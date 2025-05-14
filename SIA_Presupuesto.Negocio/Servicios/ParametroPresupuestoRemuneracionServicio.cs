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
    public class ParametroPresupuestoRemuneracionServicio : ServicioBase, IParametroPresupuestoRemuneracionServicio
    {
        IParametroPresupuestoRemuneracionRepositorio repositorio;

        public ParametroPresupuestoRemuneracionServicio(IParametroPresupuestoRemuneracionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private ParametroPresupuestoRemuneracion Clonar(ParametroPresupuestoRemuneracion ejeOperativoOld)
        {
            return new ParametroPresupuestoRemuneracion
            {
                idConPreRem = ejeOperativoOld.idConPreRem,
                idParPreRem = ejeOperativoOld.idParPreRem,
                importe = ejeOperativoOld.importe,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
            };
        }

        #region Operaciones
        public Resultado Nuevo(ParametroPresupuestoRemuneracion ParametroPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(ParametroPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ParametroPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ParametroPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Modificar(ParametroPresupuestoRemuneracion ParametroPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(ParametroPresupuestoRemuneracion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ParametroPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ParametroPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Anular(ParametroPresupuestoRemuneracion ParametroPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ParametroPresupuestoRemuneracion.estado = Estados.Anulado;
                ParametroPresupuestoRemuneracion.fechaEdita = DateTime.Now;

                repositorio.Actualizar(ParametroPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ParametroPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ParametroPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public ParametroPresupuestoRemuneracion BuscarPorCodigo(int idParametroPresupuestoRemuneracion)
        {
            return repositorio.TraerPorID(idParametroPresupuestoRemuneracion);
        }

        public List<ParametroPresupuestoRemuneracion> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<ParametroPresupuestoRemuneracion> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        public List<ParametroPoco> TraerParametrosPresentacion()
        {
            return repositorio.TraerParametrosPresentacion();
        }

        #endregion
    }
}
