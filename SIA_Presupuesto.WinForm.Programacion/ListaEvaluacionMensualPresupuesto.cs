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
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System.IO;
using System.Globalization;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaEvaluacionMensualPresupuesto : ControlBase, IListaEvaluacionMensualPresupuestoVista
    {
        private ListaEvaluacionAnualPresupuestoPresentador listaEvaluacionAnualPresupuestoPresentador;

        public List<EvaluacionMensualPresupuestoPres> listaDatosPrincipales
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

        public ListaEvaluacionMensualPresupuesto()
        {
            InitializeComponent();
            this.listaEvaluacionAnualPresupuestoPresentador = new ListaEvaluacionAnualPresupuestoPresentador(this);
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacionAnual.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacionAnual; } }

        public EvaluacionMensualProgramacion EvaluacionMensualProgramacion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as EvaluacionMensualPresupuestoPres;
                return pro != null ? listaEvaluacionAnualPresupuestoPresentador.Buscar(pro.idEvaMenPro) : null;
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaEvaluacionAnualPresupuestoPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaEvaluacionAnualPresupuestoPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmEvaluacionMensualGeneral frm = new frmEvaluacionMensualGeneral(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (EvaluacionMensualProgramacion != null)
            {
                
                using (frmEvaluacionMensualGeneral frm = new frmEvaluacionMensualGeneral(EvaluacionMensualProgramacion, this.FindForm()))
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
                if (listaEvaluacionAnualPresupuestoPresentador.AnularRegistro())
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
                case "DetalleEvaluacionMensual": DetallePresupuestoAnual(); break;
                case "ExportarEvaMen": ExportarEvaluacionMensual(); break;
                case "ImprimirEjeSub": ImprimirPorSubpresupuesto(); break;
                case "ImprimirEjeFechas": ImprimirEntreFechas(); break;
                case "ImprimirCalendario":
                    ImprimirCalendario(); break;
                case "ResumenPorSubdireccion":
                    ImprimirPorDireccion(); break;
                case "ExportarEvaluacionReajuste":
                    ExportarEvaluacionReajuste(); break;
                case "ConsolidadoPorDireccion": ConsolidadoPorDireccion(); break;
                case "ExportarEvaReaMas":
                    ExportarEvaluacionReajusteMasivo(); break;

                case "ImprimirSaldoEvaRea":
                    ImprimirPorSaldo(); break;
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
                if (EvaluacionMensualProgramacion != null)
                {
                    var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as EvaluacionMensualPresupuestoPres;
                    frmEvaluacionMensualPresupuesto frm = new frmEvaluacionMensualPresupuesto(pro.tipo, EvaluacionMensualProgramacion);
                    MostrarDialogoModulo(frm);
                }
            }
        }

        private void ExportarEvaluacionMensual()
        {
            if (this.EvaluacionMensualProgramacion != null)
            {
                using (frmSeleccionMoneda frm = new frmSeleccionMoneda(this.EvaluacionMensualProgramacion.descripcion, "", "Exportar Evaluación Mensual"))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.idMoneda = (Int32)frm.Tag;
                        List<ReporteEvaluacionMensualExportaPres> lista = listaEvaluacionAnualPresupuestoPresentador.TraerReporteEvaluacionMensualExporta();
                        if (lista.Count > 0)
                            ExportarExcel(lista);
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
            using (frmReporteEvaluacion frm = new frmReporteEvaluacion())
            {
                frm.ShowDialog();
            }
        }

        protected override void Imprimir()
        {
            ImprimirResumen();
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

        protected void ImprimirPorSubpresupuesto()
        {
            using (frmImprimirEjecucionFechasSubpresupuesto frm = new frmImprimirEjecucionFechasSubpresupuesto(this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected void ImprimirEntreFechas()
        {
            using (frmImprimirEjecucionFechas frm = new frmImprimirEjecucionFechas(this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        private void ImprimirCalendario()
        {
            using (frmImprimirCalendarioReajusteEvaluacion frm = new frmImprimirCalendarioReajusteEvaluacion())
            {
                frm.ShowDialog();
            }
        }

        private void ImprimirPorDireccion()
        {
            using (frmImprimirPorDireccionReajusteMensual frm = new frmImprimirPorDireccionReajusteMensual())
            {
                frm.ShowDialog();
            }
        }

        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        private void ExportarExcel(List<ReporteEvaluacionMensualExportaPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "EvaluacionMensualAreaExporta_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                //ExportarProHelper.ExportarEvaluacionMensualPresupuesto(ruta, lista);
                ExportarProHelper.ExportarEvaluacionMensualPresupuestoGenerica(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
