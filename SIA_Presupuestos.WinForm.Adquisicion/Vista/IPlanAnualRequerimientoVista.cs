using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IPlanAnualRequerimientoVista : IControlDetalleBaseVista
    {
        List<PlanAnualAdquisicionRequerimientoPres> listaDatosPrincipales { set; }

        PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento { get; }
        PlanAnualAdquisicionRequerimientoPres planAnualAdquisicionRequerimientoPres { get; }

        PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle { get; }
    }
}
