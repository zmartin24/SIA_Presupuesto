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
using SIA_Presupuesto.WinForm.General.Helper;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.Vista;
using SIA_Presupuesto.WinForm.Presentador;
using SIA_Presupuesto.WinForm.Recursos;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.Administrador
{
    public partial class frmPeriodo : DevExpress.XtraEditors.XtraForm, IPeriodoVista
    {

        private PeriodoPresentador periodoPres;
        public int Anio
        {
            set
            {
                lueAnio.EditValue = value;
                periodoPres.LlenarDatosMeses();
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public int Mes
        {
            set { lueMes.EditValue = value; }
            get { return Convert.ToInt32(lueMes.EditValue); }
        }

        public List<Mes> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses del año", value);
            }
        }

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }

        public frmPeriodo(PrincipalPresentador principalPresentador)
        {
            InitializeComponent();
            periodoPres = new PeriodoPresentador(this, principalPresentador);
            this.Icon = ImagenHelper.AppIcon;
            sbCambioPeriodo.Image = ImagenHelper.TraerImagen("Period", TamanioImagen.Pequenio16);
        }

        protected override void OnLoad(EventArgs e)
        {
            InicializarValidacion();
            periodoPres.InicializarDatos();
        }

        private void InicializarValidacion()
        {
            dxProveedorValidacion.SetValidationRule(lueMes, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidacion.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                if (XtraMessageBox.Show(Mensajes.PreguntaPeriodoNoAceptado, Mensajes.Pregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (periodoPres.Asignar())
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show(Mensajes.PeriodoNoValido, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else e.Cancel = true;
            }
            else
            {
                if (periodoPres.Asignar())
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    XtraMessageBox.Show(Mensajes.PeriodoNoValido, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            base.OnClosing(e);
        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            if (dxProveedorValidacion.Validate())
            {
                this.DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void sbCambioPeriodo_Click(object sender, EventArgs e)
        {
            //using (frmCambioPeriodoActivo frm = new frmCambioPeriodoActivo())
            //{
            //    if(frm.ShowDialog()== DialogResult.OK)
            //    {
            //        periodoPres.CargarLista();
            //        var ec = frm.Tag as EjercicioContable;
            //        if (ec != null)
            //        {
            //            Anio = ec.anioEjercicio;
            //            Mes = ec.mesEjercicio;
            //        }
            //        //periodoPres.Asignar();
            //    }
            //}
        }
    }
}