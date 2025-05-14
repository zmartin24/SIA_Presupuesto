using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface ICambioEstadoProgramacionAnualVista : IDialogoBaseVista
    {
        List<Predeterminado> listaReporte { set; }

        int codEstado { set; get;  }
    }
}
