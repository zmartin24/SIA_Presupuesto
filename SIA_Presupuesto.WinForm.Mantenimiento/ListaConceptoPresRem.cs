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
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaConceptoPresRem : ControlBase, IListaConceptoPresRemVista
    {
        public ListaConceptoPresRem()
        {
            InitializeComponent();
            this.listaConceptoPresRemPresentador = new ListaConceptoPresRemPresentador(this);
        }

        private ListaConceptoPresRemPresentador listaConceptoPresRemPresentador;

        public List<ConceptoPresupuestoRemuneracion> listaDatosPrincipales
        {
            set
            {
                grcConcepto.DataSource = value;
            }
        }
        public ConceptoPresupuestoRemuneracion conceptoPresupuestoRemuneracion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ConceptoPresupuestoRemuneracion;
                return pro != null ? listaConceptoPresRemPresentador.Buscar(pro.idConPreRem) : null;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcConcepto.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcConcepto; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaConceptoPresRemPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmConcepto frm = new frmConcepto(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmConcepto frm = new frmConcepto(conceptoPresupuestoRemuneracion, this.FindForm()))
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
                if (listaConceptoPresRemPresentador.Anular())
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
            switch(nomOperacion)
            {
                case "VerCuentas": Cuentas(); break;
            }
        }

        private void Cuentas()
        {
            using (ListaConceptoCuenta frm = new ListaConceptoCuenta(conceptoPresupuestoRemuneracion, this.FindForm()))
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
