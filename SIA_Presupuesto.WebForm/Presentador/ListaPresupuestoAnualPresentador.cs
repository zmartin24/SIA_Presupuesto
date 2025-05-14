using DevExpress.XtraReports.UI;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Reporte;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaPresupuestoAnualPresentador
    {
        private readonly IListaPresupuestoAnualVista listaPresupuestoAnualVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGrupoPresupuestoServicio grupoPresServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;

        public ListaPresupuestoAnualPresentador(IListaPresupuestoAnualVista listaPresupuestoAnualVista)
        {
            this.listaPresupuestoAnualVista = listaPresupuestoAnualVista;
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.grupoPresServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();
        }

        public void Iniciar()
        {
            listaPresupuestoAnualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaPresupuestoAnualVista.anioPresentacion = DateTime.Now.Year; // DateTime.Now.AddYears(1).Year;
        }

        public void IniciarPopExportaPresupuestoAnual()
        {
            ProgramacionAnual programacionAnual = new ProgramacionAnual();
            GrupoPresupuesto grupoPresupuesto = new GrupoPresupuesto();

            programacionAnual = Buscar(this.listaPresupuestoAnualVista.idProAnuExp);
            if (programacionAnual.idGruPre != null && programacionAnual.idGruPre > 0)
            {
                grupoPresupuesto = BuscarGrupoPresupuesto((int)programacionAnual.idGruPre);
                this.listaPresupuestoAnualVista.desGrupoPresupuesto = grupoPresupuesto.descripcion;
                this.listaPresupuestoAnualVista.desPresupuesto = programacionAnual.descripcion;
            }

            this.listaPresupuestoAnualVista.listaMonedaExpProAnu = generalServicio.ListaMonedas();
            this.listaPresupuestoAnualVista.idMonedaExpProAnu = 63;
        }
        public void IniciarPopExportaPresupuestoAnualMasivo()
        {
            this.listaPresupuestoAnualVista.listaAnioPopExpProAnuMas = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            this.listaPresupuestoAnualVista.listaMonedaPopExpProAnuMas = this.generalServicio.ListaMonedas();
            this.listaPresupuestoAnualVista.anioPopExpProAnuMas = DateTime.Now.Year;
            this.listaPresupuestoAnualVista.idMonedaPopExpProAnuMas = 63;
        }

        public void ObtenerDatosListado()
        {
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.grupoPresServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.fuenteServicio = IoCHelper.ResolverIoC<IFuenteFinanciamientoServicio>();

            listaPresupuestoAnualVista.listaDatosPrincipales = programacionAnualServicio.TraerListaProgramacionAnual(listaPresupuestoAnualVista.anioPresentacion);
        }
        public void LlenarGridPopExpProAnuMas()
        {
            this.listaPresupuestoAnualVista.listaProgramacionAnualPopExpProAnuMas = programacionAnualServicio.TraerListaProgramacionAnual(this.listaPresupuestoAnualVista.anioPopExpProAnuMas);
        }

        public ProgramacionAnual Buscar(int id)
        {
            return programacionAnualServicio.BuscarPorCodigo(id);
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


        public bool AnularRegistro(int id)
        {
            ProgramacionAnual ProgramacionAnual = Buscar(id);
            return programacionAnualServicio.Anular(ProgramacionAnual, listaPresupuestoAnualVista.nomUsuario).esCorrecto;
        }

        public void ImprimirRequerimiento(int id)
        {
            ProgramacionAnual ProgramacionAnual = Buscar(id);
            if (ProgramacionAnual != null)
            {
                List<ProgramacionAnualDetallePres> comp = programacionAnualServicio.TraerListaProgramacionAnualDetalle(id);
                rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();

                ReporteWinForDev frm = new ReporteWinForDev();
                List<ParametrosReporte> p = new List<ParametrosReporte>();
                frm.report = reporte;
                frm.datosReporte = comp;
                frm.listaParametros = p;
                frm.AbrirDocumento(true, false);
            }
        }

        public string ExportarProgramacionAnual(int id)
        {
            string ruta = string.Empty;
            List<ProgramacionAnualAreaExporta> lista = programacionAnualServicio.TraerListaProgramacionAnualAreaExporta(id);
            if (lista.Count > 0)
                ruta = ExportarProgramacionAnual(lista);
            return ruta;
        }

        private string ExportarProgramacionAnual(List<ProgramacionAnualAreaExporta> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "ProgramacionAnual_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnual(ruta, lista);

            }

            return ruta;
        }

        public List<ReporteProgramacionAnualExportaPres> listaProgramacionAnualAreaExporta()
        {
            return this.programacionAnualServicio.TraerReporteProgramacionAnualExporta(this.listaPresupuestoAnualVista.idProAnuExp, this.listaPresupuestoAnualVista.idMonedaExpProAnu);
        }
        public List<ReporteProgramacionAnualExportaMasivoPres> TraerReporteProgramacionAnualExportaMasivo()
        {
            return this.programacionAnualServicio.TraerReporteProgramacionAnualExportaMasivo(this.listaPresupuestoAnualVista.idsProAnuMas, this.listaPresupuestoAnualVista.idMonedaPopExpProAnuMas);
        }

        //Requerimiento
        public void IniciarReporte(int id)
        {
            listaPresupuestoAnualVista.listaDireccionesReporte = generalServicio.ListaDirecciones();
            listaPresupuestoAnualVista.listaAniosRep = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);

            listaPresupuestoAnualVista.anioReporte = listaPresupuestoAnualVista.anioPresentacion;
        }

        public void IniciarCalendario(int id)
        {
            listaPresupuestoAnualVista.listaAniosCal = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            listaPresupuestoAnualVista.anioCal = DateTime.Now.Year;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]", desRubro = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(listaPresupuestoAnualVista.anioCal));

            listaPresupuestoAnualVista.listaFuenteFinanciamiento = lista;
            listaPresupuestoAnualVista.idFueFinCal = 0;

            CargarDatosGrupoPresupuesto();
        }

        public void CargarDatosGrupoPresupuesto()
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();
            lista.Add(new ProgramacionAnualPres { idProAnu = 0, anio = listaPresupuestoAnualVista.anioCal, descripcion = "[TODOS]" });
            lista.AddRange(programacionAnualServicio.TraerListaProgramacionAnual(listaPresupuestoAnualVista.anioCal));
            listaPresupuestoAnualVista.listaProgramacionAnual = lista;
            listaPresupuestoAnualVista.idProAnuCal = 0;
        }

        private void LlenarCombosRequerimiento()
        {
            //listaPresupuestoAnualVista.listaMonedas = generalServicio.ListaMonedas();

            //List<Direccion> listaDireccion = new List<Direccion>();
            //listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            //listaDireccion.AddRange(generalServicio.ListaDirecciones());

            //listaPresupuestoAnualVista.listaDirecciones = listaDireccion;
        }

        private bool esModificacion;
        public Resultado GuardarDatosRequerimiento(string args)
        {
            //this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            //this.programacionAnualServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();


            Resultado resultado = null;
            //var callbackArgs = Util.DeserializeCallbackArgs(args);

            //RequerimientoBienServicio RequerimientoBienServicio = null;
            //if (callbackArgs[0] == "Nuevo")
            //{
            //    RequerimientoBienServicio = new RequerimientoBienServicio();
            //}
            //else if (callbackArgs[0] == "Editar")
            //{
            //    int id = int.Parse(callbackArgs[1]);
            //    RequerimientoBienServicio = Buscar(id);
            //    esModificacion = true;
            //}

            //if (RequerimientoBienServicio == null)
            //    return null;

            //RequerimientoBienServicio.idMoneda = listaPresupuestoAnualVista.idMoneda;
            //RequerimientoBienServicio.descripcion = listaPresupuestoAnualVista.descripcion;
            //RequerimientoBienServicio.anio = listaPresupuestoAnualVista.anio;
            //RequerimientoBienServicio.fechaEmision = listaPresupuestoAnualVista.fechaEmision;
            //RequerimientoBienServicio.idArea = listaPresupuestoAnualVista.idArea;

            //if (this.esModificacion)
            //{
            //    RequerimientoBienServicio.fechaEdita = DateTime.Now;
            //    RequerimientoBienServicio.usuEdita = listaPresupuestoAnualVista.nomUsuario;
            //    resultado = programacionAnualServicio.ModificarSinClonar(RequerimientoBienServicio);
            //}
            //else
            //{
            //    RequerimientoBienServicio.fechaCrea = DateTime.Now;
            //    RequerimientoBienServicio.usuCrea = listaPresupuestoAnualVista.nomUsuario;
            //    RequerimientoBienServicio.estado = Estados.Activo;
            //    resultado = programacionAnualServicio.Nuevo(RequerimientoBienServicio);
            //}

            return resultado;
        }

    }
}
