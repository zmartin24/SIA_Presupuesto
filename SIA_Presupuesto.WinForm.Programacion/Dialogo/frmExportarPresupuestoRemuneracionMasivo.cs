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

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmExportarPresupuestoRemuneracionMasivo : frmDialogoBase, IExportarPresupuestoRemuneracionMasivoVista
    {
        private ExportarPresupuestoRemuneracionMasivoPresentador exportarReajusteEvaluacionPresentador;

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


        public string idsDireccion
        {
            get
            {
                string codigos = string.Empty;
                Direccion perfil = null;
                foreach (TreeNode nodo in trvDirecciones.Nodes)
                {
                    if (nodo.Checked)
                    {
                        perfil = (Direccion)nodo.Tag;
                        if (perfil != null)
                        {
                            if (string.IsNullOrEmpty(codigos))
                            {
                                codigos = perfil.idDireccion.ToString();
                            }
                            else
                                codigos += "~" + perfil.idDireccion.ToString();
                        }
                    }
                }
                return codigos;
            }
        }

        public List<Direccion> listaDirecciones
        {
            set
            {
                System.Windows.Forms.TreeNode nodoPerfil = null;

                foreach (Direccion perfil in value)
                {
                    nodoPerfil = new System.Windows.Forms.TreeNode();
                    nodoPerfil.Text = perfil.desDireccion;
                    nodoPerfil.Tag = perfil;
                    trvDirecciones.Nodes.Add(nodoPerfil);
                }
                // ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Programación Anual", value);
            }
        }

        public frmExportarPresupuestoRemuneracionMasivo()
        {
            InitializeComponent();
            this.exportarReajusteEvaluacionPresentador = new ExportarPresupuestoRemuneracionMasivoPresentador(this);
            Text = "Exportar Reajuste Presupuesto Remuneración";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(luePresAnu, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(lueFueFin, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
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

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}