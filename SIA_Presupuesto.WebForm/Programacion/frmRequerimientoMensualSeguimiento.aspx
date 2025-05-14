<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="frmRequerimientoMensualSeguimiento.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.frmRequerimientoMensualSeguimiento" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <h2> Seguimiento de Requerimiento Mensual de Bienes y Servicios <%--<small><dx:ASPxLabel ID="lblDescripcion" runat="server" Text="[Descripcion]"></dx:ASPxLabel></small>--%></h2>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            <%--<div class="x_content">
                                <dx:BootstrapButton ID="btnSalir" runat="server" ClientInstanceName="btnSalir" Text="Salir" AutoPostBack="False" Width="110">
                                    <CssClasses Control="btn btn-dark" Icon="fa fa-reply"/>
                                    <SettingsBootstrap Sizing="Small" />
                                    <ClientSideEvents Click="Presupuesto.BotonSalirRequerimientoMensualDet_Click" />
                                </dx:BootstrapButton>
                            </div>--%>

                            <div class="row">
                                <div class="x_content">
                                    <dx:BootstrapFormLayout runat="server" LayoutType="Vertical">
                                        <Items>
                                            <%--<dx:BootstrapLayoutGroup Caption="Presupuesto Anual" >
                                                <Items>
                                                    
                                                </Items>
                                            </dx:BootstrapLayoutGroup>--%>
                                            <dx:BootstrapLayoutItem Caption="Presupuesto" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="txtDesPresupuesto" ClientInstanceName="cbMoneda" runat="server" Text="Presupuesto" ReadOnly="true" />
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                            <dx:BootstrapLayoutItem Caption="Moneda" ColSpanLg="3" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                <CaptionSettings HorizontalAlign="Left" />
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" >
                                                        <dx:BootstrapComboBox ID="cbMoneda" ClientInstanceName="cbMoneda" runat="server" TextField="descripcion" ValueField="idMoneda" OnSelectedIndexChanged="cbMoneda_SelectedIndexChanged" AutoPostBack="true">
                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la moneda" SetFocusOnError="True">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <SettingsAdaptivity Mode="OnWindowInnerWidth" ModalDropDownCaption="Seleccione moneda" />
                                                        </dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                            <dx:BootstrapLayoutItem Caption="Mes" ColSpanLg="3" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                <CaptionSettings HorizontalAlign="Left" />
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" >
                                                        <dx:BootstrapComboBox ID="cbMes" ClientInstanceName="cbMes" runat="server" TextField="nombre" ValueField="indice" AutoPostBack="false" ReadOnly="true" ClientEnabled="false">
                                                        </dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                            <dx:BootstrapLayoutItem HorizontalAlign="Right" ShowCaption="False" ColSpanMd="12">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        
                                                        <dx:BootstrapButton ID="btnSalir" runat="server" ClientInstanceName="btnSalir" Text="Salir" AutoPostBack="False" Width="110">
                                                            <CssClasses Control="btn btn-dark" Icon="fa fa-reply"/>
                                                            <SettingsBootstrap Sizing="Small" />
                                                            <ClientSideEvents Click="Presupuesto.BotonSalirRequerimientoMensualDet_Click" />
                                                        </dx:BootstrapButton>
                                                        <%--<dx:BootstrapButton runat="server" Text="Salir" SettingsBootstrap-RenderOption="Link" AutoPostBack="false">
                                                            <ClientSideEvents Click="function(s, e) { document.location.reload(); }" />
                                                        </dx:BootstrapButton>--%>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                        </Items>
                                    </dx:BootstrapFormLayout>

                                    <dx:BootstrapPageControl runat="server" TabAlign="Justify">
                                        <TabPages>
                                            <dx:BootstrapTabPage Text="Requerimiento Mensual vs Presupuesto Mensual">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <dx:BootstrapButton ID="btnExportarExcel" runat="server" AutoPostBack="false" ClientInstanceName="btnExportarExcel" Text="Exportar Excel"  OnClick="btnExportarExcel_Click">
                                                            <CssClasses Control="btn btn-sm btn-info" Icon="glyphicon glyphicon-floppy-save" />
                                                            <ClientSideEvents Click="Presupuesto.BotonExportarExcelEvaluacion_Click" />
                                                        </dx:BootstrapButton>
                                                        <dx:ASPxPivotGrid ID="grvPivot" ClientInstanceName="grvPivot" runat="server" Width="100%" OptionsData-DataProcessingEngine="Optimized">
                                                            <Fields>
                                                                <dx:PivotGridField ID="fieldDesCuentaClase" Name="fieldDesCuentaClase" Area="RowArea" AreaIndex="0" Caption="Clase" FieldName="desCuentaClase">
                                                                </dx:PivotGridField>
                                                                <dx:PivotGridField ID="fieldDesArea" Name="fieldDesArea" Area="RowArea" AreaIndex="1" Caption="Area" FieldName="desArea">
                                                                </dx:PivotGridField>
                                                                <dx:PivotGridField ID="fieldDescripcion" Name="fieldDescripcion" Area="RowArea" AreaIndex="2" Caption="Descripción" FieldName="descripcion">
                                                                </dx:PivotGridField>
                                                                <dx:PivotGridField ID="fieldDesCuentaDivisionaria" Name="fieldDesCuentaDivisionaria" AreaIndex="3" Caption="Divisionaria" FieldName="desCuentaDivisionaria">
                                                                </dx:PivotGridField>
                                                                <dx:PivotGridField ID="fieldDesCuenta" Name="fieldDesCuenta" AreaIndex="4" Caption="Cuenta" FieldName="desCuenta">
                                                                </dx:PivotGridField>
                                                                <dx:PivotGridField ID="fieldCantidad" Name="fieldCantidad" AreaIndex="5" Caption="Cantidad" CellFormat-FormatString="{0:n2}" CellFormat-FormatType="Numeric" FieldName="cantidad">
                                                                </dx:PivotGridField>
                                                                <dx:PivotGridField ID="fieldEsPresupuestado" Name="fieldEsPresupuestado" AreaIndex="6" Caption="Estado" FieldName="esPresupuestado" >
                                                                </dx:PivotGridField>

                                                                <dx:PivotGridField ID="fieldImporte" Name="fieldImporte" Area="DataArea" AreaIndex="0" Caption="Importe" CellFormat-FormatString="{0:n2}" CellFormat-FormatType="Numeric" FieldName="importe">
                                                                    <CellStyle HorizontalAlign="Right">
                                                                    </CellStyle>
                                                                </dx:PivotGridField>
                                                                
                                                                <dx:PivotGridField ID="fieldProceso" Name="fieldProceso" Area="ColumnArea" AreaIndex="0" Caption="Proceso" FieldName="proceso">
                                                                </dx:PivotGridField>
                                                            </Fields>
                                                            <OptionsData DataProcessingEngine="LegacyOptimized" />
                                                            <OptionsCustomization CustomizationFormStyle="Excel2007" />
                                                            <OptionsView 
                                                                HorizontalScrollBarMode="Auto"
                                                                ShowColumnGrandTotalHeader="False" ShowColumnGrandTotals="False" ShowRowGrandTotalHeader="False" 
                                                                />
                                                            <OptionsFilter NativeCheckBoxes="False"/>
                                                        </dx:ASPxPivotGrid>
                                                        <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="grvPivot" Visible="False" />
                                                        <%--ShowRowTotals="False" ShowRowGrandTotals="False" ShowColumnTotals="False" ShowGrandTotalsForSingleValues="False"--%>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapTabPage>
                                            <dx:BootstrapTabPage Text="Presupuesto Mensual vs Ejecución">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <dx:BootstrapGridView ID="grvPresupuestoClase" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvPresupuestoClase" Width="100%" OnCustomCallback="grvPresupuestoClase_CustomCallback" OnStartRowEditing="grvPresupuestoClase_StartRowEditing" OnDataBinding="grvPresupuestoClase_DataBinding" KeyFieldName="numCuenta">
                                                            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
                                                            <SettingsBehavior AutoExpandAllGroups="true" />
                                                            <CssClasses Control="table table-striped table-bordered dt-responsive nowrap" />
                                                            <SettingsBootstrap Sizing="Small" Striped="true" />
                                                            <Settings ShowFooter="True" />
                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                            <Columns>
                                                                <dx:BootstrapGridViewTextColumn Caption="Clase" FieldName="numCuenta" VisibleIndex="0" Width="50px">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="desCuenta" VisibleIndex="1" Width="400px" AdaptivePriority="1">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Importe Pre." FieldName="importePre" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="2" Width="100px" AdaptivePriority="2">
                                                                    <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                    </PropertiesTextEdit>
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Importe Eje." FieldName="importeEje" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="3" Width="100px" AdaptivePriority="2">
                                                                    <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                    </PropertiesTextEdit>
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Saldo" FieldName="saldo" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="4" Width="100px" AdaptivePriority="2">
                                                                    <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                    </PropertiesTextEdit>
                                                                </dx:BootstrapGridViewTextColumn>
                                                            </Columns>
                                                            <TotalSummary>
                                                                <dx:ASPxSummaryItem FieldName="importePre" SummaryType="Sum" DisplayFormat="{0:n2}"/>
                                                                <dx:ASPxSummaryItem FieldName="importeEje" SummaryType="Sum" DisplayFormat="{0:n2}"/>
                                                                <dx:ASPxSummaryItem FieldName="saldo" SummaryType="Sum" DisplayFormat="{0:n2}"/>
                                                            </TotalSummary>
                                                            <SettingsSearchPanel ShowApplyButton="True" />
                                                            <SettingsPager PageSize="10" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                                            </SettingsPager>
                                                            <Templates>
                                                                <DetailRow>
                                                                    <dx:BootstrapGridView ID="grvPresupuestoDivisionaria" runat="server" KeyFieldName="numCuenta" ClientInstanceName="grvPresupuestoDivisionaria" Width="100%" AutoGenerateColumns="False" OnBeforePerformDataSelect="grvPresupuestoDivisionaria_BeforePerformDataSelect" OnDataBinding="grvPresupuestoDivisionaria_DataBinding">
                                                                        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                                                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                                        <SettingsBootstrap Sizing="Small" Striped="true" />
                                                                        <Columns>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Divisionaria" FieldName="numCuenta" VisibleIndex="0" Width="50px" AdaptivePriority="1">
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="desCuenta" VisibleIndex="1" Width="400px" AdaptivePriority="1">
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Importe Pre." FieldName="importePre" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="2" Width="100px" AdaptivePriority="2">
                                                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                </PropertiesTextEdit>
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Importe Eje." FieldName="importeEje" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="3" Width="100px" AdaptivePriority="2">
                                                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                </PropertiesTextEdit>
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Saldo" FieldName="saldo" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="4" Width="100px" AdaptivePriority="2">
                                                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                </PropertiesTextEdit>
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                        </Columns>
                                                                        <Templates>
                                                                            <DetailRow>
                                                                                <dx:BootstrapGridView ID="grvPresupuestoCuenta" runat="server" ClientInstanceName="grvPresupuestoCuenta" Width="100%" AutoGenerateColumns="False" KeyFieldName="numCuenta" OnBeforePerformDataSelect="grvPresupuestoCuenta_BeforePerformDataSelect">
                                                                                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                                                                                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                                                    <SettingsBootstrap Sizing="Small" Striped="true" />
                                                                                    <Columns>
                                                                                        <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" VisibleIndex="0" Width="50px">
                                                                                        </dx:BootstrapGridViewTextColumn>
                                                                                        <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="desCuenta" VisibleIndex="1" Width="400px" AdaptivePriority="1">
                                                                                        </dx:BootstrapGridViewTextColumn>
                                                                                        <dx:BootstrapGridViewTextColumn Caption="Importe Pre." FieldName="importePre" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="2" Width="100px" AdaptivePriority="2">
                                                                                            <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                            </PropertiesTextEdit>
                                                                                        </dx:BootstrapGridViewTextColumn>
                                                                                        <dx:BootstrapGridViewTextColumn Caption="Importe Eje." FieldName="importeEje" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="3" Width="100px" AdaptivePriority="2">
                                                                                            <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                            </PropertiesTextEdit>
                                                                                        </dx:BootstrapGridViewTextColumn>
                                                                                        <dx:BootstrapGridViewTextColumn Caption="Saldo" FieldName="saldo" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="4" Width="100px" AdaptivePriority="2">
                                                                                            <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                            </PropertiesTextEdit>
                                                                                        </dx:BootstrapGridViewTextColumn>
                                                                                    </Columns>
                                                                                    <Templates>
                                                                                        <DetailRow>
                                                                                            <dx:BootstrapGridView ID="grvMovimiento" runat="server" ClientInstanceName="grvMovimiento" Width="100%" AutoGenerateColumns="False" KeyFieldName="numCuenta" OnBeforePerformDataSelect="grvMovimiento_BeforePerformDataSelect">
                                                                                                <CssClasses HeaderRow="" Control="table table-striped table-bordered"/>
                                                                                                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                                                                <SettingsBootstrap Sizing="Small" Striped="true" />
                                                                                                <Settings ShowFooter="True" />
                                                                                                <Columns>
                                                                                                    <dx:BootstrapGridViewTextColumn Caption="Número" FieldName="numero" VisibleIndex="0" Width="60px">
                                                                                                    </dx:BootstrapGridViewTextColumn>
                                                                                                    <dx:BootstrapGridViewTextColumn Caption="Fecha Mov." FieldName="fechaMov" VisibleIndex="1" Width="100px" AdaptivePriority="1">
                                                                                                        <PropertiesTextEdit DisplayFormatString ="dd-MM-yyyy"></PropertiesTextEdit>
                                                                                                    </dx:BootstrapGridViewTextColumn>
                                                                                                    <dx:BootstrapGridViewTextColumn Caption="Glosa" FieldName="glosa" VisibleIndex="2" Width="400px" AdaptivePriority="1">
                                                                                                    </dx:BootstrapGridViewTextColumn>
                                                                                                    <dx:BootstrapGridViewTextColumn Caption="Importe" FieldName="importe" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="3" Width="100px" AdaptivePriority="2">
                                                                                                        <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                                        </PropertiesTextEdit>
                                                                                                    </dx:BootstrapGridViewTextColumn>
                                                                                                </Columns>
                                                                                                <TotalSummary>
                                                                                                    <dx:ASPxSummaryItem FieldName="importe" SummaryType="Sum" DisplayFormat="{0:n2}"/>
                                                                                                </TotalSummary>
                                                                                            </dx:BootstrapGridView>
                                                                                        </DetailRow>
                                                                                    </Templates>
                                                                                </dx:BootstrapGridView>
                                                                            </DetailRow>
                                                                        </Templates>
                                                                    </dx:BootstrapGridView>
                                                                </DetailRow>
                                                            </Templates>
                                                        </dx:BootstrapGridView>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapTabPage>
                                            <dx:BootstrapTabPage Text="Lista Requerimientos (Forebi/Forese)">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <dx:BootstrapGridView ID="grvForebise" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvForebise" Width="100%" OnCustomCallback="grvForebise_CustomCallback" OnStartRowEditing="grvForebise_StartRowEditing" OnDataBinding="grvForebise_DataBinding" KeyFieldName="id">
                                                            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
                                                            <SettingsBehavior AutoExpandAllGroups="true" />
                                                            <CssClasses Control="table table-striped table-bordered dt-responsive nowrap" />
                                                            <SettingsBootstrap Sizing="Small" Striped="true" />
                                                            <Settings ShowFooter="True" />
                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                            <Columns>
                                                                <dx:BootstrapGridViewTextColumn Caption="Número" FieldName="numero" VisibleIndex="0" Width="80px">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Fecha" FieldName="fechaEmision" VisibleIndex="1" Width="90px">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Dirección" FieldName="desDireccion" VisibleIndex="2" Width="250px" AdaptivePriority="1">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="SubDirección" FieldName="desSubDireccion" VisibleIndex="3" Width="250px" AdaptivePriority="1">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Importe Cert." FieldName="importeCertificacion" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="4" Width="100px" AdaptivePriority="2">
                                                                    <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                    </PropertiesTextEdit>
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Importe Orden" FieldName="importeOrden" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="5" Width="100px" AdaptivePriority="2">
                                                                    <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                    </PropertiesTextEdit>
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Nro. Certificación" FieldName="nroCertificacion" VisibleIndex="6" Width="250px" AdaptivePriority="3">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Nro. Orden" FieldName="nroOrden" VisibleIndex="7" Width="250px" AdaptivePriority="3">
                                                                </dx:BootstrapGridViewTextColumn>
                                                                <dx:BootstrapGridViewTextColumn Caption="Estado" FieldName="desEstado" VisibleIndex="8" Width="200px" AdaptivePriority="3">
                                                                </dx:BootstrapGridViewTextColumn>
                                                            </Columns>
                                                            <TotalSummary>
                                                                <dx:ASPxSummaryItem FieldName="importeCertificacion" SummaryType="Sum" DisplayFormat="{0:n2}"/>
                                                                <dx:ASPxSummaryItem FieldName="importeOrden" SummaryType="Sum" DisplayFormat="{0:n2}"/>
                                                            </TotalSummary>
                                                            <SettingsSearchPanel ShowApplyButton="True" />
                                                            <SettingsPager PageSize="10" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                                            </SettingsPager>
                                                            <Templates>
                                                                <DetailRow>
                                                                    <dx:BootstrapGridView ID="grvForebiseDetalle" runat="server" ClientInstanceName="grvForebiseDetalle" KeyFieldName="id" Width="100%" AutoGenerateColumns="False" OnBeforePerformDataSelect="grvForebiseDetalle_BeforePerformDataSelect" > <%--OnDataBinding="grvPresupuestoDivisionaria_DataBinding"--%>
                                                                        <CssClasses HeaderRow="" Control="table table-striped table-bordered"/>
                                                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                                        <SettingsBootstrap Sizing="Small" Striped="true" />
                                                                        <Columns>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" VisibleIndex="0" Width="50px" AdaptivePriority="1">
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Descripción Cuenta" FieldName="desCuenta" VisibleIndex="1" Width="350px" AdaptivePriority="1">
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcionDetalle" VisibleIndex="2" Width="400px" AdaptivePriority="2">
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="unidad" VisibleIndex="3" Width="150px" AdaptivePriority="1">
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                            <dx:BootstrapGridViewTextColumn Caption="Cantidad" FieldName="cantidad" UnboundExpression="{0:n}" UnboundType="Decimal" VisibleIndex="4" Width="100px" AdaptivePriority="2">
                                                                                <PropertiesTextEdit DisplayFormatString="{0:n}">
                                                                                </PropertiesTextEdit>
                                                                            </dx:BootstrapGridViewTextColumn>
                                                                        </Columns>
                                                                        
                                                                    </dx:BootstrapGridView>
                                                                </DetailRow>
                                                            </Templates>
                                                        </dx:BootstrapGridView>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapTabPage>
                                        </TabPages>
                                    </dx:BootstrapPageControl>
                                </div>
                            </div>
                         
                        </div>
                    </div>
                </div>        
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
