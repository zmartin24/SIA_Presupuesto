using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface ITransferenciaVista
    {
        List<GrupoPresupuestoPoco> listaGrupoPresupuesto { set; }
        int idGrupoPresupuesto { get; set; }
        List<ItemPoco> listaAnios { set; }

        List<ItemPoco> listaMeses { set; }

        int mes { get; set; }

        decimal importe { get; set; }

        int anio { get; }

        string nombreGrupo { get; }

        string nombreMes { get; }

    }
}
