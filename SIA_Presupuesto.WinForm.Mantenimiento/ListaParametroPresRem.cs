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
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaParametroPresRem : ControlBase, IListaParametroPresRemVista
    {
        public ListaParametroPresRem()
        {
            InitializeComponent();
            this.listaParametroPresRemPresentador = new ListaParametroPresRemPresentador(this);
        }

        private ListaParametroPresRemPresentador listaParametroPresRemPresentador;

        public List<ParametroPoco> listaDatosPrincipales
        {
            set
            {
                grcParametro.DataSource = value;
            }
        }
        public ParametroPresupuestoRemuneracion parametroPresupuestoRemuneracion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ParametroPoco;
                return pro != null ? listaParametroPresRemPresentador.Buscar(pro.idParPreRem) : null;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcParametro.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcParametro; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaParametroPresRemPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmParametro frm = new frmParametro(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmParametro frm = new frmParametro(parametroPresupuestoRemuneracion, this.FindForm()))
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
                if (listaParametroPresRemPresentador.Anular())
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
