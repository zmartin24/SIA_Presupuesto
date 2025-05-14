using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IRequerimientoBienServicioDetalleRepositorio : IRepositorio<RequerimientoBienServicioDetalle>
    {
        List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalle(int idReqBieSer);

        List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccion(int idDireccion, int? idSubdireccion, int anio, int idMoneda);

        List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDetalleDireccionExporta(int idDireccion, int anio);

        List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(int idDireccion, int anio);

        List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccionOperativos(int idDireccion, int anio, string tipo, int idMoneda);
        List<ReporteRequerimientoBienServicioExportaPres> TraerReporteRequerimientoBienServicioExporta(int idReqBieSer);

    }
}
