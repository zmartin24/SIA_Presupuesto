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
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using Utilitario.Util;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmEvaluacionMensualGeneral : frmDialogoBase, IEvaluacionMensualGeneralVista
    {
        private EvaluacionMensualGeneralPresentador evaluacionMensualGeneralPresentador;

        public List<Mes> listaMesesDesde
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesDesde.Properties, "indice", "nombre", "Mes", value);
            }
        }

        public List<Mes> listaMesesHasta
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesHasta.Properties, "indice", "nombre", "Mes", value);
            }
        }

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }

        public List<ProgramacionAnual> listaProgramacionAnual
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresAnu.Properties, "idProAnu", "descripcion", "Presupuesto Anual", value);
            }
        }

        public int mesDesde
        {
            set { lueMesDesde.EditValue = value; }
            get { return Convert.ToInt32(lueMesDesde.EditValue); }
        }

        public int mesHasta
        {
            set { lueMesHasta.EditValue = value; }
            get { return Convert.ToInt32(lueMesHasta.EditValue); }
        }

        public int idPresAnu
        {
            set { luePresAnu.EditValue = value; }
            get { return Convert.ToInt32(luePresAnu.EditValue); }
        }

        public int anioPres
        {
            set { lueAnio.EditValue = value; }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public DateTime fechaEmision
        {
            set { deFechaEmision.EditValue = value; }
            get { return Convert.ToDateTime(deFechaEmision.EditValue); }
        }

        public decimal tipoCambio
        {
            set { seTipoCambio.EditValue = value; }
            get { return Convert.ToDecimal(seTipoCambio.EditValue); }
        }

        public frmEvaluacionMensualGeneral(EvaluacionMensualProgramacion EvaluacionMensualProgramacion, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = EvaluacionMensualProgramacion != null;
            evaluacionMensualGeneralPresentador = new EvaluacionMensualGeneralPresentador(EvaluacionMensualProgramacion, this);
            Text = "Evaluación Mensual";
            if (this.esModificacion)
                lciPresupuesto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(luePresAnu, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMesDesde, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            evaluacionMensualGeneralPresentador.IniciarDatos();
            //CrearArbol();
        }

        BarraProgresoBarHelper barra;
        protected override void GuardarDatos()
        {
            Thread hilo = new Thread(new ThreadStart(this.Guardar));
            hilo.Start();

            while (!hilo.IsAlive) ;

            barra = new BarraProgresoBarHelper
            {
                Mensaje = "Espere mientras se obtienen los datos y se registran...",
                Cantidad = 600 * (10 - mesHasta),
            };

            BarraProgreso BarraProgreso = new BarraProgreso(hilo, barra);
            BarraProgreso.ShowDialog();
            BarraProgreso.Dispose();
        }

        private void Guardar()
        {
            if (evaluacionMensualGeneralPresentador.GuardarDatos())
            {
                barra.ProgresoCalculo = barra.Cantidad;
                if (this.esModificacion)
                    XtraMessageBox.Show(Mensajes.MensajeModificacionSatisfactoria, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show(Mensajes.MensajeRegistroSatisfactorio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                barra.ProgresoCalculo = barra.Cantidad;
                XtraMessageBox.Show(Mensajes.MensajeErrorRegistro, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        private void trvPresupuesto_AfterCheck(object sender, TreeViewEventArgs e)
        {
           SeleccionarHijos(e.Node);
        }

        private void SeleccionarPadres(System.Windows.Forms.TreeNode nodoPrincipal)
        {
            if (nodoPrincipal == null) return;
            if (nodoPrincipal.Parent != null)
            {
                nodoPrincipal.Parent.Checked = true;
                SeleccionarPadres(nodoPrincipal.Parent);
            }
        }

        private void SeleccionarHijos(System.Windows.Forms.TreeNode nodoPrincipal)
        {
            foreach (System.Windows.Forms.TreeNode nodo in nodoPrincipal.Nodes)
            {
                nodo.Checked = nodoPrincipal.Checked;
            }
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            evaluacionMensualGeneralPresentador.LlenarComboPresupuesto();
        }

        private void luePresAnu_EditValueChanged(object sender, EventArgs e)
        {
            NombreEvaluacion();
        }

        private void lueMesDesde_EditValueChanged(object sender, EventArgs e)
        {
            NombreEvaluacion();
        }

        private void NombreEvaluacion()
        {
            if (luePresAnu.EditValue != null && lueMesDesde.EditValue != null && lueMesHasta.EditValue != null)
            {
                descripcion = string.Format("{0} ({1} - {2})", luePresAnu.Text, lueMesDesde.Text.ToUpper(), lueMesHasta.Text.ToUpper());
            }
        }

        private void lueMesHasta_EditValueChanged(object sender, EventArgs e)
        {
            NombreEvaluacion();
        }
    }
}