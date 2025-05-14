using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaRequerimientoMensualDetalle : ControlDetalleBase, IListaRequerimientoMensualDetalleVista
    {
        private ListaRequerimientoMensualDetallePresentador listaRequerimientoMensualDetallePresentador;

        public List<RequerimientoMensualDetallePres> listaDatosPrincipales
        {
            set
            {
                grcRequerimientoDetalle.DataSource = value;
            }
        }

        public string descripcion
        {
            set { txtDescripcion.Text = value; }
        }
        public string desArea
        {
            set { txtArea.Text = value; }
        }
        public string desTipo
        {
            set { txtDesTipo.Text = value; }
        }
        public string desMoneda
        {
            set { txtMoneda.Text = value; }
        }

        private RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres;

        GridView GridViewDetail = null;
        
        public ListaRequerimientoMensualDetalle(RequerimientoMensualBienServicioPres requerimientoMensualBienServicio)
        {
            InitializeComponent();
            this.requerimientoMensualBienServicioPres = requerimientoMensualBienServicio;
            this.listaRequerimientoMensualDetallePresentador = new ListaRequerimientoMensualDetallePresentador(requerimientoMensualBienServicio, this);
            Text = "Detalle de Requerimiento Mensual";
            esSoloListado = true;
        }

        protected override ColumnView ColumnaActual { get { return grcRequerimientoDetalle.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcRequerimientoDetalle; } }
        
        public RequerimientoMensualDetalle requerimientoMensualDetalle
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoMensualDetallePres;
                return pro != null ? listaRequerimientoMensualDetallePresentador.BuscarDetalle((Int32)pro.idReqMenDet) : null;
            }
        }
        
        protected override void InicializarDatos()
        {
            this.listaRequerimientoMensualDetallePresentador.Iniciar();
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
            using (frmRequerimientoMensualDetalle frm = new frmRequerimientoMensualDetalle(null, this.requerimientoMensualBienServicioPres, string.Empty, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            AbrirDetalle("EDITA");
            //if (this.requerimientoMensualDetalle != null)
            //{
            //    using (frmRequerimientoMensualDetalle frm = new frmRequerimientoMensualDetalle(this.requerimientoMensualDetalle, this.requerimientoMensualBienServicioPres, "EDITA", this.FindForm()))
            //    {
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            LlenarGrid();
            //        }
            //    }
            //}
            //else
            //    EmitirMensajeResultado(true, "Error : Seleccione un detalle de requerimiento válido");
        }
        protected override void Anular()
        {
            if (this.requerimientoMensualDetalle != null)
            {
                if (this.requerimientoMensualBienServicioPres.estado.Equals(2))
                {
                    if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                    {
                        if (this.listaRequerimientoMensualDetallePresentador.Anular())
                            EmitirMensajeResultado(true, "Anulado correctamente");
                        else
                            EmitirMensajeResultado(false, "No se puedo anular");
                    }
                }
                else
                    EmitirMensajeResultado(true, "Error : no es posisble editar, requerimiento ya fue procesado");
            }
            else
                EmitirMensajeResultado(true, "Seleccione un detalle válido");
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "VerificaCantApro":
                    AbrirDetalle("EDITA_APRUEBA");
                    break;
                
            }
        }
        protected void AbrirDetalle(string tipoProceso)
        {
            if (this.requerimientoMensualDetalle != null)
            {
                if (
                    this.requerimientoMensualBienServicioPres.estado.Equals(Estados.Activo) && tipoProceso.Equals("EDITA") || 
                    this.requerimientoMensualBienServicioPres.estado.Equals(Estados.Aprobado) && tipoProceso.Equals("EDITA_APRUEBA")
                    )
                {
                    using (frmRequerimientoMensualDetalle frm = new frmRequerimientoMensualDetalle(this.requerimientoMensualDetalle, this.requerimientoMensualBienServicioPres, tipoProceso, this.FindForm()))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LlenarGrid();
                        }
                    }
                }
                else
                    EmitirMensajeResultado(true, "Error: no es posisble editar, requerimiento ya fue procesado");
                //if (this.listaRequerimientoMensualDetallePresentador.BuscarCertificacionMaster(this.certificacionMasterPres.idCerMas) == null) Cerrar();
            }
            else
                EmitirMensajeResultado(true, "Error : Seleccione un detalle de requerimiento válido");
        }
        protected override void LlenarGrid()
        {
            listaRequerimientoMensualDetallePresentador.ObtenerDatosListado();
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
            GridView detail = grvRequerimientoDetalle.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            if (view != null)
            {
                GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                if (detailView != null) detailView.ExpandGroupRow(-1);
            }
            GridViewDetail = detail;
        }

    }
}
