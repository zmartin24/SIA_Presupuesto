using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RubroBienServicioCuentaRepositorio : Repositorio<RubroBienServicioCuenta>, IRubroBienServicioCuentaRepositorio
    {
        private IContexto contexto;

        public RubroBienServicioCuentaRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        public List<CuentaContablePoco> TraerListaCtaxNivelPlan(int idPlan, int? nivel, int dependencia)
        {
            
            if (dependencia == 0)
            {
                var  rubrobienservicio = (
                           from d in contexto.CuentaContable
                           join c in contexto.PlanCuenta on d.idPlaCue equals c.idPlaCue
                           where d.estado == true && c.idPlaCue == idPlan && d.nivel == nivel
                           select new CuentaContablePoco
                           {
                               idCueCon = d.idCueCon,
                               numCuenta = d.numCuenta,
                               descripcion2 = d.numCuenta + " " + d.descripcion,
                               descripcion = d.descripcion
                           }).OrderBy(t => t.numCuenta).ToList();
                return rubrobienservicio;
            }

            else
            {
                var rubrobienservicio = (
                          from d in contexto.CuentaContable
                          join c in contexto.PlanCuenta on d.idPlaCue equals c.idPlaCue
                          where d.estado == true && c.idPlaCue == idPlan && d.nivel == nivel && d.dependencia == dependencia
                          select new CuentaContablePoco
                          {
                              idCueCon = d.idCueCon,
                              numCuenta = d.numCuenta,
                              descripcion2 = d.numCuenta + " " + d.descripcion,
                              descripcion = d.descripcion
                          }).OrderBy(t => t.numCuenta).ToList();
                return rubrobienservicio;
            }
       
        }

        public List<ItemPoco> TraerListaPlanCuenta()
        {
            var rubrobienservicio = (
                           from d in contexto.PlanCuenta
                           select new ItemPoco
                           {
                              id = d.idPlaCue,
                              nombre = d.descripcion,
                              anio = d.anioEjercicio
                           }).OrderByDescending(t => t.anio).ToList();

            return rubrobienservicio;
        }

        public CuentaContablePoco ObtenerCuenta(int idCuenta)
        {
            var rubrobienservicio = (
                         from d in contexto.CuentaContable
                         where d.idCueCon == idCuenta
                         select new CuentaContablePoco
                         {
                             idCueCon = d.idCueCon,
                             dependencia = d.dependencia
                         }).FirstOrDefault();

            return rubrobienservicio;
        }

        public CuentaContablePoco ValidarExisteCta(int idCuenta)
        {
            var rubrobienservicio = (
                          from d in contexto.RubroBienServicioCuenta
                          where d.idCueCon == idCuenta && d.estado == 2
                          select new CuentaContablePoco
                          {
                              idCueCon = d.idCueCon
                          }).FirstOrDefault();

            return rubrobienservicio;
        }

        public List<RubroBienServicioCuentaPoco> TraerLista(int idPlanCuenta)
        {
            var rubrobienservicio = (
                           from d in contexto.RubroBienServicioCuenta
                           join c in contexto.RubroBienServicio on d.idRubBieSer equals c.idRubBieSer
                           join con in contexto.CuentaContable on d.idCueCon equals con.idCueCon
                           where d.estado == 2 && con.idPlaCue == idPlanCuenta
                           select new RubroBienServicioCuentaPoco
                           {
                               idRubBieSerCue = d.idRubBieSerCue,
                               idRubBieSer = d.idRubBieSer,
                               idCueCon = d.idCueCon,
                               cuenta = con.descripcion,
                               tipoGasto = c.descripcion,
                               idTipoGasto = c.idRubBieSer,
                               numCuenta = con.numCuenta,
                               usuCrea = d.usuCrea,
                               fechaCrea = d.fechaCrea
                           }).OrderBy(t => t.numCuenta).ToList();

            return rubrobienservicio;
        }
    }
}
