using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Base
{
    public interface IServicio
    {
        UsuarioOperacion UsuarioOperacion { set; }

        //void CargarInformacionUsuario<T>(IRepositorio<T> repositorio) where T : class
    }
}
