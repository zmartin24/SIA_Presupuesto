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
    public interface IRubroBienServicioCuentaVista : IDialogoBaseVista
    {
        int idRubBieSerCue { get; set; }

        int idRubBieSer { get; set; }

        List<RubroBienServicioPoco> listaTipoGastos { set; }

        int idCuentaNivel1 { get; set; }

        int idCuentaNivel2 { get; set; }

        int idCuentaNivel3 { get; set; }

        List<CuentaContablePoco> listaCuentasNivel1 {set; }

        List<CuentaContablePoco> listaCuentasNivel2 {set; }

        List<CuentaContablePoco> listaCuentasNivel3 {set; }

    }
}
