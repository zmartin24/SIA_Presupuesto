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
    public interface IPuestoPresupuestoServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(List<PuestoPresupuesto> PuestoPresupuestos);

        Resultado Nuevo(PuestoPresupuesto PuestoPresupuesto);

        Resultado Modificar(PuestoPresupuesto PuestoPresupuesto);

        Resultado Anular(PuestoPresupuesto PuestoPresupuesto);

        #endregion

        #region Busquedas y listados

        PuestoPresupuesto BuscarPorCodigo(int idPuestoPresupuesto);
        List<PuestoPresupuesto> listarTodos();
        List<PuestoPresupuesto> TraerTodosActivos();
        List<PuestoPresupuesto> BuscarPorCodigo(List<int> ids);

        #endregion
    }
}
