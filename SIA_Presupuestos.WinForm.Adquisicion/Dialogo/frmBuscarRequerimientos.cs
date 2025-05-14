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
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmBuscarRequerimientos : frmDialogoBase, IBuscarRequerimientoVista
    {
        private BuscarRequerimientoPresentador buscarRequerimientoPresentador;

        public List<RequerimientoBienServicioPendientePorCuentaPres> listaDatosPrincipales
        {
            get; set;
            //set
            //{
            //    gcRequerimiento.DataSource = value;
            //}
        }
        public RequerimientoBienServicioPendientePorCuentaPres requerimientoBienServicioPendientePorCuentaPresActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoBienServicioPendientePorCuentaPres;
            }
        }
        public List<CuentaContable> listaCuentaN1
        {
            set
            {
                glueCuentaN1.Properties.DisplayMember = "numCuenta";
                glueCuentaN1.Properties.ValueMember = "idCueCon";
                glueCuentaN1.Properties.NullText = string.Empty;
                glueCuentaN1.Properties.DataSource = value;
            }
        }
        public List<CuentaContable> listaCuentaN2
        {
            set
            {
                glueCuentaN2.Properties.DisplayMember = "numCuenta";
                glueCuentaN2.Properties.ValueMember = "idCueCon";
                glueCuentaN2.Properties.NullText = string.Empty;
                glueCuentaN2.Properties.DataSource = value;
            }
        }
        public List<CuentaContable> listaCuentaN3
        {
            set
            {
                glueCuentaN3.Properties.DisplayMember = "numCuenta";
                glueCuentaN3.Properties.ValueMember = "idCueCon";
                glueCuentaN3.Properties.NullText = string.Empty;
                glueCuentaN3.Properties.DataSource = value;
            }
        }

        public List<ConfiguracionPAA> listaTipoCompra
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipCom.Properties, "codigo", "descripcion", "Tipo de Compra", value);
            }
        }
        public List<ConfiguracionPAA> listaTipoProceso
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipPro.Properties, "codigo", "descripcion", "Tipo de Proceso", value);
            }
        }
        public List<ConfiguracionPAA> listaObjetoProceso
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueObjCon.Properties, "codigo", "descripcion", "Objeto Proceso", value);
            }
        }
        public List<ConfiguracionPAA> listaEncargado
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueEncargado.Properties, "codigo", "descripcion", "Encargado Proceso", value);
            }
        }
        public List<FuenteFinanciamiento> listaFuenteFinanciamiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFueFin.Properties, "idFueFin", "rubro", "Fuente Financiamiento", value);
            }
        }
        public List<ConfiguracionPAA> listaMesPrevisto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFechaPre.Properties, "codigo", "descripcion", "Fecha Prevista", value);
            }
        }
        public List<Ubigeo> listaRegion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueRegion.Properties, "idUbigeo", "desUbigeo", "Región", value);
            }
        }
        public List<Ubigeo> listaProvincia
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueProvincia.Properties, "idUbigeo", "desUbigeo", "Provincia", value);
            }
        }
        public List<Ubigeo> listaDistrito
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDistrito.Properties, "idUbigeo", "desUbigeo", "Distrito", value);
            }
        }

        public int idCueConN1
        {
            set { glueCuentaN1.EditValue = value; }
            get { return Convert.ToInt32(glueCuentaN1.EditValue); }
        }
        public int idCueConN2
        {
            set
            {
                glueCuentaN2.EditValue = value;
            }
            get { return Convert.ToInt32(glueCuentaN2.EditValue); }
        }
        public int idCueConN3
        {
            set
            {
                glueCuentaN3.EditValue = value;
            }
            get { return Convert.ToInt32(glueCuentaN3.EditValue); }
        }
        

        public int tipComSel
        {
            set { lueTipCom.EditValue = value; }
            get { return (Int32)lueTipCom.EditValue; }
        }
        public int TipPro
        {
            set { lueTipPro.EditValue = value; }
            get { return (Int32)lueTipPro.EditValue; }
        }
        public int objCon
        {
            set { lueObjCon.EditValue = value; }
            get { return (Int32)lueObjCon.EditValue; }
        }
        public int organoEncargado
        {
            set { lueEncargado.EditValue = value; }
            get { return (Int32)lueEncargado.EditValue; }
        }
        public int idFueFin
        {
            set { lueFueFin.EditValue = value; }
            get { return (Int32)lueFueFin.EditValue; }
        }
        public int fechaPrevista
        {
            set { lueFechaPre.EditValue = value; }
            get { return (Int32)lueFechaPre.EditValue; }
        }

        public int idRegion
        {
            set { lueRegion.EditValue = value; }
            get { return (Int32)lueRegion.EditValue; }
        }
        public int idProvincia
        {
            set { lueProvincia.EditValue = value; }
            get { return (Int32)lueProvincia.EditValue; }
        }
        public int idUbigeo
        {
            set { lueDistrito.EditValue = value; }
            get { return (Int32)lueDistrito.EditValue; }
        }
        

        private PlanAnualAdquisicion planAnualAdquisicion;
        private GastoRecurrente gastoRecurrente;

        private int vanio = DateTime.Now.Year;

        private Dictionary<RequerimientoBienServicioPendientePorCuentaPres, bool> ListaDetallesSeleccionados;

        public List<RequerimientoBienServicioPendientePorCuentaPres> listaSeleccionada
        {
            get { return ListaDetallesSeleccionados.Keys.ToList(); }
        }

        public frmBuscarRequerimientos(PlanAnualAdquisicion planAnualAdquisicion, Form padre, int vtipoRubro) : base(padre, true)
        {
            InitializeComponent();
            buscarRequerimientoPresentador = new BuscarRequerimientoPresentador(planAnualAdquisicion, this, vtipoRubro);
            this.planAnualAdquisicion = planAnualAdquisicion ?? new PlanAnualAdquisicion();
            Text = "Buscar Requerimientos - Plan Anual Adquisiciones y Contrataciones";
            ListaDetallesSeleccionados = new Dictionary<RequerimientoBienServicioPendientePorCuentaPres, bool>();
            vanio = planAnualAdquisicion != null ? (Int32)planAnualAdquisicion.anio : gastoRecurrente != null ? (Int32)gastoRecurrente.anio : vanio;
        }
        public frmBuscarRequerimientos(GastoRecurrente gastoRecurrente, Form padre, int vtipoRubro) : base(padre, true)
        {
            InitializeComponent();
            buscarRequerimientoPresentador = new BuscarRequerimientoPresentador(gastoRecurrente, this, vtipoRubro);
            this.gastoRecurrente = gastoRecurrente ?? new GastoRecurrente();
            Text = "Buscar Requerimientos - Gasto Recurrente";
            ListaDetallesSeleccionados = new Dictionary<RequerimientoBienServicioPendientePorCuentaPres, bool>();
            vanio = planAnualAdquisicion != null ? (Int32)planAnualAdquisicion.anio : gastoRecurrente != null ? (Int32)gastoRecurrente.anio : vanio;

            this.lcgDetalle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.lcgUbigeo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        protected override void OnLoad(EventArgs e)
        {
            obgmMarcar.Inicializar(gvRequerimiento, ListaDetallesSeleccionados);
            buscarRequerimientoPresentador.IniciarDatos();
        }
        //Para fila seleccionada
        public override ColumnView ColumnaActual { get { return gcRequerimiento.MainView as ColumnView; } }
        protected override ColumnView VistaActual { get { return gcRequerimiento.MainView as GridView; } }
        
        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(glueCuentaN3, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            buscarRequerimientoPresentador.IniciarDatos();
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplashLocal();
        }
        protected void EjecutarCargarConSplashLocal()
        {
            if (glueCuentaN3.EditValue != null)
            {
                this.buscarRequerimientoPresentador.LlenarGrid(vanio, Convert.ToInt32(glueCuentaN3.EditValue));
            }
            else if (glueCuentaN2.EditValue != null)
            {
                this.buscarRequerimientoPresentador.LlenarGrid(vanio, Convert.ToInt32(glueCuentaN2.EditValue));
            }
        }
        protected virtual void CargarDatosConSplashLocal()
        {
            Thread hilo = new Thread(new ThreadStart(this.EjecutarCargarConSplashLocal));
            hilo.Start();

            while (!hilo.IsAlive) ;

            Splash splash = new Splash(hilo, "Cargando Datos...");
            splash.ShowDialog();
            splash.Dispose();

            gcRequerimiento.DataSource = listaDatosPrincipales;
            gvRequerimiento.RefreshData();
        }

        protected override void GuardarDatos()
        {
            if (planAnualAdquisicion != null)
            {
                if (buscarRequerimientoPresentador.RegistrarDetalles())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            }
            else if (gastoRecurrente!= null)
            {
                if (buscarRequerimientoPresentador.RegistrarDetallesGastoRecurrente())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            }
            else
                EmitirMensajeResultado(false, Mensajes.RegistroVacio);
        }

        private void glueCuentaN1_EditValueChanged(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
            ListaDetallesSeleccionados.Clear();
            listaDatosPrincipales = null;
            if (glueCuentaN1.EditValue != null)
            {
                this.buscarRequerimientoPresentador.LlenarCombosCuentasN2(vanio, Convert.ToInt32(glueCuentaN1.EditValue));
            }
        }

        private void glueCuentaN2_EditValueChanged(object sender, EventArgs e)
        {
            if (glueCuentaN2.EditValue != null)
            {
                this.buscarRequerimientoPresentador.LlenarCombosCuentasN3(vanio,Convert.ToInt32(glueCuentaN2.EditValue));
            }
        }

        private void glueCuentaN3_EditValueChanged(object sender, EventArgs e)
        {
            //if (glueCuentaN3.EditValue != null)
            //{
            //    this.buscarRequerimientoPresentador.LlenarGrid(vanio, Convert.ToInt32(glueCuentaN3.EditValue));
            //}
            //else if (glueCuentaN2.EditValue != null)
            //{
            //    this.buscarRequerimientoPresentador.LlenarGrid(vanio, Convert.ToInt32(glueCuentaN2.EditValue));
            //}
            LlenarGrid();
        }
        protected internal void ActivarTodosCheck(bool activa)
        {
            int filas = gvRequerimiento.RowCount;
            for (int i = 0; i < filas; i++)
            {
                RequerimientoBienServicioPendientePorCuentaPres prov = ColumnaActual.GetRow(i) as RequerimientoBienServicioPendientePorCuentaPres;
                if (activa)
                {
                    if (!ListaDetallesSeleccionados.ContainsKey(prov))
                        ListaDetallesSeleccionados.Add(prov, true);
                }
                else
                {
                    ListaDetallesSeleccionados.Remove(prov);
                }
            }

            gvRequerimiento.LayoutChanged();
        }
        protected internal void ActivarCheck(bool activa)
        {
            if (activa)
            {
                if (!ListaDetallesSeleccionados.ContainsKey(requerimientoBienServicioPendientePorCuentaPresActual))
                {
                    ListaDetallesSeleccionados.Add(requerimientoBienServicioPendientePorCuentaPresActual, true);
                }
            }
            else
            {
                ListaDetallesSeleccionados.Remove(requerimientoBienServicioPendientePorCuentaPresActual);
            }
            gvRequerimiento.LayoutChanged();
        }

        private void obgmMarcar_AnteriorRegistro(object sender, EventArgs e)
        {
            ColumnaActual.FocusedRowHandle--;
        }
        private void obgmMarcar_DesmarcarRegistro(object sender, EventArgs e)
        {
            ActivarCheck(false);
        }
        private void obgmMarcar_DesmarcarTodosRegistro(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
        }
        private void obgmMarcar_MarcarRegistro(object sender, EventArgs e)
        {
            ActivarCheck(true);
        }
        private void obgmMarcar_MarcarTodosRegistro(object sender, EventArgs e)
        {
            ActivarTodosCheck(true);
        }
        private void obgmMarcar_SiguienteRegistro(object sender, EventArgs e)
        {
            ColumnaActual.FocusedRowHandle++;
        }

        private void riceSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            gvRequerimiento.CloseEditor();
        }

        private void gvRequerimiento_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            RequerimientoBienServicioPendientePorCuentaPres trab = e.Row as RequerimientoBienServicioPendientePorCuentaPres;
            if (e.IsSetData)
            {
                if (ListaDetallesSeleccionados.ContainsKey(trab))
                {
                    ListaDetallesSeleccionados.Remove(trab);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    ListaDetallesSeleccionados.Add(trab, true);
                }
                obgmMarcar.ActualizarContador();
            }
            if (e.IsGetData)
            {
                e.Value = ListaDetallesSeleccionados.ContainsKey(trab);
            }
        }

        private void glueCuentaN1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            var gridLookUpEdit = sender as GridLookUpEdit;
            var dataRowView = gridLookUpEdit.Properties.GetRowByKeyValue(e.Value) as CuentaContable;
            if (dataRowView == null)
            {
                return;
            }
            string row = dataRowView.descripcion as string;
            if (row == null)
            {
                return;
            }
            e.DisplayText = string.Format("{0}\t{1}",e.DisplayText, row);
            
            //var row = dataRowView.Row as DataRow;
            //if (row == null)
            //{
            //    return;
            //}
            //var displayValue = GetDisplayValue(gridLookUpEdit, row);
            // e.DisplayText = displayValue;
        }
        private static string GetDisplayValue(GridLookUpEdit gridLookUpEdit, DataRow row)
        {
            var columns = gridLookUpEdit.Properties.View.Columns;
            var displayValue = string.Empty;
            foreach (GridColumn column in columns)
            {
                displayValue += string.Format("{0}", row[column.FieldName]);
                if (!(columns.OfType<GridColumn>().Last() == column))
                {
                    displayValue += ", ";
                }
            }
            return displayValue;
        }

        private void glueCuentaN2_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            var gridLookUpEdit = sender as GridLookUpEdit;
            var dataRowView = gridLookUpEdit.Properties.GetRowByKeyValue(e.Value) as CuentaContable;
            if (dataRowView == null)
            {
                return;
            }
            string row = dataRowView.descripcion as string;
            if (row == null)
            {
                return;
            }
            e.DisplayText = string.Format("{0}\t{1}", e.DisplayText, row);
        }

        private void glueCuentaN3_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            var gridLookUpEdit = sender as GridLookUpEdit;
            var dataRowView = gridLookUpEdit.Properties.GetRowByKeyValue(e.Value) as CuentaContable;
            if (dataRowView == null)
            {
                return;
            }
            string row = dataRowView.descripcion as string;
            if (row == null)
            {
                return;
            }
            e.DisplayText = string.Format("{0}\t{1}", e.DisplayText, row);
        }

        private void lueRegion_EditValueChanged(object sender, EventArgs e)
        {
            if (idRegion > 0)
            {
                buscarRequerimientoPresentador.llenarComboProvincia(idRegion);
            }
        }
        private void lueProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (idProvincia > 0)
            {
                buscarRequerimientoPresentador.llenarComboDistrito(idProvincia);
            }
        }
        
    }
}