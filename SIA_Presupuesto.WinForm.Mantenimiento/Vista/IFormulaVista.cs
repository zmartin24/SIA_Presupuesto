using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IFormulaVista
    {
        List<ConceptoPresupuestoRemuneracion> listaDatosPrincipales { set; }

        string valor { set; get; }
    }
}
