using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IGastoRecurrenteRepositorio : IRepositorio<GastoRecurrente>
    {
        bool ActualizarDetallesGastoRecurrente(int idGasRec, string nomUsuario);

        List<GastoRecurrenteRequerimientoPres> TraerListaGastoRecurrenteRequerimiento(int idGasRec);
        List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro);
        List<ReporteGastoRecurrenteDetallePres> TraerReporteGastoRecurrenteDetalle(int idGasRec);
        List<ReporteGastoRecurrenteDetalleDireccionPres> TraerReporteGastoRecurrenteDetalleDireccion(int idGasRec, int idDireccion);
    }
}
