using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IEvaluacionMensualProgramacionServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(EvaluacionMensualProgramacion EvaluacionMensual);

        Resultado NuevoArea(EvaluacionMensualArea EvaluacionMensualArea);

        Resultado NuevoAreaMes(EvaluacionMensualAreaMes EvaluacionMensualAreaMes);

        Resultado NuevoDetalle(EvaluacionMensualDetalle EvaluacionMensualDetalle, bool actualizaArea);

        Resultado NuevoDetalleMes(EvaluacionMensualDetalleMes EvaluacionMensualDetalle, bool actualizaArea);

        Resultado Modificar(EvaluacionMensualProgramacion EvaluacionMensual);

        Resultado ModificarAreas(EvaluacionMensualArea EvaluacionMensualArea);

        Resultado ModificarAreasMes(EvaluacionMensualAreaMes EvaluacionMensualAreaMes);

        Resultado ModificarDetalles(EvaluacionMensualDetalle EvaluacionMensualDetalle);

        Resultado ModificarDetallesMes(EvaluacionMensualDetalleMes EvaluacionMensualDetalle, bool actualizaArea);

        Resultado Eliminar(EvaluacionMensualProgramacion EvaluacionMensual);

        Resultado Anular(EvaluacionMensualProgramacion EvaluacionMensual, string usuario);

        Resultado AnularArea(EvaluacionMensualArea EvaluacionMensualArea, string usuario);

        Resultado AnularDetalle(EvaluacionMensualDetalle EvaluacionMensualDetalle, string usuario);

        Resultado EliminarArea(EvaluacionMensualArea EvaluacionMensualArea);

        Resultado EliminarDetalle(EvaluacionMensualDetalle EvaluacionMensualDetalle);

        #endregion

        #region Busquedas y listados

        EvaluacionMensualProgramacion BuscarPorCodigo(int idEvaluacionMensual);

        EvaluacionMensualArea BuscarPorCodigoArea(int idProAnuArea);

        EvaluacionMensualArea BuscarPorCodigoArea(int idEvaMenPro, int idArea, int idCueCon);

        EvaluacionMensualArea BuscarEvaluacionMensualAreaPorCuenta(int idEvaMenPro, int idCueCon);

        EvaluacionMensualAreaMes BuscarPorCodigoAreaMes(int idProAnuAreaMes);

        EvaluacionMensualAreaMes BuscarPorCodigoAreaMes(int idProAnuArea, int mes);

        decimal BuscarImportePorArea(int idEvaMenAreaMes, string descripcion, int idUnidad, decimal precio);
        decimal BuscarImportePorArea(int idEvaMenAreaMes, int idEvaMenProDet);

        EvaluacionMensualDetalle BuscarPorCodigoDetalle(int idProAnuDet);

        EvaluacionMensualDetalle BuscarPorCodigoDetalle(int idEvaMenProArea, string descripcion, int idUnidad, decimal precio);

        EvaluacionMensualDetalleMes BuscarPorCodigoDetalleMes(int idEvaMenAreaMes, string descripcion, int idUnidad, decimal precio);

        EvaluacionMensualDetalleMes BuscarPorCodigoDetalleMes(int idEvaMenAreaMes, int idEvaMenProDet);

        List<EvaluacionMensualProgramacion> listarTodos();

        List<EvaluacionMensualPresupuestoPres> TraerListaEvaluacionMensual(int anio, int mes);

        List<EvaluacionMensualAreaPres> TraerListaEvaluacionMensualArea(int idProAnu);

        List<EvaluacionMensualAreaExporta> TraerListaEvaluacionMensualAreaExporta(int idProAnu);

        List<EvaluacionMensualDetallePres> TraerListaEvaluacionMensualDetalle(int idProAnuArea);

        List<FondoEjecutado> TraerFondoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string codigoPres);

        List<ResumenEvaFinanCorahSaal> TraerResumenEvaFinanCorahSaal(int idTipRep, int anio, int mes);

        List<FondoEjecutadosSubpresupuesto> TraerFondoEjecutadosSubpresupuesto(int idMoneda, int idGruPre, int idPresupuesto, int idSubpresupuesto);

        List<FondoEjecutadoFecha> TraerFondoEjecutadosFechas(int idMoneda, int idGruPre, int idPresupuesto, DateTime fechaDesde, DateTime fechaHasta);

        List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(int idProAnu, int anio, int mesRea, int mesEva);

        List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(string idsProAnu, int anio, int mesRea, int mesEva);

        List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta2(int idProAnu, int anio, int mesRea, int mesEva);
        List<ReporteEvaluacionMensualExportaPres> TraerReporteEvaluacionMensualExporta(int idEvaMenPro, int idMoneda);
        List<ReporteEvaluacionReajusteMensualExportaPres> TraerReporteEvaluacionReajusteMensualExporta(int idProAnu, int anio, int mesRea, int mesEva, int idMoneda);

        #endregion

    }
}
