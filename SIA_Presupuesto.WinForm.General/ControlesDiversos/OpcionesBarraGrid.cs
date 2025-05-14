using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraBars;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.General.ControlesDiversos
{
    public partial class OpcionesBarraGrid : XtraUserControl, IXtraResizableControl {

        public event EventHandler AgregarRegistro;
        public event EventHandler ModificarRegistro;
        public event EventHandler QuitarRegistro;
        public event EventHandler VisualizarRegistro;
        public event EventHandler OtrosRegistro;
        public event EventHandler MarcarTodos;
        public event EventHandler DesMarcarTodos;
        public event EventHandler NuevoDetalleRegistro;

        GridView vista;
        bool conEdicion = false;
        bool soloLectura = false;
        bool conDetalleAdicional = false;

        private bool conAgregar = true;
        private bool conModificar = true;
        private bool conQuitar = true;
        private bool conOtros = true;
        private bool conVisualizar = false;
        private bool conMarcarTodos = false;
        private bool conDesMarcarTodos = false;
        private bool conNuevoDetalle = false;

        public bool ConAgregar
        {
            get
            {
                return conAgregar;
            }
            set
            {
                conAgregar = value;
                bbiAgregar.Visibility = conAgregar ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        public bool ConVisualizar
        {
            get
            {
                return conVisualizar;
            }
            set
            {
                conVisualizar = value;
                bbiVisualizar.Visibility = conVisualizar ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        public bool ConNuevoDetalle
        {
            get
            {
                return conNuevoDetalle;
            }
            set
            {
                conNuevoDetalle = value;
                bbNuevoDetalle.Visibility = conNuevoDetalle ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        public bool ConMarcarTodos
        {
            get
            {
                return conMarcarTodos;
            }
            set
            {
                conMarcarTodos = value;
                bbiMarcarTodos.Visibility = conMarcarTodos ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        public bool ConDesMarcarTodos
        {
            get
            {
                return conDesMarcarTodos;
            }
            set
            {
                conDesMarcarTodos = value;
                bbiDesmarcarTodos.Visibility = conDesMarcarTodos ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        public bool ConModificar
        {
            get
            {
                return conModificar;
            }
            set
            {
                conModificar = value;
                bbiModificar.Visibility = conModificar ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }
        public bool ConQuitar
        {
            get
            {
                return conQuitar;
            }
            set
            {
                conQuitar = value;
                bbiEliminar.Visibility = conQuitar ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }
        public bool ConOtros
        {
            get
            {
                return conOtros;
            }
            set
            {
                conOtros = value;
                bbiDetalleAdicional.Visibility = conOtros ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }

        private string nombreAgregar;
        private string nombreModificar;
        private string nombreQuitar;
        private string nombreOtros;
        private string nombreNuevoDetalleRegistro;
        private string nombreVisualizar;
        public string NombreAgregar
        {
            get
            {
                return nombreAgregar;
            }
            set
            {
                nombreAgregar = value;
                bbiAgregar.Caption = nombreAgregar;
            }
        }
        public string NombreModificar
        {
            get
            {
                return nombreModificar;
            }
            set
            {
                nombreModificar = value;
                bbiModificar.Caption = nombreModificar;
            }
        }
        public string NombreQuitar
        {
            get
            {
                return nombreQuitar;
            }
            set
            {
                nombreQuitar = value;
                bbiEliminar.Caption = nombreQuitar;
            }
        }
        public string NombreOtros
        {
            get
            {
                return nombreOtros;
            }
            set
            {
                nombreOtros = value;
                bbiDetalleAdicional.Caption = nombreOtros;
            }
        }

        public string NombreNuevoDetalleRegistro
        {
            get
            {
                return nombreNuevoDetalleRegistro;
            }
            set
            {
                nombreNuevoDetalleRegistro = value;
                bbNuevoDetalle.Caption = nombreNuevoDetalleRegistro;
            }
        }
        public string NombreVisualizar
        {
            get
            {
                return nombreVisualizar;
            }
            set
            {
                nombreVisualizar = value;
                bbiVisualizar.Caption = nombreVisualizar;
            }
        }

        public Image ImagenAgregar
        {
            set
            {
                bbiAgregar.Glyph = value;
            }
        }
        public Image ImagenModificar
        {
            set
            {
                bbiModificar.Glyph = value;
            }
        }
        public Image ImagenQuitar
        {
            set
            {
                bbiEliminar.Glyph = value;
            }
        }
        public Image ImagenOtros
        {
            set
            {
                bbiDetalleAdicional.Glyph = value;
            }
        }

        public OpcionesBarraGrid()
        {
            InitializeComponent();

            //ConAgregar = false;
            //ConModificar = false;
            //ConQuitar = false;
            //ConOtros = false;

            NombreAgregar = "Agregar";
            //NombreModificar = "Modificar";
            NombreQuitar = "Quitar";
            //NombreOtros = "Otros";

            bbiAgregar.Glyph = ImagenHelper.TraerImagen("New", TamanioImagen.Pequenio16);
            bbiEliminar.Glyph = ImagenHelper.TraerImagen("Delete", TamanioImagen.Pequenio16);
            bbiModificar.Glyph = ImagenHelper.TraerImagen("Edit", TamanioImagen.Pequenio16);
            bbiDetalleAdicional.Glyph = ImagenHelper.TraerImagen("Refresh", TamanioImagen.Pequenio16);
            bciPermitirEditar.Glyph = ImagenHelper.TraerImagen("Edit", TamanioImagen.Pequenio16);
            bbiVisualizar.Glyph = ImagenHelper.TraerImagen("Views", TamanioImagen.Pequenio16);
            bbiMarcarTodos.Glyph = ImagenHelper.TraerImagen("SelectAllMarked", TamanioImagen.Pequenio16);
            bbiDesmarcarTodos.Glyph = ImagenHelper.TraerImagen("UnmarkAll", TamanioImagen.Pequenio16);
            bbNuevoDetalle.Glyph = ImagenHelper.TraerImagen("New", TamanioImagen.Pequenio16);
        }

        public void SoloLectura()
        {
            bbiAgregar.Enabled = false;
            bbiEliminar.Enabled = false;
            bbiModificar.Enabled = false;
            bbiDetalleAdicional.Enabled = false;
            this.soloLectura = true;
        }

        public void QuitarSoloLectura()
        {
            bbiAgregar.Enabled = true;
            bbiEliminar.Enabled = true;
            bbiModificar.Enabled = true;
            bbiDetalleAdicional.Enabled = true;
            this.soloLectura = false;
        }

        public void HabilitarEditar(bool Enabled)
        {
            bbiModificar.Enabled = Enabled;
        }

        public void HabilitarVisualizar(bool Enabled)
        {
            bbiVisualizar.Enabled = Enabled;
        }

        public void HabilitarEliminar(bool Enabled)
        {
            bbiEliminar.Enabled = Enabled;
        }

        public void HabilitarAgregar(bool Enabled)
        {
            bbiAgregar.Enabled = Enabled;
        }

        public void HabilitarNuevoDetalle(bool Enabled)
        {
            bbNuevoDetalle.Enabled = Enabled;
        }

        public void CambiarNombreBotonOtros(string nombreNuevo)
        {
            bbiDetalleAdicional.Caption = nombreNuevo;
        }

        public void InicializarOCS(GridView vista)
        {
            this.vista = vista;


            bciPermitirEditar.Checked = vista.OptionsBehavior.Editable;
          
            bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
           
            bbiModificar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
            bbiAgregar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
            bbiEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
            bbiDetalleAdicional.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);
        }

        public void InicializarOCDocVizualiza(GridView vista)
        {
            this.vista = vista;

            bciPermitirEditar.Checked = vista.OptionsBehavior.Editable;

            bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiModificar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiAgregar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            bbiEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiDetalleAdicional.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);

        }

        public void InicializarOCEdit(GridView vista)
        {
            this.vista = vista;

            bciPermitirEditar.Checked = vista.OptionsBehavior.Editable;

            bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiModificar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            bbiAgregar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            bbiEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            bbiDetalleAdicional.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            bbiVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);

        }

        public void Inicializar(GridView vista)
        {
            this.vista = vista;
            bciPermitirEditar.Checked = vista.OptionsBehavior.Editable;
            this.conEdicion = true;
            this.conDetalleAdicional = true;
            bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);
            SoloLectura();
        }

        public void Inicializar(GridView vista, bool conEdicion, bool conDetalleAdicional) 
        {
            this.vista = vista;

            
            bciPermitirEditar.Checked = vista.OptionsBehavior.Editable;
            this.conEdicion = conEdicion;
            this.conDetalleAdicional = conDetalleAdicional;
            bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (!conEdicion)
            {
                bbiModificar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                InicializarBotones(conEdicion);
                EstablecerOpcionesGrid();
            }

            //if (!conEliminacion)
            //{
            //    bbiEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}

            if (!conDetalleAdicional)
                bbiDetalleAdicional.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //else 
            //{ 
            //    bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; 
            //}

            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);

            
        }

        internal void MostrarTituloBotones()
        {
            //bbiAgregar
        }

        protected override void OnLoad(EventArgs e) 
        {
            base.OnLoad(e);
            RaiseChanged();
        }

        public void SoloNuevoDetalle(bool enabled)
        {
            bbiModificar.Enabled = !enabled;
            bbNuevoDetalle.Enabled = enabled;
            bbiEliminar.Enabled = !enabled;
        }

        public void PermitirEditar(bool permitir) 
        {
            bciPermitirEditar.Checked = permitir;
        }

        private void view_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            InicializarBotones(conEdicion);
        }

        private void InicializarBotones(bool des)
        {
            if (!conEdicion)
            {
                bbiAgregar.Enabled = bciPermitirEditar.Checked;
                bbiModificar.Enabled = bciPermitirEditar.Checked && vista.GetRow(vista.FocusedRowHandle) != null;
                bbiEliminar.Enabled = bciPermitirEditar.Checked && vista.GetRow(vista.FocusedRowHandle) != null;
            }
            else
            {
                if (!this.soloLectura)
                {
                    bbiEliminar.Enabled = vista.GetRow(vista.FocusedRowHandle) != null;
                    bbiModificar.Enabled = vista.GetRow(vista.FocusedRowHandle) != null;
                }
            }
        }

        private void EstablecerOpcionesGrid()
        {
            vista.OptionsBehavior.Editable = bciPermitirEditar.Checked;
            vista.OptionsView.ShowIndicator = bciPermitirEditar.Checked;
            foreach (GridColumn columna in vista.Columns)
                columna.OptionsColumn.AllowFocus = bciPermitirEditar.Checked;
        }

        internal void DesabilitarBotones() {
            bbiAgregar.Enabled = bbiModificar.Enabled = bbiEliminar.Enabled = bciPermitirEditar.Enabled = false;
        }

        private void bciPermitirEditar_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InicializarBotones(conEdicion);
            EstablecerOpcionesGrid();
        }

        private void bbiEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (QuitarRegistro != null) QuitarRegistro(this, e);
        }

        private void bbiMarcarTodos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MarcarTodos != null) MarcarTodos(this, e);
        }

        private void bbiDesmarcarTodos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DesMarcarTodos != null) DesMarcarTodos(this, e);
        }

        private void bbiAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AgregarRegistro != null) AgregarRegistro(this, e);
        }

        private void bbiModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ModificarRegistro != null) ModificarRegistro(this, e);
        }

        private void bbNuevoDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NuevoDetalleRegistro != null) NuevoDetalleRegistro(this, e);
        }

        private void bbiDetalleAdicional_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (OtrosRegistro != null) OtrosRegistro(this, e);
        }

        private void bbiVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VisualizarRegistro != null) VisualizarRegistro(this, e);
        }

        #region Miembros de IXtraResizableControl 

        public event EventHandler Changed;

        protected virtual void RaiseChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        public bool IsCaptionVisible
        {
            get { return false; }
        }

        public Size MaxSize
        {
            get { return new Size(3000, AlturaControl); }
        }
        public Size MinSize
        {
            get { return new Size(170, AlturaControl); }
        }

        private int AlturaControl
        {
            get
            {
                if (BarraPrincipal == null || BarraPrincipal.Size.IsEmpty || BarraPrincipal.Size.Height == 0)
                    return 25;
                return BarraPrincipal.Size.Height;
            }
        }


        #endregion

       
    }
}
