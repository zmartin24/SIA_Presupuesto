<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaCertificacionMaster.aspx.cs" Inherits="SIA_Presupuesto.WebForm.ControlPresupuestal.ListaCertificacionMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:BootstrapCallbackPanel ID="cpPrincipal" runat="server" Width="100%" ClientInstanceName="cpPrincipal" OnCallback="cpPrincipal_Callback">
        <ClientSideEvents EndCallback="Presupuesto.CpPrincipal_EndCallback" />
        <ContentCollection>
            <dx:ContentControl runat="server">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Lista Certificación <small>Presupuestal</small></h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-group">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Cert. Req." ToolTip="Certificación Req." Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-tasks" />
                                            <ClientSideEvents Click="Presupuesto.BotonDetalleCertificacion_Click" />
                                        </dx:BootstrapButton>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row">
                                    <dx:BootstrapFormLayout ID="frmConsulta" runat="server">
                                        <Items>
                                            <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="3" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <dx:BootstrapComboBox ID="cbAnio" runat="server" ClientInstanceName="cbAnio" TextField="nombre" ValueField="indice">
                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioCertificacion_SelectedIndexChanged" />
                                                        </dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                        </Items>
                                    </dx:BootstrapFormLayout>
                                </div>
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvCertificacion" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvCertificacion" Width="100%" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding" KeyFieldName="idCerMas">
                                        <CssClasses Control="table table-striped table-bordered dt-responsive nowrap" />
                                        <SettingsBootstrap Sizing="Small" Striped="true" />
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="true"/>
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idCerMas" VisibleIndex="0" Width="70px">
                                                <Settings AutoFilterCondition="Contains" ShowFilterRowMenu="False"/>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Tipo Req." FieldName="descripcionTipoReq" VisibleIndex="1" Width="90px" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Nro. Req." FieldName="numeroReq" VisibleIndex="2" Width="100px" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Observación" FieldName="observacion" VisibleIndex="3" Width="300px" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Nro Certificación" FieldName="numCertificacion" VisibleIndex="4" Width="150px" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Usuario Crea" FieldName="usuCrea" VisibleIndex="5" Width="120px" AdaptivePriority="3">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Fecha Crea" FieldName="fechaCrea"  VisibleIndex="6" Width="120px" AdaptivePriority="3">
                                            <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss">
                                            </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Usuario Edita" FieldName="usuEdita" VisibleIndex="7" Width="120px" AdaptivePriority="4">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Fecha Edita" FieldName="fechaEdita"  VisibleIndex="8" Width="120px" AdaptivePriority="4">
                                            <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss">
                                            </PropertiesTextEdit>
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvRequerimiento_OnGridSelectionChanged" />
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
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
