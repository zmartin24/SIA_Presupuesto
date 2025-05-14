using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaCertificacionDetalleVista : IControlDetalleBaseVista
    {
        List<CertificacionDetallePres> listaDatosPrincipales { set; }
        CertificacionDetallePres certificacionDetallePres { get; }

    }
}
