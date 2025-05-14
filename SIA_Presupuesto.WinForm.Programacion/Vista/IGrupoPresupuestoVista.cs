using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IGrupoPresupuestoVista : IDialogoBaseVista
    {
        int idGruPre { get; set; }
        string codigo { get; set; }
        string descripcion { get; set; }
        string abreviatura { get; set; }

        int idFuenteFinanciamiento { get; set; }

        List<FuenteFinanciamiento> listaFuente { set; }
        string observacion { get; set; }
        bool esEncargo { get; set; }
        string usuCrea { get; set; }
        DateTime fechaCrea { get; set; }
        string usuEdita { get; set; }
        DateTime fechaEdita { get; set; }
        int estado { get; set; }
        string agrupamiento { get; set; }
        List<Predeterminado> listaAgrupamiento { set; }
    }
}
