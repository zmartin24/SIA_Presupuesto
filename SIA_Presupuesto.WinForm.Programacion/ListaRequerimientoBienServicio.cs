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

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaRequerimientoBienServicio : ControlBase, IListaRequerimientoBienServicioVista
    {
        private ListaRequerimientoBienServicioPresentador listaRequerimientoBienServicioPresentador;

        public List<RequerimientoBienServicioPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacionAnual.DataSource = value;
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

        public ListaRequerimientoBienServicio()
        {
            InitializeComponent();
            this.listaRequerimientoBienServicioPresentador = new ListaRequerimientoBienServicioPresentador(this);
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacionAnual.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacionAnual; } }

        public RequerimientoBienServicio RequerimientoBienServicio
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoBienServicioPres;
                return pro != null ? listaRequerimientoBienServicioPresentador.Buscar(pro.idReqBieSer) : null;
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaRequerimientoBienServicioPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaRequerimientoBienServicioPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmRequerimientoBienServicio frm = new frmRequerimientoBienServicio(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }



        protected override void Modificar()
        {
            using (frmRequerimientoBienServicio frm = new frmRequerimientoBienServicio(RequerimientoBienServicio, this.FindForm()))
            {
                if(frm.ShowDialog() ==  DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        public override bool Anular()
        {
            //bool respuesta = false;
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaRequerimientoBienServicioPresentador.AnularRegistro())
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

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleRequerimiento": DetallePresupuestoAnual(); break;
                case "ReportePorDireccion": ExportarProgramacionAnual(); break;
                case "ExportarReporte": ExportarReque(); break;
            }
        }

        private void DetallePresupuestoAnual()
        {
            if (!esDetalleExistente(0))
            {
                frmRequerimientoBienServicioDetalle frm = new frmRequerimientoBienServicioDetalle(string.Empty, RequerimientoBienServicio);
                MostrarDialogoModulo(frm);
            }
        }

        private void ExportarProgramacionAnual()
        {
            using (frmImprimirPorDireccion frm = new frmImprimirPorDireccion())
            {
                frm.ShowDialog();
            }
        }

        private void ExportarReque()
        {
            listaRequerimientoBienServicioPresentador.ExportarRequerimiento();
        }

        protected override void Imprimir()
        {
            listaRequerimientoBienServicioPresentador.ImprimirRequerimiento();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
