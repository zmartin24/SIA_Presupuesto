using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PartidaPresupuestalServicio : ServicioBase, IPartidaPresupuestalServicio
    {
        IPartidaPresupuestalRepositorio repositorio;
        IPartidaPresupuestalCuentaRepositorio repoPartidaCuenta;

        public PartidaPresupuestalServicio(IPartidaPresupuestalRepositorio repositorio, IPartidaPresupuestalCuentaRepositorio repoPartidaCuenta)
        {
            this.repositorio = repositorio;
            this.repoPartidaCuenta = repoPartidaCuenta;
        }


        #region operaciones
        private PartidaPresupuestal Clonar(PartidaPresupuestal partidaPresupuestalOld)
        {
            return new PartidaPresupuestal
            {
                idParPre = partidaPresupuestalOld.idParPre,
                tipo = partidaPresupuestalOld.tipo,
                descripcion = partidaPresupuestalOld.descripcion,
                idUnidad = partidaPresupuestalOld.idUnidad,
                precio = partidaPresupuestalOld.precio,
                
                usuCrea = partidaPresupuestalOld.usuCrea,
                fechaCrea = partidaPresupuestalOld.fechaCrea,
                usuEdita = partidaPresupuestalOld.usuEdita,
                fechaEdita = partidaPresupuestalOld.fechaEdita,
                estado = partidaPresupuestalOld.estado,

                cuentaContable = partidaPresupuestalOld.cuentaContable


            };
        }
        public Resultado Nuevo(PartidaPresupuestal partidaPresupuestal)
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
                    IUnidadTrabajo unidadTrabajoPartidaCuenta = repoPartidaCuenta.UnidadTrabajo as IUnidadTrabajo;

                    repositorio.Agregar(partidaPresupuestal);

                    if (partidaPresupuestal.cuentaContable != null)
                    {
                        PartidaPresupuestalCuenta partidaPresupuestalCuenta = new PartidaPresupuestalCuenta()
                        {
                            idParPre = partidaPresupuestal.idParPre,
                            idCueCon = partidaPresupuestal.cuentaContable.idCueCon,
                            anio = (Int32)partidaPresupuestal.cuentaContable.PlanCuenta.anioEjercicio,
                            usuCrea = partidaPresupuestal.usuCrea,
                            fechaCrea = partidaPresupuestal.fechaCrea,
                            estado = true
                        };
                        repoPartidaCuenta.Agregar(partidaPresupuestalCuenta);
                        unidadTrabajoPartidaCuenta.GuardarCambios();
                    }

                    unidadTrabajo.GuardarCambios();
                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, partidaPresupuestal);
                    resultado.id = partidaPresupuestal.idParPre;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, partidaPresupuestal, ex);
                }
            }
            return resultado;
        }

        public Resultado Modificar(PartidaPresupuestal partidaPresupuestal)
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
                    IUnidadTrabajo unidadTrabajoPartidaCuenta = repoPartidaCuenta.UnidadTrabajo as IUnidadTrabajo;
                    //PartidaPresupuestal obj = repositorio.TraerPorID(partidaPresupuestal.idParPre);
                    PartidaPresupuestal obj = Clonar(partidaPresupuestal);

                    obj.fechaEdita = DateTime.Now;
                    repositorio.Actualizar(obj);

                    obj.ListaPartidaPresupuestalCuenta = repoPartidaCuenta.TraerVariosPorCondicion(x => x.idParPre == obj.idParPre && x.estado == true);

                    if (obj.ListaPartidaPresupuestalCuenta.Where(x => x.idCueCon == obj.cuentaContable.idCueCon).FirstOrDefault() == null && obj.cuentaContable != null)
                    {
                        var partidaCuenta = obj.ListaPartidaPresupuestalCuenta.Where(x => x.anio == obj.cuentaContable.PlanCuenta.anioEjercicio).FirstOrDefault();
                        if (partidaCuenta == null)
                        {
                            PartidaPresupuestalCuenta partidaPresupuestalCuenta = new PartidaPresupuestalCuenta()
                            {
                                idParPre = obj.idParPre,
                                idCueCon = obj.cuentaContable.idCueCon,
                                anio = (Int32)obj.cuentaContable.PlanCuenta.anioEjercicio,
                                usuCrea = obj.usuCrea,
                                fechaCrea = obj.fechaCrea,
                                estado = true
                            };
                            repoPartidaCuenta.Agregar(partidaPresupuestalCuenta);
                            unidadTrabajoPartidaCuenta.GuardarCambios();
                        }
                    }

                    unidadTrabajo.GuardarCambios();

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, obj);
                    resultado.id = obj.idParPre;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Modificacion, partidaPresupuestal, ex);
                }
            }
            return resultado;
        }

        public Resultado Anular(int idParPre, string usuario)
        {
            TransactionOptions Tranconfiguracion = new TransactionOptions()
            {
                Timeout = TransactionManager.MaximumTimeout,
                IsolationLevel = IsolationLevel.Serializable
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, Tranconfiguracion))
            {
                PartidaPresupuestal obj = repositorio.TraerPorID(idParPre);
                try
                {
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPartidaCuenta = repoPartidaCuenta.UnidadTrabajo as IUnidadTrabajo;

                    obj.estado = Estados.Anulado;
                    obj.usuEdita = usuario;
                    obj.fechaEdita = DateTime.Now;


                    repositorio.Actualizar(obj);

                    foreach (PartidaPresupuestalCuenta partidaPresupuestalCuenta in repoPartidaCuenta.TraerVariosPorCondicion(x => x.idParPreCue == idParPre && x.estado == true))
                    {
                        partidaPresupuestalCuenta.estado = false;

                        repoPartidaCuenta.Actualizar(partidaPresupuestalCuenta);
                        unidadTrabajoPartidaCuenta.GuardarCambios();
                    }

                    unidadTrabajo.GuardarCambios();
                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, obj);
                    resultado.id = obj.idParPre;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, obj, ex);
                }
            }
            return resultado;
        }
        public Resultado AnularPartidaPresupuestalCuenta(int idParPreCue, string usuario)
        {
            TransactionOptions Tranconfiguracion = new TransactionOptions()
            {
                Timeout = TransactionManager.MaximumTimeout,
                IsolationLevel = IsolationLevel.Serializable
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, Tranconfiguracion))
            {
                PartidaPresupuestalCuenta obj = repoPartidaCuenta.TraerPorID(idParPreCue);
                try
                {
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                    IUnidadTrabajo unidadTrabajoPartidaCuenta = repoPartidaCuenta.UnidadTrabajo as IUnidadTrabajo;

                    obj.estado = false;
                    obj.usuEdita = usuario;
                    obj.fechaEdita = DateTime.Now;

                    repoPartidaCuenta.Actualizar(obj);

                    unidadTrabajo.GuardarCambios();
                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, obj);
                    resultado.id = obj.idParPreCue;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, obj, ex);
                }
            }
            return resultado;
        }
        #endregion

        #region lista y busqueda

        public PartidaPresupuestal BuscarPorID(int idParPre)
        {
            return repositorio.TraerPorID(idParPre);
        }
        public PartidaPresupuestal BuscarPorCodigo(int idParPre)
        {
            return repositorio.BuscarPorCodigo(idParPre);
        }
        public PartidaPresupuestal BuscarPorCondicion(string descripcion, int idUnidad, decimal precio)
        {
            return repositorio.TraerPorCondicion(
                t => t.descripcion.Trim().ToUpper().Equals(descripcion.Trim().ToUpper()) &&
                t.idUnidad == idUnidad &&
                t.precio == precio &&
                t.estado != 1);
        }
        public List<PartidaPresupuestalPres> TraerListaPartidaPresupuestal()
        {
            return repositorio.TraerListaPartidaPresupuestal();
        }
        public List<PartidaPresupuestalCuentaPoco> TraerListaPartidaPresupuestalCuentaPoco(int idParPre)
        {
            return repositorio.TraerListaPartidaPresupuestalCuentaPoco(idParPre);
        }
        public List<PartidaPresupuestalPrecioPres> TraerPartidaPresupuestalPrecio(int tipo, string descripcion, int idMoneda)
        {
            return repositorio.TraerPartidaPresupuestalPrecio(tipo, descripcion, idMoneda).ToList();
        }
        #endregion
    }
}
