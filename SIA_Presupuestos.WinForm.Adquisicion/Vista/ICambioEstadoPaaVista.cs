using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIA_Presupuesto.WinForm.General.Helper;


namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ICambioEstadoPaaVista : IDialogoBaseVista
    {
        List<Predeterminado> listaReporte { set; }

        int codEstado { set; get;  }
    }
}
