using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IAyudaPresupuestoVista 
    {
        object listaDatosPrincipales { set; }

        object DatoActual { get; }

        string tituloColumna { set;  }

        string nombreColumna { set; }

        string tituloColumnaCodigo { set; }

        string nombreColumnaCodigo { set; }
    }
}
