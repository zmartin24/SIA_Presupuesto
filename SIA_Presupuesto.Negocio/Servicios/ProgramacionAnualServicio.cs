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
    public class ProgramacionAnualServicio : ServicioBase, IProgramacionAnualServicio
    {
        IProgramacionAnualRepositorio repositorio;
        IProgramacionAnualAreaRepositorio repoProAnuArea;
        IProgramacionAnualAreaMesRepositorio repoProAnuAreaMes;
        IProgramacionAnualDetalleRepositorio repoProAnuDet;
        IProgramacionAnualDetalleMesRepositorio repoProAnuDetMes;
        IProgramacionAnualSedeRepositorio repoSede;
        IProgramacionAnualEjeOperativoRepositorio repoEjeOpe;

        public ProgramacionAnualServicio(IProgramacionAnualRepositorio repositorio, IProgramacionAnualAreaRepositorio repoProAnuArea, 
            IProgramacionAnualDetalleRepositorio repoProAnuDet, IProgramacionAnualAreaMesRepositorio repoProAnuAreaMes, 
            IProgramacionAnualDetalleMesRepositorio repoProAnuDetMes, IProgramacionAnualSedeRepositorio repoSede, IProgramacionAnualEjeOperativoRepositorio repoEjeOpe)
        {
            this.repositorio = repositorio;
            this.repoProAnuArea = repoProAnuArea;
            this.repoProAnuDet = repoProAnuDet;
            this.repoProAnuAreaMes = repoProAnuAreaMes;
            this.repoProAnuDetMes = repoProAnuDetMes;
            this.repoSede = repoSede;
            this.repoEjeOpe = repoEjeOpe;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private ProgramacionAnual Clonar(ProgramacionAnual ProgramacionAnual1)
        {
            return new ProgramacionAnual
            {
                idMoneda = ProgramacionAnual1.idMoneda,
                idProAnu = ProgramacionAnual1.idProAnu,
                anio = ProgramacionAnual1.anio,
                descripcion = ProgramacionAnual1.descripcion,
                titulo = ProgramacionAnual1.titulo,
                idGruPre = ProgramacionAnual1.idGruPre,
                idFueFin = ProgramacionAnual1.idFueFin,
                esSaldo = ProgramacionAnual1.esSaldo,
                estado = ProgramacionAnual1.estado,
                fechaAprobacion = ProgramacionAnual1.fechaAprobacion,
                fechaCrea = ProgramacionAnual1.fechaCrea,
                fechaEdita = ProgramacionAnual1.fechaEdita,
                fechaEmision = ProgramacionAnual1.fechaEmision,
                fechaLiquidacion = ProgramacionAnual1.fechaLiquidacion,
                tipo = ProgramacionAnual1.tipo,
                usuCrea = ProgramacionAnual1.usuCrea,
                usuEdita = ProgramacionAnual1.usuEdita,
                idModalidad = ProgramacionAnual1.idModalidad,
                idTipoActividad = ProgramacionAnual1.idTipoActividad,
                nroTransferencia = ProgramacionAnual1.nroTransferencia,
                idPoaVersion = ProgramacionAnual1.idPoaVersion,
                costoxHa = ProgramacionAnual1.costoxHa,
                denominacion = ProgramacionAnual1.denominacion,
                metaHa = ProgramacionAnual1.metaHa,
                observacion = ProgramacionAnual1.observacion,
            };
        }

        private ProgramacionAnualArea Clonar(ProgramacionAnualArea ProgramacionAnualArea1)
        {
            return new ProgramacionAnualArea
            {
                idProAnuArea = ProgramacionAnualArea1.idProAnuArea,
                idProAnu = ProgramacionAnualArea1.idProAnu,
                idArea = ProgramacionAnualArea1.idArea,
                idCueCon = ProgramacionAnualArea1.idCueCon,
                idUnidad = ProgramacionAnualArea1.idUnidad,
                estado = ProgramacionAnualArea1.estado,
                fechaCrea = ProgramacionAnualArea1.fechaCrea,
                fechaEdita = ProgramacionAnualArea1.fechaEdita,
                usuCrea = ProgramacionAnualArea1.usuCrea,
                usuEdita = ProgramacionAnualArea1.usuEdita
            };
        }

        private ProgramacionAnualAreaMes Clonar(ProgramacionAnualAreaMes ProgramacionAnualAreaMes1)
        {
            return new ProgramacionAnualAreaMes
            {
                idProAnuArea = ProgramacionAnualAreaMes1.idProAnuArea,
                idProAnuAreaMes = ProgramacionAnualAreaMes1.idProAnuAreaMes,
                estado = ProgramacionAnualAreaMes1.estado,
                fechaCrea = ProgramacionAnualAreaMes1.fechaCrea,
                fechaEdita = ProgramacionAnualAreaMes1.fechaEdita,
                usuCrea = ProgramacionAnualAreaMes1.usuCrea,
                usuEdita = ProgramacionAnualAreaMes1.usuEdita,
                importe = ProgramacionAnualAreaMes1.importe,
                mes = ProgramacionAnualAreaMes1.mes
            };
        }

        private ProgramacionAnualDetalle Clonar(ProgramacionAnualDetalle ProgramacionAnualDetalle)
        {
            return new ProgramacionAnualDetalle
            {
                idProAnuArea = ProgramacionAnualDetalle.idProAnuArea,
                idProAnuDet = ProgramacionAnualDetalle.idProAnuDet,
                idProducto = ProgramacionAnualDetalle.idProducto,
                idUnidad = ProgramacionAnualDetalle.idUnidad,
                descripcion = ProgramacionAnualDetalle.descripcion,
                precio = ProgramacionAnualDetalle.precio,
                justificacion = ProgramacionAnualDetalle.justificacion,
                fechaCrea = ProgramacionAnualDetalle.fechaCrea,
                fechaEdita = ProgramacionAnualDetalle.fechaEdita,
                usuCrea = ProgramacionAnualDetalle.usuCrea,
                usuEdita = ProgramacionAnualDetalle.usuEdita,
                estado = ProgramacionAnualDetalle.estado
            };
        }

        public Resultado Nuevo(ProgramacionAnual ProgramacionAnual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(ProgramacionAnual);
                unidadTrabajo.GuardarCambios();

                foreach(var sede in ProgramacionAnual.listaSedes)
                {
                    if(sede.operacion.Equals("N"))
                    {
                        repoSede.Agregar(new ProgramacionAnualSede
                        {
                            idSede = sede.idSede,
                            idProAnu = ProgramacionAnual.idProAnu,
                            observacion = sede.observacion,
                            estado = 2,
                            usuCrea = ProgramacionAnual.usuCrea,
                            fechaCrea = DateTime.Now,
                        });
                        unidadTrabajo.GuardarCambios();
                    }
                }

                foreach (var ejeOpe in ProgramacionAnual.listaEjeOperativos)
                {
                    if (ejeOpe.operacion.Equals("N"))
                    {
                        repoEjeOpe.Agregar(new ProgramacionAnualEjeOperativo
                        {
                            idEjeOpe = ejeOpe.idEjeOpe,
                            idProAnu = ProgramacionAnual.idProAnu,
                            observacion = ejeOpe.observacion,
                            estado = 2,
                            usuCrea = ProgramacionAnual.usuCrea,
                            fechaCrea = DateTime.Now,
                        });
                        unidadTrabajo.GuardarCambios();
                    }
                }



                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ProgramacionAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ProgramacionAnual, ex);
            }

            return resultado;
        }

        public Resultado NuevoArea(ProgramacionAnualArea ProgramacionAnualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Agregar(ProgramacionAnualArea);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ProgramacionAnualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ProgramacionAnualArea, ex);
            }

            return resultado;
        }

        public Resultado NuevoAreaMes(ProgramacionAnualAreaMes ProgramacionAnualAreaMes)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuAreaMes.Agregar(ProgramacionAnualAreaMes);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ProgramacionAnualAreaMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ProgramacionAnualAreaMes, ex);
            }

            return resultado;
        }

        public Resultado NuevoDetalle(ProgramacionAnualDetalle ProgramacionAnualDetalle, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Agregar(ProgramacionAnualDetalle);
                unidadTrabajo.GuardarCambios();

                //if (actualizaArea)
                //{
                //    var ProgramacionAnualAreaMes = repoProAnuAreaMes.TraerPorID((Int32)ProgramacionAnualDetalle.idProAnuAreaMes);

                //    List<ProgramacionAnualDetalle> lista = repoProAnuDet.TraerVariosPorCondicion(t => t.idProAnuAreaMes == ProgramacionAnualDetalle.idProAnuAreaMes && t.estado != Estados.Anulado);
                //    decimal suma = lista.Sum(s => s.importe);

                //    if (ProgramacionAnualAreaMes != null)
                //    {
                //        ProgramacionAnualAreaMes.importe = suma;
                //        repoProAnuAreaMes.Actualizar(ProgramacionAnualAreaMes);
                //        unidadTrabajo.GuardarCambios();
                //    }
                //}

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ProgramacionAnualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ProgramacionAnualDetalle, ex);
            }

            return resultado;
        }

        public Resultado NuevoDetalleMes(ProgramacionAnualDetalleMes ProgramacionAnualDetalle, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDetMes.Agregar(ProgramacionAnualDetalle);
                unidadTrabajo.GuardarCambios();

                if (actualizaArea)
                {
                    var ProgramacionAnualAreaMes = repoProAnuAreaMes.TraerPorID((Int32)ProgramacionAnualDetalle.idProAnuAreaMes);

                    List<ProgramacionAnualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idProAnuAreaMes == ProgramacionAnualDetalle.idProAnuAreaMes && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.importe);

                    if (ProgramacionAnualAreaMes != null)
                    {
                        ProgramacionAnualAreaMes.importe = suma;
                        repoProAnuAreaMes.Actualizar(ProgramacionAnualAreaMes);
                        unidadTrabajo.GuardarCambios();
                    }
                }

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ProgramacionAnualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ProgramacionAnualDetalle, ex);
            }

            return resultado;
        }

        public Resultado Modificar(ProgramacionAnual ProgramacionAnual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(ProgramacionAnual));
                unidadTrabajo.GuardarCambios();

                List<ProgramacionAnualSede> listaSedes = repoSede.TraerVariosPorCondicion(t => t.idProAnu == ProgramacionAnual.idProAnu && t.estado != 1);
                List<ProgramacionAnualEjeOperativo> listaEje = repoEjeOpe.TraerVariosPorCondicion(t => t.idProAnu == ProgramacionAnual.idProAnu && t.estado != 1);
                ProgramacionAnualSede sedeOri = null;
                ProgramacionAnualEjeOperativo ejeOri = null;
                foreach (var sede in ProgramacionAnual.listaSedes)
                {
                    if (sede.operacion.Equals("N"))
                    {
                        repoSede.Agregar(new ProgramacionAnualSede
                        {
                            idSede = sede.idSede,
                            idProAnu = ProgramacionAnual.idProAnu,
                            observacion = sede.observacion,
                            estado = 2,
                            usuCrea = ProgramacionAnual.usuCrea,
                            fechaCrea = DateTime.Now,
                        });
                        unidadTrabajo.GuardarCambios();
                    }
                    else if (sede.operacion.Equals("M"))
                    {
                        sedeOri = listaSedes.FirstOrDefault(f => f.idProAnuSed == sede.idProAnuSed);
                        if (sedeOri != null)
                        {
                            sedeOri.idSede = sede.idSede;
                            sedeOri.observacion = sede.observacion;
                            sedeOri.usuEdita = ProgramacionAnual.usuEdita;
                            sedeOri.fechaEdita = DateTime.Now;
                            repoSede.Actualizar(sedeOri);
                            unidadTrabajo.GuardarCambios();
                        }
                    }
                    else if (sede.operacion.Equals("E"))
                    {
                        sedeOri = listaSedes.FirstOrDefault(f => f.idProAnuSed == sede.idProAnuSed);
                        if (sedeOri != null)
                        {
                            sedeOri.estado = 1;
                            sedeOri.usuEdita = ProgramacionAnual.usuEdita;
                            sedeOri.fechaEdita = DateTime.Now;
                            repoSede.Actualizar(sedeOri);
                            unidadTrabajo.GuardarCambios();
                        }
                    }
                }

                foreach (var ejeOpe in ProgramacionAnual.listaEjeOperativos)
                {
                    if (ejeOpe.operacion.Equals("N"))
                    {
                        repoEjeOpe.Agregar(new ProgramacionAnualEjeOperativo
                        {
                            idEjeOpe = ejeOpe.idEjeOpe,
                            idProAnu = ProgramacionAnual.idProAnu,
                            observacion = ejeOpe.observacion,
                            estado = 2,
                            usuCrea = ProgramacionAnual.usuCrea,
                            fechaCrea = DateTime.Now,
                        });
                        unidadTrabajo.GuardarCambios();
                    }
                    else if (ejeOpe.operacion.Equals("M"))
                    {
                        ejeOri = listaEje.FirstOrDefault(f => f.idProAnuEjeOpe == ejeOpe.idProAnuEjeOpe);
                        if (ejeOri != null)
                        {
                            ejeOri.idEjeOpe = ejeOpe.idEjeOpe;
                            ejeOri.observacion = ejeOpe.observacion;
                            ejeOri.usuEdita = ProgramacionAnual.usuEdita;
                            ejeOri.fechaEdita = DateTime.Now;
                            repoEjeOpe.Actualizar(ejeOri);
                            unidadTrabajo.GuardarCambios();
                        }
                    }
                    else if (ejeOpe.operacion.Equals("E"))
                    {
                        ejeOri = listaEje.FirstOrDefault(f => f.idProAnuEjeOpe == ejeOpe.idProAnuEjeOpe);
                        if (ejeOri != null)
                        {
                            ejeOri.estado = 1;
                            ejeOri.usuEdita = ProgramacionAnual.usuEdita;
                            ejeOri.fechaEdita = DateTime.Now;
                            repoEjeOpe.Actualizar(ejeOri);
                            unidadTrabajo.GuardarCambios();
                        }
                    }
                }

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ProgramacionAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ProgramacionAnual, ex);
            }

            return resultado;
        }

        public Resultado ModificarAreas(ProgramacionAnualArea ProgramacionAnualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Actualizar(Clonar(ProgramacionAnualArea));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ProgramacionAnualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ProgramacionAnualArea, ex);
            }

            return resultado;
        }

        public Resultado ModificarAreasMes(ProgramacionAnualAreaMes ProgramacionAnualAreaMes)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuAreaMes.Actualizar(ProgramacionAnualAreaMes);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ProgramacionAnualAreaMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ProgramacionAnualAreaMes, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetalles(ProgramacionAnualDetalle ProgramacionAnualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repoProAnuDet.Actualizar(Clonar(ProgramacionAnualDetalle));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ProgramacionAnualDetalle);

                List<ProgramacionAnualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idProAnuDet == ProgramacionAnualDetalle.idProAnuDet && t.estado != Estados.Anulado && t.ProgramacionAnualAreaMes.idProAnuArea == ProgramacionAnualDetalle.idProAnuArea);
                
                List<int> IDAreas = new List<int>();
                foreach (var item in lista)
                {
                    item.importe = Math.Round(item.cantidad * ProgramacionAnualDetalle.precio, 2);
                    repoProAnuDetMes.Actualizar(item);
                    unidadTrabajo.GuardarCambios();
                    IDAreas.Add((Int32)item.idProAnuAreaMes);
                }


                var ListaProgramacionAnualAreaMes = repoProAnuAreaMes.TraerVariosPorCondicion(t=> IDAreas.Contains(t.idProAnuAreaMes) && t.estado != Estados.Anulado);

                foreach (var programacionAnualAreaMes in ListaProgramacionAnualAreaMes)
                {
                    List<ProgramacionAnualDetalleMes> listaDetArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idProAnuAreaMes == programacionAnualAreaMes.idProAnuAreaMes && t.estado != Estados.Anulado && t.ProgramacionAnualDetalle.idProAnuArea == programacionAnualAreaMes.idProAnuArea);
                    decimal suma = listaDetArea.Sum(s => s.importe);

                    if (programacionAnualAreaMes != null)
                    {
                        programacionAnualAreaMes.importe = suma;
                        repoProAnuAreaMes.Actualizar(programacionAnualAreaMes);
                        unidadTrabajo.GuardarCambios();
                    }
                }

            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ProgramacionAnualDetalle, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetallesMes(ProgramacionAnualDetalleMes programacionAnualDetalleMes, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repoProAnuDetMes.Actualizar(programacionAnualDetalleMes);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, programacionAnualDetalleMes);

                if (actualizaArea)
                {
                    var ProgramacionAnualArea = repoProAnuAreaMes.TraerPorID((Int32)programacionAnualDetalleMes.idProAnuAreaMes);

                    List<ProgramacionAnualDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idProAnuAreaMes == programacionAnualDetalleMes.idProAnuAreaMes && t.estado != Estados.Anulado  && t.ProgramacionAnualDetalle.idProAnuArea == ProgramacionAnualArea.idProAnuArea && t.ProgramacionAnualDetalle.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.importe);

                    if (ProgramacionAnualArea != null)
                    {
                        ProgramacionAnualArea.importe = suma;
                        repoProAnuAreaMes.Actualizar(ProgramacionAnualArea);
                        unidadTrabajo.GuardarCambios();
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, programacionAnualDetalleMes, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(ProgramacionAnual ProgramacionAnual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(ProgramacionAnual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ProgramacionAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnual, ex);
            }

            return resultado;
        }

        public Resultado Anular(ProgramacionAnual ProgramacionAnual, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ProgramacionAnual.estado = Estados.Anulado;
                ProgramacionAnual.fechaEdita = DateTime.Now;
                ProgramacionAnual.usuEdita = usuario;

                repositorio.Actualizar(ProgramacionAnual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ProgramacionAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnual, ex);
            }

            return resultado;
        }

        public Resultado AnularArea(ProgramacionAnualArea ProgramacionAnualArea, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;


                List<ProgramacionAnualAreaMes> programacionAnualAreas = 
                    repoProAnuAreaMes.TraerVariosPorCondicion(t=> t.idProAnuArea == ProgramacionAnualArea.idProAnuArea && t.estado != 1);

                
                List<ProgramacionAnualDetalle> programacionAnualDetalles = 
                    repoProAnuDet.TraerVariosPorCondicion(t=> t.idProAnuArea == ProgramacionAnualArea.idProAnuArea && t.estado != 1);

                IEnumerable<int> IDs = programacionAnualDetalles.Select(s => s.idProAnuDet).Distinct();

                List<ProgramacionAnualDetalleMes> programacionAnualDetallesMeses =
                    repoProAnuDetMes.TraerVariosPorCondicion(t => IDs.Contains((Int32)t.idProAnuDet) && t.estado != 1);

                ProgramacionAnualArea.estado = Estados.Anulado;
                ProgramacionAnualArea.fechaEdita = DateTime.Now;
                ProgramacionAnualArea.usuEdita = usuario;

                repoProAnuArea.Actualizar(ProgramacionAnualArea);

                foreach (ProgramacionAnualAreaMes programacionAnualArea in programacionAnualAreas)
                {
                    programacionAnualArea.estado = Estados.Anulado;
                    programacionAnualArea.fechaEdita = DateTime.Now;
                    programacionAnualArea.usuEdita = usuario;

                    repoProAnuAreaMes.Actualizar(programacionAnualArea);
                }

                foreach (ProgramacionAnualDetalle programacionAnualDetalle in programacionAnualDetalles)
                {
                    programacionAnualDetalle.estado = Estados.Anulado;
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = usuario;

                    repoProAnuDet.Actualizar(programacionAnualDetalle);
                }

                foreach (ProgramacionAnualDetalleMes programacionAnualDetalleMes in programacionAnualDetallesMeses)
                {
                    programacionAnualDetalleMes.estado = Estados.Anulado;
                    programacionAnualDetalleMes.fechaEdita = DateTime.Now;
                    programacionAnualDetalleMes.usuEdita = usuario;

                    repoProAnuDetMes.Actualizar(programacionAnualDetalleMes);
                }

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ProgramacionAnualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnualArea, ex);
            }

            return resultado;
        }

        public bool AnularProgramacionAnualArea(ProgramacionAnualArea ProgramacionAnualArea, string usuario)
        {
            bool res = false;
            try
            {
                res = repoProAnuArea.AnularProgramacionAnualArea(ProgramacionAnualArea.idProAnuArea, usuario);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnualArea, ex);
            }

            return res;
        }

        public bool AnularProgramacionAnualAreaPorCuenta(ProgramacionAnualArea programacionAnualArea, string usuario)
        {
            bool res = false;
            try
            {
                res = repoProAnuArea.AnularProgramacionAnualAreaPorCuenta(programacionAnualArea.idProAnu, programacionAnualArea.idCueCon, programacionAnualArea.idArea, usuario);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, programacionAnualArea, ex);
            }

            return res;
        }

        public Resultado AnularDetalle(ProgramacionAnualDetalle ProgramacionAnualDetalle, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                ProgramacionAnualDetalle.estado = Estados.Anulado;
                ProgramacionAnualDetalle.fechaEdita = DateTime.Now;
                ProgramacionAnualDetalle.usuEdita = usuario;
                repoProAnuDet.Actualizar(ProgramacionAnualDetalle);

                //IEnumerable<int> IDs = programacionAnualAreas.Select(s => s.idProAnuArea).Distinct();
                List<ProgramacionAnualDetalleMes> programacionAnualDetalles = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idProAnuDet == ProgramacionAnualDetalle.idProAnuDet && t.estado != Estados.Anulado);
                List<int> IDAreas = new List<int>();
                foreach (ProgramacionAnualDetalleMes programacionAnualDetalle in programacionAnualDetalles)
                {
                    programacionAnualDetalle.estado = Estados.Anulado;
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = usuario;

                    repoProAnuDetMes.Actualizar(programacionAnualDetalle);
                    IDAreas.Add((Int32)programacionAnualDetalle.idProAnuAreaMes);
                }

                unidadTrabajo.GuardarCambios();

                var listaProgramacionAnualAreaMes = repoProAnuAreaMes.TraerVariosPorCondicion(t => IDAreas.Contains(t.idProAnuAreaMes));

                foreach (var programacionAnualAreaMes in listaProgramacionAnualAreaMes)
                {
                    List<ProgramacionAnualDetalleMes> listaDetArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idProAnuAreaMes == programacionAnualAreaMes.idProAnuAreaMes && t.estado != Estados.Anulado);
                    decimal suma = listaDetArea.Sum(s => s.importe);

                    if (programacionAnualAreaMes != null)
                    {
                        programacionAnualAreaMes.importe = suma;
                        repoProAnuAreaMes.Actualizar(programacionAnualAreaMes);
                        unidadTrabajo.GuardarCambios();
                    }
                }


                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ProgramacionAnualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnualDetalle, ex);
            }

            return resultado;
        }

        public Resultado EliminarArea(ProgramacionAnualArea ProgramacionAnualArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuArea.Eliminar(ProgramacionAnualArea);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ProgramacionAnualArea);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnualArea, ex);
            }

            return resultado;
        }

        public Resultado EliminarDetalle(ProgramacionAnualDetalle ProgramacionAnualDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Eliminar(ProgramacionAnualDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ProgramacionAnualDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ProgramacionAnualDetalle, ex);
            }

            return resultado;
        }

        public Resultado AsginarSubpresupuesto(List<ProgramacionAnualDetallePorMesPres> listaProgramacionAnualDetalleMes, int? idSubpresupuesto, string usuario)
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

                    foreach (ProgramacionAnualDetallePorMesPres datoDetalle in listaProgramacionAnualDetalleMes)
                    {
                        ProgramacionAnualDetalleMes objProgramacionAnualDetalleMes = repoProAnuDetMes.TraerPorID(datoDetalle.idProAnuDetMes);

                        //objProgramacionAnualDetalleMes = datoDetalle;

                        objProgramacionAnualDetalleMes.idSubpresupuesto = idSubpresupuesto;
                        objProgramacionAnualDetalleMes.usuEdita = usuario;
                        objProgramacionAnualDetalleMes.fechaEdita = DateTime.Now;

                        repoProAnuDetMes.Actualizar(objProgramacionAnualDetalleMes);
                        unidadTrabajoProAnuDetMes.GuardarCambios();
                    }

                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, listaProgramacionAnualDetalleMes);
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, listaProgramacionAnualDetalleMes, ex);
                }
            }

            return resultado;
        }

        public void GuardarDetalleProgramacionAnual(int idProAnu, string codigos, string usuario, bool indicaEliminacion)
        {
            repositorio.GuardarDetalleProgramacionAnual(idProAnu, codigos, usuario, indicaEliminacion);
        }
        public void GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(int idProAnu, string idsReqBieSer, string usuario)
        {
            repositorio.GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(idProAnu, idsReqBieSer, usuario);
        }

        public void GuardarDetalleProgramacionAnualGastosRecuerrentes(int idProAnu, string codigos, string usuario, bool indicaEliminacion)
        {
            repositorio.GuardarDetalleProgramacionAnualGastosRecuerrentes(idProAnu, codigos, usuario, indicaEliminacion);
        }

        public void GuardarDetalleProgramacionAnualRRHH(int idProAnu, string codigos, string usuario, bool indicaEliminacion)
        {
            repositorio.GuardarDetalleProgramacionAnualRRHH(idProAnu, codigos, usuario, indicaEliminacion);
        }

        public void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion)
        {
            repositorio.GuardarDetalleReajusteRRHH(idProAnu, idReaMenPro, codigos, usuario, indicaEliminacion);
        }

        #endregion

        #region Busquedas y listados

        public ProgramacionAnual BuscarPorCodigo(int idProgramacionAnual)
        {
            return repositorio.TraerPorID(idProgramacionAnual);
        }

        public ProgramacionAnualArea BuscarPorCodigoArea(int idProAnuArea)
        {
            return repoProAnuArea.TraerPorID(idProAnuArea);
        }

        public ProgramacionAnualArea BuscarPorCodigoArea(int idProAnu, int idArea, int idCueCon)
        {
            return repoProAnuArea.TraerPorCondicion(t=>t.idArea == idArea && t.idProAnu == idProAnu && t.idCueCon == idCueCon && t.estado != Estados.Anulado);
        }

        public ProgramacionAnualAreaMes BuscarPorCodigoAreaMes(int idProAnuAreaMes)
        {
            return repoProAnuAreaMes.TraerPorID(idProAnuAreaMes);
        }

        public ProgramacionAnualAreaMes BuscarPorCodigoAreaMes(int idProAnuArea, int mes)
        {
            return repoProAnuAreaMes.TraerPorCondicion(t => t.idProAnuArea == idProAnuArea && t.mes == mes && t.estado!=1);
        }

        public decimal BuscarImportePorArea(int idProAnuAreaMes, string descripcion, int idUnidad, decimal precio)
        {
            decimal importe = 0;
            var proAnuArea = repoProAnuDetMes.TraerVariosPorCondicion(t => t.ProgramacionAnualAreaMes.idProAnuAreaMes == idProAnuAreaMes
             && t.estado != 1 && (!t.ProgramacionAnualDetalle.descripcion.Equals(descripcion) 
             && t.ProgramacionAnualDetalle.idUnidad != idUnidad && t.ProgramacionAnualDetalle.precio != precio));

            if(proAnuArea != null)
            {
                importe = proAnuArea.Where(x => x.estado != 1).Sum(s => s.importe);
            }
            return importe;
        }

        public ProgramacionAnualDetalle BuscarPorCodigoDetalle(int idProAnuDet)
        {
            return repoProAnuDet.TraerPorID(idProAnuDet);
        }

        public ProgramacionAnualDetalle BuscarPorCodigoDetalle(int idProAnuArea, string descripcion, int idUnidad, decimal precio)
        {
            return repoProAnuDet.TraerPorCondicion(t => t.idProAnuArea == idProAnuArea && t.descripcion.Equals(descripcion) && t.idUnidad == idUnidad && t.precio == precio && t.estado != Estados.Anulado);
        }

        public ProgramacionAnualDetalleMes BuscarPorCodigoDetalleMes(int idProAnuAreaMes, string descripcion, int idUnidad, decimal precio)
        {
            return repoProAnuDetMes.TraerPorCondicion(t => t.idProAnuAreaMes == idProAnuAreaMes && t.ProgramacionAnualDetalle.descripcion.Equals(descripcion) && t.ProgramacionAnualDetalle.idUnidad == idUnidad && t.ProgramacionAnualDetalle.precio == precio && t.ProgramacionAnualDetalle.estado != Estados.Anulado && t.estado != Estados.Anulado);
        }
        public ProgramacionAnualDetalleMes BuscarPorCodigoDetalleMes(int idProAnuDet, int idProAnuAreaMes)
        {
            return repoProAnuDetMes.TraerPorCondicion(t => t.idProAnuAreaMes == idProAnuAreaMes && t.ProgramacionAnualDetalle.idProAnuDet == idProAnuDet && t.ProgramacionAnualDetalle.estado != Estados.Anulado && t.estado != Estados.Anulado);
        }

        public ProgramacionAnualDetalleMes BuscarPorCodigoDetalleMes(int idProAnuDetMes)
        {
            return repoProAnuDetMes.TraerPorID(idProAnuDetMes);
        }

        public List<ProgramacionAnual> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<ProgramacionAnual> listarTodos(int anio)
        {
            return repositorio.TraerVariosPorCondicion(t => t.anio == anio && t.estado != Estados.Anulado);
        }

        public List<ProgramacionAnual> listarTodosPorGrupoPresupuesto(int idGruPre)
        {
            return repositorio.TraerVariosPorCondicion( t=>t.idGruPre == idGruPre && t.estado != Estados.Anulado);
        }

        public List<ProgramacionAnualPres> TraerListaProgramacionAnual(int anio)
        {
            return repositorio.TraerListaProgramacionAnual(anio);
        }

        public List<ProgramacionAnualPres> TraerListaProgramacionAnualAprobados(int anio)
        {
            return repositorio.TraerListaProgramacionAnualAprobados(anio);
        }

        public List<ProgramacionAnualAreaPres> TraerListaProgramacionAnualArea(int idProAnu)
        {
            return repoProAnuArea.TraerListaProgramacionAnualArea(idProAnu);
        }

        public List<ProgramacionAnualAreaExporta> TraerListaProgramacionAnualAreaExporta(int idProAnu)
        {
            return repoProAnuArea.TraerListaProgramacionAnualExporta(idProAnu);
        }
        public List<ReporteProgramacionAnualExportaPres> TraerReporteProgramacionAnualExporta(int idProAnu, int idMoneda)
        {
            return repoProAnuArea.TraerReporteProgramacionAnualExporta(idProAnu, idMoneda);
        }

        public List<ProgramacionAnualDetallePres> TraerListaProgramacionAnualDetalle(int idProAnuArea)
        {
            return repoProAnuDet.TraerListaProgramacionAnualDetalle(idProAnuArea);
        }

        public List<ProgramacionAnual> TraerListaxGrupo(int idGrupo)
        {
            return repositorio.TraerVariosPorCondicion(t => t.idGruPre == idGrupo && t.estado != Estados.Anulado);
        }

        public List<int> TraerListaProgramacionAnualAreas(int idProAnu)
        {
            return repositorio.TraerListaProgramacionAnualAreas(idProAnu);
        }

        public List<ConsolidadoPresupuesto> TraerConsolidadoPresupuestoPorDirecciones(int anio)
        {
            return repositorio.TraerConsolidadoPresupuestoPorDirecciones(anio);
        }

        public List<ResumenPresupuestoPorSubdireccion> TraerResumenPresupuestoPorSubdirecciones(int anio, int idDireccion)
        {
            return repositorio.TraerResumenPresupuestoPorSubdirecciones(anio, idDireccion);
        }

        public List<CalendarioPresupuestoAnual> TraerCalendarioPresupuestoAnual(int anio, int idFueFin, int idPresupuesto)
        {
            return repositorio.TraerCalendarioPresupuestoAnual(anio, idFueFin, idPresupuesto);
        }

        public List<ProgramacionSedeLaboralPoco> ListaProgramacionSedeLaboralPoco(int idProAnu)
        {
            return repoSede.ListaProgramacionSedeLaboralPoco(idProAnu);
        }

        public List<ProgramacionEjeOperativoPoco> ListaProgramacionEjeOperativoPoco(int idProAnu)
        {
            return repoEjeOpe.ListaProgramacionEjeOperativoPoco(idProAnu);
        }
        public List<PresupuestoPorErradicacion> TraerPresupuestoPorErradicacion(int anio)
        {
            return repositorio.TraerPresupuestoPorErradicacion(anio);
        }

        public List<ProgramacionAnualDetallePorMesPres> TraerListaProgramacionAnualDetallePorMes(int idProAnu, int mes, int? idSubpresupuesto)
        {
            return repoProAnuDet.TraerListaProgramacionAnualDetallePorMes(idProAnu, mes, idSubpresupuesto).ToList();
        }

        #endregion

        #region Reportes
        public List<ReporteProgramacionAnualExportaMasivoPres> TraerReporteProgramacionAnualExportaMasivo(string idsProAnu, int idMoneda)
        {
            return repositorio.TraerReporteProgramacionAnualExportaMasivo(idsProAnu, idMoneda);
        }
        #endregion
    }
}
