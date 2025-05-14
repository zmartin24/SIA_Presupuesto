using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IAyudaCambioEstadoVista : IDialogoBaseVista
    {
        List<Predeterminado> listaEstado { set; }
        int idEstado { set; get; }
        string opcion { set; get; }
    }
}
