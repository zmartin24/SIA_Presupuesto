<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="frmRequerimientoBienServicioOriginal.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.frmRequerimientoBienServicio" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        main-element-selector nested-content-selector {
            color: initial;
        }
        .alignValue input {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:BootstrapCallbackPanel ID="cpPrincipal" runat="server" Width="100%" ClientInstanceName="cpPrincipal" OnCallback="cpPrincipal_Callback">
        <ClientSideEvents EndCallback="Presupuesto.CpPrincipal_EndCallback" />
        <ContentCollection>
            <dx:ContentControl runat="server">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="row x_title">
                                <h2> REQUERIMIENTOS DE BIENES Y SERVICIOS <small><dx:ASPxLabel ID="lblDescripcion" runat="server" Text="[Descripcion]"></dx:ASPxLabel></small></h2>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            <div class="x_content">
                                <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevo" Text="Nuevo">
                                    <CssClasses Control="btn btn-primary" Icon="fa fa-plus-circle" />
                                <ClientSideEvents Click="Presupuesto.BotonNuevoRequerimientoDet_Click" />
                                </dx:BootstrapButton>
                                <dx:BootstrapButton ID="btnEditar" runat="server" AutoPostBack="False" ClientInstanceName="btnEditar" Text="Editar">
                                    <CssClasses Control="btn btn-success" Icon="fa fa-edit" />
                                <ClientSideEvents Click="Presupuesto.BotonEditarRequerimientoDet_Click" />
                                </dx:BootstrapButton>
                                <dx:BootstrapButton ID="btnAnular" runat="server" AutoPostBack="False" ClientInstanceName="btnAnular" Text="Anular">
                                    <CssClasses Control="btn btn-danger" Icon="fa fa-remove" />
                                <ClientSideEvents Click="Presupuesto.BotonAnularRequerimientoDet_Click" />
                                </dx:BootstrapButton>
                                <dx:BootstrapButton ID="btnImprimir" runat="server" ClientInstanceName="btnImprimir" Text="Imprimir Det." ToolTip="Imprimir Detalle" AutoPostBack="False">
                                    <CssClasses Control="btn btn-info" Icon="fa fa-print"  />
                                    <ClientSideEvents Click="Presupuesto.BotonImprimirRequerimientoDetMen_Click" />
                                </dx:BootstrapButton>
                                <dx:BootstrapButton ID="btnSalir" runat="server" ClientInstanceName="btnSalir" Text="Salir" AutoPostBack="False">
                                    <CssClasses Control="btn btn-primary" Icon="fa fa-reply"/>
                                    <ClientSideEvents Click="Presupuesto.BotonSalirRequerimientoDet_Click" />
                                </dx:BootstrapButton>
                                
                            </div>

                            <div class="row">
                                <div class="x_content">
                                    <%--<div class="table-responsive"> --%><%--class="card-box table-responsive"--%>
                                        <dx:BootstrapGridView ID="grvReqDet" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvReqDet" KeyFieldName="idReqBieSerDet" EnableRowsCache="False" Width="100%" 
                                                OnRowUpdating="grvReqDet_RowUpdating" OnRowValidating="grvReqDet_RowValidating" OnStartRowEditing="grvReqDet_StartRowEditing"
                                                OnCustomCallback="grvReqDet_CustomCallback" OnCellEditorInitialize="grvReqDet_CellEditorInitialize" OnBatchUpdate="grvReqDet_BatchUpdate">
                                            <%--<CssClasses Table="table table-striped table-bordered dt-responsive nowrap" />--%>
                                            <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell">
                                                <BatchEditSettings StartEditAction="DblClick" />
                                            </SettingsEditing>
                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" ShowFooter="True" VerticalScrollableHeight="535" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto"/>
                                            <SettingsBehavior AllowClientEventsOnLoad="False"  AllowSelectByRowClick="True" />
                                            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="True" />
                                            <CssClasses FixedColumn="bg-light text-body" />
                                            <Columns>
                                                <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" VisibleIndex="0" Width="5%" GroupIndex="0" SortIndex="0" SortOrder="Ascending" ReadOnly="True">
                                                    <Settings AutoFilterCondition="BeginsWith" />
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1" Width="350px" ReadOnly="True" Fixed="true">
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="UM" FieldName="Abreviado" VisibleIndex="2" Width="70px" ReadOnly="True" Fixed="true">
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" VisibleIndex="3" Width="90px" ReadOnly="True" Fixed="true">
                                                    <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:BootstrapGridViewTextColumn>
                                                 <dx:BootstrapGridViewTextColumn Caption="Cant." FieldName="cantidad" VisibleIndex="16" Width="70px" ReadOnly="True" Fixed="true">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Subtotal" FieldName="subtotal" VisibleIndex="17" Width="100px" ReadOnly="True" Fixed="true">
                                                    <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Ene." FieldName="cantEnero"  VisibleIndex="4" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Feb." FieldName="cantFebrero"  VisibleIndex="5" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Mar." FieldName="cantMarzo"  VisibleIndex="6" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Abr." FieldName="cantAbril"  VisibleIndex="7" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. May." FieldName="cantMayo"  VisibleIndex="8" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Jun." FieldName="cantJunio"  VisibleIndex="9" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Jul." FieldName="cantJulio"  VisibleIndex="10" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Ago." FieldName="cantAgosto"  VisibleIndex="11" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Set." FieldName="cantSetiembre"  VisibleIndex="12" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Oct." FieldName="cantOctubre" VisibleIndex="13" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Nov." FieldName="cantNoviembre"  VisibleIndex="14" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                                <dx:BootstrapGridViewSpinEditColumn Caption="Cant. Dic." FieldName="cantDiciembre"  VisibleIndex="15" Width="80px">
                                                    <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                </dx:BootstrapGridViewSpinEditColumn>
                                               
                                                <%--<dx:BootstrapGridViewTextColumn Caption="Justificación" FieldName="justificacion" VisibleIndex="18" Width="5%" ReadOnly="True">
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:BootstrapGridViewTextColumn>--%>
                                                <%--<dx:BootstrapGridViewDataColumn Caption="Just.">
                                                    <DataItemTemplate>
                                                        <button type="button" class="btn btn-link more-info" data-key="<%# Container.KeyValue %>">Ver Justifi...</button>
                                                    </DataItemTemplate>
                                                </dx:BootstrapGridViewDataColumn>--%>
                                            </Columns>
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="subtotal" DisplayFormat="T. = {0:n2} " SummaryType="Sum" />
                                            </TotalSummary>
                                            <SettingsPager NumericButtonCount="6"></SettingsPager>
                                            <ClientSideEvents SelectionChanged="Presupuesto.GrvReqDet_OnGridSelectionChanged" />
                                            <%--<ClientSideEvents BatchEditEndEditing="Presupuesto.GrvDetalle_BachEditEndEditing" />--%>
                                            <SettingsPager PageSize="20" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                            </SettingsPager>
                                            <%--<SettingsPager PageSize="20" NumericButtonCount="6">
                                                <Summary Visible="false" />
                                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                            </SettingsPager>--%>
                                        </dx:BootstrapGridView>
                                        <%--<dx:ASPxCallback runat="server" ID="Callback1" ClientInstanceName="callback1" OnCallback="Callback1_Callback"></dx:ASPxCallback>--%>
                                   <%-- </div>--%>
                                </div>
                            </div>
                         
                            <dx:BootstrapPopupControl ID="popReqDet" runat="server" Width="300px" ClientInstanceName="popReqDet"  CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReqDet_Callback">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <div class="modal-dialog modal-lg">
                                                    <div class="modal-body">
                                                        
                                                        <dx:ASPxCallback ID="clbUnidad" runat="server" ClientInstanceName="clbUnidad" OnCallback="clbUnidad_Callback">
                                                            <ClientSideEvents CallbackComplete="Presupuesto.ClbUnidad_CallbackComplete" />
                                                        </dx:ASPxCallback>

                                                        <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" LayoutType="Vertical" >
                                                            <Items>
                                                                <dx:BootstrapLayoutItem Caption="Cuenta" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbCuenta" runat="server" ClientInstanceName="cbCuenta"  
                                                                                ValueField="idCueCon" Width="100%" TextFormatString="{0} - {1}">
                                                                                <Fields>
                                                                                    <dx:BootstrapListBoxField FieldName="numCuenta" />
                                                                                    <dx:BootstrapListBoxField FieldName="descripcion" />
                                                                                </Fields>
                                                                                <ValidationSettings SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbCuenta_SelectedIndexChanged" />
                                                                                
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Descripción" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <table class="fullWidthTable" style="width:100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:BootstrapMemo ID="txtDescripcion" runat="server" ClientInstanceName="txtDescripcion">
                                                                                            <ValidationSettings SetFocusOnError="True">
                                                                                                <RequiredField IsRequired="True" />
                                                                                            </ValidationSettings>
                                                                                        </dx:BootstrapMemo>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                        <dx:BootstrapButton ID="btnAyuda" runat="server" Text="..." AutoPostBack="False">
                                                                                            <ClientSideEvents Click="Presupuesto.BotonAyudaRequerimientoDet_Click" />
                                                                                        </dx:BootstrapButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Unidad" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbUnidad" runat="server"  TextField="nomUnidad" ValueField="idUnidad" ClientInstanceName="cbUnidad" Width="100%" TextFormatString="{0}">
                                                                                <ValidationSettings SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Precio">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <table class="fullWidthTable" style="width:100%">
                                                                                <tr>
                                                                                    <td style="">
                                                                                        <dx:BootstrapSpinEdit ID="sePrecio" runat="server" ClientInstanceName="sePrecio" Width="100%" DisplayFormatString="n2">
                                                                                            <ValidationSettings  SetFocusOnError="True">
                                                                                                <RequiredField IsRequired="True" />
                                                                                            </ValidationSettings>
                                                                                            <CssClasses Control="alignValue" />
                                                                                        </dx:BootstrapSpinEdit>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                        <dx:BootstrapButton ID="btnAyudaPrecio" runat="server" Text="..." AutoPostBack="False">
                                                                                            <ClientSideEvents Click="Presupuesto.BotonAyudaPrecio_Click" />
                                                                                        </dx:BootstrapButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Justificación" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12" >
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapMemo ID="txtJustificacion" runat="server" ClientInstanceName="txtJustificacion" Width="100%">
                                                                                <ValidationSettings SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapMemo>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                            </Items>
                                                        </dx:BootstrapFormLayout>
                                                        
                                                    </div>
                                                    <div class="modal-footer">
                                                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="False" ClientInstanceName="btnCancelar" Text="Cancelar">
                                                            <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonCancelarRequerimientoDet_Click" />
                                                        </dx:BootstrapButton>
                                                        <dx:BootstrapButton ID="btnGrabar" runat="server" AutoPostBack="False" ClientInstanceName="btnGrabar" Text="Grabar">
                                                                <CssClasses Control="btn btn-primary" Icon="fa fa-save"></CssClasses>
                                                                <ClientSideEvents Click="Presupuesto.BotonGuardarRequerimientoDet_Click" />
                                                        </dx:BootstrapButton>
                                                    </div>
                                                    </div>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                            </dx:BootstrapPopupControl>

                            <dx:BootstrapPopupControl ID="popAyudaProducto" runat="server" Width="580px" ClientInstanceName="popAyudaProducto"  CloseAction="CloseButton" 
                                CloseAnimationType="Fade" CloseOnEscape="True" Modal="True"  HeaderText="Seleccionar Producto"
                                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Height="500px">
                                <ClientSideEvents Shown="Presupuesto.PopAyudaProducto_Shown" />
                                    <ContentCollection>
                                        <dx:ContentControl runat="server">
                                            <div class="modal-dialog modal-md">
                                                <div class="modal-body">
                                                    <dx:BootstrapCallbackPanel ID="capProducto" runat="server" Width="560px" OnCallback="capProducto_Callback" ClientInstanceName="capProducto">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                <div class="table-responsive">
                                                                    <dx:BootstrapGridView ID="grvProducto" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvProducto" OnDataBinding="grvProducto_DataBinding" KeyFieldName="idProducto" Width="550px">
                                                                        <ClientSideEvents RowDblClick="Presupuesto.GrvProducto_RowDblClick" />
                                                                        <SettingsPager AlwaysShowPager="True" PageSize="12" EnableAdaptivity="True">
                                                                        </SettingsPager>
                                                                        <SettingsBootstrap Striped="True" />
                                                                        <Settings ShowFilterRow="True"/>
                                                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" />
                                                                        <Columns>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="Descripcion" ReadOnly="True" VisibleIndex="0" Width="550px">
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                        </Columns>
                                                                    </dx:BootstrapGridView>
                                                                </div>
                                                                </dx:ContentControl>

                                                        </ContentCollection>
                                                
                                                    </dx:BootstrapCallbackPanel>
                                                    </div>
                                            </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                </dx:BootstrapPopupControl>
                            
                            <dx:BootstrapPopupControl ID="popAyudaPrecio" runat="server" Width="700px" ClientInstanceName="popAyudaPrecio"  CloseAction="CloseButton" 
                            CloseAnimationType="Fade" CloseOnEscape="True" Modal="True"  HeaderText="Seleccionar Precio" PopupAnimationType="Fade"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="true" Height="500px" OnCallback="popAyudaPrecio_WindowCallback">
                            <ClientSideEvents Shown="Presupuesto.PopAyudaPrecio_Shown" />
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <%--<div class="modal-dialog modal-md">--%>
                                            <div class="modal-body">
                                                <dx:BootstrapFormLayout ID="ASPxFormLayout3" runat="server">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanMd="4" >
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-6 col-xs-6">
                                                                    <dx:BootstrapComboBox ID="cbAnio" runat="server" ClientInstanceName="cbAnio" TextField="nombre" ValueField="indice">
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioAyudaPrecio_SelectedIndexChanged" />
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>

                                                <dx:BootstrapCallbackPanel ID="capPrecio" runat="server" Width="690px" OnCallback="capPrecio_Callback" ClientInstanceName="capPrecio">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                            <div class="table-responsive">
                                                                <dx:BootstrapGridView ID="grvPrecio" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvPrecio" OnCustomCallback="grvPrecio_CustomCallback" OnDataBinding="grvPrecio_DataBinding" KeyFieldName="fechaPrecio" Width="100%">
                                                                    <ClientSideEvents RowDblClick="Presupuesto.GrvPrecio_RowDblClick" />
                                                                    <SettingsPager AlwaysShowPager="True" PageSize="10" EnableAdaptivity="True">
                                                                    </SettingsPager>
                                                                    <SettingsBootstrap Striped="True" />
                                                                    <Settings ShowFilterRow="True"/>
                                                                    <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" />
                                                                    <Columns>
                                                                        <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" ReadOnly="True" VisibleIndex="0" Width="320px">
                                                                            <Settings AutoFilterCondition="Contains" />
                                                                        </dx:BootstrapGridViewTextColumn>
                                                                        <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" ReadOnly="True" VisibleIndex="0" Width="50px">
                                                                            <Settings AutoFilterCondition="Contains" />
                                                                        </dx:BootstrapGridViewTextColumn>
                                                                        <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" ReadOnly="True" VisibleIndex="0" Width="80px">
                                                                            <Settings AutoFilterCondition="Contains" />
                                                                            <PropertiesTextEdit DisplayFormatString="n2">
                                                                            </PropertiesTextEdit>
                                                                        </dx:BootstrapGridViewTextColumn>
                                                                        <dx:BootstrapGridViewTextColumn Caption="Presupuesto" FieldName="desPresupuesto" ReadOnly="True" VisibleIndex="0" Width="240px">
                                                                            <Settings AutoFilterCondition="Contains" />
                                                                        </dx:BootstrapGridViewTextColumn>
                                                                    
                                                                    </Columns>
                                                                </dx:BootstrapGridView>
                                                            </div>
                                                            </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapCallbackPanel>
                                            </div>
                                        <%--</div>--%>
                                        </dx:ContentControl>
                                    </ContentCollection>
                            </dx:BootstrapPopupControl> 
                        </div>
                    </div>
                </div>        
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
