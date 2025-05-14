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
    public interface IProgramacionAnualServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(ProgramacionAnual ProgramacionAnual);

        Resultado NuevoArea(ProgramacionAnualArea ProgramacionAnualArea);

        Resultado NuevoAreaMes(ProgramacionAnualAreaMes ProgramacionAnualAreaMes);

        Resultado NuevoDetalle(ProgramacionAnualDetalle ProgramacionAnualDetalle, bool actualizaArea);

        Resultado NuevoDetalleMes(ProgramacionAnualDetalleMes ProgramacionAnualDetalle, bool actualizaArea);

        Resultado Modificar(ProgramacionAnual ProgramacionAnual);

        Resultado ModificarAreas(ProgramacionAnualArea ProgramacionAnualArea);

        Resultado ModificarAreasMes(ProgramacionAnualAreaMes ProgramacionAnualAreaMes);

        Resultado ModificarDetalles(ProgramacionAnualDetalle ProgramacionAnualDetalle);

        Resultado ModificarDetallesMes(ProgramacionAnualDetalleMes ProgramacionAnualDetalle, bool actualizaArea);

        //Resultado ModificarTodosDetalles(ProgramacionAnualDetalle ProgramacionAnualDetalle);

        Resultado Eliminar(ProgramacionAnual ProgramacionAnual);

        Resultado Anular(ProgramacionAnual ProgramacionAnual, string usuario);

        Resultado AnularArea(ProgramacionAnualArea ProgramacionAnualArea, string usuario);
        bool AnularProgramacionAnualArea(ProgramacionAnualArea ProgramacionAnualArea, string usuario);

        bool AnularProgramacionAnualAreaPorCuenta(ProgramacionAnualArea programacionAnualArea, string usuario);

        Resultado AnularDetalle(ProgramacionAnualDetalle ProgramacionAnualDetalle, string usuario);

        Resultado AsginarSubpresupuesto(List<ProgramacionAnualDetallePorMesPres> listaProgramacionAnualDetalleMes, int? idSubpresupuesto, string usuario);

        void GuardarDetalleProgramacionAnual(int idProAnu, string codigos, string usuario, bool indicaEliminacion);
        void GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(int idProAnu, string idsReqBieSer, string usuario);
        void GuardarDetalleProgramacionAnualGastosRecuerrentes(int idProAnu, string codigos, string usuario, bool indicaEliminacion);

        void GuardarDetalleProgramacionAnualRRHH(int idProAnu, string codigos, string usuario, bool indicaEliminacion);

        void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion);

        #endregion

        #region Busquedas y listados

        ProgramacionAnual BuscarPorCodigo(int idProgramacionAnual);

        ProgramacionAnualArea BuscarPorCodigoArea(int idProAnuArea);

        ProgramacionAnualArea BuscarPorCodigoArea(int idProAnu, int idArea, int idCueCon);

        ProgramacionAnualAreaMes BuscarPorCodigoAreaMes(int idProAnuAreaMes);

        ProgramacionAnualAreaMes BuscarPorCodigoAreaMes(int idProAnuArea, int mes);

        ProgramacionAnualDetalle BuscarPorCodigoDetalle(int idProAnuArea, string descripcion, int idUnidad, decimal precio);

        ProgramacionAnualDetalleMes BuscarPorCodigoDetalleMes(int idProAnuAreaMes, string descripcion, int idUnidad, decimal precio);
        ProgramacionAnualDetalleMes BuscarPorCodigoDetalleMes(int idProAnuDet, int idProAnuAreaMes);
        ProgramacionAnualDetalleMes BuscarPorCodigoDetalleMes(int idProAnuDetMes);

        ProgramacionAnualDetalle BuscarPorCodigoDetalle(int idProAnuDet);

        List<ProgramacionAnual> listarTodos();

        List<ProgramacionAnual> listarTodos(int anio);

        List<ProgramacionAnualPres> TraerListaProgramacionAnual(int anio);

        List<ProgramacionAnual> TraerListaxGrupo(int idGrupo);

        List<ProgramacionAnualPres> TraerListaProgramacionAnualAprobados(int anio);

        List<ProgramacionAnualAreaPres> TraerListaProgramacionAnualArea(int idProAnu);

        List<ProgramacionAnualAreaExporta> TraerListaProgramacionAnualAreaExporta(int idProAnu);
        List<ReporteProgramacionAnualExportaPres> TraerReporteProgramacionAnualExporta(int idProAnu, int idMoneda);

        List<ProgramacionAnualDetallePres> TraerListaProgramacionAnualDetalle(int idProAnuArea);
        decimal BuscarImportePorArea(int idProAnuAreaMes, string descripcion, int idUnidad, decimal precio);
        List<ProgramacionAnual> listarTodosPorGrupoPresupuesto(int idGruPre);

        List<int> TraerListaProgramacionAnualAreas(int idProAnu);

        List<ConsolidadoPresupuesto> TraerConsolidadoPresupuestoPorDirecciones(int anio);

        List<ResumenPresupuestoPorSubdireccion> TraerResumenPresupuestoPorSubdirecciones(int anio, int idDireccion);

        List<CalendarioPresupuestoAnual> TraerCalendarioPresupuestoAnual(int anio, int idFueFin, int idPresupuesto);

        List<ProgramacionSedeLaboralPoco> ListaProgramacionSedeLaboralPoco(int idProAnu);

        List<ProgramacionEjeOperativoPoco> ListaProgramacionEjeOperativoPoco(int idProAnu);

        List<PresupuestoPorErradicacion> TraerPresupuestoPorErradicacion(int anio);
        List<ProgramacionAnualDetallePorMesPres> TraerListaProgramacionAnualDetallePorMes(int idProAnu, int mes, int? idSubpresupuesto);

        #endregion

        #region Reportes
        List<ReporteProgramacionAnualExportaMasivoPres> TraerReporteProgramacionAnualExportaMasivo(string idsProAnu, int idMoneda);
        #endregion
    }
}
