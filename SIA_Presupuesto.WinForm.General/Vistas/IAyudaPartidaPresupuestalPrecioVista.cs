using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IAyudaPartidaPresupuestalPrecioVista
    {
        List<PartidaPresupuestalPrecioPres> listaDatosPrincipales { set; }
        PartidaPresupuestalPrecioPres DatoActual { get; }
        string desBusqueda { set; get; }
        int idMoneda { set; get; }

    }
}
