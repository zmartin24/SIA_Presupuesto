using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaRequerimientoRecursoHumanoPresentador
    {
        private readonly IListaRequerimientoRecursoHumanoVista listaRequerimientoRecursoHumanoVista;
        private IRequerimientoRecursoHumanoServicio requerimientoRecursoHumanoServicio;

        public ListaRequerimientoRecursoHumanoPresentador(IListaRequerimientoRecursoHumanoVista listaRequerimientoRecursoHumanoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoRecursoHumanoServicio = _Contenedor.Resolver(typeof(IRequerimientoRecursoHumanoServicio)) as IRequerimientoRecursoHumanoServicio;

            this.listaRequerimientoRecursoHumanoVista = listaRequerimientoRecursoHumanoVista;
        }

        public void Iniciar()
        {
            listaRequerimientoRecursoHumanoVista.listaAnios = PredeterminadoHelper.ListaAnio();

            listaRequerimientoRecursoHumanoVista.anio = DateTime.Now.Date.Year;
        }

        public void ObtenerDatosListado()
        {
            listaRequerimientoRecursoHumanoVista.listaDatosPrincipales = requerimientoRecursoHumanoServicio.TraerListaRequerimientoRecursoHumano(listaRequerimientoRecursoHumanoVista.anio, listaRequerimientoRecursoHumanoVista.UsuarioOperacion.IDUsuario);
        }

        public RequerimientoRecursoHumano Buscar(int id)
        {
            return this.requerimientoRecursoHumanoServicio.BuscarPorCodigo(id);
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
            return requerimientoRecursoHumanoServicio.Anular(listaRequerimientoRecursoHumanoVista.requerimientoRecursoHumano, listaRequerimientoRecursoHumanoVista.UsuarioOperacion.NomUsuario).esCorrecto;
        }

        public void ExportarRequerimientoPorDireccion()
        {
            //List<ProgramacionAnualAreaExporta> lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDireccionExporta(listaRequerimientoBienServicioVista.RequerimientoBienServicio.idProAnu);
            //ExportarProgramacionAnual(lista);
        }

        //public void ImprimirRequerimiento()
        //{
        //    if (listaRequerimientoRecursoHumanoVista.RequerimientoBienServicio != null)
        //    {
        //        List<RequerimientoBienServicioDetallePres> comp = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalle(listaRequerimientoRecursoHumanoVista.RequerimientoBienServicio.idReqBieSer);
        //        rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();
        //        //string titulo = "COMPROBANTE DE INGRESO";

        //        ReporteWinForDev frm = new ReporteWinForDev();
        //        List<ParametrosReporte> p = new List<ParametrosReporte>();
        //        frm.report = reporte;
        //        frm.datosReporte = comp;
        //        frm.listaParametros = p;
        //        frm.AbrirDocumento(true, false);
        //    }
        //}


        //private void ExportarProgramacionAnual(List<ProgramacionAnualAreaExporta> lista)
        //{
        //    using (SaveFileDialog sfd = new SaveFileDialog())
        //    {
        //        sfd.Filter = "Excel XLSX|*.xlsx";
        //        sfd.Title = "Guardar el siguiente archivo";

        //        string ruta = Path.GetTempPath() + "ProgramacionAnual_" + Path.GetRandomFileName() + ".xlsx";

        //        ExportarProHelper.ExportarProgramacionAnual(ruta, lista);
        //        ExportarHelper.AbrirArchivoExcel(ruta);
        //    }
        //}
    }
}
