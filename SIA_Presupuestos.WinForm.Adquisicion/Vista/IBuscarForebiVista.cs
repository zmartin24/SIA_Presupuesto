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
    public interface IBuscarForebiVista : IDialogoBaseVista
    {
        List<ForeDetallePoco> ListaDetallesSeleccionados { get; }

        Forebi Forebi { get; set; }
        Forese Forese { get; set; }

        SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion { set; get; }
    }
}
