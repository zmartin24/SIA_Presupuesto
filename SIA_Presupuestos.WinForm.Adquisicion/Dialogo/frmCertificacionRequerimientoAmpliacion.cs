using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Ayuda;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.Adquisicion.Ayuda;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCertificacionRequerimientoAmpliacion : frmDialogoBase, ICertificacionRequerimientoAmpliacionVista
    {
        private CertificacionRequerimientoAmpliacionPresentador certificacionRequerimientoAmpliacionPresentador;
        private CertificacionRequerimiento certificacionRequerimiento;

        public List<Predeterminado> listaTipoRequerimiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipo Requerimiento", value);
            }
        }
        public List<GrupoPresupuestoPoco> ListaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueGruPre.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }
        public List<ProgramacionAnual> ListaProgramacion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Presupuesto", value);
            }
        }
        public List<Subpresupuesto> ListaSubpresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubPresupuesto.Properties, "idSubpresupuesto", "descripcion", "Presupuesto Mensual", value);
            }
        }
        
        public int idTipoReq
        {
            set { lueTipo.EditValue = value.ToString(); }
            get { return Convert.ToInt32(lueTipo.EditValue); }
        }
        public string sigla
        {
            set { txtSigla.EditValue = value; }
            get { return txtSigla.Text; }
        }
        public int idGruPre
        {
            set { lueGruPre.EditValue = value; }
            get { return Convert.ToInt32(lueGruPre.EditValue); }
        }
        public int idPresupuesto
        {
            set { luePresupuesto.EditValue = value; }
            get { return Convert.ToInt32(luePresupuesto.EditValue); }
        }
        public int idSubPresupuesto
        {
            set { lueSubPresupuesto.EditValue = value; }
            get { return Convert.ToInt32(lueSubPresupuesto.EditValue); }
        }
        public decimal tipoCambio
        {
            set { seTipoCambio.EditValue = value; }
            get { return Convert.ToDecimal(seTipoCambio.Value); }
        }
        public decimal total
        {
            set;
            get;
        }
        public string detalle
        {
            set { txtDetalle.EditValue = value; }
            get { return txtDetalle.Text; }
        }
        public string justificacion
        {
            set { txtJustificacionAmp.EditValue = value; }
            get { return txtJustificacionAmp.Text; }
        }
        
        public SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion
        {
            set;get;
        }
        private tipoAyudaFore tipo;
        private CertificacionMasterPres certificacionMasterPres;
        public CertificacionMasterPres CertificacionMasterPres
        {
            get { return certificacionMasterPres; }
            set
            {
                certificacionMasterPres = value;
                if (value != null)
                {
                    txtReq.Text = value.numeroReq;
                }
                else
                {
                    txtReq.Text = string.Empty;

                }
            }
        }

        public List<ForeDetallePoco> listaDatosPrincipales
        {
            set
            {
                gcRequerimiento.DataSource = value;
                gvRequerimiento.RefreshData();
            }
        }
        public List<ForeDetallePoco> listaForeDetallePoco
        {
            set;get;
        }
        private Dictionary<ForeDetallePoco, bool> listaDetallesSeleccionados;
        public List<ForeDetallePoco> ListaDetallesSeleccionados
        {
            get { return listaDetallesSeleccionados.Keys.ToList(); }
        }
        public ForeDetallePoco foreDetallePoco
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ForeDetallePoco;
            }
        }
        private PrecioBienServicioPres precio;
        public PrecioBienServicioPres Precio
        {
            get { return precio; }
            set
            {
                precio = value;
            }
        }
        private List<SubPresupuestoDetallePres> listaSubPresupuestoDetalle;
        public List<SubPresupuestoDetallePres> ListaSubPresupuestoDetalle
        {
            set { listaSubPresupuestoDetalle = value; }
            get { return listaSubPresupuestoDetalle; }
        }

        public string vmensaje { set; get; }

        public frmCertificacionRequerimientoAmpliacion(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.certificacionRequerimiento = certificacionRequerimiento;
            this.certificacionRequerimientoAmpliacionPresentador = new CertificacionRequerimientoAmpliacionPresentador(certificacionMasterPres, certificacionRequerimiento, this);
            this.listaDetallesSeleccionados = new Dictionary<ForeDetallePoco, bool>();
            this.listaForeDetallePoco = new List<ForeDetallePoco>();
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtJustificacionAmp, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            certificacionRequerimientoAmpliacionPresentador.IniciarDatos();
            listaDatosPrincipales = listaForeDetallePoco;
            this.esModificacion = listaForeDetallePoco.Count > 0 ? true : false;

            if (this.esModificacion)
                Text = "Modificación Ampliación - Certificación de Requerimiento";
            else
                Text = "Registro Ampliación - Certificación de Requerimiento";
                
            this.listaDetallesSeleccionados.Clear();
        }
        //Para fila seleccionada
        public override ColumnView ColumnaActual { get { return gcRequerimiento.MainView as ColumnView; } }
        protected override ColumnView VistaActual { get { return gcRequerimiento.MainView as GridView; } }
        protected override void GuardarDatos()
        {
            if (this.total == 0)
                sumaDetalles();

            if (validar())
            {
                if (certificacionRequerimientoAmpliacionPresentador.GuardarDatos())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                }

                //EmitirMensajeResultado(true, "Prueba Exito");
            }
            else
            {
                this.DialogResult = DialogResult.No;
                EmitirMensajeResultado(true, vmensaje);
            }
        }
        private void lueTipo_EditValueChanged(object sender, EventArgs e)
        {
            this.tipo = idTipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio;
        }
        private void lueGruPre_EditValueChanged(object sender, EventArgs e)
        {
            certificacionRequerimientoAmpliacionPresentador.LlenarComboPresupuesto(this.idGruPre);
        }
        private void luePresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            certificacionRequerimientoAmpliacionPresentador.LlenarComboSubPresupuesto(this.idPresupuesto);
        }
        private void lueSubPresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            certificacionRequerimientoAmpliacionPresentador.TraerTipoCambio(idSubPresupuesto);
        }
        private void gvRequerimiento_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var cambio = gvRequerimiento.GetRow(e.RowHandle) as ForeDetallePoco;
            
            ForeDetallePoco Original = certificacionMasterPres.esTotalDetallado == true ? CertificacionMasterPres.forebi != null ? CertificacionMasterPres.forebi.ListaForeDetallePoco.Where(x => x.idDetalle == cambio.idDetalle).ToList().SingleOrDefault() : CertificacionMasterPres.forese.ListaForeDetallePoco.Where(x => x.idDetalle == cambio.idDetalle).ToList().SingleOrDefault() : null;

            if (cambio != null)
            {
                switch (e.Column.FieldName)
                {
                    case "precio":
                        if (cambio.precio < 0)
                        {
                            EmitirMensajeResultado(true, "Precio debe ser mayor o igual a cero");
                            cambio.precio = 0;
                            cambio.subTotal = Math.Round(foreDetallePoco.cantidad * cambio.precio, 2);
                        }
                        else
                        {
                            cambio.precio = (decimal)e.Value;
                            cambio.subTotal = Math.Round(foreDetallePoco.cantidad * cambio.precio, 2);
                        }

                        break;
                    case "cantidad":
                        if (cambio.cantidad < 0)
                        {
                            EmitirMensajeResultado(true, "Cantidad debe ser mayor o igual a cero");
                            cambio.cantidad = Original != null ? Original.cantidad : 0;
                            cambio.subTotal = Math.Round(cambio.cantidad * foreDetallePoco.precio, 2);
                        }
                        else if (Original != null && (Original.cantidad < cambio.cantidad) && (bool)certificacionMasterPres.esTotalDetallado)
                        {
                            EmitirMensajeResultado(true, "Cantidad actualizada supera cantidad original");
                            cambio.cantidad = Original.cantidad;
                            cambio.subTotal = Math.Round(cambio.cantidad * foreDetallePoco.precio, 2);
                        }
                        else if(!(bool)certificacionMasterPres.esTotalDetallado && cambio.cantidad > 1)
                        {
                            EmitirMensajeResultado(true, "Para este detalle la cantidad solo debe ser uno");
                            cambio.cantidad = 1;
                            cambio.subTotal = Math.Round(cambio.cantidad * foreDetallePoco.precio, 2);
                        }
                        else
                        {
                            cambio.cantidad = (decimal)e.Value;
                            cambio.subTotal = Math.Round(cambio.cantidad * foreDetallePoco.precio, 2);
                        }
                        break;
                }
            }
           
            gvRequerimiento.LayoutChanged();
            gvRequerimiento.RefreshData();
            sumaDetalles();
        }
        private void gvRequerimiento_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            ForeDetallePoco trab = e.Row as ForeDetallePoco;
            if (e.IsSetData)
            {
                if (this.listaDetallesSeleccionados.ContainsKey(trab))
                {
                    this.listaDetallesSeleccionados.Remove(trab);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    this.listaDetallesSeleccionados.Add(trab, true);
                }
            }
            if (e.IsGetData)
            {
                e.Value = this.listaDetallesSeleccionados.ContainsKey(trab);
            }
        }
        private void grvRequerimiento_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            var res = string.Empty;
            var cuenta = string.Empty;

            ColumnView view = sender as ColumnView;

            if (e.Column.FieldName == "idProAnuReaMen" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                res = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "idProAnuReaMen") != null ? view.GetListSourceRowCellValue(e.ListSourceRowIndex, "idProAnuReaMen").ToString() : "0";
                cuenta = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "numCuenta") != null ? view.GetListSourceRowCellValue(e.ListSourceRowIndex, "numCuenta").ToString() : "0";

                int vidReaMenDet = res != null ? (Convert.ToInt32(res)) : 0;

                if (vidReaMenDet > 0 || cuenta != "")
                {
                    e.DisplayText = cuenta;
                }
                else
                {
                    e.DisplayText = "SIN ASIGNAR";
                }
            }
        }
        private void obgDetalle_AgregarRegistro(object sender, EventArgs e)
        {
            ForeDetallePoco foreDetallePoco = new ForeDetallePoco
            {
                idCerDet = null,idDetalle = 0,idCabecera = 0,
                descripcion = "",unidad = "UNIDAD",precio = 0,cantidad = 1,subTotal = 0,
                idProAnuReaMen = 0,tipoDet = 0,idCueCon = 0,numCuenta = "",
                saldoSoles = 0,saldoDolares = 0
            };
            listaForeDetallePoco.Add(foreDetallePoco);
            listaDatosPrincipales = listaForeDetallePoco;
        }
        private void obgDetalle_QuitarRegistro(object sender, EventArgs e)
        {
            if (ListaDetallesSeleccionados.Count > 0)
            {
                foreach (ForeDetallePoco prov in ListaDetallesSeleccionados)
                {
                    listaForeDetallePoco.Remove(prov);
                }
                listaForeDetallePoco = listaForeDetallePoco;
                this.listaDetallesSeleccionados.Clear();
                sumaDetalles();
                gvRequerimiento.LayoutChanged();
            }
            else
                EmitirMensajeResultado(true, "Debe marcar selección de al menos un detalle, para eliminar");
        }
        private void obgDetalle_DesMarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
        }
        private void obgDetalle_MarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheck(true);
        }
        private void obgDetalle_NuevoDetalleRegistro(object sender, EventArgs e)
        {
            if (ListaDetallesSeleccionados.Count > 0)
            {
                AbrirAyudaSubPresupuestoDetalle((int)this.idSubPresupuesto);
            }
            else
                EmitirMensajeResultado(true, "Debe seleccionar al menos un detalle");
        }
        private void obgDetalle_VisualizarRegistro(object sender, EventArgs e)
        {
            AbrirAyudaPrecio(this.tipo);
        }
        private void riceSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            //int rowHandle = gvRequerimiento.FocusedRowHandle;
            var edit = (CheckEdit)sender;
            ActivarCheck((bool)edit.EditValue);
        }
        private void riceSeleccionar_CheckStateChanged(object sender, EventArgs e)
        {
            gvRequerimiento.CloseEditor();
        }

        /*Metodos*/
        private bool validar()
        {
            bool res = true;
            vmensaje = string.Empty;
            
            if (total == 0)
            {
                res = false;
                vmensaje = vmensaje + "\nTotal seleccionado debe ser mayor a 0";
            }
            if (ListaDetallesSeleccionados.Count == 0)
            {
                res = false;
                vmensaje = vmensaje + "\nDebe seleccionar al menos un detalle";
            }
            if (!verificaCuenta())
            {
                res = false;
                vmensaje = vmensaje + "\nUno ó mas detalles no tiene asignado una cuenta";
            }
            
            return res;
        }
        protected internal void ActivarTodosCheck(bool activa)
        {
            int filas = gvRequerimiento.RowCount;
            for (int i = 0; i < filas; i++)
            {
                ForeDetallePoco prov = ColumnaActual.GetRow(i) as ForeDetallePoco;
                if (activa)
                {
                    if (!this.listaDetallesSeleccionados.ContainsKey(prov))
                        this.listaDetallesSeleccionados.Add(prov, true);
                }
                else
                {
                    this.listaDetallesSeleccionados.Remove(prov);
                }
            }
            sumaDetalles();
            gvRequerimiento.LayoutChanged();
        }
        protected internal void ActivarCheck(bool activa)
        {
            if (activa)
            {
                if (!this.listaDetallesSeleccionados.ContainsKey(foreDetallePoco))
                {
                    this.listaDetallesSeleccionados.Add(foreDetallePoco, true);
                }
            }
            else
            {
                this.listaDetallesSeleccionados.Remove(foreDetallePoco);
            }
            sumaDetalles();
            gvRequerimiento.LayoutChanged();
        }
        private void AbrirAyudaSubPresupuestoDetalle(int idSubPresupuesto)
        {
            switch (this.certificacionRequerimiento.nivelPresupuesto)
            {
                case 2:
                    LlamarFormAyudaCuentaContable();
                    break;
                case 3:
                    //Asignamos Presupuesto Mensual
                    if (SubPresupuestoImporteCertificacion != null)
                    {
                        if ((bool)SubPresupuestoImporteCertificacion.esObra)
                        {
                            LlamarFormAyudaCuentaContable();
                        }
                        else
                        {
                            this.listaSubPresupuestoDetalle = certificacionRequerimientoAmpliacionPresentador.TraerListaSubPresupuestoDetalle(idSubPresupuesto);
                            if (this.listaSubPresupuestoDetalle.Count > 0)
                            {
                                using (frmAyudaSubPresupuestoDetalle frm = new frmAyudaSubPresupuestoDetalle(idSubPresupuesto, this.listaSubPresupuestoDetalle, foreDetallePoco))
                                {
                                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        SubPresupuestoDetallePres objDetPres = frm.Tag as SubPresupuestoDetallePres;
                                        if (objDetPres.saldoSoles > 0 && objDetPres.saldoDolares > 0)
                                            AsignarPresupuesto(objDetPres);
                                        else
                                        {
                                            EmitirMensajeResultado(true, "Tener en cuenta que la cuenta esta sin saldo a favor");
                                            AsignarPresupuesto(objDetPres);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                EmitirMensajeResultado(true, "No existen detalles para este Presupuesto Mensual, seleccione una cuenta manual");
                                LlamarFormAyudaCuentaContable();
                            }
                        }
                    }
                    else
                        EmitirMensajeResultado(true, "Problemas con el presupuesto mensual");
                break;
            }
        }
        protected internal void LlamarFormAyudaCuentaContable()
        {
            using (frmAyudaCuentaContable frm = new frmAyudaCuentaContable())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CuentaContable objCuenta = frm.Tag as CuentaContable;

                    AsignarPresupuesto(
                        new SubPresupuestoDetallePres
                        {
                            idProAnuReaMen = 0,
                            tipoDet = 0,
                            idCueCon = objCuenta.idCueCon,
                            numCuenta = objCuenta.numCuenta,
                            saldoSoles = 0,
                            saldoDolares = 0
                        }
                    );
                }
            }
        }
        protected internal void AsignarPresupuesto(SubPresupuestoDetallePres objDetPres)
        {
            foreach(ForeDetallePoco prov in ListaDetallesSeleccionados)
            {
                if (prov != null)
                {
                    prov.idProAnuReaMen = objDetPres.idProAnuReaMen;
                    prov.tipoDet = objDetPres.tipoDet;
                    prov.idCueCon = objDetPres.idCueCon;
                    prov.numCuenta = objDetPres.numCuenta;
                    prov.descripcion = (bool)certificacionMasterPres.esTotalDetallado ? prov.descripcion : objDetPres.desCuenta;
                    prov.saldoSoles = objDetPres.saldoSoles;
                    prov.saldoDolares = objDetPres.saldoDolares;
                }
            }
            gvRequerimiento.LayoutChanged();
        }
        private void AbrirAyudaPrecio(tipoAyudaFore tipo)
        {
            if (gvRequerimiento.DataRowCount > 0)
            {
                using (frmAyudaPrecioProducto frm = new frmAyudaPrecioProducto(foreDetallePoco, tipo))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Precio = frm.Tag as PrecioBienServicioPres;
                        foreDetallePoco.precio = Precio == null ? 0 : (decimal)Precio.precio;
                        foreDetallePoco.subTotal = Math.Round(foreDetallePoco.precio * foreDetallePoco.cantidad, 2);
                        gvRequerimiento.RefreshData();
                    }
                }
            }
            else
            {
                EmitirMensajeResultado(true, "No existen detalles");
            }
            gvRequerimiento.LayoutChanged();
        }
        private void sumaDetalles()
        {
            this.total = 0;
            if (ListaDetallesSeleccionados.Count > 0)
            {
                foreach (ForeDetallePoco det in ListaDetallesSeleccionados)
                {
                    if (det != null)
                    {
                        this.total = this.total + (decimal)det.subTotal;
                    }
                }
            }
        }
        private bool verificaCuenta()
        {
            bool res = true;
            
            if (ListaDetallesSeleccionados.Count > 0)
            {
                foreach (ForeDetallePoco det in ListaDetallesSeleccionados)
                {
                    if (det != null)
                    {
                        res = (det.idCueCon == null || det.idCueCon == 0) ? false : true;
                        if (!res) break;
                    }
                }
            }
            
            return res;   
        }
    }
}
