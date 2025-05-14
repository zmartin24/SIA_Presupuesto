using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PuestoRequerimientoRepositorio : Repositorio<PuestoRequerimiento>, IPuestoRequerimientoRepositorio
    {
        public PuestoRequerimientoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }
        public bool GuardarPuestoRequerimientoEnProgramacionAnual(string codigos, int idProAnu, string usuario)
        {
            var resultado = new ObjectParameter("resultado", typeof(bool));

            var contexto = this.UnidadTrabajo as IContexto;

            contexto.GuardarPuestoRequerimientoEnProgramacionAnual(codigos, idProAnu, usuario, resultado);

            return resultado.Value == null ? false : ((bool)resultado.Value);
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
                             conBonoAlimentacion = (bool)p.conBonoAlimento,
                             conBonoAlimentacionAdi = (bool)p.conBonoAlimentoAdi,
                             conBonoMovilidad = (bool)p.conBonoMovilidad,
                             conBonoProductividad = (bool)p.conBonoProductividad,
                             fechaInicio = p.fechaInicio.Value,
                             fechaTermino = p.fechaTermino.Value
                         }).ToList();

            return lista;
        }

        public List<TrabajadorPres> ListaTrabajadoresRequerimiento(int anio)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var listaPuestoRequerimiento = (from r in contexto.RequerimientoRecursoHumano
                                            join pr in contexto.PuestoRequerimiento on r.idReqRecHum equals pr.idReqRecHum
                                            where r.estado != 1 && r.anio == anio && pr.estado != 1
                                            select pr).ToList();


            var lista = (from t in contexto.TraerDatosTrabajador()
                         join pr in listaPuestoRequerimiento on t.idTrabajador equals pr.idTrabajador into trabPuestoReq
                         from tpr in trabPuestoReq.DefaultIfEmpty()
                         where tpr == null
                         select new TrabajadorPres
                         {
                             idTrabajador = t.idTrabajador,
                             nroDocIdentidad = t.nroDocIdentidad,
                             trabajador = t.trabajador
                         }).ToList();

            //var lista = (from r in contexto.RequerimientoRecursoHumano
            //             join pr in contexto.PuestoRequerimiento on r.idReqRecHum equals pr.idReqRecHum
            //             join t in contexto.TraerDatosTrabajador() on pr.idTrabajador equals t.idTrabajador
            //             where r.estado != 1 && r.anio == anio && pr.estado != 1
            //             select new TrabajadorPres
            //             {
            //                 idTrabajador = t.idTrabajador,
            //                 nroDocIdentidad = t.nroDocIdentidad,
            //                 trabajador = t.trabajador
            //             }).ToList();

            return lista;
        }
        public List<PuestoRequerimientoAnualPres> TraerListaPuestoRequerimientoAnual(int anio)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.TraerListaPuestoRequerimientoAnual(anio).ToList();
        }
        
    }
}
