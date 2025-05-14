using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaPresupuestoRecepcionadoVista
    {
        List<PresupuestoRecepcionadoPoco> listaDatosPrincipales { set; }
        PresupuestoRecepcionadoPoco PresupuestoRecepcionado { get; }

        List<ItemPoco> listaAnios { set; }

        int anio { get; set; }

        int mesInicio { get; set; }

        int mesFin { get; set; }

        List<ItemPoco> listaMesesInicio { set; }

        List<ItemPoco> listaMesesFin { set; }
    }
}
