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
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaCatGastosRecurrentes : ControlBase,IListaRubroBienServicioVista
    {
        private ListaRubroBienServicioPresentador listaRubroBienServicioPresentador;

        public List<RubroBienServicioPoco> listaDatosPrincipales
        {
            set
            {
                grcCatGastoRecurrente.DataSource = value;
            }
        }


        protected override ColumnView ColumnaActual { get { return grcCatGastoRecurrente.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcCatGastoRecurrente; } }

        public RubroBienServicioPoco rubroBienServicio
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RubroBienServicioPoco;
            }
        }

        public ListaCatGastosRecurrentes()
        {
            InitializeComponent();
            this.listaRubroBienServicioPresentador = new ListaRubroBienServicioPresentador(this);
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaRubroBienServicioPresentador.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaRubroBienServicioPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmCatGasto frm = new frmCatGasto(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmCatGasto frm = new frmCatGasto(rubroBienServicio, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        public override bool Eliminar()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaRubroBienServicioPresentador.Anular())
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
