using SIA_Presupuesto.Negocio.Entidades;
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;
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
    public interface IGeneralReporteVista : IControlBaseVista
    {
        List<Direccion> listaDirecciones { set; }
        int idDireccion { set; get; }
        List<Predeterminado> listaReporte { set; }
        string codReporte { set; get; }
        List<Anio> listaPeriodo { set; }
        int codPeriodo { get; set; }
        //Nullable<DateTime> FechaDesde { get; set; }
        //Nullable<DateTime> FechaHasta { get; set; }
        GrupoPresupuesto GrupoPresupuesto { get; set; }
        Presupuesto Presupuesto { get; set; }
        Subpresupuesto Subpresupuesto { get; set; }

        int idPresupuesto { get; set; }
        int nivel { get; set; }
    }
}
