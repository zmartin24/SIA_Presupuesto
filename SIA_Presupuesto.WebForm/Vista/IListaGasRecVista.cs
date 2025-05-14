using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaGasRecVista : IListaBase
    {
        List<GastoRecurrente> listaDatosPrincipales { set; }
        List<Direccion> listaDireccionesReporte { set; }
    }
}
