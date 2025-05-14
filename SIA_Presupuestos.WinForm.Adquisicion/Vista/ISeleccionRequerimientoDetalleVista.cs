using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ISeleccionRequerimientoDetalleVista
    {
        List<ForeDetallePoco> listaForeDetallePoco { set; }
        List<ForeDetallePoco> ListaDetallesSeleccionados { get; }

        Forebi Forebi { get; set; }
        Forese Forese { get; set; }

        SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion { set; get; }
    }
}
