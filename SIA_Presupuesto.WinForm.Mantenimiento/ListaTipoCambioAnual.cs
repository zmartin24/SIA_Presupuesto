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
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaTipoCambioAnual : ControlBase, IListaTipoCambioAnualVista
    {
        private ListaTipoCambioAnualPresentador listaTipoCambioAnualPresentador;

        public List<TipoCambioAnual> listaDatosPrincipales
        {
            set
            {
                grcTipoCambioAnual.DataSource = value;
            }
        }
        public TipoCambioAnual tipoCambioAnual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as TipoCambioAnual;
                return pro != null ? listaTipoCambioAnualPresentador.Buscar(pro.idTipCamAnu) : null;
            }
        }

        public ListaTipoCambioAnual()
        {
            InitializeComponent();
            this.listaTipoCambioAnualPresentador = new ListaTipoCambioAnualPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcTipoCambioAnual.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcTipoCambioAnual; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaTipoCambioAnualPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaTipoCambioAnualPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmTipoCambioAnual frm = new frmTipoCambioAnual(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmTipoCambioAnual frm = new frmTipoCambioAnual(tipoCambioAnual, this.FindForm()))
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
                if (listaTipoCambioAnualPresentador.Anular())
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
