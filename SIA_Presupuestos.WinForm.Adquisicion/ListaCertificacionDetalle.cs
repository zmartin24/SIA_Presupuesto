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
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Adquisicion.Ayuda;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaCertificacionDetalle : ControlDetalleBase, IListaCertificacionDetalleVista
    {
        private ListaCertificacionDetallePresentador listaCertificacionDetallePresentador;

        public List<CertificacionDetallePres> listaDatosPrincipales
        {
            set
            {
                grcCertificacionDetalle.DataSource = value;
            }
        }
        public CertificacionDetallePres certificacionDetallePres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as CertificacionDetallePres;
            }
        }

        private CertificacionRequerimiento certificacionRequerimiento;

        public ListaCertificacionDetalle(CertificacionRequerimiento certificacionRequerimiento)
        {
            InitializeComponent();
            this.certificacionRequerimiento = certificacionRequerimiento;
            this.listaCertificacionDetallePresentador = new ListaCertificacionDetallePresentador(this.certificacionRequerimiento, this);
            Text = "Detalles" + certificacionRequerimiento.sigla;
        }

        protected override ColumnView ColumnaActual { get { return grcCertificacionDetalle.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcCertificacionDetalle; } }

        protected override void InicializarDatos()
        {
            //this.listaCertificacionDetallePresentador.IniciarDatos();
        }

        protected override void InicializarValidacion()
        {

        }
        protected override bool ValidarDatos()
        {
            return ProveedorValidacion.Validate(); 
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch(nomOperacion)
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
            }
        }

        protected override void LlenarGrid()
        {
            listaCertificacionDetallePresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            //using (frmBuscarForebi frm = new frmBuscarForebi(certificacionRequerimiento, this.FindForm(), certificacionRequerimiento.tipoReq==1? tipoAyudaFore.bien : tipoAyudaFore.servicio ))
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        LlenarGrid();
            //    }
            //}
        }

        protected override void Modificar()
        {
            //using (frmBuscarForebi frm = new frmBuscarForebi(certificacionRequerimiento, certificacionDetallePres, this.FindForm(), certificacionRequerimiento.tipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio))
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        LlenarGrid();
            //    }
            //}
        }

        protected override void Anular()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaCertificacionDetallePresentador.Anular())
                    EmitirMensajeResultado(true, "Anulado correctamente");
                else
                    EmitirMensajeResultado(false, "No se puedo anular");
            }
        }

        protected void AnularDetalle()
        {
            //if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            //{
            //    if (listaCertificacionDetallePresentador.AnularDetalle())
            //        EmitirMensajeResultado(true, "Anulado correctamente");
            //    else
            //        EmitirMensajeResultado(false, "No se puedo anular el detalle");
            //}
        }

        private void AbrirDetalle(bool esModificacion)
        {
            //if (planAnualAdquisicionRequerimiento != null)
            //{
            //    string numCuenta = string.Empty;
                
            //    var gv = grcProgramacion.MainView as GridView;
            //    var topRowIndex = gv.TopRowIndex;
            //    var index = gv.FocusedRowHandle;

            //    var vistaDet = (ColumnView)grcProgramacion.FocusedView;
            //    var indexDet = vistaDet.FocusedRowHandle;

            //    using (frmPlanAnualAdquisicionDetalle frm = new frmPlanAnualAdquisicionDetalle("", numCuenta, planAnualAdquisicionRequerimiento, esModificacion ? planAnualAdquisicionDetalle : null, this.FindForm()))
            //    {
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            LlenarGrid();

            //            grvProgramacion.SetMasterRowExpanded(index, true);
            //            grvProgramacion.FocusedRowHandle = index;
            //            grvProgramacion.TopRowIndex = topRowIndex;
            //        }
            //    }
            //}
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
        
    }
}
