using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class SubpresupuestoRepositorio : Repositorio<Subpresupuesto>, ISubpresupuestoRepositorio
    {
        private IContexto contexto;

        public SubpresupuestoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }
        #region Operacion y Busqueda
        public SubPresupuestoPoco BuscarSubPresupuestoPoco(int idSubPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var subpresupuesto = (
                            from sp in contexto.BuscarSubPresupuestoPoco(idSubPresupuesto)
                            select new SubPresupuestoPoco
                            {
                                idSubPresupuesto = sp.idSubpresupuesto,
                                idPresupuesto = sp.idPresupuesto,
                                esObra = sp.esObra,
                                mes = sp.mes,
                                proyecto = sp.proyecto,
                                estado = sp.estado,
                                nombreEstado = sp.nombreEstado,
                                desSubPresupuesto = sp.desSubPresupuesto,
                                desPresupuesto = sp.desPresupuesto,
                                desGrupoPresupuesto = sp.desGrupoPresupuesto,
                                desDireccion = sp.desDireccion,
                                usuCrea = sp.usuCrea,
                                fechaCrea = sp.fechaCrea,
                                usuEdita = sp.usuEdita,
                                fechaEdita = sp.fechaEdita,
                                tipoCambio = (decimal)sp.tipoCambio
                            }).SingleOrDefault();

            return subpresupuesto;
        }
        #endregion

        #region Listas
        public List<Subpresupuesto> TraerListaSubPresupuestoPorPresupuesto(int idPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaSubPresupuestoPorPresupuesto(idPresupuesto).ToList();
        }
        public List<SubPresupuestoPoco> TraerListaSubPresupuesto(int vanio)
        {
            //var subpresupuesto = (
            //                from d in contexto.Subpresupuesto
            //                join c in contexto.ProgramacionAnual on d.idProAnu equals c.idProAnu
            //                where d.estado != 1
            //                select new SubPresupuestoPoco
            //                {
            //                    idSubPresupuesto = d.idSubpresupuesto,
            //                    idPresupuesto = d.idProAnu,
            //                    esObra = d.esObra,
            //                    mes = d.mes,
            //                    proyecto = d.nroProyecto,
            //                    estado = d.estado,
            //                    nombreEstado = (d.estado == 2) ? "Pendiente" : (d.estado == 10) ? "Aprobado" : (d.estado == 60) ? "Liquidado": "",
            //                    desSubPresupuesto = d.descripcion,
            //                    desPresupuesto = c.descripcion
            //                }).ToList();
            //on new { X1 = x.field1, X2 = x.field2 } equals new { X1 = y.field1, X2 = y.field2 }
            
            //var subpresupuesto = (
            //                from d in contexto.Subpresupuesto
            //                join c in contexto.ProgramacionAnual on d.idProAnu equals c.idProAnu
            //                join gp in contexto.GrupoPresupuesto on c.idGruPre equals gp.idGruPre
                            
            //                where d.estado != Estados.Anulado && c.anio == vanio 
            //                select new SubPresupuestoPoco
            //                {
            //                    idSubPresupuesto = d.idSubpresupuesto,
            //                    idPresupuesto = d.idProAnu,
            //                    esObra = d.esObra,
            //                    mes = d.mes,
            //                    proyecto = d.nroProyecto,
            //                    estado = d.estado,
            //                    nombreEstado = (d.estado == 2) ? "Pendiente" : (d.estado == 10) ? "Aprobado" : (d.estado == 60) ? "Liquidado" : "",
            //                    desSubPresupuesto = d.descripcion,
            //                    desPresupuesto = c.descripcion,
            //                    desGrupoPresupuesto = gp.descripcion,
            //                    usuCrea = d.usuCrea,
            //                    fechaCrea = d.fechaCrea,
            //                    usuEdita = d.usuEdita==null? string.Empty: d.usuEdita,
            //                    fechaEdita = d.fechaEdita
            //                }).ToList();


            var subpresupuesto = (
                            from sp in contexto.TraerListaSubPresupuestoPres(vanio)
                            select new SubPresupuestoPoco
                            {
                                idSubPresupuesto = sp.idSubPresupuesto,
                                idPresupuesto = sp.idPresupuesto,
                                esObra = sp.esObra,
                                mes = sp.mes,
                                proyecto = sp.proyecto,
                                estado = sp.estado,
                                nombreEstado = sp.nombreEstado,
                                desSubPresupuesto = sp.desSubPresupuesto,
                                desPresupuesto = sp.desPresupuesto,
                                desGrupoPresupuesto = sp.desGrupoPresupuesto,
                                usuCrea = sp.usuCrea,
                                fechaCrea = sp.fechaCrea,
                                usuEdita = sp.usuEdita,
                                fechaEdita = sp.fechaEdita,
                                tipoCambio = sp.tipoCambio
                            }).ToList();

            return subpresupuesto;
        }
        public List<SubPresupuestoAreaPres> TraerListaSubPresupuestoAreaPres(int idSubPresupuesto)
        {
            List<SubPresupuestoAreaPres> lista = new List<SubPresupuestoAreaPres>();
            List<SubPresupuestoAreaDetallePres> listaDetallada = new List<SubPresupuestoAreaDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaSubPresupuestoAreaPres(idSubPresupuesto).ToList();
            listaDetallada = contexto.TraerListaSubPresupuestoAreaDetallePres(idSubPresupuesto).ToList();
            
            lista.ForEach(f => f.SubPresupuestoAreaDetallePres = listaDetallada.FindAll(t => t.item == f.item));

            return lista;
        }
        public Resultado VerificarSubpresupuesto(int idPresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var res = (
                    from r in contexto.VerificarSubpresupuesto(idPresupuesto)
                    select new Resultado
                    {
                        id = (int)r.idSubpresupuesto,
                        esCorrecto = (bool)r.esCorrecto,
                        mensajeMostrar = r.mensaje
                    }).SingleOrDefault();

            return res;
        }
        #endregion

        #region Reportes y Exportacion
        public List<ReporteSubpresupuestoExportaPres> TraerReporteSubpresupuestoExporta(int idSubPresupuesto, int idMoneda)
        {
            List<ReporteSubpresupuestoExportaPres> lista = new List<ReporteSubpresupuestoExportaPres>();
            List<ReporteSubpresupuestoDetalleExportaPres> listaDetallada = new List<ReporteSubpresupuestoDetalleExportaPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerReporteSubpresupuestoExporta(idSubPresupuesto, idMoneda).ToList();
            listaDetallada = contexto.TraerReporteSubpresupuestoDetalleExporta(idSubPresupuesto, idMoneda).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteSubpresupuestoDetalleExportaPres = listaDetallada.FindAll(t => t.item == f.item);
                f.posicion += cantDetalle;
                if (f.ListaReporteSubpresupuestoDetalleExportaPres != null)
                    cantDetalle += f.ListaReporteSubpresupuestoDetalleExportaPres.Count();
            });

            return lista;
        }
        #endregion
    }
}
