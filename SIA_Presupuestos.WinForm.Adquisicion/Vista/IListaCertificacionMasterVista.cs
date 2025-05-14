using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaCertificacionMasterVista : IControlBaseVista
    {
        List<CertificacionMasterPres> listaDatosPrincipales { set; }
        CertificacionMaster certificacionMaster { get; }
        CertificacionMasterPres certificacionMasterPres { get; }
        List<Anio> listaAnios { set; }
        int anioPresentacion { set; get; }
    }
}
