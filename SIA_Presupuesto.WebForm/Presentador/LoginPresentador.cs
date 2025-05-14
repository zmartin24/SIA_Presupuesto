using Seguridad.Modelo;
using Seguridad.Servicio;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class LoginPresentador
    {
        private readonly ILoginVista loginVista;

        private UsuarioServicio usuarioServicio;

        public LoginPresentador(ILoginVista loginVista)
        {
            this.loginVista = loginVista;
        }

        public void CargarServicios()
        {
            this.usuarioServicio = IoCHelper.ResolverIoC<UsuarioServicio>();
        }

        public Usuario ValidarUsuario(string usuario, string clave)
        {
            return this.usuarioServicio.ValidarUsuario(usuario, clave);
        }

    }
}