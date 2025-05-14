using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface ITipoCambioPresupuestoServicio
    {
        #region Operaciones
        Resultado Nuevo(TipoCambioPresupuesto TipoCambioPresupuesto);

        Resultado Modificar(TipoCambioPresupuesto TipoCambioPresupuesto);

        Resultado Eliminar(TipoCambioPresupuesto TipoCambioPresupuesto);

        #endregion

        #region Busquedas y listados

        TipoCambioPresupuesto BuscarPorCodigo(int idTipoCambioPresupuesto);
        TipoCambioPresupuesto BuscarPorAnioMes(int anio, int mes);

        List<TipoCambioPresupuesto> listarTodos();
        List<TipoCambioPresupuesto> listarTodos(int anio);
        List<ItemPoco> listarMesesAnio(int anio);

        #endregion
    }
}
