using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IPoaServicio : IServicio
    {
        #region Operaciones
        
        Resultado Nuevo(Poa poa);
        Resultado Modificar(Poa poa);
        Resultado Anular(int idPoa);
        #endregion

        #region Listas
        List<PoaVersionPoco> ListaPoaVersiones(int anio);
        #endregion
    }
}
