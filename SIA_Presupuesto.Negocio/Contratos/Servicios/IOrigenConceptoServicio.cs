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
    public interface IOrigenConceptoServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(OrigenConcepto OrigenConcepto);

        Resultado Modificar(OrigenConcepto OrigenConcepto);

        Resultado Anular(OrigenConcepto OrigenConcepto);


        #endregion

        #region Busquedas y listados

        OrigenConcepto BuscarPorCodigo(int idOrigenConcepto);

        List<OrigenConcepto> listarTodos();

        List<OrigenConcepto> TraerTodosActivos();


        #endregion
    }
}
