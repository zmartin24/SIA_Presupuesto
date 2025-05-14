using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
using SIA_Presupuesto.WinForm.General.Helper;
using DevExpress.XtraEditors;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Vistas;
using SIA_Presupuesto.WinForm.General.Presentador;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.General.Base
{
    public partial class FormBase : DevExpress.XtraBars.Ribbon.RibbonForm, IFormBaseVista
    {
        private FormBasePresentador formBasePresentador;
        public RibbonControl RibbonControl { get { return rcOpcion; } }
        //public IDXMenuManager MenuManager { get { return rcOpcion.Manager; } }
        public PopupMenu PmExportacion { get { return this.pmExportacion; } }

        private PopupMenu pmExpotacionPrincipal;
        public PopupMenu PmExportacionPrinciipal { get { return this.pmExpotacionPrincipal; } }

        private MenuModulo menuModulo;
        private OpcionHelper opcionHelper;
        public MenuModulo MenuModulo { get { return menuModulo; } }
        public OpcionHelper OpcionHelper { get { return opcionHelper; } }

        private RibbonControl RibbonOpciones;
        public RibbonControl RibbonControlPrincipal
        {
            get { return RibbonOpciones; }
        }

        public int Anio
        {
            get { return formBasePresentador.Anio;  }
            set { formBasePresentador.Anio = value;  }

        }
        public int Mes
        {
            get { return formBasePresentador.Mes; }
            set { formBasePresentador.Mes = value;  }
        }

        public int IdTipCam
        {
            get { return formBasePresentador.IdTipCam; }
            set { formBasePresentador.IdTipCam = value; }
        }

        public int IdMoneda
        {
            get { return formBasePresentador.IdMoneda; }
            set { formBasePresentador.IdMoneda = value; }
        }

        public string Parametro
        {
            get { return formBasePresentador.Parametro; }
            set { formBasePresentador.Parametro = value; }
        }

        public UsuarioOperacion Usuario
        {
            get { return formBasePresentador.UsuarioOperacion; }
            set { formBasePresentador.UsuarioOperacion = value; }
        }

        //public EjercicioContable EjercicioContable
        //{
        //    get { return formBasePresentador.EjercicioContable; }
        //    set { formBasePresentador.EjercicioContable = value; }
        //}

        public FormBase(MenuModulo menuModulo, RibbonControl RibbonOpciones, PopupMenu pmExpotacionPrincipal)
        {
            InitializeComponent();
            formBasePresentador = new FormBasePresentador(this);
            this.menuModulo = menuModulo;
            this.RibbonOpciones = RibbonOpciones;
            this.pmExpotacionPrincipal = pmExpotacionPrincipal;
            Parametro = this.menuModulo.MenuSistema.parametros;

            CargarOpciones();
            ToolTipController.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            this.Text = menuModulo.MenuSistema.titulo.ToUpper();
            this.Icon = ImagenHelper.AppIcon;
        }

        private void CargarOpciones()
        {
            opcionHelper = new OpcionHelper(this);
        }

        public void InicilizarModulo()
        {
            MostrarModulo(pnlControl);
            OpcionHelper.AsignarEventoMenuRibbonPadre();
            //OpcionHelper.AsignarEventoMenuRibbonPadre(MdiParent != null);
        }

        protected void MostrarModulo(PanelControl padre)
        {
            ControlUsuarioHelper.MostrarModulo(this, padre);
        }

        //Evento de paginas ribon
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
        }

    }
}