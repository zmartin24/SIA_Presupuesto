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
    public class ListaPrecioBienServicioPresentador
    {
        private readonly IListaPrecioBienServicioVista listaPrecioBienServicioVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private List<ReporteEvaluacionDetalladaBienSerExportaPres> listaReporteExporta;
        public ListaPrecioBienServicioPresentador(IListaPrecioBienServicioVista listaPrecioBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.listaPrecioBienServicioVista = listaPrecioBienServicioVista;
            this.listaReporteExporta = new List<ReporteEvaluacionDetalladaBienSerExportaPres>();
        }
        public void IniciarDatos()
        {
            var listaAnio = PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                this.listaPrecioBienServicioVista.listaAnio = listaAnio;
                this.listaPrecioBienServicioVista.vanio = DateTime.Now.Year;
            }

            var listaMes = UtilitarioComun.ListarMeses();
            if (listaMes != null && listaMes.Count > 0)
            {
                this.listaPrecioBienServicioVista.listaMes = listaMes;
                this.listaPrecioBienServicioVista.mes = DateTime.Now.Month;
            }

            var listaGrupoPresupuesto = grupoPresupuestoServicio.TraerListaGrupoPresupuesto();
            if (listaGrupoPresupuesto != null)
            {
                this.listaPrecioBienServicioVista.listaGrupoPresupuesto = listaGrupoPresupuesto;
                this.listaPrecioBienServicioVista.idGruPre = listaGrupoPresupuesto.OrderBy(x => x.idGruPre).FirstOrDefault().idGruPre;
            }

            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMoneda != null)
            {
                this.listaPrecioBienServicioVista.listaMoneda = listaMoneda;
                this.listaPrecioBienServicioVista.idMoneda = 63;
            }

        }
        public void llenarGridPivot()
        {
            this.listaPrecioBienServicioVista.listaSplash = generalReporteServicio.TraerListaPrecioBienServicioPorGruPre(this.listaPrecioBienServicioVista.idGruPre,
                                                                                                                                            this.listaPrecioBienServicioVista.vanio, 1,
                                                                                                                                            this.listaPrecioBienServicioVista.mes, this.listaPrecioBienServicioVista.idMoneda
                                                                                                                                            );
        }

    }
}
