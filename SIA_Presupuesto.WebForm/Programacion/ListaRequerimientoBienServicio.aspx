<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaRequerimientoBienServicio.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaRequerimientoBienServicio" %>

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
                                <h4> Lista de Requerimientos Anuales de Bienes y Servicios </h4>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="well" style="overflow: auto">
                                    <div class="btn-toggle">
                                        <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevo" Text="Nuevo" Width="110">
                                            <CssClasses Control="btn btn-primary" Icon="fa fa-plus-circle"/>
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonNuevoRequerimientoGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnClona" runat="server" AutoPostBack="False" ClientInstanceName="btnClona" Text="Clonar" Width="110">
                                            <CssClasses Control="btn btn-primary" Icon="fa fa-copy"/>
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonClonarRequerimientoGeneral_Click" />
                                        </dx:BootstrapButton>
                                         <dx:BootstrapButton ID="btnEditar" runat="server" AutoPostBack="False" ClientInstanceName="btnEditar" Text="Editar" Width="110">
                                            <CssClasses Control="btn btn-success" Icon="fa fa-edit" />
                                             <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonEditarRequerimientoGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnAnular" runat="server" AutoPostBack="False" ClientInstanceName="btnAnular" Text="Anular" Width="110">
                                            <CssClasses Control="btn btn-danger" Icon="fa fa-remove"/>
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonAnularRequerimientoGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" Width="110">
                                            <ClientSideEvents Click="Presupuesto.BotonDetalleRequerimientoGeneral_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <CssClasses Control="btn btn-warning" Icon="fa fa-tasks" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimir" runat="server" ClientInstanceName="btnImprimir" Text="Imprimir" AutoPostBack="False" ToolTip="Imprimir" Width="110">
                                            <CssClasses Control="btn btn-info" Icon="fa fa-print"  />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonImprimirRequerimientoGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimirDireccion" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirDireccion" Text="Imp. por Dir" ToolTip="Imprimir por Dirección" Width="110">
                                            <CssClasses Control="btn btn-info" Icon="fa fa-print" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonImprimirDireccion_Click" />
                                        </dx:BootstrapButton>
                                        
                                    </div>
                                    </div>
                                    </div>
                                <div class="row">
                                    <div class="btn-toggle">
                                        <dx:BootstrapFormLayout ID="ASPxFormLayout3" runat="server">
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="2" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapComboBox ID="cbAnio" runat="server" ClientInstanceName="cbAnio" TextField="nombre" ValueField="indice" EnableCallbackMode="true">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnio_SelectedIndexChanged" />
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
                                    <dx:BootstrapGridView ID="grvRequerimiento" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvRequerimiento" KeyFieldName="idReqBieSer" OnCustomCallback="grvRequerimiento_CustomCallback" 
                                            OnDataBinding="grvRequerimiento_DataBinding" Width="100%" EnableCallbackAnimation="True"
                                            OnCustomSummaryCalculate="grvRequerimiento_CustomSummaryCalculate" OnCustomUnboundColumnData="grvRequerimiento_CustomUnboundColumnData"
                                        >
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" ShowFooter="True" /> <%--ShowGroupPanel="true"--%>
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" AutoExpandAllGroups="true" SortMode="Custom"/>
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idReqBieSer" VisibleIndex="0" Width="60px">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1" Width="30%" AdaptivePriority="1">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewDateColumn Caption="Fecha Emisión" FieldName="fechaEmision" VisibleIndex="2" Width="100" HorizontalAlign="Center" AdaptivePriority="1">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Area" FieldName="desArea" VisibleIndex="3" Width="12%" AdaptivePriority="1">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Subdirección" FieldName="desSubdireccion" VisibleIndex="4" Width="12%" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Dirección" FieldName="desDireccion" VisibleIndex="5" Width="15%" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            
                                            <dx:BootstrapGridViewTextColumn Caption="Moneda" FieldName="moneda" VisibleIndex="7" Width="40px" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Total" FieldName="total" VisibleIndex="8" Width="100px" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="total" ShowInColumn="Total" SummaryType="Custom" DisplayFormat="{0:n2}"/>
                                        </TotalSummary>
                                        <SettingsPager NumericButtonCount="6"></SettingsPager>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvRequerimiento_OnGridSelectionChanged" />
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>
                                </div>
                            </div>
                         
                             <div class="x_content"><%--Emergentes--%>
                                 <dx:BootstrapPopupControl ID="popRequerimiento" runat="server" Width="400px" ClientInstanceName="popRequerimiento" 
                                        CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="Middle" OnCallback="popRequerimiento_WindowCallback" ShowFooter="true" AllowDragging="true">
                                     <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="600px" MinWidth="300px"/>                                  
                                     <ContentCollection>
                                         <dx:ContentControl runat="server">
                                             <dx:BootstrapFormLayout ID="ASPxFormLayout1" runat="server" >
                                                <CssClasses Control="form-horizontal form-label-left" ItemControl="form-group" />
                                                <Items>
                                                    <dx:BootstrapLayoutItem Caption="Dirección" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <CaptionSettings HorizontalAlign="Left" />
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server" >
                                                                <dx:BootstrapComboBox ID="cbDireccion" runat="server" ClientInstanceName="cbDireccion" TextField="desDireccion" ValueField="idDireccion" OnCallback="cbDireccion_Callback">
                                                                    <ClientSideEvents SelectedIndexChanged="Presupuesto.CbDireccion_SelectedIndexChanged" />
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Subdirección/ Oficina" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server" >
                                                                <dx:BootstrapComboBox ID="cbSubdireccion" runat="server" ClientInstanceName="cbSubdireccion" TextField="desSubdireccion" ValueField="idSubdireccion"  OnCallback="cbSubdireccion_Callback">
                                                                    <ClientSideEvents SelectedIndexChanged="Presupuesto.CbSubdireccion_SelectedIndexChanged" EndCallback="Presupuesto.CbSubdireccion_EndCallback" />
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la subdirección" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Area" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbArea" runat="server" ClientInstanceName="cbArea" TextField="desArea" ValueField="idArea"  OnCallback="cbArea_Callback">
                                                                    <ClientSideEvents EndCallback="Presupuesto.CbArea_EndCallback"  />
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione el área" SetFocusOnError="True">
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
                                                                <dx:BootstrapComboBox ID="cbMoneda" runat="server" TextField="descripcion" ValueField="idMoneda" ClientInstanceName="cbMoneda">
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la moneda" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                        <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapSpinEdit ID="seAnio" runat="server" ClientInstanceName="seAnio" CssClasses-Control="spinedit" >
                                                                    <CssClasses Control="spinedit"></CssClasses>

                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Ingrese el año" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapSpinEdit>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Descripción" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <CaptionSettings HorizontalAlign="Left" />
                                                                
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapTextBox ID="txtDescripcion" runat="server" ClientInstanceName="txtDescripcion" >
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Ingrese la descripción" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapTextBox>
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
                                             <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonGuardarRequerimientoGeneral_Click" />
                                        </dx:BootstrapButton>
                                         <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="False" ClientInstanceName="btnCancelar" Text="Cancelar">
                                             <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                             <SettingsBootstrap Sizing="Small" />
                                             <ClientSideEvents Click="Presupuesto.BotonCancelarRequerimientoGeneral_Click" />
                                         </dx:BootstrapButton>
                                     </FooterTemplate>
                                 </dx:BootstrapPopupControl>
                                 
                                 <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" Width="350px" ClientInstanceName="popReporteDireccion" CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReporteDireccion_WindowCallback" ShowFooter="true">
                                     <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="600px" MinWidth="300px" />                                  
                                     <ContentCollection>
                                         <dx:ContentControl runat="server">
                                            <dx:BootstrapFormLayout ID="ASPxFormLayout2" runat="server">
                                                <Items>
                                                    <dx:BootstrapLayoutItem Caption="Dirección" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbDireccionReporte" runat="server" ClientInstanceName="cbDireccionReporte" TextField="desDireccion" ValueField="idDireccion" OnCallback="cbDireccion_Callback">
                                                                    <ClientSideEvents SelectedIndexChanged="Presupuesto.CbDireccionReporte_SelectedIndexChanged" />
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Subdirección" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbSubdireccionReporte" runat="server" ClientInstanceName="cbSubdireccionReporte" TextField="desSubDireccion" ValueField="idSubDireccion" OnCallback="cbSubdireccionReporte_Callback">
                                                                    <ClientSideEvents EndCallback="Presupuesto.CbSubdireccionReporte_EndCallback" />
                                                                    <%--<ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>--%>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Tipo" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbTipo" runat="server" ClientInstanceName="cbTipo" SelectedIndex="0">
                                                                    <Items>
                                                                        <dx:BootstrapListEditItem Selected="True" Text="Todos" Value="TOD" />
                                                                        <dx:BootstrapListEditItem Text="Administrativos" Value="ADM" />
                                                                        <dx:BootstrapListEditItem Text="Erradicación" Value="ERR" />
                                                                    </Items>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbAnioPeriodo" runat="server" ClientInstanceName="cbAnioPeriodo" TextField="anio" ValueField="anio" SelectedIndex="0">
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
                                                                <dx:BootstrapComboBox ID="cbMonedaReporte" runat="server" TextField="descripcion" ValueField="idMoneda" ClientInstanceName="cbMonedaReporte">
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la moneda" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    </Items>
                                            </dx:BootstrapFormLayout>
                                         </dx:ContentControl>
                                     </ContentCollection>
                                     <FooterTemplate>
                                         <dx:BootstrapButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                             <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                             <SettingsBootstrap Sizing="Small" />
                                             <ClientSideEvents Click="Presupuesto.BotonImprimirReporte_Click" />
                                         </dx:BootstrapButton>
                                         <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Salir">
                                             <SettingsBootstrap Sizing="Small" />
                                             <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                             <ClientSideEvents Click="Presupuesto.BotonSalirReporte_Click" />
                                         </dx:BootstrapButton>
                                     </FooterTemplate>
                                 </dx:BootstrapPopupControl>
                             </div>
                        </div>
                    </div>
                </div><%--Fin class=Row--%>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
