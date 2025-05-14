using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface ITipoCambioAnualVista : IDialogoBaseVista
    {
        List<Moneda> listaMoneda{ set; }

        int idMoneda { set; get; }
        int anio { set; get; }
        decimal valor { set; get; }   
    }
}
