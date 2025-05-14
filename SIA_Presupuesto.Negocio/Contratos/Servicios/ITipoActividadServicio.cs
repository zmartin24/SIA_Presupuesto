using Seguridad.Datos.Infraestructura;
using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface ITipoActividadServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(TipoActividad tipoActividad);
        Resultado Modificar(TipoActividad tipoActividad);
        Resultado Anular(int idTipoActivad);
        #endregion

        #region Listas
        List<TipoActividad> ListaTodos();
        #endregion
    }
}
