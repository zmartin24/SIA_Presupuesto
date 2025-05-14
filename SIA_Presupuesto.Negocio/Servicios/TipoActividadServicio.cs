using System;
using System.Collections.Generic;
using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Base;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class TipoActividadServicio : ServicioBase, ITipoActividadServicio
    {
        ITipoActividadRepositorio repositorio;

        public TipoActividadServicio(ITipoActividadRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        #region Operaciones
        public Resultado Nuevo(TipoActividad tipoActividad)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(tipoActividad);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, tipoActividad);
                resultado.id = tipoActividad.idTipoActividad;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, tipoActividad, ex);
            }

            return resultado;
        }
        public Resultado Modificar(TipoActividad tipoActividad)
        {
            try
            {
                TipoActividad objTipoActividad = repositorio.TraerPorID(tipoActividad.idTipoActividad);

                
                objTipoActividad.nombre = tipoActividad.nombre;
                

                objTipoActividad.usuEdita = tipoActividad.usuEdita;
                objTipoActividad.fechaEdita = tipoActividad.fechaEdita;

                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objTipoActividad);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, tipoActividad);
                resultado.id = tipoActividad.idTipoActividad;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, tipoActividad, ex);
            }

            return resultado;
        }

        public Resultado Anular(int idTipoActivad)
        {
            TipoActividad objTipoActividad = repositorio.TraerPorID(idTipoActivad);
            try
            {
                objTipoActividad.estado = false;
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objTipoActividad);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, objTipoActividad);
                resultado.id = objTipoActividad.idTipoActividad;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, objTipoActividad, ex);
            }

            return resultado;
        }
        #endregion

        #region Listas
        public List<TipoActividad> ListaTodos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado == true);
        }
        #endregion
    }
}
