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
    public class ReporteEvaluacionPresentador
    {
        private readonly IReporteEvaluacionVista reporteEvaluacionVista;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private ITipoReporteServicio tipoReporteServicio;
        public ReporteEvaluacionPresentador(IReporteEvaluacionVista reporteEvaluacionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;
            this.tipoReporteServicio = _Contenedor.Resolver(typeof(ITipoReporteServicio)) as ITipoReporteServicio;

            this.reporteEvaluacionVista = reporteEvaluacionVista;
        } 

        public void Inicializar()
        {
            reporteEvaluacionVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            reporteEvaluacionVista.listaMeses = UtilitarioComun.ListarMeses();
            reporteEvaluacionVista.listaReporte = tipoReporteServicio.listarTodos();
        }

        public void Imprimir()
        {
            ImprimirRequerimiento();
        }

        public void ImprimirRequerimiento()
        {
            List<ResumenEvaFinanCorahSaal> comp = evaluacionMensualProgramacionServicio.TraerResumenEvaFinanCorahSaal(reporteEvaluacionVista.idTipRep, reporteEvaluacionVista.anio, reporteEvaluacionVista.mes);
            rptResumenFinanciamiento reporte = new rptResumenFinanciamiento();
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
