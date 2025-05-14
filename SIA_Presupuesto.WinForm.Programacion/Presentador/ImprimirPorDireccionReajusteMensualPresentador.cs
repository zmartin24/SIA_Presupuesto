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
    public class ImprimirPorDireccionReajusteMensualPresentador
    {
        private readonly IImprimirPorDireccionReajusteMensualVista imprimirPorDireccionReajusteMensualVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IReajusteMensualProgramacionServicio reajusteMensualServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoServicio;

        public ImprimirPorDireccionReajusteMensualPresentador(IImprimirPorDireccionReajusteMensualVista imprimirPorDireccionReajusteMensualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.reajusteMensualServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.imprimirPorDireccionReajusteMensualVista = imprimirPorDireccionReajusteMensualVista;
        }

        public void Inicializar()
        {
            imprimirPorDireccionReajusteMensualVista.listaGrupoPresupuesto = grupoServicio.listarTodos();
            imprimirPorDireccionReajusteMensualVista.listaDirecciones = generalServicio.ListaDirecciones();
            imprimirPorDireccionReajusteMensualVista.listaReporte = PredeterminadoHelper.ListarTipoReportePorDireccionPresupuestoAnual();

            imprimirPorDireccionReajusteMensualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            imprimirPorDireccionReajusteMensualVista.anioReporte = DateTime.Now.Year;

            imprimirPorDireccionReajusteMensualVista.listaMeses = UtilitarioComun.ListarMeses();
            
            imprimirPorDireccionReajusteMensualVista.listaMesesEva = UtilitarioComun.ListarMeses();
            imprimirPorDireccionReajusteMensualVista.mesReporteEva = DateTime.Now.Month;
        }

        public void ReajustePorDireccion()
        {
            ImprimirReajuste();
        }

        public void SeleccionarReajuste()
        {
            imprimirPorDireccionReajusteMensualVista.mesReporte = imprimirPorDireccionReajusteMensualVista.mesReporteEva < 12? imprimirPorDireccionReajusteMensualVista.mesReporteEva + 1: 12;
        }

        public void ImprimirReajuste()
        {
            //List<ResumenReajustePresupuestoPorSubdirecciones> comp = reajusteMensualServicio.TraerResumenReajustePresupuestoPorSubdirecciones(imprimirPorDireccionReajusteMensualVista.anioReporte, 
            //    imprimirPorDireccionReajusteMensualVista.idDireccion, imprimirPorDireccionReajusteMensualVista.mesReporte, imprimirPorDireccionReajusteMensualVista.mesReporteEva);
            List<EvaluacionReajustePorSubdireccion> comp = reajusteMensualServicio.TraerResumenEvaluacionReajustePorSubdirecciones(imprimirPorDireccionReajusteMensualVista.anioReporte,
                imprimirPorDireccionReajusteMensualVista.idDireccion, imprimirPorDireccionReajusteMensualVista.idGruPre,  imprimirPorDireccionReajusteMensualVista.mesReporte, imprimirPorDireccionReajusteMensualVista.mesReporteEva);
            
            rptResumenEvaReaPorSubdireccion reporte = new rptResumenEvaReaPorSubdireccion();
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
