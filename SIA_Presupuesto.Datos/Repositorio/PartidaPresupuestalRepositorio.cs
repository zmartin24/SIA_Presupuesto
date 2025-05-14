using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PartidaPresupuestalRepositorio : Repositorio<PartidaPresupuestal>, IPartidaPresupuestalRepositorio
    {
        private IContexto contexto;

        public PartidaPresupuestalRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        public PartidaPresupuestal BuscarPorCodigo(int idParPre)
        {
            // return repositorio.TraerPorID(idParPre);

            PartidaPresupuestal obj = contexto.PartidaPresupuestal.Where(x => x.idParPre == idParPre && x.estado != 1).FirstOrDefault();
            obj.ListaPartidaPresupuestalCuenta = (
                                        from pc in this.contexto.PartidaPresupuestalCuenta
                                        where
                                            pc.idParPre == idParPre && pc.estado == true
                                        select pc
                                    ).ToList();
            obj.cuentaContable = (
                                        from pc in this.contexto.PartidaPresupuestalCuenta
                                        join cc in this.contexto.CuentaContable on pc.idCueCon equals cc.idCueCon
                                        where
                                            pc.idParPre == idParPre && pc.estado == true
                                        orderby pc.anio
                                        select cc

                                    ).FirstOrDefault();

            
            return obj;
        }
        public List<PartidaPresupuestalPres> TraerListaPartidaPresupuestal()
        {
            return this.contexto.TraerListaPartidaPresupuestal().ToList();
        }
        public List<PartidaPresupuestalCuentaPoco> TraerListaPartidaPresupuestalCuentaPoco(int idParPre)
        {
            var query = (
                    from pc in this.contexto.PartidaPresupuestalCuenta
                    join cc in this.contexto.CuentaContable on pc.idCueCon equals cc.idCueCon
                    where
                        pc.idParPre == idParPre && pc.estado == true
                    select new PartidaPresupuestalCuentaPoco
                    {
                        idParPreCue = pc.idParPreCue,
                        idParPre = pc.idParPre,
                        idCueCon = cc.idCueCon,
                        numCuenta = cc.numCuenta,
                        desCuenta = cc.descripcion,
                        anio = (Int32)cc.PlanCuenta.anioEjercicio,
                        usuCrea = pc.usuCrea,
                        fechaCrea = pc.fechaCrea,
                        usuEdita = pc.usuEdita,
                        fechaEdita = pc.fechaEdita,
                        estado = (bool)pc.estado
                    }
                ).OrderByDescending(x => x.anio).ToList();
            return query;
        }
        public List<PartidaPresupuestalPrecioPres> TraerPartidaPresupuestalPrecio(int tipo, string descripcion, int idMoneda)
        {
            return this.contexto.TraerPartidaPresupuestalPrecio(tipo, descripcion, idMoneda).ToList();
        }
    }
}
