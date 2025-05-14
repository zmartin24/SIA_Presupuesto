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
using SIA_Presupuesto.WinForm.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System.Net;
using SIA_Presupuesto.WinForm.Recursos;
using SIA_Presupuesto.WinForm.Presentador;
using Seguridad.Modelo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Administrador
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm, ILoginVista
    {
        private readonly LoginPresentador loginPres;

        public string nomUsuario
        {
            get
            {
                return !string.IsNullOrEmpty(txtUsuario.Text) ? txtUsuario.Text : string.Empty;
            }

            set
            {
                txtUsuario.Text = value;
            }
        }

        public string clave
        {
            get
            {
                return !string.IsNullOrEmpty(txtClave.Text) ? txtClave.Text : string.Empty;
            }

            set
            {
                txtClave.Text = value;
            }
        }

        public string IPv4
        {
            get
            {
                string IPv4 = string.Empty;
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily.ToString().Equals("InterNetwork"))
                    {
                        IPv4 = IPA.ToString();
                        break;
                    }
                }

                return !string.IsNullOrEmpty(IPv4) ? IPv4 : string.Empty;
            }
        }
        public string usuarioPC
        {
            get
            {
                string usuario = Environment.UserName.ToUpper();
                return !string.IsNullOrEmpty(usuario) ? usuario : string.Empty;
            }
        }
        public string nombrePC
        {
            get
            {
                string nomPC = Dns.GetHostName();
                return !string.IsNullOrEmpty(nomPC) ? nomPC : string.Empty;
            }
        }

        public frmLogin(PrincipalPresentador principalPresentador)
        {
            InitializeComponent();
            loginPres = new LoginPresentador(this, principalPresentador);
            this.Text = "Inicio de Sesión";
            this.Icon = ImagenHelper.AppIcon;
            this.imaLogin.Image = ImagenHelper.TraerImagen("UserKey", TamanioImagen.Grande32);
        }

        protected override void OnLoad(EventArgs e)
        {
            InicializarValidacion();
            txtUsuario.Text = Properties.Settings.Default.nomUsuario;
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtClave.Focus();
            }
        }

        private void InicializarValidacion()
        {
            dxProveedorValidacion.SetValidationRule(txtClave, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidacion.SetValidationRule(txtUsuario, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginPres.LogearUsuario())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else XtraMessageBox.Show(this.FindForm(), Mensajes.CredencialesInvalidas, Mensajes.ValidacionUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}