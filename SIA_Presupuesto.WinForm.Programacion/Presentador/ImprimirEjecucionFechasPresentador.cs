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

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ImprimirEjecucionFechasPresentador
    {
        private readonly IImprimirEjecucionFechasVista imprimirEjecucionFechasVista;
        private IGrupoPresupuestoServicio grupoServicio;
        private IProgramacionAnualServicio presupuestoServicio;
        private IEvaluacionMensualProgramacionServicio evaluacionServicio;

        public ImprimirEjecucionFechasPresentador(IImprimirEjecucionFechasVista imprimirEjecucionFechasVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.evaluacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;

            this.imprimirEjecucionFechasVista = imprimirEjecucionFechasVista;
        } 

        public void Inicializar()
        {
            imprimirEjecucionFechasVista.listaGrupoPresupuesto = grupoServicio.TraerListaGrupoPresupuesto();
            
        }

        public void CargarPresupuesto()
        {
            imprimirEjecucionFechasVista.listaProgramacion = presupuestoServicio.listarTodosPorGrupoPresupuesto(imprimirEjecucionFechasVista.idGruPre);
        }

        public void ImprimirReporte()
        {
            ImprimirRequerimiento();
        }

        public void ImprimirRequerimiento()
        {

            List<FondoEjecutadoFecha> comp = evaluacionServicio
            .TraerFondoEjecutadosFechas(imprimirEjecucionFechasVista.idMoneda, imprimirEjecucionFechasVista.idGruPre, imprimirEjecucionFechasVista.idPresupuesto, imprimirEjecucionFechasVista.fechaDesde, imprimirEjecucionFechasVista.fechaHasta);
            rptFondoEjecutadoPorFechaPresu reporte = new rptFondoEjecutadoPorFechaPresu();
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
