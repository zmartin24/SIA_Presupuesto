<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="VistaDocumento.aspx.cs" Inherits="SIA_Presupuesto.WebForm.VistaDocumento" %>
<%@ Register assembly="DevExpress.XtraReports.v22.2.Web.WebForms, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v22.2.Web.WebForms, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Error de Aplicación</title>    
</head>
<body>
    <form id="form1" runat="server">
        <div class="reportContainer">
            <dx:ASPxDocumentViewer ID="DocumentViewerControl" runat="server" ClientInstanceName="documentViewer" Height="650px" Width="100%">
                <settingsreportviewer enablereportmargins="True" />
                <toolbaritems>
                    <dx:ReportToolbarButton ItemKind="Search" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="PrintReport" />
                    <dx:ReportToolbarButton ItemKind="PrintPage" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="FirstPage" />
                    <dx:ReportToolbarButton ItemKind="PreviousPage" />
                    <dx:ReportToolbarLabel ItemKind="PageLabel" />
                    <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="80px">
                    </dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind="OfLabel" />
                    <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                    <dx:ReportToolbarButton ItemKind="NextPage" />
                    <dx:ReportToolbarButton ItemKind="LastPage" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                    <dx:ReportToolbarButton ItemKind="SaveToWindow" />
                    <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="80px">
                        <elements>
                            <dx:ListElement Value="pdf" />
                            <dx:ListElement Value="xls" />
                            <dx:ListElement Value="xlsx" />
                            <dx:ListElement Value="rtf" />
                            <dx:ListElement Value="mht" />
                            <dx:ListElement Value="html" />
                            <dx:ListElement Value="txt" />
                            <dx:ListElement Value="csv" />
                        </elements>
                    </dx:ReportToolbarComboBox>
                </toolbaritems>
            </dx:ASPxDocumentViewer>
        </div>
        </form>
</body>
</html>

