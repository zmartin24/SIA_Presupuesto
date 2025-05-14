using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Ayuda;
using DevExpress.XtraCharts.Designer.Native;

namespace SIA_Presupuesto.WinForm.Adquisicion.Controles
{
    public partial class SeleccionRequerimientoDetalle : XtraUserControl, ISeleccionRequerimientoDetalleVista
    {
        private SeleccionRequerimientoDetallePresentador seleccionRequerimientoDetallePresentador;
        private CertificacionMasterPres certificacionMasterPres;
        private CertificacionRequerimiento certificacionRequerimiento;
        private CertificacionDetallePres certificacionDetallePres = null;
        #region vistas
        public List<ForeDetallePoco> listaForeDetallePoco
        {
            set
            {
                gcRequerimiento.DataSource = value;
                gvRequerimiento.LayoutChanged();
                gvRequerimiento.RefreshData();
            }
        }
        #endregion

        private Forebi forebi;
        private Forese forese;
        private PrecioBienServicioPres precio { get; set; }
        private ForeDetallePoco foreDetallePoco
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ForeDetallePoco;
            }
        }
        public string vmensaje { set; get; }
        public decimal vsuma { set; get; }

        private Dictionary<ForeDetallePoco, bool> listaDetallesSeleccionados;
        private tipoAyudaFore tipo;
        private bool esModificacion;
        private bool esReqCab;


        public List<ForeDetallePoco> listaForeDetallePocoOriginal
        {
            set; get;
        }
        
        public List<ForeDetallePoco> ListaDetallesSeleccionados
        {
            get { return listaDetallesSeleccionados.Keys.ToList(); }
        }
        public List<ForeDetallePoco> listaForeDetallePocoPorCuenta = new List<ForeDetallePoco>();
        public Forebi Forebi
        {
            get { return forebi; }
            set
            {
                forebi = value;
                //if (value != null)
                //{
                //    txtReq.Text = value.numero;

                //}
                //else
                //{
                //    txtReq.Text = string.Empty;

                //}
            }
        }
        public Forese Forese
        {
            get { return forese; }
            set
            {
                forese = value;
                //if (value != null)
                //{
                //    txtReq.Text = value.numero;

                //}
                //else
                //{
                //    txtReq.Text = string.Empty;

                //}
            }
        }
        public SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion
        {
            set; get;
        }
        private List<SubPresupuestoDetallePres> listaSubPresupuestoDetalle;
        public bool esAnual = false;



        public SeleccionRequerimientoDetalle(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres, bool esReqCab)
        {
            InitializeComponent();
            this.certificacionMasterPres = certificacionMasterPres;
            this.certificacionRequerimiento = certificacionRequerimiento;
            this.certificacionDetallePres = certificacionDetallePres;
            this.esAnual = certificacionRequerimiento.nivelPresupuesto < 3 ? true : false;
            seleccionRequerimientoDetallePresentador = new SeleccionRequerimientoDetallePresentador(certificacionMasterPres, certificacionRequerimiento, certificacionDetallePres, this);
            
            this.tipo = certificacionMasterPres.tipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio;
            this.esReqCab = esReqCab;
            this.esModificacion = certificacionRequerimiento.idCerReq != 0;
            
            this.listaDetallesSeleccionados = new Dictionary<ForeDetallePoco, bool>();
            ListaDetallesSeleccionados.Clear();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            obgDetalle.Inicializar(gvRequerimiento);

            seleccionRequerimientoDetallePresentador.LlenarGrid();

            

            if (this.certificacionDetallePres != null)
            {
                ActivarTodosCheck(true);
            }
            obgDetalle_ActivarBotones((bool)this.certificacionMasterPres.esTotalDetallado);
            //Si es invocado desde certificacion requrimiento en editar
            if (this.esReqCab) //if (this.esReqCab && this.esModificacion)
            {
                //obgDetalle.Enabled = false;
                riseCant.ReadOnly = true;
                risePrecio.ReadOnly = true;
            }
            
            

        }
        
        //Para fila seleccionada
        public ColumnView ColumnaActual { get { return gcRequerimiento.MainView as ColumnView; } }
        protected ColumnView VistaActual { get { return gcRequerimiento.MainView as GridView; } }

        protected internal void ActivarTodosCheck(bool activa)
        {
            int filas = gvRequerimiento.RowCount;
            gvRequerimiento.LayoutChanged();
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
        private void obgDetalle_AgregarRegistro(object sender, EventArgs e)
        {
            ForeDetallePoco foreDetallePoco = new ForeDetallePoco
            {
                idCerDet = null,
                idDetalle = 0,
                idCabecera = 0,
                descripcion = "DETALLE",
                unidad = "UNIDAD",
                precio = 0,
                cantidad = 1,
                subTotal = 0,
                idProAnuReaMen = 0,
                tipoDet = 0,
                idCueCon = 0,
                numCuenta = "",
                saldoSoles = 0,
                saldoDolares = 0

            };
            listaForeDetallePocoPorCuenta.Add(foreDetallePoco);
            listaForeDetallePoco = listaForeDetallePocoPorCuenta;
        }
        private void obgDetalle_QuitarRegistro(object sender, EventArgs e)
        {
            if (ListaDetallesSeleccionados.Count > 0)
            {
                foreach (ForeDetallePoco prov in ListaDetallesSeleccionados)
                {
                    listaForeDetallePocoPorCuenta.Remove(prov);
                }
                listaForeDetallePoco = listaForeDetallePocoPorCuenta;
                this.listaDetallesSeleccionados.Clear();
                sumaDetalles();
                gvRequerimiento.LayoutChanged();
            }
            else
                XtraMessageBox.Show("Debe marcar selección de al menos un detalle, para eliminar", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void obgDetalleMarcar_DesmarcarTodosRegistro(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
        }
        private void obgDetalleMarcar_MarcarTodosRegistro(object sender, EventArgs e)
        {
            ActivarTodosCheck(true);
        }
        private void obgDetalle_VisualizarRegistro(object sender, EventArgs e)
        {
            AbrirAyudaPrecio(this.tipo);
        }
        private void obgDetalle_NuevoDetalleRegistro(object sender, EventArgs e)
        {
            if (ListaDetallesSeleccionados.Count > 0)
            {
                AbrirAyudaSubPresupuestoDetalle();
            }
            else
                XtraMessageBox.Show("Debe seleccionar al menos un detalle", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void gvRequerimiento_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var cambio = gvRequerimiento.GetRow(e.RowHandle) as ForeDetallePoco;

            decimal cantOriginal = this.certificacionDetallePres == null ? cambio.cantidad : (bool)this.certificacionDetallePres.esAmpliacion ? 0 : certificacionMasterPres.esTotalDetallado == true ? this.certificacionDetallePres != null ? (decimal)seleccionRequerimientoDetallePresentador.TraerCantPendiente((int)this.certificacionDetallePres.idForeDet, (int)this.tipo) + (decimal)this.certificacionDetallePres.cantidad : 0 : 0;

            if (cambio != null)
            {
                switch (e.Column.FieldName)
                {
                    case "precio":
                        if (cambio.precio < 0)
                        {
                            //EmitirMensajeResultado(true, "Precio debe ser mayor o igual a cero");
                            XtraMessageBox.Show("Precio debe ser mayor o igual a cero", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            //EmitirMensajeResultado(true, "Cantidad debe ser mayor o igual a cero");
                            XtraMessageBox.Show("Cantidad debe ser mayor o igual a cero", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cambio.cantidad = (decimal)this.certificacionDetallePres.cantidad;
                            cambio.subTotal = Math.Round(cambio.cantidad * foreDetallePoco.precio, 2);
                        }
                        else if (cantOriginal > 0 && (cantOriginal < cambio.cantidad) && (bool)certificacionMasterPres.esTotalDetallado)
                        {
                            //EmitirMensajeResultado(true, "Cantidad actualizada supera cantidad orginal de " + cantOriginal.ToString());
                            XtraMessageBox.Show("Cantidad actualizada supera cantidad orginal de ", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cambio.cantidad = (decimal)this.certificacionDetallePres.cantidad;
                            cambio.subTotal = Math.Round(cambio.cantidad * foreDetallePoco.precio, 2);
                        }
                        else if (!(bool)certificacionMasterPres.esTotalDetallado && cambio.cantidad > 1)
                        {
                            //EmitirMensajeResultado(true, "Para este detalle la cantidad solo debe ser uno");
                            XtraMessageBox.Show("Para este detalle la cantidad solo debe ser uno", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void riceSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            int rowHandle = gvRequerimiento.FocusedRowHandle;
            var edit = (CheckEdit)sender;
            ActivarCheck((bool)edit.EditValue);
        }
        private void riceSeleccionar_CheckStateChanged(object sender, EventArgs e)
        {
            gvRequerimiento.CloseEditor();
        }

        private void AbrirAyudaPrecio(tipoAyudaFore tipo)
        {
            var Precio= new PrecioBienServicioPres();
            if (gvRequerimiento.DataRowCount > 0)
            {
                using (frmAyudaPrecioProducto frm = new frmAyudaPrecioProducto(foreDetallePoco, tipo))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        switch (tipo)
                        {
                            case tipoAyudaFore.bien:
                                Precio = frm.Tag as PrecioBienServicioPres;
                                foreDetallePoco.precio = (decimal)Precio.precio;
                                foreDetallePoco.subTotal = Math.Round(foreDetallePoco.precio * foreDetallePoco.cantidad, 2);
                                break;
                            case tipoAyudaFore.servicio:
                                Precio = frm.Tag as PrecioBienServicioPres;
                                foreDetallePoco.precio = (decimal)Precio.precio;
                                foreDetallePoco.subTotal = Math.Round(foreDetallePoco.precio * foreDetallePoco.cantidad, 2);
                                break;
                        }
                        gvRequerimiento.RefreshData();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No existen detalles", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gvRequerimiento.LayoutChanged();
        }
        
        private void sumaDetalles()
        {
            vsuma = 0;
            int filas = gvRequerimiento.RowCount;
            for (int i = 0; i < filas; i++)
            {
                ForeDetallePoco prov = ColumnaActual.GetRow(i) as ForeDetallePoco;
                vsuma = vsuma + (decimal)prov.subTotal;
            }
        }
        private void obgDetalle_ActivarBotones(bool opcion)
        {
            obgDetalle.ConVisualizar = opcion;
            riseCant.ReadOnly = !opcion;
            obgDetalle.ConAgregar = !opcion;
            obgDetalle.ConQuitar = !opcion;

            obgDetalle.HabilitarAgregar(!opcion);
            obgDetalle.HabilitarEliminar(!opcion);
        }
        
        private void AbrirAyudaSubPresupuestoDetalle()
        {
            switch(certificacionRequerimiento.nivelPresupuesto)
            {
                case 2: LlamarFormAyudaCuentaContable();
                    break;
                case 3:
                    //Asignamos Presupuesto Mensual
                    seleccionRequerimientoDetallePresentador.TraerSubPresupuestoImporteCertificacion(certificacionRequerimiento.idPresupuesto != null && certificacionRequerimiento.nivelPresupuesto == 3 ? (int)certificacionRequerimiento.idPresupuesto : 0);
                    if (SubPresupuestoImporteCertificacion != null)
                    {
                        if ((bool)SubPresupuestoImporteCertificacion.esObra)
                        {
                            LlamarFormAyudaCuentaContable();
                        }
                        else
                        {
                            this.listaSubPresupuestoDetalle = seleccionRequerimientoDetallePresentador.TraerListaSubPresupuestoDetalle((int)certificacionRequerimiento.idPresupuesto);
                            if (this.listaSubPresupuestoDetalle.Count > 0)
                            {
                                using (frmAyudaSubPresupuestoDetalle frm = new frmAyudaSubPresupuestoDetalle((int)certificacionRequerimiento.idPresupuesto, this.listaSubPresupuestoDetalle, foreDetallePoco))
                                {
                                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        SubPresupuestoDetallePres objDetPres = frm.Tag as SubPresupuestoDetallePres;
                                        if (objDetPres.saldoSoles > 0 && objDetPres.saldoDolares > 0)
                                            AsignarPresupuesto(objDetPres);
                                        else
                                        {
                                            XtraMessageBox.Show("Tener en cuenta que la cuenta esta sin saldo a favor", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            AsignarPresupuesto(objDetPres);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("No existen detalles para este Presupuesto Mensual, seleccione una cuenta manual", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LlamarFormAyudaCuentaContable();
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Problemas con el presupuesto mensual", Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            foreach (ForeDetallePoco prov in ListaDetallesSeleccionados)
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


    }
}
