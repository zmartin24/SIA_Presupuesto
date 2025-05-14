﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIA_Presupuesto.WebForm
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }
        }
    }
}