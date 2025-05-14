using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using System.Globalization;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System.IO;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaReajusteMensualPresupuesto : ControlBase, IListaReajusteMensualPresupuestoVista
    {
        private ListaReajusteAnualPresupuestoPresentador listaReajusteAnualPresupuestoPresentador;

        #region Variables de Interface
        public List<ReajusteMensualPresupuestoPres> listaDatosPrincipales
        {
            set
            {
                grcReajusteMensual.DataSource = value;
            }
        }

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }

        public List<Mes> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int anioPresentacion
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }

        public int mesPresentacion
        {
            set { lueMes.EditValue = value; }
            get { return lueMes.EditValue != null ? Convert.ToInt32(lueMes.EditValue) : 0; }
        }

        public int idMoneda
        {
            set; get;
        }
        public List<ReporteReajusteMensualExportaPres> listaReporteReajusteMensualExportaPres
        {
            set; get;
        }
        #endregion
        public ListaReajusteMensualPresupuesto()
        {
            InitializeComponent();
            this.listaReajusteAnualPresupuestoPresentador = new ListaReajusteAnualPresupuestoPresentador(this);
        }

        protected override ColumnView ColumnaActual { get { return grcReajusteMensual.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcReajusteMensual; } }
        public ReajusteMensualProgramacion ReajusteMensualProgramacion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ReajusteMensualPresupuestoPres;
                return pro != null ? listaReajusteAnualPresupuestoPresentador.Buscar(pro.idReaMenPro) : null;
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaReajusteAnualPresupuestoPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaReajusteAnualPresupuestoPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmReajusteMensualGeneral frm = new frmReajusteMensualGeneral(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (ReajusteMensualProgramacion != null)
            {
                
                using (frmReajusteMensualGeneral frm = new frmReajusteMensualGeneral(ReajusteMensualProgramacion, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
        }

        public override bool Anular()
        {
            //bool respuesta = false;
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaReajusteAnualPresupuestoPresentador.AnularRegistro())
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
                case "DetalleReajusteMensual": DetallePresupuestoAnual(); break;
                case "ExportarReaMen": ExportarReajusteMensual(); break;
                case "Rep": break;
                case "ImprimirCalendario":
                    ImprimirCalendario(); break;
                case "ResumenPorSubdireccion":
                    ImprimirPorDireccion(); break;
                case "ExportarEvaluacionReajuste":
                    ExportarEvaluacionReajuste(); break;
                case "ConsolidadoPorDireccion":
                    ConsolidadoPorDireccion(); break;
                case "ExportarEvaReaMas":
                    ExportarEvaluacionReajusteMasivo(); break;
                case "ImprimirSaldoEvaRea":
                    ImprimirPorSaldo(); break;
                case "CalculoRemuneracion":
                    CalculoRemuneracion(); break;
                case "ActualizarDesdeRRHH":
                    ActualizarRRHH(); break;
                case "ExportarPresRem":
                    ExportarPresupuestoRemuneracion(); break;
                case "ExportarPresRemMasivo":
                    ExportarMasivoPresupuestoRemunracion(); break;
                case "AsignarPresupuestoMensual":
                    AsignarPresupuestoMensual(); break;
                case "ActualizarReqMen":
                    ActualizarDesdeRequerimientoMensual(); break;
                    
            }
        }

        private void CalculoRemuneracion()
        {
            if (!esDetalleExistente(0))
            {
                if (ReajusteMensualProgramacion != null)
                {
                    frmReajustePresupuestoRemuneracion frm = new frmReajustePresupuestoRemuneracion(ReajusteMensualProgramacion);
                    MostrarDialogoModulo(frm);
                }
                else EmitirMensajeResultado(true, "Debe seleccionar un reajuste de plan presupuestal");
            }
        }

        private void ActualizarRRHH()
        {
            if (ReajusteMensualProgramacion != null)
            {
                if (ReajusteMensualProgramacion.estado != Estados.Aprobado && ReajusteMensualProgramacion.estado != Estados.Rechazado)
                {
                    using (frmActualizacionReajustePorRRHH frm = new frmActualizacionReajustePorRRHH(ReajusteMensualProgramacion.idReaMenPro, ReajusteMensualProgramacion.idProAnu, this.FindForm()))
                    {
                        frm.ShowDialog();
                    }
                }
                else EmitirMensajeResultado(true, "El reajuste del plan presupuestal ya fue procesado");
            }
        }

        private void ExportarEvaluacionReajuste()
        {
            frmExportarReajusteEvaluacion frm = new frmExportarReajusteEvaluacion();
            frm.ShowDialog();
        }

        private void ExportarEvaluacionReajusteMasivo()
        {
            frmExportarReajusteEvaluacionMasivo frm = new frmExportarReajusteEvaluacionMasivo();
            frm.ShowDialog();
        }

        private void ConsolidadoPorDireccion()
        {
            frmImprimirConsolidadoEvaluacionReajusteAnual frm = new frmImprimirConsolidadoEvaluacionReajusteAnual();
            frm.ShowDialog();
        }

        private void DetallePresupuestoAnual()
        {
            if (!esDetalleExistente(0))
            {
                if (ReajusteMensualProgramacion != null)
                {
                    var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ReajusteMensualPresupuestoPres;
                    frmReajusteMensualPresupuesto frm = new frmReajusteMensualPresupuesto(pro.tipo, ReajusteMensualProgramacion);
                    MostrarDialogoModulo(frm);
                }
            }
        }

        private void ExportarReajusteMensual()
        {
            if (this.ReajusteMensualProgramacion != null)
            {
                using (frmSeleccionMoneda frm = new frmSeleccionMoneda(this.ReajusteMensualProgramacion.descripcion, "", "Exportar Reajuste Mensual"))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.idMoneda = (Int32)frm.Tag;
                        listaReporteReajusteMensualExportaPres = listaReajusteAnualPresupuestoPresentador.TraerReporteReajusteMensualExporta();
                        if (listaReporteReajusteMensualExportaPres.Count > 0)
                            ExportarExcel(1);
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

        private void ImprimirResumen()
        {
            //using (frmReporteReajuste frm = new frmReporteReajuste())
            //{
            //    frm.ShowDialog();
            //}
        }

        private void ImprimirCalendario()
        {
            using (frmImprimirCalendarioReajusteEvaluacion frm = new frmImprimirCalendarioReajusteEvaluacion())
            {
                frm.ShowDialog();
            }
        }

        private void AsignarPresupuestoMensual()
        {
            if (ReajusteMensualProgramacion != null)
            {
                using (frmAsignarPresupuestoMensualReajuste frm = new frmAsignarPresupuestoMensualReajuste(ReajusteMensualProgramacion, this.UsuarioOperacion, this.FindForm()))
                {
                    frm.ShowDialog();
                }
            }
            else EmitirMensajeResultado(true, Mensajes.RegistroVacio);
        }

        private void ActualizarDesdeRequerimientoMensual()
        {
            if (ReajusteMensualProgramacion != null)
            {
                if(EmitirMensajePregunta("¿Está seguro de actualizar desde requerimiento mensual?"))
                {
                    if (this.listaReajusteAnualPresupuestoPresentador.ActualizarDesdeRequerimientoMensualBienesServicio())
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                }
            }
        }

        protected override void Imprimir()
        {
            ImprimirResumen();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void ImprimirPorDireccion()
        {
            using (frmImprimirPorDireccionReajusteMensual frm = new frmImprimirPorDireccionReajusteMensual())
            {
                frm.ShowDialog();
            }
        }

        protected void ImprimirPorSaldo()
        {
            using (frmImprimirSaldoEvaluacionReajusteAnual frm = new frmImprimirSaldoEvaluacionReajusteAnual())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //LlenarGrid();
                }
            }
        }

        private void ExportarPresupuestoRemuneracion()
        {
            listaReajusteAnualPresupuestoPresentador.ExportarPresupuestoRemuneracion();
        }

        private void ExportarMasivoPresupuestoRemunracion()
        {
            using (frmExportarReajustePresupuestoRemuneracionMasivo frm = new frmExportarReajustePresupuestoRemuneracionMasivo())
            {
                frm.ShowDialog();
            }
        }
        private void ExportarExcel(int opcion)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                // opcion=>1: ReajusteMensual
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "ReajusteMensual_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                switch (opcion)
                {
                    case 1:
                        ExportarProHelper.ExportarReajusteMensualPresupuesto(ruta, this.ReajusteMensualProgramacion, listaReporteReajusteMensualExportaPres);
                        break;
                }
                
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
