using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IGastoRecurrenteDetalleVista : IDialogoBaseVista
    {
        
        List<Unidad> listaUnidades { set; }
        List<CuentaContable> listaCuentaContable { set; }

        int idCueCon { set; get; }
        int idUnidad { set; get; }
        string descripcion { get; set; }
        decimal precio { get; set; }
        string codBieSer { get; set; }
    }
}
