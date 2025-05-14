using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IRequerimientoBienServicioDetVista : IFormularioBase
    {
        List<Unidad> listaUnidades { set; }

        int idUnidad { get; set; }

        int idCueCon { get; set; }

        string descripcion { get; set; }

        string justificacion { get; set; }

        decimal precio { get; set; }

        List<CuentaContable> listaCuentaContable { set; }


    }
}
