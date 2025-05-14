using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class PlanAnualAdquisicionRequerimientoPresentador
    {
        private readonly IPlanAnualRequerimientoVista planAnualRequerimientoVista;

        private PlanAnualAdquisicion planAnualAdquisicion;
        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;

        public PlanAnualAdquisicionRequerimientoPresentador(PlanAnualAdquisicion planAnualAdquisicion, IPlanAnualRequerimientoVista programacionAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.planAnualRequerimientoVista = programacionAnualVista;
            this.planAnualAdquisicion = planAnualAdquisicion;
        }

        public void ObtenerDatosListado()
        {
            planAnualRequerimientoVista.listaDatosPrincipales = planAnualAdquisicionServicio.TraerListaPlanAnualAdquisicionRequerimiento(planAnualAdquisicion.idPaa);
        }

        public PlanAnualAdquisicionRequerimiento BuscarArea(int id)
        {
            return this.planAnualAdquisicionServicio.BuscarReqPorCodigo(id);
        }

        public PlanAnualAdquisicionDetalle BuscarDetalle(int id)
        {
            return this.planAnualAdquisicionServicio.BuscarDetallePorCodigo(id);
        }

        public void IniciarDatos()
        {

        }

        public bool AnularArea()
        {
            bool respuesta = false;
            if (planAnualRequerimientoVista.planAnualAdquisicionRequerimientoPres != null)
                respuesta = this.planAnualAdquisicionServicio.AnularPaaReqPres(planAnualRequerimientoVista.planAnualAdquisicionRequerimientoPres, planAnualRequerimientoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool AnularDetalle()
        {
            bool respuesta = false;
            if (planAnualRequerimientoVista.planAnualAdquisicionDetalle != null)
                respuesta = this.planAnualAdquisicionServicio.AnularDetalle(planAnualRequerimientoVista.planAnualAdquisicionDetalle, planAnualRequerimientoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarMontoArea(int mes, decimal importe)
        {
            bool respuesta = false;
            //if (planAnualRequerimientoVista.ProgramacionAnualArea != null)
            //{
            //    var paa = planAnualRequerimientoVista.ProgramacionAnualArea;
            //    ProgramacionAnualArea nuevaArea = null;
            //    nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);
            //    if(nuevaArea == null)
            //    {
            //        nuevaArea = new ProgramacionAnualArea();
            //        nuevaArea.idArea = paa.idArea;
            //        nuevaArea.idCueCon = paa.idCueCon;
            //        nuevaArea.idProAnu = paa.idProAnu;
            //        //nuevaArea.mes = mes;
            //        //nuevaArea.importe = importe;
            //        nuevaArea.usuCrea = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
            //        nuevaArea.fechaCrea = DateTime.Now;
            //        nuevaArea.estado = Estados.Activo;
            //        respuesta = programacionAnualServicio.NuevoArea(nuevaArea).esCorrecto;
            //    }
            //    else
            //    {
            //        nuevaArea.idArea = paa.idArea;
            //        nuevaArea.idCueCon = paa.idCueCon;
            //        nuevaArea.idProAnu = paa.idProAnu;
            //        //nuevaArea.mes = mes;
            //        //nuevaArea.importe = importe;
            //        nuevaArea.usuEdita = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
            //        nuevaArea.fechaEdita = DateTime.Now;

            //        respuesta = programacionAnualServicio.ModificarAreas(nuevaArea).esCorrecto;
            //    }
            //}
            ObtenerDatosListado();
            return respuesta;
        }
        private bool esNuevaArea;
        private ProgramacionAnualArea IngresarMontoAreaOtro(int mes, decimal importe)
        {
            ProgramacionAnualArea nuevaArea = null;
            //if (planAnualRequerimientoVista.ProgramacionAnualArea != null)
            //{
            //    var paa = planAnualRequerimientoVista.ProgramacionAnualArea;
            //    nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);
            //    if (nuevaArea == null)
            //    {
            //        nuevaArea = new ProgramacionAnualArea();
            //        nuevaArea.idArea = paa.idArea;
            //        nuevaArea.idCueCon = paa.idCueCon;
            //        nuevaArea.idProAnu = paa.idProAnu;
            //        //nuevaArea.mes = mes;
            //        //nuevaArea.importe = importe;
            //        nuevaArea.usuCrea = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
            //        nuevaArea.fechaCrea = DateTime.Now;
            //        nuevaArea.estado = Estados.Activo;
            //        programacionAnualServicio.NuevoArea(nuevaArea);

            //        esNuevaArea = true;
            //    }
            //    else
            //    {
            //        nuevaArea.idArea = paa.idArea;
            //        nuevaArea.idCueCon = paa.idCueCon;
            //        nuevaArea.idProAnu = paa.idProAnu;
            //        //nuevaArea.mes = mes;
            //        //nuevaArea.importe = importe;
            //        nuevaArea.usuEdita = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
            //        nuevaArea.fechaEdita = DateTime.Now;

            //        programacionAnualServicio.ModificarAreas(nuevaArea);
            //    }
            //}
            return nuevaArea;
        }

        private PlanAnualAdquisicionDetalle IngresarCantidadDetOtro(int mes, int dias, decimal precio, decimal cantidad)
        {
            PlanAnualAdquisicionDetalle nuevaArea = null;
            if (planAnualRequerimientoVista.planAnualAdquisicionDetalle != null)
            {
                var paa = planAnualRequerimientoVista.planAnualAdquisicionDetalle;
                nuevaArea = planAnualAdquisicionServicio.BuscarDetallePorCodigo(paa.idPaaDet);
                if (nuevaArea == null)
                {
                    nuevaArea = new PlanAnualAdquisicionDetalle();
                    nuevaArea.idPaaReq = paa.idPaaReq;
                    nuevaArea.subtotal = Math.Round(precio * cantidad, 2);
                    nuevaArea.usuCrea = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    planAnualAdquisicionServicio.NuevoDetalle(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    //ProgramacionAnualDetalle programacionAnualDetalle_ = programacionAnualVista.ProgramacionAnualDetalle;
                    suma = planAnualAdquisicionServicio.BuscarImporteDetalle(paa.idPaaReq, (decimal)paa.precio);
                    //nuevaArea.mes = mes;
                    nuevaArea.subtotal = suma;// + Math.Round(dias * precio * cantidad, 2);
                    nuevaArea.usuMod = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaMod = DateTime.Now;

                    planAnualAdquisicionServicio.ModificarDetalles(nuevaArea);
                }
            }
            return nuevaArea;
        }

        public bool GuardarDatos()
        {
            bool respuesta = false;
            return respuesta;
        }
        public bool IngresarMontoDetalle(int mes, decimal importe)
        {
            bool respuesta = false;

            //ProgramacionAnualArea ProgramacionAnualArea_ = IngresarMontoAreaOtro(mes, importe);

            //if (ProgramacionAnualArea_ != null)
            //{
            //    ProgramacionAnualDetalle programacionAnualDetalle_ = planAnualRequerimientoVista.ProgramacionAnualDetalle;
            //    ProgramacionAnualDetalle programacionAnualDetalle = programacionAnualServicio.BuscarPorCodigoDetalle(ProgramacionAnualArea_.idProAnuArea, programacionAnualDetalle_.descripcion,
            //                                                                                                             programacionAnualDetalle_.idUnidad, mes, programacionAnualDetalle_.precio);
            //    //nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

            //    if (programacionAnualDetalle != null)
            //    {
            //        programacionAnualDetalle.idProAnuArea = ProgramacionAnualArea_.idProAnuArea;
            //        //programacionAnualDetalle.cantidad = importe / programacionAnualDetalle.precio;
            //        //programacionAnualDetalle.importe = importe;
            //        programacionAnualDetalle.fechaEdita = DateTime.Now;
            //        programacionAnualDetalle.usuEdita = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
            //        respuesta = programacionAnualServicio.ModificarDetalles(programacionAnualDetalle, !esNuevaArea).esCorrecto;
            //    }
            //    else
            //    {
            //        programacionAnualDetalle = new ProgramacionAnualDetalle();
            //        programacionAnualDetalle.idUnidad = programacionAnualDetalle_.idUnidad;
            //        programacionAnualDetalle.descripcion = programacionAnualDetalle_.descripcion;
            //        //programacionAnualDetalle.cantidad = importe / programacionAnualDetalle_.precio;
            //        programacionAnualDetalle.precio = programacionAnualDetalle_.precio;
            //        //programacionAnualDetalle.importe = importe;
            //        programacionAnualDetalle.idProAnuArea = ProgramacionAnualArea_.idProAnuArea;
            //        programacionAnualDetalle.fechaCrea = DateTime.Now;
            //        programacionAnualDetalle.usuCrea = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
            //        programacionAnualDetalle.estado = Estados.Activo;
            //        respuesta = programacionAnualServicio.NuevoDetalle(programacionAnualDetalle, !esNuevaArea).esCorrecto;
            //    }
                
            //}

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, int dias, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle_ = IngresarCantidadDetOtro(mes, dias, precio, cantidad);

            if (planAnualAdquisicionDetalle_ != null)
            {
                PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes = planAnualAdquisicionServicio.BuscarPorCodigoPaaDetalleMes(planAnualAdquisicionDetalle_.idPaaDet, mes);

                if (planAnualAdquisicionDetalleMes != null)
                {
                    planAnualAdquisicionDetalleMes.cantidad = cantidad;
                    planAnualAdquisicionDetalleMes.fechaMod = DateTime.Now;
                    planAnualAdquisicionDetalleMes.usuMod = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;

                    respuesta = planAnualAdquisicionServicio.ModificarPaaDetMes(planAnualAdquisicionDetalleMes, !esNuevaArea).esCorrecto;
                }
                else
                {
                    planAnualAdquisicionDetalleMes = new PlanAnualAdquisicionDetalleMes();

                    planAnualAdquisicionDetalleMes.mes = mes;
                    planAnualAdquisicionDetalleMes.cantidad = cantidad;
                    planAnualAdquisicionDetalleMes.idPaaDet = planAnualAdquisicionDetalle_.idPaaDet;
                    planAnualAdquisicionDetalleMes.idReqBieSerDetMes = 0;
                    planAnualAdquisicionDetalleMes.fechaCrea = DateTime.Now;
                    planAnualAdquisicionDetalleMes.usuCrea = planAnualRequerimientoVista.UsuarioOperacion.NomUsuario;
                    planAnualAdquisicionDetalleMes.estado = Estados.Activo;
                    
                    respuesta = planAnualAdquisicionServicio.NuevoPaaDetMes(planAnualAdquisicionDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }
        
    }
}
