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
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmRequerimientoBienServicioDet : frmDialogoBase, IRequerimientoBienServicioDetVista
    {
        private RequerimientoBienServicioDetPresentador requerimientoBienServicioDetPresentador;

        public List<Unidad> listaUnidades
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidades", value);
            }
        }

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

        public int idUnidad
        {
            set { lueUnidad.EditValue = value; }
            get { return (Int32)lueUnidad.EditValue; }
        }

        public int idCueCon
        {
            set { glueCuenta.EditValue = value; }
            get { return Convert.ToInt32(glueCuenta.EditValue); }
        }

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public string justificacion
        {
            set { txtJustificacion.EditValue = value; }
            get { return txtJustificacion.Text; }
        }

        public decimal precio
        {
            set { sePrecio.EditValue = value; }
            get { return (decimal)sePrecio.EditValue; }
        }
        private string numCuenta;
        public frmRequerimientoBienServicioDet(string numCuenta, RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, RequerimientoBienServicio RequerimientoBienServicio, Form padre) : base(padre, false)
        {
            InitializeComponent();
            Text = "Detalle";
            this.numCuenta = numCuenta;
            this.esModificacion = RequerimientoBienServicioDetalle != null;
            this.requerimientoBienServicioDetPresentador = new RequerimientoBienServicioDetPresentador(RequerimientoBienServicioDetalle, RequerimientoBienServicio, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(glueCuenta, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(sePrecio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtJustificacion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            requerimientoBienServicioDetPresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (requerimientoBienServicioDetPresentador.GuardarDatos())
            {
                if (!esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void sePrecio_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void sbAyudaDescripcion_Click(object sender, EventArgs e)
        {
            using (frmAyudaProducto frm = new frmAyudaProducto(this.numCuenta))
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    requerimientoBienServicioDetPresentador.AsignarProducto(frm.Tag as Producto);
                }
            }
        }
    }
}