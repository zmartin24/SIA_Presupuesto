using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IGrupoPresupuestoServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(GrupoPresupuesto GrupoPresupuesto);

        Resultado Modificar(GrupoPresupuesto GrupoPresupuesto);

        Resultado Eliminar(GrupoPresupuesto GrupoPresupuesto);

        #endregion

        #region Busquedas y listados

        List<GrupoPresupuestoPoco> ListaGrupo();

        GrupoPresupuesto BuscarPorCodigo(int idGrupoPresupuesto);

        List<GrupoPresupuesto> listarTodos();

        List<GrupoPresupuestoPres> TraerListaGrupoPresupuestoPres();

        List<GrupoPresupuesto> TraerListaGrupoPresupuesto();

        Resultado Anular(GrupoPresupuestoPoco GrupoPresupuesto);

        GrupoPresupuestoPoco ObtenerxId(int idGrupo);

        #endregion
    }
}
