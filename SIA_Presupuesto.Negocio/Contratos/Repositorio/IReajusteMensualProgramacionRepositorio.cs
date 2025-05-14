using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IReajusteMensualProgramacionRepositorio : IRepositorio<ReajusteMensualProgramacion>
    {
        ReajusteMensualArea BuscarPorCodigoAreaCuentaContable(int idReaMenPro, int idArea, int idCueCon);
        List<ReajusteMensualPresupuestoPres> TraerListaReajusteMensualPresupuesto(int anio, int mes);
        void GuardarFondoEjecutado(int idProAnu, int idReaMenPro, string usuario);
        List<ResumenReajustePresupuestoPorSubdirecciones> TraerResumenReajustePresupuestoPorSubdirecciones(int anio, int idDireccion, int mesReajuste, int mesEvaluacion);
        List<CalendarioEvaluacionyAjusteAnual> TraerCalendarioEvaluacionyAjusteAnual(int anio, int idFueFin, int mesAjuste, int mesEval, int idPresupuesto);
        List<ConsolidadoEvaluacionReajuste> TraerConsolidadoEvaluacionReajustePorDirecciones(int anio, int idFueFin, int mesAjuste, int mesEval);
        List<EvaluacionReajustePorSubdireccion> TraerResumenEvaluacionReajustePorSubdirecciones(int anio, int idDireccion, int idGruPre, int mesAjuste, int mesEval);
        List<int> TraerListaReajusteMensualAreas(int idReaMenPro);
        void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion);
        void GuardarDetalleRequerimientoMensualEnReajuste(int idReaMenPro, string usuario);
    }
}
