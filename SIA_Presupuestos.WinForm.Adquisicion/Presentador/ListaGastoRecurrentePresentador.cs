using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaGastoRecurrentePresentador
    {
        private readonly IListaGastoRecurrenteVista listaGastoRecurrenteVista;
        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        public ListaGastoRecurrentePresentador(IListaGastoRecurrenteVista listaGastoRecurrenteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;

            this.listaGastoRecurrenteVista = listaGastoRecurrenteVista;
        }

        public void ObtenerDatosListado()
        {
            listaGastoRecurrenteVista.listaDatosPrincipales = gastoRecurrenteServicio.listarTodosActivos();
        }

        public GastoRecurrente Buscar(int vidGasRec)
        {
            return gastoRecurrenteServicio.Buscar(vidGasRec);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaGastoRecurrenteVista.gastoRecurrente != null)
                respuesta = this.gastoRecurrenteServicio.Anular(listaGastoRecurrenteVista.gastoRecurrente, listaGastoRecurrenteVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        public bool ActulizarDetalles()
        {
            bool respuesta = false;
            respuesta = gastoRecurrenteServicio.ActualizarDetallesGastoRecurrente(listaGastoRecurrenteVista.gastoRecurrente.idGasRec, listaGastoRecurrenteVista.UsuarioOperacion.NomUsuario);

            return respuesta;
        }
        public void ImprimirPlanAnualAdquisicion()
        {
            //if (listaGastoRecurrenteVista.gastoRecurrente != null)
            //{
            //    List<ReportePlanAnualAdquisicionDetallePres> comp = gastoRecurrenteServicio.TraerReportePlanAnualAdquisicionDetalle((Int32)listaGastoRecurrenteVista.gastoRecurrente.idGasRec);
            //    rptPlanAnualAdquisicionDet reporte = new rptPlanAnualAdquisicionDet();

            //    ReporteWinForDev frm = new ReporteWinForDev();
            //    List<ParametrosReporte> p = new List<ParametrosReporte>();
            //    frm.report = reporte;
            //    frm.datosReporte = comp;
            //    frm.listaParametros = p;
            //    frm.AbrirDocumento(true, false);
            //}
        }
    }
}
