using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class EvaluacionPresupuestoCuentaRepositorio : IEvaluacionPresupuestoCuentaRepositorio
    {
        private IContexto contexto;

        public EvaluacionPresupuestoCuentaRepositorio(IContexto contexto)
        {
            this.contexto = contexto;
        }
        #region Listas
        
       
        public List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentas(int idSubPresupuesto, string numCuenta, int nivelCuenta, int idMoneda)
        {
            var contexto = this.contexto as IContexto;
            this.contexto.AumentarLatencia(300);
            return contexto.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, numCuenta, nivelCuenta, idMoneda).ToList();
        }
        public List<EvaluacionPresupuestoDetalleMovimientosPres> TraerListaEvaluacionPresupuestoDetalleMovimientos(int idSubPresupuesto, string numCuenta, int anio)
        {
            var contexto = this.contexto as IContexto;
            this.contexto.AumentarLatencia(300);
            return contexto.TraerListaEvaluacionPresupuestoDetalleMovimientos(idSubPresupuesto, numCuenta, anio).ToList();
        }
        public List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentasTodo(int idSubPresupuesto, string numCuenta, int nivelCuenta, int idMoneda)
        {
            List<EvaluacionPresupuestoPorCuentasPres> lista = new List<EvaluacionPresupuestoPorCuentasPres>();
            List<EvaluacionPresupuestoPorCuentasPres> listaDivisionaria = new List<EvaluacionPresupuestoPorCuentasPres>();
            //List<EvaluacionPresupuestoPorCuentasDiv> listaDivisionaria = new List<EvaluacionPresupuestoPorCuentasDiv>();
            List<EvaluacionPresupuestoPorCuentasPres> listaEspecifica = new List<EvaluacionPresupuestoPorCuentasPres>();
            //List<EvaluacionPresupuestoPorCuentasEsp> listaEspecifica = new List<EvaluacionPresupuestoPorCuentasEsp>();
            List<EvaluacionPresupuestoDetalleMovimientosPres> listaDetalleMovimiento = new List<EvaluacionPresupuestoDetalleMovimientosPres>();

            var contexto = this.contexto as IContexto;
            this.contexto.AumentarLatencia(300);
            lista = contexto.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, numCuenta, nivelCuenta, idMoneda).ToList();
            listaDivisionaria = contexto.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, "", 2, idMoneda).ToList();
            //listaDivisionaria = (from l in contexto.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, "", 2, idMoneda)
            //                     select new EvaluacionPresupuestoPorCuentasDiv { numCuenta = l.numCuenta, desCuenta = l.desCuenta, importePre = l.importePre, importeEje=l.importeEje,saldo=l.saldo }).ToList();
       
            listaEspecifica = contexto.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, "", 3, idMoneda).ToList();
            //listaEspecifica = (from l in contexto.TraerListaEvaluacionPresupuestoPorCuentas(idSubPresupuesto, "", 3, idMoneda)
            //                   select new EvaluacionPresupuestoPorCuentasEsp { numCuenta = l.numCuenta, desCuenta = l.desCuenta, importePre = l.importePre, importeEje = l.importeEje, saldo = l.saldo }).ToList();
            listaDetalleMovimiento = contexto.TraerListaEvaluacionPresupuestoDetalleMovimientos(idSubPresupuesto, "", idMoneda).ToList();

            
            
            listaEspecifica.ForEach(f => f.ListaDeVouchers = listaDetalleMovimiento.FindAll(t => t.numCuenta == f.numCuenta));
            listaDivisionaria.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.numCuenta.Substring(0, 3) == f.numCuenta));
            lista.ForEach(f => f.ListaDivisionarias = listaDivisionaria.FindAll(t => t.numCuenta.Substring(0, 2) == f.numCuenta));
            
            

            return lista;
        }
        public List<ReporteEjecucionPresupuestoPorCuentasPres> TraerReporteEjecucionPresupuestoPorCuentas(int anio, int idPresupuesto, int nivelPresupuesto, int nivelCuenta, int idMoneda)
        {
            List<ReporteEjecucionPresupuestoPorCuentasPres> lista = new List<ReporteEjecucionPresupuestoPorCuentasPres>();
            List<ReporteEjecucionPresupuestoPorCuentasPres> listaDivisionaria = new List<ReporteEjecucionPresupuestoPorCuentasPres>();
            List<ReporteEjecucionPresupuestoPorCuentasPres> listaEspecifica = new List<ReporteEjecucionPresupuestoPorCuentasPres>();
            List<ReporteEjecucionPresupuestoPorCuentasDetallePres> listaDetalleMovimiento = new List<ReporteEjecucionPresupuestoPorCuentasDetallePres>();

            var contexto = this.contexto as IContexto;
            this.contexto.AumentarLatencia(300);

            lista = contexto.TraerReporteEjecucionPresupuestoPorCuentas(anio, idPresupuesto, nivelPresupuesto, nivelCuenta, idMoneda).ToList();
            listaDivisionaria = contexto.TraerReporteEjecucionPresupuestoPorCuentas(anio, idPresupuesto, nivelPresupuesto, 2, idMoneda).ToList();
            listaEspecifica = contexto.TraerReporteEjecucionPresupuestoPorCuentas(anio, idPresupuesto, nivelPresupuesto, 3, idMoneda).ToList();
            listaDetalleMovimiento = contexto.TraerReporteEjecucionPresupuestoPorCuentasDetalle(anio, idPresupuesto, nivelPresupuesto, idMoneda).ToList();

            listaEspecifica.ForEach(f => f.ListaDeVouchers = listaDetalleMovimiento.FindAll(t => t.idCueCon == f.idCueCon));
            listaDivisionaria.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.dependencia == f.idCueCon));
            lista.ForEach(f => f.ListaDivisionarias = listaDivisionaria.FindAll(t => t.dependencia == f.idCueCon));

            return lista;
        }

        #endregion
        #region Busquedas 

        #endregion


    }
}