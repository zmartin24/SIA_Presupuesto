<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaEvaluacionMensualPresupuesto.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaEvaluacionMensualPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
     <script type="text/javascript">
         function onSelectAllRowsClick() {
             grvPresupuestoAnualEvaRea.SelectRows();
         }
         function onSelectAllRowsOnPageClick() {
             grvPresupuestoAnualEvaRea.SelectAllRowsOnPage();
         }
         function onClearSelectionClick() {
             grvPresupuestoAnualEvaRea.UnselectRows();
         }
         function onUpdateSelection(s, e) {
             btnSelectAllRows.SetEnabled(s.GetSelectedRowCount() < s.cpVisibleRowCount);
             btnClearSelection.SetEnabled(s.GetSelectedRowCount() > 0);
             btnPopExpEvaRea.SetEnabled(s.GetSelectedRowCount() > 0);
             /*btnSelectAllRowsOnPage.SetEnabled(s.GetSelectedKeysOnPage().length < s.GetVisibleRowsOnPage());*/
             
             $("#info4").html("Total Presupuesto seleccionado: " + s.GetSelectedRowCount());
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
                                <h2>Lista de Evaluación Mensuales de Presupuesto</h2>
                                <div class="clearfix"></div>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-group">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" Width="110">           
                                            <CssClasses Control="btn btn-app" Icon="fa fa-tasks" />
                                            <SettingsBootstrap Sizing="Small" />
                                            <ClientSideEvents Click="Presupuesto.BotonDetalleEvaluacionMensual_Click" />
                                        </dx:BootstrapButton>

                                        <dx:BootstrapButton ID="btnImprimir" runat="server" ClientInstanceName="btnImprimir" Text="Imprimir" AutoPostBack="false"  ToolTip="Reporte por Evaluación" Width="110">
                                            <%--<CssClasses Control="btn btn-info" Icon="fa fa-print" />--%>
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print" />
                                            <ClientSideEvents Click="Presupuesto.BotonPopImprimirEvaluacionMensual_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnConsolidado" runat="server" ClientInstanceName="btnConsolidado" Text="Consolidado Dir." AutoPostBack="false"  ToolTip="Consolidado Por Direcciones" Width="110">
                                            <%--<CssClasses Control="btn btn-info" Icon="fa fa-print"  />--%>
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonConsolidadoPorDireccionesEvaReajuste_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>

                                        <dx:BootstrapButton ID="btnImprimirPorSub" runat="server" ClientInstanceName="btnImprimirPorSub" Text="Resumen Subdir." AutoPostBack="false"  ToolTip="Resumen por Subdireccion" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonResumenPorSubdireccionesEvaReajuste_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>

                                        <dx:BootstrapButton ID="btnPopImprimirEjePreMen" runat="server" ClientInstanceName="btnPopImprimirEjePreMen" Text="Ejecución Men." AutoPostBack="false"  ToolTip="Ejecución de presupuesto mensual" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonPopImprimirEjePreMen_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>

                                        <dx:BootstrapButton ID="btnPopImprimirEjePreMenFec" runat="server" ClientInstanceName="btnPopImprimirEjePreMenFec" Text="Eje. Men. Fec." AutoPostBack="false"  ToolTip="Ejecución de presupuesto mensual por fechas" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonPopImprimirEjePreMenFec_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>

                                        <dx:BootstrapButton ID="btnImprimirCalendario" runat="server" ClientInstanceName="btnImprimirCalendario" Text="Imprimir Cal." AutoPostBack="false"  ToolTip="Imprimir Calendario" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonCalendarioPresAnualEvaReajuste_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>

                                        <dx:BootstrapButton ID="btnImprimirSalGru" runat="server" ClientInstanceName="btnImprimirSalGru" Text="Imprimir Sal." AutoPostBack="false"  ToolTip="Imprimir Saldo por Grupo" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonPopImprimirSalGru_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>
                                            
                                        <%--Botones de exportación--%>
                                        <dx:BootstrapButton ID="btnExpoEva" runat="server" ClientInstanceName="btnExpoEva" Text="Exportar Eva. Men." AutoPostBack="false"  ToolTip="Exportar Evaluación Mensual" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-file-excel-o"  />
                                            <ClientSideEvents Click="Presupuesto.BotonExportarEvaluacionMoneda_Click" />
                                            <SettingsBootstrap Sizing="Small" />
                                        </dx:BootstrapButton>
                                        
                                        <dx:BootstrapButton runat="server" Text="Exportar Eva. Rea." AutoPostBack="false"  ToolTip="Exportar Evaluación - Reajuste Mensual" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-file-excel-o"  />
                                            <ClientSideEvents Click="Presupuesto.BotonExportarEvaluacionReajuste_Click" />
                                            <SettingsBootstrap RenderOption="Primary" Sizing="Small" />
                                        </dx:BootstrapButton>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row">
                                    <div class="btn-toggle">
                                        <dx:BootstrapFormLayout ID="BootstrapFormLayout3" runat="server">
                                            <Items>
                                                <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="2" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapComboBox ID="cbAnio" runat="server" ClientInstanceName="cbAnio" TextField="nombre" ValueField="indice">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioEva_SelectedIndexChanged" />
                                                            </dx:BootstrapComboBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Mes" ColSpanLg="2" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapComboBox ID="cbMes" runat="server" ClientInstanceName="cbMes" TextField="nombre" ValueField="indice">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEva_SelectedIndexChanged" />
                                                            </dx:BootstrapComboBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                            </Items>
                                        </dx:BootstrapFormLayout>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="x_content">
                                    <dx:BootstrapGridView ID="grvEvaluacion" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvEvaluacion" KeyFieldName="idEvaMenPro" Width="100%" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding">
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True"/>
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />  
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idEvaMenPro" VisibleIndex="0" Width="5%">
                                                <Settings AutoFilterCondition="Contains" ShowFilterRowMenu="False"/>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Presupuesto Anual" FieldName="presupuestoAnual"  VisibleIndex="1" Width="250px" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>                                            
                                            <dx:BootstrapGridViewTextColumn FieldName="descripcion"  Width="35%" AdaptivePriority="1" Caption="Descripci&#243;n" VisibleIndex="2">
                                            <Settings AutoFilterCondition="Contains"></Settings>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Desde" FieldName="mesDesde" VisibleIndex="3" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Hasta" FieldName="mesHasta" VisibleIndex="4" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewDateColumn Caption="Fecha Emisión" FieldName="fechaEmision"  VisibleIndex="5" Width="12%" AdaptivePriority="2">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Moneda" FieldName="moneda"  VisibleIndex="7" AdaptivePriority="2">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvEvaluacion_OnGridSelectionChanged" />
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>
                                    <%--Popup Reporte de Impresión--%>
                                    <dx:BootstrapPopupControl ID="popImprimirEvaluacion" runat="server" Width="600px" ClientInstanceName="popImprimirEvaluacion"
                                        OnCallback="popImprimirEvaluacion_Callback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopImprimirEvaluacion" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Reporte" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbTipRep" runat="server" ClientInstanceName="cbTipRep" TextField="descripcion" ValueField="idTipRep">
                                                                   </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbAnioEvaImp" runat="server" ClientInstanceName="cbAnioEvaImp" TextField="nombre" ValueField="indice">
                                                                   </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        
                                                        <dx:BootstrapLayoutItem Caption="Mes" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbMesEvaImp" runat="server" ClientInstanceName="cbMesEvaImp" TextField="nombre" ValueField="indice">
                                                                   </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopImprimir" runat="server" AutoPostBack="false" ClientInstanceName="btnSalirPopImprimir" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popImprimirEvaluacion.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnPopImprimir" runat="server" AutoPostBack="False" ClientInstanceName="btnPopImprimir" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirEvaluacion_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popCalendarioAnualCon" runat="server" ClientInstanceName="popCalendarioAnualCon" CloseAction="None" CloseAnimationType="Fade"
                                            CloseOnEscape="True" Modal="True" ShowFooter="true" OnCallback="popCalendarioAnualCon_WindowCallback" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="300px">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopCalendarioAnualCon" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbAnioCon" runat="server" ClientInstanceName="cbAnioCon" TextField="nombre" ValueField="indice">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Evaluación" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesEvaCon" runat="server" ClientInstanceName="cbMesEvaCon"  TextField="nombre" ValueField="indice">
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaCon_SelectedIndexChanged" />
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Reajuste" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesReaCon" runat="server" ClientInstanceName="cbMesReaCon" TextField="nombre" ValueField="indice" ReadOnly="True">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Fuente Financiamiento" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbFueFinCon" runat="server" ClientInstanceName="cbFueFinCon" TextField="desRubro" ValueField="idFueFin">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirCon" runat="server" AutoPostBack="False" ClientInstanceName="btnSalirCon" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonSalirReporteConsolidadoEvaReajuste_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImpCon" runat="server" AutoPostBack="False" ClientInstanceName="btnImpCon" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirConsolidadoEvaReajuste_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                       </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" Width="300px" ClientInstanceName="popReporteDireccion" OnCallback="popReporteDireccion_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopReporteDireccion" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Grupo Presupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12" >
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbGruPre" runat="server" ClientInstanceName="cbGruPre" TextField="descripcion" ValueField="idGruPre" >
                                                                        <ValidationSettings  ErrorText="Seleccione el grupo" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbAnioSub" runat="server" ClientInstanceName="cbAnioSub"  TextField="nombre" ValueField="indice">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Evaluación" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesEvaSub" runat="server" ClientInstanceName="cbMesEvaSub" TextField="nombre" ValueField="indice">
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaSub_SelectedIndexChanged" />
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Reajuste" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesReaSub" runat="server" ClientInstanceName="cbMesReaSub" TextField="nombre" ValueField="indice" ReadOnly="True">
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
                                                <ClientSideEvents Click="Presupuesto.BotonSalirResumenPorSubdirEvaReajuste_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirResumenPorSubdirEvaReajuste_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                     </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popEjecucionPreMen" runat="server" Width="300px" ClientInstanceName="popEjecucionPreMen" OnCallback="popEjecucionPreMen_Callback" CloseAction="None"
                                        CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopEjecucionPreMen" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Grupo Presupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12" >
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbGruPreEje" runat="server" ClientInstanceName="cbGruPreEje" TextField="descripcion" ValueField="idGruPre" >
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbGruPreEje_SelectedIndexChanged" />
                                                                        <ValidationSettings  ErrorText="Seleccione el grupo" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Presupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbPreEje" runat="server" ClientInstanceName="cbPreEje"  TextField="descripcion" ValueField="idProAnu"
                                                                        OnCallback="cbPreEje_Callback" >
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbPreEje_SelectedIndexChanged" EndCallback="Presupuesto.CbPreEje_EndCallback"/>
                                                                        <ValidationSettings  ErrorText="Seleccione un presupuesto anual" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Subpresupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbSubPreEje" runat="server" ClientInstanceName="cbSubPreEje" TextField="descripcion" ValueField="idSubpresupuesto"
                                                                        OnCallback="cbSubPreEje_Callback">
                                                                        <ClientSideEvents EndCallback="Presupuesto.CbSubPreEje_EndCallback"/>
                                                                        <ValidationSettings  ErrorText="Seleccione un presupuesto mensual" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMonedaEje" runat="server" ClientInstanceName="cbMonedaEje" TextField="descripcion" ValueField="idMoneda" >
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopEje" runat="server" AutoPostBack="False" ClientInstanceName="btnSalirPopEje" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popEjecucionPreMen.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImpEje" runat="server" AutoPostBack="False" ClientInstanceName="btnImpEje" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirEjecucionPreMen_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                     </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popEjecucionPreMenFec" runat="server" Width="400px" ClientInstanceName="popEjecucionPreMenFec" CloseAction="None" 
                                        CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
                                        OnCallback="popEjecucionPreMenFec_Callback">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopEjecucionPreMenFec" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Desde" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12" >
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapDateEdit ID="cFecDesde_PreMenFec" runat="server" ClientInstanceName="cFecDesde_PreMenFec" PickerDisplayMode="Auto" EditFormat="Custom" EditFormatString="dd/MM/yyyy" UseMaskBehavior="true"
                                                                            MinDate="2018-01-01">
                                                                        <DateRangeSettings StartDateEditID="cFecDesde_PreMenFec"/>
                                                                    </dx:BootstrapDateEdit>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Hasta" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapDateEdit ID="cFecHasta_PreMenFec" runat="server" ClientInstanceName="cFecHasta_PreMenFec" PickerDisplayMode="Auto" EditFormat="Custom" EditFormatString="dd/MM/yyyy" UseMaskBehavior="true"
                                                                            MinDate="2018-01-01">
                                                                        <DateRangeSettings StartDateEditID="cFecDesde_PreMenFec"/>
                                                                    </dx:BootstrapDateEdit>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Grupo Presupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12" >
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbGruPre_PreMenFec" runat="server" ClientInstanceName="cbGruPre_PreMenFec" TextField="descripcion" ValueField="idGruPre" >
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbGruPre_PreMenFec_SelectedIndexChanged" />
                                                                        <ValidationSettings  ErrorText="Seleccione el grupo" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Presupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbPre_PreMenFec" runat="server" ClientInstanceName="cbPre_PreMenFec"  TextField="descripcion" ValueField="idProAnu"
                                                                        OnCallback="cbPre_PreMenFec_Callback">
                                                                        <ClientSideEvents EndCallback="Presupuesto.CbPre_PreMenFec_EndCallback"/>
                                                                        <ValidationSettings  ErrorText="Seleccione un presupuesto anual" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMoneda_PreMenFec" runat="server" ClientInstanceName="cbMoneda_PreMenFec" TextField="descripcion" ValueField="idMoneda" >
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopPreMenFec" runat="server" AutoPostBack="False" ClientInstanceName="btnSalirPopPreMenFec" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popEjecucionPreMenFec.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImpEjePreMenFec" runat="server" AutoPostBack="False" ClientInstanceName="btnImpEjePreMenFec" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirEjecucionPreMenFec_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                     </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popCalendarioAnual" runat="server" Width="300px" ClientInstanceName="popCalendarioAnual" OnCallback="popCalendarioAnual_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbAnioCal" runat="server" ClientInstanceName="cbAnioCal" TextField="nombre" ValueField="indice">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Fuente Financiamiento" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbFueFinCal" runat="server" ClientInstanceName="cbFueFinCal" TextField="desRubro" ValueField="idFueFin" >
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Evaluación" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesEvaCal" runat="server" ClientInstanceName="cbMesEvaCal" TextField="nombre" ValueField="indice">
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaCal_SelectedIndexChanged" />
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Reajuste" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesReaCal" runat="server" ClientInstanceName="cbMesReaCal" TextField="nombre" ValueField="indice" ReadOnly="True">
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
                                                <ClientSideEvents Click="Presupuesto.BotonSalirReporteCalendarioEvaReajuste_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImpCal" runat="server" AutoPostBack="False" ClientInstanceName="btnImpCal" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirCalendarioEvaReajuste_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popSaldoGrupo" runat="server" Width="300px" ClientInstanceName="popSaldoGrupo" OnCallback="popSaldoGrupo_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="frmPopSaldoGrupo" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="4" ColSpanMd="4" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbAnio_SalGru" runat="server" ClientInstanceName="cbAnio_SalGru"  TextField="nombre" ValueField="indice">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Evaluación" ColSpanLg="4" ColSpanMd="4" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesEva_SalGru" runat="server" ClientInstanceName="cbMesEva_SalGru" TextField="nombre" ValueField="indice">
                                                                        <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEva_SalGru_SelectedIndexChanged" />
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Reajuste" ColSpanLg="4" ColSpanMd="4" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMesRea_SalGru" runat="server" ClientInstanceName="cbMesRea_SalGru" TextField="nombre" ValueField="indice" ReadOnly="True">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalir_popSaldoGrupo" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir_popSaldoGrupo" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popSaldoGrupo.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImp_popSaldoGrupo" runat="server" AutoPostBack="False" ClientInstanceName="btnImp_popSaldoGrupo" Text="Imprimir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirEvaluacionSaldoPorGrupo_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                     </dx:BootstrapPopupControl>
                                    
                                    <%--Popup Reporte de Exportación--%>
                                    <dx:BootstrapPopupControl ID="popEvaluacionMoneda" runat="server" Width="300px" ClientInstanceName="popEvaluacionMoneda"
                                        OnCallback="popEvaluacionMoneda_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="BootstrapFormLayout5" runat="server" LayoutType="Vertical">
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
                                                                    <dx:BootstrapComboBox ID="cbMoneda" runat="server" ClientInstanceName="cbMoneda" >
                                                                        <Items>
                                                                            <dx:BootstrapListEditItem Text="SOLES" Value="63" />
                                                                            <dx:BootstrapListEditItem Text="DOLARES" Value="64" />
                                                                        </Items>
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                    </Items>
                                                </dx:BootstrapFormLayout>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        <FooterTemplate>
                                            <dx:BootstrapButton ID="btnSalirPopMon" runat="server" AutoPostBack="false" ClientInstanceName="btnSalirPopMon" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popEvaluacionMoneda.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnExpEva" runat="server" AutoPostBack="False" ClientInstanceName="btnExpEva" OnClick="btnExpEva_Click" Text="Exportar">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-file-excel-o"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonExportarEvaluacionMensual_Click" />
                                            </dx:BootstrapButton>
                                        </FooterTemplate>
                                    </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popEvaRea" runat="server" Width="600px" ClientInstanceName="popEvaRea"
                                        OnCallback="popEvaRea_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:BootstrapFormLayout ID="bfrmEvaRea" runat="server" LayoutType="Vertical">
                                                    <Items>
                                                        <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbAnioEvaRea" runat="server" ClientInstanceName="cbAnioEvaRea" TextField="nombre" ValueField="indice">
                                                                       <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioEvaRea_SelectedIndexChanged" />
                                                                   </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:BootstrapComboBox ID="cbMonedaEvaRea" runat="server" ClientInstanceName="cbMonedaEvaRea" TextField="descripcion" ValueField="idMoneda">
                                                                    </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Evaluación" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbMesEvaReaEva" runat="server" ClientInstanceName="cbMesEvaReaEva" TextField="nombre" ValueField="indice">
                                                                       <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaReaEva_SelectedIndexChanged" />
                                                                   </dx:BootstrapComboBox>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:BootstrapLayoutItem>
                                                        <dx:BootstrapLayoutItem Caption="Mes Rejuste" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                   <dx:BootstrapComboBox ID="cbMesEvaReaRea" runat="server" ClientInstanceName="cbMesEvaReaRea" TextField="nombre" ValueField="indice" ReadOnly="True">
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
                                                
                                                <dx:BootstrapGridView ID="grvPresupuestoAnualEvaRea" ClientInstanceName="grvPresupuestoAnualEvaRea" runat="server" KeyFieldName="idProAnu" Width="100%"
                                                    OnCustomJSProperties="GridViewSelectionAPI_CustomJSProperties" OnCustomCallback="grvPresupuestoAnualEvaRea_CustomCallback" OnDataBinding="grvPresupuestoAnualEvaRea_DataBinding"
                                                     >
                                                    <SettingsPager PageSize="7" AlwaysShowPager="True"></SettingsPager>
                                                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                    <ClientSideEvents Init="onUpdateSelection" SelectionChanged="onUpdateSelection" EndCallback="onUpdateSelection" />
                                                    <%--<ClientSideEvents Init="onUpdateSelection" FocusedRowChanged="onUpdateSelection" SelectionChanged="onUpdateSelection" EndCallback="onUpdateSelection" />--%>
                                                    <%--<SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true"/>--%>
                                                    <%--<SettingsBehavior AllowSelectSingleRowOnly="true" ProcessSelectionChangedOnServer="true" />--%>
                                                    <%--<Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Visible" />--%>
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
                                            <dx:BootstrapButton ID="btnSalirPopExpRea" runat="server" AutoPostBack="false" ClientInstanceName="btnSalirPopExpRea" Text="Cancelar">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                <ClientSideEvents Click="function(s, e) { popEvaRea.Hide(); }" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnPopExpEvaRea" runat="server" AutoPostBack="False" ClientInstanceName="btnPopExpEvaRea" OnClick="btnPopExpEvaRea_Click" Text="Exportar">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-file-excel-o"></CssClasses>
                                                <ClientSideEvents Click="Presupuesto.BotonExportarEvaluacionReajusteMensual_Click" />
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
