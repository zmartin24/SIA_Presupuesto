using DevExpress.Office.Utils;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Globalization;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class RequerimientoMensualSeguimientoPresentador
    {
        private readonly IRequerimientoMensualSeguimientoVista requerimientoMensualSeguimientoVista;

        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        private IGeneralServicio generalServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IPeriodoServicio periodoServicio;

        public RequerimientoMensualSeguimientoPresentador(IRequerimientoMensualSeguimientoVista requerimientoMensualSeguimientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;

            this.requerimientoMensualSeguimientoVista = requerimientoMensualSeguimientoVista;
        }

        public void CargarServicios()
        {
            this.requerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
        }

        //public void LlenarGrid()
        //{
        //    this.requerimientoMensualSeguimientoVista.listaGridData = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalle(requerimientoMensualBienServicioDetalleVista.idReqMenBieSer);
        //}
        //public void TraerRequerimientoBienServicio()
        //{
        //    RequerimientoMensualBienServicio objReq = this.requerimientoMensualBienServicioServicio.BuscarRequerimientoMensualBienServicio(this.requerimientoMensualBienServicioDetalleVista.idReqMenBieSer);

        //    this.requerimientoMensualBienServicioDetalleVista.desArea = objReq.desArea + " / " + objReq.desSubdireccion + " / " + objReq.desDireccion;
        //    this.requerimientoMensualBienServicioDetalleVista.desTipoCambio = this.generalServicio.TraerTipoCambioPresupuesto(objReq.anio, objReq.mes).valor.ToString();
        //    this.requerimientoMensualBienServicioDetalleVista.idMoneda = objReq.idMoneda;
        //    this.requerimientoMensualBienServicioDetalleVista.tipo = objReq.tipo;
        //    this.requerimientoMensualBienServicioDetalleVista.estadoReqMen = objReq.estado.ToString();
        //}

        public RequerimientoMensualDetalle BuscarDetalle(int id)
        {
            return this.requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(id);
        }

        public void IniciarDatos(int idReqMenBieSer)
        {
            this.requerimientoMensualSeguimientoVista.listaMonedas = generalServicio.ListaMonedas();
            var listaMes = UtilitarioComun.ListarMeses();

            RequerimientoMensualBienServicio objRequerimientoMensualBienServicio = this.requerimientoMensualBienServicioServicio.BuscarRequerimientoMensualBienServicio(idReqMenBieSer);
            ProgramacionAnual ObjProgramacionAnual = this.programacionAnualServicio.BuscarPorCodigo(objRequerimientoMensualBienServicio.idProAnu != null ? (Int32)objRequerimientoMensualBienServicio.idProAnu : 0);
            this.requerimientoMensualSeguimientoVista.desPrespupuesto = ObjProgramacionAnual != null ? ObjProgramacionAnual.descripcion : "NO TIENE ASIGNADO PRESUPUESTO ANUAL";
            this.requerimientoMensualSeguimientoVista.idMoneda = objRequerimientoMensualBienServicio.idMoneda;

            
            if (listaMes != null && listaMes.Count > 0)
            {
                this.requerimientoMensualSeguimientoVista.listaMeses = listaMes;
                this.requerimientoMensualSeguimientoVista.idMes = objRequerimientoMensualBienServicio.mes;
            }

        }
        private void LlenarCombos()
        {
            this.requerimientoMensualSeguimientoVista.listaMonedas = generalServicio.ListaMonedas();
        }
        //public void llenarGridForebise()
        //{
        //    this.requerimientoMensualSeguimientoVista.listaForebise = this.requerimientoMensualBienServicioServicio
        //        .TraerReporteRequerimientoMensualSeguimientoForebise(this.requerimientoMensualSeguimientoVista.idReqMenBieSer, this.requerimientoMensualSeguimientoVista.idMoneda);
        //}
        public List<ReporteRequerimientoMensualSeguimientoPres> TraerReporteRequerimientoMensualSeguimiento()
        {
            if (this.requerimientoMensualSeguimientoVista.idMoneda > 0)
                return this.requerimientoMensualBienServicioServicio
                    .TraerReporteRequerimientoMensualSeguimiento(this.requerimientoMensualSeguimientoVista.idReqMenBieSer, this.requerimientoMensualSeguimientoVista.idMoneda);
            else
                return null;
        }
        public List<ReporteRequerimientoMensualSeguimientoDetallePres> TraerReporteRequerimientoMensualSeguimientoDetalle()
        {
            if (this.requerimientoMensualSeguimientoVista.idMoneda > 0)
                return this.requerimientoMensualBienServicioServicio
                    .TraerReporteRequerimientoMensualSeguimientoDetalle(this.requerimientoMensualSeguimientoVista.idReqMenBieSer, this.requerimientoMensualSeguimientoVista.idMoneda);
            else
                return null;
        }
        public List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> TraerReporteRequerimientoMensualSeguimientoForebiseCabecera()
        {
            if (this.requerimientoMensualSeguimientoVista.idMoneda > 0)
                return this.requerimientoMensualBienServicioServicio
                    .TraerReporteRequerimientoMensualSeguimientoForebiseCabecera(this.requerimientoMensualSeguimientoVista.idReqMenBieSer, this.requerimientoMensualSeguimientoVista.idMoneda);
            else
                return null;
        }

        public string BuscarSimboloMoneda(int idReq)
        {
            string moneda = string.Empty;
            var requerimiento = requerimientoMensualBienServicioServicio.BuscarPorCodigo(idReq);
            if (requerimiento != null)
            {
                var objmoneda = generalServicio.BuscarMoneda(requerimiento.idMoneda);
                if (objmoneda != null)
                    moneda = objmoneda.abreviatura;
            }
            return moneda;
        }

        
    }
}