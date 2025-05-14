using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaSubPresupuestoVista : IControlBaseVista
    {
        List<SubPresupuestoPoco> listaDatosPrincipales { set; }
        SubPresupuestoPoco subPresupuesto { get; }
        List<Anio> listaAnios { set; }
        int anioPresentacion { get; set; }
        int idMoneda { set; get; }
    }
}
