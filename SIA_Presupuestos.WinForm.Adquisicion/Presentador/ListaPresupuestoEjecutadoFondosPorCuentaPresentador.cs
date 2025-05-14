using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaPresupuestoEjecutadoFondosPorCuentaPresentador
    {
        private readonly IListaPresupuestoEjecutadoFondosPorCuentaVista listaPresupuestoEjecutadoFondosVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private List<ReporteEvaluacionDetalladaBienSerExportaPres> listaReporteExporta;
        public ListaPresupuestoEjecutadoFondosPorCuentaPresentador(IListaPresupuestoEjecutadoFondosPorCuentaVista listaPresupuestoEjecutadoFondosVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.listaPresupuestoEjecutadoFondosVista = listaPresupuestoEjecutadoFondosVista;
            this.listaReporteExporta = new List<ReporteEvaluacionDetalladaBienSerExportaPres>();
        }
        public void IniciarDatos()
        {
            var listaAnio = PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaAnio = listaAnio;
                this.listaPresupuestoEjecutadoFondosVista.vanio = DateTime.Now.Year;
            }

            var listaMes = UtilitarioComun.ListarMeses();
            if (listaMes != null && listaMes.Count > 0)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaMes = listaMes;
                this.listaPresupuestoEjecutadoFondosVista.mes = DateTime.Now.Month;
            }

            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMoneda != null)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaMoneda = listaMoneda;
                this.listaPresupuestoEjecutadoFondosVista.idMoneda = 63;
            }
            var listacuenta = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year);
            if (listacuenta != null)
            {
                listaPresupuestoEjecutadoFondosVista.listaCuentaContables = listacuenta; //año actual
                listaPresupuestoEjecutadoFondosVista.numCueCon = listacuenta.FirstOrDefault().numCuenta;
            }
        }
        public void llenarGridPivot()
        {
            this.listaPresupuestoEjecutadoFondosVista.listaSplash = generalReporteServicio.TraerReportePresupuestoEjecutadoFondos(this.listaPresupuestoEjecutadoFondosVista.idMoneda,
                                                                                                                                            this.listaPresupuestoEjecutadoFondosVista.vanio,1,
                                                                                                                                            this.listaPresupuestoEjecutadoFondosVista.mes, this.listaPresupuestoEjecutadoFondosVista.numCueCon
                                                                                                                                            );
        }

    }
}
