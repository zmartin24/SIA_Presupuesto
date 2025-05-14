using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IEstructuraVista : IDialogoBaseVista
    {
        string descripcion { set; get; }
    }
}
