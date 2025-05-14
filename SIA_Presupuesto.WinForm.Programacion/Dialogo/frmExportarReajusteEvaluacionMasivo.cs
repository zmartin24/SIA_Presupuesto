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
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using Utilitario.Util;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmExportarReajusteEvaluacionMasivo : frmDialogoBase, IExportarReajusteEvaluacionMasivoVista
    {
        private ExportarReajusteEvaluacionMasivoPresentador exportarReajusteEvaluacionPresentador;

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }

        public int anioReporte
        {
            set
            {
                lueAnio.EditValue = value;
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public List<Mes> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mesReporte
        {
            set
            {
                lueMes.EditValue = value;
            }
            get { return Convert.ToInt32(lueMes.EditValue); }
        }

        public List<Mes> listaMesesRea
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesReajuste.Properties, "indice", "nombre", "Meses", value);
            }
        }
        private Dictionary<ProgramacionAnualPres, bool> listaProgramacionAnualPresSeleccionados;
        public List<ProgramacionAnualPres> ListaProgramacionAnualPresSeleccionados
        {
            get { return listaProgramacionAnualPresSeleccionados.Keys.ToList(); }
        }

        public string idsProAnu
        {
            get
            {
                string codigos = string.Empty;
                List<string> values = new List<string>();

                foreach (ProgramacionAnualPres programacionAnualPres in ListaProgramacionAnualPresSeleccionados)
                {
                    if (programacionAnualPres != null)
                    {
                        values.Add(programacionAnualPres.idProAnu.ToString());
                    }
                }
                codigos = String.Join("~", values);

                return codigos;
                //string codigos = string.Empty;
                //ProgramacionAnualPres perfil = null;
                //foreach (TreeNode nodo in trvPresupuesto.Nodes)
                //{
                //    if (nodo.Checked)
                //    {
                //        perfil = (ProgramacionAnualPres)nodo.Tag;
                //        if (perfil != null)
                //        {
                //            if (string.IsNullOrEmpty(codigos))
                //            {
                //                codigos = perfil.idProAnu.ToString();
                //            }
                //            else
                //                codigos += "~" + perfil.idProAnu.ToString();
                //        }
                //    }
                //}
                //return codigos;
            }
        }

        public List<ProgramacionAnualPres> listaProgramacionAnual
        {
            set
            {
                System.Windows.Forms.TreeNode nodoPerfil = null;

                foreach (ProgramacionAnualPres perfil in value)
                {
                    nodoPerfil = new System.Windows.Forms.TreeNode();
                    nodoPerfil.Text = perfil.descripcion;
                    nodoPerfil.Tag = perfil;
                    trvPresupuesto.Nodes.Add(nodoPerfil);
                }
                // ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Programación Anual", value);
                grcProgramacionAnual.DataSource = value;
            }
        }

        public int mesReporteRea
        {
            set
            {
                lueMesReajuste.EditValue = value;
            }
            get { return Convert.ToInt32(lueMesReajuste.EditValue); }
        }

        public frmExportarReajusteEvaluacionMasivo()
        {
            InitializeComponent();
            this.exportarReajusteEvaluacionPresentador = new ExportarReajusteEvaluacionMasivoPresentador(this);
            this.listaProgramacionAnualPresSeleccionados = new Dictionary<ProgramacionAnualPres, bool>();
            Text = "Exportar Evaluación -  Reajuste";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(luePresAnu, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(lueFueFin, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            iniciarControles();
            exportarReajusteEvaluacionPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            exportarReajusteEvaluacionPresentador.Exportar();
            this.DialogResult = DialogResult.No;
        }

        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMes.EditValue != null)
                exportarReajusteEvaluacionPresentador.AsignarMesReajuste();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null)
                exportarReajusteEvaluacionPresentador.CargarProgramacionAnual();
        }

        private void grvProgramacionAnual_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            ProgramacionAnualPres programacionAnualPres = view.GetFocusedRow() as ProgramacionAnualPres;
            int count = 0;

            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    if (programacionAnualPres != null && !this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualPres))
                        this.listaProgramacionAnualPresSeleccionados.Add(programacionAnualPres, true);
                    break;
                case CollectionChangeAction.Remove:
                    if (programacionAnualPres != null && this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualPres))
                        this.listaProgramacionAnualPresSeleccionados.Remove(programacionAnualPres);
                    break;
                case CollectionChangeAction.Refresh:

                    for (int i = 0; i < view.DataRowCount; i++)
                    {
                        ProgramacionAnualPres programacionAnualEnRefresPres = view.GetRow(i) as ProgramacionAnualPres;
                        if (programacionAnualEnRefresPres != null)
                        {
                            switch (programacionAnualEnRefresPres.esSeleccionado)
                            {
                                case true:
                                    if (!this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualEnRefresPres))
                                    {
                                        this.listaProgramacionAnualPresSeleccionados.Add(programacionAnualEnRefresPres, true);
                                        view.SetRowCellValue(i, "esSeleccionado", true);
                                    }
                                    break;
                                case false:
                                    if (this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualEnRefresPres))
                                        this.listaProgramacionAnualPresSeleccionados.Remove(programacionAnualEnRefresPres);
                                    break;
                            }
                        }
                    }
                    break;
            }
            count = this.ListaProgramacionAnualPresSeleccionados.Count > 0 ? this.ListaProgramacionAnualPresSeleccionados.Count : 0;
            if (count > 0)
            {
                string desResgistros = count == 1 ? "Registro seleccionado" : "Registros seleccionados";
                lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcNumReg.Text = String.Format("{0} {1}", count, desResgistros);
            }
            else
            {
                lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcNumReg.Text = string.Empty;
            }
        }
        private void iniciarControles()
        {
            lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcNumReg.Text = string.Empty;
            this.listaProgramacionAnualPresSeleccionados.Clear();
        }
    }
}