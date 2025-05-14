using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IRequerimientoRecursoHumanoRepositorio : IRepositorio<RequerimientoRecursoHumano>
    {
        bool AnularRequerimientoRecursoHumano(int idReqRecHum, string nomUsuario);
        RequerimientoRecursoHumanoPres BuscarRequerimientoRecursoHumano(int idReqRecHum);
        List<RequerimientoRecursoHumanoPres> TraerListaRequerimientoRecursoHumano(int anio, int idUsuario);
        List<RequerimientoRecursoHumanoDetallePres> TraerListaRequerimientoRecursoHumanoDetalle(int idReqRecHum);
        List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHH(int anio, int idDireccion, int idReqRecHum);
        List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHHDireccionArea(int anio, int idDireccion, int idSubdireccion, int idReqRecHum);
        List<ReporteRequerimientoRRHHDireccionImportePres> TraerReporteRequerimientoRRHHDireccionImporte(int anio, int idDireccion, int idSubdireccion, int idReqRecHum, int idMoneda);
        
    }
}
