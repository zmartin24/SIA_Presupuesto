using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaRequerimientoRecursoHumanoVista : IControlBaseVista
    {
        List<RequerimientoRecursoHumanoPres> listaDatosPrincipales { set; }
        RequerimientoRecursoHumano requerimientoRecursoHumano { get; }
        List<Anio> listaAnios { set; }
        int anio { get; set; }
    }
}
