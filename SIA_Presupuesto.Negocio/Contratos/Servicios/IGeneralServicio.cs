using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IGeneralServicio
    {
        List<Direccion> ListaDirecciones();

        List<Subdireccion> ListaSubDirecciones();

        List<Area> ListaAreas();

        List<CuentaContable> ListaCuentaContable(int anio);

        List<CuentaContable> ListaCuentaContableDesdeNivel2(int anio);
        List<CuentaContable> ListaCuentaContableDesdeNivel2_BienesServicios(int anio);
        List<CuentaContable> ListaCuentaContableDesdeNivel2(int anio, string dato);

        List<Subdireccion> ListaSubDirecciones(int idDireccion);

        List<Area> ListaAreas(int idSubDireccion);

        List<Unidad> ListaUnidad();

        List<Moneda> ListaMonedas();

        List<Producto> ListaProducto();

        List<Producto> ListaProducto(string numCuenta);

        Direccion BuscarDireccion(int idDireccion);

        Subdireccion BuscarSubDireccion(int idSubdireccion);

        Area BuscarArea(int idArea);

        Producto BuscarProducto(int idProducto);

        Moneda BuscarMoneda(int idMoneda);

        CuentaContable BuscarCuentaContable(int idCueCon);
        List<CuentaContable> ListaCuentaContableN1(int anio, int tipoRubro);
        List<CuentaContable> ListaCuentaContableN2(int anio, int depe, int tipoRubro);
        List<CuentaContable> ListaCuentaContableN3(int anio, int depe, int tipoRubro);

        CuentaContablePoco BuscarCuentaContablePoco(int idCueCon);
        CuentaContablePoco BuscarCuentaContablePocoN2(int idCueCon);
        List<CuentaContable> TraerListaCuentaContableRubro(int tipoRubro, int anio);
        PlanCuenta BuscarPlanCuenta(int idPlaCue);
        List<FuenteFinanciamiento> ListaFuenteFinanciamiento();
        CuentaContable BuscarCuentaContable(string numCuenta, int anio);
        List<SedeLaboral> ListaSedeLaboral();
        List<CargoPres> ListaCargos();
        Cargo BuscarCargo(int idCargo);
        List<TrabajadorPres> ListaTrabajadores();
        TrabajadorPres BuscarTrabajador(int idTrabajador);
        List<DatoCategoriaLaboral> TraerDatosCategoriaLaboral();
        List<DatoCondicionLaboral> TraerDatosCondicionLaboral();
        List<DatoRegimenLaboral> TraerDatosRegimenLaboral();
        List<PlanCuenta> ListaPlanCuenta();
        List<ProductoPrecioPres> TraerProductoPrecio(string descripcion, int idMoneda);
        List<OpcionMenuSistemaUsuarioPres> TraerOpcionPorMenuSistemaUsuario(int idUsuario, int idSistema, int idMenu);
        TipoCambioPresupuesto TraerTipoCambioPresupuesto(int anio, int mes);
        decimal TraerTipoCambio(int anio, int mes);
        ProductoPartidaPres BuscarProductoPartida(int tipo, int idProPar);
        Unidad BuscarUnidadMedida(int idUnidad);
    }
}
