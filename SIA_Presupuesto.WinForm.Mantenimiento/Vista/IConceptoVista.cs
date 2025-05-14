using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IConceptoVista : IDialogoBaseVista
    {
        string descripcion { set; get; }

        List<OrigenConcepto> listaOrigenes { set; }

        List<Predeterminado> listaTipo { set; }

        int idOriCon { set; get; }

        string tipo { set; get; }

        string abreviatura { set; get; }

    }
}
