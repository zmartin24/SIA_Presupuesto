using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ICertificacionMasterVista : IDialogoBaseVista
    {
        List<Predeterminado> listaTipoRequerimiento { set; }
        List<CertificacionRequerimiento> ListaCertificacionRequerimiento { set; get; }

        int idTipoReq { set; get; }
        int idForebise { set; get; }
        bool esTotalDetallado { set; get; }
        string observacion { set; get; }
        Forebi Forebi { set; get; }
        Forese Forese { set; get; }
    }
}
