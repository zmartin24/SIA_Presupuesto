<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaPresupuestoAnual.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaPresupuestoAnual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
    <script type="text/javascript">
         function onSelectAllRowsClick() {
             grvPopExpProAnuMas.SelectRows();
         }
         function onSelectAllRowsOnPageClick() {
             grvPopExpProAnuMas.SelectAllRowsOnPage();
         }
         function onClearSelectionClick() {
             grvPopExpProAnuMas.UnselectRows();
         }
         function onUpdateSelection(s, e) {
             btnSelectAllRows.SetEnabled(s.GetSelectedRowCount() < s.cpVisibleRowCount);
             btnClearSelection.SetEnabled(s.GetSelectedRowCount() > 0);
             btnExpProAnuMas.SetEnabled(s.GetSelectedRowCount() > 0);
             
             $("#info4").html("Presupuesto seleccionado: " + s.GetSelectedRowCount());
         }
    </script>
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
                                <h4> Lista de Presupuesto Anual </h4>
                                <div class="clearfix"></div>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-group">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" ToolTip="Detalle" Width="110">
                                            <%--<CssClasses Control="btn btn-info" Icon="fa fa-tasks" />--%>
                                            <CssClasses Control="btn btn-app" Icon="fa fa-tasks" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonDetallePresupuestoAnual_Click" />
                                        </dx:BootstrapButton>
                                        
                                        <dx:BootstrapButton ID="btnConsolidado" runat="server" ClientInstanceName="btnConsolidado" Text="Consolidado Dir." AutoPostBack="False" ToolTip="Consolidado Por Direcciones" Width="110">
                                            <%--<CssClasses Control="btn btn-info" Icon="fa fa-print"  />--%>
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonConsolidadoPorDirecciones_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimirPorSub" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirPorSub" Text="Resumen SubDir." ToolTip="Resumen por Subdireccion" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonResumenPorSubdirecciones_Click" />
                                            <%--<CssClasses Control="btn btn-info" Icon="fa fa-print"  />--%>
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimirCalendario" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirCalendario" Text="Imprimir Cal." ToolTip="Imprimir Calendario" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonCalendarioPresAnual_Click" />
                                            <%--<CssClasses Control="btn btn-info" Icon="fa fa-print"  />--%>
                                        </dx:BootstrapButton>

                                         <%--Botones de exportación--%>
                                        <dx:BootstrapButton ID="btnPopExpoProAnu" runat="server" ClientInstanceName="btnPopExpoProAnu" Text="Exportar Pre." AutoPostBack="false"  ToolTip="Exportar Presupuesto Anual" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-file-excel-o"  />
                                            <ClientSideEvents Click="Presupuesto.BotonPopExpProAnu_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton runat="server" Text="Exportar Mas." AutoPostBack="false"  ToolTip="Exportar Presupuesto Anual Masivo" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-file-excel-o"  />
                                            <ClientSideEvents Click="Presupuesto.BotonPopExpProAnuMas_Click" />
                                            <SettingsBootstrap RenderOption="Primary" Sizing="Small" />
                                        </dx:BootstrapButton>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row">
                                    <dx:BootstrapFormLayout ID="BootstrapFormLayout3" runat="server">
                                        <Items>
                                            <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="3" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <dx:BootstrapComboBox ID="cbAnio" runat="server" ClientInstanceName="cbAnio" TextField="nombre" ValueField="indice">
                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnio_SelectedIndexChanged" />
                                                        </dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                        </Items>
                                    </dx:BootstrapFormLayout>
                                </div>
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvRequerimiento" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvRequerimiento" KeyFieldName="idProAnu" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding" Width="100%" EnableCallbackAnimation="True">
                                        <CssClasses Table="table table-striped table-bordered dt-responsive nowrap" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True"/>
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"/>
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idProAnu" VisibleIndex="0" Width="5%">
                                                <Settings AutoFilterCondition="Contains" ShowFilterRowMenu="False"/>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Grupo Presupuesto" FieldName="grupo" VisibleIndex="1" Width="30%" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="2" Width="50%" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewDateColumn Caption="Fecha Emisión" FieldName="fechaEmision"  VisibleIndex="3" Width="10%" AdaptivePriority="2">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Moneda" FieldName="moneda"  VisibleIndex="6" Width="10%" AdaptivePriority="3">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                                
                                        </Columns>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvProgramacionAnual_OnGridSelectionChanged" />
                                        <SettingsPager NumericButtonCount="6"></SettingsPager>
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>

                                    <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" Width="300px" ClientInstanceName="popReporteDireccion" 
                                        OnCallback="popReporteDireccion_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                            <dx:BootstrapFormLayout ID="BootstrapFormLayout2" runat="server" LayoutType="Vertical">
                                                <Items>
                                                    <dx:BootstrapLayoutItem Caption="Dirección" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbDir" runat="server" ClientInstanceName="cbDir" TextField="desDireccion" ValueField="idDireccion" Width="280px" >
                                                                    <%--<ClientSideEvents SelectedIndexChanged="Presupuesto.CbDir_SelectedIndexChanged" />--%>
                                                                    <ValidationSettings ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbAnioDir" runat="server" ClientInstanceName="cbAnioDir" TextField="nombre" ValueField="indice">
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    </Items>
                                            </dx:BootstrapFormLayout>
                                        </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonSalirReporteResumenPorSubdirecciones_Click" />
                                            </dx:BootstrapButton>

                                            <dx:BootstrapButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirResumenPorSubdirecciones_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>

                                    <dx:BootstrapPopupControl ID="popCalendarioAnual" runat="server" Width="300px" ClientInstanceName="popCalendarioAnual" OnCallback="popCalendarioAnual_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" 
                                        ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                        <dx:ContentControl runat="server">
                                            <dx:BootstrapFormLayout ID="frmPopCalendarioAnual" runat="server" LayoutType="Vertical">
                                                <Items>
                                                    <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbAnioCal" runat="server" ClientInstanceName="cbAnioCal" TextField="nombre" ValueField="indice">
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Fuente Financiamiento" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbFueFinCal" runat="server" ClientInstanceName="cbFueFinCal" TextField="desRubro" ValueField="idFueFin" Width="280px" >
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Presupuesto Anual" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbPresAnual" runat="server" ClientInstanceName="cbPresAnual" TextField="descripcion" ValueField="idProAnu">
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    </Items>
                                            </dx:BootstrapFormLayout>
                                      
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirCal" runat="server" AutoPostBack="False" ClientInstanceName="btnSalirCal" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonSalirReporteCalendarioPres_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImpCal" runat="server" AutoPostBack="False" ClientInstanceName="btnImpCal" Text="Imprimir">
                                                    <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                    <ClientSideEvents Click="Presupuesto.BotonImprimirCalendarioPresAnual_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>

                                    <%--Popup Reporte de Exportación--%>
                                    <dx:BootstrapPopupControl ID="popExportaProAnu" runat="server" Width="300px" ClientInstanceName="popExportaProAnu"
                                        OnCallback="popExportaProAnu_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopExportaProAnu" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Grupo Presupuesto:" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:ASPxLabel ID="lblDesGrupoPre" runat="server" Text="[Descripcion Grupo]"></dx:ASPxLabel>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Descripción" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:ASPxLabel ID="lblDesPresupuesto" runat="server" Text="[Descripcion Presupuesto]"></dx:ASPxLabel>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMonedaExpProAnu" runat="server" ClientInstanceName="cbMonedaExpProAnu" TextField="descripcion" ValueField="idMoneda">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopExp" runat="server" AutoPostBack="false" ClientInstanceName="btnSalirPopExp" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popExportaProAnu.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnExpProAnu" runat="server" AutoPostBack="False" ClientInstanceName="btnExpProAnu" OnClick="btnExpProAnu_Click" Text="Exportar">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-file-excel-o"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonExportarPresupuestoAnual_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>

                                    <dx:BootstrapPopupControl ID="popExportaProAnuMasivo" runat="server" Width="600px" ClientInstanceName="popExportaProAnuMasivo"
                                        OnCallback="popExportaProAnuMasivo_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmExportaProAnuMasivo" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbAnioPopExpProAnuMas" runat="server" ClientInstanceName="cbAnioPopExpProAnuMas" TextField="nombre" ValueField="indice">
                                                                       <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioPopExpProAnuMas_SelectedIndexChanged" />
                                                                   </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMonedaPopExpProAnuMas" runat="server" ClientInstanceName="cbMonedaPopExpProAnuMas" TextField="descripcion" ValueField="idMoneda">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        
                                                        <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <div class="form-group">
                                                                        <dx:BootstrapButton ClientInstanceName="btnSelectAllRows" Text="Todos" ToolTip="Seleccionar todos" runat="server" ClientSideEvents-Click="onSelectAllRowsClick" AutoPostBack="false">
                                                                            <CssClasses Icon="fa fa-check-square" />
                                                                            <SettingsBootstrap RenderOption="Primary" Sizing="Small"/>
                                                                        </dx:BootstrapButton>
                                                                        <dx:BootstrapButton ClientInstanceName="btnClearSelection" Text="Limpiar" ToolTip="Limpiar selección" runat="server" ClientSideEvents-Click="onClearSelectionClick" AutoPostBack="false">
                                                                            <CssClasses Icon="fa fa-trash-o" />
                                                                            <SettingsBootstrap RenderOption="Warning" Sizing="Small"/>
                                                                        </dx:BootstrapButton>
                                                                    </div>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <div class="row">
                                                                        <div class="card">
                                                                            <div class="card-body">
                                                                                <span id="info4" class="badge badge-secondary demo-label"></span>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                                
                                                <dx:BootstrapGridView ID="grvPopExpProAnuMas" ClientInstanceName="grvPopExpProAnuMas" runat="server" KeyFieldName="idProAnu" Width="100%"
                                                    OnCustomJSProperties="grvPopExpProAnuMas_CustomJSProperties" OnCustomCallback="grvPopExpProAnuMas_CustomCallback" OnDataBinding="grvPopExpProAnuMas_DataBinding"
                                                     >
                                                    <SettingsPager PageSize="7" AlwaysShowPager="True"></SettingsPager>
                                                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                    <ClientSideEvents Init="onUpdateSelection" SelectionChanged="onUpdateSelection" EndCallback="onUpdateSelection" />
                                                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="true" />
                                                    <Columns>
                                                        <dx:BootstrapGridViewCommandColumn ShowSelectCheckbox="True" Width="50px">
                                                        </dx:BootstrapGridViewCommandColumn>
                                                        <dx:BootstrapGridViewDataColumn FieldName="idProAnu" Caption="Código" Width="60px">
                                                            <Settings AllowHeaderFilter="False" ShowFilterRowMenu="False"/>
                                                        </dx:BootstrapGridViewDataColumn>
                                                        <dx:BootstrapGridViewDataColumn FieldName="descripcion" Caption="Presupuesto Anual" Width="300px" AdaptivePriority="1">
                                                            <Settings AutoFilterCondition="Contains" />
                                                        </dx:BootstrapGridViewDataColumn>
                                                        <dx:BootstrapGridViewDataColumn FieldName="grupo" Caption="Grupo Pre." Width="180px" AdaptivePriority="3">
                                                            <Settings AutoFilterCondition="Contains" />
                                                        </dx:BootstrapGridViewDataColumn>
                                                    </Columns>
                                                    <SettingsPager NumericButtonCount="6"></SettingsPager>
                                                </dx:BootstrapGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopExpProAnuMas" runat="server" AutoPostBack="false" ClientInstanceName="btnSalirPopExpProAnuMas" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popExportaProAnuMasivo.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnExpProAnuMas" runat="server" AutoPostBack="False" ClientInstanceName="btnExpProAnuMas" OnClick="btnExpProAnuMas_Click" Text="Exportar">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-file-excel-o"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonExportarPresupuestoAnualMasivo_Click" />
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
