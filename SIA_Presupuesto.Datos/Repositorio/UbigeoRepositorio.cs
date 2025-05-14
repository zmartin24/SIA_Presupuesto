using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class UbigeoRepositorio : Repositorio<Ubigeo>, IUbigeoRepositorio
    {
        private IContexto contexto;
        public UbigeoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        #region Operaciones
        #endregion

        #region Busquedas y Listas
        public UbigeoPoco TraerUbigeoPocoIdDistrito(int idDistrito)
        {
            var ubigeo = (
                            from d in contexto.Ubigeo
                                join p in contexto.Ubigeo on d.dependencia equals p.idUbigeo
                                join r in contexto.Ubigeo on p.dependencia equals r.idUbigeo
                            where d.idUbigeo == idDistrito
                            select new UbigeoPoco
                            {
                                idDistrito = d.idUbigeo,
                                codDistrito = d.codSunat,
                                distrito = d.desUbigeo,
                                idProvincia = p.idUbigeo,
                                codProvincia = p.codSunat,
                                provincia = p.desUbigeo,
                                idRegion = r.idUbigeo,
                                codRegion = r.codSunat,
                                region = r.desUbigeo
                            }).ToList().FirstOrDefault();
            return ubigeo;
        }
        #endregion
    }
}
