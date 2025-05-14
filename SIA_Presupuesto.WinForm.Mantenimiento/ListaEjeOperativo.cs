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
    public partial class ListaEjeOperativo : ControlBase, IListaEjeOperativoVista
    {
        private ListaEjeOperativoPresentador listaEjeOperativoPresentador;

        public List<EjeOperativo> listaDatosPrincipales
        {
            set
            {
                grcModalidad.DataSource = value;
            }
        }
        public EjeOperativo ejeOperativo
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as EjeOperativo;
                return pro != null ? listaEjeOperativoPresentador.Buscar(pro.idEjeOpe) : null;
            }
        }

        public ListaEjeOperativo()
        {
            InitializeComponent();
            this.listaEjeOperativoPresentador = new ListaEjeOperativoPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcModalidad.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcModalidad; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaEjeOperativoPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmEjeOperativo frm = new frmEjeOperativo(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmEjeOperativo frm = new frmEjeOperativo(ejeOperativo, this.FindForm()))
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
                if (listaEjeOperativoPresentador.Anular())
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
