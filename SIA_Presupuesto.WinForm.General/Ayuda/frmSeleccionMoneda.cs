using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Presentador;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class frmSeleccionMoneda : frmDialogoBase, IAyudaMonedaVista
    {
        private AyudaMonedaPresentador ayudaMonedaPresentador;

        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 0; }
        }

        public frmSeleccionMoneda(string desPresupuesto, string desSubpresupuesto, string subtitulo )
        {
            InitializeComponent();
            this.ayudaMonedaPresentador = new AyudaMonedaPresentador(this);
            Text = subtitulo;
            this.tePresupuesto.Text = desPresupuesto;
            this.tePresupuesto.ToolTip = desPresupuesto;
            this.teSubPresupuesto.Text = desSubpresupuesto;
            this.teSubPresupuesto.ToolTip = desSubpresupuesto;
            this.lciSubpresupuesto.Visibility = desSubpresupuesto.ToString().Trim().Length > 0 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        protected override void InicializarDatos()
        {
            ayudaMonedaPresentador.InicializarDatos();
        }
        protected override void GuardarDatos()
        {
            ayudaMonedaPresentador.AsignarDatosActual(this);
        }
    }
}
