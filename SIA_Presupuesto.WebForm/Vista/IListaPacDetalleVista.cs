using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaPacDetalleVista : IFormularioBase
    {
        int idPac { get; }

        List<PlanAnualAdquisicionRequerimientoPres> listaDatosPrincipales { set; }
    }
}
