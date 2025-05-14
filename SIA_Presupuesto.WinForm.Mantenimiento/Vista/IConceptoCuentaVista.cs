using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IConceptoCuentaVista : IDialogoBaseVista
    {
        List<DatoRegimenLaboral> listaRegimen { set; }

        List<DatoCategoriaLaboral> listaCategoria { set; }

        List<DatoCondicionLaboral> listaCondicion { set; }

        List<ConceptoPresupuestoRemuneracion> listaConceptos { set; }

        List<CuentaContable> listaCuentaContable { set; }

        int idConPreRem { set; get; }

        string numCuenta { get; }

        int idRegLab { set; get; }

        int idConLab { set; get; }

        int idCatLab { set; get; }

        int idCueCon { set; get; }
    }
}
