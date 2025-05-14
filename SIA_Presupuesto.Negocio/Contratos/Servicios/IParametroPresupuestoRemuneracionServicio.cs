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
    public interface IParametroPresupuestoRemuneracionServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(ParametroPresupuestoRemuneracion ParametroPresupuestoRemuneracion);

        Resultado Modificar(ParametroPresupuestoRemuneracion ParametroPresupuestoRemuneracion);

        Resultado Anular(ParametroPresupuestoRemuneracion ParametroPresupuestoRemuneracion);

        #endregion

        #region Busquedas y listados

        ParametroPresupuestoRemuneracion BuscarPorCodigo(int idParametroPresupuestoRemuneracion);

        List<ParametroPresupuestoRemuneracion> listarTodos();
        List<ParametroPresupuestoRemuneracion> TraerTodosActivos();

        List<ParametroPoco> TraerParametrosPresentacion();

        #endregion
    }
}
