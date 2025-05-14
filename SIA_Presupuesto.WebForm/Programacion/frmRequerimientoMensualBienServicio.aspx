<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="frmRequerimientoMensualBienServicio.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.frmRequerimientoMensualBienServicio" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnFileUploadComplete(s, e) {
            grvDetalleRequerimientoMigra.PerformCallback();
        }
    </script>
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
                                <h2> Detalles de Requerimiento Mensual de Bienes y Servicios <small><dx:ASPxLabel ID="lblDescripcion" runat="server" Text="[Descripcion]"></dx:ASPxLabel></small></h2>
                                <div class="row invoice-info">
                                    <div class="col-sm-4 invoice-col">
                                        Tipo Cambio:
                                        <address>
                                            <strong><dx:ASPxLabel ID="lblTipoCambio" runat="server" Text="[Tipo Cambio]"></dx:ASPxLabel></strong>
                                      </address>
                                    </div>
                                </div>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            <div class="x_content">
                                <div class="col-sm-10 p-3">
                                    <div class="left">
                                        <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevo" Text="Nuevo" Width="110">
                                            <CssClasses Control="btn btn-primary" Icon="fa fa-plus-circle" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonNuevoRequerimientoMensualDetalle_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnEditar" runat="server" AutoPostBack="False" ClientInstanceName="btnEditar" Text="Editar" Width="110">
                                            <CssClasses Control="btn btn-success" Icon="fa fa-edit" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonEditarRequerimientoMensualDetalle_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnAnular" runat="server" AutoPostBack="False" ClientInstanceName="btnAnular" Text="Anular" Width="110">
                                            <CssClasses Control="btn btn-danger" Icon="fa fa-remove" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonAnularRequerimientoMensualDetalle_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImportar" runat="server" AutoPostBack="False" ClientInstanceName="btnImportar" Text="Importar" Width="110">
                                            <ClientSideEvents Click="function(s, e) { 
                                                if (cpPrincipal.cpEstadoReqMen == '10')
                                                    alert('No puedes importar, requerimiento ya se ecuentra aprobado');
                                                else if(cpPrincipal.cpEstadoReqMen == '59')
                                                    alert('No puedes importar, requerimiento ya se ecuentra presupuestado');
                                                else popImportar.Show(); 
                                            }" />
                                            <CssClasses Control="btn btn-info" Icon="fa fa-cloud-upload" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnSalir" runat="server" ClientInstanceName="btnSalir" Text="Salir" AutoPostBack="False" Width="110">
                                            <CssClasses Control="btn btn-dark" Icon="fa fa-reply"/>
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonSalirRequerimientoMensualDet_Click" />
                                        </dx:BootstrapButton>
                                    </div>
                                </div>
                                <div class="col-2 p-3 mb-1">
                                    <div class="right">
                                        <dx:BootstrapButton runat="server" Text="Formato Migra." AutoPostBack="false" ToolTip="Descargar formato de migración">
                                            <ClientSideEvents Click="function(s, e) { location.href = '../Documento/FormatoMigraReqBienSerMensual.xlsx'; }" />
                                            <CssClasses Icon="fa fa-download" />
                                            <SettingsBootstrap RenderOption="Link" Sizing="Small" />
                                        </dx:BootstrapButton>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="x_content">
                                    <dx:BootstrapGridView ID="grvReqMenDet" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvReqMenDet" KeyFieldName="idReqMenDet" EnableRowsCache="False" Width="100%" 
                                            OnRowUpdating="grvReqMenDet_RowUpdating" OnRowValidating="grvReqMenDet_RowValidating" OnStartRowEditing="grvReqMenDet_StartRowEditing"
                                            OnCustomCallback="grvReqMenDet_CustomCallback" OnCellEditorInitialize="grvReqMenDet_CellEditorInitialize" OnBatchUpdate="grvReqMenDet_BatchUpdate">
                                        <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell">
                                            <BatchEditSettings StartEditAction="DblClick"  EditMode="Cell" KeepChangesOnCallbacks="False"/>
                                        </SettingsEditing>
                                        <ClientSideEvents BatchEditEndEditing="Presupuesto.GrvReqMenDet_BachEditEndEditing" EndCallback="Presupuesto.GrvReqMenDet_EndCallback" />
                                        <SettingsSearchPanel Visible="true" ShowApplyButton="true" ShowClearButton="true" />
                                        <SettingsText SearchPanelEditorNullText="Ingrese texto para buscar ..." />
                                        <SettingsCommandButton SearchPanelApplyButton-Text="Buscar" SearchPanelClearButton-Text="Limpiar"/>
                                        <Settings ShowHeaderFilterButton="True" ShowFooter="True" ShowStatusBar="Hidden" /><%--VerticalScrollableHeight="535" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto"--%>
                                        <SettingsBehavior AllowClientEventsOnLoad="False"  AllowSelectByRowClick="True" />
                                        <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                            
                                        <CssClasses FixedColumn="bg-light text-body" />
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" VisibleIndex="0" Width="5%" GroupIndex="0" SortIndex="0" SortOrder="Ascending" ReadOnly="True">
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Item" FieldName="item"  VisibleIndex="1" Width="40px">
                                                <PropertiesSpinEdit DisplayFormatString="n0" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="2" Width="450px" ReadOnly="True" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" VisibleIndex="3" Width="50px" ReadOnly="True" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" VisibleIndex="4" Width="90px" ReadOnly="True" AdaptivePriority="1">
                                                <PropertiesTextEdit DisplayFormatString="n"></PropertiesTextEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Cant." FieldName="cantidad"  VisibleIndex="5" Width="95px" AdaptivePriority="1">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom" MinValue="0" MaxValue="100000">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Cant. Pres." FieldName="cantPresupuestada" VisibleIndex="6" Width="95px" ReadOnly="True" AdaptivePriority="1">
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Importe" FieldName="importe" VisibleIndex="7" Width="100px" ReadOnly="True" AdaptivePriority="2">
                                                <PropertiesTextEdit DisplayFormatString="n"></PropertiesTextEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Justificación" FieldName="justificacion" VisibleIndex="8" Width="20%" ReadOnly="True" AdaptivePriority="2">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <GroupSummary>
                                            <dx:ASPxSummaryItem FieldName="importe" DisplayFormat="c2" SummaryType="Sum" ShowInGroupFooterColumn="importe"/>
                                        </GroupSummary>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="importe" DisplayFormat="c2" SummaryType="Sum" />
                                        </TotalSummary>
                                        <SettingsPager NumericButtonCount="6"></SettingsPager>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvReqMenDet_OnGridSelectionChanged" />
                                        
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>
                                </div>
                            </div>
                         
                            <dx:BootstrapPopupControl ID="popReqDet" runat="server" Width="800px" ClientInstanceName="popReqDet" CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReqDet_Callback">
                                <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" HorizontalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="800px" MinWidth="300px" />
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapFormLayout ID="frmDetalle" ClientInstanceName="frmDetalle" runat="server" LayoutType="Vertical" >
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Tipo" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:ASPxLabel ID="lblTipo" runat="server" Text="[Tipo]"></dx:ASPxLabel>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Con partida (bien/servicio)" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapCheckBox ID="chkConPartida"  runat="server" ClientInstanceName="chkConPartida" Text="" Checked="true">
                                                                <ClientSideEvents CheckedChanged="Presupuesto.ChkConPartidaReqMen_CheckedChanged"/>
                                                            </dx:BootstrapCheckBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Name="bliPartida" FieldName="bliPartida" Caption="Seleccionar Partida" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <dx:BootstrapButtonEdit ID="btnSelecPartida" runat="server" ClientInstanceName="btnSelecPartida" NullText="Seleccione partida" ReadOnly="true">
                                                                <ValidationSettings ValidationGroup="Validation" SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                                <ClientSideEvents ButtonClick="Presupuesto.BotonAyudaPartidaPrecio_Click" />
                                                                <Buttons>
                                                                    <dx:BootstrapEditButton/>
                                                                </Buttons>
                                                            </dx:BootstrapButtonEdit>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                
                                                <dx:BootstrapLayoutItem Name="bliProducto" FieldName="bliProducto" Caption="Seleccionar Producto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <dx:BootstrapButtonEdit ID="btnSelecProducto" runat="server" ClientInstanceName="btnSelecProducto" NullText="Seleccione producto" ReadOnly="true">
                                                                <ValidationSettings ValidationGroup="Validation" SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                                <ClientSideEvents ButtonClick="Presupuesto.BotonAyudaProductoPrecio_Click" />
                                                                <Buttons>
                                                                    <dx:BootstrapEditButton/>
                                                                </Buttons>
                                                            </dx:BootstrapButtonEdit>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Cuenta" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:ASPxLabel ID="lblCuenta" ClientInstanceName="lblCuenta" runat="server" Text="[Cuenta]"></dx:ASPxLabel>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Unidad" ColSpanLg="3" ColSpanMd="3" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapComboBox ID="cbUnidad" runat="server"  TextField="nomUnidad" ValueField="idUnidad" ClientInstanceName="cbUnidad" Width="100%" TextFormatString="{0}">
                                                                <ValidationSettings ValidationGroup="Validation" SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:BootstrapComboBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Precio" ColSpanLg="3" ColSpanMd="3" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapSpinEdit ID="sePrecio" runat="server" ClientInstanceName="sePrecio" Width="100%" DisplayFormatString="c2" MinValue="0" MaxValue="9999999">
                                                                <ValidationSettings ValidationGroup="Validation"  SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                                <ClientSideEvents KeyPress="Presupuesto.SePrecioReqDet_KeyPress" NumberChanged="Presupuesto.SePrecioReqDet_NumberChanged"/>
                                                                <CssClasses Control="alignValue" />
                                                            </dx:BootstrapSpinEdit>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Cantidad" ColSpanLg="3" ColSpanMd="3" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapSpinEdit ID="seCantidad" runat="server" ClientInstanceName="seCantidad" Width="100%" DisplayFormatString="n" NumberFormat="Custom" MinValue="0" MaxValue="1000000">
                                                                <ValidationSettings ValidationGroup="Validation"  SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                                <ClientSideEvents KeyPress="Presupuesto.SeCantidadReqMen_KeyPress" NumberChanged="Presupuesto.SeCantidadReqMen_NumberChanged"/>
                                                                <CssClasses Control="alignValue" />
                                                            </dx:BootstrapSpinEdit>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Subtotal" ColSpanLg="3" ColSpanMd="3" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapSpinEdit ID="seSubtotal" runat="server" ClientInstanceName="seSubtotal" Width="100%" DisplayFormatString="c2" ReadOnly="true">
                                                                <CssClasses Control="alignValue"/>
                                                            </dx:BootstrapSpinEdit>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                
                                                <dx:BootstrapLayoutItem Caption="Descripción" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapMemo ID="txtDescripcion" runat="server" ClientInstanceName="txtDescripcion">
                                                                <ValidationSettings ValidationGroup="Validation" SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:BootstrapMemo>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                        
                                                <dx:BootstrapLayoutItem Caption="Justificación" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12" >
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapMemo ID="txtJustificacion" runat="server" ClientInstanceName="txtJustificacion" Width="100%" MaxLength="1000">
                                                                <ValidationSettings ValidationGroup="Validation" SetFocusOnError="True">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:BootstrapMemo>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                            </Items>
                                        </dx:BootstrapFormLayout>
                                    </dx:ContentControl>
                                </ContentCollection>
                                <FooterTemplate>
                                    <dx:BootstrapButton ID="btnGrabar" runat="server" AutoPostBack="False" ClientInstanceName="btnGrabar" Text="Grabar">
                                        <CssClasses Control="btn btn-primary" Icon="fa fa-save"></CssClasses>
                                        <ClientSideEvents Click="Presupuesto.BotonGuardarRequerimientoMenDet_Click" />
                                        <SettingsBootstrap Sizing="Small" />
                                    </dx:BootstrapButton>
                                    <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="False" ClientInstanceName="btnCancelar" Text="Cancelar">
                                        <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                        <ClientSideEvents Click="Presupuesto.BotonCancelarRequerimientoDet_Click" />
                                        <SettingsBootstrap Sizing="Small" />
                                    </dx:BootstrapButton>
                                </FooterTemplate>
                            </dx:BootstrapPopupControl>

                            <dx:BootstrapPopupControl ID="popAyudaPartidaPrecio" runat="server" ClientInstanceName="popAyudaPartidaPrecio" Width="700px" CloseAction="CloseButton" 
                                CloseAnimationType="Fade" CloseOnEscape="True" Modal="True"  HeaderText="Seleccionar Partida" PopupAnimationType="Fade"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="true" Height="400px" OnCallback="popAyudaPartidaPrecio_WindowCallback">
                                <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" HorizontalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                <ClientSideEvents Shown="Presupuesto.PopAyudaPartidaPrecioReqMen_Shown" />
                                
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapCallbackPanel ID="capPartidaPrecio" runat="server" ClientInstanceName="capPartidaPrecio" Width="100%" >
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <dx:BootstrapFormLayout ID="frmPartidaPrecio" runat="server" LayoutType="Vertical" >
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Buscar Partida" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl><dx:BootstrapTextBox ID="txtBuscarPartida" runat="server" ClientInstanceName="txtBuscarPartida" NullText="Ingrese descripción">
                                                                        <%--<ClientSideEvents KeyPress="Presupuesto.TxtBuscarPartida_onTextChanged" />--%>
                                                                    </dx:BootstrapTextBox></dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Lista Partida" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapGridView ID="grvPartidaPrecio" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvPartidaPrecio" KeyFieldName="idParPre" OnCustomCallback="grvPartidaPrecio_CustomCallback" OnDataBinding="grvPartidaPrecio_DataBinding"  Width="100%">
                                                                            <ClientSideEvents RowDblClick="Presupuesto.GrvPartidaPrecioReqDet_RowDblClick" />
                                                                            <SettingsPager AlwaysShowPager="True" PageSize="10" EnableAdaptivity="True">
                                                                            </SettingsPager>
                                                                            <Settings ShowFooter="true" />
                                                                            <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" />
                                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                                            <SettingsBootstrap Sizing="Small" Striped="True" />
                                                                            <SettingsSearchPanel CustomEditorID="txtBuscarPartida"/>
                                                                            <CssClasses Row="grid-nowrap-row" Control="grid-borderless" />
                                                                            <Columns>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" ReadOnly="True" VisibleIndex="0" Width="240px" AdaptivePriority="1">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" ReadOnly="True" VisibleIndex="1" Width="70px" AdaptivePriority="1">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" ReadOnly="True" VisibleIndex="2" Width="80px" HorizontalAlign="Right" AdaptivePriority="1">
                                                                                    <PropertiesTextEdit DisplayFormatString="c2">
                                                                                    </PropertiesTextEdit>
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" ReadOnly="True" VisibleIndex="3" Width="70px" AdaptivePriority="2">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Codigo" FieldName="idParPre" ReadOnly="True" VisibleIndex="4" Visible="false">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Cod. Unidad" FieldName="idUnidad" ReadOnly="True" VisibleIndex="5" Visible="false">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Cod. Cuenta" FieldName="idCueCon" ReadOnly="True" VisibleIndex="6" Visible="false">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                            </Columns>
                                                                        </dx:BootstrapGridView>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapFormLayout>
                                                    
                                                    
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:BootstrapCallbackPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapPopupControl>
                            
                            <dx:BootstrapPopupControl ID="popAyudaProductoPrecio" runat="server" ClientInstanceName="popAyudaProductoPrecio" Width="700px" CloseAction="CloseButton" 
                                CloseAnimationType="Fade" CloseOnEscape="True" Modal="True"  HeaderText="Seleccionar Producto" PopupAnimationType="Fade"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="true" Height="400px" OnCallback="popAyudaProductoPrecio_WindowCallback">
                                <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" HorizontalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                <ClientSideEvents Shown="Presupuesto.PopAyudaProductoPrecio_Shown" />
                                
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapCallbackPanel ID="capProductoPrecio" runat="server" ClientInstanceName="capProductoPrecio" Width="100%" >
                                            <%--OnCallback="capCargo_Callback"--%>
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <dx:BootstrapFormLayout ID="frmAyudaProductoPrecio" runat="server" LayoutType="Vertical" >
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Buscar Producto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl><dx:BootstrapTextBox ID="txtBuscarProducto" runat="server" ClientInstanceName="txtBuscarProducto" NullText="Ingrese descripción">
                                                                        <%--<ClientSideEvents  KeyPress="Presupuesto.TxtBuscarProducto_onTextChanged" TextChanged="Presupuesto.TxtBuscarProducto_onTextChanged" ValueChanged="Presupuesto.TxtBuscarProducto_onTextChanged" />--%>
                                                                    </dx:BootstrapTextBox></dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Lista Producto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapGridView ID="grvProductoPrecio" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvProductoPrecio" KeyFieldName="idProducto" OnCustomCallback="grvProductoPrecio_CustomCallback" OnDataBinding="grvProductoPrecio_DataBinding"  Width="100%">
                                                                            <ClientSideEvents RowDblClick="Presupuesto.GrvProductoPrecioReqDet_RowDblClick" />
                                                                            <SettingsPager AlwaysShowPager="True" PageSize="10" EnableAdaptivity="True">
                                                                            </SettingsPager>
                                                                            <Settings ShowHeaderFilterButton="true" ShowFooter="true" />
                                                                            <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" />
                                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                                            <SettingsBootstrap Sizing="Small" Striped="True" />
                                                                            <SettingsSearchPanel CustomEditorID="txtBuscarProducto"/>
                                                                            <CssClasses Row="grid-nowrap-row" Control="grid-borderless" />
                                                                            <Columns>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" ReadOnly="True" VisibleIndex="0" Width="240px" AdaptivePriority="1">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" ReadOnly="True" VisibleIndex="1" Width="70px" AdaptivePriority="1">
                                                                                    <Settings AllowHeaderFilter="False" />
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" ReadOnly="True" VisibleIndex="2" Width="80px" HorizontalAlign="Right" AdaptivePriority="1">
                                                                                    <Settings AllowHeaderFilter="False" />
                                                                                    <PropertiesTextEdit DisplayFormatString="c2">
                                                                                    </PropertiesTextEdit>
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Año" FieldName="anioPrecio" ReadOnly="True" VisibleIndex="3" Width="60px" HorizontalAlign="Center" AdaptivePriority="2">
                                                                                    <Settings AllowHeaderFilter="False" />
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" ReadOnly="True" VisibleIndex="4" Width="70px" AdaptivePriority="2">
                                                                                    <Settings AllowHeaderFilter="False" />
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Presupuesto" FieldName="desPresupuesto" ReadOnly="True" VisibleIndex="5" Width="200px" AdaptivePriority="2">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Codigo" FieldName="idProducto" ReadOnly="True" VisibleIndex="6" Visible="false">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Cod. Unidad" FieldName="idUnidad" ReadOnly="True" VisibleIndex="7" Visible="false">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                                <dx:BootstrapGridViewTextColumn Caption="Cod. Cuenta" FieldName="idCueCon" ReadOnly="True" VisibleIndex="8" Visible="false">
                                                                                </dx:BootstrapGridViewTextColumn>
                                                                            </Columns>
                                                                        </dx:BootstrapGridView>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapFormLayout>
                                                   
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:BootstrapCallbackPanel>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapPopupControl>

                            <%--Pop Importar--%>
                            <dx:BootstrapPopupControl ID="popImportar" runat="server" Width="800px" ClientInstanceName="popImportar" 
                                HeaderText="Importar Detalles"
                                CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" >
                                <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" HorizontalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="800px" MinWidth="400px" />
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapFormLayout ID="bsfrmImportar" runat="server" LayoutType="Vertical">
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Selección" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapUploadControl ID="BootstrapUploadControlImportarExcel" ClientInstanceName="BootstrapUploadControlImportarExcel" runat="server" ShowUploadButton="true" ShowClearFileSelectionButton="true"
                                                                OnFileUploadComplete="Upload_FileUploadComplete"
                                                                ShowProgressPanel="true" ShowTextBox="true" 
                                                                UploadMode="Advanced" 
                                                                BrowseButton-Text="Examinar" UploadButton-Text="Subir archivo" NullText="Soltar el archivo aquí" AdvancedModeSettings-DropZoneText="Soltar el archivo aquí" ValidationSettings-MaxFileSizeErrorText="El tamaño del archivo supera el tamaño máximo permitido, que es {0} bytes" ValidationSettings-NotAllowedFileExtensionErrorText="Esta extensión de archivo no está permitida" ValidationSettings-GeneralErrorText="La carga del archivo falló debido a un error externo">
                                                                <ClientSideEvents FileUploadComplete="OnFileUploadComplete" />
                                                                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xlsx,.xls" />
                                                                <AdvancedModeSettings EnableDragAndDrop="true" />
                                                            </dx:BootstrapUploadControl>
                                                            <small>Extensiones de archivo permitidas: .xlsx, .xls.</small>
                                                            <br />
                                                            <small>Tamaño máximo de archivo: 4 MB.</small>
                                                            <br />
                                                            <dx:BootstrapGridView ID="grvDetalleRequerimientoMigra" ClientInstanceName="grvDetalleRequerimientoMigra" runat="server" OnInit="grvDetalleRequerimientoMigra_Init">
                                                                <Columns>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Producto/Partida" FieldName="productoPartida" ReadOnly="True" VisibleIndex="0" Width="200px" AdaptivePriority="1">
                                                                        <Settings AllowHeaderFilter="False" />
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Descripción Detalle" FieldName="descripcion" ReadOnly="True" VisibleIndex="1" Width="200px" AdaptivePriority="1">
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" ReadOnly="True" VisibleIndex="2" Width="70px" AdaptivePriority="1">
                                                                        <Settings AllowHeaderFilter="False" />
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" ReadOnly="True" VisibleIndex="3" Width="70px" HorizontalAlign="Right" AdaptivePriority="1">
                                                                        <Settings AllowHeaderFilter="False" />
                                                                        <PropertiesTextEdit DisplayFormatString="c2">
                                                                        </PropertiesTextEdit>
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Cantidad" FieldName="cantidad" ReadOnly="True" VisibleIndex="4" Width="70px" HorizontalAlign="Right" AdaptivePriority="1">
                                                                        <Settings AllowHeaderFilter="False" />
                                                                        <PropertiesTextEdit DisplayFormatString="n0">
                                                                        </PropertiesTextEdit>
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Justificación" FieldName="justificacion" ReadOnly="True" VisibleIndex="5" Width="200px" AdaptivePriority="2">
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" ReadOnly="True" VisibleIndex="6" Width="70px" AdaptivePriority="2">
                                                                        <Settings AllowHeaderFilter="False" />
                                                                    </dx:BootstrapGridViewTextColumn>

                                                                    <dx:BootstrapGridViewTextColumn Caption="IdParPre" FieldName="idParPre" ReadOnly="True" VisibleIndex="7" Visible="false">
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="IdProducto" FieldName="idProducto" ReadOnly="True" VisibleIndex="8" Visible="false">
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Cod. Unidad" FieldName="idUnidad" ReadOnly="True" VisibleIndex="9" Visible="false">
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                    <dx:BootstrapGridViewTextColumn Caption="Cod. Cuenta" FieldName="idCueCon" ReadOnly="True" VisibleIndex="10" Visible="false">
                                                                    </dx:BootstrapGridViewTextColumn>
                                                                </Columns>
                                                            </dx:BootstrapGridView>
                                                            
                                                            <%--<dx:BootstrapUploadControl ID="ulcImportar" runat="server" ShowUploadButton="true" ShowClearFileSelectionButton="true"
                                                                ShowProgressPanel="true" ShowTextBox="true"
                                                                UploadMode="Advanced" OnFileUploadComplete="UploadControl_FileUploadComplete">
                                                                <ClientSideEvents FileUploadComplete="onFileUploadComplete" FilesUploadStart="onFilesUploadStart" />
                                                                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xlsx,.xls" />
                                                                <AdvancedModeSettings EnableMultiSelect="true" EnableDragAndDrop="true" EnableFileList="true" />
                                                            </dx:BootstrapUploadControl>--%>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                </Items>
                                        </dx:BootstrapFormLayout>
                                    </dx:ContentControl>
                                </ContentCollection>
                                <FooterTemplate>
                                    <dx:BootstrapButton ID="btnMigra" ClientInstanceName="btnMigra" runat="server" AutoPostBack="False" Text="Guardar" OnClick="btnMigra_Click" >
                                        <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                        <ClientSideEvents Click="Presupuesto.BotonMigraRequerimiento_Click" />
                                    </dx:BootstrapButton>
                                    <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Salir">
                                        <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                        <ClientSideEvents Click="function(s, e) { popImportar.Hide(); }" />
                                    </dx:BootstrapButton>
                                </FooterTemplate>
                            </dx:BootstrapPopupControl>

                            <%--Pop Mensaje--%>
                            <dx:BootstrapPopupControl ID="popInformacion" runat="server" ClientInstanceName="popInformacion" ShowFooter="true" CloseAction="None"
                                    PopupHorizontalAlign="Center" PopupVerticalAlign="Middle" Width="500px">
                                    <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="500px" MinWidth="300px" />
                                    <HeaderTemplate>
                                        <h4 class="text-primary">
                                            <span class="fa fa-info-circle"></span> Información
                                        </h4>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        
                                        <dx:BootstrapButton ID="btnAceptar" runat="server" AutoPostBack="False" ClientInstanceName="btnAceptar" Text="Aceptar" UseSubmitBehavior="false">
                                            <ClientSideEvents Click="function(s, e) { popInformacion.Hide(); }" />
                                            <SettingsBootstrap RenderOption="Primary" />
                                        </dx:BootstrapButton>
                                    </FooterTemplate>
                                    <ContentCollection>
                                        <dx:ContentControl>
                                            <p></p>
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
