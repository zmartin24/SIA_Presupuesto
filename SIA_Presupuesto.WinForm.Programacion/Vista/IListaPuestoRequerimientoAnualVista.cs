using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaPuestoRequerimientoAnualVista: IDialogoBaseVista
    {
        ProgramacionAnual programacionAnual { get; }
        List<PuestoRequerimientoAnualPres> listaPuestoRequerimientoAnual { set; }
    }
}
