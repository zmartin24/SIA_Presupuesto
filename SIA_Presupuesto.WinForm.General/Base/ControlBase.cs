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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;
using System.Collections;
using SIA_Presupuesto.WinForm.General.Recursos;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using SIA_Presupuesto.WinForm.General.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraPivotGrid;

namespace SIA_Presupuesto.WinForm.General.Base
{
    [ToolboxItem(false)]
    public partial class ControlBase : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlBase()
        {
            InitializeComponent();
            this.esPeriodoCerrado = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region Establecimiento de control

        public string NombreTipo { get { return GetType().Name; } }
        protected bool IniciaCarga;
        public void EstablecerFormulario(FormBase formulario)
        {
            this.IniciaCarga = true;
            this.formulario = formulario;
            if (this.formulario != null)
            {
                //Aqui le decimos que pagina ribon esta utlizando el control principal
                this.OpcionHelper.AgregarPaginaPorControl(this);
            }
            InicializarDatos();
            LlenarGrid();
            //this.esPeriodoCerrado = this.EjercicioContable != null ? this.EjercicioContable.cerrado && this.EjercicioContable.estadoConsulta : false;
            this.IniciaCarga = false;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (DesignMode) return;
            base.OnVisibleChanged(e);
            if (this.Visible)
                Mostrar();
            else
                Ocultar();
        }


        protected void Mostrar()
        {
            OpcionHelper.ControlActual = this;
            //OpcionHelper.CargarOpcionPrincipal();
            //Agregado
            OpcionHelper.ActualizarMenu();
            if (ColumnaActual != null)
            {
                ColumnaActual.GridControl.ForceInitialize();
                ColumnaActual.Focus();
            }
        }

        protected void Ocultar()
        {

        }

        #endregion

        #region Detalle

        //Nombre del control detalle
        public string NombreDetalleTipo
        {
            get
            {
                if (DetalleControlActivo != null) return DetalleControlActivo.GetType().Name;
                return null;
            }
        }

        private ControlDetalleBase detalleControlActivo;
        public ControlDetalleBase DetalleControlActivo
        {
            get { return detalleControlActivo; }
            set
            {
                if (detalleControlActivo == value)
                {
                    ModificarDetalleControlActivo();
                    return;
                }

                detalleControlActivo = value;
                if (detalleControlActivo != null)
                {
                    CrearDetalleRibbon();
                    ModificarMenu();
                    MostrarPaginaDetalleControlRibbonActivo();
                }
            }
        }

        private ColeccionDetalleModulosHelper detalleModuloColeccion = null;
        public ColeccionDetalleModulosHelper DetalleModulosColeccion
        {
            get
            {
                if (detalleModuloColeccion == null)
                    detalleModuloColeccion = new ColeccionDetalleModulosHelper(this);
                return detalleModuloColeccion;
            }
        }

        public void MostrarDialogoModulo(ControlDetalleBase modulo)
        {
            //bool esSoloLectura = this.EjercicioContable != null ? this.EjercicioContable.cerrado && this.EjercicioContable.estadoConsulta : false;
            MostrarDialogoModulo(modulo, false/*esSoloLectura*/);
        }

        public void MostrarDialogoModulo(ControlDetalleBase modulo, bool soloLectura)
        {
            modulo.ControlPadre = this;
            modulo.Bounds = this.DisplayRectangle;
            modulo.Parent = this.Parent;
            modulo.Dock = DockStyle.Fill;
            DetalleModulosColeccion.Agregar(modulo as ControlDetalleBase);
            modulo.EventoCerrarFormulario = this.EventoCerrarControlDetalle;
            modulo.SoloLectura = soloLectura;
        }

        public bool esDetalleExistente(int codigo)
        {
            if (detalleModuloColeccion == null) return false;
            return detalleModuloColeccion.esDetalleExistente(codigo);
        }
        private void ModificarDetalleControlActivo()
        {
            if (DetalleControlActivo != null) MostrarPaginaDetalleControlRibbonActivo();
        }

        protected void CrearDetalleRibbon()
        {
            if (OpcionHelper != null) OpcionHelper.CrearDetalleRibbon();
        }

        protected void ModificarMenu()
        {
            if (OpcionHelper != null) OpcionHelper.ActualizarMenu();
        }

        public void MostrarPaginaDetalleControlRibbonActivo()
        {
            DetalleControlActivo.PaginaRibbonActivo.Ribbon.SelectedPage = DetalleControlActivo.PaginaRibbonActivo;
        }

        public bool EsPaginaAdecuada(RibbonPage pagina)
        {
            if (pagina.Tag == null) return false;
            if (detalleModuloColeccion != null)
            {
                foreach (ControlDetalleBase detalle in detalleModuloColeccion)
                    if (detalle.PaginaRibbonActivo == pagina) return true;
            }
            return PaginaActivaRibbon == pagina;
        }

        private RibbonPage paginaRibbon = null;
        public RibbonPage PaginaActivaRibbon
        {
            get { return paginaRibbon; }
            set
            {
                if (paginaRibbon != null) return;
                paginaRibbon = value;
            }
        }

        //Cerrar Detalle y eliminar control
        protected virtual void EventoCerrarControlDetalle(DialogResult result, object currentObject)
        {
            CerrarFormularioDetalleActivo();
            if (result == DialogResult.Cancel) return;
            LlenarGrid();
        }

        private void CerrarFormularioDetalleActivo()
        {
            DetalleModulosColeccion.Eliminar(DetalleControlActivo);
        }

        #endregion

        #region Operaciones

        //Operaciones con Grid
        protected virtual void InicializarDatos()
        {
            if (VistaActual != null)
            {
                VistaActual.GridControl.MouseDoubleClick += new MouseEventHandler(GridControl_MouseDoubleClick);
                VistaActual.GridControl.KeyDown += new KeyEventHandler(GridControl_KeyDown);
            }
        }

        void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.VistaActual.OptionsBehavior.Editable == false && e.KeyCode == Keys.Enter)
            {
                //if (OpcionHelper == null) return;
                //if (OpcionHelper.BotonEditar == null) return;
                //this.Boton = OpcionHelper.BotonEditar;
                RealizarModificacion();
            }
        }

        void GridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridView gv = ((GridControl)sender).MainView as GridView;
            if (gv != null)
            {
                GridHitInfo info = gv.CalcHitInfo(new Point(e.X, e.Y));
                if (!info.InRow) return;
                //if (OpcionHelper == null) return;
                //if (OpcionHelper.BotonEditar == null) return;
                //this.Boton = OpcionHelper.BotonEditar;
                RealizarModificacion();
            }
            else
            {
                ColumnView cv = ((GridControl)sender).MainView as ColumnView;
                if (cv != null)
                {
                    //if (OpcionHelper == null) return;
                    //if (OpcionHelper.BotonEditar == null) return;
                    //this.Boton = OpcionHelper.BotonEditar;
                    RealizarModificacion();
                }
            }
        }

        protected internal virtual void Siguiente()
        {
            VistaActual.FocusedRowHandle++;
        }

        protected internal virtual void Anterior()
        {
            VistaActual.FocusedRowHandle--;
        }

        protected internal virtual void Actualizar()
        {
            Cursor.Current = Cursors.WaitCursor;
            LlenarGrid();
            Cursor.Current = Cursors.Default;
        }

        //Operaciones basicas
        protected virtual void Nuevo() { }

        protected virtual void NuevoMultiple() { }

        protected virtual void Modificar() { }

        //Operaciones basicas públicas
        public void RealizarModificacion()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Modificar();
            Cursor.Current = Cursors.Default;
        }

        public void RealizarNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!this.esPeriodoCerrado)
                this.Nuevo();
            else
                EmitirMensajeResultado(true, Mensajes.ValidarPeriodoCerrado);
            Cursor.Current = Cursors.Default;
        }

        public void RealizarNuevoMultiple()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!this.esPeriodoCerrado)
                this.NuevoMultiple();
            else
                EmitirMensajeResultado(true, Mensajes.ValidarPeriodoCerrado);
            Cursor.Current = Cursors.Default;
        }

        protected virtual void LlenarGrid() { }

        public bool RealizarEliminacion()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = false;
            if (!this.esPeriodoCerrado)
                resultado = this.Eliminar();
            else
                EmitirMensajeResultado(true, Mensajes.ValidarPeriodoCerrado);
            Cursor.Current = Cursors.Default;

            return resultado;
        }

        public virtual bool Eliminar()
        {
            return false;
        }

        public bool RealizarAnulacion()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = false;
            if (!this.esPeriodoCerrado)
                resultado = this.Anular();
            else
                EmitirMensajeResultado(true, Mensajes.ValidarPeriodoCerrado);
            Cursor.Current = Cursors.Default;

            return resultado;
        }

        public virtual bool Anular()
        {
            return false;
        }

        //Otras operaciones
        protected internal virtual bool Exportar()
        {
            return false;
        }

        protected internal virtual void Imprimir()
        {

        }

        protected virtual void OtrasOperaciones(string nomOperacion)
        {

        }

        public void RealizarOtrasOperaciones(string nomOperacion)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.OtrasOperaciones(nomOperacion);
            Cursor.Current = Cursors.Default;
        } 

        //protected virtual void CerrarFormularioDetalleLuegoCargarGrid(DialogResult result, object currentObject)
        //{
        //    CerrarFormularioDetalleActivo();
        //}

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

            if (GridPrincipal != null)
                GridPrincipal.DataSource = listaSplash;
            if(PivotGridPrincipal != null)
                PivotGridPrincipal.DataSource = listaSplash;
        }

        //private void CerrarFormularioDetalleActivo()
        //{
        //    DetalleModulosColeccion.Eliminar(DetalleControlActivo);
        //}

        protected internal virtual void GuardarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.Guardar();
            Cursor.Current = Cursors.Default;
        }

        protected internal virtual void CerrarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.Cerrar();
            Cursor.Current = Cursors.Default;
        }

        protected internal virtual void GuardarYCerrarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.GuardarCerrar();
            Cursor.Current = Cursors.Default;
        }

        public void RealizarOtrasOperacionesDet(string nomOperacion)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.RealizarOtrasOperaciones(nomOperacion);
            Cursor.Current = Cursors.Default;
        }

        public void NuevoDet()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.RealizarNuevo();
            Cursor.Current = Cursors.Default;
        }

        public void ModificacionDet()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.RealizarModificacion();
            Cursor.Current = Cursors.Default;
        }

        public void AnularDet()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.RealizarAnulacion();
            Cursor.Current = Cursors.Default;
        }

        protected internal virtual void RefrescarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DetalleControlActivo != null) DetalleControlActivo.Actualizar();
            Cursor.Current = Cursors.Default;
        }

        //Emisión de preguntas y mensajes
        protected internal virtual void EmitirMensajeResultado(bool resultado, string mensaje)
        {
            if (resultado)
            {
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LlenarGrid();
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


        #endregion

        #region Propiedades

        public int Anio { get { return formulario.Anio; }  }
        public int Mes { get { return formulario.Mes; } }

        public int IdTipCam { get { return formulario.IdTipCam; } }
        public int IdMoneda { get { return formulario.IdMoneda; } }

        public string Parametros
        {
            get { return formulario.Parametro; }
        }

        public UsuarioOperacion UsuarioOperacion { get { return formulario.Usuario; } }

        private FormBase formulario;

        public MenuModulo MenuModulo { get; set; }

        private BarButtonItem nuevoBoton;
        public BarButtonItem Boton
        {
            get { return nuevoBoton; }
            set { nuevoBoton = value; }
        }

        public OpcionHelper OpcionHelper
        {
            get
            {
                var formBase = formulario as FormBase;
                if (formBase != null)
                    return formBase.OpcionHelper;

                return null;
            }
        }

        protected virtual ColumnView ColumnaActual { get { return null; } }
        protected virtual ColumnView VistaActual { get { return ColumnaActual; } }
        protected virtual ColumnView ColumnaSecundario { get { return null; } }
        protected virtual ColumnView VistaActualSecundario { get { return ColumnaSecundario; } }


        protected virtual GridControl GridPrincipal { get { return null; } }
        protected virtual GridControl GridSecundario { get { return null; } }
        protected virtual BaseView VistaExportar { get { return VistaActual; } }
        
        protected virtual PivotGridControl PivotGridPrincipal { get { return null; } }
        protected virtual bool ExportarDePivot { get { return false; } }

        public IList listaSplash { get; set; }

        protected virtual string ExportFileName { get { return "Sin_Nombre"; } }

        PrintingSystem sistemaImpresion = null;

        private bool esPeriodoCerrado = false;

        #endregion

        #region Exportar

        PrintingSystem Impresion
        {
            get
            {
                if (sistemaImpresion == null) sistemaImpresion = new PrintingSystem();
                return sistemaImpresion;
            }
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

        //private void RealizarExportacion(String nombreArchivo, string extension)
        //{
        //    if (VistaExportar == null) return;
        //    IniciarExportacion();
        //    Cursor currentCursor = Cursor.Current;
        //    Cursor.Current = Cursors.WaitCursor;
        //    switch (extension)
        //    {
        //        case "rtf": VistaExportar.ExportToRtf(nombreArchivo); break;
        //        case "pdf": VistaExportar.ExportToPdf(nombreArchivo); break;
        //        case "mht": VistaExportar.ExportToMht(nombreArchivo); break;
        //        case "html": VistaExportar.ExportToHtml(nombreArchivo); break;
        //        case "txt": VistaExportar.ExportToText(nombreArchivo); break;
        //        case "xls": VistaExportar.ExportToXls(nombreArchivo); break;
        //        case "xlsx": VistaExportar.ExportToXlsx(nombreArchivo); break;
        //    }

        //    Cursor.Current = currentCursor;
        //    FinalizarExportacion();
        //}

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


        #endregion

    }

}
