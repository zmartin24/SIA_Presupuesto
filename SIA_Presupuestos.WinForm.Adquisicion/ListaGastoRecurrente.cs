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
    public partial class ListaGastoRecurrente : ControlBase, IListaGastoRecurrenteVista
    {
        private ListaGastoRecurrentePresentador listaGastoRecurrentePresentador;

        public List<GastoRecurrente> listaDatosPrincipales
        {
            set
            {
                grcGastoRecurrente.DataSource = value;
            }
        }
        public GastoRecurrente gastoRecurrente
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as GastoRecurrente;
                return pro != null ? listaGastoRecurrentePresentador.Buscar(pro.idGasRec) : null;
            }
        }

        public ListaGastoRecurrente()
        {
            InitializeComponent();
            this.listaGastoRecurrentePresentador = new ListaGastoRecurrentePresentador(this);
        }

        protected override ColumnView ColumnaActual { get { return grcGastoRecurrente.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcGastoRecurrente; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
        }

        protected override void LlenarGrid()
        {
            listaGastoRecurrentePresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmGastoRecurrente frm = new frmGastoRecurrente(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmGastoRecurrente frm = new frmGastoRecurrente(gastoRecurrente, this.FindForm()))
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
                if (listaGastoRecurrentePresentador.Anular())
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

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetallePaa": RegistrarDetalles(); break;
                case "DetalleRequerimiento": DetallePlanAnualAdquisicionReq(); break;
                case "ExportarPresAnu": ExportarProgramacionAnual(); break;
                case "AprobarPaa": CambioEstado(); break;
                case "ImprimirGeneral": ImprimirGeneral(); break;
                case "ActualizarPac": ActualizarDetalles(); break;
            }
        }
        private void RegistrarDetalles()
        {
            if (gastoRecurrente != null)
            {
                using (frmBuscarRequerimientos frm = new frmBuscarRequerimientos(gastoRecurrente, this.FindForm(), 1))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                    }
                }
            }
            else
                EmitirMensajeResultado(true, Mensajes.RegistroVacio);
        }
        private void ImprimirGeneral()
        {
            if (gastoRecurrente != null)
            {
                using (frmImprimirGastoRecurrente frm = new frmImprimirGastoRecurrente(gastoRecurrente))
                {
                    frm.ShowDialog();
                }
            }
        }
        private void ActualizarDetalles()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaActulizarDetalles))
            {
                if (listaGastoRecurrentePresentador.ActulizarDetalles())
                    EmitirMensajeResultado(true, "Se Actulizó registros correctamente");
                else
                    EmitirMensajeResultado(true, "No se actualizó registros, o no hay registros para actualizar");
            }

        }
        private void CambioEstado()
        {
            //using (frmCambioEstadoPaa frm = new frmCambioEstadoPaa(planAnualAdquisicion, this.FindForm()))
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //    }
            //}
        }

        private void DetallePlanAnualAdquisicionReq()
        {
            if (gastoRecurrente != null)
            {
                frmListaGastoRecurrenteRequerimiento frm = new frmListaGastoRecurrenteRequerimiento(gastoRecurrente);
                MostrarDialogoModulo(frm);
            }
            else
                EmitirMensajeResultado(true, "Seleccione un registro válido");
        }
        private void ExportarProgramacionAnual()
        {
            //listaRequerimientoBienServicioPresentador.ExportarProgramacionAnual();
        }
        protected override void Imprimir()
        {
            listaGastoRecurrentePresentador.ImprimirPlanAnualAdquisicion();
        }
        public void ActualizarGrid()
        {
            LlenarGrid();
        }

    }
}
