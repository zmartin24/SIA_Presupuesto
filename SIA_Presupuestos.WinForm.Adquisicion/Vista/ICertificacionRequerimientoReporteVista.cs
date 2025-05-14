using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface ICertificacionRequerimientoReporteVista
    {
        List<Anio> listaAnio { set; }
        int anio { get; set; }
        List<Predeterminado> listaReporte { set; }
        int codReporte { set; get; }
    }
}
