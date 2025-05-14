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
    public interface IEstructuraPresupuestoRemuneracionServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(EstructuraPresupuestoRemuneracion EstructuraPresupuestoRemuneracion);

        Resultado Modificar(EstructuraPresupuestoRemuneracion EstructuraPresupuestoRemuneracion);

        Resultado Anular(EstructuraPresupuestoRemuneracion EstructuraPresupuestoRemuneracion);

        Resultado NuevoPropiedad(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion);

        Resultado ModificarPropiedad(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion);

        Resultado AnularPropiedad(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion);

        #endregion

        #region Busquedas y listados

        EstructuraPresupuestoRemuneracion BuscarPorCodigo(int idEstructuraPresupuestoRemuneracion);

        PropiedadPresupuestoRemuneracion BuscarPorCodigoPropiedad(int idEstPreRem);

        List<EstructuraPresupuestoRemuneracion> listarTodos();

        List<EstructuraPresupuestoRemuneracion> TraerTodosActivos();

        List<PropiedadPoco> TraerPropiedadPresentacion();

        List<PropiedadPoco> TraerPropiedadPresentacion(int idEstPreRem);


        #endregion
    }
}
