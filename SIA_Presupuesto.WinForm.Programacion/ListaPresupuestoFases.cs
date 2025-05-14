using System;
using System.Collections.Generic;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Ayuda;
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.Programacion.Helper;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaPresupuestoFases : ControlBase, IListaPresupuestoFasesVista
    {
        private ListaPresupuestoFasesPresentador listaPresupuestoFasesPresentador;
        public List<ReportePresupuestoFasesPres> listaDatosPrincipales
        {
            set
            {
                grcPresupuestoFases.DataSource = value;
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

        public int vanio
        {
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : DateTime.Now.Year; }
            set { lueAnio.EditValue = value; }
        }

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 63; }
        }

        public DateTime fechaIni
        {
            set { deFechaIni.EditValue = value; }
            get { return Convert.ToDateTime(deFechaIni.EditValue); }
        }

        public DateTime fechaFin
        {
            set { deFechaFin.EditValue = value; }
            get { return Convert.ToDateTime(deFechaFin.EditValue); }
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

        public List<ReportePresupuestoFasesPres> listaReportePresupuestoFasesPres
        {
            set;get;
        }

        public bool inicio = false;
        bool hacerCarga = false;
        public ListaPresupuestoFases()
        {
            InitializeComponent();
            this.listaPresupuestoFasesPresentador = new ListaPresupuestoFasesPresentador(this);
            Text = "Reporte de Presupuesto por Fases";
            hacerCarga = false;
            listaReportePresupuestoFasesPres = new List<ReportePresupuestoFasesPres>();
        }

        protected override ColumnView ColumnaActual { get { return grcPresupuestoFases.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcPresupuestoFases; } }
        protected ColumnView ColumnaActual1 { get { return grcPresupuestoFases.ViewCollection[2] as ColumnView; } }

        protected override void InicializarDatos()
        {
            this.listaPresupuestoFasesPresentador.IniciarDatos();
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "ExportarPreFases": Exportar(listaReportePresupuestoFasesPres); break;
            }
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }

        protected override void EjecutarCargarConSplash()
        {
            if (lueAnio.EditValue != null && lueMoneda.EditValue != null && hacerCarga)
            {
                this.listaPresupuestoFasesPresentador.llenarGrid();
            }
            hacerCarga = true;
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

                            break;
                        case tipoAyudaPresupuesto.presupuesto:
                            this.Presupuesto = frm.Tag as Presupuesto;

                            txtSubPresupuesto.Text = "";
                            this.Subpresupuesto = null;

                            break;
                        case tipoAyudaPresupuesto.subpresupuesto:
                            this.Subpresupuesto = frm.Tag as Subpresupuesto;
                            break;
                    }
                }
            }
        }

        private void sbConsultar_Click(object sender, EventArgs e)
        {
            this.listaReportePresupuestoFasesPres.Clear();
            LlenarGrid();
        }

        private void spLimpiar_Click(object sender, EventArgs e)
        {
            listaPresupuestoFasesPresentador.Limpiar();
            this.grcPresupuestoFases.DataSource = null;
            this.listaReportePresupuestoFasesPres.Clear();
        }
        private void Exportar(List<ReportePresupuestoFasesPres> lista)
        {
            if (lista.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string format = "yyyy-MM-dd_hh.mm.ss.tt";
                    sfd.Filter = "Excel XLSX|*.xlsx";
                    sfd.Title = "Guardar el siguiente archivo";

                    string ruta = Path.GetTempPath() + "PresupuestoFases_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                    ExportarProHelper.ExportarPresupuestoFases(ruta, lista);
                    ExportarHelper.AbrirArchivoExcel(ruta);
                }
            }
            else
            {
                EmitirMensajeResultado(true, "No hay registros a exportar");
            }
        }
    }
}
