using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PresupuestoServicio : ServicioBase, IPresupuestoServicio
    {
        IPresupuestoRepositorio repositorio;

        public PresupuestoServicio(IPresupuestoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        public Resultado Nuevo(Presupuesto Presupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(Presupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, Presupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, Presupuesto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(Presupuesto Presupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Presupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, Presupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, Presupuesto, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(Presupuesto Presupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(Presupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, Presupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, Presupuesto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public Presupuesto BuscarPorCodigo(int idPresupuesto)
        {
            return repositorio.TraerPorID(idPresupuesto);
        }

        public List<Presupuesto> listarTodos()
        {
            return repositorio.TraerTodos();
        }

        public List<PresupuestoPres> TraerListaPresupuestoPres()
        {
            return repositorio.TraerListaPresupuestoPres();
        }
        public List<Presupuesto> TraerListaPresupuestoPorGrupoPresupuesto(int idGruPre)
        {
            return repositorio.TraerListaPresupuestoPorGrupoPresupuesto(idGruPre);
        }

        #endregion
    }
}
