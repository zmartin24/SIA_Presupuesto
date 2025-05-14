using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IImprimirEjecucionSubpresupuestoVista
    {
        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }
        int idGruPre { set; get; }
        int idMoneda { set; get; }
        List<Moneda> listaMoneda { set; }
        List<ProgramacionAnual> listaProgramacion { set; }
        int idPresupuesto { set; get; }
        List<Subpresupuesto> listaSubpresupuesto { set; }
        int idSubpresupuesto { set; get; }
    }
}
