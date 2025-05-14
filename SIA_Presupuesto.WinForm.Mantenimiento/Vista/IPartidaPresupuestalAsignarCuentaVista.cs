using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IPartidaPresupuestalAsignarCuentaVista : IDialogoBaseVista
    {
        List<CuentaContable> listaCuentaContable { set; }
        string tipo { set; get; }
        string descripcion { set; get; }
        string desUnidad { set; get; }
        decimal precio { set; get; }
        CuentaContable cuentaContable { get; set; }
    }
}
