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
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PlanAnualAdquisicionServicio : ServicioBase, IPlanAnualAdquisicionServicio
    {
        IPlanAnualAdquisicionRepositorio repositorio;
        IPlanAnualAdquisicionRequerimientoRepositorio repoPaaReq;
        IPlanAnualAdquisicionDetalleRepositorio repoPaaDet;
        IPlanAnualAdquisicionDetalleMesRepositorio repoPaaDetMes;
        IRequerimientoBienServicioRepositorio repoReq;
        ITipoCambioAnualRepositorio repoTipoCambioAnual;
        


        public PlanAnualAdquisicionServicio(IPlanAnualAdquisicionRepositorio repositorio, IPlanAnualAdquisicionRequerimientoRepositorio repoPaaReq
                                            , IPlanAnualAdquisicionDetalleRepositorio repoPaaDet, IPlanAnualAdquisicionDetalleMesRepositorio repoPaaDetMes
                                            , IRequerimientoBienServicioRepositorio repoReq, ITipoCambioAnualRepositorio repoTipoCambioAnual)
        {
            this.repositorio = repositorio;
            this.repoPaaReq = repoPaaReq;
            this.repoPaaDet = repoPaaDet;
            this.repoPaaDetMes = repoPaaDetMes;
            this.repoReq = repoReq;
            this.repoTipoCambioAnual = repoTipoCambioAnual;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        private PlanAnualAdquisicion Clonar(PlanAnualAdquisicion planAnualAdquisicionOld)
        {
            return new PlanAnualAdquisicion
            {
                idPaa = planAnualAdquisicionOld.idPaa,
                descripcion = planAnualAdquisicionOld.descripcion,
                fechaEmision = planAnualAdquisicionOld.fechaEmision,
                fechaAprobacion = planAnualAdquisicionOld.fechaAprobacion,
                idEntidad = planAnualAdquisicionOld.idEntidad,
                anio = planAnualAdquisicionOld.anio,
                siglas = planAnualAdquisicionOld.siglas,
                uniEje = planAnualAdquisicionOld.uniEje,
                pliego = planAnualAdquisicionOld.pliego,
                docAprobacion = planAnualAdquisicionOld.docAprobacion,
                idMoneda = planAnualAdquisicionOld.idMoneda,
                tipoCambio = planAnualAdquisicionOld.tipoCambio,
                usuCrea = planAnualAdquisicionOld.usuCrea,
                fechaCrea = planAnualAdquisicionOld.fechaCrea,
                usuMod = planAnualAdquisicionOld.usuMod,
                fechaMod = planAnualAdquisicionOld.fechaMod,
                estado = planAnualAdquisicionOld.estado
            };
        }
        private PlanAnualAdquisicionDetalle Clonar(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalleOld)
        {
            return new PlanAnualAdquisicionDetalle
            {
                idPaaDet = planAnualAdquisicionDetalleOld.idPaaDet,
                idPaaReq = planAnualAdquisicionDetalleOld.idPaaReq,
                numRef = planAnualAdquisicionDetalleOld.numRef,
                itemUnico = planAnualAdquisicionDetalleOld.itemUnico,
                tipComSel = planAnualAdquisicionDetalleOld.tipComSel,
                nomEnt = planAnualAdquisicionDetalleOld.nomEnt,
                TipPro = planAnualAdquisicionDetalleOld.TipPro,
                objCon = planAnualAdquisicionDetalleOld.objCon,
                nroItem = planAnualAdquisicionDetalleOld.nroItem,
                antecedente = planAnualAdquisicionDetalleOld.antecedente,
                desAntecedente = planAnualAdquisicionDetalleOld.desAntecedente,
                descripcion = planAnualAdquisicionDetalleOld.descripcion,
                idReqBieSerDet = planAnualAdquisicionDetalleOld.idReqBieSerDet,
                idCueCon = planAnualAdquisicionDetalleOld.idCueCon,
                idProducto = planAnualAdquisicionDetalleOld.idProducto,
                precio = planAnualAdquisicionDetalleOld.precio,
                subtotal = planAnualAdquisicionDetalleOld.subtotal,
                idUnidad = planAnualAdquisicionDetalleOld.idUnidad,
                idTipMon = planAnualAdquisicionDetalleOld.idTipMon,
                tipCam = planAnualAdquisicionDetalleOld.tipCam,
                valorEst = planAnualAdquisicionDetalleOld.valorEst,
                idUbigeo = planAnualAdquisicionDetalleOld.idUbigeo,
                idFueFin = planAnualAdquisicionDetalleOld.idFueFin,
                fechaPre = planAnualAdquisicionDetalleOld.fechaPre,
                modalidad = planAnualAdquisicionDetalleOld.modalidad,
                organoEncargado = planAnualAdquisicionDetalleOld.organoEncargado,
                observaciones = planAnualAdquisicionDetalleOld.observaciones,
                usuCrea = planAnualAdquisicionDetalleOld.usuCrea,
                fechaCrea = planAnualAdquisicionDetalleOld.fechaCrea,
                usuMod = planAnualAdquisicionDetalleOld.usuMod,
                fechaMod = planAnualAdquisicionDetalleOld.fechaMod,
                estado = planAnualAdquisicionDetalleOld.estado
            };
        }
        private PlanAnualAdquisicionRequerimiento Clonar(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimientoOld)
        {
            return new PlanAnualAdquisicionRequerimiento
            {
                idPaaReq = planAnualAdquisicionRequerimientoOld.idPaaReq,
                idPaa = planAnualAdquisicionRequerimientoOld.idPaa,
                idReqBieSer = planAnualAdquisicionRequerimientoOld.idReqBieSer,
                idArea = planAnualAdquisicionRequerimientoOld.idArea,
                idMoneda = planAnualAdquisicionRequerimientoOld.idMoneda,
                descripcion = planAnualAdquisicionRequerimientoOld.descripcion,
                fechaEmision = planAnualAdquisicionRequerimientoOld.fechaEmision,
                fechaAprobacion = planAnualAdquisicionRequerimientoOld.fechaAprobacion,
                anio = planAnualAdquisicionRequerimientoOld.anio,
                usuCrea = planAnualAdquisicionRequerimientoOld.usuCrea,
                fechaCrea = planAnualAdquisicionRequerimientoOld.fechaCrea,
                usuMod = planAnualAdquisicionRequerimientoOld.usuMod,
                fechaMod = planAnualAdquisicionRequerimientoOld.fechaMod,
                estado = planAnualAdquisicionRequerimientoOld.estado
            };
        }

        public Resultado Nuevo(PlanAnualAdquisicion planAnualAdquisicion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(planAnualAdquisicion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, planAnualAdquisicion);
                resultado.id = planAnualAdquisicion.idPaa;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, planAnualAdquisicion, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalle(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPaaDet.Agregar(planAnualAdquisicionDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, planAnualAdquisicionDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, planAnualAdquisicionDetalle, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalleMasivo(PlanAnualAdquisicion planAnualAdquisicion, bool actualizaArea)
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
                    IUnidadTrabajo unidadTrabajoPaaReq = repoPaaReq.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDet = repoPaaDet.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDetMes = repoPaaDetMes.UnidadTrabajo as IUnidadTrabajo;
                    PlanAnualAdquisicionRequerimiento objPaaReq = null;
                    PlanAnualAdquisicionDetalle objPaaDet = null;
                    PlanAnualAdquisicionDetalleMes objPaaDetMes = null;

                    //unidadTrabajo.GuardarCambios();
                    List<RequerimientoBienServicio> listaReq = repoPaaReq.TraerListaRequerimientoBienServicioPendiente(planAnualAdquisicion.idPaa);
                    if (listaReq.Count > 0)
                    {
                        foreach (RequerimientoBienServicio req in listaReq)
                        {
                            objPaaReq = new PlanAnualAdquisicionRequerimiento()
                            {
                                idPaa = planAnualAdquisicion.idPaa,
                                idReqBieSer = req.idReqBieSer,
                                idArea = req.idArea,
                                idMoneda = req.idMoneda,
                                descripcion = req.descripcion,
                                fechaEmision = req.fechaEmision,
                                fechaAprobacion = req.fechaAprobacion,
                                anio = req.anio,
                                usuCrea = planAnualAdquisicion.usuCrea,
                                fechaCrea = DateTime.Now,
                                usuMod = "",
                                fechaMod = null, //Convert.ToDateTime("01/01/1900"),
                                estado = Estados.Activo
                            };
                            repoPaaReq.Agregar(objPaaReq);
                            unidadTrabajoPaaReq.GuardarCambios();

                            List<RequerimientoBienServicioDetalle> listaReqDet = repoPaaReq.TraerListaRequerimientoBienServicioDetallePendiente(req.idReqBieSer);
                            if (listaReqDet.Count > 0)
                            {
                                foreach (RequerimientoBienServicioDetalle reqDet in listaReqDet)
                                {
                                    objPaaDet = new PlanAnualAdquisicionDetalle()
                                    {
                                        idPaaReq = objPaaReq.idPaaReq,
                                        descripcion = reqDet.descripcion,
                                        idReqBieSerDet = reqDet.idReqBieSerDet,
                                        idCueCon = reqDet.idCueCon,
                                        idUnidad = reqDet.idUnidad,
                                        idProducto = reqDet.idProducto,
                                        precio = reqDet.precio,
                                        subtotal = reqDet.subtotal,
                                        usuCrea = planAnualAdquisicion.usuCrea,
                                        fechaCrea = DateTime.Now,
                                        usuMod = "",
                                        fechaMod = null,//Convert.ToDateTime("01/01/1900"),
                                        estado = Estados.Activo
                                    };
                                    repoPaaDet.Agregar(objPaaDet);
                                    unidadTrabajoPaaDet.GuardarCambios();

                                    List<RequerimientoBienServicioDetalleMes> listaReqDetMes = repoPaaReq.TraerListaRequerimientoBienServicioDetalleMesPendiente(reqDet.idReqBieSerDet, 2);

                                    if (listaReqDetMes.Count > 0)
                                    {
                                        foreach (RequerimientoBienServicioDetalleMes reqDetMes in listaReqDetMes)
                                        {
                                            objPaaDetMes = new PlanAnualAdquisicionDetalleMes()
                                            {
                                                idPaaDet = objPaaDet.idPaaDet,
                                                idReqBieSerDetMes = reqDetMes.idReqBieSerDetMes,
                                                mes = reqDetMes.mes,
                                                cantidad = reqDetMes.cantidad,
                                                usuCrea = planAnualAdquisicion.usuCrea,
                                                fechaCrea = DateTime.Now,
                                                usuMod = "",
                                                fechaMod = null, //Convert.ToDateTime("01/01/1900"),
                                                estado = Estados.Activo
                                            };
                                            repoPaaDetMes.Agregar(objPaaDetMes);
                                            unidadTrabajoPaaDetMes.GuardarCambios();

                                        }// fin foreach requerimiento detalle
                                    }
                                }// fin foreach requerimiento detalle
                            }
                        }// fin foreach requerimiento
                    }// fin if lista

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, planAnualAdquisicion);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, planAnualAdquisicion, ex);
                }
            }

            return resultado;
        }
        public Resultado NuevoPaaReq(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPaaReq.Agregar(planAnualAdquisicionRequerimiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, planAnualAdquisicionRequerimiento);
                resultado.id = planAnualAdquisicionRequerimiento.idPaaReq;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, planAnualAdquisicionRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado NuevoPaaDetMes(PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPaaDetMes.Agregar(planAnualAdquisicionDetalleMes);
                unidadTrabajo.GuardarCambios();

                if (actualizaArea)
                {
                    var planAnualAdquisicionDetalle = repoPaaDet.TraerPorID((Int32)planAnualAdquisicionDetalleMes.idPaaDet);

                    List<PlanAnualAdquisicionDetalleMes> lista = repoPaaDetMes.TraerVariosPorCondicion(t => t.idPaaDet == planAnualAdquisicionDetalleMes.idPaaDet && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.cantidad);

                    if (planAnualAdquisicionDetalle != null)
                    {
                        planAnualAdquisicionDetalle.subtotal = suma * planAnualAdquisicionDetalle.precio;
                        repoPaaDet.Actualizar(planAnualAdquisicionDetalle);
                        unidadTrabajo.GuardarCambios();
                    }
                }

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, planAnualAdquisicionDetalleMes);
                resultado.id = planAnualAdquisicionDetalleMes.idPaaDetMes;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, planAnualAdquisicionDetalleMes, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalleMasivoPorCuentas(PlanAnualAdquisicion planAnualAdquisicion, List<RequerimientoBienServicioPendientePorCuentaPres> requerimientoPendientePorCuentaPres)
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
                    IUnidadTrabajo unidadTrabajoPaaReq = repoPaaReq.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDet = repoPaaDet.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDetMes = repoPaaDetMes.UnidadTrabajo as IUnidadTrabajo;
                    PlanAnualAdquisicionRequerimiento objPaaReq = null;
                    PlanAnualAdquisicionDetalle objPaaDet = null;
                    PlanAnualAdquisicionDetalleMes objPaaDetMes = null;

                    List<int?> listaIdsReq = requerimientoPendientePorCuentaPres.GroupBy(x => x.idReqBieSer).Select(x => x.FirstOrDefault().idReqBieSer).ToList();
                    if (listaIdsReq.Count > 0)
                    {
                        foreach (int req in listaIdsReq)
                        {
                            RequerimientoBienServicio obj = repoPaaReq.TraerPorCondicion(x => x.idReqBieSer == req && x.estado != 1) == null ? repoReq.TraerPorID(req) : null;
                            if (obj != null)
                            {
                                objPaaReq = new PlanAnualAdquisicionRequerimiento()
                                {
                                    idPaa = planAnualAdquisicion.idPaa,
                                    idReqBieSer = obj.idReqBieSer,
                                    idArea = obj.idArea,
                                    idMoneda = obj.idMoneda,
                                    descripcion = obj.descripcion,
                                    fechaEmision = obj.fechaEmision,
                                    fechaAprobacion = obj.fechaAprobacion,
                                    anio = obj.anio,
                                    usuCrea = planAnualAdquisicion.usuCrea,
                                    fechaCrea = DateTime.Now,
                                    usuMod = "",
                                    fechaMod = null,
                                    estado = Estados.Activo
                                };
                                repoPaaReq.Agregar(objPaaReq);
                                unidadTrabajoPaaReq.GuardarCambios();
                            }
                            else
                            {
                                objPaaReq = new PlanAnualAdquisicionRequerimiento();
                            }

                            List<RequerimientoBienServicioPendientePorCuentaPres> listaDetIdsReq = requerimientoPendientePorCuentaPres.Where(x => x.idReqBieSer == req).ToList();
                            if (listaDetIdsReq.Count > 0)
                            {
                                foreach (RequerimientoBienServicioPendientePorCuentaPres reqDet in listaDetIdsReq)
                                {
                                    objPaaDet = new PlanAnualAdquisicionDetalle()
                                    {
                                        idPaaReq = objPaaReq.idPaaReq == 0 ? repoPaaReq.TraerPorCondicion(x => x.idReqBieSer == req && x.estado != 1).idPaaReq : objPaaReq.idPaaReq,
                                        descripcion = reqDet.desReqDetalle,
                                        idReqBieSerDet = reqDet.idReqBieSerDet,
                                        idCueCon = reqDet.idCueCon,
                                        idUnidad = reqDet.idUnidad,
                                        idProducto = reqDet.idProducto,
                                        precio = reqDet.precio,
                                        valorEst = reqDet.precioOrigen,
                                        subtotal = reqDet.subtotal,
                                        idTipMon = objPaaReq.idMoneda,
                                        usuCrea = planAnualAdquisicion.usuCrea,
                                        fechaCrea = DateTime.Now,
                                        usuMod = "",
                                        fechaMod = null,
                                        estado = Estados.Activo
                                    };
                                    repoPaaDet.Agregar(objPaaDet);
                                    unidadTrabajoPaaDet.GuardarCambios();

                                    List<RequerimientoBienServicioDetalleMes> listaReqDetMes = repoPaaReq.TraerListaRequerimientoBienServicioDetalleMesPendiente((int)reqDet.idReqBieSerDet, 2);

                                    if (listaReqDetMes.Count > 0)
                                    {
                                        foreach (RequerimientoBienServicioDetalleMes reqDetMes in listaReqDetMes)
                                        {
                                            objPaaDetMes = new PlanAnualAdquisicionDetalleMes()
                                            {
                                                idPaaDet = objPaaDet.idPaaDet,
                                                idReqBieSerDetMes = reqDetMes.idReqBieSerDetMes,
                                                mes = reqDetMes.mes,
                                                cantidad = reqDetMes.cantidad,
                                                usuCrea = planAnualAdquisicion.usuCrea,
                                                fechaCrea = DateTime.Now,
                                                usuMod = "",
                                                fechaMod = null,
                                                estado = Estados.Activo
                                            };
                                            repoPaaDetMes.Agregar(objPaaDetMes);
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
        public Resultado NuevoDetalleMasivoPorCuentas(PlanAnualAdquisicion planAnualAdquisicion, List<RequerimientoBienServicioPendientePorCuentaPres> requerimientoPendientePorCuentaPres, PlanAnualAdquisicionDetallePoco planAnualAdquisicionDetallePoco)
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
                    IUnidadTrabajo unidadTrabajoPaaReq = repoPaaReq.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDet = repoPaaDet.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPaaDetMes = repoPaaDetMes.UnidadTrabajo as IUnidadTrabajo;
                    PlanAnualAdquisicionRequerimiento objPaaReq = null;
                    PlanAnualAdquisicionDetalle objPaaDet = null;
                    PlanAnualAdquisicionDetalleMes objPaaDetMes = null;
                    //decimal tipoCambio = 1;

                    List<int?> listaIdsReq = requerimientoPendientePorCuentaPres.GroupBy(x => x.idReqBieSer).Select(x => x.FirstOrDefault().idReqBieSer).ToList();
                    if (listaIdsReq.Count > 0)
                    {
                        foreach (int req in listaIdsReq)
                        {
                            RequerimientoBienServicio obj = repoPaaReq.TraerPorCondicion(x => x.idReqBieSer == req && x.estado != 1) == null ? repoReq.TraerPorID(req) : null;
                            if (obj != null)
                            {
                                //tipoCambio = obj.idMoneda == 64 ? tipoCambio : repoTipoCambioAnual.TraerPorCondicion(x => x.anio == obj.anio).valor;
                                objPaaReq = new PlanAnualAdquisicionRequerimiento()
                                {
                                    idPaa = planAnualAdquisicion.idPaa,
                                    idReqBieSer = obj.idReqBieSer,
                                    idArea = obj.idArea,
                                    idMoneda = obj.idMoneda == 64 ? obj.idMoneda : 64,//Requemiento PAC siempre en dolares
                                    descripcion = obj.descripcion,
                                    fechaEmision = obj.fechaEmision,
                                    fechaAprobacion = obj.fechaAprobacion,
                                    anio = obj.anio,
                                    usuCrea = planAnualAdquisicion.usuCrea,
                                    fechaCrea = DateTime.Now,
                                    usuMod = "",
                                    fechaMod = null,
                                    estado = Estados.Activo
                                };
                                repoPaaReq.Agregar(objPaaReq);
                                unidadTrabajoPaaReq.GuardarCambios();
                            }
                            else
                            {
                                objPaaReq = new PlanAnualAdquisicionRequerimiento();
                            }

                            List<RequerimientoBienServicioPendientePorCuentaPres> listaDetIdsReq = requerimientoPendientePorCuentaPres.Where(x => x.idReqBieSer == req).ToList();
                            if (listaDetIdsReq.Count > 0)
                            {
                                foreach (RequerimientoBienServicioPendientePorCuentaPres reqDet in listaDetIdsReq)
                                {
                                    objPaaDet = new PlanAnualAdquisicionDetalle()
                                    {
                                        idPaaReq = objPaaReq.idPaaReq == 0 ? repoPaaReq.TraerPorCondicion(x => x.idReqBieSer == req && x.estado != 1).idPaaReq : objPaaReq.idPaaReq,
                                        descripcion = reqDet.desReqDetalle,
                                        idReqBieSerDet = reqDet.idReqBieSerDet,
                                        
                                        idCueCon = reqDet.idCueCon,
                                        idUnidad = reqDet.idUnidad,
                                        idProducto = reqDet.idProducto,
                                        precio = reqDet.precio,
                                        subtotal = reqDet.subtotal,
                                        idTipMon = planAnualAdquisicion.idMoneda,
                                        valorEst = reqDet.precioOrigen,
                                        tipCam = planAnualAdquisicion.tipoCambio,

                                        tipComSel = planAnualAdquisicionDetallePoco.tipComSel,
                                        TipPro = planAnualAdquisicionDetallePoco.TipPro,
                                        objCon = planAnualAdquisicionDetallePoco.objCon,
                                        organoEncargado = planAnualAdquisicionDetallePoco.organoEncargado,
                                        idFueFin = planAnualAdquisicionDetallePoco.idFueFin,
                                        fechaPre = planAnualAdquisicionDetallePoco.fechaPre,
                                        idUbigeo = planAnualAdquisicionDetallePoco.idUbigeo,
                                        observaciones = string.Empty,

                                        usuCrea = planAnualAdquisicion.usuCrea,
                                        fechaCrea = DateTime.Now,
                                        usuMod = "",
                                        fechaMod = null,
                                        estado = Estados.Activo
                                    };
                                    repoPaaDet.Agregar(objPaaDet);
                                    unidadTrabajoPaaDet.GuardarCambios();

                                    List<RequerimientoBienServicioDetalleMes> listaReqDetMes = repoPaaReq.TraerListaRequerimientoBienServicioDetalleMesPendiente((int)reqDet.idReqBieSerDet, 2);

                                    if (listaReqDetMes.Count > 0)
                                    {
                                        foreach (RequerimientoBienServicioDetalleMes reqDetMes in listaReqDetMes)
                                        {
                                            objPaaDetMes = new PlanAnualAdquisicionDetalleMes()
                                            {
                                                idPaaDet = objPaaDet.idPaaDet,
                                                idReqBieSerDetMes = reqDetMes.idReqBieSerDetMes,
                                                mes = reqDetMes.mes,
                                                cantidad = reqDetMes.cantidad,
                                                usuCrea = planAnualAdquisicion.usuCrea,
                                                fechaCrea = DateTime.Now,
                                                usuMod = "",
                                                fechaMod = null,
                                                estado = Estados.Activo
                                            };
                                            repoPaaDetMes.Agregar(objPaaDetMes);
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
        public Resultado Modificar(PlanAnualAdquisicion planAnualAdquisicion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(Clonar(planAnualAdquisicion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, planAnualAdquisicion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, planAnualAdquisicion, ex);
            }

            return resultado;
        }
        public Resultado ModificarSinClonar(PlanAnualAdquisicion planAnualAdquisicion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(planAnualAdquisicion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, planAnualAdquisicion);
                resultado.id = planAnualAdquisicion.idPaa;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, planAnualAdquisicion, ex);
            }

            return resultado;
        }
        public Resultado ModificarDetalles(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                List<PlanAnualAdquisicionDetalleMes> lista = repoPaaDetMes.TraerVariosPorCondicion(t => t.idPaaDet == planAnualAdquisicionDetalle.idPaaDet && t.estado != Estados.Anulado);
                decimal suma = lista.Sum(s => s.cantidad);
                planAnualAdquisicionDetalle.subtotal = suma * planAnualAdquisicionDetalle.valorEst;

                PlanAnualAdquisicionDetalle clon = Clonar(planAnualAdquisicionDetalle);
                repoPaaDet.Actualizar(clon);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, planAnualAdquisicionDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, planAnualAdquisicionDetalle, ex);
            }

            return resultado;
        }
        public Resultado ModificarDetallesSinClonar(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                //List<RequerimientoBienServicioDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReqBieSerDet == planAnualAdquisicionDetalle.idReqBieSerDet && t.estado != Estados.Anulado);
                //decimal suma = lista.Sum(s => s.cantidad);

                //planAnualAdquisicionDetalle.subtotal = suma * planAnualAdquisicionDetalle.precio;
                repoPaaDet.Actualizar(planAnualAdquisicionDetalle);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, planAnualAdquisicionDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, planAnualAdquisicionDetalle, ex);
            }

            return resultado;
        }
        public Resultado ModificarPaaReq(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPaaReq.Actualizar(Clonar(planAnualAdquisicionRequerimiento));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, planAnualAdquisicionRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, planAnualAdquisicionRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado ModificarPaaDetMes(PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoPaaDetMes.Actualizar(planAnualAdquisicionDetalleMes);
                unidadTrabajo.GuardarCambios();
                if (actualizaArea)
                {
                    var planAnualAdquisicionDetalle = repoPaaDet.TraerPorID((Int32)planAnualAdquisicionDetalleMes.idPaaDet);

                    List<PlanAnualAdquisicionDetalleMes> lista = repoPaaDetMes.TraerVariosPorCondicion(t => t.idPaaDet == planAnualAdquisicionDetalleMes.idPaaDet && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.cantidad);

                    if (planAnualAdquisicionDetalle != null)
                    {
                        planAnualAdquisicionDetalle.subtotal = suma * planAnualAdquisicionDetalle.precio;
                        repoPaaDet.Actualizar(planAnualAdquisicionDetalle);
                        unidadTrabajo.GuardarCambios();
                    }
                }
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, planAnualAdquisicionDetalleMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, planAnualAdquisicionDetalleMes, ex);
            }

            return resultado;
        }

        public Resultado AnularPaaReq(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                planAnualAdquisicionRequerimiento.estado = Estados.Anulado;
                planAnualAdquisicionRequerimiento.fechaMod = DateTime.Now;
                planAnualAdquisicionRequerimiento.usuMod = usuario;

                repoPaaReq.Actualizar(planAnualAdquisicionRequerimiento);

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, planAnualAdquisicionRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, planAnualAdquisicionRequerimiento, ex);
            }

            return resultado;
        }

        public Resultado AnularPaaReqPres(PlanAnualAdquisicionRequerimientoPres planAnualAdquisicionRequerimientoPres, string usuario)
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

                    /*IdPaaDet - para anular*/
                    IEnumerable<int> IDs = planAnualAdquisicionRequerimientoPres.PlanAnualAdquisicionDetallePres.Select(s => (int)s.idPaaDet).Distinct();

                    List<PlanAnualAdquisicionDetalleMes> listaPlanAnualAdquisicionDetalleMes =
                        repoPaaDetMes.TraerVariosPorCondicion(t => IDs.Contains((Int32)t.idPaaDet) && t.estado != 1);

                    /*Lista de Detalles en otras cuentas*/
                    var query = (
                                from c in repoPaaDet.TraerVariosPorCondicion(x => x.idPaaReq == planAnualAdquisicionRequerimientoPres.idPaaReq && x.estado != 1)
                                join p in planAnualAdquisicionRequerimientoPres.PlanAnualAdquisicionDetallePres on c.idPaaDet equals p.idPaaDet into ps
                                from p in ps.DefaultIfEmpty()
                                select new { detTot = c, detAct = p == null ? 0 : p.idPaaDet }
                              ).ToList().Where(x => x.detAct == 0).ToList().Count();

                    if (query <= 0)
                    {
                        PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento = repoPaaReq.TraerPorID((Int32)planAnualAdquisicionRequerimientoPres.idPaaReq);
                        planAnualAdquisicionRequerimiento.estado = Estados.Anulado;
                        planAnualAdquisicionRequerimiento.fechaMod = DateTime.Now;
                        planAnualAdquisicionRequerimiento.usuMod = usuario;

                        repoPaaReq.Actualizar(planAnualAdquisicionRequerimiento);
                    }



                    foreach (int vid in IDs)
                    {
                        PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle = repoPaaDet.TraerPorID(vid);

                        planAnualAdquisicionDetalle.estado = Estados.Anulado;
                        planAnualAdquisicionDetalle.fechaMod = DateTime.Now;
                        planAnualAdquisicionDetalle.usuMod = usuario;

                        repoPaaDet.Actualizar(planAnualAdquisicionDetalle);
                    }

                    foreach (PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes in listaPlanAnualAdquisicionDetalleMes)
                    {
                        planAnualAdquisicionDetalleMes.estado = Estados.Anulado;
                        planAnualAdquisicionDetalleMes.fechaMod = DateTime.Now;
                        planAnualAdquisicionDetalleMes.usuMod = usuario;

                        repoPaaDetMes.Actualizar(planAnualAdquisicionDetalleMes);
                    }

                    unidadTrabajo.GuardarCambios();

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, planAnualAdquisicionRequerimientoPres);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, planAnualAdquisicionRequerimientoPres, ex);
                }
            }

            return resultado;
        }

        public Resultado AnularDetalle(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                planAnualAdquisicionDetalle.estado = Estados.Anulado;
                planAnualAdquisicionDetalle.fechaMod = DateTime.Now;
                planAnualAdquisicionDetalle.usuMod = usuario;
                repoPaaDet.Actualizar(planAnualAdquisicionDetalle);

                List<PlanAnualAdquisicionDetalleMes> listaProgramacionAnualDetalleMes = repoPaaDetMes.TraerVariosPorCondicion(t => t.idPaaDet == planAnualAdquisicionDetalle.idPaaDet && t.estado != Estados.Anulado);

                foreach (PlanAnualAdquisicionDetalleMes programacionAnualDetalleMes in listaProgramacionAnualDetalleMes)
                {
                    programacionAnualDetalleMes.estado = Estados.Anulado;
                    programacionAnualDetalleMes.fechaMod = DateTime.Now;
                    programacionAnualDetalleMes.usuMod = usuario;

                    repoPaaDetMes.Actualizar(programacionAnualDetalleMes);
                }

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, planAnualAdquisicionDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, planAnualAdquisicionDetalle, ex);
            }

            return resultado;
        }
        public Resultado Anular(PlanAnualAdquisicion planAnualAdquisicion, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                planAnualAdquisicion.estado = Estados.Anulado;
                planAnualAdquisicion.fechaMod = DateTime.Now;
                planAnualAdquisicion.usuMod = usuario;

                repositorio.Actualizar(planAnualAdquisicion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, planAnualAdquisicion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, planAnualAdquisicion, ex);
            }

            return resultado;
        }
        public bool ActualizarDetallesPac(int idPaa, string nomUsuario)
        {
            return repositorio.ActualizarDetallesPac(idPaa, nomUsuario);
        }
        #endregion

        #region Busqueda y listas
        public PlanAnualAdquisicion Buscar(int idPaa)
        {
            return repositorio.TraerPorCondicion(x => x.idPaa == idPaa && x.estado != 1);
        }
        public PlanAnualAdquisicionRequerimiento BuscarReqPorCodigo(int idPaaReq)
        {
            return repoPaaReq.TraerPorID(idPaaReq);
        }
        public PlanAnualAdquisicionRequerimiento BuscarReqPorDescripcion_Area(int idPaa, string descripcion, int idArea)
        {
            return repoPaaReq.TraerPorCondicion(x => x.idPaa == idPaa && x.descripcion.Trim().ToUpper().Equals(descripcion.Trim().ToUpper()) && x.idArea == idArea && x.estado != 1);
        }
        public PlanAnualAdquisicionDetalle BuscarDetallePorCodigo(int idPaaDet)
        {
            return repoPaaDet.TraerPorID(idPaaDet);
        }
        public PlanAnualAdquisicionDetalle BuscarDetallePorVarios(int idPaaReq, int idCueCon, string descripcion, int idUnidad, decimal precio)
        {
            return repoPaaDet.TraerPorCondicion(x=>x.idPaaReq == idPaaReq && x.idCueCon == idCueCon && x.descripcion.Trim().ToUpper().Equals(descripcion.Trim().ToUpper()) && x.idUnidad == idUnidad && x.precio == precio && x.estado != 1);
        }
        public List<PlanAnualAdquisicion> listarTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != 1).OrderByDescending(x=>x.anio).ToList();
        }
        public List<PlanAnualAdquisicionRequerimientoPres> TraerListaPlanAnualAdquisicionRequerimiento(int idPaa)
        {
            return repositorio.TraerListaPlanAnualAdquisicionRequerimiento(idPaa);
        }
        public PlanAnualAdquisicionDetalleMes BuscarPorCodigoPaaDetalleMes(int idPaaDet, int mes)
        {
            return repoPaaDetMes.TraerPorCondicion(t => t.idPaaDet == idPaaDet && t.mes == mes && t.estado != 1);
        }
        public decimal BuscarImporteDetalle(int idPaaDet, decimal precio)
        {
            decimal importe = 0;
            var paaDetMes = repoPaaDetMes.TraerVariosPorCondicion(t => t.idPaaDet == idPaaDet && t.estado != 1);

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
        public List<PlanAnualAdquisicionReqPres> TraerListaPlanAnualAdquisicionReq(int idPaa)
        {
            return repoPaaReq.TraerListaPlanAnualAdquisicionReq(idPaa).ToList();
        }
        public List<PlanAnualAdquisicionReqDetallePres> TraerListaPlanAnualAdquisicionReqDetalle(int idPaaReq)
        {
            return repoPaaReq.TraerListaPlanAnualAdquisicionReqDetalle(idPaaReq).ToList();
        }

        #endregion

        #region Reporte
        public List<ReportePlanAnualAdquisicionDetallePres> TraerReportePlanAnualAdquisicionDetalle(int idPaa, int? idFueFin)
        {
            return repositorio.TraerReportePlanAnualAdquisicionDetalle(idPaa, idFueFin);
        }
        public List<ReportePlanAnualAdquisicionDireccionPres> TraerReportePlanAnualAdquisicionDireccion(int idPaa, int? idDireccion, int? idFueFin)
        {
            return repositorio.TraerReportePlanAnualAdquisicionDireccion(idPaa, idDireccion, idFueFin);
        }
        public List<ReportePlanAnualAdquisicionExportaPres> TraerReportePlanAnualAdquisicionExporta(int idPaa, int? idDireccion, int? idFueFin)
        {
            return repositorio.TraerReportePlanAnualAdquisicionExporta(idPaa, idDireccion, idFueFin);
        }
        #endregion
    }
}
