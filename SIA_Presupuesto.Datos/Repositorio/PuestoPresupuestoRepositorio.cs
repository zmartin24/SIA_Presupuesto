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
    public class PuestoPresupuestoRepositorio : Repositorio<PuestoPresupuesto>, IPuestoPresupuestoRepositorio
    {
        public PuestoPresupuestoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<PuestoPoco> ListaPuestos(int idProAnu)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var lista = (from p in contexto.PuestoPresupuesto
                         where p.estado != 1 && p.idProAnu == idProAnu
                         select new PuestoPoco
                         {
                             idPuesto = p.idPuePre,
                             idTipMon = p.idTipMon,
                             cantVacante = (Int32)p.cantVacante,
                             esRemDiaria = p.esRemDiaria,
                             esVacante = p.esVacante,
                             remuneracion = p.remuneracion,
                             grado  = p.grado,
                             situacionEspecial = (Int32)p.situacionEspecial,
                             conBonoAlimentacion = (bool)p.conBonoAlimento,
                             conBonoAlimentacionAdi = (bool)p.conBonoAlimentoAdi,
                             conBonoMovilidad = (bool)p.conBonoMovilidad,
                             conBonoProductividad = (bool)p.conBonoProductividad,
                             conSctrSalud = (bool)p.conSctrSalud,
                             conSctrPension = (bool)p.conSctrPension,
                             fechaInicio = p.fechaInicio.Value,
                             fechaTermino = p.fechaTermino.Value,
                             idCatLab = (Int32)p.idCatLab,
                             idConLab = (Int32)p.idConLab
                         }).ToList();

            return lista;
        }

    }
}
