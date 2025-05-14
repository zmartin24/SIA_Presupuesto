using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IImprimirGastoRecurrenteVista
    {
        List<Direccion> listaDirecciones { set; }
        int idDireccion { set; get; }
        
        List<Predeterminado> listaReporte { set; }
        string codReporte { set; get; }
    }
}
