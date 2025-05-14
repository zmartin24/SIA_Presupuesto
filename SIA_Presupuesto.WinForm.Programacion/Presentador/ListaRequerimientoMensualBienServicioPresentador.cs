using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
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
    public class ListaRequerimientoMensualBienServicioPresentador
    {
        private readonly IListaRequerimientoMensualBienServicioVista listaRequerimientoMensualBienServicioVista;
        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        private IPeriodoServicio periodoServicio;

        private bool listarTodos = true;
        public ListaRequerimientoMensualBienServicioPresentador(IListaRequerimientoMensualBienServicioVista listaRequerimientoMensualBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;
            this.listaRequerimientoMensualBienServicioVista = listaRequerimientoMensualBienServicioVista;
        }

        public void Iniciar()
        {
            listaRequerimientoMensualBienServicioVista.listaAnio = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            listaRequerimientoMensualBienServicioVista.listaMes = UtilitarioComun.ListarMeses();

            //listaReajusteMensualPresupuestoVista.anioPresentacion = DateTime.Now.Date.Year;
            listaRequerimientoMensualBienServicioVista.anio = this.periodoServicio.ObtenerActivo().anio; //DateTime.Now.Date.AddYears(1).Year;
            listaRequerimientoMensualBienServicioVista.mes = DateTime.Now.Date.Month;
        }

        public void ObtenerDatosListado()
        {
            listaRequerimientoMensualBienServicioVista.listaSplash = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualBienServicioVista.anio, this.listaRequerimientoMensualBienServicioVista.mes, this.listaRequerimientoMensualBienServicioVista.UsuarioOperacion.IDUsuario, null, listarTodos);
        }

        public RequerimientoMensualBienServicio Buscar(int id)
        {
            return requerimientoMensualBienServicioServicio.BuscarPorCodigo(id);
        }
        
        public bool AsignarEstadoRequerimiento(RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres, int estado )
        {
            Resultado resultado = null;
            RequerimientoMensualBienServicio req = Buscar((Int32)requerimientoMensualBienServicioPres.idReqMenBieSer);
            switch (estado)
            {
                case Estados.Aprobado:
                    req.fechaAprobacion = DateTime.Now;
                    req.estado = Estados.Aprobado;
                    break;
                case Estados.Activo:
                    req.fechaAprobacion = null;
                    req.estado = Estados.Activo;
                    break;
            }
            
            resultado = requerimientoMensualBienServicioServicio.ModificarSinClonar(req);

            return resultado.esCorrecto;
        }

        public List<RequerimientoMensualDetalle> TraerListarDetallesTodos(int idReqMenBieSer)
        {
            return this.requerimientoMensualBienServicioServicio.TraerListarDetallesTodos(idReqMenBieSer);
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


        //public bool AnularRegistro()
        //{
        //    return requerimientoMensualBienServicioServicio.Anular(this.listaRequerimientoMensualBienServicioVista.requerimientoMensualBienServicio, listaRequerimientoMensualBienServicioVista.UsuarioOperacion.NomUsuario).esCorrecto;
        //}

        public void ImprimirRequerimiento()
        {
            //if (listaRequerimientoMensualBienServicioVista.RequerimientoBienServicio != null)
            //{
            //    List<RequerimientoBienServicioDetallePres> comp = requerimientoMensualBienServicioServicio.TraerListaRequerimientoBienServicioDetalle(listaRequerimientoMensualBienServicioVista.RequerimientoBienServicio.idReqBieSer);
            //    rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();
            //    //string titulo = "COMPROBANTE DE INGRESO";

            //    ReporteWinForDev frm = new ReporteWinForDev();
            //    List<ParametrosReporte> p = new List<ParametrosReporte>();
            //    frm.report = reporte;
            //    frm.datosReporte = comp;
            //    frm.listaParametros = p;
            //    frm.AbrirDocumento(true, false);
            //}
        }


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

        //public void ExportarRequerimiento()
        //{
        //    List<ReporteRequerimientoBienServicioExportaPres> lista = requerimientoMensualBienServicioServicio.TraerReporteRequerimientoBienServicioExporta(listaRequerimientoMensualBienServicioVista.RequerimientoBienServicio.idReqBieSer);
        //    using (SaveFileDialog sfd = new SaveFileDialog())
        //    {
        //        sfd.Filter = "Excel XLSX|*.xlsx";
        //        sfd.Title = "Guardar el siguiente archivo";

        //        string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

        //        ExportarProHelper.ExportarRequerimientoBienServicio(ruta, lista);
        //        ExportarHelper.AbrirArchivoExcel(ruta);
        //    }
        //}
    }
}
