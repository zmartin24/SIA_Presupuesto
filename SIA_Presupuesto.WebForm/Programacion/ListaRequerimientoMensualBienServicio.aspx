<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaRequerimientoMensualBienServicio.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.ListaRequerimientoMensualBienServicio" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onCustomButtonClick(s, e) {
            alert("The custom button " + e.buttonID + " has been clicked (row index: " + e.visibleIndex + ")");
            //alert("Hola");
        }
        function onSelectAllRowsClick() {
            //var tipoReq = cbTipoRequerimiento.GetValue().toString();
            //var anio = seAnio.GetNumber().toString();
            //var mes = cbMesRegReqMensual.GetValue().toString();

            //var idArea = '0';
            //if (cbAreaReqMensual.GetValue() != null)
            //    idArea = cbAreaReqMensual.GetValue().toString();

            //console.log('idArea', idArea);

            //var parametro = tipoReq + "|" + anio + "|" + mes + "|" + idArea;
            //grvRequerimientoBienServicio.PerformCallback(parametro);

            grvRequerimientoBienServicio.SelectRows();
        }
        function onSelectAllRowsOnPageClick() {
            grvRequerimientoBienServicio.SelectAllRowsOnPage();
            //console.log('cbAreaReqMensual', cbAreaReqMensual.GetValue().toString());
        }
        function onClearSelectionClick() {
            grvRequerimientoBienServicio.UnselectRows();
        }
        function onUpdateSelection(s, e) {
            btnSelectAllRows.SetEnabled(s.GetSelectedRowCount() < s.cpVisibleRowCount);
            btnClearSelection.SetEnabled(s.GetSelectedRowCount() > 0);
            //btnPopExpEvaRea.SetEnabled(s.GetSelectedRowCount() > 0);

            $("#info-Seleccion").html("Total requerimiento seleccionado: " + s.GetSelectedRowCount());
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
                                <h4> Lista de Requerimientos Mensuales de Bienes y Servicios </h4>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="well" style="overflow: auto">
                                        <div class="btn-toggle">
                                            <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevo" Text="Nuevo" Width="110">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-plus-circle"/>
                                                <ClientSideEvents Click="Presupuesto.BotonNuevoRequerimientoMensualGeneral_Click" />
                                                <SettingsBootstrap Sizing="Small" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnClona" runat="server" AutoPostBack="False" ClientInstanceName="btnClona" Text="Clonar" Width="110">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-copy"/>
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonClonarRequerimientoMensualGeneral_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnEditar" runat="server" AutoPostBack="False" ClientInstanceName="btnEditar" Text="Editar" Width="110">
                                                <CssClasses Control="btn btn-success" Icon="fa fa-edit" />
                                                <ClientSideEvents Click="Presupuesto.BotonEditarRequerimientoMensualGeneral_Click" />
                                                <SettingsBootstrap Sizing="Small" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnAnular" runat="server" AutoPostBack="False" ClientInstanceName="btnAnular" Text="Anular" Width="110">
                                                <CssClasses Control="btn btn-danger" Icon="fa fa-remove"/>
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonAnularRequerimientoMensualGeneral_Click" />
                                            </dx:BootstrapButton>
                                            
                                            <dx:BootstrapButton ID="btnAprobar" runat="server" AutoPostBack="False" ClientInstanceName="btnAprobar" Text="Aprobar" ToolTip="Aprobar requerimiento mensual" Width="110" OnClick="btnAprobar_Click">
                                                <CssClasses Control="btn btn-success" Icon="fa fa-check-circle" />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonAprobarRequerimientoMensualGeneral_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnVolver" runat="server" AutoPostBack="False" ClientInstanceName="btnVolver" Text="Vol. Est." ToolTip="Volver a estado registrado" Width="110" OnClick="btnVolver_Click">
                                                <CssClasses Control="btn btn-dark" Icon="fa fa-reply" />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonVolverEstadoRequerimientoMensualGeneral_Click" />
                                            </dx:BootstrapButton>

                                            <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" Width="110">
                                                <ClientSideEvents Click="Presupuesto.BotonDetalleRequerimientoMensualGeneral_Click" />
                                                <CssClasses Control="btn btn-warning" Icon="fa fa-tasks" />
                                                <SettingsBootstrap Sizing="Small" />
                                            </dx:BootstrapButton>

                                            <dx:BootstrapButton ID="btnSeguimiento" runat="server" AutoPostBack="False" ClientInstanceName="btnSeguimiento" Text="Seg." ToolTip="Seguimiento de requerimiento" Width="110">
                                                <ClientSideEvents Click="Presupuesto.BotonRequerimientoMensualSeguimiento_Click" />
                                                <CssClasses Control="btn btn-info" Icon="fa fa-bar-chart" />
                                                <SettingsBootstrap Sizing="Small" />
                                            </dx:BootstrapButton>

                                            <dx:BootstrapButton ID="btnImprimir" runat="server" ClientInstanceName="btnImprimir" Text="Imprimir" AutoPostBack="False" Width="110">
                                                <CssClasses Control="btn btn-info" Icon="fa fa-print"  />
                                                <SettingsBootstrap Sizing="Small" />
                                                <ClientSideEvents Click="Presupuesto.BotonImprimirRequerimientoMensualGeneral_Click" />
                                            </dx:BootstrapButton>
                                            <dx:BootstrapButton ID="btnImprimirDireccion" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirDireccion" Text="Imp. por Dir." ToolTip="Imprimir por Dirección" Width="110">
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
                                                            <dx:BootstrapComboBox ID="cbAnioListado" runat="server" ClientInstanceName="cbAnioListado" TextField="nombre" ValueField="indice">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAnioListado_SelectedIndexChanged" />
                                                            </dx:BootstrapComboBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                                <dx:BootstrapLayoutItem Caption="Mes" ColSpanLg="2" ColSpanMd="4" ColSpanSm="6" ColSpanXs="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server" >
                                                            <dx:BootstrapComboBox ID="cbMesListado" runat="server" ClientInstanceName="cbMesListado" TextField="nombre" ValueField="indice">
                                                                <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesListado_SelectedIndexChanged" />
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
                                    <dx:BootstrapGridView ID="grvRequerimientoMensual" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvRequerimientoMensual" KeyFieldName="idReqMenBieSer" 
                                        OnCustomCallback="grvRequerimientoMensual_CustomCallback" OnDataBinding="grvRequerimientoMensual_DataBinding" 
                                        OnCustomSummaryCalculate="GridViewCustomSummary_CustomSummaryCalculate" OnCustomUnboundColumnData="GridViewCustomSummary_CustomUnboundColumnData"
                                        Width="100%" EnableCallbackAnimation="True" >
                                        <SettingsBootstrap Sizing="Small" Striped="True" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" ShowFooter="True" />
                                        <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="True" AutoExpandAllGroups="true" SortMode="Custom"/>
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idReqMenBieSer" VisibleIndex="0" Width="60px">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Tipo" FieldName="desTipo" VisibleIndex="1" Width="105" HorizontalAlign="Left" >
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="2" Width="25%" AdaptivePriority="1">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>                                                
                                            <dx:BootstrapGridViewTextColumn Caption="Area" FieldName="desArea" VisibleIndex="3" Width="12%" AdaptivePriority="1">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Subdirección" FieldName="desSubdireccion" VisibleIndex="4" Width="12%" AdaptivePriority="1">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Dirección" FieldName="desDireccion" VisibleIndex="5" Width="15%">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewDateColumn Caption="Fecha Emisión" FieldName="fechaEmision" VisibleIndex="6" Width="100" HorizontalAlign="Center" AdaptivePriority="2">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewDateColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Moneda" FieldName="moneda" VisibleIndex="7" Width="40px" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Total" FieldName="total" VisibleIndex="8" Width="120px" AdaptivePriority="2">
                                                <CssClasses HeaderCell="column-title" />
                                                <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Estado" FieldName="desEstado" VisibleIndex="9" Width="15%" AdaptivePriority="3">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Presupuesto" FieldName="desProAnu" VisibleIndex="9" Width="25%" AdaptivePriority="3">
                                                <CssClasses HeaderCell="column-title" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Estado" FieldName="estado" VisibleIndex="10" Width="15%" Visible="false">
                                                <CssClasses HeaderCell="column-title" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="IdMoneda" FieldName="idMoneda" VisibleIndex="10" Width="15%" Visible="false">
                                                <CssClasses HeaderCell="column-title" />
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <%--<dx:ASPxSummaryItem FieldName="descripcion" SummaryType="Count" DisplayFormat="Cant.={0:n0}" />--%>
                                            <dx:ASPxSummaryItem FieldName="total" ShowInColumn="Total" SummaryType="Custom" DisplayFormat="{0:n2}"/>
                                        </TotalSummary>
                                        <GroupSummary>
                                            <dx:ASPxSummaryItem FieldName="total" SummaryType="Sum" />
                                        </GroupSummary>
                                        <FormatConditions>
                                            <dx:GridViewFormatConditionHighlight FieldName="estado" Expression="[estado] = 10" Format="GreenFillWithDarkGreenText" ApplyToRow="true" />
                                            <dx:GridViewFormatConditionHighlight FieldName="estado" Expression="[estado] = 59" Format="YellowFillWithDarkYellowText" ApplyToRow="true" />
                                        </FormatConditions>
                                        <SettingsPager NumericButtonCount="6"></SettingsPager>
                                        <ClientSideEvents SelectionChanged="Presupuesto.GrvRequerimientoMensual_OnGridSelectionChanged" />
                                        <SettingsSearchPanel ShowApplyButton="True" />
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>
                                </div>
                            </div>
                            <%--Emergentes--%>
                            <div class="x_content">
                                <%--Registro y Actualización de Cabecera--%>
                                <dx:BootstrapPopupControl ID="popRequerimientoMensual" runat="server" Width="800px" ClientInstanceName="popRequerimientoMensual" CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popRequerimientoMensual_WindowCallback" AllowDragging="true">
                                <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="800px" MinWidth="300px" />                                  
                                    <ContentCollection>
                                        <dx:ContentControl runat="server">
                                            <dx:BootstrapFormLayout ID="ASPxFormLayout1" runat="server">
                                                <Items>
                                                    <%--<dx:BootstrapLayoutGroup Caption="Información del Requerimiento">
                                                        <Items>--%>
                                                            <dx:BootstrapLayoutItem Caption="Tipo" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                                <CaptionSettings HorizontalAlign="Left" />
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                        <dx:BootstrapComboBox ID="cbTipoRequerimiento" runat="server" ClientInstanceName="cbTipoRequerimiento" TextField="descripcion" ValueField="codigo"
                                                                            OnCallback="cbTipoRequerimiento_Callback" >
                                                                            <%--<ClientSideEvents SelectedIndexChanged="Presupuesto.CbTipoRequerimiento_SelectedIndexChanged" EndCallback="Presupuesto.CbTipoRequerimiento_EndCallback"/>--%>
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione el tipo de requerimiento" SetFocusOnError="True">
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
                                                            <dx:BootstrapLayoutItem Caption="Año" >
                                                                <CaptionSettings HorizontalAlign="Left" />                                                                
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                        <dx:BootstrapSpinEdit ID="seAnio" runat="server" ClientInstanceName="seAnio" CssClasses-Control="spinedit" >
                                                                        <CssClasses Control="spinedit"></CssClasses>
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Ingrese el año" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                            <ClientSideEvents NumberChanged="Presupuesto.SeAnio_NumberChanged" />
                                                                        </dx:BootstrapSpinEdit>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Mes">
                                                                <CaptionSettings HorizontalAlign="Left" />
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                        <dx:BootstrapComboBox ID="cbMesRegReqMensual" runat="server" ClientInstanceName="cbMesRegReqMensual" TextField="nombre" ValueField="indice">
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbMesRegReqMensual_SelectedIndexChanged" />
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione el mes" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            
                                                        <%--</Items>
                                                    </dx:BootstrapLayoutGroup>

                                                    <dx:BootstrapLayoutGroup Caption="Información de Dirección">
                                                        <Items>--%>
                                                            <dx:BootstrapLayoutItem Caption="Dirección" >
                                                                <CaptionSettings HorizontalAlign="Left" />                                                                
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                        <dx:BootstrapComboBox ID="cbDireccionReqMensual" runat="server" ClientInstanceName="cbDireccionReqMensual" TextField="desDireccion" ValueField="idDireccion">
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbDireccionReqMensual_SelectedIndexChanged" />
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Subdirección/Oficina">
                                                                <CaptionSettings HorizontalAlign="Left" />                                                                
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server" CssClass="col-md-6 col-sm-9 col-xs-12">
                                                                        <dx:BootstrapComboBox ID="cbSubdireccionReqMensual" runat="server" ClientInstanceName="cbSubdireccionReqMensual" TextField="desSubdireccion" ValueField="idSubdireccion"  OnCallback="cbSubdireccionReqMensual_Callback">
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbSubdireccionReqMensual_SelectedIndexChanged" EndCallback="Presupuesto.CbSubdireccionReqMensual_EndCallback" />
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
                                                                        <dx:BootstrapComboBox ID="cbAreaReqMensual" runat="server" ClientInstanceName="cbAreaReqMensual" TextField="desArea" ValueField="idArea"  OnCallback="cbAreaReqMensual_Callback">
                                                                            <ClientSideEvents SelectedIndexChanged="Presupuesto.CbAreaReqMensual_SelectedIndexChanged" EndCallback="Presupuesto.CbAreaReqMensual_EndCallback"  />
                                                                            <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione el área" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="Descripción" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapMemo ID="txtDescripcion" runat="server" ClientInstanceName="txtDescripcion">
                                                                            <ValidationSettings ValidationGroup="Validation" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapMemo>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        <%--</Items>
                                                    </dx:BootstrapLayoutGroup>--%>
                                                    
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
                                                                            <span id="info-Seleccion" class="badge badge-secondary demo-label"></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                </Items>
                                            </dx:BootstrapFormLayout>
                                            <dx:BootstrapGridView ID="grvRequerimientoBienServicio" ClientInstanceName="grvRequerimientoBienServicio" runat="server" EnableCallBacks="True" KeyFieldName="idReqBieSer" Width="100%"
                                                OnCustomJSProperties="GrvRequerimientoBienServicioAPI_CustomJSProperties" OnCustomCallback="GrvRequerimientoBienServicio_CustomCallback" OnDataBinding="GrvRequerimientoBienServicio_DataBinding"
                                                SettingsText-EmptyDataRow="No hay información para mostrar" Settings-ShowTitlePanel="true" SettingsText-Title="Seleccionar requerimiento anual">
                                                <SettingsPager PageSize="7" AlwaysShowPager="True" NextPageButton-Text="Siguiente" PrevPageButton-Text="Anterior" EnableAdaptivity="true">
                                                </SettingsPager>
                                                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                <ClientSideEvents Init="onUpdateSelection" SelectionChanged="onUpdateSelection" EndCallback="onUpdateSelection" />
                                                <Settings ShowFilterRow="false" ShowFilterRowMenu="True" ShowHeaderFilterButton="true"/>
                                                <SettingsBootstrap Sizing="Small" Striped="True" />
                                                <CssClasses Row="grid-nowrap-row" Control="grid-borderless" />
                                                <Columns>
                                                    <dx:BootstrapGridViewCommandColumn ShowSelectCheckbox="True" Width="50px">
                                                    </dx:BootstrapGridViewCommandColumn>
                                                    <dx:BootstrapGridViewDataColumn FieldName="idReqBieSer" Caption="Código" Width="60px">
                                                        <Settings AllowHeaderFilter="False" ShowFilterRowMenu="False"/>
                                                    </dx:BootstrapGridViewDataColumn>
                                                    <dx:BootstrapGridViewDataColumn FieldName="descripcion" Caption="Descripción Requerimiento" Width="400px" AdaptivePriority="1">
                                                        <Settings AutoFilterCondition="Contains" />
                                                    </dx:BootstrapGridViewDataColumn>
                                                </Columns>
                                                <SettingsPager NumericButtonCount="6"></SettingsPager>
                                                <%--settingsText.Pager.AllPagesText = "Todas las páginas";
                                                settingsText.Pager.NextPageText = "Siguiente";
                                                settingsText.Pager.PrevPageText = "Anterior";--%>
                                            </dx:BootstrapGridView>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                    <FooterTemplate>
                                        <dx:BootstrapButton ID="btnGrabar" runat="server" AutoPostBack="False" ClientInstanceName="btnGrabar" Text="Grabar" >
                                            <CssClasses Control="btn btn-primary" Icon="fa fa-save"></CssClasses>
                                            <ClientSideEvents Click="Presupuesto.BotonGuardarRequerimientoMensualGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="False" ClientInstanceName="btnCancelar" Text="Cancelar">
                                            <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                            <ClientSideEvents Click="Presupuesto.BotonCancelarRequerimientoMensualGeneral_Click" />
                                        </dx:BootstrapButton>
                                    </FooterTemplate>
                                </dx:BootstrapPopupControl>

                                <%--Reporte por Direcciones--%>
                                <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" Width="400px" ClientInstanceName="popReporteDireccion" 
                                                          CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" ShowFooter="true"
                                                          PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReporteDireccion_WindowCallback" AllowDragging="true">
                                    <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="400px" MinWidth="300px" />
                                    <ContentCollection>
                                        <dx:ContentControl runat="server">
                                            <dx:BootstrapFormLayout ID="ASPxFormLayout2" runat="server" LayoutType="Vertical">
                                                <Items>
                                                    <dx:BootstrapLayoutItem Caption="Dirección" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbDireccionReporte" runat="server" ClientInstanceName="cbDireccionReporte" TextField="desDireccion" ValueField="idDireccion">
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
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Tipo" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbTipoReporte" runat="server" ClientInstanceName="cbTipoReporte" SelectedIndex="0">
                                                                    <Items>
                                                                        <dx:BootstrapListEditItem Selected="True" Text="TODOS" Value="TOD" />
                                                                        <dx:BootstrapListEditItem Text="ADMINISTRATIVOS" Value="ADM" />
                                                                        <dx:BootstrapListEditItem Text="ERRADICACION" Value="ERR" />
                                                                    </Items>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Requerimiento" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbRequerimientoReporte" runat="server" ClientInstanceName="cbRequerimientoReporte" TextField="descripcion" ValueField="codigo">
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione requerimiento" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Año" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbAnioReporte" runat="server" ClientInstanceName="cbAnioReporte" TextField="nombre" ValueField="indice" SelectedIndex="0">
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione año" SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:BootstrapComboBox>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>
                                                    <dx:BootstrapLayoutItem Caption="Mes" ColSpanLg="6" ColSpanMd="6" ColSpanSm="12" ColSpanXs="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl runat="server">
                                                                <dx:BootstrapComboBox ID="cbMesReporte" runat="server" ClientInstanceName="cbMesReporte" TextField="nombre" ValueField="indice" SelectedIndex="0">
                                                                    <ValidationSettings ValidationGroup="Validation" ErrorText="Seleccione mes" SetFocusOnError="True">
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
                                            <ClientSideEvents Click="Presupuesto.BotonImprimirReporteMensual_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Salir">
                                            <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                            <ClientSideEvents Click="Presupuesto.BotonSalirReporteMensual_Click" />
                                        </dx:BootstrapButton>
                                    </FooterTemplate>
                                </dx:BootstrapPopupControl>                                
                                <dx:BootstrapPopupControl ID="popInformacion" runat="server" ClientInstanceName="popInformacion" ShowFooter="true" CloseAction="None"
                                    PopupHorizontalAlign="Center" PopupVerticalAlign="Middle" Width="500px">
                                    <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" MaxWidth="500px" MinWidth="300px" />
                                    <HeaderTemplate>
                                        <h4 class="text-primary">
                                            <span class="fa fa-info-circle"></span> Información
                                        </h4>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        
                                        <dx:BootstrapButton ID="btnAceptar" runat="server" AutoPostBack="False" ClientInstanceName="btnAceptar" Text="Aceptar" UseSubmitBehavior="false">
                                            <ClientSideEvents Click="function(s, e) { popInformacion.Hide(); }" />
                                            <SettingsBootstrap RenderOption="Primary" />
                                        </dx:BootstrapButton>
                                    </FooterTemplate>
                                    <ContentCollection>
                                        <dx:ContentControl>
                                            <p></p>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapPopupControl>
                                
                             </div>
                        </div>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
</asp:Content>
