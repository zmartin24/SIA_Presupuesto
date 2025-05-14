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
using System.Runtime.Remoting.Contexts;
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class CertificacionRequerimientoServicio : ServicioBase, ICertificacionRequerimientoServicio
    {
        ICertificacionRequerimientoRepositorio repositorio;
        ICertificacionDetalleRepositorio repoDetalle;
        ICertificacionRequerimientoSubprespuestoRepositorio repoCertificacionSubpresupuesto;
        ISubpresupuestoRepositorio repoSubpresupuesto;

        public CertificacionRequerimientoServicio(ICertificacionRequerimientoRepositorio repositorio, ICertificacionDetalleRepositorio repoDetalle, ISubpresupuestoRepositorio repoSubpresupuesto, ICertificacionRequerimientoSubprespuestoRepositorio repoCertificacionSubpresupuesto)
        {
            this.repositorio = repositorio;
            this.repoDetalle = repoDetalle;
            this.repoSubpresupuesto = repoSubpresupuesto;
            this.repoCertificacionSubpresupuesto = repoCertificacionSubpresupuesto;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        private CertificacionRequerimiento Clonar(CertificacionRequerimiento certificacionRequerimientoOld)
        {
            return new CertificacionRequerimiento
            {
                idCerReq = certificacionRequerimientoOld.idCerReq,
                numero = certificacionRequerimientoOld.numero,
                sigla = certificacionRequerimientoOld.sigla,
                fechaEmision = certificacionRequerimientoOld.fechaEmision,
                idPresupuesto = certificacionRequerimientoOld.idPresupuesto,
                nivelPresupuesto = certificacionRequerimientoOld.nivelPresupuesto,
                tipoCambio = certificacionRequerimientoOld.tipoCambio,
                idCerMas = certificacionRequerimientoOld.idCerMas,
                totalSoles = certificacionRequerimientoOld.totalSoles,
                totalDolares = certificacionRequerimientoOld.totalDolares,
                observacion = certificacionRequerimientoOld.observacion,
                usuCrea = certificacionRequerimientoOld.usuCrea,
                fechaCrea = certificacionRequerimientoOld.fechaCrea,
                usuEdita = certificacionRequerimientoOld.usuEdita,
                fechaEdita = certificacionRequerimientoOld.fechaEdita,
                usuAmp = certificacionRequerimientoOld.usuAmp,
                fechaAmp = certificacionRequerimientoOld.fechaAmp,
                usuEditaAmp = certificacionRequerimientoOld.usuEditaAmp,
                fechaEditaAmp = certificacionRequerimientoOld.fechaEditaAmp,
                justificacionAmp = certificacionRequerimientoOld.justificacionAmp,
                detalle = certificacionRequerimientoOld.detalle,
                estado = certificacionRequerimientoOld.estado
            };
        }
        private CertificacionDetalle Clonar(CertificacionDetalle certificacionDetalleOld)
        {
            return new CertificacionDetalle
            {
                idCerDet = certificacionDetalleOld.idCerDet,
                idCerReq = certificacionDetalleOld.idCerReq,
                esAmpliacion = certificacionDetalleOld.esAmpliacion,
                idProAnuReaMen = certificacionDetalleOld.idProAnuReaMen,
                tipoProRea = certificacionDetalleOld.tipoProRea,
                idCueCon = certificacionDetalleOld.idCueCon,
                idForReqDet = certificacionDetalleOld.idForReqDet,
                cantidad = certificacionDetalleOld.cantidad,
                precio = certificacionDetalleOld.precio,
                subTotal = certificacionDetalleOld.subTotal,
                usuCrea = certificacionDetalleOld.usuCrea,
                fechaCrea = certificacionDetalleOld.fechaCrea,
                usuEdita = certificacionDetalleOld.usuEdita,
                fechaEdita = certificacionDetalleOld.fechaEdita,
                estado = certificacionDetalleOld.estado
            };
        }
        public Resultado Nuevo(CertificacionRequerimiento certificacionRequerimiento, CertificacionMasterPres certificacionMasterPres, List<ForeDetallePoco> listaForeDetallePoco, int idSubpresupuesto)
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
                    IUnidadTrabajo unidadTrabajoCerDet = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoCerSub = repoCertificacionSubpresupuesto.UnidadTrabajo as IUnidadTrabajo;
                    CertificacionDetalle objCerDet = null;
                    CertificacionRequerimientoSubprespuesto objCertSubpresupuesto = null;
                    
                    
                    
                    certificacionRequerimiento.totalSoles = 0;
                    certificacionRequerimiento.totalDolares = 0;
                    //certificacionRequerimiento.numero = repositorio.TraerUltimoNumeroCertificacion(DateTime.Now.Year); 
                    //certificacionRequerimiento.sigla = Utilitario.Util.UtilitarioComun.CompletarCeros((Int32)certificacionRequerimiento.numero, 4) + "-" + certificacionRequerimiento.fechaEmision.Year.ToString() + "-CORAH-OPP";
                    certificacionRequerimiento.numero = repositorio.TraerUltimoNumeroCertificacion(certificacionRequerimiento.fechaEmision.Year);
                    certificacionRequerimiento.sigla = Utilitario.Util.UtilitarioComun.CompletarCeros((Int32)certificacionRequerimiento.numero, 6) + "-" + certificacionRequerimiento.fechaEmision.Year.ToString() + "-CORAH-OPP";

                    Resultado resValidaFechaCertificacion = repositorio.ValidaFechaCertificacion(certificacionRequerimiento.fechaEmision, certificacionRequerimiento.numero, "I", null);

                    if (resValidaFechaCertificacion.esCorrecto)
                    {
                        repositorio.Agregar(certificacionRequerimiento);
                        
                        if (listaForeDetallePoco.Count > 0)
                        {
                            foreach (ForeDetallePoco foreDet in listaForeDetallePoco)
                            {
                                objCerDet = new CertificacionDetalle()
                                {
                                    idCerReq = certificacionRequerimiento.idCerReq,
                                    idProAnuReaMen = foreDet.idProAnuReaMen != null ? (Int32)foreDet.idProAnuReaMen : 0,
                                    tipoProRea = foreDet.tipoDet != null ? (Int32)foreDet.tipoDet : 1,// si es programacion anual o reajuste
                                    idCueCon = foreDet.idCueCon != null ? (Int32)foreDet.idCueCon : 0,
                                    idForReqDet = foreDet.idDetalle,
                                    cantidad = foreDet.cantidad == 0 ? 1 : foreDet.cantidad,
                                    precio = foreDet.precio,
                                    subTotal = foreDet.subTotal == 0 ? Math.Round(foreDet.cantidad == 0 ? 1 : foreDet.cantidad * foreDet.precio, 2) : foreDet.subTotal,
                                    usuCrea = certificacionRequerimiento.usuCrea,
                                    fechaCrea = DateTime.Now,
                                    usuEdita = null,
                                    fechaEdita = null,
                                    estado = Estados.Activo
                                };
                                repoDetalle.Agregar(objCerDet);
                                unidadTrabajoCerDet.GuardarCambios();
                            }

                        }// fin if lista

                        objCertSubpresupuesto = new CertificacionRequerimientoSubprespuesto()
                        {
                            idCerReq = certificacionRequerimiento.idCerReq,
                            idSubpresupuesto = idSubpresupuesto,
                            usuCrea = certificacionRequerimiento.usuCrea,
                            fechaCrea = DateTime.Now,
                            usuEdita = null,
                            fechaEdita = null,
                            estado = true
                        };
                        repoCertificacionSubpresupuesto.Agregar(objCertSubpresupuesto);
                        unidadTrabajoCerSub.GuardarCambios();

                        //repositorio.Agregar(certificacionRequerimiento);
                        unidadTrabajo.GuardarCambios();
                        
                        //opcion: 2 =>Certificación
                        repositorio.ActualizarEstadoRequerimientoForebise(2, certificacionMasterPres.tipoReq, (int)certificacionMasterPres.idForebise, certificacionMasterPres.tipoReq == 1 ? 153 : 155, certificacionRequerimiento.usuCrea, certificacionRequerimiento.fechaCrea);
                        repositorio.ActualizarTotalCertificacionRequerimiento(certificacionRequerimiento.idCerReq);

                        scope.Complete();
                        resultado = MensajeSatisfactorio(TipoMensaje.Creacion, certificacionRequerimiento);
                        resultado.id = certificacionRequerimiento.idCerReq;
                    }
                    else
                        resultado = resValidaFechaCertificacion;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, certificacionRequerimiento, ex);
                }
            }

            return resultado;
        }
        public Resultado NuevoAmpliacion(CertificacionRequerimiento certificacionRequerimiento, CertificacionMasterPres certificacionMasterPres, List<ForeDetallePoco> listaForeDetallePoco, bool esModificacion)
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
                    IUnidadTrabajo unidadTrabajoCerDet = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                    
                    CertificacionDetalle objCerDet = null;
                    if (listaForeDetallePoco.Count > 0)
                    {
                        foreach (ForeDetallePoco foreDet in listaForeDetallePoco)
                        {
                            if (foreDet.idCerDet == null)
                            {
                                objCerDet = new CertificacionDetalle()
                                {
                                    idCerReq = certificacionRequerimiento.idCerReq,
                                    idProAnuReaMen = (int)foreDet.idProAnuReaMen,
                                    esAmpliacion = true,// es detalle de ampliación
                                    tipoProRea = (int)foreDet.tipoDet,// si es programacion anual o reajuste
                                    idCueCon = (int)foreDet.idCueCon,
                                    idForReqDet = foreDet.idDetalle,
                                    cantidad = foreDet.cantidad == 0 ? 1 : foreDet.cantidad,
                                    precio = foreDet.precio,
                                    subTotal = foreDet.subTotal == 0 ? Math.Round(foreDet.cantidad == 0 ? 1 : foreDet.cantidad * foreDet.precio, 2) : foreDet.subTotal,
                                    usuCrea = certificacionRequerimiento.usuEditaAmp == null ? certificacionRequerimiento.usuAmp : certificacionRequerimiento.usuEditaAmp,
                                    fechaCrea = certificacionRequerimiento.usuEditaAmp == null ? (DateTime)certificacionRequerimiento.fechaAmp : (DateTime)certificacionRequerimiento.fechaEditaAmp,
                                    usuEdita = null,
                                    fechaEdita = null,
                                    estado = Estados.Activo
                                };
                                repoDetalle.Agregar(objCerDet);
                            }
                            else
                            {
                                objCerDet = repoDetalle.TraerPorID((int)foreDet.idCerDet);//new CertificacionDetalle()

                                objCerDet.idProAnuReaMen = (int)foreDet.idProAnuReaMen;
                                objCerDet.tipoProRea = (int)foreDet.tipoDet;// si es programacion anual o reajuste
                                objCerDet.idCueCon = (int)foreDet.idCueCon;
                                objCerDet.idForReqDet = foreDet.idDetalle;
                                objCerDet.cantidad = foreDet.cantidad == 0 ? 1 : foreDet.cantidad;
                                objCerDet.precio = foreDet.precio;
                                objCerDet.subTotal = foreDet.subTotal == 0 ? Math.Round(foreDet.cantidad == 0 ? 1 : foreDet.cantidad * foreDet.precio, 2) : foreDet.subTotal;
                                objCerDet.usuEdita = certificacionRequerimiento.usuEditaAmp;
                                objCerDet.fechaEdita = certificacionRequerimiento.fechaEditaAmp;
                               
                                repoDetalle.Actualizar(objCerDet);
                            }
                            unidadTrabajoCerDet.GuardarCambios();
                        }
                    }// fin if lista

                    CertificacionRequerimiento objCertificacionRequerimiento = repositorio.TraerPorID(certificacionRequerimiento.idCerReq);
                    objCertificacionRequerimiento.detalle = certificacionRequerimiento.detalle;
                    objCertificacionRequerimiento.justificacionAmp = certificacionRequerimiento.justificacionAmp;
                    if (esModificacion)
                    {
                        objCertificacionRequerimiento.usuEditaAmp = certificacionRequerimiento.usuEditaAmp;
                        objCertificacionRequerimiento.fechaEditaAmp = certificacionRequerimiento.fechaEditaAmp;
                    }
                    else
                    {
                        objCertificacionRequerimiento.usuAmp = certificacionRequerimiento.usuAmp;
                        objCertificacionRequerimiento.fechaAmp = certificacionRequerimiento.fechaAmp;
                    }

                    repositorio.Actualizar(objCertificacionRequerimiento);
                    unidadTrabajo.GuardarCambios();

                    repositorio.ActualizarTotalCertificacionRequerimiento(objCertificacionRequerimiento.idCerReq);

                    scope.Complete();

                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, certificacionRequerimiento);
                    resultado.id = certificacionRequerimiento.idCerReq;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, certificacionRequerimiento, ex);
                }
            }

            return resultado;
        }
        public Resultado NuevoDetalle(CertificacionDetalle certificacionDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoDetalle.Agregar(certificacionDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, certificacionDetalle);
                resultado.id = certificacionDetalle.idCerDet;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, certificacionDetalle, ex);
            }

            return resultado;
        }
        public Resultado Modificar(CertificacionRequerimiento certificacionRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                CertificacionRequerimiento clon = Clonar(certificacionRequerimiento);
                
                repositorio.Actualizar(clon);
                unidadTrabajo.GuardarCambios();

                repositorio.ActualizarTotalCertificacionRequerimiento(clon.idCerReq);

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, certificacionRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, certificacionRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado ModificarDetalles(CertificacionDetalle certificacionDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                CertificacionDetalle clon = Clonar(certificacionDetalle);
                repoDetalle.Actualizar(clon);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, certificacionDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, certificacionDetalle, ex);
            }

            return resultado;
        }
        public Resultado Anular(CertificacionRequerimiento certificacionRequerimiento, int tipoReq, int idForebise, string usuario)
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
                    CertificacionRequerimiento clon = repositorio.TraerPorID(certificacionRequerimiento.idCerReq);//Clonar(certificacionRequerimiento);
                    

                    clon.estado = Estados.Anulado;
                    clon.fechaEdita = DateTime.Now;
                    clon.usuEdita = usuario;

                    List<int> listaDet = repoDetalle.TraerVariosPorCondicion(x => x.idCerReq == certificacionRequerimiento.idCerReq && x.estado != 1).Select(s => s.idCerDet).ToList();
                    if (listaDet.Count > 0)
                    {
                        foreach (int vidCerDet in listaDet)
                        {
                            CertificacionDetalle objDet = repoDetalle.TraerPorCondicion(x => x.idCerDet == vidCerDet);
                            objDet.estado = Estados.Anulado;
                            objDet.fechaEdita = DateTime.Now;
                            objDet.usuEdita = usuario;

                            repoDetalle.Actualizar(objDet);
                        }
                    }
                    repositorio.Actualizar(clon);
                    unidadTrabajo.GuardarCambios();

                    //opcion: 3 =>Anula Certificación y Forebi/Forese al estado pendiente
                    repositorio.ActualizarEstadoRequerimientoForebise(3, tipoReq, idForebise, tipoReq == 1 ? 22 : 108, usuario, DateTime.Now);

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, clon);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, certificacionRequerimiento, ex);
                }
            }

            return resultado;
        }
        public Resultado NuevoDetalleMasivoReque(CertificacionRequerimiento certificacionRequerimiento, List<ForeDetallePoco> listaForeDetallePoco)
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
                    IUnidadTrabajo unidadTrabajoCerDet = repoDetalle.UnidadTrabajo as IUnidadTrabajo;

                    CertificacionDetalle objCerDet = null;
                    CertificacionRequerimiento clonCertificacionRequerimiento = Clonar(certificacionRequerimiento);

                    if (listaForeDetallePoco.Count > 0)
                    {
                        foreach (ForeDetallePoco foreDet in listaForeDetallePoco)
                        {
                            objCerDet = new CertificacionDetalle()
                            {
                                idCerReq = certificacionRequerimiento.idCerReq,
                                esAmpliacion = false,
                                idProAnuReaMen = (Int32)foreDet.idProAnuReaMen,
                                tipoProRea = (Int32)foreDet.tipoDet,// si es programacion anual o reajuste
                                idCueCon = (Int32)foreDet.idCueCon,
                                idForReqDet = foreDet.idDetalle,
                                cantidad = foreDet.cantidad == 0 ? 1 : foreDet.cantidad,
                                precio = foreDet.precio,
                                subTotal = foreDet.subTotal == 0 ? Math.Round(foreDet.cantidad == 0 ? 1 : foreDet.cantidad * foreDet.precio, 2) : foreDet.subTotal,
                                usuCrea = clonCertificacionRequerimiento.usuCrea,
                                fechaCrea = DateTime.Now,
                                usuEdita = null,
                                fechaEdita = null,
                                estado = Estados.Activo
                            };
                            repoDetalle.Agregar(objCerDet);
                            unidadTrabajoCerDet.GuardarCambios();
                        }

                    }// fin if lista
                    
                    repositorio.Actualizar(clonCertificacionRequerimiento);

                    repositorio.ActualizarTotalCertificacionRequerimiento(clonCertificacionRequerimiento.idCerReq);

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, listaForeDetallePoco);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, listaForeDetallePoco, ex);
                }
            }

            return resultado;
        }
        public Resultado ModificarDetalleMasivoReque(CertificacionRequerimiento certificacionRequerimiento, List<ForeDetallePoco> listaForeDetallePoco)
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
                    IUnidadTrabajo unidadTrabajoCerDet = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                    CertificacionRequerimiento clonCertificacionRequerimiento = Clonar(certificacionRequerimiento);
                    CertificacionDetalle objCerDet = null;

                    if (listaForeDetallePoco.Count > 0)
                    {
                        foreach (ForeDetallePoco foreDet in listaForeDetallePoco)
                        {
                            objCerDet = repoDetalle.TraerPorID((int)foreDet.idCerDet);

                            objCerDet.idProAnuReaMen = (Int32)foreDet.idProAnuReaMen;
                            objCerDet.tipoProRea = (Int32)foreDet.tipoDet;
                            objCerDet.idCueCon = (Int32)foreDet.idCueCon;
                            objCerDet.precio = foreDet.precio;
                            objCerDet.cantidad = foreDet.cantidad;
                            objCerDet.subTotal = foreDet.subTotal;
                            objCerDet.usuEdita = clonCertificacionRequerimiento.usuCrea;
                            objCerDet.fechaEdita = DateTime.Now;
                            
                            repoDetalle.Actualizar(objCerDet);
                            unidadTrabajoCerDet.GuardarCambios();
                        }

                    }// fin if lista

                    repositorio.Actualizar(clonCertificacionRequerimiento);
                    //unidadTrabajo.GuardarCambios();

                    repositorio.ActualizarTotalCertificacionRequerimiento(clonCertificacionRequerimiento.idCerReq);

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, listaForeDetallePoco);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, listaForeDetallePoco, ex);
                }
            }

            return resultado;
        }
        public Resultado AnularDetalle(CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres)
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
                    IUnidadTrabajo unidadTrabajoCerDet = repoDetalle.UnidadTrabajo as IUnidadTrabajo;
                    CertificacionRequerimiento objCerReq = null;
                    CertificacionDetalle objCerDet = null;

                    objCerDet = repoDetalle.TraerPorID((int)certificacionDetallePres.idCerDet);

                    objCerDet.usuEdita = certificacionRequerimiento.usuEdita;
                    objCerDet.fechaEdita = DateTime.Now;
                    objCerDet.estado = Estados.Anulado;

                    repoDetalle.Actualizar(objCerDet);
                    unidadTrabajoCerDet.GuardarCambios();

                    objCerReq = repositorio.TraerPorID((int)certificacionRequerimiento.idCerReq);
                    
                    repositorio.Actualizar(objCerReq);
                    //unidadTrabajo.GuardarCambios();
                    repositorio.ActualizarTotalCertificacionRequerimiento(objCerReq.idCerReq);

                    scope.Complete();

                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, certificacionDetallePres);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, certificacionDetallePres, ex);
                }
            }
            
            return resultado;
        }
        public Resultado AsignacionSubpresupuesto(CertificacionRequerimiento certificacionRequerimiento, int idSubpresupuesto)
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
                    IUnidadTrabajo unidadTrabajo = repoCertificacionSubpresupuesto.UnidadTrabajo as IUnidadTrabajo;
                    CertificacionRequerimientoSubprespuesto objCerSubpresupuesto = null;

                    objCerSubpresupuesto = new CertificacionRequerimientoSubprespuesto()
                    {
                        idCerReq = certificacionRequerimiento.idCerReq,
                        idSubpresupuesto = idSubpresupuesto,
                        usuCrea = certificacionRequerimiento.usuCrea,
                        fechaCrea = DateTime.Now,
                        usuEdita = null,
                        fechaEdita = null,
                        estado = true
                    };

                    repoCertificacionSubpresupuesto.Agregar(objCerSubpresupuesto);
                    unidadTrabajo.GuardarCambios();


                    scope.Complete();

                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, certificacionRequerimiento);
                    resultado.id = certificacionRequerimiento.idCerReq;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, certificacionRequerimiento, ex);
                }
            }

            return resultado;
        }
        public Resultado AnularAsignacionSubpresupuesto(CertificacionRequerimiento certificacionRequerimiento, List<int> listaSubpresupuestoIds)
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
                    IUnidadTrabajo unidadTrabajo = repoCertificacionSubpresupuesto.UnidadTrabajo as IUnidadTrabajo;
                    
                    if (listaSubpresupuestoIds.Count > 0)
                    {
                        foreach (int idSubpresupuesto in listaSubpresupuestoIds)
                        {
                            CertificacionRequerimientoSubprespuesto certReqSubprespuesto = repoCertificacionSubpresupuesto.TraerPorCondicion(x => x.idCerReq == certificacionRequerimiento.idCerReq && x.idSubpresupuesto == idSubpresupuesto && x.estado);

                            certReqSubprespuesto.usuEdita = certificacionRequerimiento.usuEdita;
                            certReqSubprespuesto.fechaEdita = DateTime.Now;
                            certReqSubprespuesto.estado = false;
                            
                            repoCertificacionSubpresupuesto.Actualizar(certReqSubprespuesto);
                            unidadTrabajo.GuardarCambios();
                        }
                    }// fin if lista

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, certificacionRequerimiento);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repoCertificacionSubpresupuesto, TipoMensaje.Eliminacion, certificacionRequerimiento, ex);
                }
            }

            return resultado;
        }
        public Resultado ValidaFechaCertificacion(DateTime fechaEmision, int numero, string opcion, int? idCerReq)
        {
            return repositorio.ValidaFechaCertificacion(fechaEmision, numero, opcion, idCerReq);
        }
        public bool ActualizarEstadoCertificacionPresupuestal(int idCerReq, string opcion, string usuario)
        {
            return repositorio.ActualizarEstadoCertificacionPresupuestal(idCerReq, opcion, usuario);
        }
        public bool ActualizarImporteCertificacion(int idCerReq, string usuario)
        {
            return repositorio.ActualizarImporteCertificacion(idCerReq, usuario);
        }
        #endregion

        #region Busqueda y listas
        public CertificacionRequerimiento BuscarPorCodigo(int idCerReq)
        {
            CertificacionRequerimiento certificacionRequerimiento = repositorio.BuscarPorCodigo(idCerReq);
            return certificacionRequerimiento;
        }
        public CertificacionDetalle BuscarDetallePorCodigo(int idCerDet)
        {
            return repoDetalle.TraerPorID(idCerDet);
        }
        public List<CertificacionRequerimiento> listarTodosActivos(int anio)
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != 1 && x.fechaEmision.Year == anio);
        }
        public List<CertificacionRequerimiento> listarCertificacionRequerimientoPorIdCerMas(int idCerMas)
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != 1 && x.idCerMas == idCerMas);
        }
        public List<CertificacionRequerimientoPres> TraerListaCertificacionRequerimiento(int anio)
        {
            return repositorio.TraerListaCertificacionRequerimiento(anio);
        }
        public List<CertificacionDetalle> listarDetallesTodosActivos(int idCerReq)
        {
            return repoDetalle.TraerVariosPorCondicion(x => x.idCerReq == idCerReq && x.estado != 1);
        }
        public List<PrecioBienServicioPres> TraerListaPrecioBienServicio(int anio, int idProSer, int tipo)
        {
            return repositorio.TraerListaPrecioBienServicio(anio, idProSer, tipo);
        }
        public List<PrecioBienServicioPres> TraerListaPrecioBienServicioRequerimiento(int anio, int idProducto, int idCueCon, int idReqBieSer, int tipo)
        {
            return repositorio.TraerListaPrecioBienServicioRequerimiento(anio, idProducto, idCueCon, idReqBieSer, tipo);
        }

        public int TraerUltimoNumeroCertificacion(int anio)
        {
            return repositorio.TraerUltimoNumeroCertificacion(anio);
        }
        public SubPresupuestoImporteCertificacion_Pres TraerSubPresupuestoImporteCertificacion(int idSubPresupuesto)
        {
            return repositorio.TraerSubPresupuestoImporteCertificacion(idSubPresupuesto);
        }
        public decimal TraerImporteCotizacionPorCertificacion(int idCerReq)
        {
            return repositorio.TraerImporteCotizacionPorCertificacion(idCerReq);
        }

        public List<Forebi> TraerListaForebiPorSubPresupuesto(int idSubPresupuesto)
        {
            return repositorio.TraerListaForebiPorSubPresupuesto(idSubPresupuesto);
        }
        public List<Forese> TraerListaForesePorSubPresupuesto(int idSubPresupuesto)
        {
            return repositorio.TraerListaForesePorSubPresupuesto(idSubPresupuesto);
        }
        public List<ForeDetallePoco> TraerListaForebiDetallePoco(int idForebi)
        {
            return repositorio.TraerListaForebiDetallePoco(idForebi);
        }
        public List<ForeDetallePoco> TraerListaForeseDetallePoco(int idForese)
        {
            return repositorio.TraerListaForeseDetallePoco(idForese);
        }
        public List<ForeDetallePoco> TraerListaFormatoRequerimientoDetalle(int idFore, int tipo)
        {
            return repositorio.TraerListaFormatoRequerimientoDetalle(idFore, tipo);
        }
        public List<SubPresupuestoDetallePres> TraerListaSubPresupuestoDetalle(int idSubPresupuesto)
        {
            return repositorio.TraerListaSubPresupuestoDetalle(idSubPresupuesto);
        }
        public List<CertificacionDetallePres> TraerListaCertificacionDetalle(int? idCerMas, int? idCerReq)
        {
            return repositorio.TraerListaCertificacionDetalle(idCerMas, idCerReq);
        }
        public VerificaCertificacionDetallePres VerificaCertificacionDetalle(int? idCerReq, int? idCerDet)
        {
            return repositorio.VerificaCertificacionDetalle(idCerReq, idCerDet);
        }
        public decimal TraerCantPendiente(int idForReqDet, int tipoReq)
        {
            return repositorio.TraerCantPendiente(idForReqDet, tipoReq);
        }
        public decimal TraerImporteMinCer()
        {
            return repositorio.TraerImporteMinCer();
        }
        public List<CertificacionRequerimientoExportaPres> TraerListaCertificacionRequerimientoExporta(int tipoReq, int anio)
        {
            return repositorio.TraerListaCertificacionRequerimientoExporta(tipoReq, anio).ToList();
        }
        public List<SubPresupuestoPoco> TraerListaSubPresupuestoPocoPorIdCerReq(int idCerReq)
        {
            return repositorio.TraerListaSubPresupuestoPocoPorIdCerReq(idCerReq);
        }
        public List<ForeDetallePoco> TraerListaCertificacionDetalleAmpiacion(int idCerReq)
        {
            return repositorio.TraerListaCertificacionDetalleAmpiacion(idCerReq);
        }
        public List<UsuarioCorreoPres> TraerListaUsuarioCorreo()
        {
            return repositorio.TraerListaUsuarioCorreo().ToList();
        }
        public List<CertificacionRequerimientoSubprespuesto> listaCertificacionRequerimientoSubprespuesto(int idCerReq, int idSubpresupuesto)
        {
            return repoCertificacionSubpresupuesto.TraerVariosPorCondicion(x => x.estado != false && x.idCerReq == idCerReq && x.idSubpresupuesto == idSubpresupuesto);
        }
        public List<OrdenPorCertificacionPres> TraerListaOrdenPorCertificacion(int idCerReq)
        {
            return repositorio.TraerListaOrdenPorCertificacion(idCerReq);
        }
        #endregion

        #region Reporte
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal(int idCerReq, bool esAmpliacion)
        {
            return repositorio.TraerReporteCertificacionPresupuestal(idCerReq, esAmpliacion).ToList();
        }
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestalVarios(string idsCerReq, bool esAmpliacion)
        {
            return repositorio.TraerReporteCertificacionPresupuestalVarios(idsCerReq, esAmpliacion).ToList();
        }
        #endregion
    }
}
