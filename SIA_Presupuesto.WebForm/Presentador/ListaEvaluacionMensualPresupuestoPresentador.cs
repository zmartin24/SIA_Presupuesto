using DevExpress.XtraReports.UI;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaEvaluacionMensualPresupuestoPresentador
    {
        private readonly IListaEvaluacionMensualPresupuestoVista listaEvaluacionMensualPresupuestoVista;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;
        private IGrupoPresupuestoServicio grupoPresServicio;
        private ITipoReporteServicio tipoReporteServicio;

        private EvaluacionMensualProgramacion evaluacionMensualProgramacion;
        private ProgramacionAnual programacionAnual;
        private GrupoPresupuesto grupoPresupuesto;

        public ListaEvaluacionMensualPresupuestoPresentador(IListaEvaluacionMensualPresupuestoVista listaEvaluacionMensualPresupuestoVista)
        {
            this.listaEvaluacionMensualPresupuestoVista = listaEvaluacionMensualPresupuestoVista;
            this.evaluacionMensualProgramacion = new EvaluacionMensualProgramacion();
            this.programacionAnual = new ProgramacionAnual();
            this.grupoPresupuesto = new GrupoPresupuesto();

        }

        public void Iniciar()
        {
            //ObtenerDatosListado();
            listaEvaluacionMensualPresupuestoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaEvaluacionMensualPresupuestoVista.listaMeses = UtilitarioComun.ListarMeses();
            listaEvaluacionMensualPresupuestoVista.anioPresentacion = DateTime.Now.Year; // DateTime.Now.AddYears(1).Year;
            listaEvaluacionMensualPresupuestoVista.mesPresentacion = DateTime.Now.Month;
        }

        public void ObtenerDatosListado()
        {
            this.evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IEvaluacionMensualProgramacionServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.fuenteServicio = IoCHelper.ResolverIoC<IFuenteFinanciamientoServicio>();
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();
            this.grupoPresServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();
            this.tipoReporteServicio = IoCHelper.ResolverIoC<ITipoReporteServicio>();




            listaEvaluacionMensualPresupuestoVista.listaDatosPrincipales = evaluacionMensualProgramacionServicio.TraerListaEvaluacionMensual(listaEvaluacionMensualPresupuestoVista.anioPresentacion, listaEvaluacionMensualPresupuestoVista.mesPresentacion);
        }

        public EvaluacionMensualProgramacion Buscar(int id)
        {
            return evaluacionMensualProgramacionServicio.BuscarPorCodigo(id);
        }
        public ProgramacionAnual BuscarProgramacionAnual(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigo(id);
        }
        public GrupoPresupuesto BuscarGrupoPresupuesto(int id)
        {
            return this.grupoPresServicio.BuscarPorCodigo(id);
        }

        private void LlamarReporte(XtraReport report, object datosReporte, string titulo)
        {
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = report;
            frm.datosReporte = datosReporte;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }

        

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IEvaluacionMensualProgramacionServicio>();
        }

        //Requerimiento
        public void IniciarDatosProgramacionAnual(int id)
        {

        }
        public void IniciarImprimir()
        {
            var listaTipoReporte = this.tipoReporteServicio.listarTodos();
            this.listaEvaluacionMensualPresupuestoVista.listaTipoReporte = tipoReporteServicio.listarTodos();
            this.listaEvaluacionMensualPresupuestoVista.listaAnioEvaImp = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            this.listaEvaluacionMensualPresupuestoVista.listaMesEvaImp = UtilitarioComun.ListarMeses();

            this.listaEvaluacionMensualPresupuestoVista.idTipRep = listaTipoReporte.OrderBy(x => x.idTipRep).FirstOrDefault().idTipRep;
            this.listaEvaluacionMensualPresupuestoVista.anioEvaImp = DateTime.Now.Year;
            this.listaEvaluacionMensualPresupuestoVista.mesEvaImp = DateTime.Now.Month;
        }

        public void IniciarReporte(int id)
        {
            listaEvaluacionMensualPresupuestoVista.listaGrupoPresupuestoSub = grupoPresServicio.listarTodos();
            listaEvaluacionMensualPresupuestoVista.listaAniosSub = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaEvaluacionMensualPresupuestoVista.listaMesesEvaSub = UtilitarioComun.ListarMeses();
            listaEvaluacionMensualPresupuestoVista.listaMesesReaSub = UtilitarioComun.ListarMeses();
            listaEvaluacionMensualPresupuestoVista.anioSub = DateTime.Now.Year;
            listaEvaluacionMensualPresupuestoVista.mesEvaSub = DateTime.Now.Month;
            listaEvaluacionMensualPresupuestoVista.mesReaSub = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;
        }
        public void IniciarReporteEjecucion()
        {
            listaEvaluacionMensualPresupuestoVista.listaGrupoPresupuestoEje = grupoPresServicio.TraerListaGrupoPresupuesto();
            listaEvaluacionMensualPresupuestoVista.listaMonedaEje = generalServicio.ListaMonedas();

            listaEvaluacionMensualPresupuestoVista.idGruPreEje = 298;
            listaEvaluacionMensualPresupuestoVista.idMonedaEje = 63;

            CargarPresupuestoEje();
        }
        public void IniciarReporteEjecucionPorFechas()
        {
            DateTime fechatemp = DateTime.Today;

            this.listaEvaluacionMensualPresupuestoVista.fecDesde_PreMenFec = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            this.listaEvaluacionMensualPresupuestoVista.fecHasta_PreMenFec = DateTime.Now.Date;
            listaEvaluacionMensualPresupuestoVista.listaGrupoPresupuesto_PreMenFec = grupoPresServicio.TraerListaGrupoPresupuesto();
            listaEvaluacionMensualPresupuestoVista.listaMoneda_PreMenFec = generalServicio.ListaMonedas();

            listaEvaluacionMensualPresupuestoVista.idGruPre_PreMenFec = 298;
            listaEvaluacionMensualPresupuestoVista.idMoneda_PreMenFec = 63;


            CargarPresupuestoEjeFec();
        }


        public void IniciarExportaEvaluacion(int id)
        {
            this.evaluacionMensualProgramacion = Buscar(id);

            listaEvaluacionMensualPresupuestoVista.desPresupuesto = this.evaluacionMensualProgramacion.descripcion;

            if (this.evaluacionMensualProgramacion.idProAnu > 0) this.programacionAnual = BuscarProgramacionAnual(this.evaluacionMensualProgramacion.idProAnu);
            if (this.programacionAnual.idGruPre > 0)
            {
                this.grupoPresupuesto = BuscarGrupoPresupuesto((int)this.programacionAnual.idGruPre);
                if (this.grupoPresupuesto.idGruPre > 0) listaEvaluacionMensualPresupuestoVista.desGrupoPresupuesto = this.grupoPresupuesto.descripcion;
            }
            this.listaEvaluacionMensualPresupuestoVista.idMoneda = 63;
        }
        public void IniciarExportaEvaluacionReajuste()
        {
            this.listaEvaluacionMensualPresupuestoVista.listaAniosEvaRea = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            this.listaEvaluacionMensualPresupuestoVista.listaMonedaEvaRea = this.generalServicio.ListaMonedas();
            this.listaEvaluacionMensualPresupuestoVista.listaMesesEvaReaEva = UtilitarioComun.ListarMeses();
            this.listaEvaluacionMensualPresupuestoVista.listaMesesEvaReaRea = UtilitarioComun.ListarMeses();
            this.listaEvaluacionMensualPresupuestoVista.anioEvaRea = DateTime.Now.Year;
            this.listaEvaluacionMensualPresupuestoVista.mesEvaReaEva = DateTime.Now.Month;
            this.listaEvaluacionMensualPresupuestoVista.mesEvaReaRea = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;
            this.listaEvaluacionMensualPresupuestoVista.idMonedaEvaRea = 63;
        }

        public void IniciarCalendario(int id)
        {
            listaEvaluacionMensualPresupuestoVista.listaAniosCal = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaEvaluacionMensualPresupuestoVista.anioCal = DateTime.Now.Year;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]", desRubro = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(listaEvaluacionMensualPresupuestoVista.anioCal));

            listaEvaluacionMensualPresupuestoVista.listaFuenteFinanciamiento = lista;
            listaEvaluacionMensualPresupuestoVista.idFueFinCal = 0;

            listaEvaluacionMensualPresupuestoVista.listaMesesEvaCal = UtilitarioComun.ListarMeses();
            listaEvaluacionMensualPresupuestoVista.listaMesesReaCal = UtilitarioComun.ListarMeses();

            listaEvaluacionMensualPresupuestoVista.mesEvaCal = DateTime.Now.Month;
            listaEvaluacionMensualPresupuestoVista.mesReaCal = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;

            CargarDatosGrupoPresupuesto();
        }

        public void IniciarConsolidado(int id)
        {
            listaEvaluacionMensualPresupuestoVista.listaAniosCon = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaEvaluacionMensualPresupuestoVista.anioCon = DateTime.Now.Year;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]", desRubro = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(listaEvaluacionMensualPresupuestoVista.anioCon));

            listaEvaluacionMensualPresupuestoVista.listaFuenteFinanciamientoCon = lista;
            listaEvaluacionMensualPresupuestoVista.idFueFinCon = 0;

            listaEvaluacionMensualPresupuestoVista.listaMesesEvaCon = UtilitarioComun.ListarMeses();
            listaEvaluacionMensualPresupuestoVista.listaMesesReaCon = UtilitarioComun.ListarMeses();

            listaEvaluacionMensualPresupuestoVista.mesEvaCon = DateTime.Now.Month;
            listaEvaluacionMensualPresupuestoVista.mesReaCon = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;

        }

        public void IniciarSaldoPorGrupo()
        {
            listaEvaluacionMensualPresupuestoVista.listaAnio_SalGru = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaEvaluacionMensualPresupuestoVista.anio_SalGru = DateTime.Now.Year;

            listaEvaluacionMensualPresupuestoVista.listaMesEva_SalGru = UtilitarioComun.ListarMeses();
            listaEvaluacionMensualPresupuestoVista.listaMesRea_SalGru = UtilitarioComun.ListarMeses();

            listaEvaluacionMensualPresupuestoVista.mesEva_SalGru = DateTime.Now.Month;
            listaEvaluacionMensualPresupuestoVista.mesRea_SalGru = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;
        }

        public List<ProgramacionAnualPres> TraerListaProgramacionAnual(int anio)
        {
            return this.programacionAnualServicio.TraerListaProgramacionAnual(anio);
        }
        public List<ResumenEvaFinanCorahSaal> TraerResumenEvaFinanCorahSaal()
        {
            return this.evaluacionMensualProgramacionServicio.TraerResumenEvaFinanCorahSaal(this.listaEvaluacionMensualPresupuestoVista.idTipRep, this.listaEvaluacionMensualPresupuestoVista.anioEvaImp, this.listaEvaluacionMensualPresupuestoVista.mesEvaImp);
        }
        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta()
        {
            return this.evaluacionMensualProgramacionServicio.TraerListaEvaluacionReajusteMensualAreaExporta(this.listaEvaluacionMensualPresupuestoVista.idsProAnuEvaRea, this.listaEvaluacionMensualPresupuestoVista.anioEvaRea, this.listaEvaluacionMensualPresupuestoVista.mesEvaReaRea, this.listaEvaluacionMensualPresupuestoVista.mesEvaReaEva);
        }
        public List<ReporteEvaluacionMensualExportaPres> TraerReporteEvaluacionMensualExporta(int id)
        {
            return this.evaluacionMensualProgramacionServicio.TraerReporteEvaluacionMensualExporta(id, this.listaEvaluacionMensualPresupuestoVista.idMoneda);
        }


        public void CargarDatosGrupoPresupuesto()
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();
            lista.Add(new ProgramacionAnualPres { idProAnu = 0, anio = listaEvaluacionMensualPresupuestoVista.anioCal, descripcion = "[TODOS]" });
            lista.AddRange(programacionAnualServicio.TraerListaProgramacionAnual(listaEvaluacionMensualPresupuestoVista.anioCal));
            listaEvaluacionMensualPresupuestoVista.listaProgramacionAnual = lista;
            listaEvaluacionMensualPresupuestoVista.idProAnuCal = 0;
        }
        public void CargarPresupuestoAnualPopEvaRea()
        {
            this.listaEvaluacionMensualPresupuestoVista.listaProgramacionAnualEvaRea = TraerListaProgramacionAnual(this.listaEvaluacionMensualPresupuestoVista.anioEvaRea);
        }
        public void CargarPresupuestoEje()
        {
            var lista = this.programacionAnualServicio.listarTodosPorGrupoPresupuesto(listaEvaluacionMensualPresupuestoVista.idGruPreEje);
            this.listaEvaluacionMensualPresupuestoVista.listaProgramacionAnualEje = lista;
            this.listaEvaluacionMensualPresupuestoVista.idPreEje = lista.OrderByDescending(x=>x.idProAnu).FirstOrDefault().idProAnu;

            CargarSubpresupuestoEje();

        }
        public void CargarSubpresupuestoEje()
        {
            var lista = subpresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(listaEvaluacionMensualPresupuestoVista.idPreEje);
            this.listaEvaluacionMensualPresupuestoVista.listaSubpresupuestoEje = lista;
            this.listaEvaluacionMensualPresupuestoVista.idSubPreEje = lista.OrderByDescending(x => x.idSubpresupuesto).FirstOrDefault().idSubpresupuesto;
        }
        public void CargarPresupuestoEjeFec()
        {
            var lista = this.programacionAnualServicio.listarTodosPorGrupoPresupuesto(listaEvaluacionMensualPresupuestoVista.idGruPre_PreMenFec);
            this.listaEvaluacionMensualPresupuestoVista.listaProgramacionAnual_PreMenFec = lista;
            this.listaEvaluacionMensualPresupuestoVista.idPre_PreMenFec = lista.OrderByDescending(x => x.idProAnu).FirstOrDefault().idProAnu;
        }

    }
}
