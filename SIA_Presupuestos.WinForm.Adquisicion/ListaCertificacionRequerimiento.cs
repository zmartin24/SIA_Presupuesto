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
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaCertificacionRequerimiento : ControlBase, IListaCertificacionRequerimientoVista
    {
        private ListaCertificacionRequerimientoPresentador listaCertificacionRequerimientoPresentador;

        public List<CertificacionRequerimientoPres> listaDatosPrincipales
        {
            set
            {
                grcCertificacionReq.DataSource = value;
            }
        }
        public CertificacionRequerimiento certificacionRequerimiento
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var obj = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as CertificacionRequerimientoPres;
                return obj != null ? listaCertificacionRequerimientoPresentador.Buscar(obj.idCerReq) : null;
            }
        }
        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public int anioPresentacion
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }
        private bool inicio = false;
        public bool Inicio
        {
            get { return inicio; }
            set { value = inicio; }
        }

        public ListaCertificacionRequerimiento()
        {
            InitializeComponent();
            this.listaCertificacionRequerimientoPresentador = new ListaCertificacionRequerimientoPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcCertificacionReq.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcCertificacionReq; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaCertificacionRequerimientoPresentador.Iniciar();
        }
        protected override void LlenarGrid()
        {
            listaCertificacionRequerimientoPresentador.ObtenerDatosListado();
            inicio = true;
        }
        protected override void Nuevo()
        {
            //using (frmCertificacionRequerimiento frm = new frmCertificacionRequerimiento(null, this.FindForm()))
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        LlenarGrid();
            //    }
            //}
        }
        protected override void Modificar()
        {
            //using (frmCertificacionRequerimiento frm = new frmCertificacionRequerimiento(certificacionRequerimiento, this.FindForm()))
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        LlenarGrid();
            //    }
            //}
        }
        public override bool Anular()
        {
           
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaCertificacionRequerimientoPresentador.Anular())
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
                }
            }
           
            return true;
        }
        protected override void Imprimir()
        {
            if (certificacionRequerimiento != null)
            {
                List<ReporteCertificacionPresupuestalPres> lista = listaCertificacionRequerimientoPresentador.TraerReporteCertificacionPresupuestal();
                if (lista.Count > 0)
                    listaCertificacionRequerimientoPresentador.ReporteCertificacionPresupuestal(lista);
                else
                    EmitirMensajeResultado(true, "Certificación sin Detalles o ha ocurrido un problema");
            }
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "detalleCertificacion": DetalleCertificacion(); break;
                case "ExportarPresAnu": ExportarProgramacionAnual(); break;
            }
        }
        
        private void DetalleCertificacion()
        {
            if (!esDetalleExistente(0))
            {
                ListaCertificacionDetalle frm = new ListaCertificacionDetalle(certificacionRequerimiento);  //ListaCertificacionDetalle(certificacionRequerimiento);
                MostrarDialogoModulo(frm);
            }
        }
        private void ExportarProgramacionAnual()
        {
            //listaRequerimientoBienServicioPresentador.ExportarProgramacionAnual();
        }
        private void grvCertificacionReq_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            string res;

            ColumnView view = sender as ColumnView;

            if (e.Column.FieldName == "tipoReq" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                res = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "tipoReq").ToString();
                int vtipoReq = (Convert.ToInt32(res));

                if (vtipoReq == 1)
                {
                    e.DisplayText = "BIEN";
                }
                else
                {
                    e.DisplayText = "SERVICIO";
                }
            }
        }
        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio != null && inicio)
            {
                listaCertificacionRequerimientoPresentador.ObtenerDatosListado();
                inicio = true;
            }
        }
        
    }
}
