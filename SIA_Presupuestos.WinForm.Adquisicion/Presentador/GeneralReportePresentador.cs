using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class GeneralReportePresentador
    {
        private readonly IGeneralReporteVista generalReporteVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        public GeneralReportePresentador(IGeneralReporteVista generalReporteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.generalReporteVista = generalReporteVista;
        }
        public void IniciarDatos()
        {
            var listaReporte = PredeterminadoHelper.ListarTipoReporteGeneral();
            if (listaReporte != null)
            {
                generalReporteVista.listaReporte = listaReporte;
                generalReporteVista.codReporte = listaReporte.FirstOrDefault().codigo;
            }

            var listaDirecciones = generalServicio.ListaDirecciones();
            if (listaDirecciones != null)
            {
                generalReporteVista.listaDirecciones = listaDirecciones;
                generalReporteVista.idDireccion = listaDirecciones.FirstOrDefault().idDireccion;
            }
            var listaAnio = PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                generalReporteVista.listaPeriodo = listaAnio;
                generalReporteVista.codPeriodo = DateTime.Now.Year;
            }
        }

        public List<object> ListaReporte()
        {
            List<object> lista = null;
            //int vidPresupuesto = 0, vnivel = 0;

            //vidPresupuesto = this.generalReporteVista.GrupoPresupuesto != null ? this.generalReporteVista.GrupoPresupuesto.idGruPre :
            //                 this.generalReporteVista.Presupuesto != null ? this.generalReporteVista.Presupuesto.idPresupuesto :
            //                 this.generalReporteVista.Subpresupuesto != null ? this.generalReporteVista.Subpresupuesto.idSubpresupuesto : 0;

            //vnivel = this.generalReporteVista.GrupoPresupuesto != null ? 1 :
            //         this.generalReporteVista.Presupuesto != null ? 2 :
            //         this.generalReporteVista.Subpresupuesto != null ? 3 : 0;

            //vidPresupuesto = 297;
            //vnivel = 1;

            switch (this.generalReporteVista.codReporte)
            {
                case "03":
                    //lista = generalReporteServicio.TraerReporteOrdenCompraServicioComprometidas(this.generalReporteVista.codPeriodo).ToList<object>();
                    lista = generalReporteServicio.TraerReporteOrdenCompraServicioPresupuesto(this.generalReporteVista.codPeriodo, this.generalReporteVista.idPresupuesto, this.generalReporteVista.nivel, 1).ToList<object>();
                    break;
                case "04":
                    lista = generalReporteServicio.TraerReporteOrdenCompraServicioPresupuesto(this.generalReporteVista.codPeriodo, this.generalReporteVista.idPresupuesto, this.generalReporteVista.nivel, 2).ToList<object>();
                    break;
                case "05":
                    lista = generalReporteServicio.TraerReporteOrdenCompraServicioPresupuesto(this.generalReporteVista.codPeriodo, this.generalReporteVista.idPresupuesto, this.generalReporteVista.nivel, 3).ToList<object>();
                    break;
                case "06":
                    lista = generalReporteServicio.TraerReporteOrdenCompraServicioPresupuesto(this.generalReporteVista.codPeriodo, this.generalReporteVista.idPresupuesto, this.generalReporteVista.nivel, 4).ToList<object>();
                    break;
            }

            return lista;
        }
        public void ImprimirGastoRecurrente(List<object> vlista)
        {
            XtraReport reporte = new XtraReport();
            reporte = new rptOrdenCSComprometidaPresupuesto();
            //switch (this.generalReporteVista.codReporte)
            //{
            //    //case "03":
            //    //    reporte = new rptOrdenCSComprometida();
            //    //    break;

            //    case "03":
            //    case "04":
            //    case "05":
            //    case "06":
            //        reporte = new rptOrdenCSComprometidaPresupuesto();
            //        break;
            //}
            

            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = reporte;
            frm.datosReporte = vlista;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);

        }
        public void Limpiar()
        {
            this.generalReporteVista.GrupoPresupuesto = null;
            this.generalReporteVista.Presupuesto = null;
            this.generalReporteVista.Subpresupuesto = null;

        }
    }
}
