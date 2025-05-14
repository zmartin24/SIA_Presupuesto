using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
//using Alve.Negocio.Contratos.Servicio;
//using Unity.Attributes;
//using Seguridad.Servicio;
//using Utilitario.Util;
//using Alve.Transversal.IoC.Contenedor;
////using Alve.WebForm.Extension;
//using Alve.WebForm.Helper;

namespace SIA_Presupuesto.WebForm
{
    public partial class Default : System.Web.UI.Page {

        //[Dependency]
        //public UsuarioServicio usuarioServicio { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            //usuarioServicio = IoCHelper.ResolverIoC<UsuarioServicio>();

            //IoCHelper.ResolverIoC(usuarioServicio.GetType());
        }

        protected void Page_Load(object sender, EventArgs e) {
            //if (!this.IsPostBack)
            //    if (Request.QueryString("Usr") != null)
            //    {
            //        Dim Usr As String = CType(Request.QueryString("Usr"), String)
            //        ValidateUser(Usr);
            //    }
        }

        private void ValidateUser(string User)
        {
            //var usuario = usuarioServicio.ValidarUsuario(tbUserName.Text, tbPassword.Text);
        }

        //Dim cnstr As String = ConfigurationManager.ConnectionStrings("CnnStringSDB1").ConnectionString
        //Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(cnstr)
        //Dim sql As String = "SELECT [UserName] FROM [vw_aspnet_Users] where [UserName]='" + Trim(User) + "'"
        //Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(sql, cn)
        //Dim dr As System.Data.SqlClient.SqlDataReader

        //Try
        //    cn.Open()
        //    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        //    If(dr.Read()) Then
        //       FormsAuthentication.RedirectFromLoginPage(User, False)
        //        Response.Redirect("~/Default.aspx")
        //    End If

        //Catch myException As Exception
        //    Response.Write("Error al intentar autenticar al usuario: " & myException.ToString())
        //Finally
        //    If Not dr Is Nothing Then
        //        dr.Close()
        //    End If
        //End Try

        //End Sub

        protected void btnLogin_Click(object sender, EventArgs e) {
            //var usuario = usuarioServicio.ValidarUsuario(tbUserName.Text, tbPassword.Text);
            //if (usuario != null)
            //{
            //    Session.RemoveAll();
            //    Session["Sesion"] = UtilitarioComun.Random();
            //    Session["idUsuario"] = usuario.idUsuario;
            //    Session["idTrabajador"] = usuario.idPersona;
            //    Session["usuario"] = usuario.nomUsuario;

            //    //Session["idAlmacen"] = 2;
            //    //Session["idTienda"] = 1;
            //    //Session["idCaja"] = 1;

            //    //if (Membership.ValidateUser(tbUserName.Text, tbPassword.Text)) {
            //    if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            //    {
            //        FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
            //        Response.Redirect("~/Account/SeleccionarEmpresa.aspx");
            //    }
            //    else
            //    {
            //        FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
            //        Response.Redirect("~/Account/SeleccionarEmpresa.aspx");
            //    }
            //}
            //else {
            //    tbUserName.ErrorText = "Usuario Invalido";
            //    tbUserName.IsValid = false;
            //}
        }
    }
}