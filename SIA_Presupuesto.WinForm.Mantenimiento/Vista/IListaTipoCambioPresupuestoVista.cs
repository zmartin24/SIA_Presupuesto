using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IListaTipoCambioPresupuestoVista : IControlBaseVista
    {
        List<Anio> listaAnios { set; }
        int anioPresentacion { get; set; }

        List<TipoCambioPresupuesto> listaDatosPrincipales { set; }
        TipoCambioPresupuesto tipoCambioPresupuesto { get; }
    }
}
