using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaGastoRecurrenteDetallePresentador
    {
        private readonly IListaGastoRecurrenteDetalleVista listaGastoRecurrenteDetalleVista;

        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;
        
        public ListaGastoRecurrenteDetallePresentador(IListaGastoRecurrenteDetalleVista listaGastoRecurrenteDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;

            this.listaGastoRecurrenteDetalleVista = listaGastoRecurrenteDetalleVista;
        }
        private bool esNuevaArea;

        public void CargarServicios()
        {
            this.gastoRecurrenteServicio = IoCHelper.ResolverIoC<IGastoRecurrenteServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
        }

        public void ObtenerDatosListado()
        {
            listaGastoRecurrenteDetalleVista.listaDatosPrincipales = gastoRecurrenteServicio.TraerListaGastoRecurrenteRequerimiento(listaGastoRecurrenteDetalleVista.idGasRec); 
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        public void IniciarDatos(int id)
        {
            LlenarCombos();
            GastoRecurrenteRequerimiento planAnualAdquisicionRequerimiento = this.gastoRecurrenteServicio.BuscarReqPorCodigo(id);
            if (planAnualAdquisicionRequerimiento == null)
                return;
        }

        private void LlenarCombos()
        {
            //listaGastoRecurrenteDetalleVista.listaUnidades = generalServicio.ListaUnidad();
            //listaGastoRecurrenteDetalleVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual
        }

        public string BuscarSimboloMoneda(int idPac)
        {
            string moneda = string.Empty;
            var pac = this.gastoRecurrenteServicio.Buscar(idPac);
            if(pac != null)
            {
                var objmoneda = generalServicio.BuscarMoneda((Int32)pac.idMoneda);
                if (objmoneda != null)
                    moneda = objmoneda.abreviatura;
            }
            return moneda;
        }

        private bool esModificacion;
        public Resultado GuardarDatos(string args)
        {
            Resultado resultado = null;
            //var callbackArgs = Util.DeserializeCallbackArgs(args);

            //RequerimientoBienServicioDetalle requerimientoBienServicioDetalle = null;
            //if (callbackArgs[0] == "Nuevo")
            //{
            //    requerimientoBienServicioDetalle = new RequerimientoBienServicioDetalle();
            //}
            //else if (callbackArgs[0] == "Editar")
            //{
            //    int id = int.Parse(callbackArgs[1]);
            //    requerimientoBienServicioDetalle = planAnualAdquisicionServicio.BuscarPorCodigoDetalle(id);
            //    esModificacion = true;
            //}

            //if (requerimientoBienServicioDetalle == null)
            //    return null;

            //requerimientoBienServicioDetalle.idUnidad = listaPacDetalleVista.idUnidad;
            //requerimientoBienServicioDetalle.idCueCon = listaPacDetalleVista.idCueCon;
            //requerimientoBienServicioDetalle.descripcion = listaPacDetalleVista.descripcion;
            //requerimientoBienServicioDetalle.justificacion = listaPacDetalleVista.justificacion;
            //requerimientoBienServicioDetalle.precio = listaPacDetalleVista.precio;
            //requerimientoBienServicioDetalle.idProducto = listaPacDetalleVista.idProducto;

            ////Modificamos todos los detalles
            //if (this.esModificacion)
            //{
            //    requerimientoBienServicioDetalle.fechaEdita = DateTime.Now;
            //    requerimientoBienServicioDetalle.usuEdita = listaPacDetalleVista.nomUsuario;
            //    resultado = planAnualAdquisicionServicio.ModificarDetallesSinClonar(requerimientoBienServicioDetalle);
            //}
            //else
            //{
            //    requerimientoBienServicioDetalle.idReqBieSer = listaPacDetalleVista.idReqBieSer;
            //    requerimientoBienServicioDetalle.fechaCrea = DateTime.Now;
            //    requerimientoBienServicioDetalle.usuCrea = listaPacDetalleVista.nomUsuario;
            //    requerimientoBienServicioDetalle.estado = Estados.Activo;
            //    resultado = planAnualAdquisicionServicio.NuevoDetalle(requerimientoBienServicioDetalle);
            //}


            return resultado;
        }

        public void AsignarProducto(Producto producto)
        {
            //if (producto != null)
            //{
            //    this.producto = producto;
            //    requerimientoBienServicio.descripcion = producto.Descripcion;
            //}
        }

        public void ObtenerDatosProductos()
        {
            //int idCuenta = requerimientoBienServicioDetalleVista.idCueCon;
            //var Cuenta = generalServicio.BuscarCuentaContable(idCuenta);
            //if (Cuenta != null)
            //    requerimientoBienServicioDetalleVista.listaDatosProductos = generalServicio.ListaProducto(Cuenta.numCuenta);

           // listaGastoRecurrenteDetalleVista.listaDatosProductos = generalServicio.ListaProducto();
        }

        public int BuscarIDUnidadProducto(int id)
        {
            int idUnidad = 0;
            var producto = generalServicio.BuscarProducto(id);
            if (producto != null)
            {
                idUnidad = producto.idUnidad;
            }
            return idUnidad;
        }

        public GastoRecurrenteRequerimiento BuscarPacReq(int id)
        {
            return this.gastoRecurrenteServicio.BuscarReqPorCodigo(id);
        }

        public GastoRecurrenteDetalle BuscarDetalle(int id)
        {
            return this.gastoRecurrenteServicio.BuscarDetallePorCodigo(id);
        }
    }
}

