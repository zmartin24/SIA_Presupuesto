using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IReporteEvaluacionBienServicioVista : IControlBaseVista
    {
        List<Anio> listaAnio { set; }
        
        List<GrupoPresupuesto> listaGruPre { set; }
        List<Direccion> listaDirecciones { set; }
        List<Subdireccion> listaSubdireccion { set; }
        int vanio { get; set; }
        int vidGruPre { get; set; }
        int vidDireccion { set; get; }
        int vidSubDireccion { set; get; }

        List<ReporteEvaluacionDetalladaBienSerPres> listaDatosPrincipales { set; }

    }
}
