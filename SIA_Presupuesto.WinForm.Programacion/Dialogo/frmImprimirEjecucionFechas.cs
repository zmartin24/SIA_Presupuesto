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
    public partial class frmImprimirEjecucionFechas : frmDialogoBase, IImprimirEjecucionFechasVista
    {
        private ImprimirEjecucionFechasPresentador imprimirEjecucionFechasPresentador;

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

        public int idMoneda
        {
            set { }
            get { return 64;  }
        }

        public DateTime fechaDesde
        {
            set
            {
                deFechaDesde.EditValue = value;
            }
            get { return deFechaDesde.DateTime; }
        }

        public DateTime fechaHasta
        {
            set
            {
                deFechaHasta.EditValue = value;
            }
            get { return deFechaHasta.DateTime; }
        }

        public frmImprimirEjecucionFechas(Form padre) :
            base(padre, false)
        {
            InitializeComponent();
            this.imprimirEjecucionFechasPresentador = new ImprimirEjecucionFechasPresentador(this);
            Text = "Resumen de Ejecución de Presupuesto por Fechas";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(luePresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueGrupoPres, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaDesde, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaHasta, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirEjecucionFechasPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirEjecucionFechasPresentador.ImprimirReporte();
            this.DialogResult = DialogResult.No;
        }

        private void lueGrupoPres_EditValueChanged(object sender, EventArgs e)
        {
            imprimirEjecucionFechasPresentador.CargarPresupuesto();
        }
    }
}