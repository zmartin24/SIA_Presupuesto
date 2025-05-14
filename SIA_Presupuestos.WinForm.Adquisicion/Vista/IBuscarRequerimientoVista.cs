using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IBuscarRequerimientoVista : IDialogoBaseVista
    {
        List<RequerimientoBienServicioPendientePorCuentaPres> listaDatosPrincipales { set; }
        RequerimientoBienServicioPendientePorCuentaPres requerimientoBienServicioPendientePorCuentaPresActual { get; }
        List<CuentaContable> listaCuentaN1 { set; }
        List<CuentaContable> listaCuentaN2 { set; }
        List<CuentaContable> listaCuentaN3 { set; }

        List<ConfiguracionPAA> listaTipoCompra { set; }
        List<ConfiguracionPAA> listaTipoProceso { set; }
        List<ConfiguracionPAA> listaObjetoProceso { set; }
        List<ConfiguracionPAA> listaEncargado { set; }
        List<FuenteFinanciamiento> listaFuenteFinanciamiento { set; }
        List<ConfiguracionPAA> listaMesPrevisto { set; }
        List<Ubigeo> listaRegion { set; }
        List<Ubigeo> listaProvincia { set; }
        List<Ubigeo> listaDistrito { set; }

        int idCueConN1 { set; get; }
        int idCueConN2 { set; get; }
        int idCueConN3 { set; get; }

        int tipComSel { set; get; }
        int TipPro { set; get; }
        int objCon { set; get; }
        int organoEncargado { get; set; }
        int idFueFin { get; set; }
        int fechaPrevista { get; set; }

        int idRegion { get; set; }
        int idProvincia { get; set; }
        int idUbigeo { get; set; }
        

        List<RequerimientoBienServicioPendientePorCuentaPres> listaSeleccionada { get; }
    }
}
