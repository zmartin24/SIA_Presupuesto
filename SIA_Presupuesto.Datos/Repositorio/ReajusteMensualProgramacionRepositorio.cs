using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ReajusteMensualProgramacionRepositorio : Repositorio<ReajusteMensualProgramacion>, IReajusteMensualProgramacionRepositorio
    {
        public ReajusteMensualProgramacionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ReajusteMensualPresupuestoPres> TraerListaReajusteMensualPresupuesto(int anio, int mes)
        {
            List<ReajusteMensualPresupuestoPres> lista = new List<ReajusteMensualPresupuestoPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaReajusteMensualPresupuesto(anio, mes).ToList();

            return lista;
        }

        public void GuardarFondoEjecutado(int idProAnu, int idReaMenPro, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1550);
            contexto.GuardarDetalleReajuste(idProAnu, idReaMenPro, usuario);
        }

        public void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            contexto.GuardarDetalleReajusteRRHH(idProAnu, idReaMenPro, codigos, usuario, indicaEliminacion);
        }
        public void GuardarDetalleRequerimientoMensualEnReajuste(int idReaMenPro, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(500);
            contexto.GuardarDetalleRequerimientoMensualEnReajuste(idReaMenPro, usuario);
        }
        public ReajusteMensualArea BuscarPorCodigoAreaCuentaContable(int idReaMenPro, int idArea, int idCueCon)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            CuentaContable objCuenta = contexto.CuentaContable.Where(x => x.idCueCon == idCueCon && x.estado != false).FirstOrDefault();

            var objReaMenArea = from rma in contexto.ReajusteMensualArea
                                join cc in contexto.CuentaContable on rma.idCueCon equals cc.idCueCon
                                where
                                    rma.idReaMenPro == idReaMenPro && rma.idArea == idArea && rma.estado != 1 && cc.numCuenta == objCuenta.numCuenta
                                select rma;


            return objReaMenArea.FirstOrDefault();
        }

        public List<ResumenReajustePresupuestoPorSubdirecciones> TraerResumenReajustePresupuestoPorSubdirecciones(int anio, int idDireccion, int mesReajuste, int mesEvaluacion)
        {
            List<ResumenReajustePresupuestoPorSubdirecciones> lista = new List<ResumenReajustePresupuestoPorSubdirecciones>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerResumenReajustePresupuestoPorSubdirecciones(anio, idDireccion, mesReajuste, mesEvaluacion).ToList();

            return lista;
        }

        public List<CalendarioEvaluacionyAjusteAnual> TraerCalendarioEvaluacionyAjusteAnual(int anio, int idFueFin, int mesAjuste, int mesEval, int idPresupuesto)
        {
            List<CalendarioEvaluacionyAjusteAnual> lista = new List<CalendarioEvaluacionyAjusteAnual>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerCalendarioEvaluacionyAjusteAnual(anio, idFueFin, mesAjuste, mesEval, idPresupuesto)
                .ToList();

            return lista;
        }

        public List<ConsolidadoEvaluacionReajuste> TraerConsolidadoEvaluacionReajustePorDirecciones(int anio, int idFueFin, int mesAjuste, int mesEval)
        {
            List<ConsolidadoEvaluacionReajuste> lista = new List<ConsolidadoEvaluacionReajuste>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerConsolidadoEvaluacionReajustePorDirecciones(anio, idFueFin, mesAjuste, mesEval)
                .ToList();

            return lista;
        }

        public List<EvaluacionReajustePorSubdireccion> TraerResumenEvaluacionReajustePorSubdirecciones(int anio, int idDireccion, int idGruPre, int mesAjuste, int mesEval)
        {
            List<EvaluacionReajustePorSubdireccion> lista = new List<EvaluacionReajustePorSubdireccion>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerResumenEvaluacionReajustePorSubdirecciones(anio, idDireccion, idGruPre, mesAjuste, mesEval)
                .ToList();

            return lista;
        }


        public List<int> TraerListaReajusteMensualAreas(int idReaMenPro)
        {
            List<int> lista = new List<int>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaReajusteMensualAreas(idReaMenPro).Select(s => (Int32)s)
                .ToList();

            //lista = contexto.TraerListaReajusteMensualArea(idProAnu).Select(s => (Int32)s)

            return lista;
        }

    }
}
