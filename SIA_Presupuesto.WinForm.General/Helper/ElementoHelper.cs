using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Selection;
using SIA_Presupuesto.WinForm.General.Recursos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ElementoHelper
    {
        public static void LlenarLookUpEdit(RepositoryItemLookUpEdit combo, string valor, string presentacion, string titulo, IList lista)
        {
            combo.DisplayMember = presentacion;
            combo.ValueMember = valor;
            combo.DataSource = lista;
            combo.NullText = string.Empty;
            combo.Columns.Clear();
            
            combo.TextEditStyle = TextEditStyles.DisableTextEditor;
            combo.ShowFooter = false;
            //combo.DropDownRows = 20;
            combo.AllowNullInput = DefaultBoolean.True;
            if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrWhiteSpace(titulo))
            {
                combo.ShowHeader = true;
                combo.Columns.Add(new LookUpColumnInfo(presentacion, titulo));
            }
            else
            {
                combo.ShowHeader = false;
                combo.Columns.Add(new LookUpColumnInfo(presentacion));
            }
        }

        public static RepositoryItemGridLookUpEdit CrearGridLookUpEdit(RepositoryItemGridLookUpEdit combo, IList lista, string valor, string presentacion, string titulo)
        {
            RepositoryItemGridLookUpEdit ret = combo == null ? new RepositoryItemGridLookUpEdit() : combo;

            ret.AllowNullInput = DefaultBoolean.False;
            ret.ValueMember = valor;
            ret.DisplayMember = presentacion;
            ret.PopupFormSize = new Size(350, 220);
            if (ret.View == null) ret.View = new GridView();
            GridColumn columna = new GridColumn();

            columna.FieldName = presentacion;
            columna.Caption = titulo;
            columna.VisibleIndex = 1;
            columna.Width = 400;

            ret.View.Columns.Clear();
            ret.View.Columns.Add(columna);
            ret.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            ret.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            ret.View.OptionsView.ShowGroupPanel = false;
            ret.View.OptionsView.ShowIndicator = false;
            ret.View.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            ret.DataSource = lista;
            return ret;
        }

        public static string ObtenerNombreArchivo(string extension, string filtro, string nombreArchivo)
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = filtro;
                dialogo.FileName = nombreArchivo;
                dialogo.DefaultExt = extension;
                if (dialogo.ShowDialog() == DialogResult.OK)
                    return dialogo.FileName;
            }
            return String.Empty;
        }

        public static void MostrarErrorExportacion()
        {
            XtraMessageBox.Show(Mensajes.ErrorExportar, Mensajes.Exportar, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AbrirArchivo(string nombreArchivo)
        {
            if (XtraMessageBox.Show(Mensajes.PreguntaAbrirArchivo, Mensajes.Abrir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process process = new Process();
                try
                {
                    process.StartInfo.FileName = nombreArchivo;
                    process.Start();
                }
                catch { }
            }
        }

        public static void IniciarProceso(string nombreProceso)
        {
            try
            {
                Process.Start(nombreProceso);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Mensajes.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string ObtenerPosibleNombreArchivo(string nombre) { return nombre.Replace("/", ""); }

        public static void AgregarColumnas(GridControl grid, RepositoryItem editor, AppearanceDefault AparienciaTotal,
            IDictionary<string, bool> ColumnasEstaticas, IDictionary<string, string> listaColumnas, IList lista)
        {
            GridView vista = grid.MainView as GridView;
            vista.BeginDataUpdate();
            vista.Columns.Clear();
            try
            {
                string titulo = string.Empty;
                foreach (string columna in listaColumnas.Keys)
                {
                    titulo = listaColumnas.FirstOrDefault(f => f.Key.Equals(columna)).Value;
                    GridColumn col = new GridColumn();
                    vista.Columns.Add(col);
                    col.Caption = titulo;
                    col.FieldName = columna;
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Bound;
                    col.Visible = true;
                    if (editor != null) col.ColumnEdit = editor;

                    if (ColumnasEstaticas.ContainsKey(columna))
                    {
                        var des = ColumnasEstaticas.FirstOrDefault(f => f.Key.Equals(columna));
                        col.Fixed = des.Value ? FixedStyle.Left : FixedStyle.Right;
                        col.OptionsColumn.AllowEdit = false;
                        col.OptionsColumn.AllowMove = false;
                        col.OptionsColumn.ReadOnly = true;
                        col.AppearanceHeader.Assign(AparienciaTotal);
                    }
                    else
                    {
                        col.SummaryItem.Tag = col;
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    }
                }
                grid.DataSource = lista;
            }
            finally
            {
                vista.EndDataUpdate();
            }
        }

        public static string OperacionPivotGrid(PivotGridControl pivotGrid)
        {
            PivotGridCells celdas = pivotGrid.Cells;
            ReadOnlyCells celdasSeleccionadas = pivotGrid.Cells.MultiSelection.SelectedCells;
            string resultado = string.Empty;
            decimal suma = 0, promedio = 0;
            int cantidad = celdasSeleccionadas.Count;
            PivotSummaryValue summary = new PivotSummaryValue(null, null);
            if (cantidad > 0)
            {
                foreach (var celda in celdasSeleccionadas)
                {
                    var valor = celdas.GetCellInfo(celda.X, celda.Y).Value;
                    summary = celdas.GetCellInfo(celda.X, celda.Y).SummaryValue;
                    if ((decimal?)valor != null)
                    {
                        suma += (decimal)valor;
                    }
                }
                promedio = suma / cantidad;
                resultado = string.Format("Promedio: {0:#,##0.##} Cantidad: {1:n0} Suma: {2:#,##0.##}",
                                    promedio, cantidad, suma);
            }
            return resultado;
        }
    }
}
