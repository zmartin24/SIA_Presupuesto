using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class GeneralReporteRepositorio : IGeneralReporteRepositorio
    {
        private IContexto contexto;

        public GeneralReporteRepositorio(IContexto contexto)
        {
            this.contexto = contexto;
        }

        public List<ReporteOrdenCompraServicioComprometidasPres> TraerReporteOrdenCompraServicioComprometidas(int anio)
        {
            return contexto.TraerReporteOrdenCompraServicioComprometidas(anio).ToList();
        }
        public List<ReporteOrdenCompraServicioPresupuestoPres> TraerReporteOrdenCompraServicioPresupuesto(int anio,int idPresupuesto, int nivel, int opcion)
        {
            return contexto.TraerReporteOrdenCompraServicioPresupuesto(anio, idPresupuesto, nivel, opcion).ToList();
        }
        public List<ReporteEvaluacionDetalladaBienSerPres> TraerReporteEvaluacionDetalladaBienSer(int anio, int? idGruPre, int? idDireccion, int? idSubDireccion)
        {
            return contexto.TraerReporteEvaluacionDetalladaBienSer(anio, idGruPre, idDireccion, idSubDireccion).ToList();
        }
        public List<ReporteEvaluacionDetalladaBienSerExportaPres> TraerReporteEvaluacionDetalladaBienSerExporta(int anio, int? idGruPre, int? idDireccion, int? idSubDireccion)
        {
            return contexto.TraerReporteEvaluacionDetalladaBienSerExporta(anio, idGruPre, idDireccion, idSubDireccion).ToList();
        }
        public List<ReportePresupuestoEjecutadoFondosPres> TraerReportePresupuestoEjecutadoFondos(int idMoneda, int anio, int mesInicio, int mesFin, string numCuenta)
        {
            contexto.AumentarLatencia(120);
            return contexto.TraerReportePresupuestoEjecutadoFondos(idMoneda, anio, mesInicio, mesFin, numCuenta).ToList();
        }
        public List<SaldosEvaReaPorDir> SaldosEvaluacionReajustePorDirecciones(int anio, int mesRea, int mesEva)
        {
            return contexto.SaldosEvaluacionReajustePorDirecciones(anio, mesRea, mesEva).ToList();
        }
        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> TraerReportePresupuestoAprobadoComprometidoEjecutado(int idMoneda, int idSubPresupuesto)
        {
            List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> lista = new List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>();
            List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaDivisionaria = new List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>();
            List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaEspecifica = new List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>();
            

            var contexto = this.contexto as IContexto;
            lista = contexto.TraerReportePresupuestoAprobadoComprometidoEjecutado(idMoneda, idSubPresupuesto, 1).ToList();
            listaDivisionaria = contexto.TraerReportePresupuestoAprobadoComprometidoEjecutado(idMoneda, idSubPresupuesto, 2).ToList();
            listaEspecifica = contexto.TraerReportePresupuestoAprobadoComprometidoEjecutado(idMoneda, idSubPresupuesto, 3).ToList();

            listaDivisionaria.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.divisionaria == f.divisionaria));
            lista.ForEach(f => f.ListaDivisionarias = listaDivisionaria.FindAll(t => t.clase == f.clase));

            return lista;
        }
        public List<PrecioBienServicioPorGruPrePres> TraerListaPrecioBienServicioPorGruPre(int idGruPre, int anio, int mesIni, int mesFin, int tipoMoneda)
        {
            contexto.AumentarLatencia(60);
            return contexto.TraerListaPrecioBienServicioPorGruPre(idGruPre, anio, mesIni, mesFin, tipoMoneda).ToList();
        }
        public List<ReporteCertificacionOrdenProvisionPres> TraerReporteCertificacionOrdenProvision(int anio, int mes, int idMoneda)
        {
            contexto.AumentarLatencia(60);
            return contexto.TraerReporteCertificacionOrdenProvision(anio, mes, idMoneda).ToList();
        }
        public List<ReporteProgramacionAnualGenericaGastosPres> TraerReporteProgramacionAnualGenericaGastos(string codigos, int idMoneda)
        {
            contexto.AumentarLatencia(120);
            return contexto.TraerReporteProgramacionAnualGenericaGastos(codigos, idMoneda).ToList();
        }
        public List<ReporteEvaluacionMensualExportaGenericaPres> TraerReporteEvaluacionMensualExportaGenerica(int idEvaMenPro, int idMoneda)
        {
            contexto.AumentarLatencia(120);
            return contexto.TraerReporteEvaluacionMensualExportaGenerica(idEvaMenPro, idMoneda).ToList();
        }
        public List<ReportePresupuestoFasesPres> TraerReportePresupuestoFases(int anio, int idMoneda, DateTime fechaInicio, DateTime fechaFin, int idPresupuesto, int nivelPresupuesto)
        {
            //List<ReportePresupuestoFasesPres> listaGeneral = new List<ReportePresupuestoFasesPres>();
            //List<ReportePresupuestoFasesPres> lista = new List<ReportePresupuestoFasesPres>();
            //List<ReportePresupuestoFasesPres> listaSubCuenta = new List<ReportePresupuestoFasesPres>();
            //List<ReportePresupuestoFasesPres> listaEspecifica = new List<ReportePresupuestoFasesPres>();

            this.contexto.AumentarLatencia(300);

            //listaGeneral = contexto.TraerReportePresupuestoFases(anio, idMoneda, fechaInicio, fechaFin, idPresupuesto, nivelPresupuesto).ToList();
            //lista = listaGeneral.Where(x => x.nivel == 1).ToList();
            //listaSubCuenta = listaGeneral.Where(x => x.nivel == 2).ToList();
            //listaEspecifica = listaGeneral.Where(x => x.nivel == 3).ToList();
            //listaSubCuenta.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.dependencia == f.idCueCon));
            //lista.ForEach(f => f.ListaSubCuenta = listaSubCuenta.FindAll(t => t.dependencia == f.idCueCon));

            return contexto.TraerReportePresupuestoFases(anio, idMoneda, fechaInicio, fechaFin, idPresupuesto, nivelPresupuesto).ToList();
        }
        public List<ReportePresupuestoEjecutadoPres> TraerReportePresupuestoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string numCuenta)
        {
            contexto.AumentarLatencia(120);
            return contexto.TraerReportePresupuestoEjecutado(idMoneda, anio, mesInicio, mesFin, numCuenta).ToList();
        }
        public List<ReporteEvaluacionPresupuestoPorCuentasPres> TraerReporteEvaluacionPresupuestoPorCuentas(int idMoneda, int anio, int idPresupuesto, int nivelPresupuesto)
        {
            List<ReporteEvaluacionPresupuestoPorCuentasPres> listaData = new List<ReporteEvaluacionPresupuestoPorCuentasPres>();
            List<ReporteEvaluacionPresupuestoPorCuentasPres> lista = new List<ReporteEvaluacionPresupuestoPorCuentasPres>();
            List<ReporteEvaluacionPresupuestoPorCuentasPres> listaDivisionaria = new List<ReporteEvaluacionPresupuestoPorCuentasPres>();
            List<ReporteEvaluacionPresupuestoPorCuentasPres> listaEspecifica = new List<ReporteEvaluacionPresupuestoPorCuentasPres>();
            List<ReporteEvaluacionPresupuestoPorCuentasDetallePres> listaDetalleMovimiento = new List<ReporteEvaluacionPresupuestoPorCuentasDetallePres>();

            var contexto = this.contexto as IContexto;
            this.contexto.AumentarLatencia(120);

            listaData = contexto.TraerReporteEvaluacionPresupuestoPorCuentas(idMoneda, anio, idPresupuesto, nivelPresupuesto).ToList();
            lista = listaData.Where(x => x.nivel == 1).ToList();
            if (lista.Count>0)
            {
                listaDivisionaria = listaData.Where(x => x.nivel == 2).ToList();
                listaEspecifica = listaData.Where(x => x.nivel == 3).ToList();
                listaDetalleMovimiento = contexto.TraerReporteEvaluacionPresupuestoPorCuentasDetalle(idMoneda, anio, idPresupuesto, nivelPresupuesto).ToList();
            }


            listaEspecifica.ForEach(f => f.ListaDeVouchers = listaDetalleMovimiento.FindAll(t => t.idCueCon == f.idCueCon));
            listaDivisionaria.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.dependencia == f.idCueCon));
            lista.ForEach(f => f.ListaDivisionarias = listaDivisionaria.FindAll(t => t.dependencia == f.idCueCon));

            return lista;
        }

    }
}
