using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IEvaluacionPresupuestoCuentaServicio 
    {


        #region Busqueda y listas
        List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentas(int idSubPresupuesto, string numCuenta, int nivelCuenta, int idMoneda);
        List<EvaluacionPresupuestoDetalleMovimientosPres> TraerListaEvaluacionPresupuestoDetalleMovimientos(int idSubPresupuesto, string numCuenta, int anio);
        List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentasTodo(int idSubPresupuesto, string numCuenta, int nivelCuenta, int idMoneda);
        List<ReporteEjecucionPresupuestoPorCuentasPres> TraerReporteEjecucionPresupuestoPorCuentas(int anio, int idPresupuesto, int nivelPresupuesto, int nivelCuenta, int idMoneda);
        #endregion

        #region Reporte
        #endregion
    }
}
