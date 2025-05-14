using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IReporteEvaluacionVista
    {
        List<Anio> listaAnios { set; }

        List<Mes> listaMeses { set; }

        int mes { get; set; }

        int anio { get; set; }
   
        int idTipRep { get; set; }

        List<TipoReporte> listaReporte { set; }
    }
}
