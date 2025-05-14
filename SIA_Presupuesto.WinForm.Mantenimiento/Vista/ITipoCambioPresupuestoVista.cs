using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface ITipoCambioPresupuestoVista : IDialogoBaseVista
    {
        List<Moneda> listaMoneda{ set; }
        List<Mes> listaMes { set; }

        int idMoneda { set; get; }
        int anio { set; get; }
        int mes { set; get; }
        decimal valor { set; get; }   
    }
}
