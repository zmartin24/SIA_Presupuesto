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
    public class GrupoPresupuestoRepositorio : Repositorio<GrupoPresupuesto>, IGrupoPresupuestoRepositorio
    {
        private IContexto contexto;

        public GrupoPresupuestoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        public List<GrupoPresupuestoPres> TraerListaGrupoPresupuestoPres()
        {
            List<GrupoPresupuestoPres> lista = new List<GrupoPresupuestoPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaGrupoPresupuestoPres().ToList();

            return lista;
        }

        public List<GrupoPresupuestoPoco> ListaGrupo()
        {
            var grupopresupuesto = (
                            from d in contexto.GrupoPresupuesto
                            join f in contexto.FuenteFinanciamiento on d.idFueFin equals f.idFueFin
                            where d.estado != 1
                            select new GrupoPresupuestoPoco
                            {
                                idGrupoPresupuesto = d.idGruPre,
                                codigo = d.codigo,
                                idFuenteFinanciamiento = d.idFueFin,
                                descripcion = d.descripcion,
                                abreviatura = d.abreviatura,
                                esEncargo = (d.esEncargo == true)?"Si":"No",
                                observacion = d.observacion,
                                nombreFuente = f.fuente,
                                grupo = d.grupo
                            }).ToList();

            return grupopresupuesto;
        }

        public GrupoPresupuestoPoco ObtenerxId(int idGrupo)
        {
            var grupopresupuesto = (
                            from d in contexto.GrupoPresupuesto
                             join c in contexto.FuenteFinanciamiento on d.idFueFin equals c.idFueFin
                            where d.idGruPre == idGrupo
                            select new GrupoPresupuestoPoco
                            {
                                idGrupoPresupuesto = d.idGruPre,
                                codigo = d.codigo,
                                nombreFuente = c.fuente,
                                descripcion = d.descripcion,
                                abreviatura = d.abreviatura,
                                esEncargo = (d.esEncargo == true) ? "Si" : "No",
                                observacion = d.observacion,
                                grupo = d.grupo
                            }).SingleOrDefault();

            return grupopresupuesto;
        }

        public List<GrupoPresupuesto> TraerListaGrupoPresupuesto()
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaGrupoPresupuesto().ToList();
        }
    }
}
