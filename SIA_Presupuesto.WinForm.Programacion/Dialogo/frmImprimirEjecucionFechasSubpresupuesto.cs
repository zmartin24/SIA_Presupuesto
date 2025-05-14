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

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmImprimirEjecucionFechasSubpresupuesto : frmDialogoBase, IImprimirEjecucionSubpresupuestoVista
    {
        private ImprimirEjecucionSubpresupuestoPresentador imprimirEjecucionSubpresupuestoPresentador;

        public List<GrupoPresupuesto> listaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueGrupoPres.Properties, "idGruPre", "descripcion", "Grupos presupuestales", value);
            }
        }

        public int idGruPre
        {
            set
            {
                lueGrupoPres.EditValue = value;
            }
            get { return Convert.ToInt32(lueGrupoPres.EditValue); }
        }

        public List<ProgramacionAnual> listaProgramacion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Presupuesto Anual", value);
            }
        }

        public int idPresupuesto
        {
            set
            {
                luePresupuesto.EditValue = value;
            }
            get { return Convert.ToInt32(luePresupuesto.EditValue); }
        }

        public List<Subpresupuesto> listaSubpresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubpresupuesto.Properties, "idSubpresupuesto", "descripcion", "Presupuesto Mensual", value);
            }
        }

        public int idSubpresupuesto
        {
            set
            {
                lueSubpresupuesto.EditValue = value;
            }
            get { return Convert.ToInt32(lueSubpresupuesto.EditValue); }
        }

        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
            }
        }

        public int idMoneda
        {
            set
            {
                lueMoneda.EditValue = value;
            }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }

        public frmImprimirEjecucionFechasSubpresupuesto(Form padre):
            base(padre, false)
        {
            InitializeComponent();
            this.imprimirEjecucionSubpresupuestoPresentador = new ImprimirEjecucionSubpresupuestoPresentador(this);
            Text = "Resumen de Ejecución por Presupuesto Mensual";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(luePresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueGrupoPres, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueSubpresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirEjecucionSubpresupuestoPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirEjecucionSubpresupuestoPresentador.ImprimirReporte();
            this.DialogResult = DialogResult.No;
        }

        private void lueGrupoPres_EditValueChanged(object sender, EventArgs e)
        {
            imprimirEjecucionSubpresupuestoPresentador.CargarPresupuesto();
        }

        private void luePresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            imprimirEjecucionSubpresupuestoPresentador.CargarSubpresupuesto();
        }

    }
}