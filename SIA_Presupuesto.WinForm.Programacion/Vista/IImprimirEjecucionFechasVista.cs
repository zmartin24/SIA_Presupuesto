using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IImprimirEjecucionFechasVista
    {
        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }
        int idGruPre { set; get; }
        int idMoneda { set; get; }
        List<ProgramacionAnual> listaProgramacion { set; }
        int idPresupuesto { set; get; }
        DateTime fechaDesde { set; get; }
        DateTime fechaHasta { set; get; }
    }
}
