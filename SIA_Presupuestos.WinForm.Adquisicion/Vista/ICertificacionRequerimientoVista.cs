using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ICertificacionRequerimientoVista : IDialogoBaseVista
    {
        List<Predeterminado> listaTipoRequerimiento { set; }
        List<GrupoPresupuestoPoco> ListaGrupoPresupuesto{ set; }
        List<ProgramacionAnual> ListaProgramacion{ set; }
        List<Subpresupuesto> ListaSubpresupuesto { set; }
        List<CertificacionDetallePres> ListaDetalle { set; get; }

        int idTipoReq { set; get; }
        int idGruPre { set; get; }
        int idPresupuesto { set; get; }
        int idSubPresupuesto { set; get; }
        DateTime fechaEmision { set; get; }
        decimal tipoCambio { set; get; }
        decimal total { set; get; }
        string detalle { set; get; }
        CertificacionMasterPres CertificacionMasterPres { set; get; }
        CertificacionRequerimiento CertificacionRequerimiento { get; set; }
        string observacion { set; get; }
        bool esTotalDetallado { set; get; }
        SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion { set; get; }

        List<ForeDetallePoco> ListaDetallesSeleccionados { get; }
        decimal importeMinCer { set; get; }
        string vmensaje { set; get; }
        bool esAnual { set; get; }
    }
}
