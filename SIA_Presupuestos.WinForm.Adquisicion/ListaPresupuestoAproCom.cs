using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Ayuda;
using DevExpress.XtraGrid.Views.Base;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaPresupuestoAproCom : ControlBase, IListaPresupuestoAproComVista
    {
        private ListaPresupuestoAproComPresentador listaPresupuestoAproComPresentador;
        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaDatosPrincipales
        {
            set
            {
                grcClase.DataSource = value;
            }
        }
        
        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
            }
        }
        
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }

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

                }
                else
                {
                    txtSubPresupuesto.Text = string.Empty;

                }
            }
        }

        bool primerLlamado = false;
        public ListaPresupuestoAproCom()
        {
            InitializeComponent();
            this.listaPresupuestoAproComPresentador = new ListaPresupuestoAproComPresentador(this);
            Text = "Presupuesto Aprobado, Comprometido, Ejecutado y Saldo";
            primerLlamado = false;
        }

        protected override ColumnView ColumnaActual { get { return grcClase.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcClase; } }

        protected ColumnView ColumnaActual1 { get { return grcClase.ViewCollection[2] as ColumnView; } }

       
        protected override void InicializarDatos()
        {
            this.listaPresupuestoAproComPresentador.IniciarDatos();
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }
        protected override void EjecutarCargarConSplash()
        {
            if (lueMoneda.EditValue != null && this.Subpresupuesto != null && primerLlamado)
                this.listaPresupuestoAproComPresentador.llenarGrid();
            primerLlamado = true;
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "ExportarPreApr": ExportarPresupuesto(); break;
            }
        }
        private void lueMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMoneda.EditValue != null && this.Subpresupuesto != null && primerLlamado)
                LlenarGrid();
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
            if (this.Subpresupuesto != null)
                LlenarGrid();
        }
        private void spLimpiar_Click(object sender, EventArgs e)
        {
            listaPresupuestoAproComPresentador.Limpiar();
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
                            this.grcClase.DataSource = null;

                            break;
                        case tipoAyudaPresupuesto.presupuesto:
                            this.Presupuesto = frm.Tag as Presupuesto;

                            txtSubPresupuesto.Text = "";
                            this.Subpresupuesto = null;
                            this.grcClase.DataSource = null;
                            break;
                        case tipoAyudaPresupuesto.subpresupuesto:
                            this.Subpresupuesto = frm.Tag as Subpresupuesto;
                            break;
                    }
                }
            }
        }
        private void ExportarPresupuesto()
        {
            int filas = this.listaSplash != null ? this.listaSplash.Count : 0;
            if (filas > 0)
                this.listaPresupuestoAproComPresentador.ExportarPresupuesto();
            else
                EmitirMensajeResultado(true, "No existen datos a exportar");
        }

    }
}
