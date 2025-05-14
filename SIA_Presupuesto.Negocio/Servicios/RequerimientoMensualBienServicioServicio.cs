using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Utilitario.Util;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class RequerimientoMensualBienServicioServicio : ServicioBase, IRequerimientoMensualBienServicioServicio
    {
        IRequerimientoMensualBienServicioRepositorio repositorio;
        IRequerimientoMensualDetalleRepositorio repoDetalle;

        public RequerimientoMensualBienServicioServicio(IRequerimientoMensualBienServicioRepositorio repositorio, IRequerimientoMensualDetalleRepositorio repoDetalle)
        {
            this.repositorio = repositorio;
            this.repoDetalle = repoDetalle;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private RequerimientoMensualBienServicio Clonar(RequerimientoMensualBienServicio requerimientoMensualBienServicio)
        {
            return new RequerimientoMensualBienServicio
            {
                idReqMenBieSer = requerimientoMensualBienServicio.idReqMenBieSer,
                tipo = requerimientoMensualBienServicio.tipo,
                idArea = requerimientoMensualBienServicio.idArea,
                idMoneda = requerimientoMensualBienServicio.idMoneda,
                descripcion = requerimientoMensualBienServicio.descripcion,
                fechaEmision = requerimientoMensualBienServicio.fechaEmision,
                idProAnu = requerimientoMensualBienServicio.idProAnu,
                fechaAprobacion = requerimientoMensualBienServicio.fechaAprobacion,
                fechaAsigPre = requerimientoMensualBienServicio.fechaAsigPre,
                anio = requerimientoMensualBienServicio.anio,
                mes = requerimientoMensualBienServicio.mes,
                
                usuCrea = requerimientoMensualBienServicio.usuCrea,
                fechaCrea = requerimientoMensualBienServicio.fechaCrea,
                usuEdita = requerimientoMensualBienServicio.usuEdita,
                fechaEdita = requerimientoMensualBienServicio.fechaEdita,
                estado = requerimientoMensualBienServicio.estado
            };
        }

        private RequerimientoMensualDetalle Clonar(RequerimientoMensualDetalle requerimientoMensualDetalle)
        {
            return new RequerimientoMensualDetalle
            {
                idReqMenDet = requerimientoMensualDetalle.idReqMenDet,
                idReqMenBieSer = requerimientoMensualDetalle.idReqMenBieSer,
                idParPre = requerimientoMensualDetalle.idParPre,
                idProducto = requerimientoMensualDetalle.idProducto,
                idCueCon = requerimientoMensualDetalle.idCueCon,
                descripcion = requerimientoMensualDetalle.descripcion,
                idUnidad = requerimientoMensualDetalle.idUnidad,
                precio = requerimientoMensualDetalle.precio,
                cantidad = requerimientoMensualDetalle.cantidad,
                cantPresupuestada = requerimientoMensualDetalle.cantPresupuestada,
                importe = requerimientoMensualDetalle.importe,
                idTipIng = requerimientoMensualDetalle.idTipIng,
                codPat = requerimientoMensualDetalle.codPat,
                justificacion = requerimientoMensualDetalle.justificacion,
                docReferencia = requerimientoMensualDetalle.docReferencia,

                usuCrea = requerimientoMensualDetalle.usuCrea,
                fechaCrea = requerimientoMensualDetalle.fechaCrea,
                usuEdita = requerimientoMensualDetalle.usuEdita,
                fechaEdita = requerimientoMensualDetalle.fechaEdita,
                estado = requerimientoMensualDetalle.estado
            };
        }

        public Resultado Nuevo(RequerimientoMensualBienServicio requerimientoMensualBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(requerimientoMensualBienServicio);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoMensualBienServicio);
                resultado.id = requerimientoMensualBienServicio.idReqMenBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, requerimientoMensualBienServicio, ex);
            }

            return resultado;
        }
        public Resultado Nuevo(RequerimientoMensualBienServicio requerimientoMensualBienServicio, string idsReqBieSer)
        {
            TransactionOptions Tranconfiguracion = new TransactionOptions()
            {
                Timeout = TransactionManager.MaximumTimeout,
                IsolationLevel = IsolationLevel.Serializable
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, Tranconfiguracion))
            {
                try
                {
                    bool res = true;
                    
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                    repositorio.Agregar(requerimientoMensualBienServicio);
                    unidadTrabajo.GuardarCambios();

                    if (idsReqBieSer.Length > 0)
                    {
                        res = repositorio.GuardarDetalleReqMensualBienServicioDesdeReqAnual(requerimientoMensualBienServicio.idReqMenBieSer, requerimientoMensualBienServicio.tipo, requerimientoMensualBienServicio.mes, idsReqBieSer, requerimientoMensualBienServicio.usuCrea);
                        if (res)
                        {
                            scope.Complete();
                        }
                    }

                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoMensualBienServicio);
                    resultado.id = requerimientoMensualBienServicio.idReqMenBieSer;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, requerimientoMensualBienServicio, ex);
                }
            }
            return resultado;
        }
        public Resultado Modificar(RequerimientoMensualBienServicio requerimientoMensualBienServicio)
        {

            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(Clonar(requerimientoMensualBienServicio));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, requerimientoMensualBienServicio);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, requerimientoMensualBienServicio, ex);
            }

            return resultado;
        }

        public Resultado ModificarSinClonar(RequerimientoMensualBienServicio requerimientoMensualBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;


                repositorio.Actualizar(requerimientoMensualBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, requerimientoMensualBienServicio);
                resultado.id = requerimientoMensualBienServicio.idReqMenBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, requerimientoMensualBienServicio, ex);
            }

            return resultado;
        }

        public Resultado Anular(RequerimientoMensualBienServicio requerimientoMensualBienServicio, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                requerimientoMensualBienServicio.estado = Estados.Anulado;
                requerimientoMensualBienServicio.fechaEdita = DateTime.Now;
                requerimientoMensualBienServicio.usuEdita = usuario;

                repositorio.Actualizar(requerimientoMensualBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, requerimientoMensualBienServicio);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, requerimientoMensualBienServicio, ex);
            }

            return resultado;
        }
        public Resultado AsignarPresupuestoAnual(RequerimientoMensualBienServicio requerimientoMensualBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                //requerimientoMensualBienServicio.estado = Estados.Anulado;
                //requerimientoMensualBienServicio.fechaAprobacion = DateTime.Now;
                repositorio.Actualizar(requerimientoMensualBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, requerimientoMensualBienServicio);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, requerimientoMensualBienServicio, ex);
            }

            return resultado;
        }
        /*****Detalles*****/
        public Resultado NuevoDetalle(RequerimientoMensualDetalle requerimientoMensualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                repoDetalle.Agregar(requerimientoMensualDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repoDetalle, TipoMensaje.Creacion, requerimientoMensualDetalle, ex);
            }

            return resultado;
        }
       
        public Resultado ModificarDetalles(RequerimientoMensualDetalle requerimientoMensualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                
                repoDetalle.Actualizar(Clonar(requerimientoMensualDetalle));
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, requerimientoMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repoDetalle, TipoMensaje.Modificacion, requerimientoMensualDetalle, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetallesSinClonar(RequerimientoMensualDetalle requerimientoMensualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                
                repoDetalle.Actualizar(requerimientoMensualDetalle);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, requerimientoMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repoDetalle, TipoMensaje.Modificacion, requerimientoMensualDetalle, ex);
            }

            return resultado;
        }

        public Resultado AnularDetalle(RequerimientoMensualDetalle requerimientoMensualDetalle, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repoDetalle.UnidadTrabajo as IUnidadTrabajo;

                requerimientoMensualDetalle.estado = Estados.Anulado;
                requerimientoMensualDetalle.fechaEdita = DateTime.Now;
                requerimientoMensualDetalle.usuEdita = usuario;

                repoDetalle.Actualizar(requerimientoMensualDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, requerimientoMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, requerimientoMensualDetalle, ex);
            }

            return resultado;
        }
        
        public Resultado GuardarDetalleRequerimientoMensualBienesServiciosToClonar(RequerimientoMensualBienServicio requerimientoMensualBienServicio)
        {
            TransactionOptions Tranconfiguracion = new TransactionOptions()
            {
                Timeout = TransactionManager.MaximumTimeout,
                IsolationLevel = IsolationLevel.Serializable
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, Tranconfiguracion))
            {
                bool res = false;
                int idReqMenBieSerOrigen = 0;
                try
                {
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                    idReqMenBieSerOrigen = requerimientoMensualBienServicio.estado;
                    requerimientoMensualBienServicio.estado = 2;

                    repositorio.Agregar(requerimientoMensualBienServicio);
                    unidadTrabajo.GuardarCambios();

                    res = repositorio.GuardarDetalleRequerimientoMensualBienesServiciosToClonar(requerimientoMensualBienServicio.idReqMenBieSer, idReqMenBieSerOrigen, requerimientoMensualBienServicio.usuCrea);

                    if (res)
                    {
                        scope.Complete();
                    }

                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoMensualBienServicio);
                    resultado.id = requerimientoMensualBienServicio.idReqMenBieSer;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, requerimientoMensualBienServicio, ex);
                }
            }
            return resultado;
        }

        public bool GuardarDetalleRequerimientoMensualBienesServiciosToExcel(int idReqMenBieSer, string usuario, DataTable estructuraCarga)
        {
            return repositorio.GuardarDetalleRequerimientoMensualBienesServiciosToExcel(idReqMenBieSer, usuario, estructuraCarga);
        }
        public bool GuardarDetalleReqMensualBienServicioDesdeReqAnual(int idReqMenBieSer, int tipo, int mes, string idsReqBieSer, string usuario)
        {
            return repositorio.GuardarDetalleReqMensualBienServicioDesdeReqAnual(idReqMenBieSer, tipo, mes, idsReqBieSer, usuario);
        }
        #endregion

        #region Busquedas y listados

        public RequerimientoMensualBienServicio BuscarPorCodigo(int idReqMenBieSer)
        {
            return repositorio.TraerPorID(idReqMenBieSer);
        }
        public RequerimientoMensualBienServicio BuscarRequerimientoMensualBienServicio(int idReqMenBieSer)
        {
            return repositorio.BuscarRequerimientoMensualBienServicio(idReqMenBieSer);
        }
        public RequerimientoMensualDetalle BuscarDetallePorCodigo(int idReqMenDet)
        {
            return repoDetalle.TraerPorID(idReqMenDet);
        }

        public List<RequerimientoMensualBienServicio> listarTodos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != 1).ToList();
        }
        public List<RequerimientoMensualBienServicioPres> TraerListaRequerimientoMensualBienServicio(int anio, int mes, int idUsuario, int? idPresupuesto, bool listarTodos)
        {
            return repositorio.TraerListaRequerimientoMensualBienServicio(anio, mes, idUsuario, idPresupuesto, listarTodos);
        }
        
        public List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalle(int idReqMenBieSer)
        {
            return repoDetalle.TraerListaRequerimientoMensualDetalle(idReqMenBieSer);
        }

        public List<RequerimientoMensualDetalle> TraerListarDetallesTodos(int idReqMenBieSer)
        {
            return repoDetalle.TraerVariosPorCondicion(x => x.estado != 1 && x.idReqMenBieSer == idReqMenBieSer).ToList();
        }
        public List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalleDireccion(int idDireccion, int idSubdireccion, string tipo, int idTipoRequerimiento, int anio, int mes)
        {
            return repositorio.TraerListaRequerimientoMensualDetalleDireccion(idDireccion, idSubdireccion, tipo, idTipoRequerimiento, anio, mes);
        }
        #endregion

        #region Reportes
        public List<ReporteRequerimientoMensualSeguimientoPres> TraerReporteRequerimientoMensualSeguimiento(int idReqMenBieSer, int idMoneda)
        {
            return repositorio.TraerReporteRequerimientoMensualSeguimiento(idReqMenBieSer, idMoneda);
        }
        public List<ReporteRequerimientoMensualSeguimientoDetallePres> TraerReporteRequerimientoMensualSeguimientoDetalle(int idReqMenBieSer, int idMoneda)
        {
            return repositorio.TraerReporteRequerimientoMensualSeguimientoDetalle(idReqMenBieSer, idMoneda);
        }
        public List<ReporteRequerimientoMensualSeguimientoForebisePres> TraerReporteRequerimientoMensualSeguimientoForebise(int idReqMenBieSer, int idMoneda)
        {
            return repositorio.TraerReporteRequerimientoMensualSeguimientoForebise(idReqMenBieSer, idMoneda);
        }
        public List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> TraerReporteRequerimientoMensualSeguimientoForebiseCabecera(int idReqMenBieSer, int idMoneda)
        {
            return repositorio.TraerReporteRequerimientoMensualSeguimientoForebiseCabecera(idReqMenBieSer, idMoneda);
        }
        public DataTable ListaEstructuraCargaRequerimientoMensual(int idReqMenBieSer, DataTable estructuraCarga)
        {
            return repositorio.ListaEstructuraCargaRequerimientoMensual(idReqMenBieSer, estructuraCarga);
        }
        #endregion
    }
}
