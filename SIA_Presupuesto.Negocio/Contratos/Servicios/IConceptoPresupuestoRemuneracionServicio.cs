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
    public interface IConceptoPresupuestoRemuneracionServicio : IServicio
    {


        #region Operaciones
        Resultado Nuevo(ConceptoPresupuestoRemuneracion ConceptoPresupuestoRemuneracion);

        Resultado Modificar(ConceptoPresupuestoRemuneracion ConceptoPresupuestoRemuneracion);

        Resultado Anular(ConceptoPresupuestoRemuneracion ConceptoPresupuestoRemuneracion);

        #endregion

        #region Busquedas y listados

        ConceptoPresupuestoRemuneracion BuscarPorCodigo(int idConceptoPresupuestoRemuneracion);

        List<ConceptoPresupuestoRemuneracion> listarTodos();

        List<ConceptoPresupuestoRemuneracion> TraerTodosActivos();

        List<ConceptoPresupuestoRemuneracion> TraerTodosActivos(string origen);

        List<ConceptoPresupuestoRemuneracion> TraerConceptosEstructura(int idEstPreRem, int idConcepto);

        List<ConceptoPresupuestoRemuneracion> TraerConceptosMenosdeEstructura(int idEstPreRem);


        #endregion
    }
}
