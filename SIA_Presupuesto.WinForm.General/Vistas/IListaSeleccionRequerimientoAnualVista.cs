using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.General.Vista
{
    public interface IListaSeleccionRequerimientoAnualVista
    {
        List<RequerimientoBienServicioPres> listaDatosPrincipales { set; }
        object idsReqBienSer { get; set; }
    }
}
