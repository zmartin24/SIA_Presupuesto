using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaRubroBienServicioCuentaVista
    {
        List<RubroBienServicioCuentaPoco> listaDatosPrincipales { set; }

        RubroBienServicioCuentaPoco rubroBienCuentaServicio { get; }

        List<ItemPoco> listaPlanCuenta { set; }

        int idPlanCuenta { get; set; }
    }
}
