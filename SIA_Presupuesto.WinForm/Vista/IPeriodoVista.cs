using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Vista
{
    public interface IPeriodoVista
    {
        int Anio { set; get; }

        int Mes {set; get; }

        List<Mes> listaMeses { set; }

        List<Anio> listaAnios { set; }

    }
}
