<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="SIA_Presupuesto.WebForm.prueba" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnFileUploadComplete(s, e) {
            Grid.PerformCallback();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div>
            <%--<dx:ASPxUploadControl ID="Upload" runat="server" ShowUploadButton="True" OnFileUploadComplete="Upload_FileUploadComplete">
                <ValidationSettings AllowedFileExtensions=".xls,.xlsx">
                </ValidationSettings>
                <ClientSideEvents FileUploadComplete="OnFileUploadComplete" />
            </dx:ASPxUploadControl>
            <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" OnInit="Grid_Init"></dx:ASPxGridView>--%>
            <dx:BootstrapUploadControl ID="BootstrapUploadControlImportarExcel" ClientInstanceName="BootstrapUploadControlImportarExcel" runat="server" ShowUploadButton="true" ShowClearFileSelectionButton="true"
                OnFileUploadComplete="Upload_FileUploadComplete"
                ShowProgressPanel="true" ShowTextBox="true"
                UploadMode="Advanced" >
                <%-- <ClientSideEvents FileUploadComplete="onFileUploadComplete" FilesUploadStart="onFilesUploadStart" />--%>
                 <ClientSideEvents FileUploadComplete="OnFileUploadComplete" />
                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xlsx,.xls" />
                <AdvancedModeSettings EnableDragAndDrop="true" />
            </dx:BootstrapUploadControl>
            <small>Extensiones de archivo permitidas: .xlsx, .xls.</small>
            <br />
            <small>Tamaño máximo de archivo: 4 MB.</small>
            <br />
            <dx:BootstrapGridView ID="Grid" ClientInstanceName="Grid" runat="server" OnInit="Grid_Init"></dx:BootstrapGridView>
        </div>
    
</asp:Content>
