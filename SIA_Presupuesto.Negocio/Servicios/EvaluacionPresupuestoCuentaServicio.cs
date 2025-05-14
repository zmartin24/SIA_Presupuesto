using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class EvaluacionPresupuestoCuentaServicio : IEvaluacionPresupuestoCuentaServicio
    {
        IEvaluacionPresupuestoCuentaRepositorio repositorio;
        

        public EvaluacionPresupuestoCuentaServicio(IEvaluacionPresupuestoCuentaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }


        #region Busqueda y listas
        public List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentas(int idSubPresupuesto, string numCuenta, int nivelCuenta, int idMoneda)
        {
            return repositorio.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, numCuenta, nivelCuenta, idMoneda).ToList();
        }
        public List<EvaluacionPresupuestoDetalleMovimientosPres> TraerListaEvaluacionPresupuestoDetalleMovimientos(int idSubPresupuesto, string numCuenta, int anio)
        {
            return repositorio.TraerListaEvaluacionPresupuestoDetalleMovimientos(idSubPresupuesto, numCuenta, anio).ToList();
        }
        public List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentasTodo(int idSubPresupuesto, string numCuenta, int nivelCuenta, int idMoneda)
        {
            return repositorio.TraerListaEvaluacionPresupuestoPorCuentasTodo(idSubPresupuesto, numCuenta, nivelCuenta, idMoneda).ToList();
        }
        public List<ReporteEjecucionPresupuestoPorCuentasPres> TraerReporteEjecucionPresupuestoPorCuentas(int anio, int idPresupuesto, int nivelPresupuesto, int nivelCuenta, int idMoneda)
        {
            return repositorio.TraerReporteEjecucionPresupuestoPorCuentas(anio, idPresupuesto, nivelPresupuesto, nivelCuenta, idMoneda).ToList();
        }

        #endregion

        #region Reporte

        #endregion
    }
}
