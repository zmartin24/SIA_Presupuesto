using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WebForm.Reporte;
using SIA_Presupuesto.WebForm.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIA_Presupuesto.WebForm.Helper
{
    public enum TipoReporteWeb
    {
        ReqBieSer,
        ReqBieSerDireccion,
        PacGeneral,
        PacGeneralDireccion,
        PacDireccion,
        GasRecGeneral,
        GasRecDireccion,
        ConsPorDir,
        ResPresPorSub,
        CertificacionPresupuestal,
        CalPresAnu,
        CalEvaReajuste,
        ConsEvaReaPorDir,
        ResEvaReajuste,
        ReqRecHum,
        ReqRecHumImp,
        ReqBieSerDetMen,
        ImprimirEvaluacion,
        EjecucionPreMen,
        EjecucionPreMenFec,
        ImprimirEvaluacionSaldoGrupo,

        //Requerimiento Mensual de Bienes y Servicios
        ReqMensualBieSer,
        ReqMensualBieSerDireccion
    }

    public class ReporteHelper
    {
        static Dictionary<TipoReporteWeb, string> reportDisplayNames = new Dictionary<TipoReporteWeb, string>();
        static object reportDisplayNamesLockObject = new object();
        static Dictionary<TipoReporteWeb, string> ReportDisplayNames
        {
            get
            {
                lock (reportDisplayNamesLockObject)
                {
                    if (reportDisplayNames.Count == 0)
                        PopuplateReportNames(reportDisplayNames);
                    return reportDisplayNames;
                }
            }
        }

        public static string GetReportDisplayName(TipoReporteWeb rType)
        {
            return ReportDisplayNames[rType];
        }
        static void PopuplateReportNames(Dictionary<TipoReporteWeb, string> names)
        {
            names[TipoReporteWeb.ReqBieSer] = "Requerimiento de Bienes y Servicios";
            names[TipoReporteWeb.ReqBieSerDireccion] = "Requerimiento de Bienes y Servicios";
            names[TipoReporteWeb.PacGeneral] = "Plan Anual de Contrataciones Agrupado por Cuenta";
            names[TipoReporteWeb.PacGeneralDireccion] = "Plan Anual de Contrataciones Agrupado por Dirección";
            names[TipoReporteWeb.PacDireccion] = "Plan Anual de Contrataciones por Dirección";
            names[TipoReporteWeb.GasRecGeneral] = "Gastos Recurrentes";
            names[TipoReporteWeb.GasRecDireccion] = "Gastos Recurrentes por Dirección";
            names[TipoReporteWeb.ConsPorDir] = "Presupuesto Anual Consolidado por Direcciones";
            names[TipoReporteWeb.CertificacionPresupuestal] = "Certificación Presupuestal";
            names[TipoReporteWeb.ResPresPorSub] = "Resumen de Presupuesto Anual Por Subdirecciones";
            names[TipoReporteWeb.CalPresAnu] = "Calendario de Presupuesto Anual";
            names[TipoReporteWeb.CalEvaReajuste] = "Calendario de Evaluación y Reajuste de Presupuesto Anual ";
            names[TipoReporteWeb.ConsEvaReaPorDir] = "Evaluación y Reajuste Consolidado por Direcciones";
            names[TipoReporteWeb.ResEvaReajuste] = "Resumen de Evaluación y Reajuste Por Subdirecciones";
            names[TipoReporteWeb.ReqRecHum] = "Requerimiento de Recursos Humanos";
            names[TipoReporteWeb.ReqRecHumImp] = "Requerimiento de Recursos Humanos con Importe";
            names[TipoReporteWeb.ReqBieSerDetMen] = "Requerimiento de Bienes y Servicios Detalles Mensualizado";
            names[TipoReporteWeb.ImprimirEvaluacion] = "Reporte por Evaluación";
            names[TipoReporteWeb.EjecucionPreMen] = "Resumen de Ejecución de Presupuesto Mensual";
            names[TipoReporteWeb.EjecucionPreMenFec] = "Resumen de Ejecución de Presupuesto Mensual por Fechas";
            names[TipoReporteWeb.ImprimirEvaluacionSaldoGrupo] = "Imprimir Saldos";

            // Requerimiento Mensual de Bienes y Servicios.
            names[TipoReporteWeb.ReqMensualBieSer] = "Requerimiento Mensual de Bienes y Servicios";
            names[TipoReporteWeb.ReqMensualBieSerDireccion] = "Requerimiento Mensual de Bienes y Servicios por Dirección";
        }

        public static XtraReport CrearReporte(string queryString)
        {
            var args = Util.DeserializeCallbackArgs(queryString);
            if (args.Count == 0)
                return null;
            TipoReporteWeb tReporte;
            if (!Enum.TryParse(args[0], out tReporte))
                return null;
            //if (args.Count > 2)
            //{
            //    //return null;//CrearReporteOtros(tReporte, args);
            //    var itemID = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
            //    var itemIdDireccion = !string.IsNullOrEmpty(args[2]) ? int.Parse(args[2]) : 0;
            //    return CrearReporteOtros(tReporte, itemID, itemIdDireccion);
            //}
            //else
            //{
            int itemID = 0;
            if (args.Count == 2 && int.TryParse(args[1], out itemID))
            {
                return CrearReporte(tReporte, itemID);
            }
            else
            {
                return CrearReporteOtros(tReporte, args);
            }
            //}
        }

        public static XtraReport CrearReporte(TipoReporteWeb TipoReporteWeb, int id)
        {
            switch (TipoReporteWeb)
            {
                case TipoReporteWeb.ReqBieSer:
                    return CrearReporteRequerimientoBienServicio(id, null, false);
                case TipoReporteWeb.ReqBieSerDireccion:
                    return CrearReporteRequerimientoBienServicio(id, null, true);
                case TipoReporteWeb.ReqRecHum:
                    //return CrearReporteRequerimientoRRHH(2022, 45, 0);
                    return CrearReporteRequerimientoRRHH(DateTime.Now.Year, 0, 0, id);
                case TipoReporteWeb.ReqBieSerDetMen:
                    return CrearReporteRequerimientoBienServicioDetalleMensualizado(id);
                case TipoReporteWeb.ReqMensualBieSer:
                    return CrearReporteRequerimientoMensualBienServicio(id, false);
            }
            return null;
        }
        public static XtraReport CrearReporteOtros(TipoReporteWeb TipoReporteWeb, List<string> parametros)
        {
            var idSubdireccion = 0;
            switch (TipoReporteWeb)
            {
                case TipoReporteWeb.PacGeneral:
                    var id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    var idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    return CrearReportePac(id, "01", idDireccion,0);
                case TipoReporteWeb.PacGeneralDireccion:
                    id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    return CrearReportePac(id, "02", idDireccion, 0);
                case TipoReporteWeb.PacDireccion:
                    id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    var codReporte = !string.IsNullOrEmpty(parametros[2]) ? parametros[2].ToString() : "01";
                    idDireccion = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    var idFueFin = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    return CrearReportePac(id, codReporte, idDireccion, idFueFin);
                case TipoReporteWeb.ReqBieSerDireccion:
                    id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idSubdireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    string tipo = parametros[3];
                    int idMoneda = Convert.ToInt32(parametros[5]);
                    return CrearReporteRequerimientoBienServicio(id, idSubdireccion, tipo, Convert.ToInt32(parametros[4]), idMoneda);
                case TipoReporteWeb.GasRecGeneral:
                    id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    return CrearReporteGasRec(id, true, false, idDireccion);
                case TipoReporteWeb.GasRecDireccion:
                    id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    return CrearReporteGasRec(id, false, true, idDireccion);
                case TipoReporteWeb.ConsPorDir:
                    var anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    return CrearReporteConsolidadoPorDirecciones(anio);
                case TipoReporteWeb.ResPresPorSub:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    return CrearReporteResumenPorSubDirecciones(anio, idDireccion);
                case TipoReporteWeb.CertificacionPresupuestal:
                    id = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    return CrearReporteCertificacionPresupuestal(id);
                case TipoReporteWeb.ResEvaReajuste:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    int idGruPre = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    int mesReporte = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    int mesReporteEva = !string.IsNullOrEmpty(parametros[5]) ? int.Parse(parametros[5]) : 0;
                    return CrearReporteResumenPorSubDireccionesEvaReajuste(anio, idDireccion, idGruPre, mesReporte, mesReporteEva);
                case TipoReporteWeb.ConsEvaReaPorDir:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idFueFin = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    int idProAnu = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    mesReporte = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    int mesReporteRea = !string.IsNullOrEmpty(parametros[5]) ? int.Parse(parametros[5]) : 0;
                    return CrearReporteConsolidadoEvalReajuste(anio, idFueFin, idProAnu, mesReporte, mesReporteRea);
                case TipoReporteWeb.CalPresAnu:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idFueFin = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    idProAnu = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    return CrearReporteCalendarioPresAnual(anio, idFueFin, idProAnu);
                case TipoReporteWeb.CalEvaReajuste:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idFueFin = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    idProAnu = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    mesReporte = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    return CrearReporteCalendarioEvalReajuste(anio, idFueFin, idProAnu, mesReporte);
                case TipoReporteWeb.ReqRecHum:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    idSubdireccion = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    return CrearReporteRequerimientoRRHH(anio, idDireccion, idSubdireccion, 0);
                case TipoReporteWeb.ReqRecHumImp:
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idMoneda = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    idDireccion = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    idSubdireccion = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    return CrearReporteRequerimientoRRHHImp(anio, idMoneda, idDireccion, idSubdireccion, 0);
                case TipoReporteWeb.ImprimirEvaluacion:
                    int idTipRep = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    anio = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    int mes = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    return CrearReporteResumenEvaFinanCorahSaal(idTipRep, anio, mes);
                case TipoReporteWeb.EjecucionPreMen:
                    idGruPre = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idProAnu = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    int idSubpresupuesto = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    idMoneda = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    return CrearReporteFondoEjecutadosSubpresupuesto(idGruPre, idProAnu, idSubpresupuesto, idMoneda);
                case TipoReporteWeb.EjecucionPreMenFec:
                    var variable = !string.IsNullOrEmpty(parametros[1]) ? parametros[1].ToString() : "Hoy";

                    DateTime fechaDesde = !string.IsNullOrEmpty(parametros[1]) ? DateTime.Parse(parametros[1]) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                     
                    DateTime fechaHasta = !string.IsNullOrEmpty(parametros[2]) ? DateTime.Parse(parametros[2]) : DateTime.Now.Date;
                    idGruPre = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    idProAnu = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    idMoneda = !string.IsNullOrEmpty(parametros[5]) ? int.Parse(parametros[5]) : 0;
                    return CrearReporteFondoEjecutadosSubpresupuestoEntreFechas(fechaDesde, fechaHasta, idGruPre, idProAnu, idMoneda);
                case TipoReporteWeb.ImprimirEvaluacionSaldoGrupo:
                    
                    anio = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    mesReporteEva = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    mesReporteRea = !string.IsNullOrEmpty(parametros[3]) ? int.Parse(parametros[3]) : 0;
                    return CrearReporteSaldoPorGrupo(anio, mesReporteEva, mesReporteRea);
                
                case TipoReporteWeb.ReqMensualBieSerDireccion:
                    idDireccion = !string.IsNullOrEmpty(parametros[1]) ? int.Parse(parametros[1]) : 0;
                    idSubdireccion = !string.IsNullOrEmpty(parametros[2]) ? int.Parse(parametros[2]) : 0;
                    tipo = parametros[3];
                    var idTipoRequerimiento = !string.IsNullOrEmpty(parametros[4]) ? int.Parse(parametros[4]) : 0;
                    return CrearReporteRequerimientoMensualBienServicioDireccion(idDireccion, idSubdireccion, tipo, idTipoRequerimiento, Convert.ToInt32(parametros[5]), Convert.ToInt32(parametros[6]));
            }
            return null;
        }

        static XtraReport CrearReporteRequerimientoBienServicio(int id, int? idSubdireccion, bool esDireccion)
        {
            var requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            XtraReport report = new rptRequerimientoBienServicio();
            List<RequerimientoBienServicioDetallePres> lista = new List<RequerimientoBienServicioDetallePres>();
            if (esDireccion)
            {
                lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalleDireccion(id, idSubdireccion, 2020, 63);
                report = new rptRequerimientoBienServicioDireccion(lista);
            }
            else
                lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalle(id);
            report.DataSource = lista;
            return report;
        }
        static XtraReport CrearReporteRequerimientoBienServicioDetalleMensualizado(int id)
        {
            var requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            XtraReport report = new rptRequerimientoBienServicioDetalleMensual();
            List<ReporteRequerimientoBienServicioDetalleMensualPres> lista = new List<ReporteRequerimientoBienServicioDetalleMensualPres>();
            
            lista = requerimientoBienServicioServicio.TraerReporteRequerimientoBienServicioDetalleMensual(id);
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteRequerimientoBienServicio(int id, int? idSubdireccion, string tipo, int anio, int idMoneda)
        {
            var requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            
            List<RequerimientoBienServicioDetallePres> lista = new List<RequerimientoBienServicioDetallePres>();
            if (tipo.Equals("TOD"))
            {
                lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalleDireccion(id, idSubdireccion, anio, idMoneda);
            }
            else
                lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalleDireccionOperativos(id, anio, tipo, idMoneda);

            XtraReport report = new rptRequerimientoBienServicioDireccion(lista);
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReportePac(int id, string codReporte, int? idDireccion, int? idFueFin)
        {
            var pac = IoCHelper.ResolverIoC<IPlanAnualAdquisicionServicio>();
            XtraReport report = null;
            List<object> lista = new List<object>();
            switch (codReporte)
            {
                case "01":
                    report = new rptPlanAnualAdquisicionDet();
                    lista = pac.TraerReportePlanAnualAdquisicionDetalle(id, idFueFin).ToList<object>();
                    break;
                case "02":
                    report = new rptPACDireccionFueFin();
                    lista = pac.TraerReportePlanAnualAdquisicionDireccion(id, idDireccion, idFueFin).ToList<object>();
                    break;
            }
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteConsolidadoPorDirecciones(int anio)
        {
            var programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            XtraReport report = new rptPresConsolidadoPorDireccion();
            List<ConsolidadoPresupuesto> lista = new List<ConsolidadoPresupuesto>();

            lista = programacionAnualServicio.TraerConsolidadoPresupuestoPorDirecciones(anio);
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteResumenPorSubDirecciones(int anio, int idDireccion)
        {
            var programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            XtraReport report = new rptResumenPresPorSubdireccion();
            List<ResumenPresupuestoPorSubdireccion> lista = new List<ResumenPresupuestoPorSubdireccion>();

            lista = programacionAnualServicio.TraerResumenPresupuestoPorSubdirecciones(anio, idDireccion);
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteGasRec(int id, bool esCuenta, bool esDireccion, int? idDireccion)
        {
            var gasRec = IoCHelper.ResolverIoC<IGastoRecurrenteServicio>();
            XtraReport report = null;
            List<object> lista = new List<object>();

            if (esCuenta)
            {
                report = new rptGastoRecurrenteGeneral();
                lista = gasRec.TraerReporteGastoRecurrenteDetalle(id).ToList<object>();
            }
            else
            {
                if (esDireccion)
                {
                    report = new rptGastoRecurrenteDireccion();
                    lista = gasRec.TraerReporteGastoRecurrenteDetalleDireccion(id, (Int32)idDireccion).ToList<object>();
                }
                else
                {
                    report = new rptGastoRecurrenteDireccion();
                    lista = gasRec.TraerReporteGastoRecurrenteDetalleDireccion(id, 0).ToList<object>();
                }
            }

            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteCertificacionPresupuestal(int idCerReq)
        {
            var certificacionRequerimientoServicio = IoCHelper.ResolverIoC<ICertificacionRequerimientoServicio>();
            XtraReport report = new rptCertificacionPresupuestal();
            List<ReporteCertificacionPresupuestalPres> lista = new List<ReporteCertificacionPresupuestalPres>();

            lista = certificacionRequerimientoServicio.TraerReporteCertificacionPresupuestal(idCerReq, false);
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteCalendarioPresAnual(int anio, int idFueFin, int idProAnu)
        {
            var programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            List<CalendarioPresupuestoAnual> comp = programacionAnualServicio.TraerCalendarioPresupuestoAnual(anio, idFueFin, idProAnu);
            rptCalendarioPresupuestoAnual reporte = new rptCalendarioPresupuestoAnual();

            reporte.DataSource = comp;
            return reporte;
        }

        static XtraReport CrearReporteResumenEvaFinanCorahSaal(int idTipRep, int anio, int mes)
        {
            var evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IEvaluacionMensualProgramacionServicio>();
            XtraReport report = new rptResumenFinanciamiento();
            List<ResumenEvaFinanCorahSaal> lista = new List<ResumenEvaFinanCorahSaal>();

            lista = evaluacionMensualProgramacionServicio.TraerResumenEvaFinanCorahSaal(idTipRep, anio, mes);
            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteCalendarioEvalReajuste(int anio, int idFueFin, int idProAnu, int mesReporte)
        {
            var reajusteMensualProgramacionServicio = IoCHelper.ResolverIoC<IReajusteMensualProgramacionServicio>();
            int mesReajuste = mesReporte + 1;
            int mesEvaluacion = mesReporte;

            List<CalendarioEvaluacionyAjusteAnual> comp = reajusteMensualProgramacionServicio.TraerCalendarioEvaluacionyAjusteAnual(anio, idFueFin, mesReajuste, mesEvaluacion, idProAnu);

            rptCalendarioReajusteEvaluacionAnual reporte = new rptCalendarioReajusteEvaluacionAnual();

            reporte.DataSource = comp;
            return reporte;
        }

        static XtraReport CrearReporteConsolidadoEvalReajuste(int anio, int idFueFin, int idProAnu, int mesReporte, int mesReporteRea)
        {
            var reajusteMensualProgramacionServicio = IoCHelper.ResolverIoC<IReajusteMensualProgramacionServicio>();

            List<ConsolidadoEvaluacionReajuste> comp =
            reajusteMensualProgramacionServicio.TraerConsolidadoEvaluacionReajustePorDirecciones(anio, idFueFin, mesReporteRea, mesReporte);

            rptEvaReaConsolidadoPorDireccion reporte = new rptEvaReaConsolidadoPorDireccion();
            //string titulo = "COMPROBANTE DE INGRESO";

            reporte.DataSource = comp;
            return reporte;
        }

        static XtraReport CrearReporteResumenPorSubDireccionesEvaReajuste(int anio, int idDireccion, int idGruPre, int mesReporte, int mesReporteEva)
        {
            var reajusteMensualProgramacionServicio = IoCHelper.ResolverIoC<IReajusteMensualProgramacionServicio>();

            List<EvaluacionReajustePorSubdireccion> comp = reajusteMensualProgramacionServicio.TraerResumenEvaluacionReajustePorSubdirecciones(anio, idDireccion, idGruPre, mesReporte, mesReporteEva);

            rptResumenEvaReaPorSubdireccion reporte = new rptResumenEvaReaPorSubdireccion();

            reporte.DataSource = comp;
            return reporte;
        }
        
        static XtraReport CrearReporteFondoEjecutadosSubpresupuesto(int idGruPre, int idPresupuesto, int idSubpresupuesto, int idMoneda)
        {
            var evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IEvaluacionMensualProgramacionServicio>();

            List<FondoEjecutadosSubpresupuesto> comp = evaluacionMensualProgramacionServicio.TraerFondoEjecutadosSubpresupuesto(idMoneda, idGruPre, idPresupuesto, idSubpresupuesto);
            rptFondoEjecutadosSubpresupuesto reporte = new rptFondoEjecutadosSubpresupuesto();
            reporte.DataSource = comp;
            return reporte;
        }

        static XtraReport CrearReporteFondoEjecutadosSubpresupuestoEntreFechas(DateTime fechaDesde, DateTime fechaHasta, int idGruPre, int idPresupuesto, int idMoneda)
        {
            var evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IEvaluacionMensualProgramacionServicio>();

            List<FondoEjecutadoFecha> comp = evaluacionMensualProgramacionServicio.TraerFondoEjecutadosFechas(idMoneda, idGruPre, idPresupuesto, fechaDesde, fechaHasta);
            rptFondoEjecutadoPorFechaPresu reporte = new rptFondoEjecutadoPorFechaPresu();

            reporte.DataSource = comp;
            return reporte;
        }

        static XtraReport CrearReporteSaldoPorGrupo(int anio, int mesEva, int mesRea)
        {
            var generalReporteServicio = IoCHelper.ResolverIoC<IGeneralReporteServicio>();

            rptSaldoEvaluacionReajustePorDireccion reporte = new rptSaldoEvaluacionReajustePorDireccion();

            reporte.DataSource = generalReporteServicio.SaldosEvaluacionReajustePorDirecciones(anio, mesRea, mesEva);
            return reporte;
        }

        static XtraReport CrearReporteRequerimientoRRHH(int anio, int idDireccion, int idSubdireccion, int idReqRecHum)
        {
            var requerimientoRecursoHumanoServicio = IoCHelper.ResolverIoC<IRequerimientoRecursoHumanoServicio>();

            List<ReporteRequerimientoRRHHPres> comp = requerimientoRecursoHumanoServicio.TraerReporteRequerimientoRRHHDireccionArea(anio, idDireccion, idSubdireccion, idReqRecHum);

            rptRequerimientoRRHH reporte = new rptRequerimientoRRHH();

            reporte.DataSource = comp;
            return reporte;
        }
        static XtraReport CrearReporteRequerimientoRRHHImp(int anio, int idMoneda, int idDireccion, int idSubdireccion, int idReqRecHum)
        {
            var requerimientoRecursoHumanoServicio = IoCHelper.ResolverIoC<IRequerimientoRecursoHumanoServicio>();

            List<ReporteRequerimientoRRHHDireccionImportePres> comp = requerimientoRecursoHumanoServicio.TraerReporteRequerimientoRRHHDireccionImporte(anio, idDireccion, idSubdireccion, idReqRecHum, idMoneda);

            rptRequerimientoRRHHImportes reporte = new rptRequerimientoRRHHImportes(comp);

            reporte.DataSource = comp;
            return reporte;
        }

        protected const string formatoFecha = "yyyy-MM-dd";
        protected string FormatoFecha(Nullable<DateTime> fecha)
        {
            if (fecha == null) return "null";
            return fecha.Value.ToString(formatoFecha);
        }


        #region Reporte Requerimientos Mensuales Bienes y Servicios

        static XtraReport CrearReporteRequerimientoMensualBienServicio(int id, bool esDireccion)
        {
            //var requerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            //XtraReport report = new rptRequerimientoMensualBienServicio();
            //List<RequerimientoMensualDetallePres> lista = new List<RequerimientoMensualDetallePres>();
            //if (esDireccion)
            //{
                
            //    lista = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalle(id);
            //}
            //else
            //    lista = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalle(id);
            
            //report = new rptRequerimientoBienServicioDireccion();

            var requerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            XtraReport report = new rptRequerimientoMensualBienServicio();
            List<RequerimientoMensualDetallePres> lista = new List<RequerimientoMensualDetallePres>();
            if (esDireccion)
            {
                report = new rptRequerimientoBienServicioDireccion();
            }
            else
                lista = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalle(id);
            

            report.DataSource = lista;
            return report;
        }

        static XtraReport CrearReporteRequerimientoMensualBienServicioDireccion(int idDireccion, int idSubdireccion, string tipo, int idTipoRequerimiento, int anio, int mes)
        {
            var requerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            XtraReport report = new rptRequerimientoMensualBienServicioDireccion();
            List<RequerimientoMensualDetallePres> lista = new List<RequerimientoMensualDetallePres>();
            lista = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalleDireccion(idDireccion, idSubdireccion, tipo, idTipoRequerimiento, anio, mes);
            report.DataSource = lista;
            return report;
        }

        #endregion
    }
}