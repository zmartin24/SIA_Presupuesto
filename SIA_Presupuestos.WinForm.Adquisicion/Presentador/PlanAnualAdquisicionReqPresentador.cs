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
    public class PlanAnualAdquisicionReqPresentador
    {
        private readonly IPlanAnualReqVista planAnualReqVista;

        private PlanAnualAdquisicion planAnualAdquisicion;
        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;

        public PlanAnualAdquisicionReqPresentador(PlanAnualAdquisicion planAnualAdquisicion, IPlanAnualReqVista planAnualReqVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.planAnualReqVista = planAnualReqVista;
            this.planAnualAdquisicion = planAnualAdquisicion;
        }

        public void llenarGridPrincipal()
        {
            planAnualReqVista.listaDatosPrincipales = planAnualAdquisicionServicio.TraerListaPlanAnualAdquisicionReq(planAnualAdquisicion.idPaa);
        }
        public void llenarGridDetalle()
        {
            planAnualReqVista.listaPacDetalles = planAnualAdquisicionServicio.TraerListaPlanAnualAdquisicionReqDetalle(this.planAnualReqVista.planAnualAdquisicionReqPres.idPaaReq);
        }

        public PlanAnualAdquisicionRequerimiento BuscarPlanAnualAdquisicionRequerimiento(int id)
        {
            return this.planAnualAdquisicionServicio.BuscarReqPorCodigo(id);
        }

        public PlanAnualAdquisicionDetalle BuscarPlanAnualAdquisicionDetalle(int id)
        {
            return this.planAnualAdquisicionServicio.BuscarDetallePorCodigo(id);
        }


        public bool AnularPlanAnualAdquisicionRequerimiento(PlanAnualAdquisicionRequerimiento obj)
        {
            bool respuesta = false;
            if (planAnualReqVista.planAnualAdquisicionReqPres != null)
                respuesta = this.planAnualAdquisicionServicio.AnularPaaReq(obj, planAnualReqVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool AnularDetalle()
        {
            bool respuesta = false;
            if (planAnualReqVista.planAnualAdquisicionReqDetallePres != null)
            {
                PlanAnualAdquisicionDetalle objDet = BuscarPlanAnualAdquisicionDetalle(planAnualReqVista.planAnualAdquisicionReqDetallePres.idPaaDet);
                respuesta = this.planAnualAdquisicionServicio.AnularDetalle(objDet, planAnualReqVista.UsuarioOperacion.NomUsuario).esCorrecto;
            }
            return respuesta;
        }

        public bool IngresarMontoArea(int mes, decimal importe)
        {
            bool respuesta = false;

            llenarGridDetalle();
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

        public bool GuardarDatos()
        {
            bool respuesta = false;
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int idPaaDet,int mes, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle_ = BuscarPlanAnualAdquisicionDetalle(idPaaDet);

            if (planAnualAdquisicionDetalle_ != null)
            {
                PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes = planAnualAdquisicionServicio.BuscarPorCodigoPaaDetalleMes(planAnualAdquisicionDetalle_.idPaaDet, mes);

                if (planAnualAdquisicionDetalleMes != null)
                {
                    planAnualAdquisicionDetalleMes.cantidad = cantidad;
                    planAnualAdquisicionDetalleMes.fechaMod = DateTime.Now;
                    planAnualAdquisicionDetalleMes.usuMod = planAnualReqVista.UsuarioOperacion.NomUsuario;

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
                    planAnualAdquisicionDetalleMes.usuCrea = planAnualReqVista.UsuarioOperacion.NomUsuario;
                    planAnualAdquisicionDetalleMes.estado = Estados.Activo;
                    
                    respuesta = planAnualAdquisicionServicio.NuevoPaaDetMes(planAnualAdquisicionDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            llenarGridDetalle();
            return respuesta;
        }
        
    }
}
