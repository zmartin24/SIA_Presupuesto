using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IAyudaProductoPrecioVista
    {
        List<ProductoPrecioPres> listaDatosPrincipales { set; }
        ProductoPrecioPres DatoActual { get; }
        string desBusqueda { set; get; }
        int idMoneda { set; get; }
    }
}
