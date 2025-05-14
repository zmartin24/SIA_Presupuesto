using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IReajusteMensualAreaRepositorio : IRepositorio<ReajusteMensualArea>
    {
        List<ReajusteMensualAreaPres> TraerListaReajusteMensualArea(int idEvaMenPro);
        List<ReajusteMensualAreaExporta> TraerListaReajusteMensualExporta(int idEvaMenPro);
        List<ReporteReajusteMensualExportaPres> TraerReporteReajusteMensualExporta(int idReaMenPro, int idMoneda);
    }
}
