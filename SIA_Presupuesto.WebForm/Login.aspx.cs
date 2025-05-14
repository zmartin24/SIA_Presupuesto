using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm
{
    public partial class Login : System.Web.UI.Page, ILoginVista
    {
        private LoginPresentador loginPresentador;
        protected void Page_Init(object sender, EventArgs e)
        {
            loginPresentador = new LoginPresentador(this);
            loginPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.RemoveAll();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            var usuario = loginPresentador.ValidarUsuario(txtUsuario.Value, txtClave.Value);
            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.nomUsuario, false);
                //FormsAuthentication.
                Session.RemoveAll();
                Session["Sesion"] = UtilitarioComun.Random();
                Session["idUsuario"] = usuario.idUsuario;
                Session["nomUsuario"] = usuario.nomUsuario;
                FormsAuthentication.RedirectFromLoginPage(usuario.nomUsuario, false);
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                mensaje.InnerText = "Usuario y/o clave incorrecta.";
            }
        }
    }
}