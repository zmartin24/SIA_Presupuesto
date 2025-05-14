<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="frmPresupuestoAnual.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.frmPresupuestoAnual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
    <script type="text/javascript">
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
                                <h2> Detale Presupuesto Anual <small><dx:ASPxLabel ID="lblDescripcion" runat="server" Text="[Descripcion]"></dx:ASPxLabel></small></h2>
                                <div class="clearfix"></div>
                                <dx:ASPxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:ASPxHiddenField>
                            </div>
                            
                            <div class="x_content">
                                <div class="row">
                                    <dx:BootstrapButton ID="btnSalir" runat="server" ClientInstanceName="btnSalir" OnClick="btnSalir_Click" Text="Salir">
                                        <CssClasses Control="btn btn-primary" Icon="fa fa-reply"/>                      
                                    </dx:BootstrapButton>
                                </div>
                                <hr />
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvPresupuesto" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvReqDet" KeyFieldName="idProAnuArea" Width="100%"
                                        OnRowUpdated="grvReqDet_RowUpdated" OnRowUpdating="grvReqDet_RowUpdating" OnRowValidating="grvReqDet_RowValidating" OnStartRowEditing="grvReqDet_StartRowEditing">
                                        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                                        
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" ShowFooter="True" VerticalScrollableHeight="535" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto"/>
                                        <SettingsBehavior AllowClientEventsOnLoad="False"/>
                                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" VisibleIndex="0" Width="80px" ReadOnly="True">
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1" Width="250px" ReadOnly="True">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Enero" FieldName="enero"  VisibleIndex="7" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Febrero" FieldName="febrero"  VisibleIndex="8" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Marzo" FieldName="marzo"  VisibleIndex="9" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Abril" FieldName="abril"  VisibleIndex="10" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Mayo" FieldName="mayo"  VisibleIndex="11" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Junio" FieldName="junio"  VisibleIndex="12" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Julio" FieldName="julio"  VisibleIndex="13" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Agosto" FieldName="agosto"  VisibleIndex="14" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Setiembre" FieldName="setiembre"  VisibleIndex="15" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Octubre" FieldName="octubre"  VisibleIndex="16" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Noviembre" FieldName="noviembre"  VisibleIndex="17" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Diciembre" FieldName="diciembre"  VisibleIndex="18" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Total" FieldName="total"  VisibleIndex="18" Width="80px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Area" FieldName="desArea"  VisibleIndex="4">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Subdirección" FieldName="desSubdireccion"  VisibleIndex="3">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Dirección" FieldName="desDireccion"  VisibleIndex="2">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuentaNivel1" GroupIndex="0"  SortIndex="0" SortOrder="Ascending" VisibleIndex="6">
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuentaNivel2" GroupIndex="1"  SortIndex="1" SortOrder="Ascending" VisibleIndex="5">
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="enero" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="febrero" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="marzo" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="abril" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="mayo" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="junio" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="julio" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="agosto" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="setiembre" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="octubre" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="noviembre" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="diciembre" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="total" DisplayFormat="{0:n2}" SummaryType="Sum" />
                                        </TotalSummary>
                                        <SettingsPager PageSize="20" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                        <%--<ClientSideEvents Init="Presupuesto.OnInit" EndCallback="Presupuesto.OnEndCallback" />--%>
                                        <Templates>
                                            <DetailRow>
                                                <dx:BootstrapGridView ID="grvDetalle" runat="server" AutoGenerateColumns="False" KeyFieldName="idProAnuDet" Width="100%" OnBeforePerformDataSelect="grvDetalle_BeforePerformDataSelect">
                                                    <Settings VerticalScrollBarMode="Auto"/>
                                                    <Columns>
                                                        <dx:BootstrapGridViewDataColumn Caption="Descripción" Settings-AllowDragDrop="False" MinWidth="150" MaxWidth="250" Width="250" VisibleIndex="0">
                                                            <DataItemTemplate>
                                                                <div class="x_content">
                                                                    <%--<h4>Horizontal labels</h4>--%>
                                                                    <p class="font-gray-dark" title="<%# Eval("descripcion") %>"><%# Eval("descripcion") %></p>
                                                                </div>
                                                                <%--<label title="<%# Eval("descripcion") %>" class="x_title"><%# Eval("descripcion") %></label>--%>
                                                            </DataItemTemplate>
                                                        </dx:BootstrapGridViewDataColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" Visible="false" VisibleIndex="0" Width="200px">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="Abreviado" VisibleIndex="1" Width="50px">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Cantidad" FieldName="cantidad" VisibleIndex="2" Width="50px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Precio" FieldName="precio" VisibleIndex="3" Width="50px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Enero" FieldName="enero" VisibleIndex="4" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Febrero" FieldName="febrero" VisibleIndex="5" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Marzo" FieldName="marzo" VisibleIndex="6" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Abril" FieldName="abril" VisibleIndex="7" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Mayo" FieldName="mayo" VisibleIndex="8" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Junio" FieldName="junio" VisibleIndex="9" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Julio" FieldName="julio" VisibleIndex="10" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Agosto" FieldName="agosto" VisibleIndex="11" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Setiembre" FieldName="setiembre" VisibleIndex="12" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Octubre" FieldName="octubre" VisibleIndex="13" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Noviembre" FieldName="noviembre" VisibleIndex="14" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Diciembre" FieldName="diciembre" VisibleIndex="15" Width="60px">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                    </Columns>
                                                </dx:BootstrapGridView>
                                            </DetailRow>
                                        </Templates>
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
