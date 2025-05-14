using Seguridad.Modelo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Vista
{
    public interface ILoginVista
    {
        string nomUsuario { get; set; }
        string clave { get; set; }
        string IPv4 { get;  }
        string usuarioPC { get; }
        string nombrePC { get; }
        //UsuarioOperacion usuarioconCredencial { get; }
    }
}
