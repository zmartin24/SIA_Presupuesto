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
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class frmListaPlanAnualRequerimiento : ControlDetalleBase, IPlanAnualReqVista
    {
        private PlanAnualAdquisicionReqPresentador planAnualAdquisicionReqPresentador;

        public List<PlanAnualAdquisicionReqPres> listaDatosPrincipales
        {
            //set
            //{
            //    gcPacReq.DataSource = value;
            //}
            get; set;
        }
        public List<PlanAnualAdquisicionReqDetallePres> listaPacDetalles
        {
            //set
            //{
            //    gcDetalle.DataSource = value;
            //}
            get; set;
        }

        private PlanAnualAdquisicion planAnualAdquisicion;
        public PlanAnualAdquisicionReqPres planAnualAdquisicionReqPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PlanAnualAdquisicionReqPres;
            }
        }
        public PlanAnualAdquisicionReqDetallePres planAnualAdquisicionReqDetallePres
        {
            get
            {
                if (ColumnaActual1 == null || ColumnaActual1.FocusedRowHandle < 0) return null;
                return ColumnaActual1.GetRow(ColumnaActual1.FocusedRowHandle) as PlanAnualAdquisicionReqDetallePres;
            }

        }
        public PlanAnualAdquisicionReqPres planAnualAdquisicionReqPresTemp
        {
            get; set;
        }

        public frmListaPlanAnualRequerimiento(PlanAnualAdquisicion planAnualAdquisicion)
        {
            InitializeComponent();
            this.planAnualAdquisicion = planAnualAdquisicion;
            this.planAnualAdquisicionReqPresentador = new PlanAnualAdquisicionReqPresentador(planAnualAdquisicion, this);
            Text = planAnualAdquisicion.descripcion;
            this.esSoloListado = true;
            this.riseImpTotal.ReadOnly = true;
        }

        protected override ColumnView ColumnaActual { get { return gcPacReq.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return gcPacReq; } }

        protected ColumnView ColumnaActual1 { get { return gcDetalle.MainView as ColumnView; } }

        protected override void InicializarDatos()
        {
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
            CargarDatosConSplashLocal();
        }
        protected void EjecutarCargarConSplashLocal()
        {
            switch (xtcPacReq.SelectedTabPage.Name)
            {
                case "xtpReq":
                    planAnualAdquisicionReqPresentador.llenarGridPrincipal();
                    break;
                case "xtpDetalle":
                    planAnualAdquisicionReqPresentador.llenarGridDetalle();
                    break;
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

            if (gcPacReq != null)
            {
                gcPacReq.DataSource = listaDatosPrincipales;
                gvPacReq.RefreshData();
            }

            if (gcDetalle != null)
            {
                gcDetalle.DataSource = listaPacDetalles;
                bgvDetalle.RefreshData();
            }
        }

        protected override void Nuevo()
        {
            using (frmPlanAnualAdquisicionCabecera frm = new frmPlanAnualAdquisicionCabecera(this.planAnualAdquisicion, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            PlanAnualAdquisicionRequerimiento obj = this.planAnualAdquisicionReqPresentador.BuscarPlanAnualAdquisicionRequerimiento(this.planAnualAdquisicionReqPres.idPaaReq);
            if (obj != null)
            {
                using (frmPlanAnualAdquisicionCabecera frm = new frmPlanAnualAdquisicionCabecera(this.planAnualAdquisicion, obj, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
            else
                EmitirMensajeResultado(false, Mensajes.RegistroVacio);
        }
        protected override void Anular()
        {
            PlanAnualAdquisicionRequerimiento obj = this.planAnualAdquisicionReqPresentador.BuscarPlanAnualAdquisicionRequerimiento(this.planAnualAdquisicionReqPres.idPaaReq);
            if (obj != null)
            {
                ICollection<PlanAnualAdquisicionDetalle> listaDetalle = obj.PlanAnualAdquisicionDetalle;
                if (listaDetalle.Count > 0)
                {
                    EmitirMensajeResultado(true, "No se puede anular, tiene detalles y debe revisar antes de anular");
                }
                else
                {
                    if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                    {
                        if (planAnualAdquisicionReqPresentador.AnularPlanAnualAdquisicionRequerimiento(obj))
                            EmitirMensajeResultado(true, "Anulado correctamente");
                        else
                            EmitirMensajeResultado(false, "No se puedo anular");
                    }
                }
            }
            else
                EmitirMensajeResultado(false, Mensajes.RegistroVacio);
        }

        protected void AnularDetalle()
        {
            if (xtcPacReq.SelectedTabPage.Name == "xtpDetalle")
            {
                if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                {
                    if (planAnualAdquisicionReqPresentador.AnularDetalle())
                        EmitirMensajeResultado(true, "Anulado correctamente");
                    else
                        EmitirMensajeResultado(false, "No se puedo anular el detalle");
                }
            }
            else
                EmitirMensajeResultado(false, "Debe seleccionar la ficha detalle");
        }
        private void AbrirDetalle(bool esModificacion)
        {
            if (xtcPacReq.SelectedTabPage.Name == "xtpDetalle")
            {
                if (planAnualAdquisicionReqPres != null)
                {
                    PlanAnualAdquisicionRequerimiento obj = this.planAnualAdquisicionReqPresentador.BuscarPlanAnualAdquisicionRequerimiento(planAnualAdquisicionReqPres.idPaaReq);
                    PlanAnualAdquisicionDetalle objDetalle = planAnualAdquisicionReqDetallePres != null ? this.planAnualAdquisicionReqPresentador.BuscarPlanAnualAdquisicionDetalle(planAnualAdquisicionReqDetallePres.idPaaDet) : null;
                    using (frmPlanAnualAdquisicionDetalle frm = new frmPlanAnualAdquisicionDetalle("", "", obj, esModificacion ? objDetalle : null, this.FindForm()))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LlenarGrid();
                        }
                    }
                }
            }
            else
                EmitirMensajeResultado(false, "Debe seleccionar la ficha detalle");
        }

        
        private void bgvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)gcDetalle.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as PlanAnualAdquisicionReqDetallePres;

            var gv = gcDetalle.MainView as GridView;
            var index = gv.FocusedRowHandle;

            if (cambio != null)
            {
                string numero = string.Empty;
                decimal num = 0;
                switch (e.Column.FieldName)
                {
                    case "cantEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 1, cambio.precio, num);
                        }

                        break;

                    case "cantFebrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 2, cambio.precio, num);
                        }
                        break;

                    case "cantMarzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 3, cambio.precio, num);
                        }
                        break;

                    case "cantAbril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 4, cambio.precio, num);
                        }
                        break;

                    case "cantMayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 5, cambio.precio, num);
                        }
                        break;

                    case "cantJunio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 6, cambio.precio, num);
                        }
                        break;

                    case "cantJulio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 7, cambio.precio, num);
                        }
                        break;

                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 8, cambio.precio, num);
                        }
                        break;

                    case "cantSetiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 9, cambio.precio, num);
                        }
                        break;

                    case "cantOctubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 10, cambio.precio, num);
                        }
                        break;

                    case "cantNoviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 11, cambio.precio, num);
                        }
                        break;

                    case "cantDiciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionReqPresentador.IngresarCantidadDetalle((int)cambio.idPaaDet, 12, cambio.precio, num);
                        }
                        break;
                }
                
            }
            LlenarGrid();
            bgvDetalle.FocusedRowHandle = e.RowHandle;
        }

        private void grcProgramacion_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View != null && e.View.IsDetailView)
            {
                (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View.ParentView as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            }
            else if (e.View != null)
            {
                (e.View as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            }
        }

        private void xtcPacReq_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtcPacReq.SelectedTabPage.Name == "xtpDetalle")
            {
                if (this.planAnualAdquisicionReqPres != null)
                {
                    this.teDescripcion.Text = planAnualAdquisicionReqPres.descripcion;
                    this.txtArea.Text = planAnualAdquisicionReqPres.desArea + " / " + planAnualAdquisicionReqPres.desSubdireccion + " / " + planAnualAdquisicionReqPres.desDireccion;
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, "Seleccione un requerimiento válido");
                    xtcPacReq.SelectedTabPage = xtcPacReq.SelectedTabPage;
                }
            }
        }
    }
}
