using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IImprimirPorDireccionReajusteMensualVista
    {
        List<Direccion> listaDirecciones { set; }
        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }
        int idDireccion { set; get; }
        int idGruPre { set; get; }
        List<Predeterminado> listaReporte { set; }
        string codReporte { set; get; }
        List<Anio> listaAnios { set; }
        int anioReporte { set; get; }
        List<Mes> listaMeses { set; }
        int mesReporte { set; get; }
        List<Mes> listaMesesEva { set; }
        int mesReporteEva { set; get; }
    }
}
