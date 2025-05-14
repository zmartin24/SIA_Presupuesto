using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class RequerimientoBienServicioServicio : ServicioBase, IRequerimientoBienServicioServicio
    {
        IRequerimientoBienServicioRepositorio repositorio;
        IRequerimientoBienServicioDetalleMesRepositorio repoProAnuDetMes;
        IRequerimientoBienServicioDetalleRepositorio repoProAnuDet;

        public RequerimientoBienServicioServicio(IRequerimientoBienServicioRepositorio repositorio, IRequerimientoBienServicioDetalleMesRepositorio repoProAnuDetMes, IRequerimientoBienServicioDetalleRepositorio repoProAnuDet)
        {
            this.repositorio = repositorio;
            this.repoProAnuDetMes = repoProAnuDetMes;
            this.repoProAnuDet = repoProAnuDet;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private RequerimientoBienServicio Clonar(RequerimientoBienServicio RequerimientoBienServicio1)
        {
            return new RequerimientoBienServicio
            {
                idMoneda = RequerimientoBienServicio1.idMoneda,
                idReqBieSer = RequerimientoBienServicio1.idReqBieSer,
                idArea = RequerimientoBienServicio1.idArea,
                anio = RequerimientoBienServicio1.anio,
                descripcion = RequerimientoBienServicio1.descripcion,
                estado = RequerimientoBienServicio1.estado,
                fechaAprobacion = RequerimientoBienServicio1.fechaAprobacion,
                fechaCrea = RequerimientoBienServicio1.fechaCrea,
                fechaEdita = RequerimientoBienServicio1.fechaEdita,
                fechaEmision = RequerimientoBienServicio1.fechaEmision,
                usuCrea = RequerimientoBienServicio1.usuCrea,
                usuEdita = RequerimientoBienServicio1.usuEdita
            };
        }

        private RequerimientoBienServicioDetalle Clonar(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle1)
        {
            return new RequerimientoBienServicioDetalle
            {
                idProducto = RequerimientoBienServicioDetalle1.idProducto,
                idReqBieSer = RequerimientoBienServicioDetalle1.idReqBieSer,
                idReqBieSerDet = RequerimientoBienServicioDetalle1.idReqBieSerDet,
                idUnidad = RequerimientoBienServicioDetalle1.idUnidad,
                idCueCon = RequerimientoBienServicioDetalle1.idCueCon,
                estado = RequerimientoBienServicioDetalle1.estado,
                fechaCrea = RequerimientoBienServicioDetalle1.fechaCrea,
                fechaEdita = RequerimientoBienServicioDetalle1.fechaEdita,
                usuCrea = RequerimientoBienServicioDetalle1.usuCrea,
                usuEdita = RequerimientoBienServicioDetalle1.usuEdita,
                precio = RequerimientoBienServicioDetalle1.precio,
                descripcion = RequerimientoBienServicioDetalle1.descripcion,
                justificacion = RequerimientoBienServicioDetalle1.justificacion,
                subtotal = RequerimientoBienServicioDetalle1.subtotal,
            };
        }

        public Resultado Nuevo(RequerimientoBienServicio RequerimientoBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(RequerimientoBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, RequerimientoBienServicio);
                resultado.id = RequerimientoBienServicio.idReqBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, RequerimientoBienServicio, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalle(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Agregar(RequerimientoBienServicioDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, RequerimientoBienServicioDetalle, ex);
            }

            return resultado;
        }
        public Resultado NuevoDetalleConMeses(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, List<RequerimientoBienServicioDetalleMes> listaMeses)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                RequerimientoBienServicioDetalleMes objDetalleMesNew = listaMeses.FirstOrDefault() ?? new RequerimientoBienServicioDetalleMes();

                decimal suma = objDetalleMesNew.cantEne + objDetalleMesNew.cantFeb + objDetalleMesNew.cantMar + objDetalleMesNew.cantAbr + objDetalleMesNew.cantMay + objDetalleMesNew.cantJun +
                               objDetalleMesNew.cantJul + objDetalleMesNew.cantAgo + objDetalleMesNew.cantSet + objDetalleMesNew.cantOct + objDetalleMesNew.cantNov + objDetalleMesNew.cantDic;


                RequerimientoBienServicioDetalle.subtotal = suma * RequerimientoBienServicioDetalle.precio;
                repoProAnuDet.Agregar(RequerimientoBienServicioDetalle);

                if (objDetalleMesNew.cantEne > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 1;
                    objDetalleMes.cantidad = objDetalleMesNew.cantEne;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                    
                }
                if (objDetalleMesNew.cantFeb > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 2;
                    objDetalleMes.cantidad = objDetalleMesNew.cantFeb;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                    
                }
                if (objDetalleMesNew.cantMar > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 3;
                    objDetalleMes.cantidad = objDetalleMesNew.cantMar;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantAbr > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 4;
                    objDetalleMes.cantidad = objDetalleMesNew.cantAbr;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantMay > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();

                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 5;
                    objDetalleMes.cantidad = objDetalleMesNew.cantMay;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantJun > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 6;
                    objDetalleMes.cantidad = objDetalleMesNew.cantJun;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantJul > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 7;
                    objDetalleMes.cantidad = objDetalleMesNew.cantJul;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantAgo > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 8;
                    objDetalleMes.cantidad = objDetalleMesNew.cantAgo;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantSet > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                   
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 9;
                    objDetalleMes.cantidad = objDetalleMesNew.cantSet;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantOct > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 10;
                    objDetalleMes.cantidad = objDetalleMesNew.cantOct;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantNov > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 11;
                    objDetalleMes.cantidad = objDetalleMesNew.cantNov;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }
                if (objDetalleMesNew.cantDic > 0)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    
                    objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                    objDetalleMes.mes = 12;
                    objDetalleMes.cantidad = objDetalleMesNew.cantDic;
                    objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuCrea;
                    objDetalleMes.fechaCrea = RequerimientoBienServicioDetalle.fechaCrea;
                    objDetalleMes.estado = 2;
                    repoProAnuDetMes.Agregar(objDetalleMes);
                }

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, RequerimientoBienServicioDetalle, ex);
            }
            return resultado;
        }

        public Resultado NuevoDetalle(RequerimientoBienServicioDetalleMes RequerimientoBienServicioDetalleMes, bool actualizaDet)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDetMes.Agregar(RequerimientoBienServicioDetalleMes);
                unidadTrabajo.GuardarCambios();

                if (actualizaDet)
                {
                    var RequerimientoBienServicioDet = repoProAnuDet.TraerPorID(RequerimientoBienServicioDetalleMes.idReqBieSerDet);

                    List<RequerimientoBienServicioDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReqBieSerDet == RequerimientoBienServicioDet.idReqBieSerDet && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.cantidad);

                    if (RequerimientoBienServicioDet != null)
                    {
                        RequerimientoBienServicioDet.subtotal = suma * RequerimientoBienServicioDet.precio;
                        repoProAnuDet.Actualizar(RequerimientoBienServicioDet);
                        unidadTrabajo.GuardarCambios();
                    }
                }

                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, RequerimientoBienServicioDetalleMes);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, RequerimientoBienServicioDetalleMes, ex);
            }

            return resultado;
        }

        public Resultado Modificar(RequerimientoBienServicio RequerimientoBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                
                repositorio.Actualizar(Clonar(RequerimientoBienServicio));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, RequerimientoBienServicio);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, RequerimientoBienServicio, ex);
            }

            return resultado;
        }

        public Resultado ModificarSinClonar(RequerimientoBienServicio RequerimientoBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;


                repositorio.Actualizar(RequerimientoBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, RequerimientoBienServicio);
                resultado.id = RequerimientoBienServicio.idReqBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, RequerimientoBienServicio, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetalles(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                List<RequerimientoBienServicioDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && t.estado != Estados.Anulado);
                decimal suma = lista.Sum(s => s.cantidad);

                RequerimientoBienServicioDetalle.subtotal = suma * RequerimientoBienServicioDetalle.precio;
                repoProAnuDet.Actualizar(Clonar(RequerimientoBienServicioDetalle));
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, RequerimientoBienServicioDetalle, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetallesSinClonar(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                //List<RequerimientoBienServicioDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && t.estado != Estados.Anulado);
                decimal suma = repoProAnuDetMes.TraerTotalCantidadMensual(RequerimientoBienServicioDetalle.idReqBieSerDet);

                RequerimientoBienServicioDetalle.subtotal = suma * RequerimientoBienServicioDetalle.precio;
                repoProAnuDet.Actualizar(RequerimientoBienServicioDetalle);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, RequerimientoBienServicioDetalle, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetallesSinClonarConMeses(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, List<RequerimientoBienServicioDetalleMes> listaMeses)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                RequerimientoBienServicioDetalleMes objDetalleMesNew = listaMeses.FirstOrDefault() ?? new RequerimientoBienServicioDetalleMes();

                decimal suma = objDetalleMesNew.cantEne + objDetalleMesNew.cantFeb + objDetalleMesNew.cantMar + objDetalleMesNew.cantAbr + objDetalleMesNew.cantMay + objDetalleMesNew.cantJun +
                               objDetalleMesNew.cantJul + objDetalleMesNew.cantAgo + objDetalleMesNew.cantSet + objDetalleMesNew.cantOct + objDetalleMesNew.cantNov + objDetalleMesNew.cantDic;

                for(int i = 1; i <= 12; i++)
                {
                    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                    decimal cantidadNew = 0;
                    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == i && x.estado != 1);
                    switch (i) 
                    {
                        case 1:
                            cantidadNew = objDetalleMesNew.cantEne;
                            break;
                        case 2:
                            cantidadNew = objDetalleMesNew.cantFeb;
                            break;
                        case 3:
                            cantidadNew = objDetalleMesNew.cantMar;
                            break;
                        case 4:
                            cantidadNew = objDetalleMesNew.cantAbr;
                            break;
                        case 5:
                            cantidadNew = objDetalleMesNew.cantMay;
                            break;
                        case 6:
                            cantidadNew = objDetalleMesNew.cantJun;
                            break;
                        case 7:
                            cantidadNew = objDetalleMesNew.cantJul;
                            break;
                        case 8:
                            cantidadNew = objDetalleMesNew.cantAgo;
                            break;
                        case 9:
                            cantidadNew = objDetalleMesNew.cantSet;
                            break;
                        case 10:
                            cantidadNew = objDetalleMesNew.cantOct;
                            break;
                        case 11:
                            cantidadNew = objDetalleMesNew.cantNov;
                            break;
                        case 12:
                            cantidadNew = objDetalleMesNew.cantDic;
                            break;

                    }
                    if (objDetalleMes == null && cantidadNew.Equals(0)) continue;

                    if (objDetalleMes != null && (objDetalleMes.cantidad.Equals(cantidadNew))) continue;


                    if (objDetalleMes != null)
                    {
                        objDetalleMes.cantidad = cantidadNew;
                        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                        repoProAnuDetMes.Actualizar(objDetalleMes);
                    }
                    else
                    {
                        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                        objDetalleMes.mes = i;
                        objDetalleMes.cantidad = cantidadNew;
                        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                        objDetalleMes.estado = 2;
                        repoProAnuDetMes.Agregar(objDetalleMes);
                    }
                }

                //if (objDetalleMesNew.cantEne > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 1 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantEne;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 1;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantEne;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantFeb > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 2 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantFeb;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 2;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantFeb;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantMar > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 3 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantMar;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 3;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantMar;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantAbr > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 4 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantAbr;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 4;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantAbr;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantMay > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 5 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantMay;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 5;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantMay;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantJun > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 6 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantJun;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 6;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantJun;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantJul > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 7 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantJul;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 7;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantJul;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantAgo > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 8 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantAgo;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 8;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantAgo;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantSet > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 9 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantSet;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 9;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantSet;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantOct > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 10 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantOct;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 10;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantOct;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantNov > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 11 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantNov;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 11;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantNov;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}
                //if (objDetalleMesNew.cantDic > 0)
                //{
                //    RequerimientoBienServicioDetalleMes objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //    objDetalleMes = repoProAnuDetMes.TraerPorCondicion(x => x.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && x.mes == 12 && x.estado != 1);
                //    if (objDetalleMes != null)
                //    {
                //        objDetalleMes.cantidad = objDetalleMesNew.cantDic;
                //        objDetalleMes.usuEdita = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaEdita = RequerimientoBienServicioDetalle.fechaEdita;
                //        repoProAnuDetMes.Actualizar(objDetalleMes);
                //    }
                //    else
                //    {
                //        objDetalleMes = new RequerimientoBienServicioDetalleMes();
                //        objDetalleMes.idReqBieSerDet = RequerimientoBienServicioDetalle.idReqBieSerDet;
                //        objDetalleMes.mes = 12;
                //        objDetalleMes.cantidad = objDetalleMesNew.cantDic;
                //        objDetalleMes.usuCrea = RequerimientoBienServicioDetalle.usuEdita;
                //        objDetalleMes.fechaCrea = (DateTime)RequerimientoBienServicioDetalle.fechaEdita;
                //        objDetalleMes.estado = 2;
                //        repoProAnuDetMes.Agregar(objDetalleMes);
                //    }
                //}

                RequerimientoBienServicioDetalle.subtotal = suma * RequerimientoBienServicioDetalle.precio;
                repoProAnuDet.Actualizar(RequerimientoBienServicioDetalle);
                unidadTrabajo.GuardarCambios();

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, RequerimientoBienServicioDetalle, ex);
            }

            return resultado;
        }

        public Resultado ModificarDetalles(RequerimientoBienServicioDetalleMes RequerimientoBienServicioDetalleMes, bool actualizaArea)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repoProAnuDetMes.Actualizar(RequerimientoBienServicioDetalleMes);
                unidadTrabajo.GuardarCambios();
                

                if (actualizaArea)
                {
                    var RequerimientoBienServicioDet = repoProAnuDet.TraerPorID(RequerimientoBienServicioDetalleMes.idReqBieSerDet);

                    List<RequerimientoBienServicioDetalleMes> lista = repoProAnuDetMes.TraerVariosPorCondicion(t => t.idReqBieSerDet == RequerimientoBienServicioDetalleMes.idReqBieSerDet && t.estado != Estados.Anulado);
                    decimal suma = lista.Sum(s => s.cantidad);

                    if (RequerimientoBienServicioDet != null)
                    {
                        RequerimientoBienServicioDet.subtotal = suma * RequerimientoBienServicioDet.precio;
                        repoProAnuDet.Actualizar(RequerimientoBienServicioDet);
                        unidadTrabajo.GuardarCambios();
                    }
                }

                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, RequerimientoBienServicioDetalleMes);

            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, RequerimientoBienServicioDetalleMes, ex);
            }

            return resultado;
        }
        public Resultado Eliminar(RequerimientoBienServicio RequerimientoBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(RequerimientoBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, RequerimientoBienServicio);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, RequerimientoBienServicio, ex);
            }

            return resultado;
        }

        public Resultado Anular(RequerimientoBienServicio RequerimientoBienServicio, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                RequerimientoBienServicio.estado = Estados.Anulado;
                RequerimientoBienServicio.fechaEdita = DateTime.Now;
                RequerimientoBienServicio.usuEdita = usuario;

                repositorio.Actualizar(RequerimientoBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, RequerimientoBienServicio);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, RequerimientoBienServicio, ex);
            }

            return resultado;
        }

        public Resultado AnularArea(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                List<RequerimientoBienServicioDetalleMes> programacionAnualDetalles = repoProAnuDetMes.TraerVariosPorCondicion(t=> t.idReqBieSerDet == RequerimientoBienServicioDetalle.idReqBieSerDet && t.estado != 1);

                foreach (RequerimientoBienServicioDetalleMes programacionAnualDetalle in programacionAnualDetalles)
                {
                    programacionAnualDetalle.estado = Estados.Anulado;
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = usuario;

                    repoProAnuDetMes.Actualizar(programacionAnualDetalle);
                }

                RequerimientoBienServicioDetalle.estado = Estados.Anulado;
                RequerimientoBienServicioDetalle.fechaEdita = DateTime.Now;
                RequerimientoBienServicioDetalle.usuEdita = usuario;
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, RequerimientoBienServicioDetalle, ex);
            }

            return resultado;
        }

        public Resultado EliminarDetalle(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repoProAnuDet.Eliminar(RequerimientoBienServicioDetalle);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, RequerimientoBienServicioDetalle);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, RequerimientoBienServicioDetalle, ex);
            }

            return resultado;
        }
        public Resultado GuardarDetalleRequerimientoAnualBienesServiciosToClonar(RequerimientoBienServicio requerimientoBienServicio)
        {
            TransactionOptions Tranconfiguracion = new TransactionOptions()
            {
                Timeout = TransactionManager.MaximumTimeout,
                IsolationLevel = IsolationLevel.Serializable
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, Tranconfiguracion))
            {
                bool res = false;
                int idReqBieSerOrigen = 0;
                try
                {
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                    idReqBieSerOrigen = requerimientoBienServicio.estado;
                    requerimientoBienServicio.estado = 2;

                    repositorio.Agregar(requerimientoBienServicio);
                    unidadTrabajo.GuardarCambios();

                    res = repositorio.GuardarDetalleRequerimientoAnualBienesServiciosToClonar(requerimientoBienServicio.idReqBieSer, idReqBieSerOrigen, requerimientoBienServicio.usuCrea);

                    if (res)
                    {
                        scope.Complete();
                    }

                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, requerimientoBienServicio);
                    resultado.id = requerimientoBienServicio.idReqBieSer;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, requerimientoBienServicio, ex);
                }
            }
            return resultado;
        }
        public bool GuardarDetalleRequerimientoAnualBienesServiciosToExcel(int idReqBieSer, string usuario, DataTable estructuraCarga)
        {
            return repositorio.GuardarDetalleRequerimientoAnualBienesServiciosToExcel(idReqBieSer, usuario, estructuraCarga);
        }

        #endregion

        #region Busquedas y listados

        public RequerimientoBienServicio BuscarPorCodigo(int idRequerimientoBienServicio)
        {
            return repositorio.TraerPorID(idRequerimientoBienServicio);
        }
        public RequerimientoBienServicio TraerRequerimientoBienServicio(int idReqBieSer)
        {
            return repositorio.TraerRequerimientoBienServicio(idReqBieSer);
        }

        public RequerimientoBienServicioDetalle BuscarPorCodigoDetalle(int idReqBieSerDet)
        {
            return repoProAnuDet.TraerPorID(idReqBieSerDet);
        }

        //public decimal BuscarImportePorArea(int idProAnu, int idArea, int idCueCon, int mes, string descripcion, int idUnidad, decimal precio)
        //{
        //    decimal importe = 0;
        //    var proAnuArea = repoProAnuDet.TraerVariosPorCondicion(t => t.RequerimientoBienServicioArea.idArea == idArea && t.RequerimientoBienServicioArea.idProAnu == idProAnu 
        //    && t.RequerimientoBienServicioArea.mes == mes && t.RequerimientoBienServicioArea.idCueCon == idCueCon && t.estado != 1 && (!t.descripcion.Equals(descripcion) && t.idUnidad != idUnidad && t.precio != precio));

        //    if(proAnuArea != null)
        //    {
        //        importe = proAnuArea.Sum(s => s.importe);
        //    }
        //    return importe = 0;
        //}

        public RequerimientoBienServicioDetalleMes BuscarPorCodigoDetalleMes(int idProAnuDet)
        {
            return repoProAnuDetMes.TraerPorID(idProAnuDet);
        }

        public RequerimientoBienServicioDetalleMes BuscarPorCodigoDetalleMes(int idReqBieSerDet, int mes)
        {
            return repoProAnuDetMes.TraerPorCondicion(t => t.idReqBieSerDet == idReqBieSerDet && t.mes == mes );
        }

        //public RequerimientoBienServicioDetalle BuscarPorCodigoDetalle(int idProAnuDet)
        //{
        //    return repoProAnuDet.TraerPorID(idProAnuDet);
        //}

        public List<RequerimientoBienServicio> listarTodos()
        {
            return repositorio.TraerTodos();
        }

        public List<RequerimientoBienServicioPres> TraerListaRequerimientoBienServicio(int anio, int idUsuario)
        {
            return repositorio.TraerListaRequerimientoBienServicio(anio, idUsuario);
        }
        public List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPorArea(int tipo, int anio, int mes, int idArea)
        {
            return repositorio.TraerListaRequerimientoBienServicioPorArea(tipo, anio, mes, idArea);
        }

        public List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalle(int idProAnuArea)
        {
            return repoProAnuDet.TraerListaRequerimientoBienServicioDetalle(idProAnuArea);
        }

        public List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccion(int idDireccion, int? idSubdireccion, int anio, int idMoneda)
        {
            return repoProAnuDet.TraerListaRequerimientoBienServicioDetalleDireccion(idDireccion, idSubdireccion, anio, idMoneda);
        }

        public List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccionOperativos(int idDireccion, int anio, string tipo, int idMoneda)
        {
            return repoProAnuDet.TraerListaRequerimientoBienServicioDetalleDireccionOperativos(idDireccion, anio, tipo, idMoneda);
        }

        public List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDireccionExporta(int idDireccion, int anio)
        {
            return repoProAnuDet.TraerListaRequerimientoBienServicioDetalleDireccionExporta(idDireccion, anio);
        }

        public List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(int idDireccion, int anio)
        {
            return repoProAnuDet.TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(idDireccion, anio);
        }
        public List<ReporteRequerimientoBienServicioExportaPres> TraerReporteRequerimientoBienServicioExporta(int idReqBieSer)
        {
            return repoProAnuDet.TraerReporteRequerimientoBienServicioExporta(idReqBieSer);
        }

        #endregion

        #region Busquedas y listados

        public List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> TraerReporteRequerimientoBienServicioDireccionAreaExporta(int idDireccion, int anio, string tipo)
        {
            return repositorio.TraerReporteRequerimientoBienServicioDireccionAreaExporta(idDireccion, anio, tipo);
        }
        public List<ReporteRequerimientoBienServicioDetalleMensualPres> TraerReporteRequerimientoBienServicioDetalleMensual(int idReqBieSer)
        {
            return repositorio.TraerReporteRequerimientoBienServicioDetalleMensual(idReqBieSer);
        }
        public List<RequerimientoBienServicioDetalleMes> TraerRequerimientoBienServicioDetalleMeses(int idReqBieSerDet)
        {
            return repositorio.TraerRequerimientoBienServicioDetalleMeses(idReqBieSerDet);
        }
        public DataTable ListaEstructuraCargaRequerimientoAnual(int idReqBieSer, DataTable estructuraCarga)
        {
            return repositorio.ListaEstructuraCargaRequerimientoAnual(idReqBieSer, estructuraCarga);
        }
        #endregion
    }
}
