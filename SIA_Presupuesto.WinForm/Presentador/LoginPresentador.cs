using Seguridad.Modelo;
using Seguridad.Servicio;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Presentador
{
    public class LoginPresentador
    {
        private readonly ILoginVista loginVista;

        private PrincipalPresentador principalPresentador;

        private UsuarioServicio usuServ;

        public LoginPresentador(ILoginVista loginVista, PrincipalPresentador principalPresentador)
        {
            this.loginVista = loginVista;
            this.principalPresentador = principalPresentador;
            IContenedor _Contenedor = new cContenedor();
            usuServ = _Contenedor.Resolver(typeof(UsuarioServicio)) as UsuarioServicio;
        }

        public bool LogearUsuario()
        {
            var usuario = usuServ.ValidarUsuario(11, loginVista.usuarioPC, loginVista.IPv4, loginVista.nombrePC, loginVista.nomUsuario, loginVista.clave); //usuServ.ValidarUsuario(loginVista.nomUsuario, loginVista.clave);
            if (usuario == null) return false;
            if(!usuario.estado) return false;
            this.principalPresentador.UsuarioOperacion = new UsuarioOperacion
            {
                IDUsuario = usuario.idUsuario,
                IDTrabajador = usuario.idPersona,
                IDSistema = 0,
                NomUsuario = usuario.nomUsuario,
                IPUsuario = "",
                NombrePC = "",
                NomUsuarioPC = "",
                NombrePersona = "",//nomper.priNom + " " + nomper.segNom + " " + nomper.apePat + " " + nomper.apeMat,
                DniPersona = "", //nomper.nroDocIdentidad,
                estado = usuario.estado
            }; 
            Properties.Settings.Default.nomUsuario = loginVista.nomUsuario;
            Properties.Settings.Default.Save();
            return true;
        }
    }
}
