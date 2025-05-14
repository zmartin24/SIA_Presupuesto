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
    public class ModalidadServicio : ServicioBase, IModalidadServicio
    {
        IModalidadRepositorio repositorio;

        public ModalidadServicio(IModalidadRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private Modalidad Clonar(Modalidad ModalidadOld)
        {
            return new Modalidad
            {
                idModalidad = ModalidadOld.idModalidad,
                descripcion = ModalidadOld.descripcion,
                usuCrea = ModalidadOld.usuCrea,
                fechaCrea = ModalidadOld.fechaCrea,
                usuEdita = ModalidadOld.usuEdita,
                fechaEdita = ModalidadOld.fechaEdita,
                estado = ModalidadOld.estado
            };
        }

        #region Operaciones
        public Resultado Nuevo(Modalidad Modalidad)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(Modalidad);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, Modalidad);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, Modalidad, ex);
            }

            return resultado;
        }

        public Resultado Modificar(Modalidad Modalidad)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(Modalidad));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, Modalidad);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, Modalidad, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(Modalidad Modalidad)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                Modalidad.estado = Estados.Anulado;
                Modalidad.fechaEdita = DateTime.Now;

                repositorio.Actualizar(Modalidad);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, Modalidad);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, Modalidad, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public Modalidad BuscarPorCodigo(int idModalidad)
        {
            return repositorio.TraerPorID(idModalidad);
        }

        public List<Modalidad> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<Modalidad> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        #endregion
    }
}
