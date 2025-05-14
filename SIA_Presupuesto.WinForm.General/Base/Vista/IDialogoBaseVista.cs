using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Base.Vista
{
    public interface IDialogoBaseVista
    {
        int Anio { get; }

        int Mes { get; }

        UsuarioOperacion UsuarioOperacion { get; }

    }
}
