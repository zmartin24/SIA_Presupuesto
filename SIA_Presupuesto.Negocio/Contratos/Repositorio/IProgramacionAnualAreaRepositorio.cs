using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IProgramacionAnualAreaRepositorio : IRepositorio<ProgramacionAnualArea>
    {
        bool AnularProgramacionAnualArea(int idProAnuArea, string nomUsuario);
        bool AnularProgramacionAnualAreaPorCuenta(int idProAnu, int idCueCon, int idArea, string nomUsuario);
        List<ProgramacionAnualAreaPres> TraerListaProgramacionAnualArea(int idProAnu);
        List<ProgramacionAnualAreaExporta> TraerListaProgramacionAnualExporta(int idProAnu);
        List<ReporteProgramacionAnualExportaPres> TraerReporteProgramacionAnualExporta(int idProAnu, int idMoneda);
    }
}
