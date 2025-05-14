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
    public class ImprimirEjecucionSubpresupuestoPresentador
    {
        private readonly IImprimirEjecucionSubpresupuestoVista imprimirEjecucionSubpresupuestoVista;
        private IGrupoPresupuestoServicio grupoServicio;
        private IProgramacionAnualServicio presupuestoServicio;
        private IEvaluacionMensualProgramacionServicio evaluacionServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;
        private IGeneralServicio generalServicio;

        public ImprimirEjecucionSubpresupuestoPresentador(IImprimirEjecucionSubpresupuestoVista imprimirEjecucionSubpresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.evaluacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.imprimirEjecucionSubpresupuestoVista = imprimirEjecucionSubpresupuestoVista;
        } 

        public void Inicializar()
        {
            imprimirEjecucionSubpresupuestoVista.listaGrupoPresupuesto = grupoServicio.TraerListaGrupoPresupuesto();
            imprimirEjecucionSubpresupuestoVista.listaMoneda = generalServicio.ListaMonedas();
        }

        public void CargarPresupuesto()
        {
            imprimirEjecucionSubpresupuestoVista.listaProgramacion = presupuestoServicio.listarTodosPorGrupoPresupuesto(imprimirEjecucionSubpresupuestoVista.idGruPre);
        }

        public void CargarSubpresupuesto()
        {
            imprimirEjecucionSubpresupuestoVista.listaSubpresupuesto = subpresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(imprimirEjecucionSubpresupuestoVista.idPresupuesto);
        }

        public void ImprimirReporte()
        {
            ImprimirRequerimiento();
        }

        public void ImprimirRequerimiento()
        {

            List<FondoEjecutadosSubpresupuesto> comp = evaluacionServicio
            .TraerFondoEjecutadosSubpresupuesto(imprimirEjecucionSubpresupuestoVista.idMoneda, imprimirEjecucionSubpresupuestoVista.idGruPre, imprimirEjecucionSubpresupuestoVista.idPresupuesto, imprimirEjecucionSubpresupuestoVista.idSubpresupuesto);
            rptFondoEjecutadosSubpresupuesto reporte = new rptFondoEjecutadosSubpresupuesto();
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
