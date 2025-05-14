using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaRequerimientoMensualBienServicioVista : IControlBaseVista
    {
        List<RequerimientoMensualBienServicioPres> listaDatosPrincipales { set; }

        RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres { get; }

        List<Anio> listaAnio { set; }
        List<Mes> listaMes { set; }

        int anio { get; set; }
        int mes { get; set; }
    }
}
