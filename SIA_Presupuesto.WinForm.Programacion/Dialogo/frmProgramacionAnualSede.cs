using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmProgramacionAnualSede : frmDialogoBaseAyuda, IProgramacionAnualSedeVista
    {
        private ProgramacionAnualSedePresentador programacionAnualSedePresentador;
        public List<ProgramacionSedeLaboralPoco> listaDatosPrincipales
        {
            set
            {
                grcSede.DataSource = value;
            }
        }

        public List<SedeLaboral> listaSedesLaborales
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSede.Properties, "idSede", "desSede", "Sede", value);
            }
        }

        protected override ColumnView ColumnaActual { get { return grcSede.MainView as ColumnView; } }
        protected DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcSede; } }

        public ProgramacionSedeLaboralPoco ProgramacionAnualSede
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProgramacionSedeLaboralPoco;
            }
        }

        public int idSede
        {
            set { lueSede.EditValue = value; }
            get { return Convert.ToInt32(lueSede.EditValue); }
        }

        public string desSede
        {
            set { lueSede.Text = value; }
            get { return lueSede.Text; }
        }

        public frmProgramacionAnualSede(int idProAnu, List<ProgramacionSedeLaboralPoco> lista)
        {
            InitializeComponent();
            this.programacionAnualSedePresentador = new ProgramacionAnualSedePresentador(idProAnu, lista, this);
            Text = "Sedes del Presupuesto";
        }

        protected override void Inicializar()
        {
            programacionAnualSedePresentador.IniciarDatos();
        }

        private void sbAgregar_Click(object sender, EventArgs e)
        {
            programacionAnualSedePresentador.Agregar();
        }

        private void sbQuitar_Click(object sender, EventArgs e)
        {
            programacionAnualSedePresentador.Quitar();
        }

        private void grvSede_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcSede.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as ProgramacionSedeLaboralPoco;

            var gv = grcSede.MainView as GridView;
            var index = gv.FocusedRowHandle;

            if (cambio != null)
            {
                string numero = string.Empty;
                if (e.Column.FieldName.Equals("observacion"))
                {
                    if (!cambio.operacion.Equals("N")) cambio.operacion = "M";
                }
            }
        }
    }
}