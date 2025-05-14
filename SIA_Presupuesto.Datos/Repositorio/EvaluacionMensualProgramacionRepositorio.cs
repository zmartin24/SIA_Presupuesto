using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class EvaluacionMensualProgramacionRepositorio : Repositorio<EvaluacionMensualProgramacion>, IEvaluacionMensualProgramacionRepositorio
    {
        public EvaluacionMensualProgramacionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<EvaluacionMensualPresupuestoPres> TraerListaEvaluacionMensualPresupuesto(int anio, int mes)
        {
            List<EvaluacionMensualPresupuestoPres> lista = new List<EvaluacionMensualPresupuestoPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionMensualPresupuesto(anio, mes).ToList();

            return lista;
        }

        public List<FondoEjecutado> TraerFondoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string codigoPres)
        {
            List<FondoEjecutado> lista = new List<FondoEjecutado>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerFondoEjecutados(idMoneda, anio, mesInicio, mesFin, codigoPres).ToList();

            return lista;
        }

        public List<ResumenEvaFinanCorahSaal> TraerResumenEvaFinanCorahSaal(int idTipRep, int anio, int mes)
        {
            List<ResumenEvaFinanCorahSaal> lista = new List<ResumenEvaFinanCorahSaal>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerResumenEvaFinanCorahSaal(idTipRep, anio, mes).ToList();

            return lista;
        }

        public List<FondoEjecutadosSubpresupuesto> TraerFondoEjecutadosSubpresupuesto(int idMoneda, int idGruPre, int idPresupuesto, int idSubpresupuesto)
        {
            List<FondoEjecutadosSubpresupuesto> lista = new List<FondoEjecutadosSubpresupuesto>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerFondoEjecutadosSubpresupuesto(idMoneda, idGruPre, idPresupuesto, idSubpresupuesto).ToList();

            return lista;
        }

        public List<FondoEjecutadoFecha> TraerFondoEjecutadosFechas(int idMoneda, int idGruPre, int idPresupuesto, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<FondoEjecutadoFecha> lista = new List<FondoEjecutadoFecha>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerFondoEjecutadosFechas(idMoneda, idGruPre, idPresupuesto, fechaDesde, fechaHasta).ToList();

            return lista;
        }

        public void GuardarFondoEjecutado(int id, string usuario, int idMoneda, int anio, int mesInicio, int mesFin, string codigoPres)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(240);
            contexto.GuardarFondoEjecutados(id, usuario, idMoneda, anio, mesInicio, mesFin, codigoPres);
        }
    }
}
