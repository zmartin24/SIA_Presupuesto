using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class GastoRecurrenteDetallePresentador
    {
        private readonly IGastoRecurrenteDetalleVista gastoRecurrenteDetalleVista;
        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;
        private IConfiguracionPAAServicio configuracionPAAServicio;
        private IFuenteFinanciamientoServicio fuenteFinanciamientoServicio;
        private IUbigeoServicio ubigeoServicio;
        
        

        private GastoRecurrenteDetalle gastoRecurrenteDetalle;
        private bool esModificacion;
        private GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento;
        private bool esNuevaArea;
        private Producto producto;
        private PlanCuenta planCuenta;

        public GastoRecurrenteDetallePresentador(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento, GastoRecurrenteDetalle gastoRecurrenteDetalle, IGastoRecurrenteDetalleVista gastoRecurrenteDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.configuracionPAAServicio = _Contenedor.Resolver(typeof(IConfiguracionPAAServicio)) as IConfiguracionPAAServicio;
            this.fuenteFinanciamientoServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.ubigeoServicio = _Contenedor.Resolver(typeof(IUbigeoServicio)) as IUbigeoServicio;

            this.gastoRecurrenteRequerimiento = gastoRecurrenteRequerimiento;
            this.gastoRecurrenteDetalleVista = gastoRecurrenteDetalleVista;
            this.esModificacion = gastoRecurrenteDetalle != null;
            this.gastoRecurrenteDetalle = gastoRecurrenteDetalle ?? new GastoRecurrenteDetalle();

            this.producto = new Producto();
            this.planCuenta = new PlanCuenta();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            llenarCuentas();

            if (this.esModificacion)
            {
                gastoRecurrenteDetalleVista.idUnidad = (int)gastoRecurrenteDetalle.idUnidad;
                gastoRecurrenteDetalleVista.descripcion = gastoRecurrenteDetalle.descripcion;
                gastoRecurrenteDetalleVista.precio = (decimal)gastoRecurrenteDetalle.precio;
                
                /*para producto*/
                this.producto.idProducto = (int)gastoRecurrenteDetalle.idProducto;

                var cuenta = generalServicio.BuscarCuentaContable((Int32)gastoRecurrenteDetalle.idCueCon);
                if (cuenta != null)
                {
                    int vAnio = generalServicio.BuscarPlanCuenta(cuenta.idPlaCue.Value).anioEjercicio.Value;
                    CuentaContablePoco cuentaFinal = null;
                    if (cuenta.nivel == 3)
                        cuentaFinal = generalServicio.BuscarCuentaContablePoco(cuenta.idCueCon);
                    else
                        cuentaFinal = generalServicio.BuscarCuentaContablePocoN2(cuenta.idCueCon);

                    if (cuentaFinal != null)
                    {
                        gastoRecurrenteDetalleVista.codBieSer = cuenta.numCuenta + " - " + cuenta.descripcion;
                    }
                    else
                    {
                        gastoRecurrenteDetalleVista.codBieSer = "SIN CODIGO";
                    }
                }
            }
        }

        private void LlenarCombos()
        {
            gastoRecurrenteDetalle.idCueCon = gastoRecurrenteDetalle.idCueCon;
            gastoRecurrenteDetalleVista.listaUnidades = generalServicio.ListaUnidad();
            gastoRecurrenteDetalleVista.idUnidad = 4;
        }

        public void llenarCuentas()
        {
            planCuenta = generalServicio.ListaPlanCuenta().Where(x => x.anioEjercicio <= gastoRecurrenteRequerimiento.anio).OrderByDescending(o => o.anioEjercicio).FirstOrDefault();
            if (esModificacion)
            {
                planCuenta = generalServicio.BuscarPlanCuenta((int)generalServicio.BuscarCuentaContablePoco((int)gastoRecurrenteDetalle.idCueCon).idPlaCue) != null ? generalServicio.BuscarPlanCuenta((int)generalServicio.BuscarCuentaContablePoco((int)gastoRecurrenteDetalle.idCueCon).idPlaCue) :
                    generalServicio.ListaPlanCuenta().Where(x => x.anioEjercicio <= gastoRecurrenteRequerimiento.anio).SingleOrDefault();
            }
            var listaCuentaContable = generalServicio.TraerListaCuentaContableRubro(1, (int)planCuenta.anioEjercicio);

            if (listaCuentaContable != null)
            {
                gastoRecurrenteDetalleVista.listaCuentaContable = listaCuentaContable;
                if (listaCuentaContable.Count > 0)
                    gastoRecurrenteDetalleVista.idCueCon = gastoRecurrenteDetalle.idCueCon == 0 ? listaCuentaContable.First().idCueCon : (Int32)gastoRecurrenteDetalle.idCueCon;
            }
        }

        private GastoRecurrenteRequerimiento IngresarGasRecReq()
        {
            GastoRecurrenteRequerimiento nuevoGasRecReq = null;
            if (this.gastoRecurrenteRequerimiento != null)
            {
                var gasRecReq = this.gastoRecurrenteRequerimiento;
                nuevoGasRecReq = gastoRecurrenteServicio.BuscarReqPorCodigo(gasRecReq.idGasRecReq);
                if (nuevoGasRecReq == null)
                {
                    nuevoGasRecReq = new GastoRecurrenteRequerimiento();
                    nuevoGasRecReq.idArea = gasRecReq.idArea;
                    nuevoGasRecReq.idGasRec = gasRecReq.idGasRec;
                    
                    nuevoGasRecReq.usuCrea = gastoRecurrenteDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevoGasRecReq.fechaCrea = DateTime.Now;
                    nuevoGasRecReq.estado = Estados.Activo;
                    //programacionAnualServicio.NuevoArea(nuevoPaaReq);
                    esNuevaArea = true;
                }
            }
            return nuevoGasRecReq;
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            gastoRecurrenteDetalle.idCueCon = gastoRecurrenteDetalleVista.idCueCon;
            gastoRecurrenteDetalle.idUnidad = gastoRecurrenteDetalleVista.idUnidad;
            gastoRecurrenteDetalle.descripcion = gastoRecurrenteDetalleVista.descripcion.ToUpper();
            gastoRecurrenteDetalle.precio = gastoRecurrenteDetalleVista.precio;
            gastoRecurrenteDetalle.precioOrigen = gastoRecurrenteDetalleVista.precio;

            gastoRecurrenteDetalle.idProducto = this.producto == null ? 0 : this.producto.idProducto;
            
            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                gastoRecurrenteDetalle.fechaEdita = DateTime.Now;
                gastoRecurrenteDetalle.usuEdita = gastoRecurrenteDetalleVista.UsuarioOperacion.NomUsuario;
                resultado = gastoRecurrenteServicio.ModificarDetalles(gastoRecurrenteDetalle);
            }
            else
            {
                GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento_ = IngresarGasRecReq();
                if (gastoRecurrenteRequerimiento_ != null)
                {
                    gastoRecurrenteDetalle.idGasRecReq = gastoRecurrenteRequerimiento_.idGasRecReq;
                    gastoRecurrenteDetalle.fechaCrea = DateTime.Now;
                    gastoRecurrenteDetalle.usuCrea = gastoRecurrenteDetalleVista.UsuarioOperacion.NomUsuario;
                    gastoRecurrenteDetalle.estado = Estados.Activo;
                    resultado = gastoRecurrenteServicio.NuevoDetalle(gastoRecurrenteDetalle);
                }
            }
            return resultado != null ? resultado.esCorrecto : false;
        }

        public void ActualizarTotal()
        {
            //programacionAnualDetalleVista.total = programacionAnualDetalleVista.precio * programacionAnualDetalleVista.cantidad * programacionAnualDetalleVista.dias;
        }

        public void AsignarProducto(Producto producto)
        {
            if (producto != null)
            {
                this.producto = producto;
                gastoRecurrenteDetalleVista.descripcion = producto.Descripcion;
            }
        }
        
    }
}
