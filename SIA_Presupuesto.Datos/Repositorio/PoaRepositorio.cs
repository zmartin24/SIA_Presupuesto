using System.Collections.Generic;
using System.Linq;

using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;

using Seguridad.Log;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PoaRepositorio : Repositorio<Poa>, IPoaRepositorio
    {
        private IContexto contexto;

        public PoaRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }
        #region Listas
        public List<PoaVersionPoco> ListaPoaVersiones(int anio)
        {
            var lista = (from p in contexto.Poa
                         join pv in contexto.PoaVersion on p.idPoa equals pv.idPoa
                         where p.estado != 1 && p.anio == anio
                         select new { p, pv })  // Selecciona los datos sin formatear
             .AsEnumerable()  // Los siguientes métodos se ejecutan en memoria (C#)
             .Select(x => new PoaVersionPoco
             {
                 idPoaVersion = x.pv.idPoaVersion,
                 idPoa = x.p.idPoa,
                 codigoPoa = x.p.codigoPoa + " v." + x.pv.versionPoa.ToString().PadLeft(2, '0'),  // Ahora PadLeft funciona
                 versionPoa = x.pv.versionPoa,
                 anio = x.p.anio,
                 nombre = x.p.nombre,
                 objetivo = x.p.objetivo,
                 fechaAprobacion = x.p.fechaAprobacion
             })
             .OrderByDescending(x => new { x.codigoPoa, x.versionPoa })
             .ToList();

            return lista;
        }
        #endregion
    }
}
