using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using SIA_Presupuesto.WinForm.General.Recursos;
using DevExpress.XtraBars.Ribbon;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraBars;
using Seguridad.Modelo;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;
using System.Collections;
using SIA_Presupuesto.WinForm.General.ControlesDiversos;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraPivotGrid;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.General.Base
{
    public delegate void EventoCerrarFormularioDetalle(DialogResult resultado, object objetoActual);
    public partial class ControlDetalleBase : DevExpress.XtraEditors.XtraUserControl
    {

        public ControlDetalleBase()
        {
            InitializeComponent();
        }
        //public ControlDetalleBase(CerrarFormularioDetalle cerrarFormulario)
        //    :this()
        //{
        //    this.cerrarFormulario = cerrarFormulario;
        //}

        #region Propiedad

        public int Anio { get { return controlBase!=null ? controlBase.Anio : 0; } }
        public int Mes { get { return controlBase != null ? controlBase.Mes : 0; } }
        public int IdMoneda { get { return controlBase != null ? controlBase.IdMoneda : 0; } }
        public int IdTipCam { get { return controlBase != null ? controlBase.IdTipCam : 0; } }

        public UsuarioOperacion UsuarioOperacion { get { return controlBase.UsuarioOperacion; } }

        //public EjercicioContable EjercicioContable { get { return controlBase!=null ? controlBase.EjercicioContable : null; } }

        private Guid id = Guid.Empty;

        private int codigo = 0;
        public Guid ID { get { return id; } }
        private bool ocupado = false;
        public virtual bool Ocupado
        {
            get
            {
                return ocupado;
            }
            set
            {
                ocupado = value;
                //ActualizarTituloPaginaRibbonActivo();
            }
        }

        public int Codigo { get { return codigo; } }

        private EventoCerrarFormularioDetalle eventoCerrarFormulario = null;
        public EventoCerrarFormularioDetalle EventoCerrarFormulario
        {
            set { this.eventoCerrarFormulario = value; }
        }

        private ControlBase controlBase;

        public ControlBase ControlPadre
        {
            set {
                this.controlBase = value;
                //this.eventoCerrarFormulario = this.controlBase.EventoCerrarControlDetalle;
            }
        }
      
        protected bool esSoloListado = false;
        private bool soloLectura = false;

        public bool SoloLectura
        {
            get { return soloLectura; }
            set
            {
                soloLectura = value;
                ActualizarDatosSoloLectura();
            }
        }

        protected bool esModificacion = false;
        protected DXValidationProvider ProveedorValidacion { get { return dxProveedorValidacion; } }

        protected DialogResult retornarResultado = DialogResult.Cancel;

        #endregion

        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LlenarLookUpGenerales();
            InicializarDatos();
            LlenarGrid();
            InicializarValidacion();

            //Periodo Cerrado activa Solo lectura
            //this.SoloLectura = this.EjercicioContable != null ? this.EjercicioContable.cerrado : false;

            //if (padre != null)
            //    this.Location = new Point(padre.Left + (padre.Width - this.Width) / 2, padre.Top + (padre.Height - this.Height) / 2);
            //CargarDiseniadorFormulario();
            //EstablecerOpcionesPredeterminadas();
            //foreach (Control item in lcMain.Controls)
            //{
            //    AgregarControl(item);
            //}
        }

        #endregion

        #region Operaciones

        protected virtual void LlenarGrid() { }

        protected virtual void CerrarFormularioCancelar() { }

        protected virtual void CerrarFormulario() { }

        protected virtual void InicializarValidacion() { }

        protected virtual void InicializarDatos() { }

        protected virtual void LlenarLookUpGenerales() { }

        protected virtual void GuardarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        protected virtual void Nuevo()
        {
        }

        protected virtual void NuevoMultiple()
        {
        }

        protected virtual void Modificar()
        {
        }

        protected virtual void Anular()
        {

        }

        protected internal virtual void Actualizar()
        {
            Cursor.Current = Cursors.WaitCursor;
            LlenarGrid();
            Cursor.Current = Cursors.Default;
        }

        protected virtual bool ValidarDatos() { return ProveedorValidacion.Validate(); }

        protected virtual void OtrasOperaciones(string nomOperacion) { }

        public void RealizarOtrasOperaciones(string nomOperacion)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.OtrasOperaciones(nomOperacion);
            Cursor.Current = Cursors.Default;
        }

        public void RealizarNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Nuevo();
            Cursor.Current = Cursors.Default;
        }

        public void RealizarModificacion()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Modificar();
            Cursor.Current = Cursors.Default;
        }

        public void RealizarAnulacion()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Anular();
            Cursor.Current = Cursors.Default;
        }

        protected virtual void ActualizarDatosSoloLecturaFrontal()
        {

        }

        protected virtual void ConvertirModificacion() { this.esModificacion = true; }
        protected internal virtual bool Exportar()
        {
            return false;
        }

        //Cierre 
        private void Antes_CerrarModulo() //cierra  celdas en edición
        {
            foreach (Control ctrl in lcPrincipal.Controls)
            {
                GridControl grid = ctrl as GridControl;
                if (grid != null)
                {
                    ColumnView vista = grid.MainView as ColumnView;
                    if (vista == null) continue;
                    vista.CloseEditor();
                    vista.UpdateCurrentRow();
                }
            }
            Durante_CierreModulo();
        }

        protected virtual void Durante_CierreModulo()
        {

        }

        public void CerrarSinPreguntar()
        {
            Antes_CerrarModulo();

            Cursor.Current = Cursors.Default;

            //Ejecuta evento cuando cierra el formulario detalle
            if (eventoCerrarFormulario != null) eventoCerrarFormulario(retornarResultado, new object());
            this.Dispose();
        }

        public void Cerrar()
        {
            Antes_CerrarModulo();

            if (retornarResultado != DialogResult.OK)
            {
                if (/*mostrarDialogoCerrar &&*/ !soloLectura)
                {
                    DialogResult resultado = DialogResult.Yes;
                    if (!esSoloListado)
                        resultado = XtraMessageBox.Show(this, Mensajes.CerrarFormularioAdvertenciaCancelar, Mensajes.Advertencia, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (resultado == DialogResult.Cancel) return;
                    if (resultado == DialogResult.Yes)
                    {
                        if (!Guardar())
                            return;
                    }
                }
                else
                {
                    //Cancelar_CerrarFormulario();
                }
            }
            else
                CerrarFormulario();

            Cursor.Current = Cursors.Default;

            //Ejecuta evento cuando cierra el formulario detalle
            if (eventoCerrarFormulario != null) eventoCerrarFormulario(retornarResultado, new object());
            this.Dispose();
        }
        //protected virtual void Cancelar_CerrarFormulario() { }

        //Guardado de datos
        public bool Guardar()
        {
            Antes_CerrarModulo();

            if (this.soloLectura)
            {
                retornarResultado = DialogResult.Yes;
                return true;
            }

            if (ValidarDatos())
            {
                retornarResultado = DialogResult.Yes;
                GuardarDatos();
                if (retornarResultado != DialogResult.Yes) return false;
                //Sucio = false;
                ConvertirModificacion();
                return true;
            }
            return false;
        }

        public bool GuardarCerrar()
        {
            if (Guardar())
            {
                retornarResultado = DialogResult.OK;
                Cerrar();
                return true;
            }
            return false;
        }

        protected internal virtual void EmitirMensajeResultado(bool resultado, string mensaje)
        {
            if (resultado)
            {
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGrid();
            }
            else
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        protected internal virtual bool EmitirMensajePregunta(string mensaje)
        {
            bool resultado = false;
            resultado = XtraMessageBox.Show(this.FindForm(),
                mensaje, Mensajes.Pregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            return resultado;
        }

        /** Solo lectura **/

        static bool EstaVacio(RibbonPageGroup grupo)
        {
            foreach (BarButtonItemLink link in grupo.ItemLinks)
                if (link.Visible) return false;
            return true;
        }

        static void ActualizarLinksItem(RibbonPageGroup grupo, bool SoloLectura)
        {
            foreach (BarButtonItemLink link in grupo.ItemLinks)
                if ("ReadOnly".Equals(link.Item.Tag))
                    link.Visible = !SoloLectura;
        }

        protected virtual void ActualizarDatosSoloLectura()
        {
            if (pagina != null)
            {
                foreach (RibbonPageGroup grupo in pagina.Groups)
                {
                    ActualizarLinksItem(grupo, SoloLectura);
                    grupo.Visible = !EstaVacio(grupo);
                }
            }

            //EstablecerOpcionesPredeterminadas();

            if (SoloLectura)
            {
                RecorrerSoloLectura(lcPrincipal.Controls);
                ActualizarDatosSoloLecturaFrontal();
                //PaginaRibbonActivo.Text = string.Format(Mensajes.SoloLecturaCebecera);
                //PaginaRibbonActivo.Text = string.Format(Mensajes.SoloLecturaCebecera, PaginaRibbonActivo.Text);
            }

            ActualizarRibbonSoloLectura(SoloLectura);
        }

        private void ActualizarRibbonSoloLectura(bool sololect)
        {
            foreach (RibbonPageGroup grupos in pagina.Groups)
            {
                foreach (BarButtonItemLink item in grupos.ItemLinks)
                {

                    Opcion opc = item.Item.Tag as Opcion;
                    if (opc != null)
                        if (sololect)
                        {
                            if (!(bool)opc.soloLectura)
                            {
                                item.Item.Visibility = BarItemVisibility.Never;
                            }
                            else
                                item.Item.Visibility = BarItemVisibility.Always;
                        }
                        else
                            item.Item.Visibility = BarItemVisibility.Always;
                }
            }

        }

        private void RecorrerSoloLectura(ControlCollection coleccion)
        {
            foreach (Control item in coleccion)
            {
                BaseEdit be = item as BaseEdit;
                if (be != null) be.Properties.ReadOnly = true;

                BaseButton bb = item as BaseButton;
                if (bb != null) bb.Enabled = false;

                OpcionesBarraGrid obg = item as OpcionesBarraGrid;
                if (obg != null)
                    obg.SoloLectura();

                OpcionesBarraGridMarcar obgm = item as OpcionesBarraGridMarcar;
                if(obgm != null)
                    obgm.SoloLectura();

                OpcionesBarraGridSeleccion obgs = item as OpcionesBarraGridSeleccion;
                if (obgs != null)
                    obgs.SoloLectura();

                if (item.Controls.Count > 0)
                    RecorrerSoloLectura(item.Controls);

                GridControl  g = item as GridControl;
                if (g != null)
                {
                    foreach (var v in g.Views)
                    {
                        GridView gv = v as GridView;
                        if (gv != null)
                        {
                            
                            foreach (GridColumn columna in gv.Columns)
                            {
                                columna.OptionsColumn.AllowEdit = false;
                            }
                        }

                        BandedGridView gv1 = v as BandedGridView;
                        if (gv1 != null)
                        {
                            foreach (GridColumn columna in gv1.Columns)
                            {
                                columna.OptionsColumn.AllowEdit = false;
                            }
                        }
                    }
                }

                //Bar bi = item as Bar;
                //if (bi != null) bi.Enabled = false;
            }
        }

        #endregion

        #region Grid Detalle

        protected virtual ColumnView ColumnaActual { get { return null; } }
        protected virtual ColumnView VistaActual { get { return ColumnaActual; } }
        protected virtual GridControl GridPrincipal { get { return null; } }

        protected virtual BaseView VistaExportar { get { return VistaActual; } }
        protected virtual PivotGridControl PivotGridPrincipal { get { return null; } }
        protected virtual bool ExportarDePivot { get { return false; } }

        protected virtual string ExportFileName { get { return "Sin_Nombre"; } }

        protected internal virtual void Siguiente()
        {
            VistaActual.FocusedRowHandle++;
        }

        protected internal virtual void Anterior()
        {
            VistaActual.FocusedRowHandle--;
        }

        public IList listaSplash { get; set; }

        protected virtual void EjecutarCargarConSplash()
        {

        }

        protected virtual void CargarDatosConSplash()
        {
            Thread hilo = new Thread(new ThreadStart(this.EjecutarCargarConSplash));
            hilo.Start();

            while (!hilo.IsAlive) ;

            Splash splash = new Splash(hilo, Mensajes.CargaDatos);
            splash.ShowDialog();
            splash.Dispose();

            GridPrincipal.DataSource = listaSplash;
        }

        #endregion

        #region Generación de detalle de opciones

        //Pagina del detalle
        private RibbonPage pagina = null;

        public RibbonPage PaginaRibbonActivo
        {
            get { return pagina; }
        }

        //Titulo de detalle
        public string TituloPagina
        {
            get
            {
                int maxLength = 70;
                if (Text.Length <= maxLength)
                    return Text;
                return string.Format("{0}...", Text.Substring(0, maxLength));
            }
        }

        //Se toma como base el ribon del control principal
        public void CrearPaginaRibbonActivo(RibbonPage pagina)
        {
            this.pagina = pagina.Clone() as RibbonPage;
            ActualizarTituloPaginaRibbonActivo();
            PaginaRibbonActivo.Tag = this;
            pagina.Ribbon.Pages.Add(PaginaRibbonActivo);
            pagina.Category.Pages.Add(PaginaRibbonActivo);
            //OcultarOpciones(pagina);

        }

        //private void OcultarOpciones(RibbonPage pagina)
        //{
        //    if (pagina.Tag.Equals("frmGenerarAsiento"))
        //    {
        //        foreach (var Item in pagina.Ribbon.Items)
        //        {
        //            BarButtonItem ItemBoton = Item as BarButtonItem;
        //            if (ItemBoton != null)
        //            {
        //                var opc = ItemBoton.Tag as Opcion;
        //                if (opc != null)
        //                {
        //                    if (opc.esParaDetalle)
        //                    {
        //                        if (ItemBoton.Name.ToUpper().Equals("BBIGUARDAR") || ItemBoton.Name.ToUpper().Equals("BBIGUARDARCERRAR"))
        //                        {
        //                            ItemBoton.Visibility = BarItemVisibility.Always;
        //                        }
        //                        else
        //                            if (ItemBoton.Name.ToUpper().Equals("BBICERRAR"))
        //                            ItemBoton.Visibility = BarItemVisibility.Always;
        //                        else
        //                            ItemBoton.Visibility = BarItemVisibility.Never;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    else if (pagina.Tag.Equals("frmDocumento"))
        //    {
        //        foreach (var Item in pagina.Ribbon.Items)
        //        {
        //            BarButtonItem ItemBoton = Item as BarButtonItem;
        //            if (ItemBoton != null)
        //            {
        //                var opc = ItemBoton.Tag as Opcion;
        //                if (opc != null)
        //                {

        //                    if (opc.esParaDetalle)
        //                    {
        //                        if (ItemBoton.Name.ToUpper().Equals("BBIGUARDAR") || ItemBoton.Name.ToUpper().Equals("BBIGUARDARCERRAR"))
        //                        {
        //                            ItemBoton.Visibility = BarItemVisibility.Never;
        //                        }
        //                        else
        //                            ItemBoton.Visibility = BarItemVisibility.Always;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    else 
        //        foreach (var Item in pagina.Ribbon.Items)
        //        {
        //            BarButtonItem ItemBoton = Item as BarButtonItem;
        //            if (ItemBoton != null)
        //            {
        //                ItemBoton.Visibility = BarItemVisibility.Always;
        //            }
        //        }

        //}

        //Actualiza el nombre de la pagina
        public void ActualizarTituloPaginaRibbonActivo()
        {
            if (PaginaRibbonActivo == null) return;
            PaginaRibbonActivo.Text = string.Format("{0}{1}", TituloPagina, this.Ocupado ? "*" : string.Empty);
        }

        #endregion  

        protected override void Dispose(bool disposing)
        {
            if (disposing /*&& (components != null)*/)
            {
                //components.Dispose();
                if (PaginaRibbonActivo != null)
                    PaginaRibbonActivo.Dispose();
            }
            base.Dispose(disposing);
        }
        private void Exportar(string extension, string filtro)
        {
            string fileName = ElementoHelper.ObtenerNombreArchivo(string.Format("*.{0}", extension), filtro, ElementoHelper.ObtenerPosibleNombreArchivo(ExportFileName));
            if (!String.IsNullOrEmpty(fileName))
                try
                {
                    RealizarExportacion(fileName, extension);
                    ElementoHelper.AbrirArchivo(fileName);
                }
                catch
                {
                    FinalizarExportacion();
                    ElementoHelper.MostrarErrorExportacion();
                }
        }
        private void RealizarExportacion(String nombreArchivo, string extension)
        {
            if (VistaExportar == null && PivotGridPrincipal == null) return;

            if (ExportarDePivot)
            {
                PivotGridPrincipal.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
                PivotGridPrincipal.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
                PivotGridPrincipal.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            }

            IniciarExportacion();
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            switch (extension)
            {
                case "rtf": if (ExportarDePivot) PivotGridPrincipal.ExportToRtf(nombreArchivo); else VistaExportar.ExportToRtf(nombreArchivo); break;
                case "pdf": if (ExportarDePivot) PivotGridPrincipal.ExportToPdf(nombreArchivo); else VistaExportar.ExportToPdf(nombreArchivo); break;
                case "mht": if (ExportarDePivot) PivotGridPrincipal.ExportToMht(nombreArchivo); else VistaExportar.ExportToMht(nombreArchivo); break;
                case "html": if (ExportarDePivot) PivotGridPrincipal.ExportToHtml(nombreArchivo); else VistaExportar.ExportToHtml(nombreArchivo); break;
                case "txt": if (ExportarDePivot) PivotGridPrincipal.ExportToText(nombreArchivo); else VistaExportar.ExportToText(nombreArchivo); break;
                case "xls":
                    var pivotExportOptions1 = new DevExpress.XtraPivotGrid.PivotXlsExportOptions();
                    pivotExportOptions1.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    pivotExportOptions1.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                    if (ExportarDePivot) PivotGridPrincipal.ExportToXls(nombreArchivo, pivotExportOptions1); else VistaExportar.ExportToXls(nombreArchivo); break;
                case "xlsx":
                    var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
                    pivotExportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    pivotExportOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                    if (ExportarDePivot) PivotGridPrincipal.ExportToXlsx(nombreArchivo, pivotExportOptions); else VistaExportar.ExportToXlsx(nombreArchivo); break;
            }

            Cursor.Current = currentCursor;
            FinalizarExportacion();
        }
        protected virtual void IniciarExportacion()
        {

        }

        protected virtual void FinalizarExportacion()
        {
        }
        protected internal virtual void ExportarPDF()
        {
            Exportar("pdf", Mensajes.FiltroPDFAbrirArchivo);
        }
        protected internal virtual void ExportarHTML()
        {
            Exportar("html", Mensajes.FiltroHTMLAbrirArchivo);
        }
        protected internal virtual void ExportarMHT()
        {
            Exportar("mht", Mensajes.FiltroMHTAbrirArchivo);
        }
        protected internal virtual void ExportarXLS()
        {
            Exportar("xls", Mensajes.FiltroXLSAbrirArchivo);
        }
        protected internal virtual void ExportarXLSX()
        {
            Exportar("xlsx", Mensajes.FiltroXLSXAbrirArchivo);
        }
        protected internal virtual void ExportarRTF()
        {
            Exportar("rtf", Mensajes.FiltroRTFAbrirArchivo);
        }
        protected internal virtual void ExportarTexto()
        {
            Exportar("txt", Mensajes.FiltroTXTAbrirArchivo);
        }

        protected internal virtual void ExportarXML()
        {

        }
        protected internal virtual void ExportarImagen()
        {

        }
    }
}
