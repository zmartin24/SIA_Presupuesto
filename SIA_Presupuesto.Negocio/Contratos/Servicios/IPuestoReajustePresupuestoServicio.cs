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
    public interface IPuestoReajustePresupuestoServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(List<PuestoReajustePresupuesto> PuestoReajustePresupuestos);

        Resultado Nuevo(PuestoReajustePresupuesto PuestoReajustePresupuesto);

        Resultado Modificar(PuestoReajustePresupuesto PuestoReajustePresupuesto);

        Resultado Anular(PuestoReajustePresupuesto PuestoReajustePresupuesto);

        #endregion

        #region Busquedas y listados

        PuestoReajustePresupuesto BuscarPorCodigo(int idPuestoReajustePresupuesto);

        List<PuestoReajustePresupuesto> BuscarPorCodigo(List<int> ids);

        List<PuestoReajustePresupuesto> listarTodos();
        List<PuestoReajustePresupuesto> TraerTodosActivos();

        #endregion
    }
}
