using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RequerimientoMensualBienServicioRepositorio : Repositorio<RequerimientoMensualBienServicio>, IRequerimientoMensualBienServicioRepositorio
    {
        private IContexto contexto;
        string _connectionString;
        public RequerimientoMensualBienServicioRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            ReporteConeccion conexion = new ReporteConeccion();
            this.contexto = contexto;
            _connectionString = "data source=" + conexion.servidor + ";initial catalog=" + conexion.basedatos + ";persist security info=True;user id=" + conexion.usuario + ";password=" + conexion.clave + ";MultipleActiveResultSets=True;App=EntityFramework";
        }
        #region registro, actualización anulación
        public bool GuardarDetalleRequerimientoMensualBienesServiciosToClonar(int idReqMenBieSer, int idReqMenBieSerOrigen, string usuario)
        {
            var resultado = new ObjectParameter("resultado", typeof(bool));

            var contexto = this.UnidadTrabajo as IContexto;

            contexto.GuardarDetalleRequerimientoMensualBienesServiciosToClonar(idReqMenBieSer, idReqMenBieSerOrigen, usuario, resultado);

            return resultado.Value == null ? false : ((bool)resultado.Value);
        }
        public bool GuardarDetalleRequerimientoMensualBienesServiciosToExcel(int idReqMenBieSer, string usuario, DataTable estructuraCarga)
        {
            ReporteConeccion conexion = new ReporteConeccion();
            bool respuesta = false;

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pre.sp_GuardarDetalleRequerimientoMensualBienesServiciosToExcel", cn);
                cmd.Parameters.Add("idReqMenBieSer", SqlDbType.Int).Value = idReqMenBieSer;
                cmd.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("estructuraCarga", SqlDbType.Structured).Value = estructuraCarga;
                cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
            }
            //using (contexto)
            //{
            //    // Create a DataTable with the modified rows.  
            //    DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

            //    // Configure the SqlCommand and SqlParameter.  
            //    SqlCommand insertCommand = new SqlCommand("usp_InsertCategories", connection);
            //    insertCommand.CommandType = CommandType.StoredProcedure;
            //    SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@tvpNewCategories", addedCategories);
            //    tvpParam.SqlDbType = SqlDbType.Structured;

            //    // Execute the command.  
            //    insertCommand.ExecuteNonQuery();
            //}


            return respuesta;
        }
        public bool GuardarDetalleReqMensualBienServicioDesdeReqAnual(int idReqMenBieSer, int tipo, int mes, string idsReqBieSer, string usuario)
        {
            var resultado = new ObjectParameter("resultado", typeof(bool));

            var contexto = this.UnidadTrabajo as IContexto;

            contexto.GuardarDetalleReqMensualBienServicioDesdeReqAnual(idReqMenBieSer, tipo, mes, idsReqBieSer, usuario, resultado);

            return resultado.Value == null ? false : ((bool)resultado.Value);
        }
        #endregion
        #region lista y Busqueda
        public RequerimientoMensualBienServicio BuscarRequerimientoMensualBienServicio(int idReqMenBieSer)
        {
            RequerimientoMensualBienServicio obj = new RequerimientoMensualBienServicio();
            var contexto = this.UnidadTrabajo as IContexto;
            var query = (from r in contexto.RequerimientoMensualBienServicio
                         where
                            r.idReqMenBieSer == idReqMenBieSer
                         select new
                         {
                             idReqMenBieSer = r.idReqMenBieSer,
                             tipo = r.tipo,
                             desTipo = r.tipo == 1 ? "BIEN" : "SERVICIO",
                             idArea = r.idArea,
                             idMoneda = r.idMoneda,
                             descripcion = r.descripcion,
                             fechaEmision = r.fechaEmision,
                             fechaAprobacion = r.fechaAprobacion,
                             fechaAsigPre = r.fechaAsigPre,
                             idProAnu = r.idProAnu,
                             anio = r.anio,
                             mes = r.mes,
                             desArea = contexto.Area.Where(x=>x.idArea == r.idArea).Select(s=>s.desArea).FirstOrDefault(),
                             desSubdireccion = contexto.Subdireccion.Where(x => x.idSubdireccion == (contexto.Area.Where(a => a.idArea == r.idArea).FirstOrDefault().idSubDireccion)).Select(s => s.desSubdireccion).FirstOrDefault(),
                             desDireccion = contexto.Direccion.Where(x => x.idDireccion == (contexto.Subdireccion.Where(sd => sd.idSubdireccion == (contexto.Area.Where(a => a.idArea == r.idArea).FirstOrDefault().idSubDireccion)).FirstOrDefault().idDireccion)).Select(s => s.desDireccion).FirstOrDefault(),
                             usuCrea = r.usuCrea,
                             fechaCrea = r.fechaCrea,
                             usuEdita = r.usuEdita,
                             fechaEdita = r.fechaEdita,
                             estado = r.estado
                             
                         }).FirstOrDefault();

            obj = new RequerimientoMensualBienServicio()
            {
                idReqMenBieSer = query.idReqMenBieSer,
                tipo = query.tipo,
                desTipo = query.desTipo,
                idArea = query.idArea,
                idMoneda = query.idMoneda,
                descripcion = query.descripcion,
                fechaEmision = query.fechaEmision,
                fechaAprobacion = query.fechaAprobacion,
                fechaAsigPre = query.fechaAsigPre,
                idProAnu = query.idProAnu,
                anio = query.anio,
                mes = query.mes,
                desArea = query.desArea,
                desSubdireccion = query.desSubdireccion,
                desDireccion = query.desDireccion,
                usuCrea = query.usuCrea,
                fechaCrea = query.fechaCrea,
                usuEdita = query.usuEdita,
                fechaEdita = query.fechaEdita,
                estado = query.estado
            };

            return obj;
        }

        public List<RequerimientoMensualBienServicioPres> TraerListaRequerimientoMensualBienServicio(int anio, int mes, int idUsuario, int? idPresupuesto, bool listarTodos)
        {
            List<RequerimientoMensualBienServicioPres> lista = new List<RequerimientoMensualBienServicioPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaRequerimientoMensualBienServicio(anio, mes, idUsuario, idPresupuesto, listarTodos).ToList();

            return lista;
        }

        public List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalleDireccion(int idDireccion, int idSubdireccion, string tipo, int idTipoRequerimiento, int anio, int mes)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            
            return contexto.TraerListaRequerimientoMensualDetalleDireccion(idDireccion, idSubdireccion, tipo, idTipoRequerimiento, anio, mes).ToList();
        }
        public DataTable ListaEstructuraCargaRequerimientoMensual(int idReqMenBieSer, DataTable estructuraCarga)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                //SqlCommand cmd = new SqlCommand("Pre.sp_ListaEstructuraCargaRequerimientoMensual", cn);
                //cmd.Parameters.Add("idReqMenBieSer", SqlDbType.Int).Value = idReqMenBieSer;
                //cmd.Parameters.Add("estructuraCarga", SqlDbType.Structured).Value = estructuraCarga;
                //cmd.CommandType = CommandType.StoredProcedure;

                //cn.Open();
                //cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("Pre.sp_ListaEstructuraCargaRequerimientoMensual", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.Add("idReqMenBieSer", SqlDbType.Int).Value = idReqMenBieSer;
                da.SelectCommand.Parameters.Add("estructuraCarga", SqlDbType.Structured).Value = estructuraCarga;
                //da.SelectCommand.Parameters.Add("@FechaAlta", SqlDbType.DateTime);
                //da.SelectCommand.Parameters["@FechaAlta"].Value = Convert.ToDateTime(this.txtFecha.Text);
                da.Fill(dt);

            }
            
            return dt;
        }
        
        #endregion
        #region Reportes
        public List<ReporteRequerimientoMensualSeguimientoPres> TraerReporteRequerimientoMensualSeguimiento(int idReqMenBieSer, int idMoneda)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.TraerReporteRequerimientoMensualSeguimiento(idReqMenBieSer, idMoneda).ToList();
        }
        public List<ReporteRequerimientoMensualSeguimientoDetallePres> TraerReporteRequerimientoMensualSeguimientoDetalle(int idReqMenBieSer, int idMoneda)
        {
            //var contexto = this.UnidadTrabajo as IContexto;
            //return contexto.TraerReporteRequerimientoMensualSeguimientoDetalle(idReqMenBieSer, idMoneda).ToList();

            List<ReporteRequerimientoMensualSeguimientoDetallePres> listaData = new List<ReporteRequerimientoMensualSeguimientoDetallePres>();
            List<ReporteRequerimientoMensualSeguimientoDetallePres> listaClase = new List<ReporteRequerimientoMensualSeguimientoDetallePres>();
            List<ReporteRequerimientoMensualSeguimientoDetallePres> listaDivisionaria = new List<ReporteRequerimientoMensualSeguimientoDetallePres>();
            List<ReporteRequerimientoMensualSeguimientoDetallePres> listaEspecifica = new List<ReporteRequerimientoMensualSeguimientoDetallePres>();
            List<ReporteRequerimientoMensualSeguimientoDetalleForebisePres> listaDetalleMovimiento = new List<ReporteRequerimientoMensualSeguimientoDetalleForebisePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            this.contexto.AumentarLatencia(120);

            listaData = contexto.TraerReporteRequerimientoMensualSeguimientoDetalle(idReqMenBieSer, idMoneda).ToList();
            listaClase = listaData.Where(x => x.nivel == 1).ToList();
            if (listaClase.Count > 0)
            {
                listaDivisionaria = listaData.Where(x => x.nivel == 2).ToList();
                listaEspecifica = listaData.Where(x => x.nivel == 3).ToList();
                listaDetalleMovimiento = contexto.TraerReporteRequerimientoMensualSeguimientoDetalleForebise(idReqMenBieSer, idMoneda).ToList();
            }

            listaEspecifica.ForEach(f => f.listaDetalleMovimiento = listaDetalleMovimiento.FindAll(t => t.idCueCon == f.idCueCon));
            listaDivisionaria.ForEach(f => f.ListaCuentasEspecificas = listaEspecifica.FindAll(t => t.dependencia == f.idCueCon));
            listaClase.ForEach(f => f.ListaDivisionarias = listaDivisionaria.FindAll(t => t.dependencia == f.idCueCon));

            return listaClase;
        }
        public List<ReporteRequerimientoMensualSeguimientoForebisePres> TraerReporteRequerimientoMensualSeguimientoForebise(int idReqMenBieSer, int idMoneda)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerReporteRequerimientoMensualSeguimientoForebise(idReqMenBieSer, idMoneda).ToList();
        }
        public List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> TraerReporteRequerimientoMensualSeguimientoForebiseCabecera(int idReqMenBieSer, int idMoneda)
        {
            List<ReporteRequerimientoMensualSeguimientoForebisePres> listaData = new List<ReporteRequerimientoMensualSeguimientoForebisePres>();
            List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> listaCabecera = new List<ReporteRequerimientoMensualSeguimientoForebiseCabecera>();
            
            var contexto = this.UnidadTrabajo as IContexto;
            this.contexto.AumentarLatencia(120);

            listaData = contexto.TraerReporteRequerimientoMensualSeguimientoForebise(idReqMenBieSer, idMoneda).ToList();
            listaCabecera = listaData.GroupBy(x => new { x.id,x.codigo, x.numero, x.fechaEmision, x.desPresupuesto, x.desSubpresupuesto,
                                                        x.desDireccion, x.desSubDireccion, x.estado, x.desEstado, x.nroCertificacion, x.nroOrden,
                                                        x.importeCertificacion, x.importeOrden
            })
                .Select(r => new ReporteRequerimientoMensualSeguimientoForebiseCabecera
                {
                    id = r.Key.id,
                    codigo = r.Key.codigo,
                    numero = r.Key.numero,
                    fechaEmision = r.Key.fechaEmision,
                    desPresupuesto = r.Key.desPresupuesto,
                    desSubpresupuesto = r.Key.desSubpresupuesto,
                    desDireccion = r.Key.desDireccion,
                    desSubDireccion = r.Key.desSubDireccion,
                    estado = r.Key.estado,
                    desEstado = UtilitarioComun.devuelveCadenaMayusculaPrimerCaracter(r.Key.desEstado.ToLower()),
                    nroCertificacion = r.Key.nroCertificacion,
                    nroOrden = r.Key.nroOrden,
                   
                    importeCertificacion = r.Key.importeCertificacion,//Convert.ToDecimal(r.Sum(y => y.importeCertificacion)),
                    importeOrden = r.Key.importeOrden//Convert.ToDecimal(r.Sum(y => y.importeOrden))
                }).ToList();
            listaCabecera.ForEach(f => f.ListaDetalles = listaData.FindAll(t => t.id == f.id && t.codigo == f.codigo));

            return listaCabecera;
        }
        
        #endregion
    }
}
