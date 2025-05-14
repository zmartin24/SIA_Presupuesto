using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IRequerimientoBienServicioRepositorio : IRepositorio<RequerimientoBienServicio>
    {
        bool GuardarDetalleRequerimientoAnualBienesServiciosToClonar(int idReqBieSer, int idReqBieSerOrigen, string usuario);
        bool GuardarDetalleRequerimientoAnualBienesServiciosToExcel(int idReqBieSer, string usuario, DataTable estructuraCarga);
        RequerimientoBienServicio TraerRequerimientoBienServicio(int idReqBieSer);
        List<RequerimientoBienServicioPres> TraerListaRequerimientoBienServicio(int anio, int idUsuario);
        List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDireccionExporta(int idDireccion, int anio);
        List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPorArea(int tipo, int anio, int mes, int idArea);
        List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> TraerReporteRequerimientoBienServicioDireccionAreaExporta(int idDireccion, int anio, string tipo);
        List<ReporteRequerimientoBienServicioDetalleMensualPres> TraerReporteRequerimientoBienServicioDetalleMensual(int idReqBieSer);
        List<RequerimientoBienServicioDetalleMes> TraerRequerimientoBienServicioDetalleMeses(int idReqBieSerDet);
        DataTable ListaEstructuraCargaRequerimientoAnual(int idReqBieSer, DataTable estructuraCarga);
    }
}
