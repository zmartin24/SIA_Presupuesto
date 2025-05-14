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
    public class ReajusteMensualProgramacionServicio : ServicioBase, IReajusteMensualProgramacionServicio
    {
        IReajusteMensualProgramacionRepositorio repositorio;
        IReajusteMensualAreaRepositorio repoProAnuArea;
        IReajusteMensualAreaMesRepositorio repoProAnuAreaMes;
        IReajusteMensualDetalleRepositorio repoProAnuDet;
        IReajusteMensualDetalleMesRepositorio repoProAnuDetMes;
        IProgramacionAnualRepositorio repoProAnu;

        public ReajusteMensualProgramacionServicio(IReajusteMensualProgramacionRepositorio repositorio, IReajusteMensualAreaRepositorio repoProAnuArea,
            IReajusteMensualDetalleRepositorio repoProAnuDet, IReajusteMensualAreaMesRepositorio repoProAnuAreaMes, IReajusteMensualDetalleMesRepositorio repoProAnuDetMes,
            IProgramacionAnualRepositorio repoProAnu)
        {
            this.repositorio = repositorio;
            this.repoProAnuArea = repoProAnuArea;
            this.repoProAnuDet = repoProAnuDet;
            this.repoProAnuAreaMes = repoProAnuAreaMes;
            this.repoProAnuDetMes = repoProAnuDetMes;
            this.repoProAnu = repoProAnu;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private ReajusteMensualProgramacion Clonar(ReajusteMensualProgramacion ReajusteMensual1)
        {
            return new ReajusteMensualProgramacion
            {
                idReaMenPro = ReajusteMensual1.idReaMenPro,
                idProAnu = ReajusteMensual1.idProAnu,
                descripcion = ReajusteMensual1.descripcion,
                estado = ReajusteMensual1.estado,
                fechaAprobacion = ReajusteMensual1.fechaAprobacion,
                fechaCrea = ReajusteMensual1.fechaCrea,
                fechaEdita = ReajusteMensual1.fechaEdita,
                fechaEmision = ReajusteMensual1.fechaEmision,
                mesReajuste = ReajusteMensual1.mesReajuste,
                tipoCambio = ReajusteMensual1.tipoCambio,
                usuCrea = ReajusteMensual1.usuCrea,
                usuEdita = ReajusteMensual1.usuEdita
            };
        }
        private ReajusteMensualArea Clonar(ReajusteMensualArea ReajusteMensualArea1)
        {
            return new ReajusteMensualArea
            {
                idReaMenArea = ReajusteMensualArea1.idReaMenArea,
                idReaMenPro = ReajusteMensualArea1.idReaMenPro,
                idArea = ReajusteMensualArea1.idArea,
                idCueCon = ReajusteMensualArea1.idCueCon,
                idUnidad = ReajusteMensualArea1.idUnidad,
                estado = ReajusteMensualArea1.estado,
                fechaCrea = ReajusteMensualArea1.fechaCrea,
                fechaEdita = ReajusteMensualArea1.fechaEdita,
                usuCrea = ReajusteMensualArea1.usuCrea,
                usuEdita = ReajusteMensualArea1.usuEdita
            };
        }
        private ReajusteMensualAreaMes Clonar(ReajusteMensualAreaMes ReajusteMensualAreaMes1)
        {
            return new ReajusteMensualAreaMes
            {
                idReaMenArea = ReajusteMensualAreaMes1.idReaMenArea,
                idReaMenAreaMes = ReajusteMensualAreaMes1.idReaMenAreaMes,
                estado = ReajusteMensualAreaMes1.estado,
                fechaCrea = ReajusteMensualAreaMes1.fechaCrea,
                fechaEdita = ReajusteMensualAreaMes1.fechaEdita,
                usuCrea = ReajusteMensualAreaMes1.usuCrea,
                usuEdita = ReajusteMensualAreaMes1.usuEdita,
                importe = ReajusteMensualAreaMes1.importe,
                mes = ReajusteMensualAreaMes1.mes,
            };
        }
        private ReajusteMensualDetalle Clonar(ReajusteMensualDetalle EvaluacionMensualDetalle1)
        {
            return new ReajusteMensualDetalle
            {
                idReaMenDet = EvaluacionMensualDetalle1.idReaMenDet,
                idReaMenArea = EvaluacionMensualDetalle1.idReaMenArea,
                idUnidad = EvaluacionMensualDetalle1.idUnidad,
                estado = EvaluacionMensualDetalle1.estado,
                fechaCrea = EvaluacionMensualDetalle1.fechaCrea,
                fechaEdita = EvaluacionMensualDetalle1.fechaEdita,
                usuCrea = EvaluacionMensualDetalle1.usuCrea,
                usuEdita = EvaluacionMensualDetalle1.usuEdita,
                descripcion = EvaluacionMensualDetalle1.descripcion,
                precio = EvaluacionMensualDetalle1.precio,
            };
        }

        public Resultado Nuevo(ReajusteMensualProgramacion ReajusteMensual)
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
                    repositorio.Agregar(ReajusteMensual);
                    unidadTrabajo.GuardarCambios();

                    ProgramacionAnual programacion = repoProAnu.TraerPorID(ReajusteMensual.idProAnu);

                    repositorio.GuardarFondoEjecutado(ReajusteMensual.idProAnu, ReajusteMensual.idReaMenPro, ReajusteMensual.usuCrea);


                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ReajusteMensual);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, ReajusteMensual, ex);
                }
            }

            return resultado;
        }
        public Resultado NuevoArea(ReajusteMensualArea ReajusteMensualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Agregar(ReajusteMensualArea);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ReajusteMensualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ReajusteMensualArea, ex);
            }

            return resultado;
        }
        public Resultado NuevoAreaMes(ReajusteMensualAreaMes ReajusteMensualAreaMes)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                var rea = Clonar(ReajusteMensualAreaMes);
                repoProAnuAreaMes.Agregar(rea);
                unidadTrabajo.GuardarCambios();
                ReajusteMensualAreaMes.idReaMenAreaMes = rea.idReaMenAreaMes;
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ReajusteMensualAreaMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ReajusteMensualAreaMes, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalle(ReajusteMensualDetalle ReajusteMensualDetalle, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Agregar(ReajusteMensualDetalle);
                unidadTrabajo.GuardarCambios();

                //if (actualizaArea)
                //{
                //    var ReajusteMensualAreaMes = repoProAnuAreaMes.TraerPorID((Int32)ReajusteMensualDetalle.idProAnuAreaMes);

                //    List<ReajusteMensualDetalle> lista = repoProAnuDet.TraerVariosPorCondicion(t => t.idProAnuAreaMes == ReajusteMensualDetalle.idProAnuAreaMes && t.estado != Estados.Anulado);
                //    decimal suma = lista.Sum(s => s.importe);

                //    if (ReajusteMensualAreaMes != null)
                //    {
                //        ReajusteMensualAreaMes.importe = suma;
                //        repoProAnuAreaMes.Actualizar(ReajusteMensualAreaMes);
                //        unidadTrabajo.GuardarCambios();
                //    }
                //}

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ReajusteMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ReajusteMensualDetalle, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalleMes(ReajusteMensualDetalleMes ReajusteMensualDetalle, bool actualizaArea)
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
                    repoProAnuDetMes.Agregar(ReajusteMensualDetalle);
                    unidadTrabajo.GuardarCambios();

                    if (actualizaArea)
                    {
                        var ReajusteMensualAreaMes = repoProAnuAreaMes.TraerPorID((Int32)ReajusteMensualDetalle.idReaMenAreaMes);

                        List<ReajusteMensualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReaMenAreaMes == ReajusteMensualDetalle.idReaMenAreaMes && t.ReajusteMensualDetalle.idReaMenArea == ReajusteMensualAreaMes.idReaMenArea && t.estado != Estados.Anulado);
                        decimal suma = lista.Sum(s => s.importe);

                        if (ReajusteMensualAreaMes != null)
                        {
                            ReajusteMensualAreaMes.importe = suma;
                            repoProAnuAreaMes.Actualizar(ReajusteMensualAreaMes);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ReajusteMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, ReajusteMensualDetalle, ex);
                }
            }
            return resultado;
        }

        public Resultado Modificar(ReajusteMensualProgramacion ReajusteMensual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                ReajusteMensualProgramacion objReajusteMensualProgramacion = ReajusteMensual;
                repositorio.Actualizar(Clonar(objReajusteMensualProgramacion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ReajusteMensual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ReajusteMensual, ex);
            }

            return resultado;
        }
        public Resultado ModificarAreas(ReajusteMensualArea ReajusteMensualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repoProAnuArea.UnidadTrabajo as IUnidadTrabajo;
                ReajusteMensualArea obj = new ReajusteMensualArea();
                obj = repoProAnuArea.TraerPorID(ReajusteMensualArea.idReaMenArea);

                obj.idUnidad = ReajusteMensualArea.idUnidad;
                obj.usuCrea = ReajusteMensualArea.usuCrea;
                obj.usuEdita = ReajusteMensualArea.usuEdita;
                repoProAnuArea.Actualizar(obj);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ReajusteMensualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ReajusteMensualArea, ex);
            }

            return resultado;
        }
        public Resultado ModificarAreasMes(ReajusteMensualAreaMes ReajusteMensualAreaMes)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuAreaMes.Actualizar(ReajusteMensualAreaMes);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ReajusteMensualAreaMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ReajusteMensualAreaMes, ex);
            }

            return resultado;
        }
        public Resultado ModificarDetalles(ReajusteMensualDetalle ReajusteMensualDetalle)
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
                    IUnidadTrabajo unidadTrabajo = repoProAnuDet.UnidadTrabajo as IUnidadTrabajo;
                    ReajusteMensualDetalle obj = repoProAnuDet.TraerPorID(ReajusteMensualDetalle.idReaMenDet);
                    obj.descripcion = ReajusteMensualDetalle.descripcion;
                    obj.idUnidad = ReajusteMensualDetalle.idUnidad;
                    obj.precio = ReajusteMensualDetalle.precio;
                    obj.justificacion = ReajusteMensualDetalle.justificacion;
                    obj.usuEdita = ReajusteMensualDetalle.usuEdita;
                    obj.fechaEdita = ReajusteMensualDetalle.fechaEdita;

                    repoProAnuDet.Actualizar(obj);
                    unidadTrabajo.GuardarCambios();

                    List<ReajusteMensualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReaMenDet == ReajusteMensualDetalle.idReaMenDet && t.estado != Estados.Anulado);
                    List<int> IDAreas = new List<int>();
                    foreach (var item in lista)
                    {
                        item.importe = Math.Round(item.cantidad * ReajusteMensualDetalle.precio, 2);
                        repoProAnuDetMes.Actualizar(item);
                        unidadTrabajo.GuardarCambios();
                        IDAreas.Add(item.idReaMenAreaMes);
                    }

                    var ProgramacionAnualAreas = repoProAnuAreaMes.TraerVariosPorCondicion(t => IDAreas.Contains(t.idReaMenAreaMes) && t.estado != Estados.Anulado);

                    foreach (var ProgramacionAnualArea in ProgramacionAnualAreas)
                    {
                        List<ReajusteMensualDetalleMes> listaDetArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReaMenAreaMes == ProgramacionAnualArea.idReaMenAreaMes && t.estado != Estados.Anulado);
                        decimal suma = listaDetArea.Sum(s => s.importe);

                        if (ProgramacionAnualArea != null)
                        {
                            ProgramacionAnualArea.importe = suma;
                            repoProAnuAreaMes.Actualizar(ProgramacionAnualArea);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ReajusteMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ReajusteMensualDetalle, ex);
                }
            }
            return resultado;
        }
        public Resultado ModificarDetallesMes(ReajusteMensualDetalleMes reajusteMensualDetalleMes, bool actualizaArea)
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

                    repoProAnuDetMes.Actualizar(reajusteMensualDetalleMes);
                    unidadTrabajo.GuardarCambios();

                    if (actualizaArea)
                    {
                        var ReajusteMensualArea = repoProAnuAreaMes.TraerPorID((Int32)reajusteMensualDetalleMes.idReaMenAreaMes);

                        List<ReajusteMensualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReaMenAreaMes == reajusteMensualDetalleMes.idReaMenAreaMes && t.estado != Estados.Anulado && t.ReajusteMensualDetalle.idReaMenArea == ReajusteMensualArea.idReaMenArea && t.ReajusteMensualDetalle.estado != Estados.Anulado);
                        decimal suma = lista.Sum(s => s.importe);

                        if (ReajusteMensualArea != null)
                        {
                            ReajusteMensualArea.importe = suma;
                            repoProAnuAreaMes.Actualizar(ReajusteMensualArea);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, reajusteMensualDetalleMes);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Modificacion, reajusteMensualDetalleMes, ex);
                }
            }
            return resultado;
        }

        public Resultado Eliminar(ReajusteMensualProgramacion ReajusteMensual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(ReajusteMensual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajusteMensual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajusteMensual, ex);
            }

            return resultado;
        }
        public Resultado Anular(ReajusteMensualProgramacion ReajusteMensual, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ReajusteMensual.estado = Estados.Anulado;
                ReajusteMensual.fechaEdita = DateTime.Now;
                ReajusteMensual.usuEdita = usuario;

                repositorio.Actualizar(ReajusteMensual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajusteMensual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajusteMensual, ex);
            }

            return resultado;
        }
        public Resultado AnularArea(ReajusteMensualArea ReajusteMensualArea, string usuario)
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


                    List<ReajusteMensualAreaMes> programacionAnualAreas =
                        repoProAnuAreaMes.TraerVariosPorCondicion(t => t.idReaMenArea == ReajusteMensualArea.idReaMenArea && t.estado != 1);


                    List<ReajusteMensualDetalle> programacionAnualDetalles =
                        repoProAnuDet.TraerVariosPorCondicion(t => t.idReaMenArea == ReajusteMensualArea.idReaMenArea && t.estado != 1);

                    IEnumerable<int> IDs = programacionAnualDetalles.Select(s => s.idReaMenDet).Distinct();

                    List<ReajusteMensualDetalleMes> programacionAnualDetallesMeses =
                        repoProAnuDetMes.TraerVariosPorCondicion(t => IDs.Contains((Int32)t.idReaMenDet) && t.estado != 1);

                    ReajusteMensualArea.estado = Estados.Anulado;
                    ReajusteMensualArea.fechaEdita = DateTime.Now;
                    ReajusteMensualArea.usuEdita = usuario;

                    repoProAnuArea.Actualizar(ReajusteMensualArea);

                    foreach (ReajusteMensualAreaMes programacionAnualArea in programacionAnualAreas)
                    {
                        programacionAnualArea.estado = Estados.Anulado;
                        programacionAnualArea.fechaEdita = DateTime.Now;
                        programacionAnualArea.usuEdita = usuario;

                        repoProAnuAreaMes.Actualizar(programacionAnualArea);
                    }

                    foreach (ReajusteMensualDetalle programacionAnualDetalle in programacionAnualDetalles)
                    {
                        programacionAnualDetalle.estado = Estados.Anulado;
                        programacionAnualDetalle.fechaEdita = DateTime.Now;
                        programacionAnualDetalle.usuEdita = usuario;

                        repoProAnuDet.Actualizar(programacionAnualDetalle);
                    }

                    foreach (ReajusteMensualDetalleMes programacionAnualDetalleMes in programacionAnualDetallesMeses)
                    {
                        programacionAnualDetalleMes.estado = Estados.Anulado;
                        programacionAnualDetalleMes.fechaEdita = DateTime.Now;
                        programacionAnualDetalleMes.usuEdita = usuario;

                        repoProAnuDetMes.Actualizar(programacionAnualDetalleMes);
                    }

                    unidadTrabajo.GuardarCambios();

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajusteMensualArea);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajusteMensualArea, ex);
                }
            }
            return resultado;
        }
        public Resultado AnularDetalle(ReajusteMensualDetalle ReajusteMensualDetalle, string usuario)
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

                    ReajusteMensualDetalle.estado = Estados.Anulado;
                    ReajusteMensualDetalle.fechaEdita = DateTime.Now;
                    ReajusteMensualDetalle.usuEdita = usuario;
                    repoProAnuDet.Actualizar(ReajusteMensualDetalle);

                    //IEnumerable<int> IDs = programacionAnualAreas.Select(s => s.idProAnuArea).Distinct();
                    List<ReajusteMensualDetalleMes> programacionAnualDetalles = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReaMenDet == ReajusteMensualDetalle.idReaMenDet && t.estado != Estados.Anulado);
                    List<int> IDAreas = new List<int>();
                    foreach (ReajusteMensualDetalleMes programacionAnualDetalle in programacionAnualDetalles)
                    {
                        programacionAnualDetalle.estado = Estados.Anulado;
                        programacionAnualDetalle.fechaEdita = DateTime.Now;
                        programacionAnualDetalle.usuEdita = usuario;

                        repoProAnuDetMes.Actualizar(programacionAnualDetalle);
                        IDAreas.Add(programacionAnualDetalle.idReaMenAreaMes);
                    }

                    var ProgramacionAnualAreas = repoProAnuAreaMes.TraerVariosPorCondicion(t => IDAreas.Contains(t.idReaMenAreaMes));

                    foreach (var ProgramacionAnualArea in ProgramacionAnualAreas)
                    {
                        List<ReajusteMensualDetalleMes> listaDetArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReaMenAreaMes == ProgramacionAnualArea.idReaMenAreaMes && t.estado != Estados.Anulado);
                        decimal suma = listaDetArea.Sum(s => s.importe);

                        if (ProgramacionAnualArea != null)
                        {
                            ProgramacionAnualArea.importe = suma;
                            repoProAnuAreaMes.Actualizar(ProgramacionAnualArea);
                            unidadTrabajo.GuardarCambios();
                        }
                    }


                    unidadTrabajo.GuardarCambios();

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajusteMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajusteMensualDetalle, ex);
                }
            }
            return resultado;
        }
        public Resultado EliminarArea(ReajusteMensualArea ReajusteMensualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Eliminar(ReajusteMensualArea);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajusteMensualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajusteMensualArea, ex);
            }

            return resultado;
        }
        public Resultado EliminarDetalle(ReajusteMensualDetalle ReajusteMensualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Eliminar(ReajusteMensualDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajusteMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajusteMensualDetalle, ex);
            }

            return resultado;
        }

        public void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion)
        {
            repositorio.GuardarDetalleReajusteRRHH(idProAnu, idReaMenPro, codigos, usuario, indicaEliminacion);
        }
        public void GuardarDetalleRequerimientoMensualEnReajuste(int idReaMenPro, string usuario)
        {
            repositorio.GuardarDetalleRequerimientoMensualEnReajuste(idReaMenPro, usuario);
        }

        public Resultado AsginarSubpresupuesto(List<ReajusteMensualDetallePorMesPres> listaReajusteMensualDetallePorMes, int? idSubpresupuesto, string usuario)
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
                    IUnidadTrabajo unidadTrabajoProAnuDetMes = repoProAnuDetMes.UnidadTrabajo as IUnidadTrabajo;

                    foreach (ReajusteMensualDetallePorMesPres datoDetalle in listaReajusteMensualDetallePorMes)
                    {
                        ReajusteMensualDetalleMes objReajusteMensualDetalleMes = repoProAnuDetMes.TraerPorID(datoDetalle.idReaMenDetMes);

                        objReajusteMensualDetalleMes.idSubpresupuesto = idSubpresupuesto;
                        objReajusteMensualDetalleMes.usuEdita = usuario;
                        objReajusteMensualDetalleMes.fechaEdita = DateTime.Now;

                        repoProAnuDetMes.Actualizar(objReajusteMensualDetalleMes);
                        unidadTrabajoProAnuDetMes.GuardarCambios();
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, listaReajusteMensualDetallePorMes);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, listaReajusteMensualDetallePorMes, ex);
                }
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public ReajusteMensualProgramacion BuscarPorCodigo(int idReajusteMensual)
        {
            return repositorio.TraerPorID(idReajusteMensual);
        }
        public ReajusteMensualArea BuscarPorCodigoArea(int idProAnuArea)
        {
            return repoProAnuArea.TraerPorID(idProAnuArea);
        }
        public ReajusteMensualArea BuscarPorCodigoArea(int idReaMenPro, int idArea, int idCueCon)
        {
            //return repoProAnuArea.TraerPorCondicion(t => t.idArea == idArea && t.idReaMenPro == idReaMenPro && t.idCueCon == idCueCon && t.estado != Estados.Anulado);
            return repositorio.BuscarPorCodigoAreaCuentaContable(idReaMenPro, idArea, idCueCon);
        }

        public ReajusteMensualAreaMes BuscarPorCodigoAreaMes(int idProAnuAreaMes)
        {
            return repoProAnuAreaMes.TraerPorID(idProAnuAreaMes);
        }
        public ReajusteMensualAreaMes BuscarPorCodigoAreaMes(int idReaMenArea, int mes)
        {
            return repoProAnuAreaMes.TraerPorCondicion(t => t.idReaMenArea == idReaMenArea && t.mes == mes && t.estado != 1);
        }

        public decimal BuscarImportePorArea(int idReaMenAreaMes, string descripcion, int idUnidad, decimal precio)
        {
            ReajusteMensualAreaMes reajusteMensualAreaMes = repoProAnuAreaMes.TraerPorID(idReaMenAreaMes);
            decimal importe = 0;
            var proAnuArea = repoProAnuDetMes.TraerVariosPorCondicion(
                    t => t.ReajusteMensualAreaMes.idReaMenAreaMes == idReaMenAreaMes && 
                    t.estado != 1 && 
                    t.ReajusteMensualDetalle.idReaMenArea ==reajusteMensualAreaMes.idReaMenArea &&
                    (!t.ReajusteMensualDetalle.descripcion.Equals(descripcion)&& 
                    t.ReajusteMensualDetalle.idUnidad != idUnidad && 
                    t.ReajusteMensualDetalle.precio != precio));

            if (proAnuArea != null)
            {
                importe = proAnuArea.Sum(s => s.importe);
            }
            return importe;
        }
        public decimal BuscarImportePorArea(int idReaMenAreaMes, int idReaMenDet)
        {
            ReajusteMensualAreaMes reajusteMensualAreaMes = repoProAnuAreaMes.TraerPorID(idReaMenAreaMes);
            decimal importe = 0;
            var proAnuArea = repoProAnuDetMes.TraerVariosPorCondicion(
                    t => t.ReajusteMensualAreaMes.idReaMenAreaMes == idReaMenAreaMes &&
                    t.estado != 1 &&
                    t.ReajusteMensualDetalle.idReaMenArea == reajusteMensualAreaMes.idReaMenArea &&
                    t.ReajusteMensualDetalle.idReaMenDet != idReaMenDet
                    );

            if (proAnuArea != null)
            {
                importe = proAnuArea.Sum(s => s.importe);
            }
            return importe;
        }
        public ReajusteMensualDetalle BuscarPorCodigoDetalle(int idProAnuDet)
        {
            return repoProAnuDet.TraerPorID(idProAnuDet);
        }
        public ReajusteMensualDetalle BuscarPorCodigoDetalle(int idReaMenArea, string descripcion, int idUnidad, decimal precio)
        {
            return repoProAnuDet.TraerPorCondicion(
                t => t.idReaMenArea == idReaMenArea && 
                t.descripcion.Trim().ToUpper().Equals(descripcion.Trim().ToUpper()) && 
                t.idUnidad == idUnidad && 
                t.precio == precio &&
                t.estado != 1);
        }
        public ReajusteMensualDetalleMes BuscarPorCodigoDetalleMes(int idReaMenAreaMes, int idReaMenDet, string descripcion, int idUnidad, decimal precio)
        {
            ReajusteMensualAreaMes reajusteMensualAreaMes = repoProAnuAreaMes.TraerPorID(idReaMenAreaMes);
            return repoProAnuDetMes.TraerPorCondicion(
                    t => t.idReaMenAreaMes == idReaMenAreaMes &&
                    t.ReajusteMensualDetalle.idReaMenArea == reajusteMensualAreaMes.idReaMenArea &&
                    t.ReajusteMensualDetalle.descripcion.Equals(descripcion) &&
                    t.ReajusteMensualDetalle.idUnidad == idUnidad &&
                    t.ReajusteMensualDetalle.precio == precio &&
                    t.ReajusteMensualDetalle.idReaMenDet == idReaMenDet &&
                    t.estado != 1);
        }
        public ReajusteMensualDetalleMes BuscarPorCodigoDetalleMes(int idReaMenDetMes)
        {
            return repoProAnuDetMes.TraerPorCondicion(t => t.idReaMenDetMes == idReaMenDetMes && t.estado != 1);
        }
        public List<ReajusteMensualProgramacion> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<ReajusteMensualPresupuestoPres> TraerListaReajusteMensual(int anio, int mes)
        {
            return repositorio.TraerListaReajusteMensualPresupuesto(anio, mes);
        }
        public List<ReajusteMensualAreaPres> TraerListaReajusteMensualArea(int idProAnu)
        {
            return repoProAnuArea.TraerListaReajusteMensualArea(idProAnu);
        }
        public List<int> TraerListaReajusteMensualAreas(int idReaMenPro)
        {
            return repositorio.TraerListaReajusteMensualAreas(idReaMenPro);
        }
        public List<ReajusteMensualAreaExporta> TraerListaReajusteMensualAreaExporta(int idProAnu)
        {
            return repoProAnuArea.TraerListaReajusteMensualExporta(idProAnu);
        }
        public List<ReporteReajusteMensualExportaPres> TraerReporteReajusteMensualExporta(int idReaMenPro, int idMoneda)
        {
            return repoProAnuArea.TraerReporteReajusteMensualExporta(idReaMenPro, idMoneda);
        }
        public List<ReajusteMensualDetallePres> TraerListaReajusteMensualDetalle(int idProAnuArea)
        {
            return repoProAnuDet.TraerListaReajusteMensualDetalle(idProAnuArea);
        }
        public List<ResumenReajustePresupuestoPorSubdirecciones> TraerResumenReajustePresupuestoPorSubdirecciones(int anio, int idDireccion, int mesReajuste, int mesEvaluacion)
        {
            return repositorio.TraerResumenReajustePresupuestoPorSubdirecciones(anio, idDireccion, mesReajuste, mesEvaluacion);
        }
        public List<CalendarioEvaluacionyAjusteAnual> TraerCalendarioEvaluacionyAjusteAnual(int anio, int idFueFin, int mesAjuste, int mesEval, int idPresupuesto)
        {
            return repositorio.TraerCalendarioEvaluacionyAjusteAnual(anio, idFueFin, mesAjuste, mesEval, idPresupuesto);
        }
        public List<ConsolidadoEvaluacionReajuste> TraerConsolidadoEvaluacionReajustePorDirecciones(int anio, int idFueFin, int mesAjuste, int mesEval)
        {
            return repositorio.TraerConsolidadoEvaluacionReajustePorDirecciones(anio, idFueFin, mesAjuste, mesEval);
        }
        public List<EvaluacionReajustePorSubdireccion> TraerResumenEvaluacionReajustePorSubdirecciones(int anio, int idDireccion, int idGruPre, int mesAjuste, int mesEval)
        {
            return repositorio.TraerResumenEvaluacionReajustePorSubdirecciones(anio, idDireccion, idGruPre, mesAjuste, mesEval);
        }
        public List<ReajusteMensualDetallePorMesPres> TraerListaReajusteMensualDetallePorMes(int idReaMenPro, int mes, int? idSubpresupuesto)
        {
            return repoProAnuDet.TraerListaReajusteMensualDetallePorMes(idReaMenPro, mes, idSubpresupuesto).ToList();
        }

        #endregion

    }
}

