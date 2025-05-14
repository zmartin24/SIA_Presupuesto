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
    public class PuestoReajustePresupuestoRepositorio : Repositorio<PuestoReajustePresupuesto>, IPuestoReajustePresupuestoRepositorio
    {
        public PuestoReajustePresupuestoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<PuestoPoco> ListaPuestos(int idReaMenPro)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var lista = (from p in contexto.PuestoReajustePresupuesto
                         where p.estado != 1 && p.idReaMenPro == idReaMenPro
                         select new PuestoPoco
                         {
                             idPuesto = p.idReaPuePre,
                             idTipMon = p.idTipMon,
                             cantVacante = (Int32)p.cantVacante,
                             esRemDiaria = p.esRemDiaria,
                             esVacante = p.esVacante,
                             remuneracion = p.remuneracion,
                             grado  = p.grado,
                             conBonoAlimentacion = (bool)p.conBonoAlimento,
                             conBonoAlimentacionAdi = (bool)p.conBonoAlimentoAdi,
                             conBonoMovilidad = (bool)p.conBonoMovilidad,
                             conBonoProductividad = (bool)p.conBonoProductividad,
                             fechaInicio = p.fechaInicio.Value,
                             fechaTermino = p.fechaTermino.Value
                         }).ToList();

            return lista;
        }

    }
}
