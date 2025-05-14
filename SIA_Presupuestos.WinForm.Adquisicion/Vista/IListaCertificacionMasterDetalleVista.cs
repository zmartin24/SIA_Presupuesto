using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaCertificacionMasterDetalleVista : IControlDetalleBaseVista
    {
        List<CertificacionRequerimientoPres> listaDatosPrincipales { set; }
        CertificacionRequerimiento certificacionRequerimiento { get; set; }
        CertificacionRequerimientoPres certificacionRequerimientoPres { get; }
        CertificacionDetallePres certificacionDetallePres { get; }
    }
}
