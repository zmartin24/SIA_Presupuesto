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
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmImprimirPac : frmDialogoBase, IImprimirPacVista
    {
        private ImprimirPacPresentador ImprimirPacPresentador;

        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }

        public int idDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }
        public List<FuenteFinanciamiento> listaFinanciamiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFueFin.Properties, "idFueFin", "fuente", "Fuente", value);
            }
        }

        public int idFueFin
        {
            set
            {
                lueFueFin.EditValue = value;
            }
            get { return Convert.ToInt32(lueFueFin.EditValue); }
        }

        public List<Predeterminado> listaReporte
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueReporte.Properties, "codigo", "descripcion", "Direcciones", value);
            }
        }

        public string codReporte
        {
            set
            {
                lueReporte.EditValue = value;
            }
            get { return Convert.ToString(lueReporte.EditValue); }
        }

        public frmImprimirPac(PlanAnualAdquisicion planAnualAdquisicion)
        {
            InitializeComponent();
            this.ImprimirPacPresentador = new ImprimirPacPresentador(planAnualAdquisicion, this);
            Text = "Reportes Plan Anual de Adquisiciones y Contrataciones";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueDireccion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueReporte, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            ImprimirPacPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            List<object> lista = new List<object>();
            lista = ImprimirPacPresentador.ListaReporte();
            if (lista.Count > 0)
            {
                ImprimirPacPresentador.Imprimir(lista);
                this.DialogResult = DialogResult.No;
            }
            else
                EmitirMensajeResultado(true, "Consulta no generó datos");
            //ImprimirPacPresentador.RequerimientoPorDireccion();
            
        }

        private void lueReporte_EditValueChanged(object sender, EventArgs e)
        {
            if (codReporte.Equals("01"))
            {
                lciDireccion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciDireccion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }
    }
}