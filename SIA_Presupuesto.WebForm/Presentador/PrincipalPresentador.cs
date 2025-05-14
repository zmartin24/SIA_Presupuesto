using Seguridad.Servicio;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class PrincipalPresentador
    {
        private readonly IPrincipalVista principalVista;

        private MenuServicio menuServicio;

        private UsuarioServicio usuarioServicio;

        public PrincipalPresentador(IPrincipalVista principalVista)
        {
            this.principalVista = principalVista;
        }

        public void CargarServicios()
        {
            this.menuServicio = IoCHelper.ResolverIoC<MenuServicio>();
            this.usuarioServicio = IoCHelper.ResolverIoC<UsuarioServicio>();
        }

        public List<Seguridad.Modelo.Menu> ListaMenus()
        {
            List<Seguridad.Modelo.Menu> listaMenu = usuarioServicio.ListaMenuOpcionesAutorizados(principalVista.idUsuario, 11);
            return listaMenu;
        }



    }
}