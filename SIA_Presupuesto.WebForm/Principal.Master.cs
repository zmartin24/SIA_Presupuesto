using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SIA_Presupuesto.WebForm
{
    public partial class Principal : System.Web.UI.MasterPage, IPrincipalVista
    {
        private PrincipalPresentador principalPresentador;

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"]) : 6; } }

        protected void Page_Init(object sender, EventArgs e)
        {
            principalPresentador = new PrincipalPresentador(this);
            principalPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMenu();
        }

        private void CargarMenu()
        {
            //if (Session["idUsuario"] != null)
            //{
                StringBuilder sb = new StringBuilder();
                //int idUsuario = Convert.ToInt32(Session["idUsuario"]);
                List<Seguridad.Modelo.Menu> listaMenu = principalPresentador.ListaMenus();

                var listaMenuPrincipal = listaMenu
                    .FindAll(s => s.tipo.Equals("CA"))
                    .OrderBy(o => o.posicion);

                //nbMenu.Groups.Clear();
                menu.Controls.Clear();
                sb.AppendLine("<ul class=\"nav side-menu\">");
                foreach (var menu in listaMenuPrincipal)
                {
                    var listaMenuHijos = listaMenu.FindAll(f => f.idDependencia == menu.idMenu && f.tipo.Equals("DE") && !string.IsNullOrEmpty(f.rutaWeb)).OrderBy(o => o.posicion);

                    sb.AppendLine(string.Format("<li id=\"{0}\"><a><i class=\"fa fa-home\"></i> {1} <span class=\"fa fa-chevron-down\"></span></a>", menu.nomMenu.Replace(" ", string.Empty), menu.titulo));
                    sb.AppendLine("<ul class=\"nav child_menu\">");

                    foreach (var menuHijo in listaMenuHijos)
                    {
                        sb.AppendLine(string.Format("<li><a href=\"{0}\">{1}</a></li>", ResolveUrl(menuHijo.rutaWeb), menuHijo.titulo));
                    }
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</li>");
                }
                sb.AppendLine("</ul>");
                menu.InnerHtml = sb.ToString();
            //}
        }

        private void CargarMenu1()
        {
            //if (Session["idUsuario"] != null)
            //{
            StringBuilder sb = new StringBuilder();
            //int idUsuario = Convert.ToInt32(Session["idUsuario"]);
            List<Seguridad.Modelo.Menu> listaMenu = principalPresentador.ListaMenus();

            var listaMenuPrincipal = listaMenu
                .FindAll(s => s.tipo.Equals("CA"))
                .OrderBy(o => o.posicion);

            //nbMenu.Groups.Clear();
            menu.Controls.Clear();
            HtmlGenericControl lu = new HtmlGenericControl();

            HtmlGenericControl li = new HtmlGenericControl();
            HtmlGenericControl a = new HtmlGenericControl();
            HtmlGenericControl i = new HtmlGenericControl();
            HtmlGenericControl span = new HtmlGenericControl();
            HtmlGenericControl ul = new HtmlGenericControl();
            HtmlGenericControl liHijo = new HtmlGenericControl();
            HtmlGenericControl aHijo = new HtmlGenericControl();

            lu.TagName = "ul";
            lu.Attributes.Add("class", "nav side-menu");

            foreach (var menu in listaMenuPrincipal)
            {
                var listaMenuHijos = listaMenu.FindAll(f => f.idDependencia == menu.idMenu && f.tipo.Equals("DE") && !string.IsNullOrEmpty(f.rutaWeb)).OrderBy(o => o.posicion);

                li = new HtmlGenericControl();
                li.TagName = "li";
                li.Attributes.Add("id", menu.nomMenu.Replace(" ", string.Empty));

                //<a>
                a = new HtmlGenericControl();
                a.TagName = "a";

                //<i>
                i = new HtmlGenericControl();
                i.TagName = "i";
                i.Attributes.Add("class", "fa fa-home");
                a.Controls.Add(i);
                //</i>
                a.InnerText = menu.titulo;

                span = new HtmlGenericControl();
                span.TagName = "span";
                span.Attributes.Add("class", "fa fa-chevron-down");
                a.Controls.Add(span);
                li.Controls.Add(a);

                ul = new HtmlGenericControl();
                ul.Attributes.Add("class", "nav child_menu");

                foreach (var menuHijo in listaMenuHijos)
                {
                    liHijo = new HtmlGenericControl();
                    liHijo.TagName = "li";
                    aHijo = new HtmlGenericControl();
                    aHijo.TagName = "a";
                    aHijo.Attributes.Add("href", menuHijo.rutaWeb);
                    aHijo.InnerText = menuHijo.titulo;
                    liHijo.Controls.Add(aHijo);
                    ul.Controls.Add(liHijo);
                }

                li.Controls.Add(ul);
                lu.Controls.Add(li);
            }

            menu.Controls.Add(lu);
        }

        protected void PageViewerPopup_CustomJSProperties(object sender, CustomJSPropertiesEventArgs e)
        {
            var tipoReportes = Enum.GetValues(typeof(Helper.TipoReporteWeb)).OfType<Helper.TipoReporteWeb>();
            e.Properties["cpReportDisplayNames"] = tipoReportes.ToDictionary(r => r.ToString(), r => ReporteHelper.GetReportDisplayName(r));
        }
    }
}