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
    public partial class frmAsignarPresupuestoMensualProAnu : frmDialogoBaseAyuda, IAsignarPresupuestoMensualProAnuVista
    {
        private AsignarPresupuestoMensualProAnuPresentador asignarPresupuestoMensualProAnuPresentador;

        #region interface
        
        public List<ProgramacionAnualDetallePorMesPres> listaDetalleProAnu
        {
            get;set;
        }
        public List<ProgramacionAnualDetallePorMesPres> listaDetalleSubPre
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
        public ProgramacionAnualDetallePorMesPres programacionAnualDetalleMes
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProgramacionAnualDetallePorMesPres;
            }
        }

        private Dictionary<ProgramacionAnualDetallePorMesPres, bool> _listaDetalleProAnuSeleccionado;
        public List<ProgramacionAnualDetallePorMesPres> ListaDetalleProAnuSeleccionado
        {
            get { return _listaDetalleProAnuSeleccionado.Keys.ToList(); }
        }

        //Para fila seleccionada grid DetalleSubPresupuesto
        protected override ColumnView ColumnaActual2 { get { return gcDetalleSubPre.MainView as ColumnView; } }
        protected override ColumnView Vista2 { get { return gcDetalleSubPre.MainView as GridView; } }
        public ProgramacionAnualDetallePorMesPres subPresupuestoDetallePorMesPres
        {
            get
            {
                if (ColumnaActual2 == null || ColumnaActual2.FocusedRowHandle < 0) return null;
                return ColumnaActual2.GetRow(ColumnaActual2.FocusedRowHandle) as ProgramacionAnualDetallePorMesPres;
            }
        }

        private Dictionary<ProgramacionAnualDetallePorMesPres, bool> _listaDetalleSubPreSeleccionado;
        public List<ProgramacionAnualDetallePorMesPres> ListaDetalleSubPreSeleccionado
        {
            get { return _listaDetalleSubPreSeleccionado.Keys.ToList(); }
        }

        public int opcion
        {
            get;set;
        }
        private string vmensaje = string.Empty;
        #endregion

        public frmAsignarPresupuestoMensualProAnu(ProgramacionAnual programacionAnual, UsuarioOperacion usuarioOperacion, Form padre)
        {
            InitializeComponent();
            asignarPresupuestoMensualProAnuPresentador = new AsignarPresupuestoMensualProAnuPresentador(programacionAnual, usuarioOperacion, this);
            Text = "Asignar Presupuesto Mensual";

            _listaDetalleProAnuSeleccionado = new Dictionary<ProgramacionAnualDetallePorMesPres, bool>();
            _listaDetalleSubPreSeleccionado = new Dictionary<ProgramacionAnualDetallePorMesPres, bool>();
            opcion = 0;//Inicio para llenar opciones
        }

        protected override void Inicializar()
        {
            asignarPresupuestoMensualProAnuPresentador.IniciarDatos();
        }

        private void cboMes_EditValueChanged(object sender, EventArgs e)
        {
            asignarPresupuestoMensualProAnuPresentador.Llenar_ComboSubpresupuesto();
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
                    asignarPresupuestoMensualProAnuPresentador.ActualizarGrillas();
                    break;
                case 2:
                    asignarPresupuestoMensualProAnuPresentador.ActualizarGriDetalleSubPresupuesto();
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
                gcDetalleProAnu.DataSource = listaDetalleProAnu;
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
                if (this.asignarPresupuestoMensualProAnuPresentador.AsignaSubpresupuesto(ListaDetalleProAnuSeleccionado, idSubpresupuesto))
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                    LlenarGrillas();
                    this._listaDetalleProAnuSeleccionado.Clear();
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

            if (ListaDetalleProAnuSeleccionado.Count == 0)
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
            ProgramacionAnualDetallePorMesPres objDetalle = e.Row as ProgramacionAnualDetallePorMesPres;
            
            if (e.IsSetData)
            {
                if (this._listaDetalleProAnuSeleccionado.ContainsKey(objDetalle))
                {
                    this._listaDetalleProAnuSeleccionado.Remove(objDetalle);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    this._listaDetalleProAnuSeleccionado.Add(objDetalle, true);
                }
            }
            if (e.IsGetData && this._listaDetalleProAnuSeleccionado != null)
            {
                e.Value = this._listaDetalleProAnuSeleccionado.ContainsKey(objDetalle);
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
                ProgramacionAnualDetallePorMesPres prov = ColumnaActual.GetRow(i) as ProgramacionAnualDetallePorMesPres;
                
                if (activa)
                {
                    if (!this._listaDetalleProAnuSeleccionado.ContainsKey(prov))
                        this._listaDetalleProAnuSeleccionado.Add(prov, true);
                }
                else
                {
                    this._listaDetalleProAnuSeleccionado.Remove(prov);
                }
            }
            gvDetalleProAnu.LayoutChanged();
        }
        protected internal void ActivarCheck(bool activa)
        {
            if (activa)
            {
                if (!this._listaDetalleProAnuSeleccionado.ContainsKey(programacionAnualDetalleMes))
                {
                    this._listaDetalleProAnuSeleccionado.Add(programacionAnualDetalleMes, true);
                }
            }
            else
            {
                this._listaDetalleProAnuSeleccionado.Remove(programacionAnualDetalleMes);
            }
            gvDetalleProAnu.LayoutChanged();
        }

        #endregion

        #region GridDetalleSubpresupuesto
        private void obgDetalleSubPre_QuitarRegistro(object sender, EventArgs e)
        {
            if (ListaDetalleSubPreSeleccionado.Count > 0)
            {
                if (this.asignarPresupuestoMensualProAnuPresentador.AsignaSubpresupuesto(ListaDetalleSubPreSeleccionado, null))
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
            ProgramacionAnualDetallePorMesPres objDetalle = e.Row as ProgramacionAnualDetallePorMesPres;
            
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
                ProgramacionAnualDetallePorMesPres prov = ColumnaActual2.GetRow(i) as ProgramacionAnualDetallePorMesPres;

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