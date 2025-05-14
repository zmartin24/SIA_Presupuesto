using System;
using System.Collections.Generic;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;

using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class frmReporteEvaluacionBienServicio : ControlBase, IReporteEvaluacionBienServicioVista
    {
        private ReporteEvaluacionBienServicioPresentador reporteEvaluacionBienServicioPresentador;
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Periodo", value);
            }
        }
        public List<GrupoPresupuesto> listaGruPre
        {
            set
            {
                glueGruPre.Properties.DisplayMember = "descripcion";
                glueGruPre.Properties.ValueMember = "idGruPre";
                glueGruPre.Properties.NullText = string.Empty;
                glueGruPre.Properties.DataSource = value;
            }
        }
        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }
        public List<Subdireccion> listaSubdireccion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubDireccion.Properties, "idSubdireccion", "desSubdireccion", "Sub Direcciones", value);
            }
        }


        public int vanio
        {
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
            set { lueAnio.EditValue = value; }
        }
        public int vidGruPre
        {
            set { glueGruPre.EditValue = value; }
            get { return Convert.ToInt32(glueGruPre.EditValue); }
        }
        public int vidDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }
        public int vidSubDireccion
        {
            set
            {
                lueSubDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueSubDireccion.EditValue); }
        }
        bool primerLlamado = false;
        public List<ReporteEvaluacionDetalladaBienSerPres> listaDatosPrincipales
        {
            set
            {
                pivotGridControl1.DataSource = value;
            }
        }
        public frmReporteEvaluacionBienServicio()
        {
            InitializeComponent();
            this.reporteEvaluacionBienServicioPresentador = new ReporteEvaluacionBienServicioPresentador(this);
            Text = "Reporte de Evaluacion Detalle Bienes y Servicios";
            primerLlamado = false;
        }
        
        protected override DevExpress.XtraPivotGrid.PivotGridControl PivotGridPrincipal { get { return pivotGridControl1; } }
        protected override bool ExportarDePivot { get { return true; } }
        protected override void InicializarDatos()
        {
            this.reporteEvaluacionBienServicioPresentador.IniciarDatos();
        }
        
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }
        protected override void EjecutarCargarConSplash()
        {
            if (glueGruPre.EditValue != null && lueAnio.EditValue != null && lueDireccion.EditValue != null) //if (lueAnio.EditValue != null && lueDireccion.EditValue != null && lueSubDireccion.EditValue != null && primerLlamado)
            {
                this.reporteEvaluacionBienServicioPresentador.llenarGridPivot();
                primerLlamado = true;
            }
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "ExportaEvaDet": ExportarEvaluacionDetalladaBienServicio(); break;
            }
        }

        private void glueGruPre_EditValueChanged(object sender, EventArgs e)
        {
            
            if (glueGruPre.EditValue != null && lueAnio.EditValue != null && lueDireccion.EditValue != null && lueSubDireccion.EditValue != null && primerLlamado)//if (glueGruPre.EditValue != null)
                LlenarGrid();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (glueGruPre.EditValue != null && lueAnio.EditValue != null && lueDireccion.EditValue != null && lueSubDireccion.EditValue != null && primerLlamado) //if (lueAnio.EditValue != null) 
                LlenarGrid();
        }

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (glueGruPre.EditValue != null && lueAnio.EditValue != null && lueDireccion.EditValue != null && primerLlamado) //if (lueDireccion.EditValue != null)
            {
                this.reporteEvaluacionBienServicioPresentador.llenarComboSubDireccion();
                LlenarGrid();
            }
        }

        private void lueSubDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (glueGruPre.EditValue != null && lueAnio.EditValue != null && lueDireccion.EditValue != null && lueSubDireccion.EditValue != null && primerLlamado) //if (lueSubDireccion.EditValue != null)
                LlenarGrid();
        }

        private void ExportarEvaluacionDetalladaBienServicio()
        {
            this.reporteEvaluacionBienServicioPresentador.ExportarEvaluacionDetalladaBienServicio();
        }
    }
}
