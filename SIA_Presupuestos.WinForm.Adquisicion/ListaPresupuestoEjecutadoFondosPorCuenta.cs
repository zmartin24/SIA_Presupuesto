using System;
using System.Collections.Generic;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaPresupuestoEjecutadoFondosPorCuenta : ControlBase, IListaPresupuestoEjecutadoFondosPorCuentaVista
    {
        private ListaPresupuestoEjecutadoFondosPorCuentaPresentador listaPresupuestoEjecutadoFondosPresentador;

        public List<ReportePresupuestoEjecutadoFondosPres> listaDatosPrincipales
        {
            set
            {
                pivotGridControl1.DataSource = value;
            }
        }
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Año", value);
            }
        }
        
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public List<CuentaContable> listaCuentaContables
        {
            set
            {
                glueCuentaContable.Properties.DisplayMember = "numCuenta";
                glueCuentaContable.Properties.ValueMember = "numCuenta";
                glueCuentaContable.Properties.NullText = string.Empty;
                glueCuentaContable.Properties.DataSource = value;
            }
        }

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 63; }
        }
        public string numCueCon
        {
            set { glueCuentaContable.EditValue = value; }
            get { return glueCuentaContable.Text; }
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return lueMes.EditValue!= null ? (Int32)lueMes.EditValue : DateTime.Now.Month; }
        }
        public int vanio
        {
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : DateTime.Now.Year; }
            set { lueAnio.EditValue = value; }
        }

        public bool inicio = false;
        
        public ListaPresupuestoEjecutadoFondosPorCuenta()
        {
            InitializeComponent();
            this.listaPresupuestoEjecutadoFondosPresentador = new ListaPresupuestoEjecutadoFondosPorCuentaPresentador(this);
            Text = "Reporte de Ejecución de Presupuesto por Fondos y cuentas contables";
        }
        
        protected override DevExpress.XtraPivotGrid.PivotGridControl PivotGridPrincipal { get { return pivotGridControl1; } }
        protected override bool ExportarDePivot { get { return true; } }
        protected override void InicializarDatos()
        {
            this.listaPresupuestoEjecutadoFondosPresentador.IniciarDatos();
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }

        protected override void EjecutarCargarConSplash()
        {
            if (glueCuentaContable.EditValue != null && lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null)
            {
                this.listaPresupuestoEjecutadoFondosPresentador.llenarGridPivot();
                inicio = true;
            }
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (glueCuentaContable.EditValue != null && lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
                LlenarGrid();
        }

        private void lueMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (glueCuentaContable.EditValue != null && lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
                LlenarGrid();
        }

        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            if (glueCuentaContable.EditValue != null && lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
                LlenarGrid();
        }

        private void glueCuentaContable_EditValueChanged(object sender, EventArgs e)
        {
            if (glueCuentaContable.EditValue!=null && lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
                LlenarGrid();
        }
    }
}
