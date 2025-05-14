using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
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
    public class ListaRequerimientoBienServicioPresentador
    {
        private readonly IListaRequerimientoBienServicioVista listaRequerimientoBienServicioVista;
        private IRequerimientoBienServicioServicio requerimientoBienServicioServicio;
        private IPeriodoServicio periodoServicio;
        public ListaRequerimientoBienServicioPresentador(IListaRequerimientoBienServicioVista listaRequerimientoBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;
            this.listaRequerimientoBienServicioVista = listaRequerimientoBienServicioVista;
        }

        public void Iniciar()
        {
            listaRequerimientoBienServicioVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);

            listaRequerimientoBienServicioVista.anioPresentacion = this.periodoServicio.ObtenerActivo().anio; //DateTime.Now.Date.AddYears(1).Year;
        }

        public void ObtenerDatosListado()
        {
            listaRequerimientoBienServicioVista.listaDatosPrincipales = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicio(listaRequerimientoBienServicioVista.anioPresentacion, listaRequerimientoBienServicioVista.UsuarioOperacion.IDUsuario);
        }

        public RequerimientoBienServicio Buscar(int id)
        {
            return requerimientoBienServicioServicio.BuscarPorCodigo(id);
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
            return requerimientoBienServicioServicio.Anular(listaRequerimientoBienServicioVista.RequerimientoBienServicio, listaRequerimientoBienServicioVista.UsuarioOperacion.NomUsuario).esCorrecto;
        }

        public void ExportarRequerimientoPorDireccion()
        {
            //List<ProgramacionAnualAreaExporta> lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDireccionExporta(listaRequerimientoBienServicioVista.RequerimientoBienServicio.idProAnu);
            //ExportarProgramacionAnual(lista);
        }

        public void ImprimirRequerimiento()
        {
            if (listaRequerimientoBienServicioVista.RequerimientoBienServicio != null)
            {
                List<RequerimientoBienServicioDetallePres> comp = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalle(listaRequerimientoBienServicioVista.RequerimientoBienServicio.idReqBieSer);
                rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();
                //string titulo = "COMPROBANTE DE INGRESO";

                ReporteWinForDev frm = new ReporteWinForDev();
                List<ParametrosReporte> p = new List<ParametrosReporte>();
                frm.report = reporte;
                frm.datosReporte = comp;
                frm.listaParametros = p;
                frm.AbrirDocumento(true, false);
            }
        }


        private void ExportarProgramacionAnual(List<ProgramacionAnualAreaExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "ProgramacionAnual_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnual(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        public void ExportarRequerimiento()
        {
            List<ReporteRequerimientoBienServicioExportaPres> lista = requerimientoBienServicioServicio.TraerReporteRequerimientoBienServicioExporta(listaRequerimientoBienServicioVista.RequerimientoBienServicio.idReqBieSer);
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarRequerimientoBienServicio(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
