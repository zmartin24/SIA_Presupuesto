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
    public interface IReajusteMensualProgramacionServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(ReajusteMensualProgramacion ReajusteMensual);

        Resultado NuevoArea(ReajusteMensualArea ReajusteMensualArea);

        Resultado NuevoAreaMes(ReajusteMensualAreaMes ReajusteMensualAreaMes);

        Resultado NuevoDetalle(ReajusteMensualDetalle ReajusteMensualDetalle, bool actualizaArea);

        Resultado NuevoDetalleMes(ReajusteMensualDetalleMes ReajusteMensualDetalle, bool actualizaArea);

        Resultado Modificar(ReajusteMensualProgramacion ReajusteMensual);

        Resultado ModificarAreas(ReajusteMensualArea ReajusteMensualArea);

        Resultado ModificarAreasMes(ReajusteMensualAreaMes ReajusteMensualAreaMes);

        Resultado ModificarDetalles(ReajusteMensualDetalle ReajusteMensualDetalle);

        Resultado ModificarDetallesMes(ReajusteMensualDetalleMes ReajusteMensualDetalle, bool actualizaArea);

        Resultado Eliminar(ReajusteMensualProgramacion ReajusteMensual);

        Resultado Anular(ReajusteMensualProgramacion ReajusteMensual, string usuario);

        Resultado AnularArea(ReajusteMensualArea ReajusteMensualArea, string usuario);

        Resultado AnularDetalle(ReajusteMensualDetalle ReajusteMensualDetalle, string usuario);

        Resultado EliminarArea(ReajusteMensualArea ReajusteMensualArea);

        Resultado EliminarDetalle(ReajusteMensualDetalle ReajusteMensualDetalle);

        void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion);
        void GuardarDetalleRequerimientoMensualEnReajuste(int idReaMenPro, string usuario);
        Resultado AsginarSubpresupuesto(List<ReajusteMensualDetallePorMesPres> listaReajusteMensualDetallePorMes, int? idSubpresupuesto, string usuario);
        #endregion

        #region Busquedas y listados

        ReajusteMensualProgramacion BuscarPorCodigo(int idReajusteMensual);

        ReajusteMensualArea BuscarPorCodigoArea(int idProAnuArea);

        ReajusteMensualArea BuscarPorCodigoArea(int idReaMenPro, int idArea, int idCueCon);

        ReajusteMensualAreaMes BuscarPorCodigoAreaMes(int idProAnuAreaMes);

        ReajusteMensualAreaMes BuscarPorCodigoAreaMes(int idProAnuArea, int mes);

        decimal BuscarImportePorArea(int idReaMenAreaMes, string descripcion, int idUnidad, decimal precio);
        decimal BuscarImportePorArea(int idReaMenAreaMes, int idReaMenDet);

        ReajusteMensualDetalle BuscarPorCodigoDetalle(int idProAnuDet);

        ReajusteMensualDetalle BuscarPorCodigoDetalle(int idReaMenProArea, string descripcion, int idUnidad, decimal precio);

        ReajusteMensualDetalleMes BuscarPorCodigoDetalleMes(int idReaMenAreaMes, int idReaMenDet, string descripcion, int idUnidad, decimal precio);
        ReajusteMensualDetalleMes BuscarPorCodigoDetalleMes(int idReaMenDetMes);

        List<ReajusteMensualProgramacion> listarTodos();

        List<ReajusteMensualPresupuestoPres> TraerListaReajusteMensual(int anio, int mes);

        List<ReajusteMensualAreaPres> TraerListaReajusteMensualArea(int idProAnu);

        List<ReajusteMensualAreaExporta> TraerListaReajusteMensualAreaExporta(int idProAnu);

        List<ReporteReajusteMensualExportaPres> TraerReporteReajusteMensualExporta(int idReaMenPro, int idMoneda);

        List<ReajusteMensualDetallePres> TraerListaReajusteMensualDetalle(int idProAnuArea);

        List<ResumenReajustePresupuestoPorSubdirecciones> TraerResumenReajustePresupuestoPorSubdirecciones(int anio, int idDireccion, int mesReajuste, int mesEvaluacion);

        List<CalendarioEvaluacionyAjusteAnual> TraerCalendarioEvaluacionyAjusteAnual(int anio, int idFueFin, int mesAjuste, int mesEval, int idPresupuesto);

        List<ConsolidadoEvaluacionReajuste> TraerConsolidadoEvaluacionReajustePorDirecciones(int anio, int idFueFin, int mesAjuste, int mesEval);

        List<EvaluacionReajustePorSubdireccion> TraerResumenEvaluacionReajustePorSubdirecciones(int anio, int idDireccion, int idGruPre, int mesAjuste, int mesEval);

        List<int> TraerListaReajusteMensualAreas(int idReaMenPro);

        List<ReajusteMensualDetallePorMesPres> TraerListaReajusteMensualDetallePorMes(int idReaMenPro, int mes, int? idSubpresupuesto);

        #endregion
    }
}
