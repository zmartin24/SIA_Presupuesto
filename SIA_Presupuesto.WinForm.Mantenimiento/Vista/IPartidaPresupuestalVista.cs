using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IPartidaPresupuestalVista : IDialogoBaseVista
    {
        List<Unidad> listaUnidad { set; }
        List<CuentaContable> listaCuentaContable { set; }
        List<Predeterminado> listaTipo { set; }

        int tipo { set; get; }
        string descripcion { set; get; }
        int idUnidad { set; get; }
        decimal precio { set; get; }
        CuentaContable cuentaContable { get; set; }
    }
}
