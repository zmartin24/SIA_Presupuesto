using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;
using Utilitario.Reporte;
using System.Data.Entity.Core.Objects;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RequerimientoBienServicioRepositorio : Repositorio<RequerimientoBienServicio>, IRequerimientoBienServicioRepositorio
    {
        string _connectionString;
        public RequerimientoBienServicioRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            ReporteConeccion conexion = new ReporteConeccion();
            _connectionString = "data source=" + conexion.servidor + ";initial catalog=" + conexion.basedatos + ";persist security info=True;user id=" + conexion.usuario + ";password=" + conexion.clave + ";MultipleActiveResultSets=True;App=EntityFramework";
        }
        public bool GuardarDetalleRequerimientoAnualBienesServiciosToClonar(int idReqBieSer, int idReqBieSerOrigen, string usuario)
        {
            var resultado = new ObjectParameter("resultado", typeof(bool));

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);

            contexto.GuardarDetalleRequerimientoAnualBienesServiciosToClonar(idReqBieSer, idReqBieSerOrigen, usuario, resultado);

            return resultado.Value == null ? false : ((bool)resultado.Value);
        }
        public bool GuardarDetalleRequerimientoAnualBienesServiciosToExcel(int idReqBieSer, string usuario, DataTable estructuraCarga)
        {
            bool respuesta = false;
            
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pre.sp_GuardarDetalleRequerimientoAnualBienesServiciosToExcel", cn);
                cmd.Parameters.Add("idReqBieSer", SqlDbType.Int).Value = idReqBieSer;
                cmd.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("estructuraCarga", SqlDbType.Structured).Value = estructuraCarga;
                cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
            }
            return respuesta;
        }
        public RequerimientoBienServicio TraerRequerimientoBienServicio(int idReqBieSer)
        {
            RequerimientoBienServicio obj = new RequerimientoBienServicio();
            var contexto = this.UnidadTrabajo as IContexto;
            var query = (from r in contexto.RequerimientoBienServicio
                         join a in contexto.Area on r.idArea equals a.idArea
                         join sd in contexto.Subdireccion on a.idSubDireccion equals sd.idSubdireccion
                         join d in contexto.Direccion on sd.idDireccion equals d.idDireccion
                         where
                            r.idReqBieSer == idReqBieSer
                         select new RequerimientoBienServicioPoco
                         {
                             idReqBieSer = r.idReqBieSer,
                             idArea = r.idArea,
                             idMoneda = r.idMoneda,
                             descripcion = r.descripcion,
                             fechaEmision = r.fechaEmision,
                             fechaAprobacion = r.fechaAprobacion,
                             anio = r.anio,
                             desArea = a.desArea,
                             desSubdireccion = sd.desSubdireccion,
                             desDireccion = d.desDireccion,
                             usuCrea = r.usuCrea,
                             fechaCrea = r.fechaCrea,
                             usuEdita = r.usuEdita,
                             fechaEdita = r.fechaEdita,
                             estado = r.estado
                         }).FirstOrDefault();

            obj.idReqBieSer = query.idReqBieSer;
            obj.idArea = query.idArea;
            obj.idMoneda = query.idMoneda;
            obj.descripcion = query.descripcion;
            obj.fechaEmision = query.fechaEmision;
            obj.fechaAprobacion = query.fechaAprobacion;
            obj.anio = query.anio;
            obj.desArea = query.desArea;
            obj.desSubdireccion = query.desSubdireccion;
            obj.desDireccion = query.desDireccion;
            obj.usuCrea = query.usuCrea;
            obj.fechaCrea = query.fechaCrea;
            obj.usuEdita = query.usuEdita;
            obj.fechaEdita = query.fechaEdita;
            obj.estado = query.estado;

            return obj;
        }
        public List<RequerimientoBienServicioPres> TraerListaRequerimientoBienServicio(int anio, int idUsuario)
        {
            List<RequerimientoBienServicioPres> lista = new List<RequerimientoBienServicioPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaRequerimientoBienServicio(anio, idUsuario).ToList();

            return lista;
        }
        public List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPorArea(int tipo, int anio, int mes, int idArea)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.TraerListaRequerimientoBienServicioPorArea(tipo, anio, mes, idArea).ToList();
        }

        public List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDireccionExporta(int idDireccion, int anio)
        {
            List<RequerimientoBienServicioDetallePresExporta> lista = new List<RequerimientoBienServicioDetallePresExporta>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaRequerimientoBienServicioDetalleDireccionExporta(idDireccion, anio).ToList();

            return lista;
        }
        public List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> TraerReporteRequerimientoBienServicioDireccionAreaExporta(int idDireccion, int anio, string tipo)
        {
            List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> lista = new List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres>();
            List<ReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres> listaDetallada = new List<ReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            lista = contexto.TraerReporteRequerimientoBienServicioDireccionAreaExporta(idDireccion, anio, tipo).ToList();
            listaDetallada = contexto.TraerReporteRequerimientoBienServicioDireccionAreaDetalleExporta(idDireccion, anio, tipo).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres != null)
                    cantDetalle += f.ListaReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres.Count();
            });

            return lista;
        }
        public List<ReporteRequerimientoBienServicioDetalleMensualPres> TraerReporteRequerimientoBienServicioDetalleMensual(int idReqBieSer)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            
            return contexto.TraerReporteRequerimientoBienServicioDetalleMensual(idReqBieSer).ToList();
        }
        public List<RequerimientoBienServicioDetalleMes> TraerRequerimientoBienServicioDetalleMeses(int idReqBieSerDet)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            List<RequerimientoBienServicioDetalleMes> lista = new List<RequerimientoBienServicioDetalleMes>();
            RequerimientoBienServicioDetalleMes obj = new RequerimientoBienServicioDetalleMes();

            List<RequerimientoBienServicioDetalleMes> query = (
                                                                from dm in contexto.RequerimientoBienServicioDetalleMes
                                                                where
                                                                    dm.idReqBieSerDet == idReqBieSerDet && dm.estado != 1
                                                                select dm
                                                                ).ToList();

            decimal cant = 0;
            obj = query.FirstOrDefault()?? new RequerimientoBienServicioDetalleMes();
            obj.idReqBieSerDetMes = 0;
            
            foreach (RequerimientoBienServicioDetalleMes item in query)
            {
                switch(item.mes)
                {
                    case 1:
                        obj.cantEne = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 2:
                        obj.cantFeb = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 3:
                        obj.cantMar = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 4:
                        obj.cantAbr = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 5:
                        obj.cantMay = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 6:
                        obj.cantJun = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 7:
                        obj.cantJul = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 8:
                        obj.cantAgo = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 9:
                        obj.cantSet = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 10:
                        obj.cantOct = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 11:
                        obj.cantNov = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;
                    case 12:
                        obj.cantDic = item.mes == 0 ? 0 : item.cantidad > 0 ? item.cantidad : 0;
                        break;

                }
                cant = cant + item.cantidad;
            }

            obj.cantidad = cant;

            lista.Add(obj);
            return lista;
        }

        public DataTable ListaEstructuraCargaRequerimientoAnual(int idReqBieSer, DataTable estructuraCarga)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Pre.sp_ListaEstructuraCargaRequerimientoAnual", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("idReqBieSer", SqlDbType.Int).Value = idReqBieSer;
                da.SelectCommand.Parameters.Add("estructuraCarga", SqlDbType.Structured).Value = estructuraCarga;
                da.Fill(dt);
            }

            return dt;
        }
    }
}
