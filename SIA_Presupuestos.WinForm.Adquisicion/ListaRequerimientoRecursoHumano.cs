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
    public partial class ListaRequerimientoRecursoHumano : ControlBase, IListaRequerimientoRecursoHumanoVista
    {
        private ListaRequerimientoRecursoHumanoPresentador listaRequerimientoRecursoHumanoPresentador;

        public List<RequerimientoRecursoHumanoPres> listaDatosPrincipales
        {
            set
            {
                grcRequerimiento.DataSource = value;
            }
        }
        public RequerimientoRecursoHumano requerimientoRecursoHumano
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoRecursoHumanoPres;
                return pro != null ? listaRequerimientoRecursoHumanoPresentador.Buscar(pro.idReqRecHum) : null;
            }
        }
        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public int anio
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }

        public ListaRequerimientoRecursoHumano()
        {
            InitializeComponent();
            this.listaRequerimientoRecursoHumanoPresentador = new ListaRequerimientoRecursoHumanoPresentador(this);
        }

        protected override ColumnView ColumnaActual { get { return grcRequerimiento.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcRequerimiento; } }

        

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaRequerimientoRecursoHumanoPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaRequerimientoRecursoHumanoPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmRequerimientoRecursoHumano frm = new frmRequerimientoRecursoHumano(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmRequerimientoRecursoHumano frm = new frmRequerimientoRecursoHumano(requerimientoRecursoHumano, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        public override bool Anular()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaRequerimientoRecursoHumanoPresentador.AnularRegistro())
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
                case "DetalleRRHH": DetalleRRHH(); break;
                case "ReportePorDireccion": ExportarProgramacionAnual(); break;
            }
        }

        private void DetalleRRHH()
        {
            if (!esDetalleExistente(0))
            {
                ListaRequerimientoRecursoHumanoDetalle frm = new ListaRequerimientoRecursoHumanoDetalle(requerimientoRecursoHumano);
                MostrarDialogoModulo(frm);
            }
        }

        private void ExportarProgramacionAnual()
        {
            //using (frmImprimirPorDireccion frm = new frmImprimirPorDireccion())
            //{
            //    frm.ShowDialog();
            //}
        }
        protected override void Imprimir()
        {
            //listaRequerimientoRecursoHumanoPresentador.ImprimirRequerimiento();
        }
        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
