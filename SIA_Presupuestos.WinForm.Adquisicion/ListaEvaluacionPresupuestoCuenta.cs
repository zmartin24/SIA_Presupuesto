using System;
using System.Collections.Generic;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;

using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Ayuda;
using DevExpress.XtraGrid.Views.Base;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaEvaluacionPresupuestoCuenta : ControlBase, IListaEvaluacionPresupuestoCuentaVista
    {
        private ListaEvaluacionPresupuestoCuentaPresentador listaEvaluacionPresupuestoCuentaPresentador;
        public List<ReporteEvaluacionPresupuestoPorCuentasPres> listaDatosPrincipales
        {
            set
            {
                grcEvaluacionPresupuestoCuenta.DataSource = value;
            }
        }
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Periodo", value);
            }
        }
        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
            }
        }
        
        public int anio
        {
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
            set { lueAnio.EditValue = value; }
        }
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }

        public int idPresupuesto { get; set; }
        public int nivelPresupuesto { get; set; }

        private GrupoPresupuesto grupoPresupuesto;
        private Presupuesto presupuesto;
        private Subpresupuesto subpresupuesto;

        public GrupoPresupuesto GrupoPresupuesto
        {
            get { return grupoPresupuesto; }
            set
            {
                grupoPresupuesto = value;
                if (value != null)
                {
                    txtGrupoPresupuesto.Text = value.descripcion;
                    nivelPresupuesto = 1;
                    idPresupuesto = grupoPresupuesto.idGruPre;
                }

                else
                {
                    txtGrupoPresupuesto.Text = string.Empty;
                }
            }
        }
        public Presupuesto Presupuesto
        {
            get { return presupuesto; }
            set
            {
                presupuesto = value;
                if (value != null)
                {
                    txtPresupuesto.Text = value.descripcion;
                    nivelPresupuesto = 2;
                    idPresupuesto = presupuesto.idPresupuesto;
                }
                else
                {
                    txtPresupuesto.Text = string.Empty;
                }
            }
        }
        public Subpresupuesto Subpresupuesto
        {
            get { return subpresupuesto; }
            set
            {
                subpresupuesto = value;
                if (value != null)
                {
                    txtSubPresupuesto.Text = value.descripcion;
                    nivelPresupuesto = 3;
                    idPresupuesto = subpresupuesto.idSubpresupuesto;
                }
                else
                {
                    txtSubPresupuesto.Text = string.Empty;
                }
            }
        }

        bool hacerCargar = false;

        public ListaEvaluacionPresupuestoCuenta()
        {
            InitializeComponent();
            this.listaEvaluacionPresupuestoCuentaPresentador = new ListaEvaluacionPresupuestoCuentaPresentador(this);
            Text = "Evaluación de Presupuesto por Cuentas";
            hacerCargar = false;
        }

        protected override ColumnView ColumnaActual { get { return grcEvaluacionPresupuestoCuenta.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcEvaluacionPresupuestoCuenta; } }
        protected ColumnView ColumnaActual1 { get { return grcEvaluacionPresupuestoCuenta.ViewCollection[2] as ColumnView; } }

        protected override void InicializarDatos()
        {
            this.listaEvaluacionPresupuestoCuentaPresentador.IniciarDatos();
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }
        protected override void EjecutarCargarConSplash()
        {
            if(hacerCargar)
                this.listaEvaluacionPresupuestoCuentaPresentador.llenarGrid();
            hacerCargar = true;
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "ExportaEvaDet": ExportarEvaluacionCuentas(); break;
            }
        }

        private void sbAyudaGrupoPresupuesto_Click(object sender, EventArgs e)
        {
            AbrirAyudaPresupuesto(0, tipoAyudaPresupuesto.grupoPresupuesto);
        }
        private void sbAyudaPresupuesto_Click(object sender, EventArgs e)
        {
            int id = this.GrupoPresupuesto != null ? this.GrupoPresupuesto.idGruPre : 0;
            AbrirAyudaPresupuesto(id, tipoAyudaPresupuesto.presupuesto);
        }
        private void sbAyudaSubPresupuesto_Click(object sender, EventArgs e)
        {
            int id = this.Presupuesto != null ? this.Presupuesto.idPresupuesto : 0;
            AbrirAyudaPresupuesto(id, tipoAyudaPresupuesto.subpresupuesto);
        }
        private void AbrirAyudaPresupuesto(int id, tipoAyudaPresupuesto tipo)
        {
            using (frmAyudaPresupuesto frm = new frmAyudaPresupuesto(id, tipo))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (tipo)
                    {
                        case tipoAyudaPresupuesto.grupoPresupuesto:
                            this.GrupoPresupuesto = frm.Tag as GrupoPresupuesto;

                            txtPresupuesto.Text = "";
                            txtSubPresupuesto.Text = "";
                            this.Presupuesto = null;
                            this.Subpresupuesto = null;
                            this.grcEvaluacionPresupuestoCuenta.DataSource = null;

                            break;
                        case tipoAyudaPresupuesto.presupuesto:
                            this.Presupuesto = frm.Tag as Presupuesto;

                            txtSubPresupuesto.Text = "";
                            this.Subpresupuesto = null;
                            this.grcEvaluacionPresupuestoCuenta.DataSource = null;
                            break;
                        case tipoAyudaPresupuesto.subpresupuesto:
                            this.Subpresupuesto = frm.Tag as Subpresupuesto;
                            break;
                    }
                }
            }
        }
        private void ExportarEvaluacionCuentas()
        {
            int filas = this.listaSplash != null ? this.listaSplash.Count : 0;
            if (filas > 0)
                this.listaEvaluacionPresupuestoCuentaPresentador.ExportarEvaluacionPresupuestoPorCuentas();
            else
                EmitirMensajeResultado(true, "No existen datos a exportar");
        }

        private void lueMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (this.nivelPresupuesto >= 2)
                LlenarGrid();
        }
        private void spLimpiar_Click(object sender, EventArgs e)
        {
            listaEvaluacionPresupuestoCuentaPresentador.Limpiar();
            this.grcEvaluacionPresupuestoCuenta.DataSource = null;
        }
        private void sbConsultar_Click(object sender, EventArgs e)
        {
            //if (this.nivelPresupuesto >= 2)
            //    LlenarGrid();
            //else
            //    EmitirMensajeResultado(true, "Debe seleccionar presupuesto anual y/o mensual");

            LlenarGrid();
        }
    }
}
