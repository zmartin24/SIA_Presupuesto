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
    public interface IImprimirPorDireccionPresupuestoAnualVista
    {
        List<Direccion> listaDirecciones { set; }
        int idDireccion { set; get; }
        List<Predeterminado> listaReporte { set; }
        string codReporte { set; get; }
        List<Anio> listaAnios { set; }

        int anioReporte { set; get; }
    }
}
