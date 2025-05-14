using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;
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
    public class ListaReajusteAnualPresupuestoPresentador
    {
        private readonly IListaReajusteMensualPresupuestoVista listaReajusteMensualPresupuestoVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IReajustePresupuestoRemuneracionServicio reajustePresupuestoRemuneracionServicio;

        public ListaReajusteAnualPresupuestoPresentador(IListaReajusteMensualPresupuestoVista IListaReajusteMensualPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.reajustePresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IReajustePresupuestoRemuneracionServicio)) as IReajustePresupuestoRemuneracionServicio;

            this.listaReajusteMensualPresupuestoVista = IListaReajusteMensualPresupuestoVista;
        }

        public void Iniciar()
        {
            listaReajusteMensualPresupuestoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            listaReajusteMensualPresupuestoVista.listaMeses = UtilitarioComun.ListarMeses();

            listaReajusteMensualPresupuestoVista.anioPresentacion = DateTime.Now.Date.Year;
            listaReajusteMensualPresupuestoVista.mesPresentacion = DateTime.Now.Date.Month;
        }

        public void ObtenerDatosListado()
        {
            listaReajusteMensualPresupuestoVista.listaDatosPrincipales
                = reajusteMensualProgramacionServicio.TraerListaReajusteMensual(listaReajusteMensualPresupuestoVista.anioPresentacion, listaReajusteMensualPresupuestoVista.mesPresentacion);
        }

        public ReajusteMensualProgramacion Buscar(int id)
        {
            return reajusteMensualProgramacionServicio.BuscarPorCodigo(id);
        }
        public List<ReporteReajusteMensualExportaPres> TraerReporteReajusteMensualExporta()
        {
            return reajusteMensualProgramacionServicio.TraerReporteReajusteMensualExporta(listaReajusteMensualPresupuestoVista.ReajusteMensualProgramacion.idReaMenPro, listaReajusteMensualPresupuestoVista.idMoneda);
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
            return reajusteMensualProgramacionServicio.Anular(listaReajusteMensualPresupuestoVista.ReajusteMensualProgramacion, listaReajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario).esCorrecto;
        }

        public void ExportarProgramacionAnual()
        {
            List<ReajusteMensualAreaExporta> lista = reajusteMensualProgramacionServicio.TraerListaReajusteMensualAreaExporta(listaReajusteMensualPresupuestoVista.ReajusteMensualProgramacion.idReaMenPro);
            ExportarProgramacionAnual(listaReajusteMensualPresupuestoVista.ReajusteMensualProgramacion, lista);
        }


        private void ExportarProgramacionAnual(ReajusteMensualProgramacion reajuste, List<ReajusteMensualAreaExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "ReajusteMensual_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarReajusteMensualPresupuesto(ruta, reajuste, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        public void ExportarPresupuestoRemuneracion()
        {
            List<PresupuestoRemuneracionExporta> lista = reajustePresupuestoRemuneracionServicio.ReajustePresupuestoRemuneracionExporta(listaReajusteMensualPresupuestoVista.ReajusteMensualProgramacion.idReaMenPro);
            if (lista.Count > 0)
                ExportarPresupuestoRemuneracion(lista);
        }


        private void ExportarPresupuestoRemuneracion(List<PresupuestoRemuneracionExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PresupuestoRemuneracion_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarPresupuestoRemuneracion(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
        public bool ActualizarDesdeRequerimientoMensualBienesServicio()
        {
            bool resultado = true;
            //this.programacionAnual.estado = cambioEstadoProgramacionAnualVista.codEstado;
            //this.programacionAnual.usuEdita = cambioEstadoProgramacionAnualVista.UsuarioOperacion.NomUsuario;
            //this.programacionAnual.fechaEdita = DateTime.Now;

            //string codigos = this.actualizacionPorRRHHVista.IndicaSoloReajuste ? string.Empty : string.Join("~", this.actualizacionPorRRHHVista.listaAreasSeleccionadas.Select(s => s.idArea));
            this.reajusteMensualProgramacionServicio.GuardarDetalleRequerimientoMensualEnReajuste(this.listaReajusteMensualPresupuestoVista.ReajusteMensualProgramacion.idReaMenPro, this.listaReajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario);

            return resultado;
        }
    }
}
