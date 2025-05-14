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
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Selection;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using Utilitario.Util;
using DevExpress.XtraGrid.Views.Base;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaRequerimientoRecursoHumanoDetalle : ControlDetalleBase, IListaRequerimientoRecursoHumanoDetalleVista
    {
        private ListaRequerimientoRecursoHumanoDetallePresentador listaRequerimientoRecursoHumanoDetallePresentador;
        private RequerimientoRecursoHumano requerimientoRecursoHumano;
        public ListaRequerimientoRecursoHumanoDetalle(RequerimientoRecursoHumano requerimientoRecursoHumano)
        {
            InitializeComponent();
            Text = "Cuadro de Recurso Humano";
            this.listaRequerimientoRecursoHumanoDetallePresentador = new ListaRequerimientoRecursoHumanoDetallePresentador(requerimientoRecursoHumano, this);
            this.requerimientoRecursoHumano = requerimientoRecursoHumano;
            this.esSoloListado = true;
        }
        protected override ColumnView ColumnaActual { get { return grcReqTrabajador.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcReqTrabajador; } }

        public List<RequerimientoRecursoHumanoDetallePres> listaDatosPrincipales
        {
            set
            {
                grcReqTrabajador.DataSource = value;
            }
        }

        public PuestoRequerimiento puestoRequerimiento
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoRecursoHumanoDetallePres;
                return pro != null ? listaRequerimientoRecursoHumanoDetallePresentador.Buscar(pro.idPueReq) : null;
            }
        }

        public List<PuestoRequerimiento> listaPuestoRequerimiento
        {
            get
            {
                //List<int> lista = ListaCodigoContratosSeleccionadosPreliminar().Select(s => s.Key).ToList();
                return null; // lista != null ? presupuestoRemuneracionPresentador.Buscar(lista) : null;
            }
        }

        public List<Mes> listaMesDesde
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesDesde.Properties, "indice", "nombre", "Mes Desde", value);
            }
        }
        public List<Mes> listaMesHasta
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesHasta.Properties, "indice", "nombre", "Mes Hasta", value);
            }
        }

        public int mesDesde
        {
            get { return Convert.ToInt32(lueMesDesde.EditValue); }
            set { lueMesDesde.EditValue = value; }
        }

        public int mesHasta
        {
            get { return Convert.ToInt32(lueMesHasta.EditValue); }
            set { lueMesHasta.EditValue = value; }
        }

        protected override void InicializarValidacion()
        {
            listaRequerimientoRecursoHumanoDetallePresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            return ProveedorValidacion.Validate();
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch(nomOperacion)
            {
                case "CalcularDet":
                    Calcular();
                    break;
                case "NuevoMultipleDet":
                    NuevoMultiple();
                    break;
            }
        }

        protected override void GuardarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void Calcular()
        {
            //if (presupuestoRemuneracionPresentador.Calcular())
            //    LlenarGrid();
        }

        protected override void LlenarGrid()
        {
            listaRequerimientoRecursoHumanoDetallePresentador.ObtenerDatosListado();
        }

        protected override void NuevoMultiple()
        {
            //using (frmPuestoMasivo frm = new frmPuestoMasivo(this.programacionAnual,  this.FindForm()))
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //        LlenarGrid();
            //}
        }

        protected override void Nuevo()
        {
            using (frmPuestoRequerimiento frm = new frmPuestoRequerimiento(this.requerimientoRecursoHumano, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmPuestoRequerimiento frm = new frmPuestoRequerimiento(this.requerimientoRecursoHumano, puestoRequerimiento, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Anular()
        {
            //if (presupuestoRemuneracionPresentador.Anular())
            //    EmitirMensajeResultado(true, "Anulado correctamente");
            //else
            //    EmitirMensajeResultado(false, "No se puedo anular");
        }
    }
}
