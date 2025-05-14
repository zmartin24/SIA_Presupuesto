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
    public class TipoReporteServicio : ServicioBase, ITipoReporteServicio
    {
        ITipoReporteRepositorio repositorio;

        public TipoReporteServicio(ITipoReporteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        public Resultado Nuevo(TipoReporte TipoReporte)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(TipoReporte);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, TipoReporte);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, TipoReporte, ex);
            }

            return resultado;
        }

        public Resultado Modificar(TipoReporte TipoReporte)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(TipoReporte);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, TipoReporte);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, TipoReporte, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(TipoReporte TipoReporte)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(TipoReporte);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, TipoReporte);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, TipoReporte, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public TipoReporte BuscarPorCodigo(int idTipoReporte)
        {
            return repositorio.TraerPorID(idTipoReporte);
        }

        public List<TipoReporte> listarTodos()
        {
            return repositorio.TraerTodos();
        }

        #endregion
    }
}
