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
    public interface IModalidadServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(Modalidad Modalidad);

        Resultado Modificar(Modalidad Modalidad);

        Resultado Eliminar(Modalidad Modalidad);

        #endregion

        #region Busquedas y listados

        Modalidad BuscarPorCodigo(int idModalidad);

        List<Modalidad> listarTodos();
        List<Modalidad> TraerTodosActivos();

        #endregion
    }
}
