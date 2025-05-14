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
    public interface IImprimirSaldoEvaluacionReajusteAnualVista
    {
        List<Anio> listaAnios{ set; }
        int anioReporte { set; get; }
        List<Mes> listaMeses { set; }
        int mesReporte { set; get; }
        List<Mes> listaMesesRea { set; }
        int mesReporteRea { set; get; }
    }
}
