using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IAyudaSubPresupuestoDetalleVista
    {
        object listaDatosPrincipales { set; }
        object DatoActual { get; }
        string desGrupoPresupuesto { set; }
        string desPresupuesto { set; }
        string desSubPresupuesto { set; }
        string desDireccion { set; }
        string numeroFore { set; }
        decimal cantidad { set; }
        string descripcion { set; }
        decimal tipCambio { set; }
    }
}
