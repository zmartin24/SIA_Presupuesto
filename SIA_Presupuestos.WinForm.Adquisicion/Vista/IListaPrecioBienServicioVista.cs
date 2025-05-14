using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaPrecioBienServicioVista : IControlBaseVista
    {
        List<PrecioBienServicioPorGruPrePres> listaDatosPrincipales { set; }

        List<Anio> listaAnio { set; }
        List<Mes> listaMes { set; }
        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }
        List<Moneda> listaMoneda { set; }


        int idMoneda { get; set; }
        int vanio { get; set; }
        int mes { set; get; }
        int idGruPre { set; get; }
    }
}
