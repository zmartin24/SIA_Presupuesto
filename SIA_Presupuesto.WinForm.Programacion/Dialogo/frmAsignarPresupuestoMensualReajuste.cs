using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmAsignarPresupuestoMensualReajuste : frmDialogoBaseAyuda, IAsignarPresupuestoMensualReajusteVista
    {
        private AsignarPresupuestoMensualReajustePresentador asignarPresupuestoMensualReajustePresentador;

        #region interface
        
        public List<ReajusteMensualDetallePorMesPres> listaDetalleReajusteMensual
        {
            get;set;
        }
        public List<ReajusteMensualDetallePorMesPres> listaDetalleSubPre
        {
            get; set;
        }

        public List<ItemPoco> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboMes.Properties, "id", "nombre", "Mes", value);
            }
        }
        public List<Subpresupuesto> listaSubpresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboSubpresupuesto.Properties, "idSubpresupuesto", "descripcion", "Presupuesto Mensual", value);
            }
        }

        public string desPresupuesto
        {
            set { txtAbreviatura.EditValue = value; }
            get { return txtAbreviatura.Text; }
        }
        public int mes
        {
            set { cboMes.EditValue = value; }
            get { return (Int32)cboMes.EditValue; }
        }
        public int idSubpresupuesto
        {
            set { cboSubpresupuesto.EditValue = value; }
            get { return (Int32)cboSubpresupuesto.EditValue; }
        }

        //Para fila seleccionada gcDetalleProAnu
        protected override ColumnView ColumnaActual { get { return gcDetalleProAnu.MainView as ColumnView; } }
        protected override ColumnView Vista { get { return gcDetalleProAnu.MainView as GridView; } }
        public ReajusteMensualDetallePorMesPres reajusteMensualDetallePorMesPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ReajusteMensualDetallePorMesPres;
            }
        }

        private Dictionary<ReajusteMensualDetallePorMesPres, bool> _listaDetalleReajusteSeleccionado;
        public List<ReajusteMensualDetallePorMesPres> ListaDetalleReajusteSeleccionado
        {
            get { return _listaDetalleReajusteSeleccionado.Keys.ToList(); }
        }

        //Para fila seleccionada grid DetalleSubPresupuesto
        protected override ColumnView ColumnaActual2 { get { return gcDetalleSubPre.MainView as ColumnView; } }
        protected override ColumnView Vista2 { get { return gcDetalleSubPre.MainView as GridView; } }
        public ReajusteMensualDetallePorMesPres subPresupuestoDetallePorMesPres
        {
            get
            {
                if (ColumnaActual2 == null || ColumnaActual2.FocusedRowHandle < 0) return null;
                return ColumnaActual2.GetRow(ColumnaActual2.FocusedRowHandle) as ReajusteMensualDetallePorMesPres;
            }
        }

        private Dictionary<ReajusteMensualDetallePorMesPres, bool> _listaDetalleSubPreSeleccionado;
        public List<ReajusteMensualDetallePorMesPres> ListaDetalleSubPreSeleccionado
        {
            get { return _listaDetalleSubPreSeleccionado.Keys.ToList(); }
        }

        public int opcion
        {
            get;set;
        }
        public bool esInicio
        {
            get; set;
        }
        private string vmensaje = string.Empty;
        #endregion

        public frmAsignarPresupuestoMensualReajuste(ReajusteMensualProgramacion reajusteMensualProgramacion, UsuarioOperacion usuarioOperacion, Form padre)
        {
            InitializeComponent();
            asignarPresupuestoMensualReajustePresentador = new AsignarPresupuestoMensualReajustePresentador(reajusteMensualProgramacion, usuarioOperacion, this);
            Text = "Asignar Presupuesto Mensual";

            _listaDetalleReajusteSeleccionado = new Dictionary<ReajusteMensualDetallePorMesPres, bool>();
            _listaDetalleSubPreSeleccionado = new Dictionary<ReajusteMensualDetallePorMesPres, bool>();
            opcion = 0;//Inicio para llenar opciones
            esInicio = true;
        }

        protected override void Inicializar()
        {
            asignarPresupuestoMensualReajustePresentador.IniciarDatos();
        }
        
        private void cboMes_EditValueChanged(object sender, EventArgs e)
        {
            asignarPresupuestoMensualReajustePresentador.Llenar_ComboSubpresupuesto();
            if (opcion == 1) LlenarGrillas();
            opcion = 2;
        }

        private void cboSubpresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            if (opcion == 2) LlenarGrillas();
        }

        protected void LlenarGrillas()
        {
            CargarDatosConSplash();
        }

        protected void EjecutarCargarConSplash()
        {
            switch (opcion)
            {
                case 1:
                    asignarPresupuestoMensualReajustePresentador.ActualizarGrillas();
                    break;
                case 2:
                    asignarPresupuestoMensualReajustePresentador.ActualizarGriDetalleSubPresupuesto();
                    break;
            }
        }

        protected virtual void CargarDatosConSplash()
        {
            Thread hilo = new Thread(new ThreadStart(this.EjecutarCargarConSplash));
            hilo.Start();

            while (!hilo.IsAlive) ;

            Splash splash = new Splash(hilo, "Cargando Datos...");
            splash.ShowDialog();
            splash.Dispose();

            if (gcDetalleProAnu != null)
            {
                gcDetalleProAnu.DataSource = listaDetalleReajusteMensual;
                gvDetalleProAnu.RefreshData();
            }

            if (gcDetalleSubPre != null)
            {
                gcDetalleSubPre.DataSource = listaDetalleSubPre;
                gvDetalleSubPre.RefreshData();
            }
        }

        #region GridDetalleProgrmacionAnual
        private void obgDetalleProAnu_AgregarRegistro(object sender, EventArgs e)
        {
            if (validar())
            {
                if (this.asignarPresupuestoMensualReajustePresentador.AsignaSubpresupuesto(ListaDetalleReajusteSeleccionado, idSubpresupuesto))
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                    LlenarGrillas();
                    this._listaDetalleReajusteSeleccionado.Clear();
                    opcion = 2;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            }
            else
                EmitirMensajeResultado(true, vmensaje);
        }
        private bool validar()
        {
            bool res = true;
            vmensaje = string.Empty;

            if (ListaDetalleReajusteSeleccionado.Count == 0)
            {
                res = false;
                vmensaje = vmensaje + "* Debe seleccionar al menos un detalle";
            }
            if (idSubpresupuesto < 0)
            {
                res = false;
                vmensaje = vmensaje + "\n* No existe presupuesto mensual";
            }
            return res;
        }
        private void obgDetalleProAnu_MarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheck(true);
        }
        private void obgDetalleProAnu_DesMarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
        }
        
        private void gvDetalleProAnu_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            ReajusteMensualDetallePorMesPres objDetalle = e.Row as ReajusteMensualDetallePorMesPres;
            
            if (e.IsSetData)
            {
                if (this._listaDetalleReajusteSeleccionado.ContainsKey(objDetalle))
                {
                    this._listaDetalleReajusteSeleccionado.Remove(objDetalle);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    this._listaDetalleReajusteSeleccionado.Add(objDetalle, true);
                }
            }
            if (e.IsGetData && this._listaDetalleReajusteSeleccionado != null)
            {
                e.Value = this._listaDetalleReajusteSeleccionado.ContainsKey(objDetalle);
            }
        }

        private void riseProAnu_CheckedChanged(object sender, EventArgs e)
        {
            var edit = (CheckEdit)sender;
            ActivarCheck((bool)edit.EditValue);
        }
        private void riseProAnu_CheckStateChanged(object sender, EventArgs e)
        {
            gvDetalleProAnu.CloseEditor();
        }
        
        protected internal void ActivarTodosCheck(bool activa)
        {
            int filas = gvDetalleProAnu.RowCount;
            for (int i = 0; i < filas; i++)
            {
                ReajusteMensualDetallePorMesPres prov = ColumnaActual.GetRow(i) as ReajusteMensualDetallePorMesPres;
                
                if (activa)
                {
                    if (!this._listaDetalleReajusteSeleccionado.ContainsKey(prov))
                        this._listaDetalleReajusteSeleccionado.Add(prov, true);
                }
                else
                {
                    this._listaDetalleReajusteSeleccionado.Remove(prov);
                }
            }
            gvDetalleProAnu.LayoutChanged();
        }
        protected internal void ActivarCheck(bool activa)
        {
            if (activa)
            {
                if (!this._listaDetalleReajusteSeleccionado.ContainsKey(reajusteMensualDetallePorMesPres))
                {
                    this._listaDetalleReajusteSeleccionado.Add(reajusteMensualDetallePorMesPres, true);
                }
            }
            else
            {
                this._listaDetalleReajusteSeleccionado.Remove(reajusteMensualDetallePorMesPres);
            }
            gvDetalleProAnu.LayoutChanged();
        }

        #endregion

        #region GridDetalleSubpresupuesto
        private void obgDetalleSubPre_QuitarRegistro(object sender, EventArgs e)
        {
            if (ListaDetalleSubPreSeleccionado.Count > 0)
            {
                if (this.asignarPresupuestoMensualReajustePresentador.AsignaSubpresupuesto(ListaDetalleSubPreSeleccionado, null))
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeEliminacionSatisfactoria);
                    LlenarGrillas();
                    this._listaDetalleSubPreSeleccionado.Clear();
                    opcion = 2;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            }
            else
                EmitirMensajeResultado(true, "Debe seleccionar detalles");
        }
        private void obgDetalleSubPre_MarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheckSubPre(true);
        }
        private void obgDetalleSubPre_DesMarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheckSubPre(false);
        }

        private void gvDetalleSubPre_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            ReajusteMensualDetallePorMesPres objDetalle = e.Row as ReajusteMensualDetallePorMesPres;
            
            if (e.IsSetData)
            {
                if (this._listaDetalleSubPreSeleccionado.ContainsKey(objDetalle))
                {
                    this._listaDetalleSubPreSeleccionado.Remove(objDetalle);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    this._listaDetalleSubPreSeleccionado.Add(objDetalle, true);
                }
            }
            if (e.IsGetData)
            {
                e.Value = this._listaDetalleSubPreSeleccionado.ContainsKey(objDetalle);
            }
        }

        private void riseSubPre_CheckedChanged(object sender, EventArgs e)
        {
            var edit = (CheckEdit)sender;
            ActivarCheckSubPre((bool)edit.EditValue);
        }
        private void riseSubPre_CheckStateChanged(object sender, EventArgs e)
        {
            gvDetalleSubPre.CloseEditor();
        }

        protected internal void ActivarTodosCheckSubPre(bool activa)
        {
            int filas = gvDetalleSubPre.RowCount;
            for (int i = 0; i < filas; i++)
            {
                ReajusteMensualDetallePorMesPres prov = ColumnaActual2.GetRow(i) as ReajusteMensualDetallePorMesPres;

                if (activa)
                {
                    if (!this._listaDetalleSubPreSeleccionado.ContainsKey(prov))
                        this._listaDetalleSubPreSeleccionado.Add(prov, true);
                }
                else
                {
                    this._listaDetalleSubPreSeleccionado.Remove(prov);
                }
            }
            gvDetalleSubPre.LayoutChanged();
        }
        protected internal void ActivarCheckSubPre(bool activa)
        {
            if (activa)
            {
                if (!this._listaDetalleSubPreSeleccionado.ContainsKey(subPresupuestoDetallePorMesPres))
                {
                    this._listaDetalleSubPreSeleccionado.Add(subPresupuestoDetallePorMesPres, true);
                }
            }
            else
            {
                this._listaDetalleSubPreSeleccionado.Remove(subPresupuestoDetallePorMesPres);
            }
            gvDetalleSubPre.LayoutChanged();
        }

        #endregion

        
    }
}