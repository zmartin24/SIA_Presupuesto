using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IProgramacionAnualDetalleRepositorio : IRepositorio<ProgramacionAnualDetalle>
    {
        List<ProgramacionAnualDetallePres> TraerListaProgramacionAnualDetalle(int idProAnuArea);
        List<ProgramacionAnualDetallePorMesPres> TraerListaProgramacionAnualDetallePorMes(int idProAnu, int mes, int? idSubpresupuesto);
    }
}
