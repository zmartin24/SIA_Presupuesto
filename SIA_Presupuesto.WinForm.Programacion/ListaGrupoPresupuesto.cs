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
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaGrupoPresupuesto : ControlBase, IListaGrupoPresupuestoVista
    {
        private ListaGrupoPresupuestoPresentador listaGrupoPresupuestoPresentador;

        public List<GrupoPresupuestoPoco> listaDatosPrincipales
        {
            set
            {
                grcGrupoPresupuesto.DataSource = value;
            }
        }

        public GrupoPresupuestoPoco grupoPresupuesto
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as GrupoPresupuestoPoco;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcGrupoPresupuesto.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcGrupoPresupuesto; } }

        public ListaGrupoPresupuesto()
        {
            InitializeComponent();
            this.listaGrupoPresupuestoPresentador = new ListaGrupoPresupuestoPresentador(this);
        }

        protected override void Nuevo()
        {
            using (frmGrupoPresupuesto frm = new frmGrupoPresupuesto(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmGrupoPresupuesto frm = new frmGrupoPresupuesto(grupoPresupuesto, this.FindForm()))
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
                if (listaGrupoPresupuestoPresentador.Anular())
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

        protected override void LlenarGrid()
        {
            listaGrupoPresupuestoPresentador.ObtenerDatosListado();
        }

    }
}
