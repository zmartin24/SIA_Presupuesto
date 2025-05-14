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
    public class EjeOperativoServicio : ServicioBase, IEjeOperativoServicio
    {
        IEjeOperativoRepositorio repositorio;

        public EjeOperativoServicio(IEjeOperativoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private EjeOperativo Clonar(EjeOperativo ejeOperativoOld)
        {
            return new EjeOperativo
            {
                idEjeOpe = ejeOperativoOld.idEjeOpe,
                descripcion = ejeOperativoOld.descripcion,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado
            };
        }

        #region Operaciones
        public Resultado Nuevo(EjeOperativo EjeOperativo)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(EjeOperativo);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EjeOperativo);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, EjeOperativo, ex);
            }

            return resultado;
        }

        public Resultado Modificar(EjeOperativo EjeOperativo)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(EjeOperativo));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EjeOperativo);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EjeOperativo, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(EjeOperativo EjeOperativo)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                EjeOperativo.estado = Estados.Anulado;
                EjeOperativo.fechaEdita = DateTime.Now;

                repositorio.Actualizar(EjeOperativo);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EjeOperativo);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EjeOperativo, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public EjeOperativo BuscarPorCodigo(int idEjeOperativo)
        {
            return repositorio.TraerPorID(idEjeOperativo);
        }

        public List<EjeOperativo> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<EjeOperativo> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        #endregion
    }
}
