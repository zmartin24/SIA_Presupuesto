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
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaPresupuestoRecepcionado : ControlBase ,IListaPresupuestoRecepcionadoVista
    {
        private ListaPresupuestoRecepcionadoPresentador listaPresupuestoRecepcionadoPresentador;

        public ListaPresupuestoRecepcionado()
        {
            InitializeComponent();
            this.listaPresupuestoRecepcionadoPresentador = new ListaPresupuestoRecepcionadoPresentador(this);
        }

        public List<PresupuestoRecepcionadoPoco> listaDatosPrincipales
        {
            set
            {
                grcProgramacionAnual.DataSource = value;
            }
        }

        public List<ItemPoco> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboAnio.Properties, "id", "nombre", "Año", value);
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

        protected override ColumnView ColumnaActual { get { return grcProgramacionAnual.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacionAnual; } }

        public int anio
        {
            set { cboAnio.EditValue = value; }
            get { return (Int32)cboAnio.EditValue; }
        }
        
        public int mesInicio
        {
            set { cboMesInicio.EditValue = value; }
            get { return (Int32)cboMesInicio.EditValue; }
        }

        public int mesFin
        {
            set { cboMesFin.EditValue = value; }
            get { return (Int32)cboMesFin.EditValue; }
        }

        public List<ItemPoco> listaMesesInicio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboMesInicio.Properties, "id", "nombre", "Mes", value);
            }
        }

        public List<ItemPoco> listaMesesFin
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboMesFin.Properties, "id", "nombre", "Mes", value);
            }
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleRequerimiento": DetalleRequerimiento(); break;
                case "Transferir": Transferir(); break;
            }
        }

        protected void Transferir()
        {
            using (frmTransferencia frm = new frmTransferencia(PresupuestoRecepcionado, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaPresupuestoRecepcionadoPresentador.Iniciar(); 
        }

        protected override void Nuevo()
        {
            using (frmPresupuestoRecepcionado frm = new frmPresupuestoRecepcionado(null, this.FindForm()))
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
                if (listaPresupuestoRecepcionadoPresentador.AnularRegistro())
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
            listaPresupuestoRecepcionadoPresentador.ObtenerDatosListado();
        }

        private void DetalleRequerimiento()
        {
            int idGrupo = PresupuestoRecepcionado.idGruPre;
            frmDetallePresupuestoRecepcionado frm = new frmDetallePresupuestoRecepcionado(idGrupo);
            MostrarDialogoModulo(frm);    
        }

        private void cboAnio_EditValueChanged(object sender, EventArgs e)
        {
            if(cboMesInicio.EditValue != null && cboMesFin.EditValue != null)
            {
                LlenarGrid();
            }
        }

        private void cboMes_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMesInicio.EditValue != null && cboMesFin.EditValue != null)
            {
                LlenarGrid();
            }
            
        }

        private void cboMesFin_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMesInicio.EditValue != null && cboMesFin.EditValue != null)
            {
                LlenarGrid();
            }
        }
    }
}
