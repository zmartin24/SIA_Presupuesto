using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IExportarReajustePresupuestoRemuneracionMasivoVista
    {
        //List<Predeterminado> listaReporte { set; }
        //string codReporte { set; get; }
        List<Anio> listaAnios{ set; }
        int anioReporte { set; get; }
        List<Mes> listaMesesRea { set; }
        int mesReporteRea { set; get; }
        string idsDireccion { get; }
        List<Direccion> listaDirecciones { set; }


    }
}
