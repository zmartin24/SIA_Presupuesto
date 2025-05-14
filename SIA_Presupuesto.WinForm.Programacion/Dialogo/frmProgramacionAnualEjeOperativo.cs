using System;
using System.Collections.Generic;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Vista;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmProgramacionAnualEjeOperativo : frmDialogoBaseAyuda, IProgramacionAnualEjeOperativoVista
    {
        private ProgramacionAnualEjeOperativoPresentador programacionAnualEjeOperativoPresentador;
        public List<ProgramacionEjeOperativoPoco> listaDatosPrincipales
        {
            set
            {
                grcEjeOpe.DataSource = value;
            }
        }

        public List<EjeOperativo> listaEjeOperativos
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueEjeOpe.Properties, "idEjeOpe", "descripcion", "Eje Operativo", value);
            }
        }

        protected override ColumnView ColumnaActual { get { return grcEjeOpe.MainView as ColumnView; } }
        protected DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcEjeOpe; } }

        public ProgramacionEjeOperativoPoco ProgramacionAnualEjeOperativo
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProgramacionEjeOperativoPoco;
            }
        }

        public int idEjeOpe
        {
            set { lueEjeOpe.EditValue = value; }
            get { return Convert.ToInt32(lueEjeOpe.EditValue); }
        }

        public string ejeOperativo
        {
            set { lueEjeOpe.Text = value; }
            get { return lueEjeOpe.Text; }
        }

        public frmProgramacionAnualEjeOperativo(int idProAnu, List<ProgramacionEjeOperativoPoco> lista)
        {
            InitializeComponent();
            this.programacionAnualEjeOperativoPresentador = new ProgramacionAnualEjeOperativoPresentador(idProAnu, lista, this);
            Text = "Ejes Operativos del Presupuesto";
        }

        protected override void Inicializar()
        {
            try
            {
                // Validar que los controles y presentador existen
                if (programacionAnualEjeOperativoPresentador == null)
                    throw new NullReferenceException("El presentador no está inicializado");

                if (lueEjeOpe == null || sbAgregar == null || sbQuitar == null)
                    throw new NullReferenceException("Controles no inicializados");

                // Iniciar datos
                programacionAnualEjeOperativoPresentador.IniciarDatos();

                // Habilitar/deshabilitar botón basado en condición
                UpdateUIState();
            }
            catch (Exception ex)
            {
                // Loggear el error o mostrar mensaje al usuario
                EmitirMensajeResultado(true, $"Error al inicializar: {ex.Message}");

                // Opcional: deshabilitar funcionalidad si hay error
                if (sbAgregar != null) sbAgregar.Enabled = false;
            }

        }
        private void UpdateUIState()
        {
            if (lueEjeOpe != null && sbAgregar != null && sbQuitar != null)
            {
                sbAgregar.Enabled = grvEjeOpe.DataRowCount <= 0;
                sbQuitar.Enabled = grvEjeOpe.DataRowCount > 0;
            }
        }

        private void sbAgregar_Click(object sender, EventArgs e)
        {
            programacionAnualEjeOperativoPresentador.Agregar();
            UpdateUIState();
        }

        private void sbQuitar_Click(object sender, EventArgs e)
        {
            programacionAnualEjeOperativoPresentador.Quitar();
            UpdateUIState();
        }

        private void grvEjeOpe_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcEjeOpe.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as ProgramacionEjeOperativoPoco;

            var gv = grcEjeOpe.MainView as GridView;
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