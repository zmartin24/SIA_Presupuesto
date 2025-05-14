using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IParametroVista : IDialogoBaseVista
    {
        List<ConceptoPresupuestoRemuneracion> listaConceptos { set; }

        int idConPreRem { set; get; }

        decimal importe { set; get; }
        List<Moneda> listaMonedas { set; }

        int idMoneda { set; get; }

    }
}