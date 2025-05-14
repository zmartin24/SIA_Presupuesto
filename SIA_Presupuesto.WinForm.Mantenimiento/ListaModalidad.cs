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
    public partial class ListaModalidad : ControlBase, IListaModalidadVista
    {
        private ListaModalidadPresentador listaModalidadPresentador;

        public List<Modalidad> listaDatosPrincipales
        {
            set
            {
                grcEjeOperativo.DataSource = value;
            }
        }
        public Modalidad modalidad
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as Modalidad;
                return pro != null ? listaModalidadPresentador.Buscar(pro.idModalidad) : null;
            }
        }

        public ListaModalidad()
        {
            InitializeComponent();
            this.listaModalidadPresentador = new ListaModalidadPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcEjeOperativo.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcEjeOperativo; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaModalidadPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmModalidad frm = new frmModalidad(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmModalidad frm = new frmModalidad(modalidad, this.FindForm()))
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
                if (listaModalidadPresentador.Anular())
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
