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
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaRequerimientoMensualBienServicio : ControlBase, IListaRequerimientoMensualBienServicioVista
    {
        private ListaRequerimientoMensualBienServicioPresentador listaRequerimientoMensualBienServicioPresentador;

        public List<RequerimientoMensualBienServicioPres> listaDatosPrincipales
        {
            set
            {
                grcRequerimiento.DataSource = value;
            }
        }
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int anio
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return lueMes.EditValue != null ? Convert.ToInt32(lueMes.EditValue) : 0; }
        }
        bool hacerCargar = false;
        RequerimientoMensualBienServicio requerimientoMensualBienServicio;

        public ListaRequerimientoMensualBienServicio()
        {
            InitializeComponent();
            this.listaRequerimientoMensualBienServicioPresentador = new ListaRequerimientoMensualBienServicioPresentador(this);
            hacerCargar = false;
        }

        protected override ColumnView ColumnaActual { get { return grcRequerimiento.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcRequerimiento; } }

        public RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoMensualBienServicioPres;  
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaRequerimientoMensualBienServicioPresentador.Iniciar();
        }
        // Addding custom Filters and Data Items customization
        //<gridControl1>
        void grvRequerimiento_FilterPopupExcelData(object sender, FilterPopupExcelDataEventArgs e)
        {
            string fieldName = e.Column.FieldName;
            //if (e.Column == bcModification)
            //{
            //    // Filter Items
            //    e.AddFilter("<image=A><nbsp>Automatic Transmission (6-speed)", "Contains([" + fieldName + "], '6A')", true);
            //    e.AddFilter("<image=A><nbsp>Automatic Transmission (8-speed)", "Contains([" + fieldName + "], '8A')", true);
            //    e.AddFilter("<image=M><nbsp>Manual Transmission (6-speed)", "Contains([" + fieldName + "], '6M')", true);
            //    e.AddFilter("<image=M><nbsp>Manual Transmission (7-speed)", "Contains([" + fieldName + "], '7M')", true);
            //    e.AddFilter("<image=V><nbsp>Variomatic Transmission", "Contains([" + fieldName + "], 'VA')", true);
            //    e.AddFilter("<b>Limited Edition</b>", "Contains([" + fieldName + "], 'Limited')", true);
            //    // Data Items
            //    foreach (var item in e.DataItems)
            //    {
            //        if (item.Text.Contains("V6"))
            //            item.HtmlText = item.Text.Replace("V6", "<b>V6</b>");
            //        if (item.Text.Contains("V8"))
            //            item.HtmlText = item.Text.Replace("V8", "<b>V8</b>");
            //        if (item.Text.Contains("Limited"))
            //            item.HtmlText = "<image=Ltd><nbsp>" + item.Text;
            //    }
            //}
            if (e.Column == gcDesEstado)
            { // 12-28
                e.AddFilter("Fuel Economy (<color=@Information>High</color>)", "[" + fieldName + "]>25", true);
                e.AddFilter("Fuel Economy (<color=@Warning>Medium</color>)", "[" + fieldName + "]>=15 AND [" + fieldName + "]<=25", true);
                e.AddFilter("Fuel Economy (<color=@Critical>Low</color>)", "[" + fieldName + "]<15", true);
            }
            //if (e.Column == bcMPGHighway)
            //{ // 15-36
            //    e.AddFilter("Fuel Economy (<color=@Information>High</color>)", "[" + fieldName + "]>20", true);
            //    e.AddFilter("Fuel Economy (<color=@Warning>Medium</color>)", "[" + fieldName + "]>=20 AND [" + fieldName + "]<=30", true);
            //    e.AddFilter("Fuel Economy (<color=@Critical>Low</color>)", "[" + fieldName + "]>20", true);
            //}
            // sales from newer to older by years
            //if (e.Column == bcSalesDate)
            //{
            //    // using low-level API for inplace values and texts reordering
            //    Array.Sort(e.Values, e.DisplayTexts, YearsFromNewerToOlder.Comparer);
            //}
        }
        //</gridControl1>

        protected override void LlenarGrid()
        {
            hacerCargar = true;
            CargarDatosConSplash();
        }
        protected override void EjecutarCargarConSplash()
        {
            this.listaRequerimientoMensualBienServicioPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmRequerimientoMensualBienServicio frm = new frmRequerimientoMensualBienServicio(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (this.requerimientoMensualBienServicioPres != null)
            {
                if (this.requerimientoMensualBienServicioPres.estado.Equals(2))
                {
                    this.requerimientoMensualBienServicio = listaRequerimientoMensualBienServicioPresentador.Buscar((Int32)requerimientoMensualBienServicioPres.idReqMenBieSer);
                    using (frmRequerimientoMensualBienServicio frm = new frmRequerimientoMensualBienServicio(requerimientoMensualBienServicio, this.FindForm()))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LlenarGrid();
                        }
                    }
                }
                else
                    EmitirMensajeResultado(true, "Error: No es posisble editar requerimiento, ya fue procesado");
            }
            else
                EmitirMensajeResultado(true, "Error: Seleccione una requerimiento requerimiento válido");
        }

        public override bool Anular()
        {
            //bool respuesta = false;

            //if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            //{
            //    if (listaRequerimientoMensualBienServicioPresentador.AnularRegistro())
            //    {
            //        EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
            //        LlenarGrid();
            //    }
            //    else
            //    {
            //        EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
            //    }
            //}
            return true;
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleRequerimiento": DetallePresupuestoAnual(); break;
                case "AprobarReqMen": CambioEstadoRequerimiento(10); break;
                case "VolverEstado": CambioEstadoRequerimiento(2); break;
            }
        }

        private void DetallePresupuestoAnual()
        {
            if (!esDetalleExistente(0))
            {
                ListaRequerimientoMensualDetalle frm = new ListaRequerimientoMensualDetalle(requerimientoMensualBienServicioPres);
                MostrarDialogoModulo(frm);
            }
        }
        

        private void CambioEstadoRequerimiento(int estado)
        {
            if (!esDetalleExistente(0) && this.listaRequerimientoMensualBienServicioPresentador.TraerListarDetallesTodos((Int32)this.requerimientoMensualBienServicioPres.idReqMenBieSer).Count > 0)
            {
                switch (estado)
                {
                    case 10:
                        if (this.requerimientoMensualBienServicioPres.estado.Equals(2))
                            if (EmitirMensajePregunta(Mensajes.PreguntaActivarRegistro))
                            {
                                if (this.listaRequerimientoMensualBienServicioPresentador.AsignarEstadoRequerimiento(this.requerimientoMensualBienServicioPres, estado))
                                {
                                    EmitirMensajeResultado(true, estado.Equals(10) ? "Se aprobó correctamente" : "Se volvió a estado correctamente");
                                    LlenarGrid();
                                }
                                else
                                    EmitirMensajeResultado(true, "Error al procesar requerimiento");
                            }

                        break;
                    case 2:
                        if (this.requerimientoMensualBienServicioPres.estado.Equals(10))
                        {
                            if (EmitirMensajePregunta("¿Está seguro de anular el aprobación?"))
                            {
                                if (this.listaRequerimientoMensualBienServicioPresentador.AsignarEstadoRequerimiento(this.requerimientoMensualBienServicioPres, estado))
                                {
                                    EmitirMensajeResultado(true, estado.Equals(10) ? "Se aprobó correctamente" : "Se volvió a estado correctamente");
                                    LlenarGrid();
                                }
                                else
                                    EmitirMensajeResultado(true, "Error al procesar requerimiento");
                            }
                        }
                        else
                            EmitirMensajeResultado(true, "Error: para volver al estado Activo, requerimiento debe estar con el estado Aprobado");
                        break;
                }
            }
        }

        //private void ExportarReque()
        //{
        //    listaRequerimientoMensualBienServicioPresentador.ExportarRequerimiento();
        //}

        protected override void Imprimir()
        {
            listaRequerimientoMensualBienServicioPresentador.ImprimirRequerimiento();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMes.EditValue != null && hacerCargar)
                LlenarGrid();
        }
        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMes.EditValue != null && hacerCargar)
                LlenarGrid();
        }
    }
}
