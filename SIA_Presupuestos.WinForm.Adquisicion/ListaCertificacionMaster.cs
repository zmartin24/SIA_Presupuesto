using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;

using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.WinForm.General.Helper;
using Utilitario.Util;


namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaCertificacionMaster : ControlBase, IListaCertificacionMasterVista
    {
        private ListaCertificacionMasterPresentador listaCertificacionMasterPresentador;

        public List<CertificacionMasterPres> listaDatosPrincipales
        {
            set
            {
                grcCertificacionMaster.DataSource = value;
            }
        }
        public CertificacionMaster certificacionMaster
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var obj = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as CertificacionMasterPres;
                return obj != null ? listaCertificacionMasterPresentador.Buscar(obj.idCerMas) : null;
            }
        }
        public CertificacionMasterPres certificacionMasterPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var obj = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as CertificacionMasterPres;
                obj.forebi = obj != null ? obj.tipoReq == 1 ? listaCertificacionMasterPresentador.BuscarForebi(obj.idForebise) : null : null;
                obj.forese = obj != null ? obj.tipoReq == 2 ? listaCertificacionMasterPresentador.BuscarForese(obj.idForebise) : null : null;

                return obj != null ? obj : null;
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

        private Dictionary<CertificacionMaster, bool> listaCertificacionMasterSeleccionados;
        public List<CertificacionMaster> ListaCertificacionMasterSeleccionados
        {
            get { return listaCertificacionMasterSeleccionados.Keys.ToList(); }
        }

        private List<ReporteCertificacionPresupuestalPres> listaReporteCertificacionPresupuestal;

        public ListaCertificacionMaster()
        {
            InitializeComponent();
            this.listaCertificacionMasterPresentador = new ListaCertificacionMasterPresentador(this);
            this.listaCertificacionMasterSeleccionados = new Dictionary<CertificacionMaster, bool>();
            this.listaReporteCertificacionPresupuestal = new List<ReporteCertificacionPresupuestalPres>();
        }

        protected override ColumnView ColumnaActual { get { return grcCertificacionMaster.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcCertificacionMaster; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaCertificacionMasterPresentador.Iniciar();
        }
        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio != null && inicio)
            {
                listaCertificacionMasterPresentador.ObtenerDatosListado();
                inicio = true;
            }
        }
        protected override void LlenarGrid()
        {
            listaCertificacionMasterPresentador.ObtenerDatosListado();
            inicio = true;
        }
        protected override void Nuevo()
        {
            using (frmCertificacionMaster frm = new frmCertificacionMaster(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            if (this.certificacionMaster != null)
            {
                using (frmCertificacionMaster frm = new frmCertificacionMaster(certificacionMaster, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
            else
                EmitirMensajeResultado(true, "Error : Seleccione un registro válido");
        }
        public override bool Anular()
        {
            if (this.certificacionMaster != null)
            {
                if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                {
                    if (listaCertificacionMasterPresentador.Anular())
                    {
                        EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                        LlenarGrid();
                    }
                    else
                    {
                        EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
                    }
                }
            }
            else
                EmitirMensajeResultado(true, "Error : Seleccione un registro válido");

            return true;
        }
        protected override void Imprimir()
        {
            //if (certificacionMaster != null)
            //{
            //    List<ReporteCertificacionPresupuestalPres> lista = listaCertificacionMasterPresentador.TraerReporteCertificacionPresupuestal();
            //    if (lista.Count > 0)
            //        listaCertificacionMasterPresentador.ReporteCertificacionPresupuestal(lista);
            //    else
            //        EmitirMensajeResultado(true, "Certificación sin Detalles o ha ocurrido un problema");
            //}
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleCertificacionMaster": DetalleCertificacion(); break;
                case "Reporte": ReporteVarios(); break;
                case "EnviarCorreo": EnviarCorreo(); break;
            }
        }

        private void DetalleCertificacion()
        {
            if (!esDetalleExistente(0))
            {
                if (certificacionMaster != null)
                {
                    ListaCertificacionMasterDetalle frm = new ListaCertificacionMasterDetalle(certificacionMasterPres);
                    MostrarDialogoModulo(frm);
                }
                else EmitirMensajeResultado(true, "Debe seleccionar una certificación válida");
            }
        }
        private void ReporteVarios()
        {
            using (frmCertificacionRequerimientoReporte frm = new frmCertificacionRequerimientoReporte())
            {
                frm.ShowDialog();
            }
        }
        private void EnviarCorreo()
        {
            SeleccionamosRequerimientos(grvCertificacionMaster);
            List<UsuarioCorreoPres> listaUsuarioCorreo = this.listaCertificacionMasterPresentador.TraerListaUsuarioCorreo();

            if (this.listaReporteCertificacionPresupuestal.Count > 0)
            {
                if (listaUsuarioCorreo.Count > 0)
                {
                    using (frmEnviarCorreoCertificacion frm = new frmEnviarCorreoCertificacion(listaUsuarioCorreo, listaReporteCertificacionPresupuestal))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            grvCertificacionMaster.ClearSelection();
                        }
                        this.listaReporteCertificacionPresupuestal.Clear();
                    }
                }
                else
                    EmitirMensajeResultado(true, "Ocurrio un error al cargar lista de correos");
            }
            else
                EmitirMensajeResultado(true, "Debe seleccionar al menos un requerimiento válido");
            
        }

        private void SeleccionamosRequerimientos(GridView view)
        {
            string idsCerReq = string.Empty;
            view.BeginSelection();
            
            this.listaCertificacionMasterSeleccionados.Clear();
            int[] selectedRows = view.GetSelectedRows();

            foreach (int rowHandle in selectedRows)
            {
                List<CertificacionRequerimiento> listaCertificacion = listaCertificacionMasterPresentador.listarCertificacionRequerimientoPorIdCerMas((int)view.GetRowCellValue(rowHandle, "idCerMas"));

                listaCertificacion.ForEach(f =>
                {
                    idsCerReq = idsCerReq + "," + f.idCerReq.ToString();
                });
            }

            if (!string.IsNullOrEmpty(idsCerReq))
            {
                idsCerReq = idsCerReq.Substring(1);
                this.listaReporteCertificacionPresupuestal = listaCertificacionMasterPresentador.TraerReporteCertificacionPresupuestalVarios(idsCerReq, false);
            }
            //view.ClearSelection();
            view.EndSelection();
        }
    }
}
