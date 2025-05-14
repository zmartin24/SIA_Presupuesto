using Seguridad.Modelo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Vista
{
    public interface IPrincipalVista
    {
        string nomUsuario { set; }
        string Periodo { set; }
        string PeriodoActivo { set; }

    }
}
