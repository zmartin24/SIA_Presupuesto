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
    public partial class frmAyudaPrecioProducto : frmDialogoBaseAyuda, IAyudaPrecioProductoVista
    {
        private AyudaPrecioProductoPresentador ayudaPrecioProductoPresentador;

        public object listaDatosPrincipales
        {
            set
            {
                grcSubPresupuestoDet.DataSource = value;
            }
        }
        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public int anioPresentacion
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }

        private bool inicio = false;

        public bool Inicio
        {
            get { return inicio; }
            set { value = inicio; }
        }

        public frmAyudaPrecioProducto(ForeDetallePoco foreDetallePoco, tipoAyudaFore tipo)
        {
            InitializeComponent();
            this.ayudaPrecioProductoPresentador = new AyudaPrecioProductoPresentador(foreDetallePoco, tipo, this);
            Text = "Lista de Precios";
        }

        protected override ColumnView Vista { get { return grcSubPresupuestoDet.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcSubPresupuestoDet.MainView as ColumnView; } }

        public object DatoActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as object;
            }
        }

        protected override void Inicializar()
        {
            base.Inicializar();
            ayudaPrecioProductoPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            ayudaPrecioProductoPresentador.CargarLista();
            inicio = true;
        }

        public override void SelecionarItem()
        {
            ayudaPrecioProductoPresentador.AsignarDatosActual(this);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void obgsSeleccion_AnteriorRegistro(object sender, EventArgs e)
        {
            Anterior();
        }
        private void obgsSeleccion_SeleccionarRegistro(object sender, EventArgs e)
        {
            SelecionarItem();
        }
        private void obgsSeleccion_SiguienteRegistro(object sender, EventArgs e)
        {
            Siguiente();
        }
        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio != null && inicio)
            {
                ayudaPrecioProductoPresentador.CargarLista();
                inicio = true;
            }
        }
    }
}