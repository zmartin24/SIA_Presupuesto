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

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ConsultaProgramacionAnual : ControlBase, IConsultaProgramacionAnualVista
    {
        private ConsultaProgramacionAnualPresentador listaProgramacionAnualPresentador;

        public List<ProgramacionAnualPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacionAnual.DataSource = value;
            }
        }

        public ConsultaProgramacionAnual()
        {
            InitializeComponent();
            this.listaProgramacionAnualPresentador = new ConsultaProgramacionAnualPresentador(this);
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacionAnual.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacionAnual; } }

        public ProgramacionAnual ProgramacionAnual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProgramacionAnualPres;
                return pro != null ? listaProgramacionAnualPresentador.Buscar(pro.idProAnu) : null;
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaProgramacionAnualPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaProgramacionAnualPresentador.ObtenerDatosListado();
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "ExportarPresAnu": ExportarProgramacionAnual(); break;
                case "Vista": Vista(); break;
            }
        }

        private void Vista()
        {
            if (!esDetalleExistente(0))
            {
                if (ProgramacionAnual != null)
                {
                    frmProgramacionAnual frm = new frmProgramacionAnual(ProgramacionAnual);
                    //frm.SoloLectura = true;
                    MostrarDialogoModulo(frm, true);
                }
                else EmitirMensajeResultado(true, "Debe seleccionar un plan presupuestal"); ;

            }

        }


        private void ExportarProgramacionAnual()
        {
            listaProgramacionAnualPresentador.ExportarProgramacionAnual();
        }

    }
}
