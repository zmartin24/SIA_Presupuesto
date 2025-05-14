using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista.Base;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IRequerimientoMensualSeguimientoVista : IFormularioBase
    {
        List<ReporteRequerimientoMensualSeguimientoPres> listaDatosPrincipales { set; }
        List<ReporteRequerimientoMensualSeguimientoDetallePres> listaPresupuestoEvaluacionCuenta { set; }
        List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> listaForebiseCabecera { set; }
        List<Moneda> listaMonedas { set; }
        List<Mes> listaMeses { set; }
        int idReqMenBieSer { get; }
        string desPrespupuesto { set; }
        int idMoneda { set; get; }
        int idMes { set;get; }

    }
}
