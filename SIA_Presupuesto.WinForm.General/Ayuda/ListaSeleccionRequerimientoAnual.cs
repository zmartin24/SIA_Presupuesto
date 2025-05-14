using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Presentador;
using SIA_Presupuesto.WinForm.General.Vista;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class ListaSeleccionRequerimientoAnual : XtraUserControl, IListaSeleccionRequerimientoAnualVista
    {
        private ListaSeleccionRequerimientoAnualPresentador listaSeleccionRequerimientoAnualPresentador;
        
        #region vistas
        public List<RequerimientoBienServicioPres> listaDatosPrincipales
        {
            set
            {
                grcRequerimientoBienSer.DataSource = value;
            }
        }
        
        private Dictionary<RequerimientoBienServicioPres, bool> listaRequerimientoBienServicioPresSeleccionados;
        public List<RequerimientoBienServicioPres> ListaRequerimientoBienServicioPresSeleccionados
        {
            get { return listaRequerimientoBienServicioPresSeleccionados.Keys.ToList(); }
        }
        public object idsReqBienSer
        {
            get; set;
        }
        #endregion
        public ListaSeleccionRequerimientoAnual(int vAnio, int vIdUsuario)
        {
            InitializeComponent();

            listaSeleccionRequerimientoAnualPresentador = new ListaSeleccionRequerimientoAnualPresentador(vAnio, vIdUsuario, this);
            this.listaRequerimientoBienServicioPresSeleccionados = new Dictionary<RequerimientoBienServicioPres, bool>();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            iniciarControles();
            listaSeleccionRequerimientoAnualPresentador.LlenarGrid();
        }

        private object seleccionarIdsReqBienSer()
        {
            string codigos = string.Empty;
            List<string> values = new List<string>();

            foreach (RequerimientoBienServicioPres requerimientoBienServicioPres in ListaRequerimientoBienServicioPresSeleccionados)
            {
                if (requerimientoBienServicioPres != null)
                {
                    values.Add(requerimientoBienServicioPres.idReqBieSer.ToString());
                }
            }
            codigos = String.Join("~", values);

            return codigos;
        }
        private void grvRequerimientoBienSer_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            RequerimientoBienServicioPres requerimientoBienServicioPres = view.GetFocusedRow() as RequerimientoBienServicioPres;
            int count = 0;

            if (requerimientoBienServicioPres != null)
            {
                switch (e.Action)
                {
                    case CollectionChangeAction.Add:
                        if (!this.ListaRequerimientoBienServicioPresSeleccionados.Contains(requerimientoBienServicioPres))
                            this.listaRequerimientoBienServicioPresSeleccionados.Add(requerimientoBienServicioPres, true);
                        break;
                    case CollectionChangeAction.Remove:
                        if (this.ListaRequerimientoBienServicioPresSeleccionados.Contains(requerimientoBienServicioPres))
                            this.listaRequerimientoBienServicioPresSeleccionados.Remove(requerimientoBienServicioPres);
                        break;
                    case CollectionChangeAction.Refresh:
                        if (this.ListaRequerimientoBienServicioPresSeleccionados.Contains(requerimientoBienServicioPres))
                            view.SelectRow(e.ControllerRow);
                        break;
                }
            }
            count = this.ListaRequerimientoBienServicioPresSeleccionados.Count > 0 ? this.ListaRequerimientoBienServicioPresSeleccionados.Count : 0;
            if (count > 0)
            {
                string desResgistros = count == 1 ? "Registro seleccionado" : "Registros seleccionados";
                lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcNumReg.Text = String.Format("{0} {1}", count, desResgistros);
                idsReqBienSer = seleccionarIdsReqBienSer();
                this.listaSeleccionRequerimientoAnualPresentador.AsignarIdsBienServicio(this);
            }
            else
            {
                lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcNumReg.Text = string.Empty;
                idsReqBienSer = null;
            }
        }

        private void iniciarControles()
        {
            lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcNumReg.Text = string.Empty;
            this.listaRequerimientoBienServicioPresSeleccionados.Clear();
        }
    }
}
