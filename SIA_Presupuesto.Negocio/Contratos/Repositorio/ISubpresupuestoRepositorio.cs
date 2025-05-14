using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface ISubpresupuestoRepositorio : IRepositorio<Subpresupuesto>
    {
        SubPresupuestoPoco BuscarSubPresupuestoPoco(int idSubPresupuesto);
        List<Subpresupuesto> TraerListaSubPresupuestoPorPresupuesto(int idPresupuesto);
        List<SubPresupuestoPoco> TraerListaSubPresupuesto(int vanio);
        List<SubPresupuestoAreaPres> TraerListaSubPresupuestoAreaPres(int idSubPresupuesto);
        List<ReporteSubpresupuestoExportaPres> TraerReporteSubpresupuestoExporta(int idSubPresupuesto, int idMoneda);
        Resultado VerificarSubpresupuesto(int idPresupuesto);
    }
}
