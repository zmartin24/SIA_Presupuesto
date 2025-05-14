using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Base.Vista
{
    public interface IControlBaseVista
    {
        int Anio { get; }

        int Mes { get; }

        string Parametros { get; }

        UsuarioOperacion UsuarioOperacion { get; }

        IList listaSplash { set; get; }

    }
}
