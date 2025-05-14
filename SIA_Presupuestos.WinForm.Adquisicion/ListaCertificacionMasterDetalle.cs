using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaCertificacionMasterDetalle : ControlDetalleBase, IListaCertificacionMasterDetalleVista
    {
        private ListaCertificacionMasterDetallePresentador listaCertificacionMasterDetallePresentador;

        public List<CertificacionRequerimientoPres> listaDatosPrincipales
        {
            set
            {
                grcCertificacion.DataSource = value;
            }
        }
        private CertificacionMasterPres certificacionMasterPres;

        GridView GridViewDetail = null;

        private decimal importeCotizado = 0;
        public CertificacionRequerimiento certificacionRequerimiento { get; set; }

        public ListaCertificacionMasterDetalle(CertificacionMasterPres certificacionMasterPres)
        {
            InitializeComponent();
            this.certificacionMasterPres = certificacionMasterPres;
            this.listaCertificacionMasterDetallePresentador = new ListaCertificacionMasterDetallePresentador(certificacionMasterPres, this);
            Text = "Certificación de Requerimiento - [ " + certificacionMasterPres.numeroReq + " ]";
            esSoloListado = true;
            this.certificacionRequerimiento = new CertificacionRequerimiento();
        }

        protected override ColumnView ColumnaActual { get { return grcCertificacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcCertificacion; } }
        protected ColumnView ColumnaActualDetalle
        {
            get { return (grcCertificacion.ViewCollection.Count < 3 ? null : grcCertificacion.ViewCollection[2]) as ColumnView; }   
        }

        public CertificacionRequerimientoPres certificacionRequerimientoPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as CertificacionRequerimientoPres;
                if (pro != null) this.certificacionRequerimiento = listaCertificacionMasterDetallePresentador.Buscar((Int32)pro.idCerReq);

                //return pro != null ? listaCertificacionMasterDetallePresentador.Buscar((Int32)pro.idCerReq) : null;
                return pro != null ? pro : null;
            }
        }
        public CertificacionDetallePres certificacionDetallePres
        {
            get
            {
                if (ColumnaActualDetalle == null || ColumnaActualDetalle.FocusedRowHandle < 0) return null;
                var pro = GridViewDetail.FocusedRowHandle < 0 ? null : GridViewDetail.GetRow(GridViewDetail.FocusedRowHandle) as CertificacionDetallePres;
                return pro;
            }
        }

        protected override void InicializarDatos()
        {
            //this.listaCertificacionMasterDetallePresentador.IniciarDatos();
        }
        protected override void InicializarValidacion()
        {
        }
        protected override bool ValidarDatos()
        {
            return ProveedorValidacion.Validate(); 
        }

        protected override void Nuevo()
        {
            this.certificacionMasterPres.validarForebisePres = listaCertificacionMasterDetallePresentador.ValidarForebise(this.certificacionMasterPres.idCerMas);

            //Actualizamos Datos Forebise
            if (this.certificacionMasterPres.tipoReq == 1)

                this.certificacionMasterPres.forebi = listaCertificacionMasterDetallePresentador.BuscarForebi(this.certificacionMasterPres.idForebise);
            else
                this.certificacionMasterPres.forese = listaCertificacionMasterDetallePresentador.BuscarForese(this.certificacionMasterPres.idForebise);


            if (this.certificacionMasterPres.validarForebisePres != null && (bool)this.certificacionMasterPres.validarForebisePres.respuesta)
            {
                using (frmCertificacionRequerimiento frm = new frmCertificacionRequerimiento(this.certificacionMasterPres, null, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
                if (this.listaCertificacionMasterDetallePresentador.BuscarCertificacionMaster(this.certificacionMasterPres.idCerMas) == null) Cerrar();
            }
            else
                EmitirMensajeResultado(true, this.certificacionMasterPres.validarForebisePres.mensaje);
        }
        protected override void Modificar()
        {
            if (this.certificacionRequerimientoPres != null)
            {
                
                using (frmCertificacionRequerimiento frm = new frmCertificacionRequerimiento(this.certificacionMasterPres, this.certificacionRequerimiento, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
                if (this.listaCertificacionMasterDetallePresentador.BuscarCertificacionMaster(this.certificacionMasterPres.idCerMas) == null) Cerrar();
            }
            else
                EmitirMensajeResultado(true, "Error : Seleccione una certificación requerimiento válido");
        }
        protected override void Anular()
        {
            if (this.certificacionRequerimientoPres != null)
            {
                var res = this.listaCertificacionMasterDetallePresentador.VerificaCertificacionDetalle((int)this.certificacionRequerimientoPres.idCerReq, null);
                if (Convert.ToBoolean(res.repuesta))
                {
                    if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                    {
                        if (listaCertificacionMasterDetallePresentador.Anular())
                            EmitirMensajeResultado(true, "Anulado correctamente");
                        else
                            EmitirMensajeResultado(false, "No se puedo anular");
                    }
                }
                else
                    EmitirMensajeResultado(true, "Detalle no se puede anular, ya existe en orden");
            }
            else
                EmitirMensajeResultado(true, "Seleccione un detalle válido");
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleDet":
                    AbrirDetalle(false);
                    break;
                case "ModificarDetalle":
                    AbrirDetalle(true);
                    break;
                case "AnularDetalle":
                    AnularDetalle();
                    break;
                case "ImpresionCertificacion":
                    ImprimirCertificacion(false);
                    break;
                case "AmpliacionCertificacion":
                    RegistroAmpliacion();
                    break;
                case "AsignarSubpresupuesto":
                    AsignaciónSubpresupuesto();
                    break;
                case "CambioEstadoCert":
                    CambioEstado();
                    break;
                case "ImpresionCertificacionAmp":
                    ImprimirCertificacion(true);
                    break;
                case "ActualizarImporte":
                    ActualizarImportes();
                    break;
            }
        }
        protected override void LlenarGrid()
        {
            listaCertificacionMasterDetallePresentador.ObtenerDatosListado();
        }
        protected override void GuardarDatos()
        {
        }
        protected override void CerrarFormularioCancelar()
        {

        }
        protected override void LlenarLookUpGenerales()
        {
        }
        
        private void grvCertificacionReq_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridView detail = grvCertificacionReq.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            if (view != null)
            {
                GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                if (detailView != null) detailView.ExpandGroupRow(-1);
            }
            GridViewDetail = detail;
        }

        protected void AnularDetalle()
        {
            if ( this.certificacionDetallePres != null)
            {
                if (this.certificacionRequerimientoPres.estado == 10)
                {
                    EmitirMensajeResultado(true, "No puedes modificar detalles, certificación ya esta aprobada");
                    return;
                }

                if (this.certificacionDetallePres.cantPendiente > 0)
                {
                    EmitirMensajeResultado(true, "Detalle no se puede modificar, ya existe en orden");
                    return;
                }

                
                var res = this.listaCertificacionMasterDetallePresentador.VerificaCertificacionDetalle(null, (int)this.certificacionDetallePres.idCerDet);

                string numCuenta = string.Empty;

                //var gv = grcCertificacion.MainView as GridView;
                //var topRowIndex = gv.TopRowIndex;
                //var index = gv.FocusedRowHandle;

                //var vistaDet = (ColumnView)grcCertificacion.FocusedView;
                //var indexDet = vistaDet.FocusedRowHandle;

                if (Convert.ToBoolean(res.repuesta))
                {
                    if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                    {
                        if (listaCertificacionMasterDetallePresentador.AnularDetalle(this.certificacionRequerimiento, this.certificacionDetallePres))
                        {
                            EmitirMensajeResultado(true, "Anulado correctamente");

                            LlenarGrid();

                            //grvCertificacionReq.SetMasterRowExpanded(index, true);
                            //grvCertificacionReq.FocusedRowHandle = index;
                            //grvCertificacionReq.TopRowIndex = topRowIndex;
                        }
                        else
                            EmitirMensajeResultado(false, "No se puedo anular el detalle");
                    }
                }
                else
                    EmitirMensajeResultado(true, res.mensaje);
                
            }
            else
                EmitirMensajeResultado(true, "Seleccione un detalle válido");
        }
        private void AbrirDetalle(bool esModificacion)
        {
            if (certificacionRequerimientoPres != null)
            {
                string numCuenta = string.Empty;

                CertificacionDetallePres vcertificacionMasterPres = esModificacion ? this.certificacionDetallePres : null;
                if (esModificacion)
                {
                    if (this.certificacionDetallePres != null)
                    {
                        if (this.certificacionRequerimientoPres.estado == 10)
                        {
                            EmitirMensajeResultado(true, "No puedes modificar detalles, certificación ya esta aprobada");
                            return;
                        }

                        if (this.certificacionDetallePres.cantPendiente > 0)
                        {
                            EmitirMensajeResultado(true, "Detalle no se puede modificar, ya existe en orden");
                            return;
                        }
                        
                        using (frmBuscarForebi frm = new frmBuscarForebi(this.certificacionMasterPres, this.certificacionRequerimiento, vcertificacionMasterPres, this.FindForm(), this.certificacionMasterPres.tipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LlenarGrid();
                            }
                        }
                    }
                    else
                        EmitirMensajeResultado(true, "Seleccione un detalle válido");
                }
                else
                {
                    using (frmBuscarForebi frm = new frmBuscarForebi(this.certificacionMasterPres, this.certificacionRequerimiento, null, this.FindForm(), this.certificacionMasterPres.tipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LlenarGrid();
                        }
                    }
                }

            }
            else
                EmitirMensajeResultado(true, "Seleccione una certificación válida");
        }
        private void ImprimirCertificacion(bool esAmpliacion)
        {
            string vmensaje = esAmpliacion? "Certificación sin ampliación ó ha ocurrido un problema" : "Certificación sin detalles ó ha ocurrido un problema";
            if (certificacionRequerimientoPres != null)
            {
                List<ReporteCertificacionPresupuestalPres> lista = listaCertificacionMasterDetallePresentador.TraerReporteCertificacionPresupuestal(esAmpliacion);
                if (lista.Count > 0)
                    listaCertificacionMasterDetallePresentador.ReporteCertificacionPresupuestal(lista);
                else
                    EmitirMensajeResultado(true, vmensaje);
            }
            else
                EmitirMensajeResultado(true, "Seleccione un detalle válido");
        }
        private void RegistroAmpliacion()
        {
            if (certificacionRequerimientoPres != null)
            {
                using (frmCertificacionRequerimientoAmpliacion frm = new frmCertificacionRequerimientoAmpliacion(this.certificacionMasterPres, this.certificacionRequerimiento, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
            else
                EmitirMensajeResultado(true, "Seleccione un registro válido");
        }
        private void AsignaciónSubpresupuesto()
        {
            if (certificacionRequerimientoPres != null)
            {
                if ((bool)this.certificacionMasterPres.esAnual)
                {
                    using (frmCertificacionRequerimientoSubpresupuesto frm = new frmCertificacionRequerimientoSubpresupuesto(this.certificacionMasterPres, this.certificacionRequerimiento, this.FindForm(), null))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LlenarGrid();
                        }
                    }
                }
                else
                    EmitirMensajeResultado(true, "No se puede asignar presupuesto mensual a requerimiento mensual");
            }
            else
                EmitirMensajeResultado(true, "Seleccione un registro válido");
        }
        private void CambioEstado()
        {
            if (this.certificacionRequerimientoPres != null)
            {
                var ob = this.certificacionRequerimientoPres;
                importeCotizado = this.listaCertificacionMasterDetallePresentador.TraerImporteCotizacionPorCertificacion();
                var listaOrden = this.listaCertificacionMasterDetallePresentador.TraerListaOrdenPorCertificacion();

                if (this.certificacionRequerimientoPres.estado == 10 && listaOrden.Count > 0)
                {
                    EmitirMensajeResultado(true, "No se realizó actualización, certificación ya esta aprobada y tiene orden");
                    return;
                }
                if (this.certificacionRequerimientoPres.estado==2 && this.certificacionRequerimientoPres.totalSoles!=importeCotizado)
                {
                    EmitirMensajeResultado(true, "Debes actualizar importes de certificación");
                    return;
                }

                using (frmCambioEstado frm = new frmCambioEstado(this.certificacionRequerimiento, this.listaCertificacionMasterDetallePresentador.TraerListaEstado(), this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
            else
                EmitirMensajeResultado(true, "Seleccione un registro válido");
        }
        private void ActualizarImportes()
        {
            if (this.certificacionRequerimientoPres != null)
            {
                importeCotizado = this.listaCertificacionMasterDetallePresentador.TraerImporteCotizacionPorCertificacion();
                var listaOrden = this.listaCertificacionMasterDetallePresentador.TraerListaOrdenPorCertificacion();
                if (this.certificacionRequerimientoPres.estado == 10 && listaOrden.Count>0)
                {
                    EmitirMensajeResultado(true, "No se realizó actualización, certificación ya esta aprobada y tiene orden");
                    return;
                }

                if (this.certificacionRequerimientoPres.estado == 2 && this.certificacionRequerimientoPres.totalSoles == importeCotizado)
                {
                    EmitirMensajeResultado(true, "No se realizó actualización, importe de certificación es igual el cotizado");
                    return;
                }

                if (EmitirMensajePregunta(Mensajes.PreguntaActualizaImporte))
                {
                    if (this.listaCertificacionMasterDetallePresentador.ActualizarImporte())
                        EmitirMensajeResultado(true, "Se Actualizó importes correctamente");
                    else
                        EmitirMensajeResultado(true, "No se actualizó importes, o no hay registros para actualizar");
                }
            }
            else
                EmitirMensajeResultado(true, "Seleccione un registro válido");
        }
        private void RefrescarGrilla(int fila)
        {
            if (grvCertificacionReq.GetMasterRowExpanded(fila))
            {
                grvCertificacionReq.SetMasterRowExpanded(fila, false);
                grvCertificacionReq.SetMasterRowExpanded(fila, true);
            }
        }
        void detail_Click(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            var value = gridView.GetRowCellValue(gridView.FocusedRowHandle, "idCerDet");//gridView.FocusedColumn);
            MessageBox.Show("Cell value: " + value.ToString(), "Message");
        }

    }
}
