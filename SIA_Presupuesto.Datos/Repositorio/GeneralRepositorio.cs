using Seguridad.Modelo;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class GeneralRepositorio : IGeneralRepositorio
    {

        private IContexto contexto;

        //public UsuarioOperacion  UsuInfo { get; set; }
        public GeneralRepositorio(IContexto contexto)
        {
            this.contexto = contexto;
        }

        public List<Unidad> ListaUnidad()
        {
            var lista = contexto.Unidad.ToList();

            return lista;

        }

        public List<Moneda> ListaMonedas()
        {
            var lista = contexto.Moneda.Where(x => x.idMoneda != 5926).ToList();

            return lista;
        }

        public List<Direccion> ListaDirecciones()
        {
            var lista = contexto.Direccion.Where(x => x.estado != 0).ToList();

            return lista;

        }

        public Direccion BuscarDireccion(int idDireccion)
        {
            var lista = contexto.Direccion.Where(w => w.idDireccion == idDireccion).FirstOrDefault();

            return lista;
        }

        public List<Subdireccion> ListaSubDirecciones()
        {
            var lista = contexto.Subdireccion.Where(x => x.estado != 0).ToList();

            return lista;

        }

        public List<Subdireccion> ListaSubDirecciones(int idDireccion)
        {
            var lista = contexto.Subdireccion.Where(w => w.idDireccion == idDireccion).ToList();

            return lista;

        }

        public Subdireccion BuscarSubDireccion(int idSubdireccion)
        {
            var lista = contexto.Subdireccion.Where(w => w.idSubdireccion == idSubdireccion).FirstOrDefault();

            return lista;
        }

        public List<Area> ListaAreas()
        {
            var lista = contexto.Area.Where(x => x.estado != 0).ToList();

            return lista;
        }

        public Area BuscarArea(int idArea)
        {
            var lista = contexto.Area.Where(w => w.idArea == idArea).FirstOrDefault();

            return lista;

        }

        public List<Area> ListaAreas(int idSubDireccion)
        {
            var lista = contexto.Area.Where(w => w.idSubDireccion == idSubDireccion && w.estado != 0).ToList();

            return lista;

        }

        public List<Producto> ListaProducto()
        {
            var lista = contexto.Producto.Where(w => w.estado).ToList();

            return lista;
        }

        public List<Producto> ListaProducto(string numCuenta)
        {
            DateTime fechaPredeterminada = new DateTime(2100, 12, 31);
            DateTime fechaActual = DateTime.Now.Date;
            int anio = DateTime.Now.Year;

            var lista = (from p in contexto.Producto
                         join pd in contexto.ProductoDenominador on p.idProducto equals pd.idProducto
                         join dc in contexto.DenomCuenta on pd.idDenominador equals dc.idDenominador
                         where p.estado && dc.idCuenta.Equals(numCuenta) &&
                         fechaActual >= pd.fechaDesde && pd.estado &&
                         (pd.fechaHasta == null || (pd.fechaHasta != null && fechaActual <= pd.fechaHasta)) &&
                         dc.anio == anio
                         select p
                        ).ToList();

            return lista;
        }

        public Producto BuscarProducto(int idProducto)
        {
            var lista = contexto.Producto.Where(w => w.idProducto == idProducto).FirstOrDefault();

            return lista;
        }

        public CuentaContable BuscarCuentaContable(int idCueCon)
        {
            var lista = contexto.CuentaContable.Where(w => w.idCueCon == idCueCon).FirstOrDefault();

            return lista;
        }

        public CuentaContable BuscarCuentaContable(string numCuenta, int anio)
        {
            var lista = contexto.CuentaContable.Where(w => w.numCuenta.Equals(numCuenta) && w.PlanCuenta.anioEjercicio == anio && (bool)w.estado).FirstOrDefault();

            return lista;
        }

        public Moneda BuscarMoneda(int idMoneda)
        {
            var lista = contexto.Moneda.Where(w => w.idMoneda == idMoneda).FirstOrDefault();

            return lista;
        }

        public List<CuentaContable> ListaCuentaContable(int anio)
        {
            var lista = (from cc in contexto.CuentaContable
                         join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                         join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                         join cc2 in contexto.CuentaContable on cc1.dependencia equals cc2.idCueCon
                         join gc in contexto.GrupoCuentaDetalle on cc2.idCueCon equals gc.idCueCon
                         where cc.nivel == 3 && pc.anioEjercicio == anio && (bool)cc.estado
                         select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            return lista;
        }

        public List<CuentaContable> ListaCuentaContableDesdeNivel2(int anio)
        {
            var lista = (from cc in contexto.CuentaContable
                         join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                         join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                         join cc2 in contexto.CuentaContable on cc1.dependencia equals cc2.idCueCon
                         join gc in contexto.GrupoCuentaDetalle on cc2.idCueCon equals gc.idCueCon
                         where (cc.nivel == 3) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && (bool)cc.estado
                         select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            var lista1 = (from cc in contexto.CuentaContable
                          join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                          join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                          join gc in contexto.GrupoCuentaDetalle on cc1.idCueCon equals gc.idCueCon
                          where (cc.nivel == 2) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && (bool)cc.estado
                          select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            lista.AddRange(lista1);
            return lista;
        }
        public List<CuentaContable> ListaCuentaContableDesdeNivel2_BienesServicios(int anio)
        {
            var lista = (from cc in contexto.CuentaContable
                         join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                         join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                         join cc2 in contexto.CuentaContable on cc1.dependencia equals cc2.idCueCon
                         join gc in contexto.GrupoCuentaDetalle on cc2.idCueCon equals gc.idCueCon
                         where (cc.nivel == 3) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && (bool)cc.estado && gc.idGruCue == 2
                         select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            var lista1 = (from cc in contexto.CuentaContable
                          join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                          join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                          join gc in contexto.GrupoCuentaDetalle on cc1.idCueCon equals gc.idCueCon
                          where (cc.nivel == 2) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && (bool)cc.estado && gc.idGruCue == 2
                          select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            var listaCapacitaciones = (from cc in contexto.CuentaContable
                          join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                          join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                          where (cc.nivel == 3) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && cc1.numCuenta.Equals("624") && (bool)cc.estado
                          select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            lista.AddRange(lista1);
            lista.AddRange(listaCapacitaciones);
            return lista;
        }

        public List<CuentaContable> ListaCuentaContableDesdeNivel2(int anio, string dato)
        {
            var lista = (from cc in contexto.CuentaContable
                         join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                         join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                         join cc2 in contexto.CuentaContable on cc1.dependencia equals cc2.idCueCon
                         join gc in contexto.GrupoCuentaDetalle on cc2.idCueCon equals gc.idCueCon
                         where
                            (cc.nivel == 3) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && (bool)cc.estado
                            && (
                                (dato.Length < 3) ||
                                (dato.Length >= 3 && cc.numCuenta.Contains(dato)) ||
                                (dato.Length >= 3 && cc.descripcion.Contains(dato))
                            )
                         select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            var lista1 = (from cc in contexto.CuentaContable
                          join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                          join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                          join gc in contexto.GrupoCuentaDetalle on cc1.idCueCon equals gc.idCueCon
                          where
                            (cc.nivel == 2) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && (bool)cc.estado
                            && (
                                (dato.Length < 3) ||
                                (dato.Length >= 3 && cc.numCuenta.Contains(dato)) ||
                                (dato.Length >= 3 && cc.descripcion.Contains(dato))
                            )
                          select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            var listaCapacitaciones = (from cc in contexto.CuentaContable
                          join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
                          join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                          where
                            (cc.nivel == 3) && cc.idTipCtaCon == 72 && pc.anioEjercicio == anio && cc1.numCuenta.Equals("624")  && (bool)cc.estado
                            && (
                                (dato.Length < 3) ||
                                (dato.Length >= 3 && cc.numCuenta.Contains(dato)) ||
                                (dato.Length >= 3 && cc.descripcion.Contains(dato))
                            )
                          select cc).OrderBy(o => o.numCuenta).Distinct().ToList();

            lista.AddRange(lista1);
            lista.AddRange(listaCapacitaciones);

            return lista.ToList().Take(50).ToList();
        }
        public List<CuentaContable> ListaCuentaContableN1(int anio, int tipoRubro)
        {
            //var lista = (from cc in contexto.CuentaContable
            //             join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
            //             where cc.nivel == 1 && pc.anioEjercicio == anio && (bool)cc.estado
            //             select cc).OrderBy(o => o.numCuenta).Distinct().ToList();
            var lista = (
                        contexto.TraerListaCuentaContableRequerimientoBienServicio(anio, 0, 1, tipoRubro)
                        ).OrderBy(o => o.numCuenta).Distinct().ToList();

            return lista;
        }
        public List<CuentaContable> ListaCuentaContableN2(int anio, int depe, int tipoRubro)
        {
            //var lista = (from cc in contexto.CuentaContable
            //             join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
            //             where cc.nivel == 2 && cc.dependencia == depe && pc.anioEjercicio == anio && (bool)cc.estado
            //             select cc).OrderBy(o => o.numCuenta).Distinct().ToList();
            var lista = (
                        contexto.TraerListaCuentaContableRequerimientoBienServicio(anio, depe, 2, tipoRubro)
                        ).OrderBy(o => o.numCuenta).Distinct().ToList();
            return lista;
        }
        public List<CuentaContable> ListaCuentaContableN3(int anio, int depe, int tipoRubro)
        {
            //var lista = (from cc in contexto.CuentaContable
            //             join pc in contexto.PlanCuenta on cc.idPlaCue equals pc.idPlaCue
            //             join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
            //             join cc2 in contexto.CuentaContable on cc1.dependencia equals cc2.idCueCon
            //             join gc in contexto.GrupoCuentaDetalle on cc2.idCueCon equals gc.idCueCon
            //             where cc.nivel == 3 && cc.dependencia == depe && pc.anioEjercicio == anio && (bool)cc.estado
            //             select cc).OrderBy(o => o.numCuenta).Distinct().ToList();
            var lista = (
                        contexto.TraerListaCuentaContableRequerimientoBienServicio(anio, depe, 3, tipoRubro)
                        ).OrderBy(o => o.numCuenta).Distinct().ToList();
            return lista;
        }
        public CuentaContablePoco BuscarCuentaContablePoco(int idCueCon)
        {
            var lista = (
                            from cc in contexto.CuentaContable
                            join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                            join cc2 in contexto.CuentaContable on cc1.dependencia equals cc2.idCueCon
                            //join gc in contexto.GrupoCuentaDetalle on cc2.idCueCon equals gc.idCueCon
                            where cc.idCueCon == idCueCon && cc.nivel == 3 && (bool)cc.estado
                            select new CuentaContablePoco
                            {
                                idCueCon = cc.idCueCon,
                                numCuenta = cc.numCuenta,
                                descripcion = cc.descripcion,
                                idCueConN1 = cc2.idCueCon,
                                numCuentaN1 = cc2.numCuenta,
                                idCueConN2 = cc1.idCueCon,
                                numCuentaN2 = cc1.numCuenta,
                                idPlaCue = cc.idPlaCue,
                                abreviatura = cc.abreviatura,
                                abreviaturaliq = cc.abreviaturaliq,
                                idTipCtaCon = cc.idTipCtaCon,
                                DeudorAcreedor = cc.DeudorAcreedor,
                                anexoPrincipal = cc.anexoPrincipal,
                                anexoSecundario = cc.anexoSecundario,
                                idNivSal = cc.idNivSal,
                                inConBan = cc.inConBan,
                                esManual = cc.esManual,
                                dependencia = cc.dependencia,
                                nivel = cc.nivel,
                                usuCrea = cc.usuCrea,
                                usuEdita = cc.usuEdita,
                                fecCrea = cc.fecCrea,
                                fecEdita = cc.fecEdita,
                                idCatCon = cc.idCatCon,
                                estado = cc.estado
                            }
                         ).FirstOrDefault();

            return lista;
        }
        public CuentaContablePoco BuscarCuentaContablePocoN2(int idCueCon)
        {
            var lista = (
                            from cc in contexto.CuentaContable
                            join cc1 in contexto.CuentaContable on cc.dependencia equals cc1.idCueCon
                            where cc.idCueCon == idCueCon && cc.nivel == 2 && (bool)cc.estado
                            select new CuentaContablePoco
                            {
                                idCueCon = cc.idCueCon,
                                numCuenta = cc.numCuenta,
                                descripcion = cc.descripcion,
                                idCueConN1 = cc1.idCueCon,
                                numCuentaN1 = cc1.numCuenta,
                                idCueConN2 = cc.idCueCon,
                                numCuentaN2 = cc.numCuenta,
                                idPlaCue = cc.idPlaCue,
                                abreviatura = cc.abreviatura,
                                abreviaturaliq = cc.abreviaturaliq,
                                idTipCtaCon = cc.idTipCtaCon,
                                DeudorAcreedor = cc.DeudorAcreedor,
                                anexoPrincipal = cc.anexoPrincipal,
                                anexoSecundario = cc.anexoSecundario,
                                idNivSal = cc.idNivSal,
                                inConBan = cc.inConBan,
                                esManual = cc.esManual,
                                dependencia = cc.dependencia,
                                nivel = cc.nivel,
                                usuCrea = cc.usuCrea,
                                usuEdita = cc.usuEdita,
                                fecCrea = cc.fecCrea,
                                fecEdita = cc.fecEdita,
                                idCatCon = cc.idCatCon,
                                estado = cc.estado
                            }
                         ).FirstOrDefault();

            return lista;
        }
        public List<CuentaContable> TraerListaCuentaContableRubro(int tipoRubro, int anio)
        {
            //int anioPlanCont = (int)contexto.PlanCuenta.OrderByDescending(x => x.anioEjercicio).ToList().FirstOrDefault().anioEjercicio;
            return contexto.TraerListaCuentaContableRubro(tipoRubro, anio).ToList();
        }
        public PlanCuenta BuscarPlanCuenta(int idPlaCue)
        {
            var lista = contexto.PlanCuenta.Where(w => w.idPlaCue == idPlaCue).FirstOrDefault();

            return lista;
        }
        public List<FuenteFinanciamiento> ListaFuenteFinanciamiento()
        {
            return contexto.FuenteFinanciamiento.Where(w => w.estado != 1).ToList();
        }

        public List<SedeLaboral> ListaSedeLaboral()
        {
            return contexto.SedeLaboral.ToList();
        }
        public Cargo BuscarCargo(int idCargo)
        {
            var query = contexto.Cargo.Where(w => w.idCargo == idCargo).FirstOrDefault();
            return query;
        }
        public List<CargoPres> ListaCargos()
        {
            return contexto.TraerDatosCargo().ToList();
        }

        public List<TrabajadorPres> ListaTrabajadores()
        {
            return contexto.TraerDatosTrabajador().ToList();
        }

        public TrabajadorPres BuscarTrabajador(int idTrabajador)
        {
            var query = contexto.TraerDatosTrabajador().Where(w => w.idTrabajador == idTrabajador).FirstOrDefault();

            return query;
        }

        public List<DatoCategoriaLaboral> TraerDatosCategoriaLaboral()
        {
            return contexto.TraerDatosCategoriaLaboral().ToList();
        }

        public List<DatoCondicionLaboral> TraerDatosCondicionLaboral()
        {
            return contexto.TraerDatosCondicionLaboral().ToList();
        }

        public List<DatoRegimenLaboral> TraerDatosRegimenLaboral()
        {
            return contexto.TraerDatosRegimenLaboral().ToList();
        }
        public List<PlanCuenta> ListaPlanCuenta()
        {
            return contexto.PlanCuenta.ToList();
        }
        public List<ProductoPrecioPres> TraerProductoPrecio(string descripcion, int idMoneda)
        {
            return contexto.TraerProductoPrecio(descripcion, idMoneda).ToList();
        }
        public List<OpcionMenuSistemaUsuarioPres> TraerOpcionPorMenuSistemaUsuario(int idUsuario, int idSistema, int idMenu)
        {
            return contexto.TraerOpcionPorMenuSistemaUsuario(idUsuario, idSistema, idMenu).ToList();
        }
        public TipoCambioPresupuesto TraerTipoCambioPresupuesto(int anio, int mes)
        {
            var tipoCambio = (
                                from tc in contexto.TipoCambioPresupuesto

                                where tc.anio <= anio && tc.mes <= mes && tc.estado != 1
                                select tc
                            ).OrderByDescending(x => new { x.anio, x.mes }).FirstOrDefault();
            

            return tipoCambio;
        }
        public decimal TraerTipoCambio(int anio, int mes)
        {
            decimal valorPredeterminado = 0;
            
            var tipoCambio = (
                from tc in contexto.TipoCambioPresupuesto
                where tc.anio <= anio && tc.mes <= mes && tc.estado != 1
                select tc
            ).OrderByDescending(x => new { x.anio, x.mes }).FirstOrDefault()?.valor ?? valorPredeterminado;

            var tipoCambioAnual = (
                                from tc in contexto.TipoCambioAnual

                                where tc.anio <= anio && tc.estado != 1
                                select tc
                            ).OrderByDescending(x => new { x.anio }).FirstOrDefault()?.valor ?? valorPredeterminado;

            return mes > 0 ? tipoCambio : tipoCambioAnual;
        }
        public ProductoPartidaPres BuscarProductoPartida(int tipo, int idProPar)
        {
            var query =
                        contexto.TraerProductoPartida(tipo, idProPar).FirstOrDefault();
            return query;
        }
        public Unidad BuscarUnidadMedida(int idUnidad)
        {
            return contexto.Unidad.Where(x => x.idUnidad == idUnidad).FirstOrDefault();
        }
    }
}
