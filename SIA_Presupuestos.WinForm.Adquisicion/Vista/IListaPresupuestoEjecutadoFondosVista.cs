using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaPresupuestoEjecutadoFondosVista : IControlBaseVista
    {
        List<Moneda> listaMoneda { set; }
        List<Anio> listaAnio { set; }
        List<Mes> listaMes { set; }
        
        int idMoneda { get; set; }
        int vanio { get; set; }
        int mes { set; get; }

        
        List<ReportePresupuestoEjecutadoFondosPres> listaDatosPrincipales { set; }

    }
}
