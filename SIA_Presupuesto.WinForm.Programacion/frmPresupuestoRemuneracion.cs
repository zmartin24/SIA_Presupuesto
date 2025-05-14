using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Selection;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using Utilitario.Util;
using DevExpress.XtraPrinting;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class frmPresupuestoRemuneracion : ControlDetalleBase, IPresupuestoRemuneracionVista
    {
        private PresupuestoRemuneracionPresentador presupuestoRemuneracionPresentador;
        private ProgramacionAnual programacionAnual;
        public frmPresupuestoRemuneracion(ProgramacionAnual programacionAnual)
        {
            InitializeComponent();
            Text = "Cálculo de Remuneración";
            this.presupuestoRemuneracionPresentador = new PresupuestoRemuneracionPresentador(programacionAnual, this);
            this.programacionAnual = programacionAnual;
        }
        protected override DevExpress.XtraPivotGrid.PivotGridControl PivotGridPrincipal { get { return pgcResultado; } }
        protected override bool ExportarDePivot { get { return true; } }

        public int idEstPreRem
        {
            get { return Convert.ToInt32(lueEstructura.EditValue); }
            set { lueEstructura.EditValue = value; }
        }

        public List<CalculoPresupuestoRemuneracion> listaDatosPrincipales
        {
            set
            {
                pgcResultado.DataSource = value;
                pgcResultado.RefreshData();
            }
        }

        public PuestoPresupuesto puestoPresupuesto
        {
            get
            {
                //Dictionary<int, string> Ids = ListaCodigoContratosSeleccionadosPreliminar();
                List<int> lista = ListaCodigoContratosSeleccionadosPreliminar().Select(s => s.Key).ToList();
                return lista != null ? presupuestoRemuneracionPresentador.Buscar(lista.FirstOrDefault()) : null;
            }
        }

        public List<PuestoPresupuesto> puestoPresupuestos
        {
            get
            {
                //Dictionary<int, string> Ids = ListaCodigoContratosSeleccionadosPreliminar();
                List<int> lista = ListaCodigoContratosSeleccionadosPreliminar().Select(s => s.Key).ToList();
                return lista != null ? presupuestoRemuneracionPresentador.Buscar(lista) : null;
            }
        }

        public List<EstructuraPresupuestoRemuneracion> listaEstructura
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueEstructura.Properties, "idEstPreRem", "descripcion", "Estructura", value);
            }
        }

        public List<Mes> listaMesDesde
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesDesde.Properties, "indice", "nombre", "Mes Desde", value);
            }
        }

        public List<Mes> listaMesHasta
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesHasta.Properties, "indice", "nombre", "Mes Hasta", value);
            }
        }

        public int mesDesde
        {
            get { return Convert.ToInt32(lueMesDesde.EditValue); }
            set { lueMesDesde.EditValue = value; }
        }

        public int mesHasta
        {
            get { return Convert.ToInt32(lueMesHasta.EditValue); }
            set { lueMesHasta.EditValue = value; }
        }

        protected override void InicializarValidacion()
        {
            presupuestoRemuneracionPresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            return ProveedorValidacion.Validate();
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch(nomOperacion)
            {
                case "CalcularDet":
                    Calcular();
                    break;
                case "NuevoMultipleDet":
                    NuevoMultiple();
                    break;
                case "AgregarPersonal":
                    AgregarPuestoRequerimiento();
                    break;
                case "ExportarDet":
                    Cursor currentCursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    XlsxExportOptions exportOptions = new XlsxExportOptions();
                    string fileName = ElementoHelper.ObtenerNombreArchivo(string.Format("*.{0}", "xlsx"), "Documento XLSX (*.xlsx)|*.xlsx", ElementoHelper.ObtenerPosibleNombreArchivo(ExportFileName));
                    var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
                    pivotExportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    pivotExportOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                    pgcResultado.ExportToXlsx(fileName, pivotExportOptions);
                    Cursor.Current = currentCursor;
                    break;
            }
        }

        protected override void GuardarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;

            
        }

        private void Calcular()
        {
            if (presupuestoRemuneracionPresentador.Calcular())
                LlenarGrid();
        }

        protected override void LlenarGrid()
        {
            presupuestoRemuneracionPresentador.ObtenerDatosListado();
        }

        protected override void NuevoMultiple()
        {
            using (frmPuestoMasivo frm = new frmPuestoMasivo(this.programacionAnual,  this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LlenarGrid();
            }
        }

        protected override void Nuevo()
        {
            using (frmPuesto frm = new frmPuesto(this.programacionAnual, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmPuesto frm = new frmPuesto(this.programacionAnual, puestoPresupuesto, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Anular()
        {
            if (presupuestoRemuneracionPresentador.Anular())
                EmitirMensajeResultado(true, "Anulado correctamente");
            else
                EmitirMensajeResultado(false, "No se puedo anular");
        }
        protected void AgregarPuestoRequerimiento()
        {
            using (frmListaPuestoRequerimientoAnual frm = new frmListaPuestoRequerimientoAnual(this.programacionAnual, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        private Dictionary<int, string> ListaCodigoContratosSeleccionadosPreliminar()
        {
            Dictionary<int, string> codigos = new Dictionary<int, string>();
            PivotDrillDownDataSource ds = null;
            ReadOnlyCells celdasSeleccionadas = pgcResultado.Cells.MultiSelection.SelectedCells;
            PivotGridCells celdas = pgcResultado.Cells;

            foreach (var celda in celdasSeleccionadas)
            {
                ds = celdas.GetCellInfo(celda.X, celda.Y).CreateDrillDownDataSource();

                foreach (DevExpress.XtraPivotGrid.PivotDrillDownDataRow row in ds)
                {
                    object val = row["idPuePre"];
                    if (val != null)
                    {
                        string nombres = Convert.ToString(row["trabajador"]);
                        int idContrato = (int)val;
                        if (!codigos.ContainsKey(idContrato))
                            codigos.Add(idContrato, nombres);
                    }
                }
            }

            return codigos;
        }
    }
}
