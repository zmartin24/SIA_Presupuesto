using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class EstructuraPresupuestoRemuneracionServicio : ServicioBase, IEstructuraPresupuestoRemuneracionServicio
    {
        IEstructuraPresupuestoRemuneracionRepositorio repositorio;
        IPropiedadPresupuestoRemuneracionRepositorio repoPropiedad;
        public EstructuraPresupuestoRemuneracionServicio(IEstructuraPresupuestoRemuneracionRepositorio repositorio,
            IPropiedadPresupuestoRemuneracionRepositorio repoPropiedad)
        {
            this.repositorio = repositorio;
            this.repoPropiedad = repoPropiedad;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private EstructuraPresupuestoRemuneracion Clonar(EstructuraPresupuestoRemuneracion ejeOperativoOld)
        {
            return new EstructuraPresupuestoRemuneracion
            {
                idEstPreRem = ejeOperativoOld.idEstPreRem,
                descripcion = ejeOperativoOld.descripcion,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
            };
        }

        private PropiedadPresupuestoRemuneracion Clonar(PropiedadPresupuestoRemuneracion ejeOperativoOld)
        {
            return new PropiedadPresupuestoRemuneracion
            {
                idEstPreRem = ejeOperativoOld.idEstPreRem,
                idConPreRem = ejeOperativoOld.idConPreRem,
                idProPreRem = ejeOperativoOld.idProPreRem,
                valor = ejeOperativoOld.valor,
                tipoValor = ejeOperativoOld.tipoValor,
                orden = ejeOperativoOld.orden,
                visualiza = ejeOperativoOld.visualiza,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
            };
        }

        #region Operaciones
        public Resultado Nuevo(EstructuraPresupuestoRemuneracion EstructuraPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(EstructuraPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EstructuraPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, EstructuraPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado NuevoPropiedad(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPropiedad.Agregar(PropiedadPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, PropiedadPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, PropiedadPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Modificar(EstructuraPresupuestoRemuneracion EstructuraPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(EstructuraPresupuestoRemuneracion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EstructuraPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EstructuraPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado ModificarPropiedad(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPropiedad.Actualizar(Clonar(PropiedadPresupuestoRemuneracion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, PropiedadPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, PropiedadPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Anular(EstructuraPresupuestoRemuneracion EstructuraPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                EstructuraPresupuestoRemuneracion.estado = Estados.Anulado;
                EstructuraPresupuestoRemuneracion.fechaEdita = DateTime.Now;

                repositorio.Actualizar(EstructuraPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EstructuraPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EstructuraPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado AnularPropiedad(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                PropiedadPresupuestoRemuneracion.estado = Estados.Anulado;
                PropiedadPresupuestoRemuneracion.fechaEdita = DateTime.Now;

                repoPropiedad.Actualizar(PropiedadPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, PropiedadPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, PropiedadPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public EstructuraPresupuestoRemuneracion BuscarPorCodigo(int idEstructuraPresupuestoRemuneracion)
        {
            return repositorio.TraerPorID(idEstructuraPresupuestoRemuneracion);
        }

        public PropiedadPresupuestoRemuneracion BuscarPorCodigoPropiedad(int idEstPreRem)
        {
            return repoPropiedad.TraerPorID(idEstPreRem);
        }

        public List<EstructuraPresupuestoRemuneracion> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<EstructuraPresupuestoRemuneracion> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        public List<PropiedadPoco> TraerPropiedadPresentacion()
        {
            return repoPropiedad.TraerPropiedadPresentacion();
        }

        public List<PropiedadPoco> TraerPropiedadPresentacion(int idEstPreRem)
        {
            return repoPropiedad.TraerPropiedadPresentacion(idEstPreRem);
        }

        #endregion
    }
}
