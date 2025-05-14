using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaPresupuestoFasesPresentador
    {
        private readonly IListaPresupuestoFasesVista listaPresupuestoFasesVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
      
        private List<ReportePresupuestoFasesPres> listaReporte;
        public ListaPresupuestoFasesPresentador(IListaPresupuestoFasesVista listaPresupuestoFasesVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.listaPresupuestoFasesVista = listaPresupuestoFasesVista;
            this.listaReporte = new List<ReportePresupuestoFasesPres>();
        }
        public void IniciarDatos()
        {
            DateTime hoy = DateTime.Now.Date;
            var listaAnio = PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                this.listaPresupuestoFasesVista.listaAnio = listaAnio;
                this.listaPresupuestoFasesVista.vanio = hoy.Year;
            }

            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMoneda != null)
            {
                this.listaPresupuestoFasesVista.listaMoneda = listaMoneda;
                this.listaPresupuestoFasesVista.idMoneda = 63;
            }
            this.listaPresupuestoFasesVista.fechaIni = new DateTime(hoy.Year,hoy.Month,1);
            this.listaPresupuestoFasesVista.fechaFin = hoy;
        }
        public void llenarGrid()
        {
            List<ReportePresupuestoFasesPres> lista = new List<ReportePresupuestoFasesPres>();
            List<ReportePresupuestoFasesPres> listaSubCuenta = new List<ReportePresupuestoFasesPres>();
            List<ReportePresupuestoFasesPres> listaEspecifica = new List<ReportePresupuestoFasesPres>();

            
            listaReporte = generalReporteServicio.TraerReportePresupuestoFases(
                                                                    this.listaPresupuestoFasesVista.vanio, this.listaPresupuestoFasesVista.idMoneda,
                                                                    this.listaPresupuestoFasesVista.fechaIni, this.listaPresupuestoFasesVista.fechaFin,
                                                                    this.listaPresupuestoFasesVista.idPresupuesto, this.listaPresupuestoFasesVista.nivelPresupuesto);

            lista = listaReporte.Where(x => x.nivel == 1).ToList();
            listaSubCuenta = listaReporte.Where(x => x.nivel == 2).ToList();
            listaEspecifica = listaReporte.Where(x => x.nivel == 3).ToList();

            listaSubCuenta.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.dependencia == f.idCueCon));
            lista.ForEach(f => f.ListaSubCuenta = listaSubCuenta.FindAll(t => t.dependencia == f.idCueCon));

            
            this.listaPresupuestoFasesVista.listaReportePresupuestoFasesPres = listaReporte;
            this.listaPresupuestoFasesVista.listaSplash = lista;

        }
        public void Limpiar()
        {
            this.listaPresupuestoFasesVista.GrupoPresupuesto = null;
            this.listaPresupuestoFasesVista.Presupuesto = null;
            this.listaPresupuestoFasesVista.Subpresupuesto = null;
            this.listaPresupuestoFasesVista.nivelPresupuesto = 0;
            this.listaPresupuestoFasesVista.idPresupuesto = 0;
            this.listaPresupuestoFasesVista.listaSplash = null;
        }
    }
}
