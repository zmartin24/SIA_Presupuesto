using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaEvaluacionAnualPresupuestoPresentador
    {
        private readonly IListaEvaluacionMensualPresupuestoVista listaEvaluacionMensualPresupuestoVista;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;

        public ListaEvaluacionAnualPresupuestoPresentador(IListaEvaluacionMensualPresupuestoVista IListaEvaluacionMensualPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;

            this.listaEvaluacionMensualPresupuestoVista = IListaEvaluacionMensualPresupuestoVista;
        }

        public void Iniciar()
        {
            listaEvaluacionMensualPresupuestoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            listaEvaluacionMensualPresupuestoVista.listaMeses = UtilitarioComun.ListarMeses();

            listaEvaluacionMensualPresupuestoVista.anioPresentacion = DateTime.Now.Date.Year;
            listaEvaluacionMensualPresupuestoVista.mesPresentacion = DateTime.Now.Date.Month;
        }

        public void ObtenerDatosListado()
        {
            listaEvaluacionMensualPresupuestoVista.listaDatosPrincipales = 
                evaluacionMensualProgramacionServicio.TraerListaEvaluacionMensual(listaEvaluacionMensualPresupuestoVista.anioPresentacion, listaEvaluacionMensualPresupuestoVista.mesPresentacion);
        }

        public EvaluacionMensualProgramacion Buscar(int id)
        {
            return evaluacionMensualProgramacionServicio.BuscarPorCodigo(id);
        }

        private void LlamarReporte(XtraReport report, object datosReporte, string titulo)
        {
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            //p.Add(new ParametrosReporte { nombre = "Titulo", valor = titulo, tipo = TipoParametroReporteDev.Cadena });
            frm.report = report;
            frm.datosReporte = datosReporte;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }

        public bool AnularRegistro()
        {
            return evaluacionMensualProgramacionServicio.Anular(listaEvaluacionMensualPresupuestoVista.EvaluacionMensualProgramacion, listaEvaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario).esCorrecto;
        }
        public List<ReporteEvaluacionMensualExportaPres> TraerReporteEvaluacionMensualExporta()
        {
            return this.evaluacionMensualProgramacionServicio.TraerReporteEvaluacionMensualExporta(listaEvaluacionMensualPresupuestoVista.EvaluacionMensualProgramacion.idEvaMenPro, listaEvaluacionMensualPresupuestoVista.idMoneda);
        }

    }
}
