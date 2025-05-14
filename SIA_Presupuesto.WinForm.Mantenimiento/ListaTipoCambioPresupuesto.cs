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
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaTipoCambioPresupuesto : ControlBase, IListaTipoCambioPresupuestoVista
    {
        private ListaTipoCambioPresupuestoPresentador listaTipoCambioPresupuestoPresentador;

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

        public List<TipoCambioPresupuesto> listaDatosPrincipales
        {
            set
            {
                grcTipoCambioPresupuesto.DataSource = value;
            }
        }
        public TipoCambioPresupuesto tipoCambioPresupuesto
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as TipoCambioPresupuesto;
                return pro != null ? listaTipoCambioPresupuestoPresentador.Buscar(pro.idTipCamPres) : null;
            }
        }

        public ListaTipoCambioPresupuesto()
        {
            InitializeComponent();
            this.listaTipoCambioPresupuestoPresentador = new ListaTipoCambioPresupuestoPresentador(this);
            
        }

        protected override ColumnView ColumnaActual { get { return grcTipoCambioPresupuesto.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcTipoCambioPresupuesto; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            listaTipoCambioPresupuestoPresentador.Iniciar();
        }

        protected override void LlenarGrid()
        {
            listaTipoCambioPresupuestoPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmTipoCambioPresupuesto frm = new frmTipoCambioPresupuesto(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmTipoCambioPresupuesto frm = new frmTipoCambioPresupuesto(tipoCambioPresupuesto, this.FindForm()))
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
                if (listaTipoCambioPresupuestoPresentador.Anular())
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
        private void grvTipoCambioPresupuesto_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            string res;

            ColumnView view = sender as ColumnView;

            if (e.Column.FieldName == "mes" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                res = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "mes").ToString();
                int vtipoReq = (Convert.ToInt32(res));

                switch (vtipoReq)
                {
                    case 1:
                        e.DisplayText = "ENERO";
                        break;
                    case 2:
                        e.DisplayText = "FEBRERO";
                        break;
                    case 3:
                        e.DisplayText = "MARZO";
                        break;
                    case 4:
                        e.DisplayText = "ABRIL";
                        break;
                    case 5:
                        e.DisplayText = "MAYO";
                        break;
                    case 6:
                        e.DisplayText = "JUNIO";
                        break;
                    case 7:
                        e.DisplayText = "JULIO";
                        break;
                    case 8:
                        e.DisplayText = "AGOSTO";
                        break;
                    case 9:
                        e.DisplayText = "SETIEMBRE";
                        break;
                    case 10:
                        e.DisplayText = "OCTUBRE";
                        break;
                    case 11:
                        e.DisplayText = "NOVIEMBRE";
                        break;
                    case 12:
                        e.DisplayText = "DICIEMBRE";
                        break;
                }
            }
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio != null)
                listaTipoCambioPresupuestoPresentador.ObtenerDatosListado();
        }
    }
}
