<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="frmReajusteMensualPresupuesto.aspx.cs" Inherits="SIA_Presupuesto.WebForm.Programacion.frmReajusteMensualPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
    <script type="text/javascript">
        function initMoreButton(s, e) {
            $(s.GetMainElement()).find(".more-info").click(function () {
                if (s.InCallback()) return;
                var $btn = $(this);
                s.GetRowValues($btn.attr("data-key"), 'descripcion;Abreviado', function (values) {
                    detailsModal.SetHeaderText("Detalle");
                    detailsModal.SetContentHtml(values[0] + " - " + values[1]);
                    detailsModal.Show();
                });
            });
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
                            <div class="x_title">
                                <h2>Detalle de Presupuesto<small>(Reajuste Mensual)</small></h2>
                                <div class="clearfix"></div>
                                <dx:AspxHiddenField ID="hdfValores" runat="server" ClientInstanceName="hdfValores">
                                </dx:AspxHiddenField>
                            </div>
                            <div class="x_content">
                                <!-- content starts here -->
                                <div class="row">
                                    <div class="btn-group">
                                        <dx:BootstrapButton ID="btnSalir" runat="server" ClientInstanceName="btnSalir" OnClick="btnSalir_Click" Text="Salir">
                                                <CssClasses Control="btn btn-primary" Icon="fa fa-reply"/>
                                        </dx:BootstrapButton>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row">
                                    <dx:BootstrapGridView ID="grvPresupuesto" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvPresupuesto" KeyFieldName="idReaMenArea" Width="100%">
                                        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" ShowFooter="True" VerticalScrollBarMode="Auto" VerticalScrollableHeight="600"/>
                                        <SettingsBehavior AutoExpandAllGroups="true" AllowEllipsisInText="true"/>
                                        <CssClasses Control="table table-striped table-bordered dt-responsive nowrap" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                                        <SettingsBootstrap Sizing="Small" Striped="true" />
                                        
                                        <SettingsEditing Mode="EditForm"></SettingsEditing>
                                        <Columns>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuenta" VisibleIndex="0" Width="75" ReadOnly="True" >
                                                <Settings AutoFilterCondition="BeginsWith" ShowFilterRowMenu="False"/>
                                            </dx:BootstrapGridViewTextColumn>                                            
                                            <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1" Width="200" ReadOnly="True" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Dirección" FieldName="desDireccion"  VisibleIndex="2" Width="120" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Subdirección" FieldName="desSubdireccion" Width="120" VisibleIndex="3" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Area" FieldName="desArea"  VisibleIndex="4" Width="120" AdaptivePriority="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuentaNivel1" GroupIndex="0"  SortIndex="0" SortOrder="Ascending" VisibleIndex="6">
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewTextColumn Caption="Cuenta" FieldName="numCuentaNivel2" GroupIndex="1"  SortIndex="1" SortOrder="Ascending" VisibleIndex="5">
                                                <Settings AutoFilterCondition="BeginsWith" />
                                            </dx:BootstrapGridViewTextColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Enero" FieldName="enero"  VisibleIndex="7" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Febrero" FieldName="febrero"  VisibleIndex="8" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Marzo" FieldName="marzo"  VisibleIndex="9" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Abril" FieldName="abril"  VisibleIndex="10" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Mayo" FieldName="mayo"  VisibleIndex="11" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Junio" FieldName="junio"  VisibleIndex="12" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Julio" FieldName="julio"  VisibleIndex="13" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Agosto" FieldName="agosto"  VisibleIndex="14" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Setiembre" FieldName="setiembre"  VisibleIndex="15" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Octubre" FieldName="octubre"  VisibleIndex="16" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Noviembre" FieldName="noviembre"  VisibleIndex="17" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Diciembre" FieldName="diciembre"  VisibleIndex="18" Width="90px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                            <dx:BootstrapGridViewSpinEditColumn Caption="Total" FieldName="total"  VisibleIndex="19" Width="100px">
                                                <PropertiesSpinEdit DisplayFormatString="n" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                </PropertiesSpinEdit>
                                                <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            </dx:BootstrapGridViewSpinEditColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="enero" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="febrero" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="marzo" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="abril" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="mayo" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="junio" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="julio" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="agosto" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="setiembre" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="octubre" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="noviembre" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="diciembre" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                            <dx:ASPxSummaryItem FieldName="total" DisplayFormat="{0:n2} " SummaryType="Sum" />
                                        </TotalSummary>
                                        <Templates>
                                            <DetailRow>
                                                <dx:BootstrapGridView ID="grvDetalle" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvDetalle" KeyFieldName="idReaMenArea" Width="100%" OnBeforePerformDataSelect="grvDetalle_BeforePerformDataSelect">
                                                    <Settings HorizontalScrollBarMode="Auto" />
                                                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" />
                                                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"></SettingsAdaptivity>
                                                    <SettingsBootstrap Sizing="Small" Striped="true" />
                                                    <Columns>
                                                        <dx:BootstrapGridViewDataColumn Caption="Descripción" Settings-AllowDragDrop="False" ToolTip="Ver Detalle" MinWidth="150" MaxWidth="300" Width="25%" VisibleIndex="0" AdaptivePriority="1">
                                                            <DataItemTemplate>
                                                                <button type="button" title="<%# Eval("descripcion") %>" class="btn btn-link more-info" data-key="<%# Container.VisibleIndex %>"><%# Eval("descripcion") %></button>
                                                            </DataItemTemplate>
                                                        </dx:BootstrapGridViewDataColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Descripción" FieldName="descripcion" Visible="false" VisibleIndex="0" MinWidth="150" MaxWidth="300" Width="25%" AdaptivePriority="1">
                                                            <Settings AutoFilterCondition="Contains" ShowFilterRowMenu="False" />
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Unidad" FieldName="Abreviado" VisibleIndex="1" Width="80px" AdaptivePriority="2">
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Cantidad" FieldName="cantidad" VisibleIndex="2" Width="50px" AdaptivePriority="3">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Precio" FieldName="precio" VisibleIndex="3" Width="50px" AdaptivePriority="4">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Enero" FieldName="enero" VisibleIndex="4" Width="60px" AdaptivePriority="5">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False"/>
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                                
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Febrero" FieldName="febrero" VisibleIndex="5" Width="60px" AdaptivePriority="6">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                                
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Marzo" FieldName="marzo" VisibleIndex="6" Width="60px" AdaptivePriority="7">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                                
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Abril" FieldName="abril" VisibleIndex="7" Width="60px" AdaptivePriority="8">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Mayo" FieldName="mayo" VisibleIndex="8" Width="60px" AdaptivePriority="9">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Junio" FieldName="junio" VisibleIndex="9" Width="60px" AdaptivePriority="10">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Julio" FieldName="julio" VisibleIndex="10" Width="60px" AdaptivePriority="11">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Agosto" FieldName="agosto" VisibleIndex="11" Width="60px" AdaptivePriority="12">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Setiembre" FieldName="setiembre" VisibleIndex="12" Width="60px" AdaptivePriority="13">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Octubre" FieldName="octubre" VisibleIndex="13" Width="60px" AdaptivePriority="14">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Noviembre" FieldName="noviembre" VisibleIndex="14" Width="60px" AdaptivePriority="15">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        <dx:BootstrapGridViewSpinEditColumn Caption="Diciembre" FieldName="diciembre" VisibleIndex="15" Width="60px" AdaptivePriority="16">
                                                            <PropertiesSpinEdit DisplayFormatString="n">
                                                            </PropertiesSpinEdit>
                                                            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                        </dx:BootstrapGridViewSpinEditColumn>
                                                        
                                                    </Columns>
                                                    <ClientSideEvents Init="initMoreButton" EndCallback="initMoreButton" />
                                                </dx:BootstrapGridView>
                                            </DetailRow>
                                        </Templates>
                                        <SettingsPager PageSize="15" AlwaysShowPager="True" EnableAdaptivity="True" NumericButtonCount="6">
                                            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                        </SettingsPager>
                                    </dx:BootstrapGridView>

                                    <dx:BootstrapPopupControl runat="server" ClientInstanceName="detailsModal" PopupAnimationType="None" CloseAnimationType="None" CloseOnEscape="True" Modal="True"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                        <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" FixedHeader="true" FixedFooter="true" />
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
