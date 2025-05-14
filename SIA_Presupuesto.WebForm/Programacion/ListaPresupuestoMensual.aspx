<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaPresupuestoMensual.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaPresupuestoMensual" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
                                <%--<h4>Presupuesto Mensual</h4>--%>
                                <h2>Presupuesto Mensual</h2>
                                <div class="clearfix"></div>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-group">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" ToolTip="Detalle" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-tasks" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonDetallePresupuestoMensual_Click" />
                                        </dx:BootstrapButton>

                                        <%--Botones de exportación--%>
                                        <dx:BootstrapButton ID="btnExpoEva" runat="server" ClientInstanceName="btnExpoEva" Text="Exportar Pre. Men." AutoPostBack="false"  ToolTip="Exportar Presupuesto Mensual" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-file-excel-o"  />
                                            <ClientSideEvents Click="Presupuesto.BotonPopExportarPresupuestoMensualMoneda_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>
                                    </div>
                                    <hr />
                                </div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="form-toggle">
                                        <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server">
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="2" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapComboBox ID="cbAnioPreMen" runat="server" ClientInstanceName="cbAnioPreMen" TextField="nombre" ValueField="indice">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioPreMen_SelectedIndexChanged" />
                                                            </dx:BootstrapComboBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                            </Items>
                                        </dx:BootstrapFormLayout>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="x_content">
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvSubPresupuesto" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvSubPresupuesto" Width="100%" KeyFieldName="idSubPresupuesto" EnableCallbackAnimation="True" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding" >
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <SettingsBootstrap Sizing="Small" Striped="true" />
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" AutoExpandAllGroups="false"/>
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" ShowGroupPanel="True" />

                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idSubPresupuesto" VisibleIndex="0" Width="40px">
                                                <Settings AutoFilterCondition="Contains" ShowFilterRowMenu="False"/>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Sub Presupuesto" FieldName="desSubPresupuesto" VisibleIndex="1" Width="35%" >
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Gru. Pre." FieldName="desGrupoPresupuesto" VisibleIndex="2" Width="150px" GroupIndex="0" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Presupuesto" FieldName="desPresupuesto" VisibleIndex="3" Width="150px" GroupIndex="1" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            
                                            <dx:BootstrapGridViewTextColumn Caption="T. Cambio" FieldName="tipoCambio" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="6" Width="30px" AdaptivePriority="2">
                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Estado" FieldName="nombreEstado" VisibleIndex="7" Width="50px" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Usu. Crea" FieldName="usuCrea" VisibleIndex="8" Width="60px" AdaptivePriority="3">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Fecha Crea" FieldName="fechaCrea" VisibleIndex="9" Width="60px" UnboundType="DateTime" AdaptivePriority="3">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Usu. Edita" FieldName="usuEdita" VisibleIndex="10" Width="60px" AdaptivePriority="3">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Fecha Edita" FieldName="fechaEdita" VisibleIndex="11" Width="60px" UnboundType="DateTime" AdaptivePriority="3">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvSubPresupuesto_OnGridSelectionChanged" />
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager NumericButtonCount="6"></SettingsPager>
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>

                                    <%--Popup Reporte de Exportación--%>
                                    <dx:BootstrapPopupControl ID="popPreMenMoneda" runat="server" Width="300px" ClientInstanceName="popPreMenMoneda"
                                        OnCallback="popPreMenMoneda_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopPreMenMoneda" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Presupuesto:" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:ASPxLabel ID="lblDesPresupuesto" runat="server" Text="[Descripcion Presupuesto]"></dx:ASPxLabel>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Descripción" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:ASPxLabel ID="lblDesSubpresupuesto" runat="server" Text="[Descripcion Presupuesto Mensual]"></dx:ASPxLabel>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMoneda" runat="server" ClientInstanceName="cbMoneda" TextField="descripcion" ValueField="idMoneda">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopPreMenMoneda" runat="server" AutoPostBack="false" ClientInstanceName="btnSalirPopPreMenMoneda" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popPreMenMoneda.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnExpPreMen" runat="server" AutoPostBack="False" ClientInstanceName="btnExpPreMen" OnClick="btnExpPreMen_Click" Text="Exportar">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-file-excel-o"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonExportarPresupuestoMensual_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
