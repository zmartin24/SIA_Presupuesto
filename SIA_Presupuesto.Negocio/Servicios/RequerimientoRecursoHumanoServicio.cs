using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class RequerimientoRecursoHumanoServicio : ServicioBase, IRequerimientoRecursoHumanoServicio
    {
        IRequerimientoRecursoHumanoRepositorio repositorio;

        public RequerimientoRecursoHumanoServicio(IRequerimientoRecursoHumanoRepositorio repositorio)
        {
            this.repositorio = repositorio;
            resultado = new Resultado();
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private RequerimientoRecursoHumano Clonar(RequerimientoRecursoHumano requerimientoRecursoHumano)
        {
            return new RequerimientoRecursoHumano
            {
                idReqRecHum = requerimientoRecursoHumano.idReqRecHum,
                idArea = requerimientoRecursoHumano.idArea,
                idMoneda = requerimientoRecursoHumano.idMoneda,
                descripcion = requerimientoRecursoHumano.descripcion,
                fechaEmision = requerimientoRecursoHumano.fechaEmision,
                fechaAprobacion = requerimientoRecursoHumano.fechaAprobacion,
                anio = requerimientoRecursoHumano.anio,
                usuCrea = requerimientoRecursoHumano.usuCrea,
                fechaCrea = requerimientoRecursoHumano.fechaCrea,
                usuEdita = requerimientoRecursoHumano.usuEdita,
                fechaEdita = requerimientoRecursoHumano.fechaEdita,
                estado = requerimientoRecursoHumano.estado
            };
        }

        public Resultado Nuevo(RequerimientoRecursoHumano requerimientoRecursoHumano)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(requerimientoRecursoHumano);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoRecursoHumano);
                resultado.id = requerimientoRecursoHumano.idReqRecHum;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, requerimientoRecursoHumano, ex);
            }

            return resultado;
        }
        public Resultado Modificar(RequerimientoRecursoHumano requerimientoRecursoHumano)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(Clonar(requerimientoRecursoHumano));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, requerimientoRecursoHumano);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, requerimientoRecursoHumano, ex);
            }

            return resultado;
        }
        public Resultado ModificarSinClonar(RequerimientoRecursoHumano requerimientoRecursoHumano)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(requerimientoRecursoHumano);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, requerimientoRecursoHumano);
                resultado.id = requerimientoRecursoHumano.idReqRecHum;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, requerimientoRecursoHumano, ex);
            }
            return resultado;
        }
        public Resultado Anular(RequerimientoRecursoHumano requerimientoRecursoHumano, string usuario)
        {
            
            try
            {
                resultado.esCorrecto = repositorio.AnularRequerimientoRecursoHumano(requerimientoRecursoHumano.idReqRecHum, usuario);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, requerimientoRecursoHumano, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados
        public RequerimientoRecursoHumano BuscarPorCodigo(int idReqRecHum)
        {
            return repositorio.TraerPorID(idReqRecHum);
        }
        public RequerimientoRecursoHumanoPres BuscarRequerimientoRecursoHumano(int idReqRecHum)
        {
            return repositorio.BuscarRequerimientoRecursoHumano(idReqRecHum);
        }
        public List<RequerimientoRecursoHumanoPres> TraerListaRequerimientoRecursoHumano(int anio, int idUsuario)
        {
            return repositorio.TraerListaRequerimientoRecursoHumano(anio, idUsuario);
        }
        public List<RequerimientoRecursoHumanoDetallePres> TraerListaRequerimientoRecursoHumanoDetalle(int idReqRecHum)
        {
            return repositorio.TraerListaRequerimientoRecursoHumanoDetalle(idReqRecHum);
        }
        #endregion

        #region Reportes
        public List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHH(int anio, int idDireccion, int idReqRecHum)
        {
            return repositorio.TraerReporteRequerimientoRRHH(anio, idDireccion, idReqRecHum);
        }
        public List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHHDireccionArea(int anio, int idDireccion, int idSubdireccion, int idReqRecHum)
        {
            return repositorio.TraerReporteRequerimientoRRHHDireccionArea(anio, idDireccion, idSubdireccion, idReqRecHum);
        }
        public List<ReporteRequerimientoRRHHDireccionImportePres> TraerReporteRequerimientoRRHHDireccionImporte(int anio, int idDireccion, int idSubdireccion, int idReqRecHum, int idMoneda)
        {
            return repositorio.TraerReporteRequerimientoRRHHDireccionImporte(anio, idDireccion, idSubdireccion, idReqRecHum, idMoneda);
            
        }

        #endregion
    }
}
