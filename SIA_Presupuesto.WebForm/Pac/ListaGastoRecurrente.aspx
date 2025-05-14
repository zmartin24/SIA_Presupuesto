<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaGastoRecurrente.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Pac.ListaGastoRecurrente" %>
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
                                <h4>Lista Gastos Recurrentes</h4>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">
                                    <div class="btn-toggle">
                                        <dx:BootstrapButton ID="btnDetalle" runat="server" AutoPostBack="False" ClientInstanceName="btnDetalle" Text="Detalle" >
                                            <ClientSideEvents Click="Presupuesto.BotonDetalleGastoRecurrente_Click" />
                                            <CssClasses Control="btn btn-sm btn-primary" Icon="fa fa-tasks" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimir" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimir" Text="Imprimir Gasto Recurrente Grupo Cuenta">
                                            <CssClasses Control="btn btn-sm btn-info" Icon="fa fa-print"/>
                                            <ClientSideEvents Click="Presupuesto.BotonImprimirGasRecGeneral_Click" />
                                        </dx:BootstrapButton>
                                        <dx:BootstrapButton ID="btnImprimirDireccion" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirDireccion" Text="Imprimir Gasto Recurrente por Dirección">
                                            <CssClasses Control="btn btn-sm btn-info" Icon="fa fa-print"/>
                                            <ClientSideEvents Click="Presupuesto.BotonImprimirPacDireccion_Click" />
                                        </dx:BootstrapButton>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="x_content">
                                <div class="row">
                                    <div class="table-responsive">
                                        <dx:BootstrapGridView ID="grvGasRec" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvGasRec" Width="100%" EnableCallbackAnimation="True" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding" KeyFieldName="idGasRec">
                                            <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True">
                                            </SettingsPager>
                                            
                                            <SettingsBootstrap Sizing="Small" Striped="true" />
                                            <SettingsBehavior AllowClientEventsOnLoad="False" AllowSelectByRowClick="true"/>
                                            <Settings ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" />
                                            <Columns>
                                                <dx:BootstrapGridViewTextColumn Caption="Código" FieldName="idGasRec" VisibleIndex="0" Width="70px">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="2" Width="400px">
                                                </dx:BootstrapGridViewTextColumn>
                                                <dx:BootstrapGridViewTextColumn Caption="Año" FieldName="anio" VisibleIndex="3" Width="50px">
                                                    <CssClasses DataCell="hidden-xs" HeaderCell="hidden-xs" FilterCell="hidden-xs"></CssClasses>
                                                </dx:BootstrapGridViewTextColumn>
                                            </Columns>
                                            <ClientSideEvents SelectionChanged="Presupuesto.GrvRequerimiento_OnGridSelectionChanged" />
                                            <SettingsSearchPanel ShowApplyButton="True" />
                                        </dx:BootstrapGridView>
                                    </div>
                                </div>
                            </div>
                            <div class="x_content">
                                <!-- Large modal --> 
                                <dx:BootstrapPopupControl ID="popReporteDireccion" runat="server" ClientInstanceName="popReporteDireccion" AllowDragging="true" AllowResize="true"  MaxWidth="450px" MinWidth="330px" CloseAction="CloseButton" CloseAnimationType="Fade" CloseOnEscape="True" Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" OnCallback="popReporteDireccion_WindowCallback">
                                    <ContentCollection>
                                        <dx:ContentControl runat="server">
                                            <div class="modal-dialog modal-lg">
                                                <div class="modal-body">
                                                    <dx:BootstrapFormLayout ID="ASPxFormLayout2" runat="server" LayoutType="Vertical">
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Dirección:" ColSpanLg="12" ColSpanMd="12" ColSpanSm="12" ColSpanXs="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapComboBox ID="cbDir" runat="server" ClientInstanceName="cbDir" TextField="desDireccion" ValueField="idDireccion" OnCallback="cbDireccion_Callback">
                                                                            <ValidationSettings ErrorText="Seleccione direccionón" SetFocusOnError="True">
                                                                                <RequiredField IsRequired="True" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapFormLayout>
                                                </div>
                                                <div class="modal-footer"> 
                                                    <dx:BootstrapButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Salir">
                                                        <CssClasses Control="btn btn-danger" Icon="fa fa-close"></CssClasses>
                                                        <ClientSideEvents Click="Presupuesto.BotonSalirReporte_Click" />
                                                    </dx:BootstrapButton>
                                                    <dx:BootstrapButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                                            <CssClasses Control="btn btn-primary" Icon="fa fa-print"></CssClasses>
                                                            <ClientSideEvents Click="Presupuesto.BotonImprimirReporteGasRecDireccion_Click" />
                                                    </dx:BootstrapButton>
                                                </div>
                                            </div>
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
                <%--<dx:ASPxCallbackPanel ID="cpPrincipal" runat="server" Width="100%" ClientInstanceName="cpPrincipal" OnCallback="cpPrincipal_Callback">

                    <ClientSideEvents EndCallback="Presupuesto.CpPrincipal_EndCallback" />
                    <PanelCollection>
                     <dx:PanelContent runat="server">
                         <table style="width:100%">
                             <tr>
                                 <td style="text-align:center">
                                     <table class="auto-style1">
                                        <tr>
                                            <td colspan="4"><h3> LISTA GASTOS RECURRENTES</h3></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table class="auto-style2">
                                                    <tr>    
                                                        <td>
                                                            <dx:ASPxButton ID="btnDetalle" runat="server" ClientInstanceName="btnDetalle" Text="Detalle" OnClick="btnDetalle_Click">
                                                                <Image Url="~/Imagenes/Categories_16x16.png">
                                                                </Image>
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnImprimir" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimir" Text="Imprimir Gasto Recurrente Grupo Cuenta">
                                                                <Image Url="~/Imagenes/Print_16x16.png">
                                                                </Image>
                                                                <ClientSideEvents Click="Presupuesto.BotonImprimirGasRecGeneral_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnImprimirDireccion" runat="server" AutoPostBack="False" ClientInstanceName="btnImprimirDireccion" Text="Imprimir Gasto Recurrente por Dirección">
                                                                <Image Url="~/Imagenes/Print_16x16.png">
                                                                </Image>
                                                                <ClientSideEvents Click="Presupuesto.BotonImprimirPacDireccion_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                            
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <dx:ASPxGridView ID="grvGasRec" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvGasRec" KeyFieldName="idGasRec" Width="100%" OnCustomCallback="grvRequerimiento_CustomCallback" OnDataBinding="grvRequerimiento_DataBinding">
                                                    <SettingsPager PageSize="20" AlwaysShowPager="True">
                                                    </SettingsPager>
                                                    <Settings HorizontalScrollBarMode="Visible" ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" VerticalScrollableHeight="400" VerticalScrollBarMode="Auto" />
                                                    <SettingsBehavior AllowClientEventsOnLoad="False" AllowFocusedRow="True" />
                                                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true">
                                                        <AdaptiveDetailLayoutProperties>
                                                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
                                                        </AdaptiveDetailLayoutProperties>
                                                    </SettingsAdaptivity>
                                                    <EditFormLayoutProperties>
                                                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
                                                    </EditFormLayoutProperties>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="idGasRec" VisibleIndex="0" Width="60px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1" Width="80%">
                                                            <PropertiesTextEdit>
                                                                <Style HorizontalAlign="Justify">
                                                                </Style>
                                                            </PropertiesTextEdit>
                                                            <CellStyle HorizontalAlign="Justify">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Año" FieldName="anio" VisibleIndex="8" Width="15%">
                                                            <PropertiesTextEdit>
                                                                <Style HorizontalAlign="Center">
                                                                </Style>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>

                                                </dx:ASPxGridView>
                                            </td>
                                        </tr>
                                    </table>
                                        
                                     
                                     <dx:ASPxPopupControl ID="popReporteDireccion" runat="server" Width="300px" ClientInstanceName="popReporteDireccion" OnWindowCallback="popReporteDireccion_WindowCallback" CloseAction="None" CloseAnimationType="Fade" CloseOnEscape="True" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl runat="server">
                                                <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2">
                                                    <Items>
                                                        <dx:LayoutItem Caption="Dirección" ColSpan="2">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="cbDir" runat="server" ClientInstanceName="cbDir" TextField="desDireccion" ValueField="idDireccion" Width="280px" OnCallback="cbDireccion_Callback">
                                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="Seleccione la dirección" SetFocusOnError="True">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                     </Items>
                                                </dx:ASPxFormLayout>
                                                <dx:ASPxButton ID="btnImp" runat="server" AutoPostBack="False" ClientInstanceName="btnImp" Text="Imprimir">
                                                        <ClientSideEvents Click="Presupuesto.BotonImprimirReporteGasRecDireccion_Click" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnSalir" runat="server" AutoPostBack="False" ClientInstanceName="btnSalir" Text="Cancelar">
                                                    <ClientSideEvents Click="Presupuesto.BotonSalirReporte_Click" />
                                                </dx:ASPxButton>
                                                        </dx:PopupControlContentControl>
                                            </ContentCollection>
                                            </dx:ASPxPopupControl>
                                 </td>
                             </tr>
                          </table>
                     </dx:PanelContent>
                    </PanelCollection>

                </dx:ASPxCallbackPanel>--%>


</asp:Content>
