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
    public class GrupoPresupuestoServicio : ServicioBase, IGrupoPresupuestoServicio
    {
        IGrupoPresupuestoRepositorio repositorio;

        public GrupoPresupuestoServicio(IGrupoPresupuestoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        public Resultado Nuevo(GrupoPresupuesto GrupoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(GrupoPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, GrupoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, GrupoPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Anular(GrupoPresupuestoPoco GrupoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                GrupoPresupuesto objGrupoPresupuesto = repositorio.TraerPorID(GrupoPresupuesto.idGrupoPresupuesto);
                objGrupoPresupuesto.estado = 1;

                repositorio.Actualizar(objGrupoPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, GrupoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, GrupoPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(GrupoPresupuesto GrupoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                GrupoPresupuesto objGrupoPresupuesto = repositorio.TraerPorID(GrupoPresupuesto.idGruPre);
                objGrupoPresupuesto.idGruPre = GrupoPresupuesto.idGruPre;
                objGrupoPresupuesto.codigo = GrupoPresupuesto.codigo;
                objGrupoPresupuesto.descripcion = GrupoPresupuesto.descripcion;
                objGrupoPresupuesto.abreviatura = GrupoPresupuesto.abreviatura;
                objGrupoPresupuesto.observacion = GrupoPresupuesto.observacion;
                objGrupoPresupuesto.esEncargo = GrupoPresupuesto.esEncargo;
                objGrupoPresupuesto.usuEdita = GrupoPresupuesto.usuEdita;
                objGrupoPresupuesto.fechaEdita = GrupoPresupuesto.fechaEdita;
                objGrupoPresupuesto.grupo = GrupoPresupuesto.grupo;
                repositorio.Actualizar(objGrupoPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, GrupoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, GrupoPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(GrupoPresupuesto GrupoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(GrupoPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, GrupoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, GrupoPresupuesto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public GrupoPresupuesto BuscarPorCodigo(int idGrupoPresupuesto)
        {
            return repositorio.TraerPorID(idGrupoPresupuesto);
        }

        public GrupoPresupuestoPoco ObtenerxId(int idGrupo)
        {
            return repositorio.ObtenerxId(idGrupo);
        }

        public List<GrupoPresupuesto> listarTodos()
        {
            return repositorio.TraerTodos();
        }

        public List<GrupoPresupuestoPres> TraerListaGrupoPresupuestoPres()
        {
            return repositorio.TraerListaGrupoPresupuestoPres();
        }

        public List<GrupoPresupuesto> TraerListaGrupoPresupuesto()
        {
            return repositorio.TraerListaGrupoPresupuesto();
        }

        public List<GrupoPresupuestoPoco> ListaGrupo()
        {
            return repositorio.ListaGrupo();
        }

        #endregion
    }
}
