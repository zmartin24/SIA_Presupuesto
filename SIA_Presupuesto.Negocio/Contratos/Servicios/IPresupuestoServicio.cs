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
    public interface IPresupuestoServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(Presupuesto Presupuesto);

        Resultado Modificar(Presupuesto Presupuesto);

        Resultado Eliminar(Presupuesto Presupuesto);

        #endregion

        #region Busquedas y listados

        Presupuesto BuscarPorCodigo(int idPresupuesto);

        List<Presupuesto> listarTodos();

        List<PresupuestoPres> TraerListaPresupuestoPres();
        List<Presupuesto> TraerListaPresupuestoPorGrupoPresupuesto(int idGruPre);

        #endregion
    }
}
