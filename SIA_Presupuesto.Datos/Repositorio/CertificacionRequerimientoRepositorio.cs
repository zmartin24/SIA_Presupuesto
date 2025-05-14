using Seguridad.Log;
using Seguridad.Modelo;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class CertificacionRequerimientoRepositorio : Repositorio<CertificacionRequerimiento>, ICertificacionRequerimientoRepositorio
    {
        public CertificacionRequerimientoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }
        public bool ActualizarEstadoRequerimientoForebise(int opcion, int tipo, int idForebise, int estado, string usuario, DateTime fecha)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);

            return (bool)contexto.ActualizarEstadoRequerimientoForebise(opcion, tipo, idForebise, estado, usuario, fecha).ToList().FirstOrDefault();
        }
        public bool ActualizarEstadoCertificacionPresupuestal(int idCerReq, string opcion, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(60);

            return (bool)contexto.ActualizarEstadoCertificacionPresupuestal(idCerReq,opcion, usuario).ToList().FirstOrDefault();
        }
        public bool ActualizarImporteCertificacion(int idCerReq, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(60);

            return (bool)contexto.ActualizarImporteCertificacion(idCerReq, usuario).ToList().FirstOrDefault();
        }
        public void ActualizarTotalCertificacionRequerimiento(int idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            contexto.ActualizarTotalCertificacionRequerimiento(idCerReq);
        }
        public Resultado ValidaFechaCertificacion(DateTime fechaEmision, int numero, string opcion, int? idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return (
                    from q in contexto.ValidaFechaCertificacion(fechaEmision, numero, opcion, idCerReq)
                    select new Resultado
                    {
                        esCorrecto = (bool)q.resultado,
                        mensajeMostrar = q.mensaje
                    }).SingleOrDefault();
        }
        #region Listas
        public List<Forebi> TraerListaForebiPorSubPresupuesto(int idSubPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.Forebi.Where(x => x.estado == 152 && x.idSubPresupuesto == idSubPresupuesto).OrderByDescending(f => f.fechaEmision).ToList();
        }
        public List<Forese> TraerListaForesePorSubPresupuesto(int idSubPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.Forese.Where(x => x.estado != 111 && x.idSubPresupuesto == idSubPresupuesto).OrderByDescending(f => f.fechaEmision).ToList();
        }
        public List<ForeDetallePoco> TraerListaForebiDetallePoco(int idForebi)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var query = (
                            from df in TraerListaFormatoRequerimientoDetalle(idForebi, 1)
                            select new ForeDetallePoco
                            {
                                idDetalle = df.idDetalle,
                                idCabecera = (int)df.idCabecera,
                                descripcion = df.descripcion,
                                unidad = df.unidad,
                                cantidad = (decimal)df.cantidad
                            }
                ).OrderByDescending(o => o.idDetalle).ToList();

            return query;
        }
        public List<ForeDetallePoco> TraerListaForeseDetallePoco(int idForese)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var query = (
                            from df in TraerListaFormatoRequerimientoDetalle(idForese, 2)
                            select new ForeDetallePoco
                            {
                                idDetalle = df.idDetalle,
                                idCabecera = (int)df.idCabecera,
                                descripcion = df.descripcion,
                                unidad = "UNIDAD",
                                cantidad = (decimal)df.cantidad
                            }
                ).OrderByDescending(o => o.idDetalle).ToList();

            return query;
        }
        public List<ForeDetallePoco> TraerListaFormatoRequerimientoDetalle(int idFore, int tipo)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var query = (
                            from df in contexto.TraerListaFormatoRequerimientoDetalle(idFore, tipo)
                            select new ForeDetallePoco
                            {
                                idDetalle = df.idDetalle,
                                idCabecera = (int)df.idCabecera,
                                descripcion = df.descripcion,
                                unidad = df.unidad,
                                cantidad = (decimal)df.cantidad,
                                precio = df.precio,
                                subTotal = df.subTotal
                            }
                ).OrderByDescending(o => o.idDetalle).ToList();

            return query;
        }

        public List<SubPresupuestoDetallePres> TraerListaSubPresupuestoDetalle(int idSubPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            return contexto.TraerListaSubPresupuestoDetalle(idSubPresupuesto).ToList();
        }
        public List<CertificacionDetallePres> TraerListaCertificacionDetalle(int? idCerMas, int? idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaCertificacionDetalle(idCerMas, idCerReq).ToList();
        }
        public List<CertificacionRequerimientoPres> TraerListaCertificacionRequerimiento(int idCerMas)
        {
            List<CertificacionRequerimientoPres> lista = new List<CertificacionRequerimientoPres>();
            List<CertificacionDetallePres> listaDetallada = new List<CertificacionDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaCertificacionRequerimiento(idCerMas).ToList();
            listaDetallada = contexto.TraerListaCertificacionDetalle(idCerMas, 0).ToList();

            lista.ForEach(f => f.CertificacionDetallePres = listaDetallada.FindAll(t => t.idCerReq == f.idCerReq));

            return lista;
        }
        public List<PrecioBienServicioPres> TraerListaPrecioBienServicio(int anio, int idProSer, int tipo)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaPrecioBienServicio(anio, idProSer, tipo).ToList();
        }
        public List<PrecioBienServicioPres> TraerListaPrecioBienServicioRequerimiento(int anio, int idProducto, int idCueCon, int idReqBieSer, int tipo)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaPrecioBienServicioRequerimiento(anio, idProducto, idCueCon, idReqBieSer, tipo).ToList();
        }
        public List<CertificacionRequerimientoExportaPres> TraerListaCertificacionRequerimientoExporta(int tipoReq, int anio)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(240);
            return contexto.TraerListaCertificacionRequerimientoExporta(tipoReq, anio).ToList();
        }
        public List<ForeDetallePoco> TraerListaCertificacionDetalleAmpiacion(int idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var queryCertificacionMensual = (
                            from cr in contexto.CertificacionRequerimiento
                            join d in contexto.CertificacionDetalle on cr.idCerReq equals d.idCerReq
                            join cc in contexto.CuentaContable on d.idCueCon equals cc.idCueCon
                            join sp in contexto.Subpresupuesto on cr.idPresupuesto equals sp.idSubpresupuesto
                            where
                                cr.idCerReq == idCerReq && cr.nivelPresupuesto == 3 && d.esAmpliacion == true && d.estado != 1
                            select new ForeDetallePoco
                            {
                                idCerDet = d.idCerDet,
                                idDetalle = 0,
                                idCabecera = 0,
                                descripcion = "",
                                unidad = "UNIDAD",
                                precio = (decimal)d.precio,
                                cantidad = (decimal)d.cantidad,
                                subTotal = (decimal)d.subTotal,
                                idProAnuReaMen = d.idProAnuReaMen,
                                tipoDet = d.tipoProRea,
                                idCueCon = d.idCueCon,
                                numCuenta = cc.numCuenta,
                                saldoSoles = 0,
                                saldoDolares = 0
                            }
                            ).OrderByDescending(o => o.idCerDet).ToList();

            var queryCertificacionAnual = (
                            from cr in contexto.CertificacionRequerimiento
                            join d in contexto.CertificacionDetalle on cr.idCerReq equals d.idCerReq
                            join cc in contexto.CuentaContable on d.idCueCon equals cc.idCueCon
                            join p in contexto.ProgramacionAnual on cr.idPresupuesto equals p.idProAnu
                            where
                                cr.idCerReq == idCerReq && cr.nivelPresupuesto == 2 && d.esAmpliacion == true && d.estado != 1
                            select new ForeDetallePoco
                            {
                                idCerDet = d.idCerDet,
                                idDetalle = 0,
                                idCabecera = 0,
                                descripcion = "",
                                unidad = "UNIDAD",
                                precio = (decimal)d.precio,
                                cantidad = (decimal)d.cantidad,
                                subTotal = (decimal)d.subTotal,
                                idProAnuReaMen = d.idProAnuReaMen,
                                tipoDet = d.tipoProRea,
                                idCueCon = d.idCueCon,
                                numCuenta = cc.numCuenta,
                                saldoSoles = 0,
                                saldoDolares = 0
                            }
                            ).OrderByDescending(o => o.idCerDet).ToList();

            queryCertificacionMensual.AddRange(queryCertificacionAnual);

            return queryCertificacionMensual;
        }
        public List<SubPresupuestoPoco> TraerListaSubPresupuestoPocoPorIdCerReq(int idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var query = (
                            from cr in contexto.CertificacionRequerimientoSubprespuesto
                            join sp in contexto.Subpresupuesto on cr.idSubpresupuesto equals sp.idSubpresupuesto
                            join pa in contexto.ProgramacionAnual on sp.idProAnu equals pa.idProAnu
                            join gp in contexto.GrupoPresupuesto on pa.idGruPre equals gp.idGruPre
                            where
                                cr.idCerReq == idCerReq && cr.estado == true
                            select new SubPresupuestoPoco
                            {
                                idSubPresupuesto = cr.idSubpresupuesto,
                                desSubPresupuesto = sp.descripcion,
                                idPresupuesto = sp.idProAnu,
                                desPresupuesto = pa.descripcion,
                                idGrupoPresupuesto = (Int32)pa.idGruPre,
                                desGrupoPresupuesto = gp.descripcion,
                                anio = pa.anio.ToString(),
                                mes = sp.mes,
                                esObra = sp.esObra,
                                esEncargo = sp.esEncargo,
                                esActividadCampo = sp.esActividadCampo,
                                esErradicacion = sp.esErradicacion,
                                esLiquidado = sp.esLiquidado,
                                proyecto = sp.nroProyecto
                            }
                            ).OrderByDescending(o => new {o.mes, o.desSubPresupuesto}).ToList();

           

            return query;
        }
        public List<UsuarioCorreoPres> TraerListaUsuarioCorreo()
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaUsuarioCorreo().ToList();
        }
        public List<OrdenPorCertificacionPres> TraerListaOrdenPorCertificacion(int idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaOrdenPorCertificacion(idCerReq).ToList();
        }

        #endregion

        #region Busquedas 

        public CertificacionRequerimiento BuscarPorCodigo(int idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var query = (
                            from cr in contexto.CertificacionRequerimiento
                            where
                                cr.idCerReq == idCerReq
                            select cr
                ).FirstOrDefault();

            return query;
        }

        public decimal TraerImporteCotizacionPorCertificacion(int idCerReq)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            
            return contexto.TraerImporteCotizacionPorCertificacion(idCerReq).FirstOrDefault().Value;
        }

        public int TraerUltimoNumeroCertificacion(int anio)
        {
            int num = 0;
            var contexto = this.UnidadTrabajo as IContexto;
            num = contexto.CertificacionRequerimiento.Where(o => o.fechaEmision.Year == anio).ToList().Count > 0 ? contexto.CertificacionRequerimiento.Where(o => o.fechaEmision.Year == anio).Select(s => s.numero).Max() + 1 : 1;
            return num;
        }
        public SubPresupuestoImporteCertificacion_Pres TraerSubPresupuestoImporteCertificacion(int idSubPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.TraerSubPresupuestoImporteCertificacion(idSubPresupuesto).FirstOrDefault();
        }
        public VerificaCertificacionDetallePres VerificaCertificacionDetalle(int? idCerReq,int? idCerDet)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.VerificaCertificacionDetalle(idCerReq, idCerDet).FirstOrDefault();
        }
        public decimal TraerCantPendiente(int idForReqDet, int tipoReq)
        {
            decimal cant = 0;
            var contexto = this.UnidadTrabajo as IContexto;
            cant = contexto.TraerCantidadPendienteCertificar(idForReqDet, tipoReq).SingleOrDefault().Value;
            
            return cant;
        }
        public decimal TraerImporteMinCer()
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return (decimal)contexto.TraerImporteMinCer().SingleOrDefault().importeMinCer;
        }
        #endregion

        #region Reportes
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal(int idCerReq, bool esAmpliacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerReporteCertificacionPresupuestal(idCerReq, esAmpliacion).ToList();
        }
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestalVarios(string idsCerReq, bool esAmpliacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerReporteCertificacionPresupuestalVarios(idsCerReq, esAmpliacion).ToList();
        }
        #endregion
    }
}