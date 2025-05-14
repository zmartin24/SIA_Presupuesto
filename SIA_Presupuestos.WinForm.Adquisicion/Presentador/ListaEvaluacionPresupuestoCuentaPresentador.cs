using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaEvaluacionPresupuestoCuentaPresentador
    {
        private readonly IListaEvaluacionPresupuestoCuentaVista listaEvaluacionPresupuestoCuentaVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        List<ReporteEvaluacionPresupuestoPorCuentasPres> lista;
        public ListaEvaluacionPresupuestoCuentaPresentador(IListaEvaluacionPresupuestoCuentaVista listaEvaluacionPresupuestoCuentaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            //this.evaluacionPresupuestoCuentaServicio = _Contenedor.Resolver(typeof(IEvaluacionPresupuestoCuentaServicio)) as IEvaluacionPresupuestoCuentaServicio;
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.listaEvaluacionPresupuestoCuentaVista = listaEvaluacionPresupuestoCuentaVista;
            this.lista = new List<ReporteEvaluacionPresupuestoPorCuentasPres>();
        }
        public void IniciarDatos()
        {
            var listaAnio = PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                listaEvaluacionPresupuestoCuentaVista.listaAnio = listaAnio;
                listaEvaluacionPresupuestoCuentaVista.anio = DateTime.Now.Year;
            }
            var listaMonedas = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMonedas != null)
            {
                listaEvaluacionPresupuestoCuentaVista.listaMonedas = listaMonedas;
                listaEvaluacionPresupuestoCuentaVista.idMoneda = (Int32)listaMonedas.FirstOrDefault().idMoneda;
            }
        }
        public void llenarGrid()
        {
            lista = generalReporteServicio.TraerReporteEvaluacionPresupuestoPorCuentas(this.listaEvaluacionPresupuestoCuentaVista.idMoneda, this.listaEvaluacionPresupuestoCuentaVista.anio, this.listaEvaluacionPresupuestoCuentaVista.idPresupuesto, listaEvaluacionPresupuestoCuentaVista.nivelPresupuesto);
            this.listaEvaluacionPresupuestoCuentaVista.listaSplash = lista;
        }

        public void Limpiar()
        {
            this.listaEvaluacionPresupuestoCuentaVista.GrupoPresupuesto = null;
            this.listaEvaluacionPresupuestoCuentaVista.Presupuesto = null;
            this.listaEvaluacionPresupuestoCuentaVista.Subpresupuesto = null;
            this.listaEvaluacionPresupuestoCuentaVista.nivelPresupuesto = 0;
            this.listaEvaluacionPresupuestoCuentaVista.idPresupuesto = 0;
            this.listaEvaluacionPresupuestoCuentaVista.listaSplash = null;
        }
        public void ExportarEvaluacionPresupuestoPorCuentas()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "EvaluacionPorCuenta_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarHelperAdquisicion.ExportarEvaluacionPresupuestoPorCuentas(ruta, lista.OrderBy(o => o.numCuenta).ToList(), listaEvaluacionPresupuestoCuentaVista.idMoneda, listaEvaluacionPresupuestoCuentaVista.Presupuesto != null ? listaEvaluacionPresupuestoCuentaVista.Presupuesto.descripcion : listaEvaluacionPresupuestoCuentaVista.GrupoPresupuesto.descripcion, listaEvaluacionPresupuestoCuentaVista.Subpresupuesto != null ? listaEvaluacionPresupuestoCuentaVista.Subpresupuesto.descripcion : string.Empty);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
