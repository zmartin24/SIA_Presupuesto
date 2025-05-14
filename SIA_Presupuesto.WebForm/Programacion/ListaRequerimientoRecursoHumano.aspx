<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaRequerimientoRecursoHumano.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaRequerimientoRecursoHumano" %>

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
                                <h2>Lista de Requerimientos de Recursos Humanos</h2>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="well" style="overflow: auto">
                                        <div class="btn-toggle">
                                            <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevo" Text="Nuevo">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-plus-circle"/>
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonNuevoRequerimientoGeneral_Click" />
                                            </dx:BootstrapButton>
                                                <dx:BootstrapButton ID="btnEditar" runat="server" AutoPostBack="False" ClientInstanceName="btnEditar" Text="Editar">
                                                <CssClasses Control="btn btn-success" Icon="fa fa-edit" />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonEditarRequerimientoRRHH_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnAnular" runat="server" AutoPostBack="False" ClientInstanceName="btnAnular" Text="Anular">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-remove"/>
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonAnularRequerimientoRRHH_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle Personal">
                                                <ClientSideEvents Click="Presupuesto.BotonDetalleRequerimientoRH_Click" />
                                                <CssClasses Control="btn btn-warning" Icon="fa fa-tasks" />
                                                <SettingsBootstrap Sizing="Small" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImprimir" runat="server" ClientInstanceName="btnImprimir" Text="Imprimir" AutoPostBack="False">
                                                <CssClasses Control="btn btn-info" Icon="fa fa-print"  />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirRequerimientoRH_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImprimirReporteDirArea" runat="server" ClientInstanceName="btnImprimirReporteDirArea" AutoPostBack="false"  Text="Imp. por Subdir." ToolTip="Imprimir por Subdirección">
                                                <CssClasses Control="btn btn-info" Icon="fa fa-print" />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonImpReqRHDirArea_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImprimirReporteDirAreaImp" runat="server" ClientInstanceName="btnImprimirReporteDirAreaImp" AutoPostBack="false"  Text="Imp. totales" ToolTip="Imprimir totales por Dirección, Subdirección">
                                                <CssClasses Control="btn btn-info" Icon="fa fa-print" />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonImpReqRHDirImp_Click" />
                                            </dx:BootstrapButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="btn-toggle">
                                        <%--Basic Example--%>
                                        <%--<div class="form-group">--%>
                                            <dx:BootstrapFormLayout ID="ASPxFormLayout3" runat="server">
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="2" ColSpanMd="4" ColSpanSm="12" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapComboBox ID="cbAnio" runat="server" ClientInstanceName="cbAnio" TextField="nombre" ValueField="indice">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioRRHH_SelectedIndexChanged" />
                                                            </dx:BootstrapComboBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                            </Items>
                                        </dx:BootstrapFormLayout>
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvReqRecursosHumanos" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvReqRecursosHumanos" KeyFieldName="idReqRecHum" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding" Width="100%" EnableCallbackAnimation="True" >
                                        <SettingsPager AlwaysShowPager="True" EnableAdaptivity="True">
                                        </SettingsPager>
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" ShowFooter="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <%--<Settings ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" ShowFooter="True"/>--%>
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idReqRecHum" VisibleIndex="0" Width="50px">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1" Width="40%" AdaptivePriority="1">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Moneda" FieldName="moneda" VisibleIndex="7" Width="50px" AdaptivePriority="1" Visible="false">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Cant." FieldName="cantTotalPuesto" VisibleIndex="8" Width="40px" AdaptivePriority="1" ToolTip="Cantidad de Puestos">
                                                <CssClasses HeaderCell="column-title" />
                                                <PropertiesTextEdit DisplayFormatString="n0"></PropertiesTextEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Dirección" FieldName="desDireccion" VisibleIndex="5" Width="15%" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Subdirección" FieldName="desSubdireccion" VisibleIndex="4" Width="12%" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Area" FieldName="desArea" VisibleIndex="3" Width="12%" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewDateColumn Caption="Fecha Emisión" FieldName="fechaEmision" VisibleIndex="2" Width="6%" AdaptivePriority="2">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>
                                        </Columns>
                                         <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="cantTotalPuesto" ShowInColumn="cantTotalPuesto" SummaryType="Sum" DisplayFormat="{0:n0}"/>
                                        </TotalSummary>
                                        <SettingsPager NumericButtonCount="6"></SettingsPager>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvReqRecursosHumanos_OnGridSelectionChanged" />
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>
                                </div>
                            </div>
                         
                             <div class="x_content"><%--Emergentes--%>
                                <dx:BootstrapPopupControl ID="popRequerimiento" runat="server" Width="350px" ClientInstanceName="popRequerimiento" 
                                    CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popRequerimiento_WindowCallback">
                                          
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <div class="modal-dialog modal-lg">
                                                    <div class="modal-body">
                                                        <dx:BootstrapFormLayout ID="ASPxFormLayout1" runat="server" CssClasses-Control="form-horizontal form-label-left input_mask" CssClasses-ItemControl="form-group">
                                                            <CssClasses Control="form-horizontal form-label-left" ItemControl="form-group" />
                                                            <Items>
                                                                <dx:BootstrapLayoutItem Caption="Dirección" >
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                            <dx:BootstrapComboBox ID="cbDireccion" runat="server" ClientInstanceName="cbDireccion" TextField="desDireccion" ValueField="idDireccion">
                                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbDireccion_SelectedIndexChanged" />
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Subdirección/ Oficina">
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                            <dx:BootstrapComboBox ID="cbSubdireccion" runat="server" ClientInstanceName="cbSubdireccion" TextField="desSubdireccion" ValueField="idSubdireccion"  OnCallback="cbSubdireccion_Callback">
                                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbSubdireccion_SelectedIndexChanged" EndCallback="Presupuesto.CbSubdireccion_EndCallback"  />
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la subdirección" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Area">
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                            <dx:BootstrapComboBox ID="cbArea" runat="server" ClientInstanceName="cbArea" TextField="desArea" ValueField="idArea"  OnCallback="cbArea_Callback">
                                                                                <ClientSideEvents EndCallback="Presupuesto.CbArea_EndCallback"  />
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione el área" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Moneda">
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                            <dx:BootstrapComboBox ID="cbMoneda" runat="server" TextField="descripcion" ValueField="idMoneda" ClientInstanceName="cbMoneda">
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la moneda" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Descripción">
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                            <dx:BootstrapTextBox ID="txtDescripcion" runat="server" ClientInstanceName="txtDescripcion" MaskSettings-UseInvariantCultureDecimalSymbolOnClient="False">
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Ingrese la descripción" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapTextBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Año" >
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                            <dx:BootstrapSpinEdit ID="seAnio" runat="server" ClientInstanceName="seAnio" CssClasses-Control="spinedit">
                                                                                <CssClasses Control="spinedit"></CssClasses>
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Ingrese el año" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapSpinEdit>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                    
                                                            </Items>
                                                        </dx:BootstrapFormLayout>
                                                        </div>
                                                    <div class="modal-footer">
                                                        <dx:BootstrapButton ID="btnGrabar" runat="server" AutoPostBack="False" ClientInstanceName="btnGrabar" Text="Grabar">
                                                                <CssClasses Control="btn btn-primary" Icon="fa fa-save"></CssClasses>
                                                                <ClientSideEvents Click="Presupuesto.BotonGuardarRequerimientoGeneral_Click" />
                                                        </dx:BootstrapButton>
                                                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="False" ClientInstanceName="btnCancelar" Text="Cancelar">
                                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonCancelarRequerimientoGeneral_Click" />
                                                        </dx:BootstrapButton>
                                                    </div>
                                                </div>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                            </dx:BootstrapPopupControl>
                                    
                                 
                                <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" Width="400px" ClientInstanceName="popReporteDireccion" CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReporteDireccion_WindowCallback">
                                        <ContentCollection>
                                        <dx:ContentControl runat="server">
                                                <div class="modal-body">
                                                    <dx:BootstrapFormLayout ID="ASPxFormLayout2" runat="server" LayoutType="Vertical">
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Año">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server"  ColSpanLg="8" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                        <dx:BootstrapComboBox ID="cbAnioPeriodo" runat="server" ClientInstanceName="cbAnioPeriodo" TextField="anio" ValueField="anio" SelectedIndex="0">
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione año" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Dirección"  ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" >
                                                                        <dx:BootstrapComboBox ID="cbDireccionReporte" runat="server" ClientInstanceName="cbDireccionReporte" TextField="desDireccion" ValueField="idDireccion">
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbDireccionReporte_SelectedIndexChanged" />
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Subdirección"  ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbSubdireccionReporte" runat="server" ClientInstanceName="cbSubdireccionReporte" TextField="desSubdireccion" ValueField="idSubdireccion"  OnCallback="cbSubdireccionReporte_Callback">
                                                                                <ClientSideEvents EndCallback="Presupuesto.CbSubdireccionReporte_EndCallback"  />
                                                                                <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la subdirección" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapFormLayout>
                                                <div class="modal-footer">
                                                    <dx:BootstrapButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                                            <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonImprimirReporteRR_Click" />
                                                    </dx:BootstrapButton>

                                                    <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Salir">
                                                        <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                        <ClientSideEvents Click="Presupuesto.BotonSalirReporte_Click" />
                                                    </dx:BootstrapButton>
                                                </div>
                                            </div>
                                                    </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:BootstrapPopupControl>
                                <dx:BootstrapPopupControl ID="popReporteDireccionImp" runat="server" Width="400px" ClientInstanceName="popReporteDireccionImp" CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReporteDireccionImp_WindowCallback">
                                        <ContentCollection>
                                        <dx:ContentControl runat="server">
                                                <div class="modal-body">
                                                    <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" LayoutType="Vertical">
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Año">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server"  ColSpanLg="8" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                        <dx:BootstrapComboBox ID="cbAnioPeriodoImp" runat="server" ClientInstanceName="cbAnioPeriodoImp" TextField="anio" ValueField="anio" SelectedIndex="0">
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione año" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                                <CaptionSettings HorizontalAlign="Left" />
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapComboBox ID="cbMonedaReporteImp" runat="server" ClientInstanceName="cbMonedaReporteImp" TextField="descripcion" ValueField="idMoneda" >
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la moneda" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Dirección"  ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" >
                                                                        <dx:BootstrapComboBox ID="cbDireccionReporteImp" runat="server" ClientInstanceName="cbDireccionReporteImp" TextField="desDireccion" ValueField="idDireccion" >
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbDireccionReporteRRHHImp_SelectedIndexChanged" />
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Subdirección"  ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                    <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbSubdireccionReporteImp" runat="server" ClientInstanceName="cbSubdireccionReporteImp" TextField="desSubdireccion" ValueField="idSubdireccion"  OnCallback="cbSubdireccionReporteImp_Callback">
                                                                                <ClientSideEvents EndCallback="Presupuesto.CbSubdireccionReporteImp_EndCallback"  />
                                                                                <%--<ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la subdirección" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>--%>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapFormLayout>
                                                <div class="modal-footer">
                                                    <dx:BootstrapButton ID="btnRepImp" runat="server" AutoPostBack="False" ClientInstanceName="btnRepImp" Text="Imprimir">
                                                            <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonImprimirReporteRRImp_Click" />
                                                    </dx:BootstrapButton>

                                                    <dx:BootstrapButton ID="btnRepImpSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnRepImpSalir" Text="Salir">
                                                        <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                        <ClientSideEvents Click="function(s, e) { popReporteDireccionImp.Hide(); }" />
                                                    </dx:BootstrapButton>
                                                </div>
                                            </div>
                                                    </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:BootstrapPopupControl>
                             </div>
                        </div>
                    </div>
                </div><%--Fin class=Row--%>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
