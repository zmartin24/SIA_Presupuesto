using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class UbigeoServicio : IUbigeoServicio
    {
        private IUbigeoRepositorio repositorio;

        public UbigeoServicio(IUbigeoRepositorio vrepositorio)
        {
            this.repositorio = vrepositorio;
        }

        #region Busqueda y Listas
        public UbigeoPoco TraerUbigeoPocoIdDistrito(int idDistrito)
        {
            return repositorio.TraerUbigeoPocoIdDistrito(idDistrito);
        }
        public Ubigeo TraerUbigeoId(int idUbigeo)
        {
            return repositorio.TraerPorCondicion(x => x.idUbigeo == idUbigeo);
        }
        public List<Ubigeo> TraerListaRegion()
        {
            return repositorio.TraerVariosPorCondicion(x => x.idUbigeo == x.dependencia).ToList();
        }
        public List<Ubigeo> TraerListaProvincia(int idRegion)
        {
            return repositorio.TraerVariosPorCondicion(x => x.dependencia == idRegion && x.codSunat.Length == 4).ToList();
        }
        public List<Ubigeo> TraerListaDistrito(int idProvincia)
        {
            return repositorio.TraerVariosPorCondicion(x => x.dependencia == idProvincia && x.codSunat.Length == 6).ToList();
        }
        #endregion
    }
}
