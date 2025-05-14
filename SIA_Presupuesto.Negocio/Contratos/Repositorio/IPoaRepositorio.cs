using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPoaRepositorio : IRepositorio<Poa>
    {
        #region Listas
        List<PoaVersionPoco> ListaPoaVersiones(int anio);
        #endregion
    }

}
