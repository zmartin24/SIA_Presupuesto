using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IFuenteFinanciamientoVista : IDialogoBaseVista
    {
        string fuente { set; get; }
        string codigo { set; get; }
        string rubro { set; get; }
        string desRubro { set; get; }   
    }
}
