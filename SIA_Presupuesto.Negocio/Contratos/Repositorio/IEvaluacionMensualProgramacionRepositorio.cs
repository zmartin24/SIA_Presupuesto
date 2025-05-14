using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IEvaluacionMensualProgramacionRepositorio : IRepositorio<EvaluacionMensualProgramacion>
    {
        List<EvaluacionMensualPresupuestoPres> TraerListaEvaluacionMensualPresupuesto(int anio, int mes);

        List<FondoEjecutado> TraerFondoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string codigoPres);

        void GuardarFondoEjecutado(int id, string usuario, int idMoneda, int anio, int mesInicio, int mesFin, string codigoPres);

        List<ResumenEvaFinanCorahSaal> TraerResumenEvaFinanCorahSaal(int idTipRep, int anio, int mes);

        List<FondoEjecutadosSubpresupuesto> TraerFondoEjecutadosSubpresupuesto(int idMoneda, int idGruPre, int idPresupuesto, int idSubpresupuesto);

        List<FondoEjecutadoFecha> TraerFondoEjecutadosFechas(int idMoneda, int idGruPre, int idPresupuesto, DateTime fechaDesde, DateTime fechaHasta);
    }
}
