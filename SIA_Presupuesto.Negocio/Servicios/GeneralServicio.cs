using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class GeneralServicio : IGeneralServicio
    {

        private IGeneralRepositorio repoGeneral;

        public GeneralServicio(IGeneralRepositorio repoGeneral)
        {
            this.repoGeneral = repoGeneral;
        }

        public List<Direccion> ListaDirecciones()
        {
            return repoGeneral.ListaDirecciones();
        }

        public List<Unidad> ListaUnidad()
        {
            return repoGeneral.ListaUnidad();
        }

        public List<Moneda> ListaMonedas()
        {
            return repoGeneral.ListaMonedas();
        }

        public List<Subdireccion> ListaSubDirecciones()
        {
            return repoGeneral.ListaSubDirecciones();
        }

        public List<Subdireccion> ListaSubDirecciones(int idDireccion)
        {
            return repoGeneral.ListaSubDirecciones(idDireccion);
        }

        public List<Area> ListaAreas()
        {
            return repoGeneral.ListaAreas();
        }

        public List<Area> ListaAreas(int idSubDireccion)
        {
            return repoGeneral.ListaAreas(idSubDireccion);
        }

        public List<CuentaContable> ListaCuentaContable(int anio)
        {
            return repoGeneral.ListaCuentaContable(anio);
        }

        public List<CuentaContable> ListaCuentaContableDesdeNivel2(int anio)
        {
            return repoGeneral.ListaCuentaContableDesdeNivel2(anio);
        }
        public List<CuentaContable> ListaCuentaContableDesdeNivel2_BienesServicios(int anio)
        {
            return repoGeneral.ListaCuentaContableDesdeNivel2_BienesServicios(anio);
        }
        public List<CuentaContable> ListaCuentaContableDesdeNivel2(int anio, string dato)
        {
            return repoGeneral.ListaCuentaContableDesdeNivel2(anio, dato);
        }

        public List<Producto> ListaProducto()
        {
            return repoGeneral.ListaProducto();
        }

        public List<Producto> ListaProducto(string numCuenta)
        {
            return repoGeneral.ListaProducto(numCuenta);
        }

        public List<CuentaContable> ListaCuentaContableN1(int anio, int tipoRubro)
        {
            return repoGeneral.ListaCuentaContableN1(anio, tipoRubro);
        }
        public List<CuentaContable> ListaCuentaContableN2(int anio, int depe, int tipoRubro)
        {
            return repoGeneral.ListaCuentaContableN2(anio, depe, tipoRubro);
        }
        public List<CuentaContable> ListaCuentaContableN3(int anio, int depe, int tipoRubro)
        {
            return repoGeneral.ListaCuentaContableN3(anio, depe, tipoRubro);
        }

        public Direccion BuscarDireccion(int idDireccion)
        {
            return repoGeneral.BuscarDireccion(idDireccion);
        }

        public Subdireccion BuscarSubDireccion(int idSubdireccion)
        {
            return repoGeneral.BuscarSubDireccion(idSubdireccion);
        }

        public Area BuscarArea(int idArea)
        {
            return repoGeneral.BuscarArea(idArea);
        }

        public Producto BuscarProducto(int idProducto)
        {
            return repoGeneral.BuscarProducto(idProducto);
        }
        public Moneda BuscarMoneda(int idMoneda)
        {
            return repoGeneral.BuscarMoneda(idMoneda);
        }

        public CuentaContable BuscarCuentaContable(int idCueCon)
        {
            return repoGeneral.BuscarCuentaContable(idCueCon);
        }
        public CuentaContablePoco BuscarCuentaContablePoco(int idCueCon)
        {
            return repoGeneral.BuscarCuentaContablePoco(idCueCon);
        }
        public CuentaContablePoco BuscarCuentaContablePocoN2(int idCueCon)
        {
            return repoGeneral.BuscarCuentaContablePocoN2(idCueCon);
        }
        public List<CuentaContable> TraerListaCuentaContableRubro(int tipoRubro, int anio)
        {
            return repoGeneral.TraerListaCuentaContableRubro(tipoRubro, anio);
        }
        public PlanCuenta BuscarPlanCuenta(int idPlaCue)
        {
            return repoGeneral.BuscarPlanCuenta(idPlaCue);
        }
        public List<FuenteFinanciamiento> ListaFuenteFinanciamiento()
        {
            return repoGeneral.ListaFuenteFinanciamiento();
        }

        public CuentaContable BuscarCuentaContable(string numCuenta, int anio)
        {
            return repoGeneral.BuscarCuentaContable(numCuenta, anio);
        }

        public List<SedeLaboral> ListaSedeLaboral()
        {
            return repoGeneral.ListaSedeLaboral();
        }

        public List<CargoPres> ListaCargos()
        {
            return repoGeneral.ListaCargos();
        }
        public Cargo BuscarCargo(int idCargo)
        {
            return repoGeneral.BuscarCargo(idCargo);
        }
        public List<TrabajadorPres> ListaTrabajadores()
        {
            return repoGeneral.ListaTrabajadores();
        }
        public TrabajadorPres BuscarTrabajador(int idTrabajador)
        {
            return repoGeneral.BuscarTrabajador(idTrabajador);
        }

        public List<DatoCategoriaLaboral> TraerDatosCategoriaLaboral()
        {
            return repoGeneral.TraerDatosCategoriaLaboral();
        }
        public List<DatoCondicionLaboral> TraerDatosCondicionLaboral()
        {
            return repoGeneral.TraerDatosCondicionLaboral();
        }
        public List<DatoRegimenLaboral> TraerDatosRegimenLaboral()
        {
            return repoGeneral.TraerDatosRegimenLaboral();
        }
        public List<PlanCuenta> ListaPlanCuenta()
        {
            return repoGeneral.ListaPlanCuenta();
        }
        public List<ProductoPrecioPres> TraerProductoPrecio(string descripcion, int idMoneda)
        {
            return repoGeneral.TraerProductoPrecio(descripcion, idMoneda);
        }
        public List<OpcionMenuSistemaUsuarioPres> TraerOpcionPorMenuSistemaUsuario(int idUsuario, int idSistema, int idMenu)
        {
            return repoGeneral.TraerOpcionPorMenuSistemaUsuario(idUsuario, idSistema, idMenu);
        }
        public TipoCambioPresupuesto TraerTipoCambioPresupuesto(int anio, int mes)
        {
            return repoGeneral.TraerTipoCambioPresupuesto(anio, mes);
        }
        public decimal TraerTipoCambio(int anio, int mes)
        {
            return repoGeneral.TraerTipoCambio(anio, mes);
        }
        public ProductoPartidaPres BuscarProductoPartida(int tipo, int idProPar)
        {
            return repoGeneral.BuscarProductoPartida(tipo, idProPar);
        }
        public Unidad BuscarUnidadMedida(int idUnidad)
        {
            return repoGeneral.BuscarUnidadMedida(idUnidad);
        }
    }
}
