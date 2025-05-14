using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaGastoRecurrenteDetalleVista : IFormularioBase
    {
        int idGasRec { get; }

        List<GastoRecurrenteRequerimientoPres> listaDatosPrincipales { set; }

        int idProducto { get; set; }
    }
}
