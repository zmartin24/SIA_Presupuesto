using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IAyudaProductoVista
    {
        List<Producto> listaDatosPrincipales { set; }

        Producto DatoActual { get; }

    }
}
