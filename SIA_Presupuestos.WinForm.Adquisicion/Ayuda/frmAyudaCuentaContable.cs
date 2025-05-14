using System;
using SIA_Presupuesto.WinForm.General.Base;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Adquisicion.Ayuda
{
    public partial class frmAyudaCuentaContable : frmDialogoBaseAyuda, IAyudaCuentaContableVista
    {
        private AyudaCuentaContablePresentador ayudaCuentaContablePresentador;

        public List<CuentaContable> listaCuentaContable
        {
            set
            {
                glueCuenta.Properties.DisplayMember = "numCuenta";
                glueCuenta.Properties.ValueMember = "idCueCon";
                glueCuenta.Properties.NullText = string.Empty;
                glueCuenta.Properties.DataSource = value;
            }
        }
        public int idCueCon
        {
            set { glueCuenta.EditValue = value; }
            get { return Convert.ToInt32(glueCuenta.EditValue); }
        }
        public object DatoActual
        {
            get
            {
                if (glueCuenta.EditValue == null ) return null;
                return new CuentaContable { idCueCon = Convert.ToInt32(glueCuenta.EditValue), numCuenta = Convert.ToString(glueCuenta.Text) } as object;
            }
        }

        public frmAyudaCuentaContable()
        {
            InitializeComponent();
            this.ayudaCuentaContablePresentador = new AyudaCuentaContablePresentador(this);
            Text = "Seleccionar Cuenta";
        }

        protected override void Inicializar()
        {
            base.Inicializar();
            ayudaCuentaContablePresentador.IniciarDatos();
        }
        public override void SelecionarItem()
        {
            ayudaCuentaContablePresentador.AsignarDatosActual(this);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private void glueCuenta_EditValueChanged(object sender, EventArgs e)
        {
            SelecionarItem();
        }
    }
}