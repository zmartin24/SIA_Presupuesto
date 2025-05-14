using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IProgramacionAnualRepositorio : IRepositorio<ProgramacionAnual>
    {
        List<ProgramacionAnualPres> TraerListaProgramacionAnual(int anio);

        List<ProgramacionAnualPres> TraerListaProgramacionAnualAprobados(int anio);

        void GuardarDetalleProgramacionAnual(int idProAnu, string codigos, string usuario, bool indicaEliminacion);
        void GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(int idProAnu, string idsReqBieSer, string usuario);
        void GuardarDetalleProgramacionAnualGastosRecuerrentes(int idProAnu, string codigos, string usuario, bool indicaEliminacion);

        void GuardarDetalleProgramacionAnualRRHH(int idProAnu, string codigos, string usuario, bool indicaEliminacion);

        List<int> TraerListaProgramacionAnualAreas(int idProAnu);

        List<ConsolidadoPresupuesto> TraerConsolidadoPresupuestoPorDirecciones(int anio);

        List<ResumenPresupuestoPorSubdireccion> TraerResumenPresupuestoPorSubdirecciones(int anio, int idDireccion);

        List<CalendarioPresupuestoAnual> TraerCalendarioPresupuestoAnual(int anio, int idFueFin, int idPresupuesto);

        List<PresupuestoPorErradicacion> TraerPresupuestoPorErradicacion(int anio);

        void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion);
        List<ReporteProgramacionAnualExportaMasivoPres> TraerReporteProgramacionAnualExportaMasivo(string idsProAnu, int idMoneda);
    }
}
