using System;
using System.Collections.Generic;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using Utilitario.Util;
using DevExpress.XtraPivotGrid;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaPrecioBienServicio : ControlBase, IListaPrecioBienServicioVista
    {
        private ListaPrecioBienServicioPresentador listaPrecioBienServicioPresentador;

        public List<PrecioBienServicioPorGruPrePres> listaDatosPrincipales
        {
            set
            {
                pivotGridControl1.DataSource = value;
            }
        }
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Año", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }
        public List<GrupoPresupuesto> listaGrupoPresupuesto
        {
            set { ElementoHelper.LlenarLookUpEdit(lueGruPre.Properties, "idGruPre", "descripcion", "Descripción", value); }
        }
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }

        public int vanio
        {
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : DateTime.Now.Year; }
            set { lueAnio.EditValue = value; }
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return lueMes.EditValue!= null ? (Int32)lueMes.EditValue : DateTime.Now.Month; }
        }
        public int idGruPre
        {
            set { lueGruPre.EditValue = value; }
            get { return Convert.ToInt32(lueGruPre.EditValue); }
        }
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 63; }
        }
        
        public ListaPrecioBienServicio()
        {
            InitializeComponent();
            this.listaPrecioBienServicioPresentador = new ListaPrecioBienServicioPresentador(this);
        }
        
        protected override PivotGridControl PivotGridPrincipal { get { return pivotGridControl1; } }
        protected override bool ExportarDePivot { get { return true; } }
        protected override void InicializarDatos()
        {
            this.listaPrecioBienServicioPresentador.IniciarDatos();
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }
        protected override void EjecutarCargarConSplash()
        {
            if (lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null)
            {
                this.listaPrecioBienServicioPresentador.llenarGridPivot();
            }
        }
        private void sbConsultar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
