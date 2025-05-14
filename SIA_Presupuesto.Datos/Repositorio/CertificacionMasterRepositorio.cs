using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class CertificacionMasterRepositorio : Repositorio<CertificacionMaster>, ICertificacionMasterRepositorio
    {
        public CertificacionMasterRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }
        #region Operaciones
        public bool AnularCertificacionMaster(int opcion, int idCerMas, int tipoReq, string nomUsuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return (bool)contexto.AnularCertificacionMaster(opcion, idCerMas, tipoReq, nomUsuario).FirstOrDefault();
        }
        
        #endregion

        #region Listas
        public List<CertificacionMasterPres> TraerListaCertificacionMaster(int anio)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaCertificacionMaster(anio).ToList();
        }
        public List<Forebi> TraerListaForebiTodos()
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var query = (
                            from f in contexto.TraerListaForebise(1)
                            select new Forebi
                            {
                                idForebi = f.dcid,
                                codigo = f.codigo,
                                numero = f.numero,
                                fechaEmision = f.fechaEmision,
                                idGruPre = f.idGruPre,
                                idPresupuesto = f.idPresupuesto,
                                idSubPresupuesto = f.idSubPresupuesto,
                                desGruPresupuesto = f.desGruPresupuesto,
                                desPresupuesto = f.desPresupuesto,
                                desSubPresupuesto = f.desSubPresupuesto,
                                idDireccion = f.idDireccion,
                                idSubdireccion = f.idSubdireccion,
                                desDireccion = f.desDireccion,
                                desSubDireccion = f.desSubDireccion,
                                justificacion = f.justificacion,
                                estadoAD = f.estadoAD,
                                usuADA = f.usuADA,
                                fechaADA = f.fechaADA,
                                estadoCER = f.estadoCER,
                                usuCER = f.usuCER,
                                fechaCER = f.fechaCER,
                                esAnual = f.esAnual,
                                estado = f.estado,
                            }
                ).OrderByDescending(o => o.fechaEmision).ToList();

            return query; 
        }
        public List<Forese> TraerListaForeseTodos()
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var query = (
                            from f in contexto.TraerListaForebise(2)
                            select new Forese
                            {
                                idForese = f.dcid,
                                codigo = f.codigo,
                                numero = f.numero,
                                fechaEmision = f.fechaEmision,
                                idGruPre = f.idGruPre,
                                idPresupuesto = f.idPresupuesto,
                                idSubPresupuesto = f.idSubPresupuesto,
                                desGruPresupuesto = f.desGruPresupuesto,
                                desPresupuesto = f.desPresupuesto,
                                desSubPresupuesto = f.desSubPresupuesto,
                                idDireccion = f.idDireccion,
                                idSubdireccion = f.idSubdireccion,
                                desDireccion = f.desDireccion,
                                desSubDireccion = f.desSubDireccion,
                                justificacion = f.justificacion,
                                estadoAD = f.estadoAD,
                                usuADA = f.usuADA,
                                fechaADA = f.fechaADA,
                                estadoCER = f.estadoCER,
                                usuCER = f.usuCER,
                                fechaCER = f.fechaCER,
                                esAnual = f.esAnual,
                                estado = f.estado,
                            }
                ).OrderByDescending(o => o.fechaEmision).ToList();

            return query;
        }
        #endregion

        #region Busquedas
        public Forebi BuscarForebi(int idForebi)
        {
            Forebi obj = null;
            var contexto = this.UnidadTrabajo as IContexto;
            obj = contexto.Forebi.Where(x => x.idForebi == idForebi).SingleOrDefault();
            obj.ListaForebiDetalle = obj != null ? contexto.ForebiDetalle.Where(x => x.idForebi == obj.idForebi).ToList() : null;
            //obj.ListaForeDetallePoco = contexto.TraerListaFormatoRequerimientoDetalle(obj.idForebi, 1).Select(x => new ForeDetallePoco
            //{
            //    idDetalle = x.idDetalle,
            //    idCabecera = (int)x.idCabecera,
            //    descripcion = x.descripcion,
            //    unidad = x.unidad,
            //    cantidad = (decimal)x.cantidad,
            //    precio = x.precio,
            //    subTotal = x.subTotal
            //}).OrderByDescending(o => o.idDetalle).ToList();

            return obj;
        }
        public Forese BuscarForese(int idForese)
        {
            Forese obj = null;
            var contexto = this.UnidadTrabajo as IContexto;
            obj = contexto.Forese.Where(x => x.idForese == idForese).SingleOrDefault();
            obj.ListaForeseDetalle = contexto.ForeseDetalle.Where(x => x.idForese == obj.idForese).ToList();
            //obj.ListaForeDetallePoco = contexto.TraerListaFormatoRequerimientoDetalle(obj.idForese, 2).Select(x => new ForeDetallePoco
            //{
            //    idDetalle = x.idDetalle,
            //    idCabecera = (int)x.idCabecera,
            //    descripcion = x.descripcion,
            //    unidad = x.unidad,
            //    cantidad = (decimal)x.cantidad,
            //    precio = x.precio,
            //    subTotal = x.subTotal
            //}).OrderByDescending(o => o.idDetalle).ToList();
            return obj;
        }
        public ForeDetallePoco BuscarForebiDetallePoco(int idForeDet)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var query = (
                            from df in contexto.ForebiDetalle
                            where df.idForebiDet == idForeDet
                            select new ForeDetallePoco
                            {
                                idDetalle = df.idForebiDet,
                                idCabecera = (int)df.idForebi,
                                descripcion = df.desProducto,
                                unidad = df.unidad,
                                cantidad = (decimal)df.cantidad
                            }
                ).SingleOrDefault();

            return query;
        }
        public ForeDetallePoco BuscarForeseDetallePoco(int idForeDet)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var query = (
                            from df in contexto.ForeseDetalle
                            where df.idForeseDet == idForeDet
                            select new ForeDetallePoco
                            {
                                idDetalle = df.idForeseDet,
                                idCabecera = (int)df.idForese,
                                descripcion = df.numCuenta + " - " + df.descripcion,
                                unidad = "UNIDAD",
                                cantidad = (decimal)df.cantidad
                            }
                ).SingleOrDefault();

            return query;
        }
        public ValidarForebisePres ValidarForebise(int idCerMas)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.ValidarForebise(idCerMas).SingleOrDefault();
        }
        #endregion

        #region Reportes
        #endregion
    }
}
