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
    public class PropiedadPresupuestoRemuneracionRepositorio : Repositorio<PropiedadPresupuestoRemuneracion>, IPropiedadPresupuestoRemuneracionRepositorio
    {
        public PropiedadPresupuestoRemuneracionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<PropiedadPoco> TraerPropiedadPresentacion()
        {
            List<PropiedadPoco> lista = new List<PropiedadPoco>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = (from par in contexto.PropiedadPresupuestoRemuneracion
                     join con in contexto.ConceptoPresupuestoRemuneracion on par.idConPreRem equals con.idConPreRem
                     join ori in contexto.OrigenConcepto on con.idOriCon equals ori.idOriCon
                     where par.estado != 1
                     select new PropiedadPoco
                     {
                         idEstPreRem = par.idEstPreRem,
                         idProPreRem = par.idProPreRem,
                         idConPreRem = par.idConPreRem,
                         seVisualiza = par.visualiza,
                         esAcumulativo = false,
                         numero = 0,
                         numeroImp = 0,
                         concepto = con.descripcion,
                         codigo = con.codigo,
                         tipo = con.tipo.Equals("IN") ? "INGRESO" : con.tipo.Equals("DE") ? "DESCUENTO" : "DATOS",
                         codOrigen = ori.codigo,
                         origen = ori.descripcion,
                         orden = par.orden,
                         tipoValor = par.tipoValor.Equals("FI") ? "FIJO" : "FORMULA",
                         valor = par.valor,
                         codTipoValor = par.tipoValor,
                         visualiza = par.visualiza ? "SI":"NO"
                     }
                ).ToList();

            return lista;
        }

        public List<PropiedadPoco> TraerPropiedadPresentacion(int idEstPreRem)
        {
            List<PropiedadPoco> lista = new List<PropiedadPoco>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = (from par in contexto.PropiedadPresupuestoRemuneracion
                     join con in contexto.ConceptoPresupuestoRemuneracion on par.idConPreRem equals con.idConPreRem
                     join ori in contexto.OrigenConcepto on con.idOriCon equals ori.idOriCon
                     where par.idEstPreRem == idEstPreRem && par.estado!=1
                     select new PropiedadPoco
                     {
                         idEstPreRem = par.idEstPreRem,
                         idProPreRem = par.idProPreRem,
                         idConPreRem = par.idConPreRem,
                         seVisualiza = par.visualiza,
                         esAcumulativo = false,
                         numero = 0,
                         numeroImp = 0,
                         concepto = con.descripcion,
                         codigo = con.codigo,
                         tipo = con.tipo.Equals("IN") ? "INGRESO" : con.tipo.Equals("DE") ? "DESCUENTO" : "DATOS",
                         codOrigen = ori.codigo,
                         origen = ori.descripcion,
                         orden = par.orden,
                         tipoValor = par.tipoValor.Equals("FI") ? "FIJO" : "FORMULA",
                         valor = par.valor,
                         codTipoValor = par.tipoValor,
                         visualiza = par.visualiza ? "SI" : "NO"
                     }
                ).ToList();

            return lista;
        }
    }
}
