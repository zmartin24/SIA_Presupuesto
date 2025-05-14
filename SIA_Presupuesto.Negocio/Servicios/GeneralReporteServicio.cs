using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class GeneralReporteServicio : IGeneralReporteServicio
    {
        private IGeneralReporteRepositorio repoGeneralReporte;

        public GeneralReporteServicio(IGeneralReporteRepositorio repoGeneralReporte)
        {
            this.repoGeneralReporte = repoGeneralReporte;
        }
        public List<ReporteOrdenCompraServicioComprometidasPres> TraerReporteOrdenCompraServicioComprometidas(int anio)
        {
            return repoGeneralReporte.TraerReporteOrdenCompraServicioComprometidas(anio).ToList();
        }
        public List<ReporteOrdenCompraServicioPresupuestoPres> TraerReporteOrdenCompraServicioPresupuesto(int anio, int idPresupuesto, int nivel, int opcion)
        {
            return repoGeneralReporte.TraerReporteOrdenCompraServicioPresupuesto(anio, idPresupuesto, nivel, opcion).ToList();
        }
        public List<ReporteEvaluacionDetalladaBienSerPres> TraerReporteEvaluacionDetalladaBienSer(int anio, int? idGruPre, int? idDireccion, int? idSubDireccion)
        {
            return repoGeneralReporte.TraerReporteEvaluacionDetalladaBienSer(anio, idGruPre, idDireccion, idSubDireccion).ToList();
        }
        public List<ReporteEvaluacionDetalladaBienSerExportaPres> TraerReporteEvaluacionDetalladaBienSerExporta(int anio, int? idGruPre, int? idDireccion, int? idSubDireccion)
        {
            return repoGeneralReporte.TraerReporteEvaluacionDetalladaBienSerExporta(anio, idGruPre, idDireccion, idSubDireccion).ToList();
        }
        public List<ReportePresupuestoEjecutadoFondosPres> TraerReportePresupuestoEjecutadoFondos(int idMoneda, int anio, int mesInicio, int mesFin, string numCuenta)
        {
            return repoGeneralReporte.TraerReportePresupuestoEjecutadoFondos(idMoneda, anio, mesInicio, mesFin, numCuenta);
        }
        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> TraerReportePresupuestoAprobadoComprometidoEjecutado(int idMoneda, int idSubPresupuesto)
        {
            return repoGeneralReporte.TraerReportePresupuestoAprobadoComprometidoEjecutado(idMoneda, idSubPresupuesto);
        }

        public List<SaldosEvaReaPorDir> SaldosEvaluacionReajustePorDirecciones(int anio, int mesRea, int mesEva)
        {
            return repoGeneralReporte.SaldosEvaluacionReajustePorDirecciones(anio, mesRea, mesEva);
        }
        public List<PrecioBienServicioPorGruPrePres> TraerListaPrecioBienServicioPorGruPre(int idGruPre, int anio, int mesIni, int mesFin, int tipoMoneda)
        {
            return repoGeneralReporte.TraerListaPrecioBienServicioPorGruPre(idGruPre, anio, mesIni, mesFin, tipoMoneda);
        }
        public List<ReporteCertificacionOrdenProvisionPres> TraerReporteCertificacionOrdenProvision(int anio, int mes, int idMoneda)
        {
            return repoGeneralReporte.TraerReporteCertificacionOrdenProvision(anio, mes, idMoneda);
        }
        public List<ReporteProgramacionAnualGenericaGastosPres> TraerReporteProgramacionAnualGenericaGastos(string codigos, int idMoneda)
        {
            return repoGeneralReporte.TraerReporteProgramacionAnualGenericaGastos(codigos, idMoneda);
        }
        public List<ReporteEvaluacionMensualExportaGenericaPres> TraerReporteEvaluacionMensualExportaGenerica(int idEvaMenPro, int idMoneda)
        {
            return repoGeneralReporte.TraerReporteEvaluacionMensualExportaGenerica(idEvaMenPro, idMoneda);
        }
        public List<ReportePresupuestoFasesPres> TraerReportePresupuestoFases(int anio, int idMoneda, DateTime fechaInicio, DateTime fechaFin, int idPresupuesto, int nivelPresupuesto)
        {
            return repoGeneralReporte.TraerReportePresupuestoFases(anio, idMoneda, fechaInicio, fechaFin, idPresupuesto, nivelPresupuesto);
        }
        public List<ReportePresupuestoEjecutadoPres> TraerReportePresupuestoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string numCuenta)
        {
            return repoGeneralReporte.TraerReportePresupuestoEjecutado(idMoneda, anio, mesInicio, mesFin, numCuenta);
        }
        public List<ReporteEvaluacionPresupuestoPorCuentasPres> TraerReporteEvaluacionPresupuestoPorCuentas(int idMoneda, int anio, int idPresupuesto, int nivelPresupuesto)
        {
            return repoGeneralReporte.TraerReporteEvaluacionPresupuestoPorCuentas(idMoneda, anio, idPresupuesto, nivelPresupuesto);
        }
    }
}
