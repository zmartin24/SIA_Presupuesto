using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IFuenteFinanciamientoServicio
    {
        #region Procesos
        Resultado Nuevo(FuenteFinanciamiento fuenteFinanciamiento);
        Resultado Modificar(FuenteFinanciamiento fuenteFinanciamiento);
        Resultado Anular(FuenteFinanciamiento fuenteFinanciamiento);
        #endregion
        #region Busqueda y Listas
        FuenteFinanciamiento BuscarPorId(int idFueFin);
        List<FuenteFinanciamiento> TraerListaFuenteFinanciamiento(int vAnio);
        List<FuenteFinanciamiento> TraerTodosActivos();
        #endregion
    }
}
