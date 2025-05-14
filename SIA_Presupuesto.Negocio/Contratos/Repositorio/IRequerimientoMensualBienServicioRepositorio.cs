using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IRequerimientoMensualBienServicioRepositorio : IRepositorio<RequerimientoMensualBienServicio>
    {
        bool GuardarDetalleRequerimientoMensualBienesServiciosToClonar(int idReqMenBieSer, int idReqMenBieSerOrigen, string usuario);
        bool GuardarDetalleRequerimientoMensualBienesServiciosToExcel(int idReqMenBieSer, string usuario, DataTable estructuraCarga);
        bool GuardarDetalleReqMensualBienServicioDesdeReqAnual(int idReqMenBieSer, int tipo, int mes, string idsReqBieSer, string usuario);
        
        RequerimientoMensualBienServicio BuscarRequerimientoMensualBienServicio(int idReqMenBieSer);
        List<RequerimientoMensualBienServicioPres> TraerListaRequerimientoMensualBienServicio(int anio, int mes, int idUsuario, int? idPresupuesto, bool listarTodos);
        List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalleDireccion(int idDireccion, int idSubdireccion, string tipo, int idTipoRequerimiento, int anio, int mes);
        List<ReporteRequerimientoMensualSeguimientoPres> TraerReporteRequerimientoMensualSeguimiento(int idReqMenBieSer, int idMoneda);
        List<ReporteRequerimientoMensualSeguimientoDetallePres> TraerReporteRequerimientoMensualSeguimientoDetalle(int idReqMenBieSer, int idMoneda);
        List<ReporteRequerimientoMensualSeguimientoForebisePres> TraerReporteRequerimientoMensualSeguimientoForebise(int idReqMenBieSer, int idMoneda);
        List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> TraerReporteRequerimientoMensualSeguimientoForebiseCabecera(int idReqMenBieSer, int idMoneda);
        DataTable ListaEstructuraCargaRequerimientoMensual(int idReqMenBieSer, DataTable estructuraCarga);
    }
}
