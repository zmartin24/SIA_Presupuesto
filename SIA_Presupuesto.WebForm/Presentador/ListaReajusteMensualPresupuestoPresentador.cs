using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Reporte;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaReajusteMensualPresupuestoPresentador
    {
        private readonly IListaReajusteMensualPresupuestoVista listaReajusteMensualPresupuestoVista;
        private IReajusteMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGrupoPresupuestoServicio grupoPresServicio;

        public ListaReajusteMensualPresupuestoPresentador(IListaReajusteMensualPresupuestoVista listaReajusteMensualPresupuestoVista)
        {
            this.listaReajusteMensualPresupuestoVista = listaReajusteMensualPresupuestoVista;
        }

        public void Iniciar()
        {
            //ObtenerDatosListado();
            listaReajusteMensualPresupuestoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaReajusteMensualPresupuestoVista.listaMeses = UtilitarioComun.ListarMeses();
            listaReajusteMensualPresupuestoVista.anioPresentacion = DateTime.Now.Year; // DateTime.Now.AddYears(1).Year;
            listaReajusteMensualPresupuestoVista.mesPresentacion = DateTime.Now.Month;
        }

        public void ObtenerDatosListado()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IReajusteMensualProgramacionServicio>();
            this.fuenteServicio = IoCHelper.ResolverIoC<IFuenteFinanciamientoServicio>();
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.grupoPresServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();

            listaReajusteMensualPresupuestoVista.listaDatosPrincipales = evaluacionMensualProgramacionServicio.TraerListaReajusteMensual(listaReajusteMensualPresupuestoVista.anioPresentacion, listaReajusteMensualPresupuestoVista.mesPresentacion);
        }

        public ReajusteMensualProgramacion Buscar(int id)
        {
            return evaluacionMensualProgramacionServicio.BuscarPorCodigo(id);
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

        public string ExportarReajuste(int id)
        {
            string ruta = string.Empty;
            ReajusteMensualProgramacion reajuste = evaluacionMensualProgramacionServicio.BuscarPorCodigo(id);
            List<ReajusteMensualAreaExporta> lista = evaluacionMensualProgramacionServicio.TraerListaReajusteMensualAreaExporta(id);
            if (lista.Count > 0)
                ruta = ExportarReajuste(reajuste, lista);
            return ruta;
        }


        private string ExportarReajuste(ReajusteMensualProgramacion reajuste, List<ReajusteMensualAreaExporta> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "ReajusteMensualPresupuesto_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarReajusteMensualPresupuesto(ruta, reajuste, lista);

            }

            return ruta;
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IReajusteMensualProgramacionServicio>();
        }

        //Requerimiento
        public void IniciarDatosProgramacionAnual(int id)
        {

        }

        public void IniciarReporte(int id)
        {
            listaReajusteMensualPresupuestoVista.listaGrupoPresupuestoSub = grupoPresServicio.listarTodos();
            listaReajusteMensualPresupuestoVista.listaAniosSub = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaReajusteMensualPresupuestoVista.listaMesesEvaSub = UtilitarioComun.ListarMeses();
            listaReajusteMensualPresupuestoVista.listaMesesReaSub = UtilitarioComun.ListarMeses();
            listaReajusteMensualPresupuestoVista.anioSub = DateTime.Now.Year;
            listaReajusteMensualPresupuestoVista.mesEvaSub = DateTime.Now.Month;
            listaReajusteMensualPresupuestoVista.mesReaSub = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;
        }

        public void IniciarCalendario(int id)
        {
            listaReajusteMensualPresupuestoVista.listaAniosCal = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaReajusteMensualPresupuestoVista.anioCal = DateTime.Now.Year;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]", desRubro = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(listaReajusteMensualPresupuestoVista.anioCal));

            listaReajusteMensualPresupuestoVista.listaFuenteFinanciamiento = lista;
            listaReajusteMensualPresupuestoVista.idFueFinCal = 0;

            listaReajusteMensualPresupuestoVista.listaMesesEvaCal = UtilitarioComun.ListarMeses();
            listaReajusteMensualPresupuestoVista.listaMesesReaCal = UtilitarioComun.ListarMeses();

            listaReajusteMensualPresupuestoVista.mesEvaCal = DateTime.Now.Month;
            listaReajusteMensualPresupuestoVista.mesReaCal = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;

            CargarDatosGrupoPresupuesto();
        }

        public void IniciarConsolidado(int id)
        {
            listaReajusteMensualPresupuestoVista.listaAniosCon = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaReajusteMensualPresupuestoVista.anioCon = DateTime.Now.Year;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]", desRubro = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(listaReajusteMensualPresupuestoVista.anioCon));

            listaReajusteMensualPresupuestoVista.listaFuenteFinanciamientoCon = lista;
            listaReajusteMensualPresupuestoVista.idFueFinCon = 0;

            listaReajusteMensualPresupuestoVista.listaMesesEvaCon = UtilitarioComun.ListarMeses();
            listaReajusteMensualPresupuestoVista.listaMesesReaCon = UtilitarioComun.ListarMeses();

            listaReajusteMensualPresupuestoVista.mesEvaCon = DateTime.Now.Month;
            listaReajusteMensualPresupuestoVista.mesReaCon = DateTime.Now.Month == 12 ? 12 : DateTime.Now.Month + 1;

        }

        public void CargarDatosGrupoPresupuesto()
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();
            lista.Add(new ProgramacionAnualPres { idProAnu = 0, anio = listaReajusteMensualPresupuestoVista.anioCal, descripcion = "[TODOS]" });
            lista.AddRange(programacionAnualServicio.TraerListaProgramacionAnual(listaReajusteMensualPresupuestoVista.anioCal));
            listaReajusteMensualPresupuestoVista.listaProgramacionAnual = lista;
            listaReajusteMensualPresupuestoVista.idProAnuCal = 0;
        }

    }
}
