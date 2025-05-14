using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
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

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ImprimirPorDireccionPresentador
    {
        private readonly IImprimirPorDireccionVista imprimirPorDireccionVista;
        private IRequerimientoBienServicioServicio requerimientoBienServicioServicio;
        private IGeneralServicio generalServicio;
        private IPeriodoServicio periodoServicio;
        public ImprimirPorDireccionPresentador(IImprimirPorDireccionVista imprimirPorDireccionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;

            this.imprimirPorDireccionVista = imprimirPorDireccionVista;
        } 

        public void Inicializar()
        {
            imprimirPorDireccionVista.listaReporte = PredeterminadoHelper.ListarTipoReportePorDireccion();
            imprimirPorDireccionVista.listaDirecciones = generalServicio.ListaDirecciones();
            imprimirPorDireccionVista.listaPeriodo = periodoServicio.ListaPeriodo();
        }

        public void RequerimientoPorDireccion()
        {
            if (imprimirPorDireccionVista.codReporte.Equals("02"))
            {
                List<RequerimientoBienServicioDetallePresExporta> lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDireccionExporta(imprimirPorDireccionVista.idDireccion, imprimirPorDireccionVista.anio);
                ExportarRequerimientoDireccion(lista);
            }
            else if (imprimirPorDireccionVista.codReporte.Equals("03"))
            {
                List<RequerimientoBienServicioDetallePresExporta> lista = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(imprimirPorDireccionVista.idDireccion, imprimirPorDireccionVista.anio);
                ExportarRequerimientoDireccionArea(lista);
            }
            else if (imprimirPorDireccionVista.codReporte.Equals("04"))
            {
                List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> lista = requerimientoBienServicioServicio.TraerReporteRequerimientoBienServicioDireccionAreaExporta(imprimirPorDireccionVista.idDireccion, imprimirPorDireccionVista.anio, "ERR");
                ExportarReporteRequerimientoBienServicioDireccionArea(lista);
            }
            else
            {
                ImprimirRequerimiento();
            }
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

        private void ExportarRequerimientoDireccionArea(List<RequerimientoBienServicioDetallePresExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarRequerimientosArea(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        private void ExportarReporteRequerimientoBienServicioDireccionArea(List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarRequerimientoBienServicioDireccionAreaExporta(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        public void ImprimirRequerimiento()
        {

                List<RequerimientoBienServicioDetallePres> comp = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalleDireccion(imprimirPorDireccionVista.idDireccion, null, imprimirPorDireccionVista.anio, 63);
                rptRequerimientoBienServicioDireccion reporte = new rptRequerimientoBienServicioDireccion();
                //string titulo = "COMPROBANTE DE INGRESO";

                ReporteWinForDev frm = new ReporteWinForDev();
                List<ParametrosReporte> p = new List<ParametrosReporte>();
                frm.report = reporte;
                frm.datosReporte = comp;
                frm.listaParametros = p;
                frm.AbrirDocumento(true, false);
            
        }
        private void ExportarRequerimientoBienServicioDireccionAreaExporta(List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "RequerimientoBienSerFormatoII_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarRequerimientoBienServicioDireccionAreaExporta(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
