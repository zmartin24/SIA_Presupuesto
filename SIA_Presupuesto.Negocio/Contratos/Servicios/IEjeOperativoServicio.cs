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
    public interface IEjeOperativoServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(EjeOperativo EjeOperativo);

        Resultado Modificar(EjeOperativo EjeOperativo);

        Resultado Eliminar(EjeOperativo EjeOperativo);

        #endregion

        #region Busquedas y listados

        EjeOperativo BuscarPorCodigo(int idEjeOperativo);

        List<EjeOperativo> listarTodos();
        List<EjeOperativo> TraerTodosActivos();

        #endregion
    }
}
