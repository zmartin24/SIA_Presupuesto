using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IActualizarPorRequerimientoBienServicioVista : IDialogoBaseVista
    {
        List<Anio> listaAnio { set; }
        int anio { set; get; }
        string idsReqBienSer { get; set; }

    }
}
