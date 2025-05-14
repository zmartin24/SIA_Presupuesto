<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaReajusteMensualPresupuesto.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaReajusteMensualPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:BootstrapCallbackPanel ID="cpPrincipal" runat="server" Width="100%" ClientInstanceName="cpPrincipal" OnCallback="cpPrincipal_Callback">
        <ClientSideEvents EndCallback="Presupuesto.CpPrincipal_EndCallback" />
        <ContentCollection>
            <dx:ContentControl runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Lista Reajustes <small>Mensuales</small></h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <!-- content starts here -->
                                <div class="row">
                                    <div class="btn-group">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" ToolTip="Detalle" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-tasks" />
                                            <ClientSideEvents Click="Presupuesto.BotonDetalleReajusteGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimir" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimir" OnClick="btnImprimir_Click" Text="Exportar Excel" ToolTip="Exportar Excel" Width="110">
                                            <ClientSideEvents Click="Presupuesto.BotonExportarReajuste_Click" />
                                            <CssClasses Control="btn btn-app" Icon="fa fa-file-excel-o"  />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnConsolidado" runat="server" AutoPostBack="False" ClientInstanceName="btnConsolidado" Text="Consolidado Dir." ToolTip="Consolidado Por Direcciones" Width="110">
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                            <ClientSideEvents Click="Presupuesto.BotonConsolidadoPorDireccionesEvaReajuste_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimirPorSub" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirPorSub"  Text="Resumen Sub.Dir." ToolTip="Resumen por Subdireccion" Width="110">
                                            <ClientSideEvents Click="Presupuesto.BotonResumenPorSubdireccionesEvaReajuste_Click" />
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimirCalendario" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirCalendario" Text="Imprimir Cal." ToolTip="Imprimir Calendario" Width="110">
                                            <ClientSideEvents Click="Presupuesto.BotonCalendarioPresAnualEvaReajuste_Click" />
                                            <CssClasses Control="btn btn-app" Icon="fa fa-print"  />
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
                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioRea_SelectedIndexChanged" />
                                                        </dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                            <dx:BootstrapLayoutItem Caption="Mes" ColSpanLg="3" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <dx:BootstrapComboBox ID="cbMes" runat="server" ClientInstanceName="cbMes" TextField="nombre" ValueField="indice">
                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesRea_SelectedIndexChanged" />
                                                        </dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                        </Items>
                                    </dx:BootstrapFormLayout>
                                </div>
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvReajuste" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvReajuste" KeyFieldName="idReaMenPro" Width="100%" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding">
                                        <CssClasses Table="table table-striped table-bordered dt-responsive nowrap" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True"  />
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idReaMenPro" VisibleIndex="0" Width="5%">
                                                <Settings AutoFilterCondition="Contains" ShowFilterRowMenu="False"/>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Presupuesto Anual" FieldName="presupuestoAnual" VisibleIndex="1" Width="300px" AdaptivePriority="1">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn FieldName="descripcion" Width="35%" Caption="Descripci&#243;n" VisibleIndex="2" AdaptivePriority="1">
                                            <Settings AutoFilterCondition="Contains"></Settings>
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Mes Reajuste" FieldName="mesReajuste" VisibleIndex="3" AdaptivePriority="2">
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewDateColumn Caption="Fecha Emisión" FieldName="fechaEmision"  VisibleIndex="4" Width="10%" AdaptivePriority="2">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Moneda" FieldName="moneda"  VisibleIndex="5" AdaptivePriority="3">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <%--<dx:BootstrapGridViewDateColumn Caption="Fecha Aprob." FieldName="fechaAprobacion"  VisibleIndex="5">
                                                <PropertiesDateEdit DisplayFormatString="">
                                                </PropertiesDateEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>--%>
                                            
                                            <%--<dx:BootstrapGridViewTextColumn Caption="Año" FieldName="anio" VisibleIndex="7">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>--%>
                                        </Columns>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvReajuste_OnGridSelectionChanged" />
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>

                                    <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" Width="300px" ClientInstanceName="popReporteDireccion" OnCallback="popReporteDireccion_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <div class="modal-dialog modal-md">
                                                    <div class="modal-body">
                                                        <dx:BootstrapFormLayout ID="BootstrapFormLayout2" runat="server">
                                                            <Items>
                                                                <dx:BootstrapLayoutItem Caption="Grupo Presupuesto">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbGruPre" runat="server" ClientInstanceName="cbGruPre" TextField="descripcion" ValueField="idGruPre" Width="280px" >
                                                                                <%--<ClientSideEvents SelectedIndexChanged="Presupuesto.CbDir_SelectedIndexChanged" />--%>
                                                                                <ValidationSettings ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                                    <RequiredField IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Año">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbAnioSub" runat="server" ClientInstanceName="cbAnioSub"  TextField="nombre" ValueField="indice">
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Mes Evaluación">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbMesEvaSub" runat="server" ClientInstanceName="cbMesEvaSub" TextField="nombre" ValueField="indice">
                                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaSub_SelectedIndexChanged" />
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Mes Reajuste">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbMesReaSub" runat="server" ClientInstanceName="cbMesReaSub" TextField="nombre" ValueField="indice" ReadOnly="True">
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                            </Items>
                                                        </dx:BootstrapFormLayout>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Cancelar">
                                                            <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonSalirResumenPorSubdirEvaReajuste_Click" />
                                                        </dx:BootstrapButton>
                                                        <dx:BootstrapButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                                            <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonImprimirResumenPorSubdirEvaReajuste_Click" />
                                                        </dx:BootstrapButton>
                                                    </div>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:BootstrapPopupControl>

                                    <dx:BootstrapPopupControl ID="popCalendarioAnual" runat="server" Width="300px" ClientInstanceName="popCalendarioAnual"  OnCallback="popCalendarioAnual_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                    <div class="modal-dialog modal-md">
                                                        <div class="modal-body">
                                                        <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server">
                                                            <Items>
                                                                <dx:BootstrapLayoutItem Caption="Año">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbAnioCal" runat="server" ClientInstanceName="cbAnioCal" TextField="nombre" ValueField="indice">
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Mes Evaluación">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbMesEvaCal" runat="server" ClientInstanceName="cbMesEvaCal" TextField="nombre" ValueField="indice">
                                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaCal_SelectedIndexChanged" />
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Mes Reajuste">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbMesReaCal" runat="server" ClientInstanceName="cbMesReaCal" TextField="nombre" ValueField="indice" ReadOnly="True">
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Fuente Financiamiento">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbFueFinCal" runat="server" ClientInstanceName="cbFueFinCal" TextField="desRubro" ValueField="idFueFin" Width="280px" >
                                                                                <%--<ClientSideEvents SelectedIndexChanged="Presupuesto.CbDir_SelectedIndexChanged" />--%>
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                <dx:BootstrapLayoutItem Caption="Presupuesto Anual">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <dx:BootstrapComboBox ID="cbPresAnual" runat="server" ClientInstanceName="cbPresAnual" TextField="descripcion" ValueField="idProAnu">
                                                                            </dx:BootstrapComboBox>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:BootstrapLayoutItem>
                                                                </Items>
                                                        </dx:BootstrapFormLayout>
                                                        </div>
                                                        <div class="modal-footer">
                                                        <dx:BootstrapButton ID="btnSalirCal" runat="server" AutoPostBack="False" ClientInstanceName="btnSalirCal" Text="Cancelar">
                                                            <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonSalirReporteCalendarioEvaReajuste_Click" />
                                                        </dx:BootstrapButton>
                                                        <dx:BootstrapButton ID="btnImpCal" runat="server" AutoPostBack="False" ClientInstanceName="btnImpCal" Text="Imprimir">
                                                            <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonImprimirCalendarioEvaReajuste_Click" />
                                                        </dx:BootstrapButton>
                                                        
                                                        </div>
                                                        </div>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                    </dx:BootstrapPopupControl>
                                    <dx:BootstrapPopupControl ID="popCalendarioAnualCon" runat="server" ClientInstanceName="popCalendarioAnualCon" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True"  OnCallback="popCalendarioAnualCon_WindowCallback" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="300px">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <div class="modal-dialog modal-md">
                                                <div class="modal-body">
                                                    <dx:BootstrapFormLayout ID="BootstrapFormLayout4" runat="server">
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Año">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapComboBox ID="cbAnioCon" runat="server" ClientInstanceName="cbAnioCon" TextField="nombre" ValueField="indice">
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Mes Evaluación">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapComboBox ID="cbMesEvaCon" runat="server" ClientInstanceName="cbMesEvaCon"  TextField="nombre" ValueField="indice">
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesEvaCon_SelectedIndexChanged" />
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Mes Reajuste">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapComboBox ID="cbMesReaCon" runat="server" ClientInstanceName="cbMesReaCon" TextField="nombre" ValueField="indice" ReadOnly="True">
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Fuente Financiamiento">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapComboBox ID="cbFueFinCon" runat="server" ClientInstanceName="cbFueFinCon" TextField="desRubro" ValueField="idFueFin" Width="280px">
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapFormLayout>
                                                </div>
                                                <div class="modal-footer">
                                                    <dx:BootstrapButton ID="btnSalirCon" runat="server" AutoPostBack="False" ClientInstanceName="btnSalirCon" Text="Cancelar">
                                                        <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                        <ClientSideEvents Click="Presupuesto.BotonSalirReporteConsolidadoEvaReajuste_Click" />
                                                    </dx:BootstrapButton>
                                                    <dx:BootstrapButton ID="btnImpCon" runat="server" AutoPostBack="False" ClientInstanceName="btnImpCon" Text="Imprimir">
                                                        <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                        <ClientSideEvents Click="Presupuesto.BotonImprimirConsolidadoEvaReajuste_Click" />
                                                    </dx:BootstrapButton>
                                                       
                                                    </div>
                                                    </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:BootstrapPopupControl>
                                </div>
                                <!-- content ends here -->
                            </div>
                        </div>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
