using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ICertificacionRequerimientoAmpliacionVista : IDialogoBaseVista
    {
        List<Predeterminado> listaTipoRequerimiento { set; }
        List<GrupoPresupuestoPoco> ListaGrupoPresupuesto{ set; }
        List<ProgramacionAnual> ListaProgramacion{ set; }
        List<Subpresupuesto> ListaSubpresupuesto { set; }

        int idTipoReq { set; get; }
        string sigla { set; get; }
        int idGruPre { set; get; }
        int idPresupuesto { set; get; }
        int idSubPresupuesto { set; get; }
        decimal tipoCambio { set; get; }
        decimal total { set; get; }
        CertificacionMasterPres CertificacionMasterPres { set; get; }
        string detalle { set; get; }
        string justificacion { set; get; }
        
        SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion { set; get; }

        List<ForeDetallePoco> listaDatosPrincipales { set; }
        List<ForeDetallePoco> ListaDetallesSeleccionados { get; }
        List<ForeDetallePoco> listaForeDetallePoco { get; set; }
    }
}
