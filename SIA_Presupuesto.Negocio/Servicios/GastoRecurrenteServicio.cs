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
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class GastoRecurrenteServicio : ServicioBase, IGastoRecurrenteServicio
    {
        IGastoRecurrenteRepositorio repositorio;
        IGastoRecurrenteRequerimientoRepositorio repoGasRecReq;
        IGastoRecurrenteDetalleRepositorio repoGasRecDet;
        IGastoRecurrenteDetalleMesRepositorio repoGasRecDetMes;
        IRequerimientoBienServicioRepositorio repoReq;


        public GastoRecurrenteServicio(IGastoRecurrenteRepositorio repositorio, IGastoRecurrenteRequerimientoRepositorio repoGasRecReq
                                            , IGastoRecurrenteDetalleRepositorio repoGasRecDet, IGastoRecurrenteDetalleMesRepositorio repoGasRecDetMes
                                            , IRequerimientoBienServicioRepositorio repoReq)
        {
            this.repositorio = repositorio;
            this.repoGasRecReq = repoGasRecReq;
            this.repoGasRecDet = repoGasRecDet;
            this.repoGasRecDetMes = repoGasRecDetMes;
            this.repoReq = repoReq;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        private GastoRecurrente Clonar(GastoRecurrente gastoRecurrenteOld)
        {
            return new GastoRecurrente
            {
                idGasRec = gastoRecurrenteOld.idGasRec,
                descripcion = gastoRecurrenteOld.descripcion,
                idEntidad = gastoRecurrenteOld.idEntidad,
                anio = gastoRecurrenteOld.anio,
                idMoneda = gastoRecurrenteOld.idMoneda,
                tipCam = gastoRecurrenteOld.tipCam,
                usuCrea = gastoRecurrenteOld.usuCrea,
                fechaCrea = gastoRecurrenteOld.fechaCrea,
                usuEdita = gastoRecurrenteOld.usuEdita,
                fechaEdita = gastoRecurrenteOld.fechaEdita,
                estado = gastoRecurrenteOld.estado
            };
        }
        private GastoRecurrenteRequerimiento Clonar(GastoRecurrenteRequerimiento gastoRecurrenteRequerimientoOld)
        {
            return new GastoRecurrenteRequerimiento
            {
                idGasRecReq = gastoRecurrenteRequerimientoOld.idGasRecReq,
                idGasRec = gastoRecurrenteRequerimientoOld.idGasRec,
                idArea = gastoRecurrenteRequerimientoOld.idArea,
                idMoneda = gastoRecurrenteRequerimientoOld.idMoneda,
                idReqBieSer = gastoRecurrenteRequerimientoOld.idReqBieSer,
                descripcion = gastoRecurrenteRequerimientoOld.descripcion,
                anio = gastoRecurrenteRequerimientoOld.anio,
                usuCrea = gastoRecurrenteRequerimientoOld.usuCrea,
                fechaCrea = gastoRecurrenteRequerimientoOld.fechaCrea,
                usuEdita = gastoRecurrenteRequerimientoOld.usuEdita,
                fechaEdita = gastoRecurrenteRequerimientoOld.fechaEdita,
                estado = gastoRecurrenteRequerimientoOld.estado
            };
        }
        private GastoRecurrenteDetalle Clonar(GastoRecurrenteDetalle gastoRecurrenteDetalleOld)
        {
            return new GastoRecurrenteDetalle
            {
                idGasRecDet = gastoRecurrenteDetalleOld.idGasRecDet,
                idGasRecReq = gastoRecurrenteDetalleOld.idGasRecReq,
                idReqBieSerDet = gastoRecurrenteDetalleOld.idReqBieSerDet,
                idCueCon = gastoRecurrenteDetalleOld.idCueCon,
                idUnidad = gastoRecurrenteDetalleOld.idUnidad,
                idProducto = gastoRecurrenteDetalleOld.idProducto,
                descripcion = gastoRecurrenteDetalleOld.descripcion,
                precio = gastoRecurrenteDetalleOld.precio,
                subTotal = gastoRecurrenteDetalleOld.subTotal,
                usuCrea = gastoRecurrenteDetalleOld.usuCrea,
                fechaCrea = gastoRecurrenteDetalleOld.fechaCrea,
                usuEdita = gastoRecurrenteDetalleOld.usuEdita,
                fechaEdita = gastoRecurrenteDetalleOld.fechaEdita,
                estado = gastoRecurrenteDetalleOld.estado
            };
        }
        

        public Resultado Nuevo(GastoRecurrente gastoRecurrente)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(gastoRecurrente);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, gastoRecurrente);
                resultado.id = gastoRecurrente.idGasRec;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, gastoRecurrente, ex);
            }

            return resultado;
        }
        public Resultado NuevoGasRecReq(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoGasRecReq.Agregar(gastoRecurrenteRequerimiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, gastoRecurrenteRequerimiento);
                resultado.id = gastoRecurrenteRequerimiento.idGasRecReq;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, gastoRecurrenteRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalle(GastoRecurrenteDetalle gastoRecurrenteDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoGasRecDet.Agregar(gastoRecurrenteDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, gastoRecurrenteDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, gastoRecurrenteDetalle, ex);
            }

            return resultado;
        }
        public Resultado NuevoGasRecDetMes(GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoGasRecDetMes.Agregar(gastoRecurrenteDetalleMes);
                unidadTrabajo.GuardarCambios();

                if (actualizaArea)
                {
                    var gastoRecurrenteDetalle = repoGasRecDet.TraerPorID((Int32)gastoRecurrenteDetalleMes.idGasRecDet);

                    List<GastoRecurrenteDetalleMes> lista = repoGasRecDetMes.TraerVariosPorCondicion(t => t.idGasRecDet == gastoRecurrenteDetalleMes.idGasRecDet && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.cantidad);

                    if (gastoRecurrenteDetalle != null)
                    {
                        gastoRecurrenteDetalle.subTotal = suma * gastoRecurrenteDetalle.precio;
                        repoGasRecDet.Actualizar(gastoRecurrenteDetalle);
                        unidadTrabajo.GuardarCambios();
                    }
                }

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, gastoRecurrenteDetalleMes);
                resultado.id = gastoRecurrenteDetalleMes.idGasRecDetMes;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, gastoRecurrenteDetalleMes, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalleMasivoPorCuentas(GastoRecurrente gastoRecurrente, List<RequerimientoBienServicioPendientePorCuentaPres> requerimientoPendientePorCuentaPres)
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
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaReq = repoGasRecReq.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDet = repoGasRecDet.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDetMes = repoGasRecDetMes.UnidadTrabajo as IUnidadTrabajo;
                    GastoRecurrenteRequerimiento objGasRecReq = null;
                    GastoRecurrenteDetalle objGasRecDet = null;
                    GastoRecurrenteDetalleMes objGasRecDetMes = null;

                    List<int?> listaIdsReq = requerimientoPendientePorCuentaPres.GroupBy(x => x.idReqBieSer).Select(x => x.FirstOrDefault().idReqBieSer).ToList();
                    if (listaIdsReq.Count > 0)
                    {
                        foreach (int req in listaIdsReq)
                        {
                            RequerimientoBienServicio obj = repoGasRecReq.TraerPorCondicion(x => x.idReqBieSer == req && x.estado != 1) == null ? repoReq.TraerPorID(req) : null;
                            if (obj != null)
                            {
                                objGasRecReq = new GastoRecurrenteRequerimiento()
                                {
                                    idGasRec = gastoRecurrente.idGasRec,
                                    idReqBieSer = obj.idReqBieSer,
                                    idArea = obj.idArea,
                                    idMoneda = obj.idMoneda,
                                    descripcion = obj.descripcion,
                                    anio = obj.anio,
                                    usuCrea = gastoRecurrente.usuCrea,
                                    fechaCrea = DateTime.Now,
                                    usuEdita = null,
                                    fechaEdita = null,
                                    estado = Estados.Activo
                                };
                                repoGasRecReq.Agregar(objGasRecReq);
                                unidadTrabajoPaaReq.GuardarCambios();
                            }
                            else
                            {
                                objGasRecReq = new GastoRecurrenteRequerimiento();
                            }

                            List<RequerimientoBienServicioPendientePorCuentaPres> listaDetIdsReq = requerimientoPendientePorCuentaPres.Where(x => x.idReqBieSer == req).ToList();
                            if (listaDetIdsReq.Count > 0)
                            {
                                foreach (RequerimientoBienServicioPendientePorCuentaPres reqDet in listaDetIdsReq)
                                {
                                    objGasRecDet = new GastoRecurrenteDetalle()
                                    {
                                        idGasRecReq = objGasRecReq.idGasRecReq == 0 ? repoGasRecReq.TraerPorCondicion(x => x.idReqBieSer == req && x.estado != 1).idGasRecReq : objGasRecReq.idGasRecReq,
                                        idReqBieSerDet = reqDet.idReqBieSerDet,
                                        idCueCon = (int)reqDet.idCueCon,
                                        idUnidad = (int)reqDet.idUnidad,
                                        idProducto = (int)reqDet.idProducto,
                                        descripcion = reqDet.desReqDetalle,
                                        precio = (decimal)reqDet.precio,
                                        precioOrigen = (decimal)reqDet.precioOrigen,
                                        subTotal = (decimal)reqDet.subtotal,
                                        usuCrea = gastoRecurrente.usuCrea,
                                        fechaCrea = DateTime.Now,
                                        usuEdita = null,
                                        fechaEdita = null,
                                        estado = Estados.Activo
                                    };
                                    repoGasRecDet.Agregar(objGasRecDet);
                                    unidadTrabajoPaaDet.GuardarCambios();

                                    List<RequerimientoBienServicioDetalleMes> listaReqDetMes = repoGasRecReq.TraerListaRequerimientoBienServicioDetalleMesPendiente((int)reqDet.idReqBieSerDet, 1);

                                    if (listaReqDetMes.Count > 0)
                                    {
                                        foreach (RequerimientoBienServicioDetalleMes reqDetMes in listaReqDetMes)
                                        {
                                            objGasRecDetMes = new GastoRecurrenteDetalleMes()
                                            {
                                                idGasRecDet = objGasRecDet.idGasRecDet,
                                                idReqBieSerDetMes = reqDetMes.idReqBieSerDetMes,
                                                mes = reqDetMes.mes,
                                                cantidad = reqDetMes.cantidad,
                                                usuCrea = gastoRecurrente.usuCrea,
                                                fechaCrea = DateTime.Now,
                                                usuEdita = null,
                                                fechaEdita = null,
                                                estado = Estados.Activo
                                            };
                                            repoGasRecDetMes.Agregar(objGasRecDetMes);
                                            unidadTrabajoPaaDetMes.GuardarCambios();

                                        }// fin foreach requerimiento detalle
                                    }
                                }// fin foreach requerimiento detalle
                            }

                        }// fin foreach requerimiento
                    }// fin if lista

                    

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoPendientePorCuentaPres);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, requerimientoPendientePorCuentaPres, ex);
                }
            }

            return resultado;
        }

        public Resultado Modificar(GastoRecurrente gastoRecurrente)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(Clonar(gastoRecurrente));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, gastoRecurrente);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, gastoRecurrente, ex);
            }

            return resultado;
        }
        public Resultado ModificarSinClonar(GastoRecurrente gastoRecurrente)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(gastoRecurrente);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, gastoRecurrente);
                resultado.id = gastoRecurrente.idGasRec;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, gastoRecurrente, ex);
            }

            return resultado;
        }
        public Resultado ModificarDetalles(GastoRecurrenteDetalle gastoRecurrenteDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                List<GastoRecurrenteDetalleMes> lista = repoGasRecDetMes.TraerVariosPorCondicion(t => t.idGasRecDet == gastoRecurrenteDetalle.idGasRecDet && t.estado != Estados.Anulado);
                decimal suma = lista.Sum(s => s.cantidad);
                gastoRecurrenteDetalle.subTotal = suma * gastoRecurrenteDetalle.precio;

                GastoRecurrenteDetalle clon = Clonar(gastoRecurrenteDetalle);
                repoGasRecDet.Actualizar(clon);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, gastoRecurrenteDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, gastoRecurrenteDetalle, ex);
            }

            return resultado;
        }
        public Resultado ModificarDetallesSinClonar(GastoRecurrenteDetalle gastoRecurrenteDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                List<GastoRecurrenteDetalleMes> lista = repoGasRecDetMes.TraerVariosPorCondicion(t => t.idGasRecDet == gastoRecurrenteDetalle.idGasRecDet && t.estado != Estados.Anulado);
                decimal suma = lista.Sum(s => s.cantidad);
                gastoRecurrenteDetalle.subTotal = suma * gastoRecurrenteDetalle.precio;

                repoGasRecDet.Actualizar(gastoRecurrenteDetalle);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, gastoRecurrenteDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, gastoRecurrenteDetalle, ex);
            }

            return resultado;
        }
        public Resultado ModificarGasRecReq(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoGasRecReq.Actualizar(Clonar(gastoRecurrenteRequerimiento));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, gastoRecurrenteRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, gastoRecurrenteRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado ModificarGasRecDetMes(GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoGasRecDetMes.Actualizar(gastoRecurrenteDetalleMes);
                unidadTrabajo.GuardarCambios();
                if (actualizaArea)
                {
                    var gastoRecurrenteDetalle = repoGasRecDet.TraerPorID((Int32)gastoRecurrenteDetalleMes.idGasRecDet);

                    List<GastoRecurrenteDetalleMes> lista = repoGasRecDetMes.TraerVariosPorCondicion(t => t.idGasRecDet == gastoRecurrenteDetalleMes.idGasRecDet && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.cantidad);

                    if (gastoRecurrenteDetalle != null)
                    {
                        gastoRecurrenteDetalle.subTotal = suma * gastoRecurrenteDetalle.precio;
                        repoGasRecDet.Actualizar(gastoRecurrenteDetalle);
                        unidadTrabajo.GuardarCambios();
                    }
                }
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, gastoRecurrenteDetalleMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, gastoRecurrenteDetalleMes, ex);
            }

            return resultado;
        }

        public Resultado AnularGasRecReq(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                List<GastoRecurrenteDetalle> listaGastoRecurrenteDetalle =
                    repoGasRecDet.TraerVariosPorCondicion(t => t.idGasRecReq == gastoRecurrenteRequerimiento.idGasRecReq && t.estado != 1);

                IEnumerable<int> IDs = listaGastoRecurrenteDetalle.Select(s => s.idGasRecDet).Distinct();

                List<GastoRecurrenteDetalleMes> listaPlanAnualAdquisicionDetalleMes =
                    repoGasRecDetMes.TraerVariosPorCondicion(t => IDs.Contains((Int32)t.idGasRecDet) && t.estado != 1);

                //gastoRecurrenteRequerimiento.estado = Estados.Anulado;
                //gastoRecurrenteRequerimiento.fechaEdita = DateTime.Now;
                //gastoRecurrenteRequerimiento.usuEdita = usuario;

                //repoGasRecReq.Actualizar(gastoRecurrenteRequerimiento);

                
                //foreach (GastoRecurrenteDetalle gastoRecurrenteDetalle in listaGastoRecurrenteDetalle)
                //{
                //    gastoRecurrenteDetalle.estado = Estados.Anulado;
                //    gastoRecurrenteDetalle.fechaEdita = DateTime.Now;
                //    gastoRecurrenteDetalle.usuEdita = usuario;

                //    repoGasRecDet.Actualizar(gastoRecurrenteDetalle);
                //}

                //foreach (GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes in listaPlanAnualAdquisicionDetalleMes)
                //{
                //    gastoRecurrenteDetalleMes.estado = Estados.Anulado;
                //    gastoRecurrenteDetalleMes.fechaEdita = DateTime.Now;
                //    gastoRecurrenteDetalleMes.usuEdita = usuario;

                //    repoGasRecDetMes.Actualizar(gastoRecurrenteDetalleMes);
                //}

                //unidadTrabajo.GuardarCambios();
                //resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, gastoRecurrenteRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, gastoRecurrenteRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado AnularGasRecReqPres(GastoRecurrenteRequerimientoPres gastoRecurrenteRequerimientoPres, string usuario)
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
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                    IEnumerable<int> IDs = gastoRecurrenteRequerimientoPres.GastoRecurrenteDetallePres.Select(s => (int)s.idGasRecDet).Distinct();

                    List<GastoRecurrenteDetalleMes> listagastoRecurrenteDetalleMes =
                        repoGasRecDetMes.TraerVariosPorCondicion(t => IDs.Contains((Int32)t.idGasRecDet) && t.estado != 1);


                    /*Lista de Detalles en otras cuentas*/
                    var query = (
                                from c in repoGasRecDet.TraerVariosPorCondicion(x => x.idGasRecReq == gastoRecurrenteRequerimientoPres.idGasRecReq && x.estado != 1)
                                join p in gastoRecurrenteRequerimientoPres.GastoRecurrenteDetallePres on c.idGasRecDet equals p.idGasRecDet into ps
                                from p in ps.DefaultIfEmpty()
                                select new { detTot = c, detAct = p == null ? 0 : p.idGasRecDet }
                              ).ToList().Where(x => x.detAct == 0).ToList().Count();

                    if (query <= 0)
                    {
                        GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento = repoGasRecReq.TraerPorID((Int32)gastoRecurrenteRequerimientoPres.idGasRecReq);
                        gastoRecurrenteRequerimiento.estado = Estados.Anulado;
                        gastoRecurrenteRequerimiento.fechaEdita = DateTime.Now;
                        gastoRecurrenteRequerimiento.usuEdita = usuario;

                        repoGasRecReq.Actualizar(gastoRecurrenteRequerimiento);
                    }


                    foreach (int vid in IDs)
                    {
                        GastoRecurrenteDetalle gastoRecurrenteDetalle = repoGasRecDet.TraerPorID(vid);
                        gastoRecurrenteDetalle.estado = Estados.Anulado;
                        gastoRecurrenteDetalle.fechaEdita = DateTime.Now;
                        gastoRecurrenteDetalle.usuEdita = usuario;

                        repoGasRecDet.Actualizar(gastoRecurrenteDetalle);
                    }

                    foreach (GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes in listagastoRecurrenteDetalleMes)
                    {
                        gastoRecurrenteDetalleMes.estado = Estados.Anulado;
                        gastoRecurrenteDetalleMes.fechaEdita = DateTime.Now;
                        gastoRecurrenteDetalleMes.usuEdita = usuario;

                        repoGasRecDetMes.Actualizar(gastoRecurrenteDetalleMes);
                    }

                    unidadTrabajo.GuardarCambios();

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, gastoRecurrenteRequerimientoPres);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, gastoRecurrenteRequerimientoPres, ex);
                }
            }

            return resultado;
        }
        public Resultado AnularDetalle(GastoRecurrenteDetalle gastoRecurrenteDetalle, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                gastoRecurrenteDetalle.estado = Estados.Anulado;
                gastoRecurrenteDetalle.fechaEdita = DateTime.Now;
                gastoRecurrenteDetalle.usuEdita = usuario;
                repoGasRecDet.Actualizar(gastoRecurrenteDetalle);

                List<GastoRecurrenteDetalleMes> listaGastoRecurrenteDetalleMes = repoGasRecDetMes.TraerVariosPorCondicion(t => t.idGasRecDet == gastoRecurrenteDetalle.idGasRecDet && t.estado != Estados.Anulado);

                foreach (GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes in listaGastoRecurrenteDetalleMes)
                {
                    gastoRecurrenteDetalleMes.estado = Estados.Anulado;
                    gastoRecurrenteDetalleMes.fechaEdita = DateTime.Now;
                    gastoRecurrenteDetalleMes.usuEdita = usuario;

                    repoGasRecDetMes.Actualizar(gastoRecurrenteDetalleMes);
                }

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, gastoRecurrenteDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, gastoRecurrenteDetalle, ex);
            }

            return resultado;
        }
        public Resultado Anular(GastoRecurrente gastoRecurrente, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                gastoRecurrente.estado = Estados.Anulado;
                gastoRecurrente.fechaEdita = DateTime.Now;
                gastoRecurrente.usuEdita = usuario;

                repositorio.Actualizar(gastoRecurrente);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, gastoRecurrente);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, gastoRecurrente, ex);
            }

            return resultado;
        }
        public bool ActualizarDetallesGastoRecurrente(int idGasRec, string nomUsuario)
        {
            return repositorio.ActualizarDetallesGastoRecurrente(idGasRec, nomUsuario);
        }
        #endregion

        #region Busqueda y listas
        public GastoRecurrente Buscar(int idGasRec)
        {
            return repositorio.TraerPorCondicion(x => x.idGasRec == idGasRec && x.estado != 1);
        }
        public GastoRecurrenteRequerimiento BuscarReqPorCodigo(int idGasRecReq)
        {
            return repoGasRecReq.TraerPorID(idGasRecReq);
        }
        public GastoRecurrenteDetalle BuscarDetallePorCodigo(int idGasRecDet)
        {
            return repoGasRecDet.TraerPorID(idGasRecDet);
        }

        public List<GastoRecurrente> listarTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != 1);
        }
        public List<GastoRecurrenteRequerimientoPres> TraerListaGastoRecurrenteRequerimiento(int idGasRec)
        {
            return repositorio.TraerListaGastoRecurrenteRequerimiento(idGasRec);
        }
        public GastoRecurrenteDetalleMes BuscarPorCodigoPaaDetalleMes(int idGasRecDet, int mes)
        {
            return repoGasRecDetMes.TraerPorCondicion(t => t.idGasRecDet == idGasRecDet && t.mes == mes);
        }
        public decimal BuscarImporteDetalle(int idGasRecDet, decimal precio)
        {
            decimal importe = 0;
            var paaDetMes = repoGasRecDetMes.TraerVariosPorCondicion(t => t.idGasRecDet == idGasRecDet && t.estado != 1 );

            if (paaDetMes != null)
            {
                importe = precio * paaDetMes.Sum(s => s.cantidad);
            }
            return importe = 0;
        }
        public List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro)
        {
            return repositorio.TraerListaRequerimientoBienServicioPendientePorCuenta(idCueCon, anio, tipoRubro);
        }

        #endregion

        #region Reporte
        public List<ReporteGastoRecurrenteDetallePres> TraerReporteGastoRecurrenteDetalle(int idGasRec)
        {
            return repositorio.TraerReporteGastoRecurrenteDetalle(idGasRec);
        }
        public List<ReporteGastoRecurrenteDetalleDireccionPres> TraerReporteGastoRecurrenteDetalleDireccion(int idGasRec, int idDireccion)
        {
            return repositorio.TraerReporteGastoRecurrenteDetalleDireccion(idGasRec, idDireccion);
        }
        #endregion
    }
}
