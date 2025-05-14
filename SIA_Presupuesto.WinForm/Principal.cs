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
using DevExpress.XtraBars.Docking2010.Views;
using SIA_Presupuesto.WinForm.Presentador;
using DevExpress.XtraBars;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Recursos;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Helper;
using DevExpress.XtraNavBar;
using SIA_Presupuesto.WinForm.Administrador;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;

namespace SIA_Presupuesto.WinForm
{
    public partial class Principal : DevExpress.XtraEditors.XtraForm, IPrincipalVista
    {
        private PrincipalPresentador principalPresentador;
        IDictionary<object, BaseDocument> documentos = new Dictionary<object, BaseDocument>();

        public IDictionary<object, BaseDocument> Documentos
        {
            get { return documentos; }
        }

        public string nomUsuario
        {
            set
            {
                this.tsslUsuario.Text = value;
            }
        }

        public string Periodo
        {
            set
            {
                this.tssbPeriodo.Text = value;
            }
        }

        public string PeriodoActivo
        {
            set
            {
                this.tsslPeriodoActivo.Text = value;
            }
        }

        public PopupMenu PopupMenu
        {
            get { return pmExportacion; }
        }

        public PrincipalPresentador PrincipalPresentador
        {
            get { return principalPresentador; }
        }

        public Principal()
        {
            InitializeComponent();

            principalPresentador = new PrincipalPresentador(this);
            this.Icon = ImagenHelper.AppIcon;

            //this.bbiPeriodo.LargeGlyph = ImagenHelper.TraerImagen("Period", TamanioImagen.Grande32);
            //this.bbiPeriodo.Glyph = ImagenHelper.TraerImagen("Period", TamanioImagen.Pequenio16);

            tvVista.DocumentAdded += tabbedView_DocumentAdded;
            tvVista.DocumentRemoved += tabbedView_DocumentRemoved;

        }

        #region Logeo y Periodo
        protected override void OnShown(EventArgs e)
        {
            //Abrimos Login de Usuario
            Type tipo = typeof(frmLogin);
            using (frmLogin frm = new frmLogin(this.principalPresentador))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.principalPresentador.AsignarUsuario();
                    ActualizarPeriodo();
                    nbcMenuPrincipal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                }
                else
                    Application.Exit();
            }
        }

        private void ActualizarPeriodo()
        {
            using (frmPeriodo frmPer = new frmPeriodo(this.principalPresentador))
            {
                if (frmPer.ShowDialog() == DialogResult.OK)
                {
                    this.principalPresentador.AsignarPeriodo();
                    //this.principalPresentador.AsignarPeriodoActivo();
                    if (!menuActualizado) CargarMenu();
                }
            }
        }

        #endregion

        #region Menu y sus acciones

        bool menuActualizado = false;
        private void CargarMenu()
        {
            RegistroReporteHelper.CargarModulos();
            RegistroModuloHelper.CargarModulos();
            var listaMenu = this.principalPresentador.TraerMenuUsuario();
            //this.nbcMenuPrincipal.Items.Clear();
            //Provisional
            MenuHelper.CargarMenu(this.nbcMenuPrincipal, listaMenu.Where(w => w.idDependencia != 167 || w.idMenu == 167 || w.idMenu == 1214).ToList());
            this.nbcMenuPrincipal.LinkClicked += new NavBarLinkEventHandler(navBar_LinkClicked);
            menuActualizado = true;
        }

        private void navBar_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Seguridad.Modelo.Menu modulo = e.Link.Item.Tag as Seguridad.Modelo.Menu;
            if (!string.IsNullOrEmpty(modulo.rutaWeb) && !string.IsNullOrWhiteSpace(modulo.rutaWeb) &&
                string.IsNullOrEmpty(modulo.control) && string.IsNullOrWhiteSpace(modulo.control))
            {
                System.Diagnostics.Process.Start(modulo.rutaWeb);
            }
            else
            {
                if (Convert.ToBoolean(modulo.esPopup))
                    AbrirFormularioPopup(modulo);
                else
                    AbrirFormulario(modulo);
            }
        }

        private void nbcMenuPrincipal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //    Seguridad.Modelo.Menu modulo = e.Link.Item.Tag as Seguridad.Modelo.Menu;
            //    if (!string.IsNullOrEmpty(modulo.rutaWeb) && !string.IsNullOrWhiteSpace(modulo.rutaWeb) &&
            //        string.IsNullOrEmpty(modulo.control) && string.IsNullOrWhiteSpace(modulo.control))
            //    {
            //        System.Diagnostics.Process.Start(modulo.rutaWeb);
            //    }
            //    else
            //    {
            //        if (Convert.ToBoolean(modulo.esPopup))
            //            AbrirFormularioPopup(modulo);
            //        else
            //            AbrirFormulario(modulo);
            //    }
        }

        public void AbrirFormulario(Seguridad.Modelo.Menu menuHelper)
        {
            BaseDocument documento = null;
            if (!Documentos.TryGetValue(menuHelper, out documento))
            {
                FormBase frm = MenuHelper.AbrirFormulario(menuHelper, this);
                if (tvVista.Documents.TryGetValue(frm, out documento))
                {
                    documento.Caption = menuHelper.titulo;
                }
                //CambiarPagina();
            }
            else tvVista.Controller.Activate(documento);
        }

        public void AbrirFormularioPopup(Seguridad.Modelo.Menu menuHelper)
        {
            frmDialogo frm = MenuHelper.NuevoMenuPopup(menuHelper, this);
            frm.ShowDialog();
        }

        private void RegistrarDocumento(BaseDocument documento)
        {
            FormBase frm = documento.Form as FormBase;

            if (frm != null)
            {
                //frm.CambiarPrincipal = true;
                Documentos.Add(frm.MenuModulo.MenuSistema, documento);
            }
        }

        private void QuitarregistroDocumento(BaseDocument documento)
        {
            FormBase frm = documento.Form as FormBase;

            if (frm != null)
            {
                //frm.CambiarPrincipal = false;
                tvVista.Controller.RemoveDocument(documento);
                Documentos.Remove(frm.MenuModulo.MenuSistema);
                //frm.Dispose();
            }
        }

        private void tabbedView_DocumentAdded(object sender, DocumentEventArgs e)
        {
            RegistrarDocumento(e.Document);
        }

        private void tabbedView_DocumentRemoved(object sender, DocumentEventArgs e)
        {
            QuitarregistroDocumento(e.Document);
        }

        #endregion

        private void ActualizarPeriodoProc()
        {
            bool res = true;
            if (Documentos.Count > 0)
                res = XtraMessageBox.Show(this.FindForm(),
                    Mensajes.AdvertenciaCierreModulos, Mensajes.Pregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;

            if (res)
            {
                tvVista.Controller.CloseAll();
                Documentos.Clear();
                ActualizarPeriodo();
            }
        }

        private void tssbPeriodo_ButtonClick(object sender, EventArgs e)
        {
            ActualizarPeriodoProc();
        }
    }
}