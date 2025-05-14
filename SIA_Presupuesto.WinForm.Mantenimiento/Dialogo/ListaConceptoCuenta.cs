using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class ListaConceptoCuenta : frmDialogoBaseAyuda, IListaConceptoCuentaVista
    {
        private ListaConceptoCuentaPresentador listaConceptoCuentaPresentador;
        public List<DatoConceptoCuentaContable> listaDatosPrincipales
        {
            set
            {
                grcConcepto.DataSource = value;
            }
        }
        private ConceptoPresupuestoRemuneracion concepto;
        public ListaConceptoCuenta(ConceptoPresupuestoRemuneracion concepto, Form padre):base(padre, null)
        {
            InitializeComponent();
            this.concepto = concepto;
            this.listaConceptoCuentaPresentador = new ListaConceptoCuentaPresentador(concepto, this);
            Text = "Lista de cuentas por concepto";
        }

        protected override ColumnView Vista { get { return grcConcepto.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcConcepto.MainView as ColumnView; } }

        public ConceptoCuentaContable conceptoCuentaContable
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var  concepto = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as DatoConceptoCuentaContable;
                return listaConceptoCuentaPresentador.Buscar(concepto.idConCueCon);
            }
        }

        protected override void LlenarGrid()
        {
            listaConceptoCuentaPresentador.ObtenerDatosListado();
        }

        private void obgOperaciones_AgregarRegistro(object sender, EventArgs e)
        {
            using (frmConceptoCuenta frm = new frmConceptoCuenta(this.concepto, null, this.UsuarioOperacion, this.FindForm()))
            {
                if(frm.ShowDialog() ==  DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        private void obgOperaciones_QuitarRegistro(object sender, EventArgs e)
        {
            if (listaConceptoCuentaPresentador.Anular())
                EmitirMensajeResultado(true, "Se anuló correctamente la cuenta del concepto");
            else
                EmitirMensajeResultado(false, "No se pudo anular");
        }
    }
}