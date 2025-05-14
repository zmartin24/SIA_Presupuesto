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
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Ayuda;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class frmGeneralReporte : ControlBase, IGeneralReporteVista
    {
        private GeneralReportePresentador generalReportePresentador;
        public List<Predeterminado> listaReporte
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueReporte.Properties, "codigo", "descripcion", "Direcciones", value);
            }
        }
        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }
        public List<Anio> listaPeriodo
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePeriodo.Properties, "indice", "nombre", "Periodo", value);
            }
        }

        public int idDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }
        public string codReporte
        {
            set
            {
                lueReporte.EditValue = value;
            }
            get { return Convert.ToString(lueReporte.EditValue); }
        }
        public int codPeriodo
        {
            get { return luePeriodo.EditValue != null ? Convert.ToInt32(luePeriodo.EditValue) : 0; }
            set { luePeriodo.EditValue = value; }
        }

        //public Nullable<DateTime> FechaDesde
        //{
        //    set { deFechaDesde.EditValue = value; }
        //    get { return deFechaDesde.DateTime; }
        //}

        //public Nullable<DateTime> FechaHasta
        //{
        //    set { deFechaHasta.EditValue = value; }
        //    get { return deFechaHasta.DateTime; }
        //}

        private GrupoPresupuesto grupoPresupuesto;
        private Presupuesto presupuesto;
        private Subpresupuesto subpresupuesto;

        public GrupoPresupuesto GrupoPresupuesto
        {
            get { return grupoPresupuesto; }
            set
            {
                grupoPresupuesto = value;
                if (value != null)
                {
                    txtGrupoPresupuesto.Text = value.descripcion;
                }

                else
                {
                    txtGrupoPresupuesto.Text = string.Empty;
                }
            }
        }
        public Presupuesto Presupuesto
        {
            get { return presupuesto; }
            set
            {
                presupuesto = value;
                if (value != null)
                {
                    txtPresupuesto.Text = value.descripcion;
                }
                else
                {
                    txtPresupuesto.Text = string.Empty;
                }

            }
        }        
        public Subpresupuesto Subpresupuesto
        {
            get { return subpresupuesto; }
            set
            {
                subpresupuesto = value;
                if (value != null)
                {
                    txtSubPresupuesto.Text = value.descripcion;

                }
                else
                {
                    txtSubPresupuesto.Text = string.Empty;

                }
            }
        }

        public int idPresupuesto { get; set; }
        public int nivel { get; set; }

        public frmGeneralReporte()
        {
            InitializeComponent();
            this.generalReportePresentador = new GeneralReportePresentador(this);
            this.lciDireccion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            Text = "Reportes Generales";
        }

        
        protected override void InicializarDatos()
        {
            this.generalReportePresentador.IniciarDatos();
            this.idPresupuesto = 0;
            this.nivel = 0;
        }

        private void sbBuscar_Click(object sender, EventArgs e)
        {
            List<object> lista = new List<object>();
            lista = generalReportePresentador.ListaReporte();
            if (lista.Count > 0)
                generalReportePresentador.ImprimirGastoRecurrente(lista);
            else
                EmitirMensajeResultado(true, "Consulta no generó datos");
        }

        private void sbAyudaGrupoPresupuesto_Click(object sender, EventArgs e)
        {
            AbrirAyudaPresupuesto(0, tipoAyudaPresupuesto.grupoPresupuesto);
        }

        private void sbAyudaPresupuesto_Click(object sender, EventArgs e)
        {
            int id = this.GrupoPresupuesto != null ? this.GrupoPresupuesto.idGruPre : 0;
            AbrirAyudaPresupuesto(id, tipoAyudaPresupuesto.presupuesto);
        }

        private void sbAyudaSubPresupuesto_Click(object sender, EventArgs e)
        {
            int id = this.Presupuesto != null ? this.Presupuesto.idPresupuesto : 0;
            AbrirAyudaPresupuesto(id, tipoAyudaPresupuesto.subpresupuesto);
        }

        private void AbrirAyudaPresupuesto(int id, tipoAyudaPresupuesto tipo)
        {
            using (frmAyudaPresupuesto frm = new frmAyudaPresupuesto(id, tipo))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (tipo)
                    {
                        case tipoAyudaPresupuesto.grupoPresupuesto:
                            this.GrupoPresupuesto = frm.Tag as GrupoPresupuesto;
                            this.idPresupuesto = this.GrupoPresupuesto == null ? 0 : this.GrupoPresupuesto.idGruPre;
                            this.nivel = this.GrupoPresupuesto == null ? 0 : 1;

                            txtPresupuesto.Text = "";
                            txtSubPresupuesto.Text = "";
                            this.Presupuesto = null;
                            this.Subpresupuesto = null;

                            break;
                        case tipoAyudaPresupuesto.presupuesto:
                            this.Presupuesto = frm.Tag as Presupuesto;
                            this.idPresupuesto = this.Presupuesto == null ? 0 : this.Presupuesto.idPresupuesto;
                            this.nivel = this.Presupuesto == null ? 0 : 2;

                            txtSubPresupuesto.Text = "";
                            this.Subpresupuesto = null;
                            break;
                        case tipoAyudaPresupuesto.subpresupuesto:
                            this.Subpresupuesto = frm.Tag as Subpresupuesto;
                            this.idPresupuesto = this.Subpresupuesto == null ? 0 : this.Subpresupuesto.idSubpresupuesto;
                            this.nivel = this.Subpresupuesto == null ? 0 : 3;
                            break;
                    }
                }
            }
        }

        private void sbLimpiar_Click(object sender, EventArgs e)
        {
            generalReportePresentador.Limpiar();
        }
    }
}
