using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IAyudaMonedaVista
    {
        List<Moneda> listaMoneda { set; }
        int idMoneda { set; get; }
    }
}
