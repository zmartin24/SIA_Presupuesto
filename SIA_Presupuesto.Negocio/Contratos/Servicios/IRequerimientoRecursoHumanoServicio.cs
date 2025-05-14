using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IRequerimientoRecursoHumanoServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(RequerimientoRecursoHumano requerimientoRecursoHumano);
        Resultado Modificar(RequerimientoRecursoHumano requerimientoRecursoHumano);
        Resultado ModificarSinClonar(RequerimientoRecursoHumano requerimientoRecursoHumano);
        Resultado Anular(RequerimientoRecursoHumano requerimientoRecursoHumano, string usuario);

        #endregion

        #region Busquedas y listados
        RequerimientoRecursoHumano BuscarPorCodigo(int idReqRecHum);
        RequerimientoRecursoHumanoPres BuscarRequerimientoRecursoHumano(int idReqRecHum);
        List<RequerimientoRecursoHumanoPres> TraerListaRequerimientoRecursoHumano(int anio, int idUsuario);
        List<RequerimientoRecursoHumanoDetallePres> TraerListaRequerimientoRecursoHumanoDetalle(int idReqRecHum);
        #endregion

        #region Reportes
        List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHH(int anio, int idDireccion, int idReqRecHum);
        List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHHDireccionArea(int anio, int idDireccion, int idSubdireccion, int idReqRecHum);
        List<ReporteRequerimientoRRHHDireccionImportePres> TraerReporteRequerimientoRRHHDireccionImporte(int anio, int idDireccion, int idSubdireccion, int idReqRecHum, int idMoneda);
        #endregion
    }
}
