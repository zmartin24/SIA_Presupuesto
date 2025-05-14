using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
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
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ImprimirPorDireccionPresupuestoAnualPresentador
    {
        private readonly IImprimirPorDireccionPresupuestoAnualVista imprimirPorDireccionVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        public ImprimirPorDireccionPresupuestoAnualPresentador(IImprimirPorDireccionPresupuestoAnualVista imprimirPorDireccionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.imprimirPorDireccionVista = imprimirPorDireccionVista;
        } 

        public void Inicializar()
        {
            imprimirPorDireccionVista.listaDirecciones = generalServicio.ListaDirecciones();
            imprimirPorDireccionVista.listaReporte = PredeterminadoHelper.ListarTipoReportePorDireccionPresupuestoAnual();
            imprimirPorDireccionVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            imprimirPorDireccionVista.anioReporte = DateTime.Now.Year;
        }

        public void RequerimientoPorDireccion()
        {
            ImprimirRequerimiento();
        }


        public void ImprimirRequerimiento()
        {

                List<ResumenPresupuestoPorSubdireccion> comp = programacionAnualServicio.TraerResumenPresupuestoPorSubdirecciones(imprimirPorDireccionVista.anioReporte, imprimirPorDireccionVista.idDireccion);
                rptResumenPresPorSubdireccion reporte = new rptResumenPresPorSubdireccion();
                //string titulo = "COMPROBANTE DE INGRESO";

                ReporteWinForDev frm = new ReporteWinForDev();
                List<ParametrosReporte> p = new List<ParametrosReporte>();
                frm.report = reporte;
                frm.datosReporte = comp;
                frm.listaParametros = p;
                frm.AbrirDocumento(true, false);
            
        }
    }
}
