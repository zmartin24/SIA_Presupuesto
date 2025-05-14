using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
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
    public class ListaPresupuestoAproComPresentador
    {
        private readonly IListaPresupuestoAproComVista listaPresupuestoAproComVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> lista;
        public ListaPresupuestoAproComPresentador(IListaPresupuestoAproComVista listaPresupuestoAproComVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.listaPresupuestoAproComVista = listaPresupuestoAproComVista;
            this.lista = new List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>();
        }
        public void IniciarDatos()
        {
            var listaMonedas = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMonedas != null)
            {
                listaPresupuestoAproComVista.listaMonedas = listaMonedas;
                listaPresupuestoAproComVista.idMoneda = (Int32)listaMonedas.FirstOrDefault().idMoneda;
            }
        }
        public void llenarGrid()
        {
            lista = generalReporteServicio.TraerReportePresupuestoAprobadoComprometidoEjecutado(listaPresupuestoAproComVista.idMoneda, listaPresupuestoAproComVista.Subpresupuesto.idSubpresupuesto);
            this.listaPresupuestoAproComVista.listaSplash = lista;
        }

        public void Limpiar()
        {
            this.listaPresupuestoAproComVista.GrupoPresupuesto = null;
            this.listaPresupuestoAproComVista.Presupuesto = null;
            this.listaPresupuestoAproComVista.Subpresupuesto = null;

        }
        public void ExportarPresupuesto()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PresupuestoAprobadoComprometidoEjecutado_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";

                ExportarHelperAdquisicion.ExportarPresupuestoAprobadoComprometidoEjecutado(ruta, lista.OrderBy(o => o.numCuenta).ToList(), listaPresupuestoAproComVista.idMoneda, listaPresupuestoAproComVista.Presupuesto.descripcion, listaPresupuestoAproComVista.Subpresupuesto.descripcion);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
