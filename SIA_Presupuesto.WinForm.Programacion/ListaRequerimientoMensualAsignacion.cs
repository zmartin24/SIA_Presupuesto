using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Adicional;
using System.Threading;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraVerticalGrid;
using System.ComponentModel;
using System.Linq;
using DevExpress.Export;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using static DevExpress.Xpo.Logger.LogManager;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class ListaRequerimientoMensualAsignacion : ControlBase, IListaRequerimientoMensualAsignacionVista
    {
        private ListaRequerimientoMensualAsignacionPresentador listaRequerimientoMensualAsignacionPresentador;
        public List<RequerimientoMensualBienServicioPres> listaRequerimientoMensual
        {
            set;get;
        }
        public List<RequerimientoMensualBienServicioPres> listaRequerimientoMensualAsignado
        {
            set; get;
        }
        
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }
        public List<ProgramacionAnualPres> listaProgramacionAnual
        {
            set
            {
                //ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Presupuesto Anual", value);
                gluePresupuesto.Properties.DataSource = value;
            }
        }

        public int anio
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return lueMes.EditValue != null ? Convert.ToInt32(lueMes.EditValue) : 0; }
        }
        public int idProAnu
        {
            //set { luePresupuesto.EditValue = value; }
            //get { return luePresupuesto.EditValue != null ? Convert.ToInt32(luePresupuesto.EditValue) : 0; }
            set { gluePresupuesto.EditValue = value; }
            get { return gluePresupuesto.EditValue != null ? Convert.ToInt32(gluePresupuesto.EditValue) : 0; }
        }

        bool hacerCargar = false;
        
        Dictionary<RequerimientoMensualBienServicioPres, bool> listaRequerimientoMensualBienServicioSeleccionado = new Dictionary<RequerimientoMensualBienServicioPres, bool>();
        Dictionary<RequerimientoMensualBienServicioPres, bool> listaRequerimientoMensualAsignadoSeleccionado = new Dictionary<RequerimientoMensualBienServicioPres, bool>();

        public List<RequerimientoMensualBienServicioPres> ListaRequerimientoMensualBienServicioSeleccionado
        {
            get { return this.listaRequerimientoMensualBienServicioSeleccionado.Keys.ToList(); }
        }
        public List<RequerimientoMensualBienServicioPres> ListaRequerimientoMensualAsignadoSeleccionado
        {
            get { return this.listaRequerimientoMensualAsignadoSeleccionado.Keys.ToList(); }
        }

        public ListaRequerimientoMensualAsignacion()
        {
            InitializeComponent();
            this.listaRequerimientoMensualBienServicioSeleccionado = new Dictionary<RequerimientoMensualBienServicioPres, bool>();
            this.listaRequerimientoMensualAsignadoSeleccionado = new Dictionary<RequerimientoMensualBienServicioPres, bool>();

            this.listaRequerimientoMensualAsignacionPresentador = new ListaRequerimientoMensualAsignacionPresentador(this);
            hacerCargar = false;
        }

        protected override ColumnView ColumnaActual { get { return gcRequerimiento.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return gcRequerimiento; } }

        public RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoMensualBienServicioPres;  
            }
        }

        protected override ColumnView ColumnaSecundario { get { return gcRequeAsig.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridSecundario { get { return gcRequeAsig; } }

        public RequerimientoMensualBienServicioPres requerimientoMensualAsignadoPres
        {
            get
            {
                if (ColumnaSecundario == null || ColumnaSecundario.FocusedRowHandle < 0) return null;

                return ColumnaSecundario.GetRow(ColumnaSecundario.FocusedRowHandle) as RequerimientoMensualBienServicioPres;
            }
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            this.listaRequerimientoMensualAsignacionPresentador.Iniciar();
            Init();
            LlenarGrid();
            hacerCargar = true;

        }

        void Init()
        {
            InitializeGridControl1DragDrop();
            InitializeGridControl2DragDrop();
        }
        protected override void LlenarGrid()
        {
            CargarDatosSplash();
        }
        //protected void LlenarGrillas()
        //{
        //    CargarDatosSplash();
        //}
        protected void EjecutarCargarSplash()
        {
            this.listaRequerimientoMensualAsignacionPresentador.ObtenerDatosListado();
        }
        
        protected virtual void CargarDatosSplash()
        {
            Thread hilo = new Thread(new ThreadStart(this.EjecutarCargarSplash));
            hilo.Start();

            while (!hilo.IsAlive) ;

            Splash splash = new Splash(hilo, "Cargando Datos...");
            splash.ShowDialog();
            splash.Dispose();

            if (gcRequerimiento != null)
            {
                gcRequerimiento.DataSource = listaRequerimientoMensual;
                grvRequerimiento.RefreshData();
            }

            if (gcRequeAsig != null)
            {
                gcRequeAsig.DataSource = listaRequerimientoMensualAsignado;
                grvRequeAsig.RefreshData();
            }
        }

        //protected override void Nuevo()
        //{
        //    using (frmRequerimientoMensualBienServicio frm = new frmRequerimientoMensualBienServicio(null, this.FindForm()))
        //    {
        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            LlenarGrid();
        //        }
        //    }
        //}

        //protected override void Modificar()
        //{
        //    if (this.requerimientoMensualBienServicioPres != null)
        //    {
        //        requerimientoMensualBienServicio = listaRequerimientoMensualAsignacionPresentador.Buscar((Int32)requerimientoMensualBienServicioPres.idReqMenBieSer);
        //        using (frmRequerimientoMensualBienServicio frm = new frmRequerimientoMensualBienServicio(requerimientoMensualBienServicio, this.FindForm()))
        //        {
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                LlenarGrid();
        //            }
        //        }
        //    }
        //    else
        //        EmitirMensajeResultado(true, "Error : Seleccione una requerimiento requerimiento válido");
        //}

        

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch (nomOperacion)
            {
                case "DetalleRequerimiento": DetalleRequerimientoMensual(); break;
            }
        }


        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMes.EditValue != null && hacerCargar)
            {
                this.listaRequerimientoMensualAsignacionPresentador.LlenarListaProgramacionAnual();
                LlenarGrid();

            }
        }
        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMes.EditValue != null && hacerCargar)
                LlenarGrid();
        }
        private void luePresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMes.EditValue != null && hacerCargar)
                LlenarGrid();
        }
        private void btnQuitarPresupuesto_Click(object sender, EventArgs e)
        {
            DragDropToGridRequerimientoParaQuitarPresupuesto();
        }

        private void btnAsignarPresupuesto_Click(object sender, EventArgs e)
        {
            DragDropToGridRequerimientoParaAsignarPresupuesto();
        }

        private void grvRequerimiento_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            grvGrid_SelectionChanged(sender, e, ListaRequerimientoMensualBienServicioSeleccionado, listaRequerimientoMensualBienServicioSeleccionado);
            
        }
        private void grvRequeAsig_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            grvGrid_SelectionChanged(sender, e, this.ListaRequerimientoMensualAsignadoSeleccionado, this.listaRequerimientoMensualAsignadoSeleccionado);
        }
        private void grvRequeAsig_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        /*Metodos Personalizados*/
        private void DetalleRequerimientoMensual()
        {
            // obtaining the focused view
            ColumnView ViewAsig = (ColumnView)gcRequeAsig.FocusedView;
            ColumnView View = (ColumnView)gcRequerimiento.FocusedView;
            
            if (View.IsFocusedView)
            {
                // locating the row
                if (requerimientoMensualBienServicioPres != null)
                {
                    ListaRequerimientoMensualDetalle frm = new ListaRequerimientoMensualDetalle(requerimientoMensualBienServicioPres);
                    MostrarDialogoModulo(frm);
                }
            }
            if (ViewAsig.IsFocusedView)
            {
                if (requerimientoMensualAsignadoPres != null)
                {
                    ListaRequerimientoMensualDetalle frm = new ListaRequerimientoMensualDetalle(requerimientoMensualAsignadoPres);
                    MostrarDialogoModulo(frm);
                }
            }
        }
        //<gcRequerimiento>
        void InitializeGridControl1DragDrop()
        {
            behaviorManager1.Attach<DragDropBehavior>(grvRequerimiento, behavior => {
                behavior.DragDrop += Behavior_DragDropToGrid1;
            });
        }
        void Behavior_DragDropToGrid1(object sender, DragDropEventArgs e)
        {
            DragDropToGridRequerimientoParaQuitarPresupuesto();
            //int? vidProAnu = null;
            //Asignar(this.ListaRequerimientoMensualAsignadoSeleccionado, this.listaRequerimientoMensualAsignadoSeleccionado, vidProAnu);
            //LlenarGrillas();
        }
        //</gcRequerimiento>

        //<gcRequeAsig>
        void InitializeGridControl2DragDrop()
        {
            behaviorManager1.Attach<DragDropBehavior>(grvRequeAsig, behavior => {
                behavior.DragDrop += Behavior_DragDropToGrid2;
            });
        }
        void Behavior_DragDropToGrid2(object sender, DragDropEventArgs e)
        {
            DragDropToGridRequerimientoParaAsignarPresupuesto();
            //if (idProAnu == 0)
            //{
            //    EmitirMensajeResultado(true, "Seleccione un presupuesto anual válido");
            //    return;
            //}

            //Asignar(this.ListaRequerimientoMensualBienServicioSeleccionado, this.listaRequerimientoMensualBienServicioSeleccionado, idProAnu);
            //LlenarGrillas();
        }
        //</gcRequeAsig>
        private void grvGrid_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e, List<RequerimientoMensualBienServicioPres> listaGet, Dictionary<RequerimientoMensualBienServicioPres, bool> listaSet)
        {
            GridView grid = sender as GridView;
            DefaultBoolean showCheckBoxSelectorInColumnHeader = grid.OptionsSelection.ShowCheckBoxSelectorInColumnHeader;
            //bool esTodos = showCheckBoxSelectorInColumnHeader as bool;

            var requerimientoMensualSeleccionado = grid.GetFocusedRow() as RequerimientoMensualBienServicioPres;
            int[] idSeleccionados = grid.GetSelectedRows();

            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    if (!listaGet.Contains(requerimientoMensualSeleccionado))
                        listaSet.Add(requerimientoMensualSeleccionado, true);
                    break;
                case CollectionChangeAction.Remove:
                    if (listaGet.Contains(requerimientoMensualSeleccionado))
                        listaSet.Remove(requerimientoMensualSeleccionado);
                    break;
                case CollectionChangeAction.Refresh:
                    if (idSeleccionados.Length == 0)
                    {
                        listaSet.Clear();
                        return;
                    }
                    else
                    {
                        foreach (int idSelected in idSeleccionados)
                        {
                            var requerimientoMensualBienServicioPres = grid.GetRow(idSelected) as RequerimientoMensualBienServicioPres;

                            if (requerimientoMensualBienServicioPres != null)
                            {
                                if (listaGet.Contains(requerimientoMensualBienServicioPres))
                                    grid.SelectRow(e.ControllerRow);
                                else
                                    listaSet.Add(requerimientoMensualBienServicioPres, true);
                            }
                        }
                    }

                    break;
            }

            
        }
        private void Asignar(List<RequerimientoMensualBienServicioPres> lista, Dictionary<RequerimientoMensualBienServicioPres, bool> listaSet, int? idProAnu)
        {
            List<string> idsNoEliminados = new List<string>();

            if (lista.Count > 0)
            {
                foreach (RequerimientoMensualBienServicioPres requerimientoMensualSeleccionado in lista)
                {
                    if (!this.listaRequerimientoMensualAsignacionPresentador.AsignarRequerimiento(requerimientoMensualSeleccionado, idProAnu))                   
                        idsNoEliminados.Add(requerimientoMensualSeleccionado.idReqMenBieSer.ToString());
                }
                if (idsNoEliminados.Count > 0)
                    EmitirMensajeResultado(false, "Error en los siguientes requerimientos: " + string.Join(", ", idsNoEliminados));

                listaSet.Clear();
            }
        }

        private void DragDropToGridRequerimientoParaAsignarPresupuesto() 
        {
            if (this.ListaRequerimientoMensualBienServicioSeleccionado.Count == 0) return;
            if (idProAnu == 0)
            {
                EmitirMensajeResultado(true, "Seleccione un presupuesto anual válido");
                return;
            }

            Asignar(this.ListaRequerimientoMensualBienServicioSeleccionado, this.listaRequerimientoMensualBienServicioSeleccionado, idProAnu);
            LlenarGrid();
        }
        private void DragDropToGridRequerimientoParaQuitarPresupuesto()
        {
            if (this.ListaRequerimientoMensualAsignadoSeleccionado.Count == 0) return;
            int? vidProAnu = null;
            Asignar(this.ListaRequerimientoMensualAsignadoSeleccionado, this.listaRequerimientoMensualAsignadoSeleccionado, vidProAnu);
            LlenarGrid();
        }

        private void gluePresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMes.EditValue != null && hacerCargar)
                LlenarGrid();
        }
    }
}
