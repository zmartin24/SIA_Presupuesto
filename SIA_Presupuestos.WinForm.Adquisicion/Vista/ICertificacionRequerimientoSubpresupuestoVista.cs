using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ICertificacionRequerimientoSubpresupuestoVista : IControlDetalleBaseVista//: IDialogoBaseVista
    {
        List<GrupoPresupuestoPoco> ListaGrupoPresupuesto{ set; }
        List<ProgramacionAnual> ListaProgramacion{ set; }
        List<Subpresupuesto> ListaSubpresupuesto { set; }
        List<SubPresupuestoPoco> listaSubPresupuestoPoco { set; }

        //string sigla { set; get; }
        //string numero { set; get; }
        int idGruPre { set; get; }
        int idPresupuesto { set; get; }
        int idSubPresupuesto { set; get; }
        
        CertificacionMasterPres CertificacionMasterPres { set; get; }
        CertificacionRequerimiento CertificacionRequerimiento { set; get; }
        SubPresupuestoPoco subPresupuestoPoco { get; }

    }
}
