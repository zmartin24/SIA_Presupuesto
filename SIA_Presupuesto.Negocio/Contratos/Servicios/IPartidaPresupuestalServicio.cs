using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IPartidaPresupuestalServicio : IServicio
    {
        #region operaciones
        Resultado Nuevo(PartidaPresupuestal partidaPresupuestal);
        Resultado Modificar(PartidaPresupuestal partidaPresupuestal);
        Resultado Anular(int idParPre, string usuario);
        Resultado AnularPartidaPresupuestalCuenta(int idParPreCue, string usuario);
        #endregion

        #region lista y busqueda
        PartidaPresupuestal BuscarPorID(int idParPre);
        PartidaPresupuestal BuscarPorCodigo(int idParPre);
        PartidaPresupuestal BuscarPorCondicion(string descripcion, int idUnidad, decimal precio);
        List<PartidaPresupuestalPres> TraerListaPartidaPresupuestal();
        List<PartidaPresupuestalCuentaPoco> TraerListaPartidaPresupuestalCuentaPoco(int idParPre);
        List<PartidaPresupuestalPrecioPres> TraerPartidaPresupuestalPrecio(int tipo, string descripcion, int idMoneda);
        
        #endregion
    }
}
