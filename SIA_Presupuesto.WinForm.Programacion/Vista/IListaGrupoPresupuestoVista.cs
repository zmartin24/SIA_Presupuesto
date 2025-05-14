using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaGrupoPresupuestoVista
    {
        List<GrupoPresupuestoPoco> listaDatosPrincipales { set; }
        GrupoPresupuestoPoco grupoPresupuesto{ get; }
    }
}
