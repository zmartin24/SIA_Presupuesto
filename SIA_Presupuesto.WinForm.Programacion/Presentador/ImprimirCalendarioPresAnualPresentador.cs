using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Reporte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ImprimirCalendarioPresAnualPresentador
    {
        private readonly IImprimirCalendarioPresAnualVista imprimirCalendarioPresAnualVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;
        private IGrupoPresupuestoServicio grupoServicio;

        public ImprimirCalendarioPresAnualPresentador(IImprimirCalendarioPresAnualVista imprimirCalendarioPresAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.fuenteServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.imprimirCalendarioPresAnualVista = imprimirCalendarioPresAnualVista;
        } 

        public void Inicializar()
        {
            imprimirCalendarioPresAnualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            imprimirCalendarioPresAnualVista.anioReporte = DateTime.Now.Year;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(imprimirCalendarioPresAnualVista.anioReporte));
           
            imprimirCalendarioPresAnualVista.listaFueFin = lista;
            imprimirCalendarioPresAnualVista.idFueFin = 0;
            //imprimirCalendarioPresAnualVista.listaGrupoPres = grupoServicio.TraerListaGrupoPresupuesto();
            CargarDatosGrupoPresupuesto();
        }

        public void CargarDatosGrupoPresupuesto()
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();
            lista.Add(new ProgramacionAnualPres { idProAnu = 0, anio = imprimirCalendarioPresAnualVista.anioReporte, descripcion = "[TODOS]" });
            lista.AddRange(programacionAnualServicio.TraerListaProgramacionAnual(imprimirCalendarioPresAnualVista.anioReporte));
            imprimirCalendarioPresAnualVista.listaProgramacion = lista;
            imprimirCalendarioPresAnualVista.idProAnu = 0;
        }

        public void ImprimirCalenarios()
        {
            ImprimirCalendario();
        }

        private void ExportarRequerimientoDireccion(List<RequerimientoBienServicioDetallePresExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarRequerimientos(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        public void ImprimirCalendario()
        {
            List<CalendarioPresupuestoAnual> comp =
            programacionAnualServicio.TraerCalendarioPresupuestoAnual(imprimirCalendarioPresAnualVista.anioReporte, imprimirCalendarioPresAnualVista.idFueFin, imprimirCalendarioPresAnualVista.idProAnu);
            rptCalendarioPresupuestoAnual reporte = new rptCalendarioPresupuestoAnual();
            //string titulo = "COMPROBANTE DE INGRESO";

            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = reporte;
            frm.datosReporte = comp;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }
    }
}
