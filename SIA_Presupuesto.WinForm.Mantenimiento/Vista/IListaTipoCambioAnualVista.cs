using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IListaTipoCambioAnualVista : IControlBaseVista
    {
        List<TipoCambioAnual> listaDatosPrincipales { set; }
        TipoCambioAnual tipoCambioAnual { get; }
    }
}
