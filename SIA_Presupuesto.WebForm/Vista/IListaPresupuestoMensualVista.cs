using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using SIA_Presupuesto.WebForm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaPresupuestoMensualVista : IListaBase
    {
        List<SubPresupuestoPoco> listaDatosPrincipales { set; }
        int idSubpresupuesto { get; }

        List<Anio> listaAnios { set; }

        int anioPresentacion { get; set; }

        /*popExportarPreMen*/
        List<Moneda> listaMoneda { set; }
        string desPresupuesto { set; }
        string desSubpresupuesto { set; }
        int idMoneda { set; get; }
    }
}
