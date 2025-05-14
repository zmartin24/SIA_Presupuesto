using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IEvaluacionMensualAreaRepositorio : IRepositorio<EvaluacionMensualArea>
    {
        List<EvaluacionMensualAreaPres> TraerListaEvaluacionMensualArea(int idEvaMenPro);
        List<EvaluacionMensualAreaExporta> TraerListaEvaluacionMensualExporta(int idEvaMenPro);
        List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(int idProAnu, int anio, int mesRea, int mesEva);
        List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(string idsProAnu, int anio, int mesRea, int mesEva);
        List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta2(int idProAnu, int anio, int mesRea, int mesEva);
        List<ReporteEvaluacionMensualExportaPres> TraerReporteEvaluacionMensualExporta(int idEvaMenPro, int idMoneda);
        List<ReporteEvaluacionReajusteMensualExportaPres> TraerReporteEvaluacionReajusteMensualExporta(int idProAnu, int anio, int mesRea, int mesEva, int idMoneda);
    }
}
