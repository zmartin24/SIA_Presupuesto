<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaCertificacionDetalles.aspx.cs" Inherits="SIA_Presupuesto.WebForm.ControlPresupuestal.ListaCertificacionDetalles" %>
<%@ Register assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
                                <h2>Detalle <small><dx:ASPxLabel ID="lblDescripcion" runat="server" Text="Certificación"></dx:ASPxLabel></small></h2>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-toggle">
                                        <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Volver" OnClick="btnSalir_Click">
                                            <CssClasses Control="btn btn-sm btn-primary" Icon="fa fa-reply" />
                                        </dx:BootstrapButton>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvCertificacionDetalle" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvCertificacionDetalle" Width="100%"  KeyFieldName="idCerReq">
                                        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
                                        <SettingsBehavior AutoExpandAllGroups="true" />
                                        <CssClasses Control="table table-striped table-bordered dt-responsive nowrap" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idCerReq" VisibleIndex="0" Width="50px">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Sigla" FieldName="sigla" VisibleIndex="1" Width="100px" GroupIndex="0" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Tipo" FieldName="descripcionTipoReq" VisibleIndex="2" Width="90px" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Req. Num." FieldName="numeroReq" VisibleIndex="3" Width="100px" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Presupuesto" FieldName="desPresupuesto" VisibleIndex="4" Width="120px" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Presupuesto Mensual/Obra" FieldName="desSubpresupuesto" VisibleIndex="5" Width="120px" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="T.C." FieldName="tipoCambio" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="6" Width="100px" AdaptivePriority="3">
                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="T. Soles" FieldName="totalSoles" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="7" Width="100px" AdaptivePriority="3">
                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="T. Dolares" FieldName="totalDolares" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="8" Width="100px" AdaptivePriority="3">
                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                        <Templates>
                                            <DetailRow>
                                                <dx:BootstrapGridView ID="grvCertificacionDetalleDetail" runat="server" KeyFieldName="idCerReq" ClientInstanceName="grvCertificacionDetalleDetail" Width="100%" AutoGenerateColumns="False" OnBeforePerformDataSelect="grvCertificacionDetalleDetail_BeforePerformDataSelect">
                                                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" />
                                                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                    <SettingsBootstrap Sizing="Small" Striped="true" />
                                                    <Columns>
                                                        <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="0" Width="300px" AdaptivePriority="1">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" VisibleIndex="1" Width="80px" AdaptivePriority="2">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Precio" FieldName="precio" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="2" Width="90px" AdaptivePriority="3">
                                                            <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                            </PropertiesTextEdit>
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Cantidad" FieldName="cantidad" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="3" Width="90px" AdaptivePriority="3">
                                                            <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                            </PropertiesTextEdit>
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Subtotal" FieldName="subTotal" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="4" Width="100px" AdaptivePriority="4">
                                                            <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                            </PropertiesTextEdit>
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Det. Presupuesto" FieldName="desPresupuesto" VisibleIndex="5" Width="50px" AdaptivePriority="4">
                                                        </dx:BootstrapGridViewTextColumn>
                                                    </Columns>
                                                </dx:BootstrapGridView>
                                            </DetailRow>
                                        </Templates>
                                    </dx:BootstrapGridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
