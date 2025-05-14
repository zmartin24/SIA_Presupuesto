using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using SIA_Presupuesto.WebForm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaPresupuestoMensualDetalleVista : IFormularioBase
    {
        List<SubPresupuestoAreaPres> listaDatosPrincipales { set; }
        int idSubPre { get; set; }
        string desPresupuesto { set; get; }
        string desSubPresupuesto { set; get; }
        string tipoCambio { set; get; }
        string proyecto { set; get; }
        string esObra { set; get; }
    }
}
