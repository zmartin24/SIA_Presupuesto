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

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaPlanAnualAdquisicion : ControlBase, IListaPlanAnualAdquisicionVista
    {
        private ListaPlanAnualAdquisicionPresentador listaPlanAnualAdquisicionPresentador;

        public List<PlanAnualAdquisicion> listaDatosPrincipales
        {
            set
            {
                grcPlanAnualAdquisicion.DataSource = value;
            }
        }
        public PlanAnualAdquisicion planAnualAdquisicion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PlanAnualAdquisicion;
                return pro != null ? listaPlanAnualAdquisicionPresentador.Buscar(pro.idPaa) : null;
            }
        }

        public ListaPlanAnualAdquisicion()
        {
            InitializeComponent();
            this.listaPlanAnualAdquisicionPresentador = new ListaPlanAnualAdquisicionPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcPlanAnualAdquisicion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcPlanAnualAdquisicion; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            //listaRequerimientoBienServicioPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaPlanAnualAdquisicionPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmPlanAnualAdquisicion frm = new frmPlanAnualAdquisicion(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (!planAnualAdquisicion.estado.Equals(10))
            {
                using (frmPlanAnualAdquisicion frm = new frmPlanAnualAdquisicion(planAnualAdquisicion, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
            else
                EmitirMensajeResultado(true, "Plan esta aprobado, no puedes modificar");
        }

        public override bool Anular()
        {
            if (!planAnualAdquisicion.estado.Equals(10))
            {
                if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                {
                    if (listaPlanAnualAdquisicionPresentador.Anular())
                    {
                        EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                        LlenarGrid();
                    }
                    else
                    {
                        EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
                    }
                }
            }
            else
                EmitirMensajeResultado(true, "Plan esta aprobado, no puedes anular");
            return true;
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetallePaa": RegistrarDetalles(); break;
                case "DetalleRequerimiento": DetallePlanAnualAdquisicionReq(); break;
                case "ExportarPresAnu": ExportarProgramacionAnual(); break;
                case "AprobarPaa": CambioEstado(); break;
                case "ActualizarPac": ActualizarDetalles(); break;
                case "ExportarPac": ExportarPAC(); break;
            }
        }
        private void RegistrarDetalles()
        {
            if (!planAnualAdquisicion.estado.Equals(10))
            {
                using (frmBuscarRequerimientos frm = new frmBuscarRequerimientos(planAnualAdquisicion, this.FindForm(), 2))
                {
                    frm.ShowDialog();
                }
            }
            else
                EmitirMensajeResultado(true, "Plan esta aprobado, no puedes agregar detalles");
        }
        private void CambioEstado()
        {
            using (frmCambioEstadoPaa frm = new frmCambioEstadoPaa(planAnualAdquisicion, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
        private void ActualizarDetalles()
        {
            if (!planAnualAdquisicion.estado.Equals(10))
            {
                if (EmitirMensajePregunta(Mensajes.PreguntaActulizarDetalles))
                {
                    if (listaPlanAnualAdquisicionPresentador.ActulizarDetalles())
                        EmitirMensajeResultado(true, "Se Actualizó registros correctamente");
                    else
                        EmitirMensajeResultado(true, "No se actualizó registros, o no hay registros para actualizar");
                }
            }
            else
                EmitirMensajeResultado(true, "Plan esta aprobado, no se puede actualizar");
        }
        public void ListaObjetivos()
        {
            
        }
        private void DetallePlanAnualAdquisicionReq()
        {

            if (!esDetalleExistente(0))
            {
                //frmListaPlanAnualRequerimiento frm = new frmListaPlanAnualRequerimiento(planAnualAdquisicion);
                frmListaPlanAnualVizualiza frm = new frmListaPlanAnualVizualiza(planAnualAdquisicion);
                MostrarDialogoModulo(frm);
            }
        }
        
        private void ExportarProgramacionAnual()
        {
            //listaRequerimientoBienServicioPresentador.ExportarProgramacionAnual();
        }
        protected override void Imprimir()
        {
            if (planAnualAdquisicion != null)
            {
                using (frmImprimirPac frm = new frmImprimirPac(planAnualAdquisicion))
                {
                    frm.ShowDialog();
                }
            }
        }
        private void ExportarPAC()
        {
            this.listaPlanAnualAdquisicionPresentador.ExportarPAC();
        }

    }
}
