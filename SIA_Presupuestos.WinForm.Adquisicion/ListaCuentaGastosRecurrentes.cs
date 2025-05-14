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
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaCuentaGastosRecurrentes : ControlBase, IListaRubroBienServicioCuentaVista
    {
        private ListaRubroBienServicioCuentaPresentador listaRubroBienServicioCuentaPresentador;

        public ListaCuentaGastosRecurrentes()
        {
            InitializeComponent();
            this.listaRubroBienServicioCuentaPresentador = new ListaRubroBienServicioCuentaPresentador(this);
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            this.listaRubroBienServicioCuentaPresentador.InicializarDatos();
        }

        protected override ColumnView ColumnaActual { get { return grcCatGastoRecurrente.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcCatGastoRecurrente; } }

        public RubroBienServicioCuentaPoco rubroBienCuentaServicio
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RubroBienServicioCuentaPoco;
            }
        }

        public int idPlanCuenta
        {
            set { cboPlanCuenta.EditValue = value; }
            get { return (Int32)cboPlanCuenta.EditValue; }
        }

        public List<RubroBienServicioCuentaPoco> listaDatosPrincipales
        {
            set
            {
                grcCatGastoRecurrente.DataSource = value;
            }
        }

        public List<ItemPoco> listaPlanCuenta
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboPlanCuenta.Properties, "id", "nombre", "Plan Cuenta", value);
            }
        }

        protected override void LlenarGrid()
        {
            listaRubroBienServicioCuentaPresentador.ObtenerDatosListado();
        }

        private void cboPlanCuenta_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected override void Nuevo()
        {
            using (frmAgregarCtaGasto frm = new frmAgregarCtaGasto(null, this.FindForm(),idPlanCuenta))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmAgregarCtaGasto frm = new frmAgregarCtaGasto(rubroBienCuentaServicio, this.FindForm(), idPlanCuenta))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        public override bool Eliminar()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaRubroBienServicioCuentaPresentador.Anular())
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
                }
            }
            return true;
        }
    }
}
