using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaRequerimientoRecursoHumanoDetalleVista : IControlDetalleBaseVista
    {
        List<RequerimientoRecursoHumanoDetallePres> listaDatosPrincipales { set; }
        List<PuestoRequerimiento> listaPuestoRequerimiento { get; }
        List<Mes> listaMesDesde { set; }
        List<Mes> listaMesHasta { set; }

        PuestoRequerimiento puestoRequerimiento { get; }
        int mesDesde { set; get; }
        int mesHasta { set; get; }
    }
}
