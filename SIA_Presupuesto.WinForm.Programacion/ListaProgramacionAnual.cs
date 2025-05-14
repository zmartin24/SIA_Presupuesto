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
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;
using System.Globalization;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System.IO;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaProgramacionAnual : ControlBase, IListaProgramacionAnualVista
    {
        private ListaProgramacionAnualPresentador listaProgramacionAnualPresentador;
        #region variables de interface
        public List<ProgramacionAnualPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacionAnual.DataSource = value;
            }
        }
        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public int anioPresentacion
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }
        public int idMoneda
        {
            get; set;
        }
        #endregion
        public ListaProgramacionAnual()
        {
            InitializeComponent();
            this.listaProgramacionAnualPresentador = new ListaProgramacionAnualPresentador(this);
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

        protected override void Nuevo()
        {
            using (frmProgramacionAnualGeneral frm = new frmProgramacionAnualGeneral(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (ProgramacionAnual != null)
            {
                if (ProgramacionAnual.estado != Estados.Aprobado && ProgramacionAnual.estado != Estados.Rechazado)
                {
                    using (frmProgramacionAnualGeneral frm = new frmProgramacionAnualGeneral(ProgramacionAnual, this.FindForm()))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LlenarGrid();
                        }
                    }
                }
                else
                    EmitirMensajeResultado(true, "El plan presupuestal ya fue procesado");
            }
            else
                EmitirMensajeResultado(true, "Debe seleccionar un plan presupuestal");
        }

        public override bool Anular()
        {
            //bool respuesta = false;
            if (ProgramacionAnual != null)
            {
                if (ProgramacionAnual.estado != Estados.Aprobado && ProgramacionAnual.estado != Estados.Rechazado)
                {
                    if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                    {
                        if (listaProgramacionAnualPresentador.AnularRegistro())
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
                else EmitirMensajeResultado(true, "El plan presupuestal ya fue procesado");

            }
            else EmitirMensajeResultado(true, "Debe seleccionar un plan presupuestal");
            return true;
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetallePresupuestoAnual": DetallePresupuestoAnual(); break;
                case "ExportarPresAnu": ExportarProgramacionAnual(); break;
                case "ExportarPreAnuGen": ExportarPresupuestoAnualGenerica(); break;
                case "ConsolidadoPorDireccion": listaProgramacionAnualPresentador.ReporteConsolidadoPorDireccion(); break;
                case "CambioEstado":
                    CambiarEstado(); break;
                case "ActualizarDesdePAC":
                    ActualizarPAC(); break;
                case "ActualizarDesdeRRHH":
                    ActualizarRRHH(); break;
                case "ResumenPorSubdireccion":
                    ImprimirPorDireccion(); break;
                case "ImprimirCalendario":
                    ImprimirCalendario(); break;
                case "CalculoRemuneracion":
                    CalculoRemuneracion(); break;
                case "ExportarPresRem":
                    ExportarPresupuestoRemuneracion(); break;
                case "ExportarPresRemMasivo":
                    ExportarMasivoPresupuestoRemunracion(); break;
                case "AsignarPresupuestoMensual":
                    AsignarPresupuestoMensual(); break;
                case "ActualizarDesdeRequerimiento":
                    ActualizarDesdeRequerimiento(); break;

            }
        }

        private void CalculoRemuneracion()
        {
            if (!esDetalleExistente(0))
            {
                if (ProgramacionAnual != null)
                {
                    frmPresupuestoRemuneracion frm = new frmPresupuestoRemuneracion(ProgramacionAnual);
                    MostrarDialogoModulo(frm);
                }
                else EmitirMensajeResultado(true, "Debe seleccionar un plan presupuestal");
            }
            
        }

        private void DetallePresupuestoAnual()
        {
            if (!esDetalleExistente(0))
            {
                if (ProgramacionAnual != null)
                {
                    if (ProgramacionAnual.estado != Estados.Aprobado && ProgramacionAnual.estado != Estados.Rechazado)
                    {
                        frmProgramacionAnual frm = new frmProgramacionAnual(ProgramacionAnual);
                        MostrarDialogoModulo(frm);
                    }
                    else EmitirMensajeResultado(true, "El plan presupuestal ya fue procesado");
                }
                else EmitirMensajeResultado(true, "Debe seleccionar un plan presupuestal");
            }
            
        }

        private void CambiarEstado()
        {
            if(ProgramacionAnual != null)
            using (frmCambioEstadoProgramacionAnual frm = new frmCambioEstadoProgramacionAnual(ProgramacionAnual, this.FindForm()))
            {
                    if (frm.ShowDialog() == DialogResult.OK)
                        LlenarGrid();
            }
        }

        private void ActualizarPAC()
        {
            if (ProgramacionAnual != null)
            {
                if (ProgramacionAnual.estado != Estados.Aprobado && ProgramacionAnual.estado != Estados.Rechazado)
                {
                    using (frmActualizacionPorPAC frm = new frmActualizacionPorPAC(ProgramacionAnual.idProAnu, this.FindForm()))
                    {
                        frm.ShowDialog();
                    }
                }
                else EmitirMensajeResultado(true, "El plan presupuestal ya fue procesado");
            }
        }

        private void ActualizarRRHH()
        {
            if (ProgramacionAnual != null)
            {
                if (ProgramacionAnual.estado != Estados.Aprobado && ProgramacionAnual.estado != Estados.Rechazado)
                {
                    using (frmActualizacionPorRRHH frm = new frmActualizacionPorRRHH(ProgramacionAnual.idProAnu, this.FindForm()))
                    {
                        frm.ShowDialog();
                    }
                }
                else EmitirMensajeResultado(true, "El plan presupuestal ya fue procesado");
            }
        }

        private void AsignarPresupuestoMensual()
        {
            if (ProgramacionAnual != null)
            {
                using (frmAsignarPresupuestoMensualProAnu frm = new frmAsignarPresupuestoMensualProAnu(ProgramacionAnual, this.UsuarioOperacion, this.FindForm()))
                {
                    frm.ShowDialog();
                }
            }
            else EmitirMensajeResultado(true, Mensajes.RegistroVacio);
        }

        private void ActualizarDesdeRequerimiento()
        {
            if (ProgramacionAnual != null)
            {
                if (ProgramacionAnual.estado != Estados.Aprobado && ProgramacionAnual.estado != Estados.Rechazado)
                {
                    using (frmActualizarPorRequerimientoBienServicio frm = new frmActualizarPorRequerimientoBienServicio(ProgramacionAnual, this.FindForm()))
                    {
                        frm.ShowDialog();
                    }
                }
                else EmitirMensajeResultado(true, "El plan presupuestal ya fue procesado");
            }
        }

        private void ImprimirPorDireccion()
        {
            if (ProgramacionAnual != null)
            {
                using (frmImprimirPorDireccionPresupuestoAnual frm = new frmImprimirPorDireccionPresupuestoAnual())
                {
                    frm.ShowDialog();
                }
            }
        }

        private void ImprimirCalendario()
        {
            using (frmImprimirCalendarioPresAnual frm = new frmImprimirCalendarioPresAnual())
            {
                frm.ShowDialog();
            }
        }

        private void ExportarProgramacionAnual()
        {
            if (this.ProgramacionAnual != null)
            {
                using (frmSeleccionMoneda frm = new frmSeleccionMoneda(this.ProgramacionAnual.descripcion, "", "Exportar Programación Anual"))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.idMoneda = (Int32)frm.Tag;
                        List<ReporteProgramacionAnualExportaPres> lista = listaProgramacionAnualPresentador.TraerReporteProgramacionAnualExporta();
                        if (lista.Count > 0)
                            Exportar(lista);
                        else
                            EmitirMensajeResultado(true, "no se realizó exportación");
                    }
                }
            }
            else
            {
                EmitirMensajeResultado(true, "Seleccione un plan presupuestal");
            }
            
        }
        private void ExportarPresupuestoAnualGenerica()
        {
            using (frmExportarProgramacionAnualGenericaMasivo frm = new frmExportarProgramacionAnualGenericaMasivo())
            {
                frm.ShowDialog();
            }
        }

        private void ExportarPresupuestoRemuneracion()
        {
            listaProgramacionAnualPresentador.ExportarPresupuestoRemuneracion();
        }

        private void ExportarMasivoPresupuestoRemunracion()
        {
            using (frmExportarPresupuestoRemuneracionMasivo frm = new frmExportarPresupuestoRemuneracionMasivo())
            {
                frm.ShowDialog();
            }
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void Exportar(List<ReporteProgramacionAnualExportaPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "ProgramacionAnual_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnual(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
