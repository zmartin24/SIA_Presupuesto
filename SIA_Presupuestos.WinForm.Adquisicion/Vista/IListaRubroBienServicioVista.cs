using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaRubroBienServicioVista
    {
        List<RubroBienServicioPoco> listaDatosPrincipales { set; }

        RubroBienServicioPoco rubroBienServicio { get; }
    }
}
