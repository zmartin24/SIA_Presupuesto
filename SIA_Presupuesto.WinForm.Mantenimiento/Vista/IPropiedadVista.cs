using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IPropiedadVista : IDialogoBaseVista
    {
        List<ConceptoPresupuestoRemuneracion> listaConceptos { set; }

        List<Predeterminado> listaTipoValor { set; }

        int idConPreRem { get; set; }

        string tipoValor { get; set; }

        string valor { get; set; }

        string visualiza { get; set; }

        int orden { get; set; }
    }
}
