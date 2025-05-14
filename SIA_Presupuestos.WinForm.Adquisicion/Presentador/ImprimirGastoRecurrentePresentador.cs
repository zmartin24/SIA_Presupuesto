using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using DevExpress.XtraReports.UI;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ImprimirGastoRecurrentePresentador
    {
        private readonly IImprimirGastoRecurrenteVista imprimirGastoRecurrenteVista;
        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;
        GastoRecurrente gastoRecurrente;
        int vidDireccion = 0;
        public ImprimirGastoRecurrentePresentador(GastoRecurrente gastoRecurrente, IImprimirGastoRecurrenteVista imprimirGastoRecurrenteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.imprimirGastoRecurrenteVista = imprimirGastoRecurrenteVista;
            this.gastoRecurrente = gastoRecurrente;
        } 

        public void Inicializar()
        {
            var listaReporte = PredeterminadoHelper.ListarTipoReportePorDireccionGastoRecurrente();
            if (listaReporte != null)
            {
                imprimirGastoRecurrenteVista.listaReporte = listaReporte;
                imprimirGastoRecurrenteVista.codReporte = listaReporte.FirstOrDefault().codigo;
            }

            var listaDirecciones = generalServicio.ListaDirecciones();
            if (listaDirecciones != null)
            {
                imprimirGastoRecurrenteVista.listaDirecciones = listaDirecciones;
                imprimirGastoRecurrenteVista.idDireccion = listaDirecciones.FirstOrDefault().idDireccion;
            }
        }

        public void RequerimientoPorDireccion()
        {
            if (imprimirGastoRecurrenteVista.codReporte.Equals("01"))
            {
                vidDireccion = 0;
                ImprimirGastoRecurrente();
            }
            else
            {
                vidDireccion = this.imprimirGastoRecurrenteVista.idDireccion;
                ImprimirGastoRecurrente();
            }
        }

        private void ExportarRequerimientoDireccion(List<RequerimientoBienServicioDetallePresExporta> lista)
        {
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //{
            //    sfd.Filter = "Excel XLSX|*.xlsx";
            //    sfd.Title = "Guardar el siguiente archivo";

            //    string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

            //    ExportarProHelper.ExportarRequerimientos(ruta, lista);
            //    ExportarHelper.AbrirArchivoExcel(ruta);
            //}
        }

        public void ImprimirGastoRecurrente()
        {
            XtraReport reporte;
            List<ReporteGastoRecurrenteDetalleDireccionPres> comp = gastoRecurrenteServicio.TraerReporteGastoRecurrenteDetalleDireccion(this.gastoRecurrente.idGasRec, vidDireccion);
            if (vidDireccion > 0)
            {
                reporte = new rptGastoRecurrenteDireccion();
               
            }
            else
            {
                reporte = new rptGastoRecurrenteGeneral();
            }
            
            
               
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = reporte;
            frm.datosReporte = comp;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
            
        }
    }
}
