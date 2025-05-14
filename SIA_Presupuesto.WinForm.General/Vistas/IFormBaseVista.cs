using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Vistas
{
    public interface IFormBaseVista
    {
        int Anio { get; set; }
        int Mes { get; set; }
        UsuarioOperacion Usuario { get; set; }
        string Parametro { get; set; }
    }
}
