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
    public interface ITipoReporteServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(TipoReporte TipoReporte);

        Resultado Modificar(TipoReporte TipoReporte);

        Resultado Eliminar(TipoReporte TipoReporte);

        #endregion

        #region Busquedas y listados

        TipoReporte BuscarPorCodigo(int idTipoReporte);

        List<TipoReporte> listarTodos();

        #endregion
    }
}
