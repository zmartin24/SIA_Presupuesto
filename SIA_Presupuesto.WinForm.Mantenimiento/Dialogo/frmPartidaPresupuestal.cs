using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmPartidaPresupuestal : frmDialogoBase, IPartidaPresupuestalVista
    {
        private PartidaPresupuestalPresentador partidaPresupuestalPresentador;

        public List<Predeterminado> listaTipo
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipo", value);
            }
        }
        public List<Unidad> listaUnidad
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidad", value);
            }
        }
        public List<CuentaContable> listaCuentaContable
        {
            set
            {
                slueCuenta.Properties.DataSource = value;
            }
        }

        public int tipo
        {
            set { lueTipo.EditValue = value; }
            get { return Convert.ToInt32(lueTipo.EditValue); }
        }
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        public int idUnidad
        {
            set { lueUnidad.EditValue = value; }
            get { return Convert.ToInt32(lueUnidad.EditValue); }
        }
        public decimal precio
        {
            set { sePrecio.EditValue = value; }
            get { return Convert.ToDecimal(sePrecio.EditValue); }
        }
        public CuentaContable cuentaContable
        {
            set; get;
        }
        private PartidaPresupuestal partidaPresupuestal;
        private string mensaje = string.Empty;

        public frmPartidaPresupuestal(PartidaPresupuestal partidaPresupuestal, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = partidaPresupuestal != null;
            this.partidaPresupuestal = partidaPresupuestal;
            this.cuentaContable = new CuentaContable();
            partidaPresupuestalPresentador = new PartidaPresupuestalPresentador(partidaPresupuestal, this);
            Text = partidaPresupuestal != null ? "Modificación de Partida Presupuestal - " + partidaPresupuestal.descripcion : "Registro de Partida Presupuestal";
            
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            
        }
        protected override void InicializarDatos()
        {
            partidaPresupuestalPresentador.IniciarDatos();
            if(this.esModificacion)
            {
                lueTipo.ReadOnly = true;
                this.cuentaContable = this.partidaPresupuestal.cuentaContable != null ? this.partidaPresupuestal.cuentaContable : new CuentaContable();
                slueCuenta.ReadOnly = this.partidaPresupuestal.cuentaContable != null ? true : false;
            }
        }
        protected override bool ValidarDatos()
        {
            mensaje = string.Empty;
            //bool res = (proveedorValidacion.Validate() && this.partidaPresupuestalPresentador.ValidarRegistroExistente());
            bool res = proveedorValidacion.Validate();
            if (!this.partidaPresupuestalPresentador.ValidarRegistroExistente())
            {
                mensaje = mensaje + "\nLa descripción, unidad y precio ya existe";
                res = false;
            }
            if (!(this.cuentaContable == null || this.cuentaContable.idCueCon > 0))
            {
                mensaje = mensaje + "\nDebe seleccionar una cuenta";
                res = false;
            }

            if (!res)
                EmitirMensajeResultado(true, mensaje);

            return res;
        }
        protected override void GuardarDatos()
        {
            if (partidaPresupuestalPresentador.GuardarDatos())
            {
                if (this.esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void slueCuenta_Popup(object sender, EventArgs e)
        {
            SearchLookUpEdit edit = sender as SearchLookUpEdit;
            GridView view = edit.Properties.View as GridView;
            List<string> values = new List<string>();

            if (!edit.IsPopupOpen)
                edit.ShowPopup();

            if (this.cuentaContable.idCueCon > 0)
            {
                values.Add(cuentaContable.numCuenta);
                view.SelectRow(view.FindRow(cuentaContable));
            }

            string csv = String.Join(", ", values);
            edit.Text = csv;
        }

        private void slueView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView grid = sender as GridView;
            var row = e.ControllerRow;
            var accion = e.Action;

            var cuenta = this.esModificacion ? this.partidaPresupuestal.cuentaContable != null ? this.partidaPresupuestal.cuentaContable : grid.GetFocusedRow() as CuentaContable : grid.GetFocusedRow() as CuentaContable;

            if (cuenta != null)
            {
                switch (e.Action)
                {
                    case CollectionChangeAction.Add:
                        if (!this.cuentaContable.Equals(cuenta))
                            this.cuentaContable = cuenta;
                        break;
                    case CollectionChangeAction.Remove:
                        if (this.cuentaContable.Equals(cuenta))
                            this.cuentaContable = null;
                        break;
                    case CollectionChangeAction.Refresh:
                        //if (this.cuentaContable.Equals(cuenta))
                        this.cuentaContable = cuenta;
                        slueView.SelectRow(e.ControllerRow);
                        break;
                }
            }
        }

        private void slueCuenta_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            List<string> values = new List<string>();

            if (this.cuentaContable!=null)
            {
                if (this.cuentaContable.idCueCon == 0)
                {
                    values.Add("SIN CUENTA");
                    return;
                }

                values.Add(this.cuentaContable.numCuenta);
                values.Add(this.cuentaContable.descripcion);
            }
            string csv = String.Join(" - ", values);
            e.DisplayText = csv;
        }
    }
}
