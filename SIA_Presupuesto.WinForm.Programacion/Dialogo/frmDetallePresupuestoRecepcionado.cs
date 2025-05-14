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
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmDetallePresupuestoRecepcionado : ControlDetalleBase,IListaPresupuestoRecepcionadoVista
    {
        private ListaPresupuestoRecepcionadoPresentador listaPresupuestoRecepcionadoPresentador;
        private int idGrupo;
        public frmDetallePresupuestoRecepcionado(int _idGrupo)
        {
            InitializeComponent();
            idGrupo = _idGrupo;
            this.listaPresupuestoRecepcionadoPresentador = new ListaPresupuestoRecepcionadoPresentador(this);
        }

        public List<PresupuestoRecepcionadoPoco> listaDatosPrincipales
        {
            set
            {
                grcPresupuestoRecepcionado.DataSource = value;
            }
        }

        public PresupuestoRecepcionadoPoco PresupuestoRecepcionado
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PresupuestoRecepcionadoPoco;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcPresupuestoRecepcionado.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcPresupuestoRecepcionado; } }

        public List<ItemPoco> listaAnios
        {
            set;get;
        }

      
        public List<ItemPoco> listaMeses
        {
            set
            {
               
            }
        }

        public int anio
        {
            get;set;
        }

        public int mes
        {
            get; set;
        }

        public int mesInicio
        {
            get; set;
        }

        public int mesFin
        {
            get; set;
        }

        public List<ItemPoco> listaMesesInicio
        {
            set
            {

            }
        }

        public List<ItemPoco> listaMesesFin
        {
            set
            {

            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaPresupuestoRecepcionadoPresentador.Iniciar();  
        }

        protected override void LlenarGrid()
        {
            listaPresupuestoRecepcionadoPresentador.listarDetalleRecepcionados(idGrupo);
        }

        protected override void Modificar()
        {
            using (frmModificarDetPreRecepcionado frm = new frmModificarDetPreRecepcionado(PresupuestoRecepcionado, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
       

    }
}
