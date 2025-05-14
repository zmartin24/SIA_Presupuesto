using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface ITipoCambioAnualServicio
    {
        #region Operaciones
        Resultado Nuevo(TipoCambioAnual TipoCambioAnual);

        Resultado Modificar(TipoCambioAnual TipoCambioAnual);

        Resultado Eliminar(TipoCambioAnual TipoCambioAnual);

        #endregion

        #region Busquedas y listados

        TipoCambioAnual BuscarPorCodigo(int idTipoCambioAnual);
        TipoCambioAnual BuscarPorAnio(int anio);

        List<TipoCambioAnual> listarTodos();
        List<TipoCambioAnual> listarTodos(int anio);

        #endregion
    }
}
