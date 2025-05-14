using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaPresupuestoEjecutadoFondosVista : IListaBase
    {
        List<ReportePresupuestoEjecutadoFondosPres> listaDatosPrincipales { set; }
        List<Anio> listaAnios { set; }
        List<Mes> listaMeses { set; }
        List<Moneda> listaMonedas { set; }
        
        
        int anioPresentacion { get; set; }
        int idMes { get; set; }
        int idMoneda { get; set; }
       
    }
}
