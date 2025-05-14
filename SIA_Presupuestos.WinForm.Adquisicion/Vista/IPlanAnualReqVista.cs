using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IPlanAnualReqVista : IControlDetalleBaseVista
    {
        List<PlanAnualAdquisicionReqPres> listaDatosPrincipales { get; set; }
        List<PlanAnualAdquisicionReqDetallePres> listaPacDetalles { get; set; }
        PlanAnualAdquisicionReqPres planAnualAdquisicionReqPres { get; }
        PlanAnualAdquisicionReqDetallePres planAnualAdquisicionReqDetallePres { get; }
        PlanAnualAdquisicionReqPres planAnualAdquisicionReqPresTemp { get; set; }
    }
}
