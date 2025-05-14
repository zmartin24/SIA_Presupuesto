using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IGeneralReporteRepositorio
    {
        List<ReporteOrdenCompraServicioComprometidasPres> TraerReporteOrdenCompraServicioComprometidas(int anio);
        List<ReporteOrdenCompraServicioPresupuestoPres> TraerReporteOrdenCompraServicioPresupuesto(int anio, int idPresupuesto, int nivel, int opcion);
        List<ReporteEvaluacionDetalladaBienSerPres> TraerReporteEvaluacionDetalladaBienSer(int anio, int? idGruPre, int? idDireccion, int? idSubDireccion);
        List<ReporteEvaluacionDetalladaBienSerExportaPres> TraerReporteEvaluacionDetalladaBienSerExporta(int anio, int? idGruPre, int? idDireccion, int? idSubDireccion);
        List<ReportePresupuestoEjecutadoFondosPres> TraerReportePresupuestoEjecutadoFondos(int idMoneda, int anio, int mesInicio, int mesFin, string numCuenta);
        List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> TraerReportePresupuestoAprobadoComprometidoEjecutado(int idMoneda, int idSubPresupuesto);
        List<SaldosEvaReaPorDir> SaldosEvaluacionReajustePorDirecciones(int anio, int mesRea, int mesEva);
        List<PrecioBienServicioPorGruPrePres> TraerListaPrecioBienServicioPorGruPre(int idGruPre, int anio, int mesIni, int mesFin, int tipoMoneda);
        List<ReporteCertificacionOrdenProvisionPres> TraerReporteCertificacionOrdenProvision(int anio, int mes, int idMoneda);
        List<ReporteProgramacionAnualGenericaGastosPres> TraerReporteProgramacionAnualGenericaGastos(string codigos, int idMoneda);
        List<ReporteEvaluacionMensualExportaGenericaPres> TraerReporteEvaluacionMensualExportaGenerica(int idEvaMenPro, int idMoneda);
        List<ReportePresupuestoFasesPres> TraerReportePresupuestoFases(int anio, int idMoneda, DateTime fechaInicio, DateTime fechaFin, int idPresupuesto, int nivelPresupuesto);
        List<ReportePresupuestoEjecutadoPres> TraerReportePresupuestoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string numCuenta);
        List<ReporteEvaluacionPresupuestoPorCuentasPres> TraerReporteEvaluacionPresupuestoPorCuentas(int idMoneda, int anio, int idPresupuesto, int nivelPresupuesto);


    }
}
