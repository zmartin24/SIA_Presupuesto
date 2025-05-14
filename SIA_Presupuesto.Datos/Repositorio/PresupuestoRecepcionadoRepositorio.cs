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
    public class PresupuestoRecepcionadoRepositorio : Repositorio<PresupuestoRecepcionado>, IPresupuestoRecepcionadoRepositorio
    {
        private IContexto contexto;

        public PresupuestoRecepcionadoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        public List<PresupuestoRecepcionadoPoco> listarDetalleRecepcionados(int idGrupo)
        {
            var grupopresupuesto = (
                           from p in contexto.PresupuestoRecepcionado
                           join g in contexto.GrupoPresupuesto on p.idGruPre equals g.idGruPre
                           where p.idGruPre == idGrupo && p.estado != 1
                           select new PresupuestoRecepcionadoPoco
                           {
                               idGruPre = p.idGruPre,
                               idPreRec = p.idPreRec,
                               anio = p.anio,
                               nombreGrupre = g.descripcion,
                               importe = p.importe,
                               mes= p.mes,
                               usuCrea = p.usuCrea,
                               fechaCrea = p.fechaCrea,
                               tipo = (p.tipo == "RE")?"RECEPCIONADO" :  (p.tipo == "TR")?"TRANSFERIDO": "",
                               nombreMes = 
                                (p.mes == 1) ? "ENERO"
                               :(p.mes == 2) ? "FEBRERO"
                               :(p.mes == 3) ? "MARZO"
                               :(p.mes == 4) ? "ABRIL"
                               :(p.mes == 5) ? "MAYO"
                               :(p.mes == 6) ? "JUNIO"
                               :(p.mes == 7) ? "JULIO"
                               :(p.mes == 8) ? "AGOSTO"
                               :(p.mes == 9) ? "SEPTIEMBRE"
                               :(p.mes == 10)? "OCTUBRE"
                               :(p.mes == 11)? "NOVIEMBRE"
                               :(p.mes == 12)? "DICIEMRE" : ""
                               //idGruPre = grp.Key.idGruPre,
                               //anio = grp.Key.anio,
                               //grupo = grp.Key.descripcion + "-" + grp.Key.anio,
                               //cantidad = 0
                           }).OrderBy(t=>t.anio).OrderBy(t=>t.mes).ToList();

            return grupopresupuesto;
        }

        public List<PresupuestoRecepcionadoPoco> ListaGrupo(int anio, int mesInicio, int mesFin)
        {
            var grupopresupuesto = (
                            from p in contexto.PresupuestoRecepcionado
                            join g in contexto.GrupoPresupuesto on p.idGruPre equals g.idGruPre
                            where p.estado != 1 && (anio == 0 || p.anio == anio) && (p.mes >= mesInicio && p.mes <=mesFin)
                            group p by new {p.idGruPre, p.anio, g.descripcion} into grp
                            select new PresupuestoRecepcionadoPoco
                            {
                                idGruPre = grp.Key.idGruPre,
                                anio = grp.Key.anio,
                                grupo = grp.Key.descripcion + "-" + grp.Key.anio,
                                cantidad = grp.Sum(_ => _.importe)
                            }).ToList();

            return grupopresupuesto;
        }

        public List<PresupuestoRecepcionadoPoco> BuscarxIdAnio(int idGru, int anio)
        {

            var grupopresupuesto = (
                            from p in contexto.PresupuestoRecepcionado
                            join g in contexto.GrupoPresupuesto on p.idGruPre equals g.idGruPre
                            where p.idGruPre == idGru && p.anio == anio && p.estado != 1
                            select new PresupuestoRecepcionadoPoco
                            {
                                idPreRec = p.idPreRec
                            }).ToList();

            return grupopresupuesto;
        }

        public PresupuestoRecepcionadoPoco ObtenerRegistroxFiltro(int idGruPre, int anio, int mes)
        {
            var grupopresupuesto = (
                           from p in contexto.PresupuestoRecepcionado
                           join g in contexto.GrupoPresupuesto on p.idGruPre equals g.idGruPre
                           where p.idGruPre == idGruPre && p.anio == anio && p.mes == mes && p.estado != 1
                           group p by new { p.idGruPre,p.anio,p.mes } into g
                           select new PresupuestoRecepcionadoPoco
                           {
                               idPreRec = g.Min(_=>_.idPreRec),
                               importe = g.Sum(_=>_.importe)
                           }).FirstOrDefault();
            return grupopresupuesto;
        }

        public PresupuestoRecepcionadoPoco ObtenerRegistroxGrupo(int idGruPre, int anio)
        {
            var grupopresupuesto = (
                           from p in contexto.PresupuestoRecepcionado
                          
                           where p.idGruPre == idGruPre && p.anio == anio && p.estado != 1
                           select new PresupuestoRecepcionadoPoco
                           {
                               idPreRec = p.idPreRec
                           }).FirstOrDefault();
            return grupopresupuesto;
        }
    }
}
