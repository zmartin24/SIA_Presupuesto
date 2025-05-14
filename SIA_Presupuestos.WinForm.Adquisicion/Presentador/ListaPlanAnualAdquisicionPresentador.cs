using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaPlanAnualAdquisicionPresentador
    {
        private readonly IListaPlanAnualAdquisicionVista listaPlanAnualAdquisicionVista;
        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        public ListaPlanAnualAdquisicionPresentador(IListaPlanAnualAdquisicionVista listaPlanAnualAdquisicionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.listaPlanAnualAdquisicionVista = listaPlanAnualAdquisicionVista;
        }

        public void ObtenerDatosListado()
        {
            listaPlanAnualAdquisicionVista.listaDatosPrincipales = planAnualAdquisicionServicio.listarTodosActivos();
        }

        public PlanAnualAdquisicion Buscar(int vidPlaa)
        {
            return planAnualAdquisicionServicio.Buscar(vidPlaa);
        }

        public bool RegistrarDetalles()
        {
            Resultado respuesta = null;
            listaPlanAnualAdquisicionVista.planAnualAdquisicion.usuCrea = listaPlanAnualAdquisicionVista.UsuarioOperacion.NomUsuario;
            respuesta = planAnualAdquisicionServicio.NuevoDetalleMasivo(listaPlanAnualAdquisicionVista.planAnualAdquisicion, true);

            return respuesta.esCorrecto;
        }
        public bool ActulizarDetalles()
        {
            bool respuesta = false;
            listaPlanAnualAdquisicionVista.planAnualAdquisicion.usuCrea = listaPlanAnualAdquisicionVista.UsuarioOperacion.NomUsuario;
            respuesta = planAnualAdquisicionServicio.ActualizarDetallesPac(listaPlanAnualAdquisicionVista.planAnualAdquisicion.idPaa, listaPlanAnualAdquisicionVista.UsuarioOperacion.NomUsuario);

            return respuesta;
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaPlanAnualAdquisicionVista.planAnualAdquisicion != null)
                respuesta = this.planAnualAdquisicionServicio.Anular(listaPlanAnualAdquisicionVista.planAnualAdquisicion, listaPlanAnualAdquisicionVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        public void ImprimirPlanAnualAdquisicion()
        {
            if (listaPlanAnualAdquisicionVista.planAnualAdquisicion != null)
            {
                List<ReportePlanAnualAdquisicionDetallePres> comp = planAnualAdquisicionServicio.TraerReportePlanAnualAdquisicionDetalle((Int32)listaPlanAnualAdquisicionVista.planAnualAdquisicion.idPaa, 0);
                rptPlanAnualAdquisicionDet reporte = new rptPlanAnualAdquisicionDet();

                ReporteWinForDev frm = new ReporteWinForDev();
                List<ParametrosReporte> p = new List<ParametrosReporte>();
                frm.report = reporte;
                frm.datosReporte = comp;
                frm.listaParametros = p;
                frm.AbrirDocumento(true, false);
            }
        }
        public void ExportarPAC()
        {
            List<ReportePlanAnualAdquisicionExportaPres> lista = planAnualAdquisicionServicio.TraerReportePlanAnualAdquisicionExporta(this.listaPlanAnualAdquisicionVista.planAnualAdquisicion.idPaa, 0, 0);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PAC_" + Path.GetRandomFileName() + ".xlsx";

                ExportarHelperAdquisicion.ExportarPAC(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
