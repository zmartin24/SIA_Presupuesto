using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaPartidaPresupuestal : ControlBase, IListaPartidaPresupuestalVista
    {
        private ListaPartidaPresupuestalPresentador listaPartidaPresupuestalPresentador;

        public List<PartidaPresupuestalPres> listaDatosPrincipales
        {
            set
            {
                grcPartidaPresupuestal.DataSource = value;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcPartidaPresupuestal.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcPartidaPresupuestal; } }

        public PartidaPresupuestalPres partidaPresupuestalPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PartidaPresupuestalPres;
            }
        }

        public PartidaPresupuestal partidaPresupuestal
        {
            set; get;
        }

        public ListaPartidaPresupuestal()
        {
            InitializeComponent();
            this.listaPartidaPresupuestalPresentador = new ListaPartidaPresupuestalPresentador(this);
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaPartidaPresupuestalPresentador.ObtenerDatosListado();
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleParPre": DetalleCuenta(); break;
            }
        }

        private void DetalleCuenta()
        {
            if (!esDetalleExistente(0))
            {
                if (this.partidaPresupuestalPres != null)
                {
                    partidaPresupuestal = this.listaPartidaPresupuestalPresentador.BuscarPorID(partidaPresupuestalPres.idParPre);
                    ListaPartidaPresupuestalCuenta frm = new ListaPartidaPresupuestalCuenta(partidaPresupuestal);
                    MostrarDialogoModulo(frm);
                }
                else EmitirMensajeResultado(true, "Debe seleccionar una certificación válida");
            }
        }

        protected override void Nuevo()
        {
            using (frmPartidaPresupuestal frm = new frmPartidaPresupuestal(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (partidaPresupuestalPres == null) return;
            
            partidaPresupuestal = this.listaPartidaPresupuestalPresentador.BuscarPorID(partidaPresupuestalPres.idParPre);
            using (frmPartidaPresupuestal frm = new frmPartidaPresupuestal(partidaPresupuestal, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        //public override bool Eliminar()
        //{
        //    if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
        //    {
        //        if (listaPartidaPresupuestalPresentador.Anular())
        //        {
        //            EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
        //            LlenarGrid();
        //        }
        //        else
        //        {
        //            EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
        //        }
        //    }
        //    return true;
        //}
    }
}
