using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPartidaPresupuestalRepositorio : IRepositorio<PartidaPresupuestal>
    {
        PartidaPresupuestal BuscarPorCodigo(int idParPre);
        List<PartidaPresupuestalPres> TraerListaPartidaPresupuestal();
        List<PartidaPresupuestalCuentaPoco> TraerListaPartidaPresupuestalCuentaPoco(int idParPre);
        List<PartidaPresupuestalPrecioPres> TraerPartidaPresupuestalPrecio(int tipo, string descripcion, int idMoneda);
    }
}
