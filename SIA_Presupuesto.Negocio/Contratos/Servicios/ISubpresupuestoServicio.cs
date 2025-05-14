using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface ISubpresupuestoServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(Subpresupuesto Subpresupuesto);

        Resultado Modificar(Subpresupuesto Subpresupuesto);

        Resultado Eliminar(Subpresupuesto Subpresupuesto);

        #endregion

        #region Busquedas y listados

        Subpresupuesto BuscarPorCodigo(int idSubpresupuesto);
        Subpresupuesto BuscarPorDescripcion(int idProAnu, string descripcion);
        SubPresupuestoPoco BuscarSubPresupuestoPoco(int idSubPresupuesto);
        List<Subpresupuesto> listarTodos();
        List<Subpresupuesto> TraerListaSubPresupuestoPorPresupuesto(int idPresupuesto);

        List<SubPresupuestoPoco> TraerListaSubPresupuesto(int vanio);
        List<SubPresupuestoAreaPres> TraerListaSubPresupuestoAreaPres(int idSubPresupuesto);
        List<ReporteSubpresupuestoExportaPres> TraerReporteSubpresupuestoExporta(int idSubPresupuesto, int idMoneda);
        Resultado VerificarSubpresupuesto(int idPresupuesto);

        Resultado Anular(SubPresupuestoPoco SubPresupuesto);

        Resultado Aprobar(SubPresupuestoPoco SubPresupuesto);

        Resultado Liquidar(SubPresupuestoPoco SubPresupuesto);

        #endregion
    }
}
