using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaGastoRecurrenteRequerimientoVista : IControlDetalleBaseVista
    {
        List<GastoRecurrenteRequerimientoPres> listaDatosPrincipales { set; }
        GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento { get; }
        GastoRecurrenteRequerimientoPres gastoRecurrenteRequerimientoPres { get; }
        GastoRecurrenteDetalle gastoRecurrenteDetalle { get; }
    }
}
