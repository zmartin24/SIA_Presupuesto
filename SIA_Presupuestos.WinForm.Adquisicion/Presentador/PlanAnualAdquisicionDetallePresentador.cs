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
    public class PlanAnualAdquisicionDetallePresentador
    {
        private readonly IPlanAnualAdquisicionDetalleVista planAnualAdquisicionDetalleVista;
        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGeneralServicio generalServicio;
        private IConfiguracionPAAServicio configuracionPAAServicio;
        private IFuenteFinanciamientoServicio fuenteFinanciamientoServicio;
        private IUbigeoServicio ubigeoServicio;
        
        private PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle;
        private bool esModificacion;
        private PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento;
        private bool esNuevaArea;
        private Producto producto;
        private UbigeoPoco ubigeoPoco;
        private PlanCuenta planCuenta;

        public PlanAnualAdquisicionDetallePresentador(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento, PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle, IPlanAnualAdquisicionDetalleVista programacionAnualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.configuracionPAAServicio = _Contenedor.Resolver(typeof(IConfiguracionPAAServicio)) as IConfiguracionPAAServicio;
            this.fuenteFinanciamientoServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.ubigeoServicio = _Contenedor.Resolver(typeof(IUbigeoServicio)) as IUbigeoServicio;

            this.planAnualAdquisicionRequerimiento = planAnualAdquisicionRequerimiento;
            this.planAnualAdquisicionDetalleVista = programacionAnualDetalleVista;
            this.esModificacion = planAnualAdquisicionDetalle != null;
            this.planAnualAdquisicionDetalle = planAnualAdquisicionDetalle ?? new PlanAnualAdquisicionDetalle();

            this.producto = new Producto();
            this.planCuenta = new PlanCuenta();

        }

        public void IniciarDatos()
        {
            LlenarCombos();
            llenarCuentas();
            if (this.esModificacion)
            {
                planAnualAdquisicionDetalleVista.itemUnico = planAnualAdquisicionDetalle.itemUnico == null ? false : (bool)planAnualAdquisicionDetalle.itemUnico;
                planAnualAdquisicionDetalleVista.tipComSel = (int)planAnualAdquisicionDetalle.tipComSel == 0 ? planAnualAdquisicionDetalleVista.tipComSel : (int)planAnualAdquisicionDetalle.tipComSel;
                planAnualAdquisicionDetalleVista.TipPro = (int)planAnualAdquisicionDetalle.TipPro == 0 ? planAnualAdquisicionDetalleVista.TipPro : (int)planAnualAdquisicionDetalle.TipPro;
                planAnualAdquisicionDetalleVista.objCon = (int)planAnualAdquisicionDetalle.objCon == 0 ? planAnualAdquisicionDetalleVista.objCon : (int)planAnualAdquisicionDetalle.objCon;
                planAnualAdquisicionDetalleVista.antecedente = planAnualAdquisicionDetalle.antecedente == null ? false : (bool)planAnualAdquisicionDetalle.antecedente;

                planAnualAdquisicionDetalleVista.desAntecedente = planAnualAdquisicionDetalle.desAntecedente;

                planAnualAdquisicionDetalleVista.idFueFin = (int)planAnualAdquisicionDetalle.idFueFin == 0 ? planAnualAdquisicionDetalleVista.idFueFin : (int)planAnualAdquisicionDetalle.idFueFin;
                planAnualAdquisicionDetalleVista.organoEncargado = (int)planAnualAdquisicionDetalle.organoEncargado == 0 ? planAnualAdquisicionDetalleVista.organoEncargado : (int)planAnualAdquisicionDetalle.organoEncargado;
                
                planAnualAdquisicionDetalleVista.idTipMon = planAnualAdquisicionRequerimiento == null ? (Int32)planAnualAdquisicionDetalle.idTipMon : (Int32)planAnualAdquisicionRequerimiento.PlanAnualAdquisicion.idMoneda;
                planAnualAdquisicionDetalleVista.tipCam = planAnualAdquisicionDetalle.tipCam == null ? 1 : (decimal)planAnualAdquisicionDetalle.tipCam;
                
                planAnualAdquisicionDetalleVista.fechaPrevista = planAnualAdquisicionDetalle.fechaPre == 0 ? planAnualAdquisicionDetalleVista.fechaPrevista : (Int32)planAnualAdquisicionDetalle.fechaPre;
                planAnualAdquisicionDetalleVista.observacion = planAnualAdquisicionDetalle.observaciones == null ? string.Empty : planAnualAdquisicionDetalle.observaciones;

                planAnualAdquisicionDetalleVista.idUnidad = (int)planAnualAdquisicionDetalle.idUnidad;
                planAnualAdquisicionDetalleVista.descripcion = planAnualAdquisicionDetalle.descripcion;
                planAnualAdquisicionDetalleVista.precio = (decimal)planAnualAdquisicionDetalle.precio;
                planAnualAdquisicionDetalleVista.valorEst = planAnualAdquisicionDetalle.valorEst == null ? planAnualAdquisicionDetalle.precio == null ? 0 : (decimal)planAnualAdquisicionDetalle.precio : (decimal)planAnualAdquisicionDetalle.valorEst;
                

                /*para producto*/
                this.producto.idProducto = (int)planAnualAdquisicionDetalle.idProducto;

                var cuenta = generalServicio.BuscarCuentaContable((Int32)planAnualAdquisicionDetalle.idCueCon);
                if (cuenta != null)
                {
                    CuentaContablePoco cuentaFinal = null;
                    if (cuenta.nivel == 3)
                        cuentaFinal = generalServicio.BuscarCuentaContablePoco(cuenta.idCueCon);
                    else
                        cuentaFinal = generalServicio.BuscarCuentaContablePocoN2(cuenta.idCueCon);

                    if (cuentaFinal != null)
                    {
                        if (cuentaFinal.numCuentaN1.Equals("33") || cuentaFinal.numCuentaN2.Equals("656"))
                        {
                            planAnualAdquisicionDetalleVista.objCon = planAnualAdquisicionDetalle == null ? 1 : (Int32)planAnualAdquisicionDetalle.objCon;
                            planAnualAdquisicionDetalleVista.codBieSer = this.producto.idProducto == 0 ? "SIN CODIGO" : generalServicio.BuscarProducto(this.producto.idProducto).CodProductoAct == null ? "SIN CODIGO" : generalServicio.BuscarProducto(this.producto.idProducto).CodProductoAct;
                        }
                        else if (cuentaFinal.numCuentaN2.Equals("631") || cuentaFinal.numCuentaN2.Equals("634") || cuentaFinal.numCuentaN2.Equals("635") || cuentaFinal.numCuentaN2.Equals("636") ||
                                 cuentaFinal.numCuentaN2.Equals("638") || cuentaFinal.numCuentaN2.Equals("639") || cuentaFinal.numCuentaN2.Equals("649") || cuentaFinal.numCuentaN2.Equals("653") || cuentaFinal.numCuentaN2.Equals("659"))

                        {
                            planAnualAdquisicionDetalleVista.objCon = planAnualAdquisicionDetalle == null ? 2 : (Int32)planAnualAdquisicionDetalle.objCon;
                            planAnualAdquisicionDetalleVista.codBieSer = cuenta.numCuenta +" - "+ cuenta.descripcion;
                        }
                        else
                        {
                            planAnualAdquisicionDetalleVista.objCon = planAnualAdquisicionDetalle == null ? 5 : (Int32)planAnualAdquisicionDetalle.objCon;
                            planAnualAdquisicionDetalleVista.codBieSer = "SIN CODIGO";
                        }
                    }
                }
            }
        }

        public bool ValidarRegistroExistente()
        {
            PlanAnualAdquisicionDetalle reg = null;
            if (!this.esModificacion || (
                                            this.esModificacion && (
                                                    !planAnualAdquisicionDetalle.idCueCon.Equals(planAnualAdquisicionDetalleVista.idCueCon)||
                                                    !planAnualAdquisicionDetalle.descripcion.Trim().ToUpper().Equals(planAnualAdquisicionDetalleVista.descripcion.Trim().ToUpper()) ||
                                                    !planAnualAdquisicionDetalle.idUnidad.Equals(planAnualAdquisicionDetalleVista.idUnidad) ||
                                                    !planAnualAdquisicionDetalle.precio.Equals(planAnualAdquisicionDetalleVista.precio)
                                                                    )
                                         )
            )
                reg = planAnualAdquisicionServicio.BuscarDetallePorVarios(planAnualAdquisicionRequerimiento.idPaaReq, planAnualAdquisicionDetalleVista.idCueCon, planAnualAdquisicionDetalleVista.descripcion.Trim().ToUpper(), planAnualAdquisicionDetalleVista.idUnidad, planAnualAdquisicionDetalleVista.precio);

            return reg == null;
        }

        private void LlenarCombos()
        {

            planAnualAdquisicionDetalle.tipComSel = planAnualAdquisicionDetalle.tipComSel == null ? 0 : planAnualAdquisicionDetalle.tipComSel;
            planAnualAdquisicionDetalle.TipPro = planAnualAdquisicionDetalle.TipPro == null ? 0 : planAnualAdquisicionDetalle.TipPro;
            planAnualAdquisicionDetalle.objCon = planAnualAdquisicionDetalle.objCon == null ? 0 : planAnualAdquisicionDetalle.objCon;
            planAnualAdquisicionDetalle.idFueFin = planAnualAdquisicionDetalle.idFueFin == null ? 0 : planAnualAdquisicionDetalle.idFueFin;
            planAnualAdquisicionDetalle.organoEncargado = planAnualAdquisicionDetalle.organoEncargado == null ? 0 : planAnualAdquisicionDetalle.organoEncargado;
            planAnualAdquisicionDetalle.idTipMon = planAnualAdquisicionDetalle.idTipMon == null ? 0 : planAnualAdquisicionDetalle.idTipMon;
            planAnualAdquisicionDetalle.idUbigeo = planAnualAdquisicionDetalle.idUbigeo == null ? 0 : planAnualAdquisicionDetalle.idUbigeo;
            planAnualAdquisicionDetalle.idCueCon = planAnualAdquisicionDetalle.idCueCon == null ? 0 : planAnualAdquisicionDetalle.idCueCon;
            planAnualAdquisicionDetalle.fechaPre = planAnualAdquisicionDetalle.fechaPre == null ? 0 : planAnualAdquisicionDetalle.fechaPre;

            if (planAnualAdquisicionDetalle.idUbigeo > 0)
            {
                ubigeoPoco = ubigeoServicio.TraerUbigeoPocoIdDistrito(Convert.ToInt32(planAnualAdquisicionDetalle.idUbigeo));
            }

            planAnualAdquisicionDetalleVista.listaUnidades = generalServicio.ListaUnidad();
            planAnualAdquisicionDetalleVista.idUnidad = 4;

            // combo tipo compra
            var listaTipCompra = configuracionPAAServicio.TraerListaConfiguracionPAA(1);
            if (listaTipCompra != null)
            {
                planAnualAdquisicionDetalleVista.listaTipoCompra = listaTipCompra;
                if (listaTipCompra.Count > 0)
                    planAnualAdquisicionDetalleVista.tipComSel = /*listaTipCompra.First().idConPaa;*/ planAnualAdquisicionDetalle.tipComSel == 0 ? (Int32)listaTipCompra.First().codigo : (Int32)planAnualAdquisicionDetalle.tipComSel;
            }

            // combo tipo proceso
            var listaTipProceso = configuracionPAAServicio.TraerListaConfiguracionPAA(2);
            if (listaTipProceso != null)
            {
                planAnualAdquisicionDetalleVista.listaTipoProceso = listaTipProceso;
                if (listaTipProceso.Count > 0)
                    planAnualAdquisicionDetalleVista.TipPro = planAnualAdquisicionDetalle.TipPro == 0 ? (Int32)listaTipProceso.First().codigo : (Int32)planAnualAdquisicionDetalle.TipPro; //listaTipProceso.First().idConPaa;
            }

            // combo objeto proceso
            var listaObjetoProceso = configuracionPAAServicio.TraerListaConfiguracionPAA(3);
            if (listaObjetoProceso != null)
            {
                planAnualAdquisicionDetalleVista.listaObjetoProceso = listaObjetoProceso;
                if (listaObjetoProceso.Count > 0)
                    planAnualAdquisicionDetalleVista.objCon = planAnualAdquisicionDetalle.objCon == 0 ? (Int32)listaObjetoProceso.First().codigo : (Int32)planAnualAdquisicionDetalle.objCon; //listaObjetoProceso.First().idConPaa;
            }
            // combo Encargado
            var listaEncargado = configuracionPAAServicio.TraerListaConfiguracionPAA(4);
            if (listaEncargado != null)
            {
                planAnualAdquisicionDetalleVista.listaEncargado = listaEncargado;
                if (listaEncargado.Count > 0)
                    planAnualAdquisicionDetalleVista.organoEncargado = planAnualAdquisicionDetalle.organoEncargado == 0 ? (Int32)listaEncargado.First().codigo : (Int32)planAnualAdquisicionDetalle.organoEncargado; //listaObjetoProceso.First().idConPaa;
            }

            // combo fuente financiamiento
            var listaFuenteFina = fuenteFinanciamientoServicio.TraerTodosActivos();
            if (listaFuenteFina != null)
            {
                planAnualAdquisicionDetalleVista.listaFuenteFinanciamiento = listaFuenteFina;
                if (listaFuenteFina.Count > 0)
                    planAnualAdquisicionDetalleVista.idFueFin = planAnualAdquisicionDetalle.idFueFin == 0 ? listaFuenteFina.First().idFueFin : (Int32)planAnualAdquisicionDetalle.idFueFin;  //listaFuenteFina.First().idFueFin;
            }

            
            // combo región
            var listaRegion = ubigeoServicio.TraerListaRegion();
            if (listaRegion != null)
            {
                planAnualAdquisicionDetalleVista.listaRegion = listaRegion;
                if (listaRegion.Count > 0)
                    planAnualAdquisicionDetalleVista.idRegion = planAnualAdquisicionDetalle.idUbigeo == 0 ? listaRegion.Where(x=>x.codSunat=="25").FirstOrDefault().idUbigeo : ubigeoPoco.idRegion;  //listaRegion.First().idUbigeo;
            }

            // combo moneda
            var listaMoneda = generalServicio.ListaMonedas();
            if (listaMoneda != null)
            {
                planAnualAdquisicionDetalleVista.listaMoneda = listaMoneda;
                if (listaMoneda.Count > 0)
                    planAnualAdquisicionDetalleVista.idTipMon = planAnualAdquisicionRequerimiento == null ? listaMoneda.First().idMoneda : (Int32)planAnualAdquisicionRequerimiento.PlanAnualAdquisicion.idMoneda; //listaMoneda.First().idMoneda;
                planAnualAdquisicionDetalleVista.tipCam = planAnualAdquisicionRequerimiento == null ? 1 : (decimal)planAnualAdquisicionRequerimiento.PlanAnualAdquisicion.tipoCambio;
            }

            // combo fecha prevista
            var listaMesPrevisto = configuracionPAAServicio.TraerListaConfiguracionPAA(5);
            if (listaMesPrevisto != null)
            {
                planAnualAdquisicionDetalleVista.listaMesPrevisto = listaMesPrevisto;
                if (listaMesPrevisto.Count > 0)
                    planAnualAdquisicionDetalleVista.fechaPrevista = planAnualAdquisicionDetalle.fechaPre == 0 ? (Int32)listaMesPrevisto.First().codigo : (Int32)planAnualAdquisicionDetalle.fechaPre; 
            }
        }
        public void llenarCuentas()
        {
            planCuenta = generalServicio.ListaPlanCuenta().Where(x => x.anioEjercicio <= planAnualAdquisicionRequerimiento.anio).OrderByDescending(o=>o.anioEjercicio).FirstOrDefault();
            if (esModificacion)
            {
                planCuenta = generalServicio.BuscarPlanCuenta((int)generalServicio.BuscarCuentaContablePoco((int)planAnualAdquisicionDetalle.idCueCon).idPlaCue) != null ? generalServicio.BuscarPlanCuenta((int)generalServicio.BuscarCuentaContablePoco((int)planAnualAdquisicionDetalle.idCueCon).idPlaCue) :
                    generalServicio.ListaPlanCuenta().Where(x => x.anioEjercicio <= planAnualAdquisicionRequerimiento.anio).SingleOrDefault();
            }

            var listaCuentaContable = generalServicio.TraerListaCuentaContableRubro(2, (int)planCuenta.anioEjercicio);

            if (listaCuentaContable != null)
            {
                planAnualAdquisicionDetalleVista.listaCuentaContable = listaCuentaContable;
                if (listaCuentaContable.Count > 0)
                    planAnualAdquisicionDetalleVista.idCueCon = planAnualAdquisicionDetalle.idCueCon == 0 ? listaCuentaContable.First().idCueCon : (Int32)planAnualAdquisicionDetalle.idCueCon;
            }
        }

        private PlanAnualAdquisicionRequerimiento IngresarPaaReq()
        {
            PlanAnualAdquisicionRequerimiento nuevoPaaReq = null;
            if (this.planAnualAdquisicionRequerimiento != null)
            {
                var paaReq = this.planAnualAdquisicionRequerimiento;
                nuevoPaaReq = planAnualAdquisicionServicio.BuscarReqPorCodigo(paaReq.idPaaReq);
                if (nuevoPaaReq == null)
                {
                    nuevoPaaReq = new PlanAnualAdquisicionRequerimiento();
                    nuevoPaaReq.idArea = paaReq.idArea;
                    nuevoPaaReq.idPaa = paaReq.idPaa;
                    
                    nuevoPaaReq.usuCrea = planAnualAdquisicionDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevoPaaReq.fechaCrea = DateTime.Now;
                    nuevoPaaReq.estado = Estados.Activo;
                    esNuevaArea = true;
                }
            }
            return nuevoPaaReq;
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            planAnualAdquisicionDetalle.itemUnico = planAnualAdquisicionDetalleVista.itemUnico;
            planAnualAdquisicionDetalle.tipComSel = planAnualAdquisicionDetalleVista.tipComSel;
            planAnualAdquisicionDetalle.TipPro = planAnualAdquisicionDetalleVista.TipPro;
            planAnualAdquisicionDetalle.objCon = planAnualAdquisicionDetalleVista.objCon;
            planAnualAdquisicionDetalle.antecedente = planAnualAdquisicionDetalleVista.antecedente;
            planAnualAdquisicionDetalle.desAntecedente = planAnualAdquisicionDetalleVista.desAntecedente.ToUpper();
            

            planAnualAdquisicionDetalle.idFueFin = planAnualAdquisicionDetalleVista.idFueFin;
            planAnualAdquisicionDetalle.idUbigeo = planAnualAdquisicionDetalleVista.idUbigeo;
            planAnualAdquisicionDetalle.idTipMon = planAnualAdquisicionDetalleVista.idTipMon;
            planAnualAdquisicionDetalle.tipCam = planAnualAdquisicionDetalleVista.tipCam;
            planAnualAdquisicionDetalle.valorEst = planAnualAdquisicionDetalleVista.valorEst;

            planAnualAdquisicionDetalle.idCueCon = planAnualAdquisicionDetalleVista.idCueCon;
            planAnualAdquisicionDetalle.idUnidad = planAnualAdquisicionDetalleVista.idUnidad;
            planAnualAdquisicionDetalle.descripcion = planAnualAdquisicionDetalleVista.descripcion.ToUpper();
            planAnualAdquisicionDetalle.precio = planAnualAdquisicionDetalleVista.precio;
            planAnualAdquisicionDetalle.fechaPre = planAnualAdquisicionDetalleVista.fechaPrevista;
            planAnualAdquisicionDetalle.observaciones = planAnualAdquisicionDetalleVista.observacion.ToUpper();

            planAnualAdquisicionDetalle.organoEncargado = planAnualAdquisicionDetalleVista.organoEncargado;

            planAnualAdquisicionDetalle.idProducto = this.producto == null ? 0 : this.producto.idProducto;
            
            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                planAnualAdquisicionDetalle.fechaMod = DateTime.Now;
                planAnualAdquisicionDetalle.usuMod = planAnualAdquisicionDetalleVista.UsuarioOperacion.NomUsuario;
                resultado = planAnualAdquisicionServicio.ModificarDetalles(planAnualAdquisicionDetalle);
            }
            else
            {
                PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento_ = IngresarPaaReq();
                if (planAnualAdquisicionRequerimiento_ != null)
                {
                    planAnualAdquisicionDetalle.idPaaReq = planAnualAdquisicionRequerimiento_.idPaaReq;
                    planAnualAdquisicionDetalle.fechaCrea = DateTime.Now;
                    planAnualAdquisicionDetalle.usuCrea = planAnualAdquisicionDetalleVista.UsuarioOperacion.NomUsuario;
                    planAnualAdquisicionDetalle.estado = Estados.Activo;
                    resultado = planAnualAdquisicionServicio.NuevoDetalle(planAnualAdquisicionDetalle);
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
                planAnualAdquisicionDetalleVista.descripcion = producto.Descripcion;
            }
        }
        public void llenarComboProvincia(int idRegion)
        {
            var listaProvincia = ubigeoServicio.TraerListaProvincia(idRegion);
            if (listaProvincia != null)
            {
                planAnualAdquisicionDetalleVista.listaProvincia = listaProvincia;
                if (listaProvincia.Count > 0)
                    planAnualAdquisicionDetalleVista.idProvincia = planAnualAdquisicionDetalle.idUbigeo == 0 ? listaProvincia.First().idUbigeo : ubigeoPoco.idProvincia; //listaProvincia.First().idUbigeo;
            }
        }
        public void llenarComboDistrito(int idProvincia)
        {
            var listaDistrito = ubigeoServicio.TraerListaDistrito(idProvincia);
            if (listaDistrito != null)
            {
                planAnualAdquisicionDetalleVista.listaDistrito = listaDistrito;
                if (listaDistrito.Count > 0)
                    planAnualAdquisicionDetalleVista.idUbigeo = planAnualAdquisicionDetalle.idUbigeo == 0 ? listaDistrito.First().idUbigeo : ubigeoPoco.idDistrito; //listaDistrito.First().idUbigeo;
            }
        }
    }
}
