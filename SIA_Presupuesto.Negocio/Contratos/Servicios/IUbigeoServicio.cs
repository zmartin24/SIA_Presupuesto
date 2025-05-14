using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IUbigeoServicio
    {
        #region Busqueda y Listas
        UbigeoPoco TraerUbigeoPocoIdDistrito(int idDistrito);
        Ubigeo TraerUbigeoId(int idUbigeo);
        List<Ubigeo> TraerListaRegion();
        List<Ubigeo> TraerListaProvincia(int idRegion);
        List<Ubigeo> TraerListaDistrito(int idProvincia);
        #endregion
    }
}
