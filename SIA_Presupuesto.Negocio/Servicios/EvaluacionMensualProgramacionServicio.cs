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
    public class EvaluacionMensualProgramacionServicio : ServicioBase, IEvaluacionMensualProgramacionServicio
    {
        IEvaluacionMensualProgramacionRepositorio repositorio;
        IEvaluacionMensualAreaRepositorio repoProAnuArea;
        IEvaluacionMensualAreaMesRepositorio repoProAnuAreaMes;
        IEvaluacionMensualDetalleRepositorio repoProAnuDet;
        IEvaluacionMensualDetalleMesRepositorio repoProAnuDetMes;
        IEvaluacionMensualProgramacionPresRepositorio reporevaMenProPres;
        IProgramacionAnualRepositorio repoProAnu;

        public EvaluacionMensualProgramacionServicio(IEvaluacionMensualProgramacionRepositorio repositorio, IEvaluacionMensualAreaRepositorio repoProAnuArea,
            IEvaluacionMensualDetalleRepositorio repoProAnuDet, IEvaluacionMensualAreaMesRepositorio repoProAnuAreaMes, IEvaluacionMensualDetalleMesRepositorio repoProAnuDetMes,
            IEvaluacionMensualProgramacionPresRepositorio reporevaMenProPres, IProgramacionAnualRepositorio repoProAnu)
        {
            this.repositorio = repositorio;
            this.repoProAnuArea = repoProAnuArea;
            this.repoProAnuDet = repoProAnuDet;
            this.repoProAnuAreaMes = repoProAnuAreaMes;
            this.repoProAnuDetMes = repoProAnuDetMes;
            this.reporevaMenProPres = reporevaMenProPres;
            this.repoProAnu = repoProAnu;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private EvaluacionMensualProgramacion Clonar(EvaluacionMensualProgramacion EvaluacionMensual1)
        {
            return new EvaluacionMensualProgramacion
            {
                idEvaMenPro = EvaluacionMensual1.idEvaMenPro,
                idProAnu = EvaluacionMensual1.idProAnu,
                descripcion = EvaluacionMensual1.descripcion,
                estado = EvaluacionMensual1.estado,
                fechaAprobacion = EvaluacionMensual1.fechaAprobacion,
                fechaCrea = EvaluacionMensual1.fechaCrea,
                fechaEdita = EvaluacionMensual1.fechaEdita,
                fechaEmision = EvaluacionMensual1.fechaEmision,
                mesDesde = EvaluacionMensual1.mesDesde,
                mesHasta = EvaluacionMensual1.mesHasta,
                tipoCambio = EvaluacionMensual1.tipoCambio,
                usuCrea = EvaluacionMensual1.usuCrea,
                usuEdita = EvaluacionMensual1.usuEdita
            };
        }

        private EvaluacionMensualArea Clonar(EvaluacionMensualArea EvaluacionMensualArea1)
        {
            return new EvaluacionMensualArea
            {
                idEvaMenArea = EvaluacionMensualArea1.idEvaMenArea,
                idEvaMenPro = EvaluacionMensualArea1.idEvaMenPro,
                idArea = EvaluacionMensualArea1.idArea,
                idCueCon = EvaluacionMensualArea1.idCueCon,
                estado = EvaluacionMensualArea1.estado,
                fechaCrea = EvaluacionMensualArea1.fechaCrea,
                fechaEdita = EvaluacionMensualArea1.fechaEdita,
                usuCrea = EvaluacionMensualArea1.usuCrea,
                usuEdita = EvaluacionMensualArea1.usuEdita
            };
        }

        private EvaluacionMensualAreaMes Clonar(EvaluacionMensualAreaMes EvaluacionMensualAreaMes1)
        {
            return new EvaluacionMensualAreaMes
            {
                idEvaMenArea = EvaluacionMensualAreaMes1.idEvaMenArea,
                idEvaMenAreaMes = EvaluacionMensualAreaMes1.idEvaMenAreaMes,
                estado = EvaluacionMensualAreaMes1.estado,
                fechaCrea = EvaluacionMensualAreaMes1.fechaCrea,
                fechaEdita = EvaluacionMensualAreaMes1.fechaEdita,
                usuCrea = EvaluacionMensualAreaMes1.usuCrea,
                usuEdita = EvaluacionMensualAreaMes1.usuEdita,
                importe = EvaluacionMensualAreaMes1.importe,
                mes = EvaluacionMensualAreaMes1.mes,
            };
        }

        private EvaluacionMensualDetalleMes Clonar(EvaluacionMensualDetalleMes EvaluacionMensualAreaMes1)
        {
            return new EvaluacionMensualDetalleMes
            {
                idEvaMenProDet = EvaluacionMensualAreaMes1.idEvaMenProDet,
                idEvaMenProDetMes = EvaluacionMensualAreaMes1.idEvaMenProDetMes,
                idEvaMenAreaMes = EvaluacionMensualAreaMes1.idEvaMenAreaMes,
                estado = EvaluacionMensualAreaMes1.estado,
                fechaCrea = EvaluacionMensualAreaMes1.fechaCrea,
                fechaEdita = EvaluacionMensualAreaMes1.fechaEdita,
                usuCrea = EvaluacionMensualAreaMes1.usuCrea,
                usuEdita = EvaluacionMensualAreaMes1.usuEdita,
                cantidad = EvaluacionMensualAreaMes1.cantidad,
                dias = EvaluacionMensualAreaMes1.dias,
                importe = EvaluacionMensualAreaMes1.importe,
            };
        }

        private EvaluacionMensualDetalle Clonar(EvaluacionMensualDetalle EvaluacionMensualDetalle1)
        {
            return new EvaluacionMensualDetalle
            {
                idEvaMenProDet = EvaluacionMensualDetalle1.idEvaMenProDet,
                idEvaMenProArea = EvaluacionMensualDetalle1.idEvaMenProArea,
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

        


        public Resultado Nuevo(EvaluacionMensualProgramacion EvaluacionMensual)
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
                    repositorio.Agregar(EvaluacionMensual);
                    unidadTrabajo.GuardarCambios();

                    ProgramacionAnual programacion = repoProAnu.TraerPorID(EvaluacionMensual.idProAnu);

                    string codigos = string.Empty;

                    codigos = programacion.idProAnu.ToString() + "~2";

                    repositorio.GuardarFondoEjecutado(EvaluacionMensual.idEvaMenPro, EvaluacionMensual.usuCrea,
                    programacion.idMoneda, programacion.anio, EvaluacionMensual.mesDesde, EvaluacionMensual.mesHasta, codigos);

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EvaluacionMensual);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, EvaluacionMensual, ex);
                }
            }
            return resultado;
        }

        public Resultado NuevoArea(EvaluacionMensualArea EvaluacionMensualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Agregar(EvaluacionMensualArea);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EvaluacionMensualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, EvaluacionMensualArea, ex);
            }

            return resultado;
        }

        public Resultado NuevoAreaMes(EvaluacionMensualAreaMes EvaluacionMensualAreaMes)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuAreaMes.Agregar(EvaluacionMensualAreaMes);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EvaluacionMensualAreaMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, EvaluacionMensualAreaMes, ex);
            }

            return resultado;
        }

        public Resultado NuevoDetalle(EvaluacionMensualDetalle EvaluacionMensualDetalle, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Agregar(EvaluacionMensualDetalle);
                unidadTrabajo.GuardarCambios();

                //if (actualizaArea)
                //{
                //    var EvaluacionMensualAreaMes = repoProAnuAreaMes.TraerPorID((Int32)EvaluacionMensualDetalle.idProAnuAreaMes);

                //    List<EvaluacionMensualDetalle> lista = repoProAnuDet.TraerVariosPorCondicion(t => t.idProAnuAreaMes == EvaluacionMensualDetalle.idProAnuAreaMes && t.estado != Estados.Anulado);
                //    decimal suma = lista.Sum(s => s.importe);

                //    if (EvaluacionMensualAreaMes != null)
                //    {
                //        EvaluacionMensualAreaMes.importe = suma;
                //        repoProAnuAreaMes.Actualizar(EvaluacionMensualAreaMes);
                //        unidadTrabajo.GuardarCambios();
                //    }
                //}

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EvaluacionMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, EvaluacionMensualDetalle, ex);
            }

            return resultado;
        }

        public Resultado NuevoDetalleMes(EvaluacionMensualDetalleMes EvaluacionMensualDetalle, bool actualizaArea)
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
                    repoProAnuDetMes.Agregar(Clonar(EvaluacionMensualDetalle));
                    unidadTrabajo.GuardarCambios();

                    if (actualizaArea)
                    {
                        var EvaluacionMensualAreaMes = repoProAnuAreaMes.TraerPorID((Int32)EvaluacionMensualDetalle.idEvaMenAreaMes);

                        List<EvaluacionMensualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idEvaMenAreaMes == EvaluacionMensualDetalle.idEvaMenAreaMes && t.estado != Estados.Anulado);
                        decimal suma = lista.Sum(s => s.importe);

                        if (EvaluacionMensualAreaMes != null)
                        {
                            EvaluacionMensualAreaMes.importe = suma;
                            repoProAnuAreaMes.Actualizar(EvaluacionMensualAreaMes);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, EvaluacionMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, EvaluacionMensualDetalle, ex);
                }
            }
            return resultado;
        }

        public Resultado Modificar(EvaluacionMensualProgramacion EvaluacionMensual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;


                repositorio.Actualizar(Clonar(EvaluacionMensual));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EvaluacionMensual, ex);
            }

            return resultado;
        }

        public Resultado ModificarAreas(EvaluacionMensualArea EvaluacionMensualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Actualizar(Clonar(EvaluacionMensualArea));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EvaluacionMensualArea, ex);
            }

            return resultado;
        }

        public Resultado ModificarAreasMes(EvaluacionMensualAreaMes EvaluacionMensualAreaMes)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuAreaMes.Actualizar(EvaluacionMensualAreaMes);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensualAreaMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EvaluacionMensualAreaMes, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetalles(EvaluacionMensualDetalle EvaluacionMensualDetalle)
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

                    repoProAnuDet.Actualizar(Clonar(EvaluacionMensualDetalle));
                    unidadTrabajo.GuardarCambios();
                    //resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensualDetalle);


                    List<EvaluacionMensualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idEvaMenProDet == EvaluacionMensualDetalle.idEvaMenProDet && t.estado != Estados.Anulado);
                    List<int> IDAreas = new List<int>();
                    foreach (var item in lista)
                    {
                        item.importe = Math.Round(item.cantidad * EvaluacionMensualDetalle.precio, 2);
                        repoProAnuDetMes.Actualizar(item);
                        unidadTrabajo.GuardarCambios();
                        IDAreas.Add(item.idEvaMenAreaMes);
                    }

                    var ProgramacionAnualAreas = repoProAnuAreaMes.TraerVariosPorCondicion(t => IDAreas.Contains(t.idEvaMenAreaMes));

                    foreach (var ProgramacionAnualArea in ProgramacionAnualAreas)
                    {
                        List<EvaluacionMensualDetalleMes> listaDetArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idEvaMenAreaMes == ProgramacionAnualArea.idEvaMenAreaMes && t.estado != Estados.Anulado);
                        decimal suma = listaDetArea.Sum(s => s.importe);

                        if (ProgramacionAnualArea != null)
                        {
                            ProgramacionAnualArea.importe = suma;
                            repoProAnuAreaMes.Actualizar(ProgramacionAnualArea);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EvaluacionMensualDetalle, ex);
                }
            }
            return resultado;
        }

        public Resultado ModificarDetallesMes(EvaluacionMensualDetalleMes EvaluacionMensualDetalle, bool actualizaArea)
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

                    repoProAnuDetMes.Actualizar(EvaluacionMensualDetalle);
                    unidadTrabajo.GuardarCambios();
                    //resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensualDetalle);

                    if (actualizaArea)
                    {
                        var EvaluacionMensualArea = repoProAnuAreaMes.TraerPorID((Int32)EvaluacionMensualDetalle.idEvaMenAreaMes);

                        List<EvaluacionMensualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idEvaMenAreaMes == EvaluacionMensualDetalle.idEvaMenAreaMes && t.EvaluacionMensualDetalle.idEvaMenProArea == EvaluacionMensualArea.idEvaMenArea && t.estado != Estados.Anulado);
                        decimal suma = lista.Sum(s => s.importe);

                        if (EvaluacionMensualArea != null)
                        {
                            EvaluacionMensualArea.importe = suma;
                            repoProAnuAreaMes.Actualizar(EvaluacionMensualArea);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, EvaluacionMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Modificacion, EvaluacionMensualDetalle, ex);
                }
            }
            return resultado;
        }

        public Resultado Eliminar(EvaluacionMensualProgramacion EvaluacionMensual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(EvaluacionMensual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EvaluacionMensual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EvaluacionMensual, ex);
            }

            return resultado;
        }

        public Resultado Anular(EvaluacionMensualProgramacion EvaluacionMensual, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                EvaluacionMensual.estado = Estados.Anulado;
                EvaluacionMensual.fechaEdita = DateTime.Now;
                EvaluacionMensual.usuEdita = usuario;

                repositorio.Actualizar(EvaluacionMensual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EvaluacionMensual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EvaluacionMensual, ex);
            }

            return resultado;
        }

        public Resultado AnularArea(EvaluacionMensualArea EvaluacionMensualArea, string usuario)
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


                    List<EvaluacionMensualAreaMes> programacionAnualAreas =
                        repoProAnuAreaMes.TraerVariosPorCondicion(t => t.idEvaMenArea == EvaluacionMensualArea.idEvaMenArea && t.estado != 1);


                    List<EvaluacionMensualDetalle> programacionAnualDetalles =
                        repoProAnuDet.TraerVariosPorCondicion(t => t.idEvaMenProArea == EvaluacionMensualArea.idEvaMenArea && t.estado != 1);

                    IEnumerable<int> IDs = programacionAnualDetalles.Select(s => s.idEvaMenProDet).Distinct();

                    List<EvaluacionMensualDetalleMes> programacionAnualDetallesMeses =
                        repoProAnuDetMes.TraerVariosPorCondicion(t => IDs.Contains((Int32)t.idEvaMenProDet) && t.estado != 1);

                    EvaluacionMensualArea.estado = Estados.Anulado;
                    EvaluacionMensualArea.fechaEdita = DateTime.Now;
                    EvaluacionMensualArea.usuEdita = usuario;

                    repoProAnuArea.Actualizar(EvaluacionMensualArea);

                    foreach (EvaluacionMensualAreaMes programacionAnualArea in programacionAnualAreas)
                    {
                        programacionAnualArea.estado = Estados.Anulado;
                        programacionAnualArea.fechaEdita = DateTime.Now;
                        programacionAnualArea.usuEdita = usuario;

                        repoProAnuAreaMes.Actualizar(programacionAnualArea);
                    }

                    foreach (EvaluacionMensualDetalle programacionAnualDetalle in programacionAnualDetalles)
                    {
                        programacionAnualDetalle.estado = Estados.Anulado;
                        programacionAnualDetalle.fechaEdita = DateTime.Now;
                        programacionAnualDetalle.usuEdita = usuario;

                        repoProAnuDet.Actualizar(programacionAnualDetalle);
                    }

                    foreach (EvaluacionMensualDetalleMes programacionAnualDetalleMes in programacionAnualDetallesMeses)
                    {
                        programacionAnualDetalleMes.estado = Estados.Anulado;
                        programacionAnualDetalleMes.fechaEdita = DateTime.Now;
                        programacionAnualDetalleMes.usuEdita = usuario;

                        repoProAnuDetMes.Actualizar(programacionAnualDetalleMes);
                    }

                    unidadTrabajo.GuardarCambios();

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EvaluacionMensualArea);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EvaluacionMensualArea, ex);
                }
            }
            return resultado;
        }

        public Resultado AnularDetalle(EvaluacionMensualDetalle EvaluacionMensualDetalle, string usuario)
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

                    EvaluacionMensualDetalle.estado = Estados.Anulado;
                    EvaluacionMensualDetalle.fechaEdita = DateTime.Now;
                    EvaluacionMensualDetalle.usuEdita = usuario;
                    repoProAnuDet.Actualizar(EvaluacionMensualDetalle);

                    //IEnumerable<int> IDs = programacionAnualAreas.Select(s => s.idProAnuArea).Distinct();
                    List<EvaluacionMensualDetalleMes> programacionAnualDetalles = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idEvaMenProDet == EvaluacionMensualDetalle.idEvaMenProDet && t.estado != Estados.Anulado);
                    List<int> IDAreas = new List<int>();
                    foreach (EvaluacionMensualDetalleMes programacionAnualDetalle in programacionAnualDetalles)
                    {
                        programacionAnualDetalle.estado = Estados.Anulado;
                        programacionAnualDetalle.fechaEdita = DateTime.Now;
                        programacionAnualDetalle.usuEdita = usuario;

                        repoProAnuDetMes.Actualizar(programacionAnualDetalle);
                        IDAreas.Add(programacionAnualDetalle.idEvaMenAreaMes);
                    }

                    unidadTrabajo.GuardarCambios();

                    var ProgramacionAnualAreas = repoProAnuAreaMes.TraerVariosPorCondicion(t => IDAreas.Contains(t.idEvaMenAreaMes));

                    foreach (var ProgramacionAnualArea in ProgramacionAnualAreas)
                    {
                        List<EvaluacionMensualDetalleMes> listaDetArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idEvaMenAreaMes == ProgramacionAnualArea.idEvaMenAreaMes && t.estado != Estados.Anulado);
                        decimal suma = listaDetArea.Sum(s => s.importe);

                        if (ProgramacionAnualArea != null)
                        {
                            ProgramacionAnualArea.importe = suma;
                            repoProAnuAreaMes.Actualizar(ProgramacionAnualArea);
                            unidadTrabajo.GuardarCambios();
                        }
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EvaluacionMensualDetalle);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EvaluacionMensualDetalle, ex);
                }
            }
            return resultado;
        }

        public Resultado EliminarArea(EvaluacionMensualArea EvaluacionMensualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Eliminar(EvaluacionMensualArea);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EvaluacionMensualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EvaluacionMensualArea, ex);
            }

            return resultado;
        }

        public Resultado EliminarDetalle(EvaluacionMensualDetalle EvaluacionMensualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Eliminar(EvaluacionMensualDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, EvaluacionMensualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, EvaluacionMensualDetalle, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public EvaluacionMensualProgramacion BuscarPorCodigo(int idEvaluacionMensual)
        {
            return repositorio.TraerPorID(idEvaluacionMensual);
        }

        public EvaluacionMensualArea BuscarPorCodigoArea(int idProAnuArea)
        {
            return repoProAnuArea.TraerPorID(idProAnuArea);
        }

        public EvaluacionMensualArea BuscarPorCodigoArea(int idEvaMenPro, int idArea, int idCueCon)
        {
            return repoProAnuArea.TraerPorCondicion(t => t.idArea == idArea && t.idEvaMenPro == idEvaMenPro && t.idCueCon == idCueCon && t.estado != Estados.Anulado);
        }

        public EvaluacionMensualArea BuscarEvaluacionMensualAreaPorCuenta(int idEvaMenPro, int idCueCon)
        {
            return repoProAnuArea.TraerPorCondicion(t => t.idEvaMenPro == idEvaMenPro && t.idCueCon == idCueCon && t.estado != Estados.Anulado);
        }

        public EvaluacionMensualAreaMes BuscarPorCodigoAreaMes(int idProAnuAreaMes)
        {
            return repoProAnuAreaMes.TraerPorID(idProAnuAreaMes);
        }

        public EvaluacionMensualAreaMes BuscarPorCodigoAreaMes(int idEvaMenArea, int mes)
        {
            return repoProAnuAreaMes.TraerPorCondicion(t => t.idEvaMenArea == idEvaMenArea && t.mes == mes && t.estado!=1);
        }

        public decimal BuscarImportePorArea(int idEvaMenAreaMes, string descripcion, int idUnidad, decimal precio)
        {
            EvaluacionMensualAreaMes evaluacionMensualAreaMes = repoProAnuAreaMes.TraerPorID(idEvaMenAreaMes);
            decimal importe = 0;
            var proAnuArea = repoProAnuDetMes.TraerVariosPorCondicion(
                t => t.EvaluacionMensualAreaMes.idEvaMenAreaMes == idEvaMenAreaMes && 
                t.estado != 1 &&
                t.EvaluacionMensualDetalle.idEvaMenProArea == evaluacionMensualAreaMes.idEvaMenArea &&
                (!t.EvaluacionMensualDetalle.descripcion.Equals(descripcion) && 
                t.EvaluacionMensualDetalle.idUnidad != idUnidad && 
                t.EvaluacionMensualDetalle.precio != precio));

            if (proAnuArea != null)
            {
                importe = proAnuArea.Sum(s => s.importe);
            }
            return importe;
        }

        public decimal BuscarImportePorArea(int idEvaMenAreaMes, int idEvaMenProDet)
        {
            EvaluacionMensualAreaMes evaluacionMensualAreaMes = repoProAnuAreaMes.TraerPorID(idEvaMenAreaMes);
            decimal importe = 0;
            var proAnuArea = repoProAnuDetMes.TraerVariosPorCondicion(
                t => t.EvaluacionMensualAreaMes.idEvaMenAreaMes == idEvaMenAreaMes &&
                t.estado != 1 &&
                t.EvaluacionMensualDetalle.idEvaMenProArea == evaluacionMensualAreaMes.idEvaMenArea &&
                t.EvaluacionMensualDetalle.idEvaMenProDet != idEvaMenProDet
            );

            if (proAnuArea != null)
            {
                importe = proAnuArea.Sum(s => s.importe);
            }
            return importe;
        }

        public EvaluacionMensualDetalle BuscarPorCodigoDetalle(int idProAnuDet)
        {
            return repoProAnuDet.TraerPorID(idProAnuDet);
        }

        public EvaluacionMensualDetalle BuscarPorCodigoDetalle(int idEvaMenProArea, string descripcion, int idUnidad, decimal precio)
        {
            return repoProAnuDet.TraerPorCondicion(
                t => t.idEvaMenProArea == idEvaMenProArea &&
                t.descripcion.Equals(descripcion) &&
                t.idUnidad == idUnidad &&
                t.precio == precio &&
                t.estado != 1);
        }

        public EvaluacionMensualDetalleMes BuscarPorCodigoDetalleMes(int idEvaMenAreaMes, string descripcion, int idUnidad, decimal precio)
        {
            EvaluacionMensualAreaMes evaluacionMensualAreaMes = repoProAnuAreaMes.TraerPorID(idEvaMenAreaMes);
            return repoProAnuDetMes.TraerPorCondicion(
                    t => t.idEvaMenAreaMes == idEvaMenAreaMes &&
                    t.EvaluacionMensualDetalle.idEvaMenProArea == evaluacionMensualAreaMes.idEvaMenArea &&
                    t.EvaluacionMensualDetalle.descripcion.Equals(descripcion) && 
                    t.EvaluacionMensualDetalle.idUnidad == idUnidad && 
                    t.EvaluacionMensualDetalle.precio == precio &&
                    t.estado != 1);
        }
        public EvaluacionMensualDetalleMes BuscarPorCodigoDetalleMes(int idEvaMenAreaMes, int idEvaMenProDet)
        {
            EvaluacionMensualAreaMes evaluacionMensualAreaMes = repoProAnuAreaMes.TraerPorID(idEvaMenAreaMes);
            return repoProAnuDetMes.TraerPorCondicion(
                    t => t.idEvaMenAreaMes == idEvaMenAreaMes &&
                    t.EvaluacionMensualDetalle.idEvaMenProArea == evaluacionMensualAreaMes.idEvaMenArea &&
                    t.EvaluacionMensualDetalle.idEvaMenProDet == idEvaMenProDet &&
                    t.estado != 1);
        }

        public List<EvaluacionMensualProgramacion> listarTodos()
        {
            return repositorio.TraerTodos();
        }

        public List<EvaluacionMensualPresupuestoPres> TraerListaEvaluacionMensual(int anio, int mes)
        {
            return repositorio.TraerListaEvaluacionMensualPresupuesto(anio, mes);
        }

        public List<EvaluacionMensualAreaPres> TraerListaEvaluacionMensualArea(int idProAnu)
        {
            return repoProAnuArea.TraerListaEvaluacionMensualArea(idProAnu);
        }

        public List<EvaluacionMensualAreaExporta> TraerListaEvaluacionMensualAreaExporta(int idProAnu)
        {
            return repoProAnuArea.TraerListaEvaluacionMensualExporta(idProAnu);
        }

        public List<EvaluacionMensualDetallePres> TraerListaEvaluacionMensualDetalle(int idProAnuArea)
        {
            return repoProAnuDet.TraerListaEvaluacionMensualDetalle(idProAnuArea);
        }

        public List<FondoEjecutado> TraerFondoEjecutado(int idMoneda, int anio, int mesInicio, int mesFin, string codigoPres)
        {
            return repositorio.TraerFondoEjecutado(idMoneda, anio, mesInicio, mesFin, codigoPres);
        }

        public List<ResumenEvaFinanCorahSaal> TraerResumenEvaFinanCorahSaal(int idTipRep, int anio, int mes)
        {
            return repositorio.TraerResumenEvaFinanCorahSaal(idTipRep, anio, mes);
        }

        public List<FondoEjecutadosSubpresupuesto> TraerFondoEjecutadosSubpresupuesto(int idMoneda, int idGruPre, int idPresupuesto, int idSubpresupuesto)
        {
            return repositorio.TraerFondoEjecutadosSubpresupuesto(idMoneda, idGruPre, idPresupuesto, idSubpresupuesto);
        }

        public List<FondoEjecutadoFecha> TraerFondoEjecutadosFechas(int idMoneda, int idGruPre, int idPresupuesto, DateTime fechaDesde, DateTime fechaHasta)
        {
            return repositorio.TraerFondoEjecutadosFechas(idMoneda, idGruPre, idPresupuesto, fechaDesde, fechaHasta);
        }

        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(int idProAnu, int anio, int mesRea, int mesEva)
        {
            return repoProAnuArea.TraerListaEvaluacionReajusteMensualAreaExporta(idProAnu, anio, mesRea, mesEva);
        }

        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(string idsProAnu, int anio, int mesRea, int mesEva)
        {
            return repoProAnuArea.TraerListaEvaluacionReajusteMensualAreaExporta(idsProAnu, anio, mesRea, mesEva);
        }


        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta2(int idProAnu, int anio, int mesRea, int mesEva)
        {
            return repoProAnuArea.TraerListaEvaluacionReajusteMensualAreaExporta2(idProAnu, anio, mesRea, mesEva);
        }
        public List<ReporteEvaluacionMensualExportaPres> TraerReporteEvaluacionMensualExporta(int idEvaMenPro, int idMoneda)
        {
            return repoProAnuArea.TraerReporteEvaluacionMensualExporta(idEvaMenPro, idMoneda);
        }
        public List<ReporteEvaluacionReajusteMensualExportaPres> TraerReporteEvaluacionReajusteMensualExporta(int idProAnu, int anio, int mesRea, int mesEva, int idMoneda)
        {
            return repoProAnuArea.TraerReporteEvaluacionReajusteMensualExporta(idProAnu, anio, mesRea, mesEva, idMoneda);
        }

        #endregion
    }
}
