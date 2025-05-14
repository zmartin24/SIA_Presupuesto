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
    public class ImprimirCalendarioReajusteEvaluacionPresentador
    {
        private readonly IImprimirCalendarioReajusteEvaluacionVista imprimirCalendarioReajusteEvaluacionVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;
        private IGrupoPresupuestoServicio grupoServicio;

        public ImprimirCalendarioReajusteEvaluacionPresentador(IImprimirCalendarioReajusteEvaluacionVista imprimirCalendarioReajusteEvaluacionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.fuenteServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.imprimirCalendarioReajusteEvaluacionVista = imprimirCalendarioReajusteEvaluacionVista;
        } 

        public void Inicializar()
        {
            imprimirCalendarioReajusteEvaluacionVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            imprimirCalendarioReajusteEvaluacionVista.anioReporte = DateTime.Now.Year;

            imprimirCalendarioReajusteEvaluacionVista.listaMeses = UtilitarioComun.ListarMeses();
            imprimirCalendarioReajusteEvaluacionVista.listaMesesRea = UtilitarioComun.ListarMeses();
            imprimirCalendarioReajusteEvaluacionVista.mesReporte = DateTime.Now.Month;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(imprimirCalendarioReajusteEvaluacionVista.anioReporte));
           
            imprimirCalendarioReajusteEvaluacionVista.listaFueFin = lista;
            imprimirCalendarioReajusteEvaluacionVista.idFueFin = 0;
            //imprimirCalendarioReajusteEvaluacionVista.listaGrupoPres = grupoServicio.TraerListaGrupoPresupuesto();
            CargarDatosGrupoPresupuesto();
        }

        public void CargarDatosGrupoPresupuesto()
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();
            lista.Add(new ProgramacionAnualPres { idProAnu = 0, anio = imprimirCalendarioReajusteEvaluacionVista.anioReporte, descripcion = "[TODOS]" });
            lista.AddRange(programacionAnualServicio.TraerListaProgramacionAnual(imprimirCalendarioReajusteEvaluacionVista.anioReporte));
            imprimirCalendarioReajusteEvaluacionVista.listaProgramacion = lista;
            imprimirCalendarioReajusteEvaluacionVista.idProAnu = 0;
        }

        public void AsignarMesReajuste()
        {
            imprimirCalendarioReajusteEvaluacionVista.mesReporteRea = imprimirCalendarioReajusteEvaluacionVista.mesReporte == 12 ? imprimirCalendarioReajusteEvaluacionVista.mesReporte :
                imprimirCalendarioReajusteEvaluacionVista.mesReporte + 1;
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
            int mesReajuste = imprimirCalendarioReajusteEvaluacionVista.mesReporte + 1;
            int mesEvaluacion = imprimirCalendarioReajusteEvaluacionVista.mesReporte;
            List<CalendarioEvaluacionyAjusteAnual> comp =
            reajusteMensualProgramacionServicio.TraerCalendarioEvaluacionyAjusteAnual(imprimirCalendarioReajusteEvaluacionVista.anioReporte, imprimirCalendarioReajusteEvaluacionVista.idFueFin, mesReajuste, mesEvaluacion, imprimirCalendarioReajusteEvaluacionVista.idProAnu);

            rptCalendarioReajusteEvaluacionAnual reporte = new rptCalendarioReajusteEvaluacionAnual();
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
