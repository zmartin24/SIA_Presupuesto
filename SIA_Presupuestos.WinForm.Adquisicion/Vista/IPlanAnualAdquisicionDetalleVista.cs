using SIA_Presupuesto.Negocio.Entidades;
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IPlanAnualAdquisicionDetalleVista : IDialogoBaseVista
    {
        List<Unidad> listaUnidades { set; }
        List<ConfiguracionPAA> listaTipoCompra { set; }
        List<ConfiguracionPAA> listaTipoProceso { set; }
        List<ConfiguracionPAA> listaObjetoProceso { set; }
        List<ConfiguracionPAA> listaEncargado { set; }
        List<FuenteFinanciamiento> listaFuenteFinanciamiento { set; }
        List<Ubigeo> listaRegion { set; }
        List<Ubigeo> listaProvincia { set; }
        List<Ubigeo> listaDistrito { set; }
        List<Moneda> listaMoneda { set; }
        List<CuentaContable> listaCuentaContable { set; }
        List<ConfiguracionPAA> listaMesPrevisto { set; }

        bool itemUnico { set; get; }
        int idUnidad { set; get; }
        int idCueCon { set; get; }
        int tipComSel { set; get; }
        int TipPro { set; get; }
        int objCon { set; get; }
        bool antecedente { set; get; }
        string desAntecedente { set; get; }

        string descripcion { get; set; }
        decimal precio { get; set; }

        int idTipMon { get; set; }
        decimal tipCam { get; set; }
        decimal valorEst { get; set; }
        int idRegion { get; set; }
        int idProvincia { get; set; }
        int idUbigeo { get; set; }
        int idFueFin { get; set; }
        string observacion { get; set; }
        int organoEncargado { get; set; }
        string codBieSer { get; set; }
        int fechaPrevista { get; set; }

    }
}
