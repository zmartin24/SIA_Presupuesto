using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Ayuda;
using System.IO;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using System.Globalization;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaPresupuestoMensual : ControlBase, IListaSubPresupuestoVista
    {
        private ListaSubPresupuestoPresentador listaSubPresupuestoPresentador;
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
        public List<SubPresupuestoPoco> listaDatosPrincipales
        {
            set
            {
                gcSubPresupuesto.DataSource = value;
            }
        }
        public SubPresupuestoPoco subPresupuesto
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as SubPresupuestoPoco;
            }
        }

        public int idMoneda
        {
            set;get;
        }

        private bool res = true;
        private string vmensaje = string.Empty;

        protected override ColumnView ColumnaActual { get { return gcSubPresupuesto.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return gcSubPresupuesto; } }

        public ListaPresupuestoMensual()
        {
            InitializeComponent();
            this.listaSubPresupuestoPresentador = new ListaSubPresupuestoPresentador(this);
        }
        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaSubPresupuestoPresentador.Iniciar();
        }

        protected override void Nuevo()
        {
            using (frmPresupuestoMensual frm = new frmPresupuestoMensual(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmPresupuestoMensual frm = new frmPresupuestoMensual(subPresupuesto, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "Aprobar": Aprobar(); break;
                case "Liquidar": Liquidar(); break;
                case "DetallePresupuestoAnual": DetallePresupuestoAnual();break;
                case "ExportarPresMen": ExportartoExcel(); break;
            }
        }

        public void DetallePresupuestoAnual()
        {
            using (frmDetalleProgramacionMensual frm = new frmDetalleProgramacionMensual(subPresupuesto,subPresupuesto.mes.GetValueOrDefault()))
            {
                frm.ShowDialog();
            }
        }
        private void ExportartoExcel()
        {
            if (subPresupuesto != null)
            {
                using (frmSeleccionMoneda frm = new frmSeleccionMoneda(subPresupuesto.desPresupuesto, subPresupuesto.desSubPresupuesto, "Exportar Presupuesto Mensual"))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.idMoneda = (Int32)frm.Tag;
                        List<ReporteSubpresupuestoExportaPres> lista = listaSubPresupuestoPresentador.TraerReporteSubpresupuestoExporta();
                        if (lista.Count > 0)
                            Exportar(lista);
                        else
                            EmitirMensajeResultado(true, "no se realizó exportación");
                    }
                }
            }
            else
            {
                EmitirMensajeResultado(true, "Seleccione un presupuesto mensual");
            }
            
        }

        public  bool Aprobar()
        {
            if (EmitirMensajePregunta("¿Está seguro que desea aprobar el presupuesto mensual?"))
            {
                if (listaSubPresupuestoPresentador.Aprobar())
                {
                    EmitirMensajeResultado(true, "Registro aprobado con éxito.");
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, "No se pudo aprobar el registro.");
                }
            }
            return true;
        }

        public  bool Liquidar()
        {
            if (EmitirMensajePregunta("¿Está seguro que desea liquidar el presupuesto mensual?"))
            {
                if (listaSubPresupuestoPresentador.Liquidar())
                {
                    EmitirMensajeResultado(true, "Registro liquidado con éxito.");
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, "No se pudo liquidar el registro.");
                }
            }
            return true;
        }

        public override bool Eliminar()
        {
            if (!validar())
            {
                EmitirMensajeResultado(false, vmensaje);
                return false;
            }

            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaSubPresupuestoPresentador.Anular())
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
            listaSubPresupuestoPresentador.ObtenerDatosListado();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if(lueAnio!=null)
                listaSubPresupuestoPresentador.ObtenerDatosListado();
        }

        private void Exportar(List<ReporteSubpresupuestoExportaPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                //string ruta = Path.GetTempPath() + "Subpresupuesto_" + Path.GetRandomFileName() + ".xlsx";
                string ruta = Path.GetTempPath() + "Subpresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarSubpresupuesto(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
        private bool validar()
        {
            vmensaje = string.Empty;
            res = true;
            Resultado result = listaSubPresupuestoPresentador.VerificarSubpresupuesto();
            if (!result.esCorrecto)
            {
                res = false;
                vmensaje = vmensaje + result.mensajeMostrar + Environment.NewLine;
            }

            return res;
        }
    }
}
