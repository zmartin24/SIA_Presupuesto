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
    public class ImprimirPacPresentador
    {
        private readonly IImprimirPacVista imprimirPacVista;
        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGeneralServicio generalServicio;
        PlanAnualAdquisicion planAnualAdquisicion;

        public ImprimirPacPresentador(PlanAnualAdquisicion planAnualAdquisicion, IImprimirPacVista imprimirPacVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.imprimirPacVista = imprimirPacVista;
            this.planAnualAdquisicion = planAnualAdquisicion;
        } 

        public void Inicializar()
        {
            var listaReporte = PredeterminadoHelper.ListarTipoReportePac();
            if (listaReporte != null)
            {
                imprimirPacVista.listaReporte = listaReporte;
                imprimirPacVista.codReporte = listaReporte.FirstOrDefault().codigo;
            }

            var listaDirecciones = generalServicio.ListaDirecciones();
            if (listaDirecciones != null)
            {
                listaDirecciones.Add(new Direccion { idDireccion = 0, desDireccion = "[TODOS]" });
                imprimirPacVista.listaDirecciones = listaDirecciones.OrderBy(x => x.idDireccion).ToList();
                imprimirPacVista.idDireccion = listaDirecciones.OrderBy(x=>x.idDireccion).FirstOrDefault().idDireccion;
            }

            var listaFueFin = generalServicio.ListaFuenteFinanciamiento().Where(x => x.anio == this.planAnualAdquisicion.anio).ToList();
            if (listaFueFin != null)
            {
                listaFueFin.Add(new FuenteFinanciamiento { idFueFin = 0, fuente = "[TODOS]" });
                imprimirPacVista.listaFinanciamiento = listaFueFin.OrderBy(x => x.idFueFin).ToList();
                imprimirPacVista.idFueFin = listaFueFin.OrderBy(x=>x.idFueFin).FirstOrDefault().idFueFin;
            }
        }

        public List<object> ListaReporte()
        {
            List<object> lista = null;
            switch (this.imprimirPacVista.codReporte)
            {
                case "01":
                    lista = planAnualAdquisicionServicio.TraerReportePlanAnualAdquisicionDetalle(this.planAnualAdquisicion.idPaa, this.imprimirPacVista.idFueFin).ToList<object>();
                    break;
                //case "02":
                //    lista = planAnualAdquisicionServicio.TraerReportePlanAnualAdquisicionDireccion(this.planAnualAdquisicion.idPaa, 0, 0).ToList<object>();
                //    break;
                case "02":
                    lista = planAnualAdquisicionServicio.TraerReportePlanAnualAdquisicionDireccion(this.planAnualAdquisicion.idPaa, this.imprimirPacVista.idDireccion, this.imprimirPacVista.idFueFin).ToList<object>();
                    break;
            }

            return lista;
        }
        public void Imprimir(List<object> vlista)
        {
            XtraReport reporte = new XtraReport();

            switch (this.imprimirPacVista.codReporte)
            {
                case "01":
                    reporte = new rptPlanAnualAdquisicionDet();
                    break;
                //case "02":
                case "02":
                    reporte = new rptPACDireccionFueFin();//new rptPlanAnualAdquisicionDireccion();
                    break;
            }


            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = reporte;
            frm.datosReporte = vlista;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);

        }
    }
}
