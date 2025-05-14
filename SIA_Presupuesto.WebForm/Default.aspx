<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Alve_WebForm.Login" %>

<%@ Register assembly="DevExpress.Web.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="~/Content/Login.css" rel="stylesheet" type="text/css" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>.::.INGRESO DE USUARIO.::.</title>
</head>
<body>
    <form id="form1" runat="server">
          <table style="width: 437px">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center">
              <asp:login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                  Font-Size="0.8em" Font-Underline="True" ForeColor="#333333" LoginButtonText="Ingresar" 
                  PasswordRequiredErrorMessage="Se requiere Password." RememberMeText="Recordarme la próxima vez." TitleText="Iniciar sesión" 
                  UserNameLabelText="Nombre Usuario:" UserNameRequiredErrorMessage="Se requiere Nombre de Usuario." 
                  FailureText="Nombre Usuario o Password incorrecto. Favor intentelo nuevamente." DestinationPageUrl="~/Default.aspx" >
                  <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                      Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                  <TextBoxStyle Font-Size="0.8em" />
                  <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                  <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
              </asp:login>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Public/RecuperarPwd.aspx">Olvidé mi contraseña</asp:HyperLink>
            </td>
        </tr>
    </table>
    </form>
</body>



 
