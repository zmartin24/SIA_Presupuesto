using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaPresupuestoMensualDetalles : System.Web.UI.Page, IListaPresupuestoMensualDetalleVista
    {
        private ListaPresupuestoMensualDetallesPresentador listaPresupuestoMensualDetallesPresentador;

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public List<SubPresupuestoAreaPres> listaDatosPrincipales
        {
            set
            {
                this.grvSubPreDet.DataSource = value;
                this.grvSubPreDet.DataBind();
            }
        }
        
        public int idSubPre
        {
            set { hdfValores["idSubPre"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idSubPre"]); }
        }
        public string desPresupuesto
        {
            set { lblDesPresupuesto.Text = value.ToString(); }
            get { return lblDesPresupuesto.Text; }
        }
        public string desSubPresupuesto
        {
            set { lblDesSubPresupuesto.Text = value.ToString(); }
            get { return lblDesSubPresupuesto.Text; }
        }
        public string tipoCambio
        {
            set { lblTipoCambio.Text = value.ToString(); }
            get { return lblTipoCambio.Text; }
        }
        public string proyecto
        {
            set { lblProyecto.Text = value.ToString(); }
            get { return lblProyecto.Text; }
        }
        public string esObra
        {
            set { lblObra.Text = value.ToString(); }
            get { return lblObra.Text; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            listaPresupuestoMensualDetallesPresentador = new ListaPresupuestoMensualDetallesPresentador(this);
            listaPresupuestoMensualDetallesPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                hdfValores.Add("idSubPre", Request.Params.Get("idSubPre"));
            }
            Actualizar();
        }

        public void Actualizar()
        {
            listaPresupuestoMensualDetallesPresentador.Iniciar();
            grvSubPreDet.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            cpPrincipal.JSProperties["cpGrid"] = "grvReqDet";

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ListaPresupuestoMensual.aspx", idSubPre));
        }

        //protected void grvReqDet_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        //{
            
        //}

        //protected void grvReqDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        //{
        //    ASPxGridView grid = sender as ASPxGridView;
        //    int id = (Int32)e.Keys[0];

        //    //Enero
        //    if (e.NewValues["cantEnero"] != e.OldValues["cantEnero"])
        //    {
        //        Decimal enero = e.NewValues["cantEnero"] != null ? Convert.ToDecimal(e.NewValues["cantEnero"]) : 0.0m;
        //    }

        //    //Febrero
        //    if (e.NewValues["cantFebrero"] != e.OldValues["cantFebrero"])
        //    {
        //        Decimal enero = e.NewValues["cantFebrero"] != null ? Convert.ToDecimal(e.NewValues["cantFebrero"]) : 0.0m;
        //    }

        //    //Marzo
        //    if (e.NewValues["cantMarzo"] != e.OldValues["cantMarzo"])
        //    {
        //        Decimal enero = e.NewValues["cantMarzo"] != null ? Convert.ToDecimal(e.NewValues["cantMarzo"]) : 0.0m;
        //    }

        //    //Abril
        //    if (e.NewValues["cantAbril"] != e.OldValues["cantAbril"])
        //    {
        //        Decimal enero = e.NewValues["cantAbril"] != null ? Convert.ToDecimal(e.NewValues["cantAbril"]) : 0.0m;
        //    }

        //    //Mayo
        //    if (e.NewValues["cantMayo"] != e.OldValues["cantMayo"])
        //    {
        //        Decimal enero = e.NewValues["cantMayo"] != null ? Convert.ToDecimal(e.NewValues["cantMayo"]) : 0.0m;
        //    }

        //    //Junio
        //    if (e.NewValues["cantJunio"] != e.OldValues["cantJunio"])
        //    {
        //        Decimal enero = e.NewValues["cantJunio"] != null ? Convert.ToDecimal(e.NewValues["cantJunio"]) : 0.0m;
        //    }

        //    //Julio
        //    if (e.NewValues["cantJulio"] != e.OldValues["cantJulio"])
        //    {
        //        Decimal enero = e.NewValues["cantJulio"] != null ? Convert.ToDecimal(e.NewValues["cantJulio"]) : 0.0m;
        //    }

        //    //Agosto
        //    if (e.NewValues["cantAgosto"] != e.OldValues["cantAgosto"])
        //    {
        //        Decimal enero = e.NewValues["cantAgosto"] != null ? Convert.ToDecimal(e.NewValues["cantAgosto"]) : 0.0m;
        //    }
        //    //Setiembre
        //    if (e.NewValues["cantSetiembre"] != e.OldValues["cantSetiembre"])
        //    {
        //        Decimal enero = e.NewValues["cantSetiembre"] != null ? Convert.ToDecimal(e.NewValues["cantSetiembre"]) : 0.0m;
        //    }
        //    //Octubre
        //    if (e.NewValues["cantOctubre"] != e.OldValues["cantOctubre"])
        //    {
        //        Decimal enero = e.NewValues["cantOctubre"] != null ? Convert.ToDecimal(e.NewValues["cantOctubre"]) : 0.0m;
        //    }
        //    //Noviembre
        //    if (e.NewValues["cantNoviembre"] != e.OldValues["cantNoviembre"])
        //    {
        //        Decimal enero = e.NewValues["cantNoviembre"] != null ? Convert.ToDecimal(e.NewValues["cantNoviembre"]) : 0.0m;
        //    }
        //    //Diciembre
        //    if (e.NewValues["cantDiciembre"] != e.OldValues["cantDiciembre"])
        //    {
        //        Decimal enero = e.NewValues["cantDiciembre"] != null ? Convert.ToDecimal(e.NewValues["cantDiciembre"]) : 0.0m;
        //    }

        //    e.Cancel = true;
        //    grid.CancelEdit();
        //}

        //protected void grvReqDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        //{
        //    //Validación de enero
        //    decimal enero = e.NewValues["cantEnero"] != null ? (decimal)e.NewValues["cantEnero"] : 0;
        //    if (enero < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantEnero"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de febrero
        //    decimal febrero = e.NewValues["cantFebrero"] != null ? (decimal)e.NewValues["cantFebrero"] : 0;
        //    if (febrero < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantFebrero"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de marzo
        //    decimal marzo = e.NewValues["cantMarzo"] != null ? (decimal)e.NewValues["cantMarzo"] : 0;
        //    if (marzo < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantMarzo"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de abril
        //    decimal abril = e.NewValues["cantAbril"] != null ? (decimal)e.NewValues["cantAbril"] : 0;
        //    if (abril < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantAbril"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de mayo
        //    decimal mayo = e.NewValues["cantMayo"] != null ? (decimal)e.NewValues["cantMayo"] : 0;
        //    if (mayo < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantMayo"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de junio
        //    decimal junio = e.NewValues["cantJunio"] != null ? (decimal)e.NewValues["cantJunio"] : 0;
        //    if (junio < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantJunio"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de julio
        //    decimal julio = e.NewValues["cantJulio"] != null ? (decimal)e.NewValues["cantJulio"] : 0;
        //    if (julio < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantJulio"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de agosto
        //    decimal agosto = e.NewValues["cantAgosto"] != null ? (decimal)e.NewValues["cantAgosto"] : 0;
        //    if (agosto < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantAgosto"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de setiembre
        //    decimal setiembre = e.NewValues["cantSetiembre"] != null ? (decimal)e.NewValues["cantSetiembre"] : 0;
        //    if (setiembre < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantSetiembre"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de octubre
        //    decimal octubre = e.NewValues["cantOctubre"] != null ? (decimal)e.NewValues["cantOctubre"] : 0;
        //    if (octubre < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantOctubre"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de noviembre
        //    decimal noviembre = e.NewValues["cantNoviembre"] != null ? (decimal)e.NewValues["cantNoviembre"] : 0;
        //    if (noviembre < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantNoviembre"], "La cantidad debe ser mayor o igual a cero");
        //    }

        //    //Validación de diciembre
        //    decimal diciembre = e.NewValues["cantDiciembre"] != null ? (decimal)e.NewValues["cantDiciembre"] : 0;
        //    if (diciembre < 0)
        //    {
        //        AddError(e.Errors, grvPacDet.Columns["cantDiciembre"], "La cantidad debe ser mayor o igual a cero");
        //    }
        //}

        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void grvReqDet_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvSubPreDet.IsNewRowEditing)
            {
                grvSubPreDet.DoRowValidation();
            }
        }

        protected void detailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            if (detailGrid != null)
            {
                int id = (int)detailGrid.GetMasterRowKeyValue();

                SubPresupuestoAreaPres result = grvSubPreDet.GetRow(grvSubPreDet.FindVisibleIndexByKeyValue(id)) as SubPresupuestoAreaPres;

                if (result != null)
                    if (result.SubPresupuestoAreaDetallePres != null)
                        detailGrid.DataSource = result.SubPresupuestoAreaDetallePres;
            }
        }
        protected void grid_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(SubPresupuestoAreaPres));
        }
    }
}