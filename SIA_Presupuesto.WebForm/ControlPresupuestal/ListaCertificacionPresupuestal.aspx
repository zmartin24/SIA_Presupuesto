<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaCertificacionPresupuestal.aspx.cs" Inherits="SIA_Presupuesto.WebForm.ControlPresupuestal.ListaCertificacionPresupuestal" %>
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
                                <h4> LISTA CERTIFICACIÓN PRESUPUESTAL</h4>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-toggle">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" >
                                            <ClientSideEvents Click="Presupuesto.BotonDetalleCertificacion_Click" />
                                            <CssClasses Control="btn btn-sm btn-primary" Icon="fa fa-tasks" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimir" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimir" Text="Imprimir">
                                            <CssClasses Control="btn btn-sm btn-info" Icon="fa fa-print"/>
                                            <ClientSideEvents Click="Presupuesto.BotonImprimirCertificacion_Click" />
                                        </dx:BootstrapButton>
                                    </div>
                                </div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="form-group">
                                        <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server">
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Año" ColSpanMd="6">
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
                                </div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="table-responsive">
                                        <dx:BootstrapGridView ID="grvCertificacion" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvCertificacion" Width="100%" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding" KeyFieldName="idCerReq">
                                            <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True">
                                            </SettingsPager>
                                            <CssClasses Control="table table-striped table-bordered dt-responsive nowrap" />
                                            <SettingsBootstrap Sizing="Small" Striped="true" />
                                            <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="true"/>
                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" />
                                            
                                            <Columns>
                                                <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idCerReq" VisibleIndex="0" Width="70px">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="2" Width="400px">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Fecha Emisión" FieldName="fechaEmision" VisibleIndex="6" Width="100px" UnboundType="DateTime">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Número" FieldName="sigla" VisibleIndex="1" Width="150px">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Usuario Crea" FieldName="usuCrea" VisibleIndex="7" Width="120px">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Fecha Crea" FieldName="fechaCrea"  VisibleIndex="8" Width="120px">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss">
                                                </PropertiesTextEdit>
                                                </dx:BootstrapGridViewTextColumn>
                                            </Columns>
                                            <ClientSideEvents SelectionChanged="Presupuesto.GrvRequerimiento_OnGridSelectionChanged" />
                                        </dx:BootstrapGridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
    
</asp:Content>
