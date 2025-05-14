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
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaFuenteFinanciamiento : ControlBase, IListaFuenteFinanciamientoVista
    {
        private ListaFuenteFinanciamientoPresentador listaFuenteFinanciamientoPresentador;

        public List<FuenteFinanciamiento> listaDatosPrincipales
        {
            set
            {
                grcFuenteFinaciamiento.DataSource = value;
            }
        }
        public FuenteFinanciamiento fuenteFinanciamiento
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as FuenteFinanciamiento;
                return pro != null ? listaFuenteFinanciamientoPresentador.Buscar(pro.idFueFin) : null;
            }
        }

        public ListaFuenteFinanciamiento()
        {
            InitializeComponent();
            this.listaFuenteFinanciamientoPresentador = new ListaFuenteFinanciamientoPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcFuenteFinaciamiento.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcFuenteFinaciamiento; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaFuenteFinanciamientoPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmFuenteFinanciamiento frm = new frmFuenteFinanciamiento(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmFuenteFinanciamiento frm = new frmFuenteFinanciamiento(fuenteFinanciamiento, this.FindForm()))
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
                if (listaFuenteFinanciamientoPresentador.Anular())
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
    }
}
