using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class ListaPartidaPresupuestalCuentaPresentador
    {
        private readonly IListaPartidaPresupuestalCuentaVista listaPartidaPresupuestalCuentaVista;
        private IPartidaPresupuestalServicio partidaPresupuestalServicio;

        private PartidaPresupuestal partidaPresupuestal;
        public ListaPartidaPresupuestalCuentaPresentador(PartidaPresupuestal partidaPresupuestal, IListaPartidaPresupuestalCuentaVista listaPartidaPresupuestalCuentaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.partidaPresupuestalServicio = _Contenedor.Resolver(typeof(IPartidaPresupuestalServicio)) as IPartidaPresupuestalServicio;

            this.listaPartidaPresupuestalCuentaVista = listaPartidaPresupuestalCuentaVista;
            this.partidaPresupuestal = partidaPresupuestal;
        }
        public void Iniciar()
        {
            this.listaPartidaPresupuestalCuentaVista.tipo = this.partidaPresupuestal.tipo == 1 ? "BIEN" : "SERVICIO";
            this.listaPartidaPresupuestalCuentaVista.descripcion = this.partidaPresupuestal.descripcion;
            this.listaPartidaPresupuestalCuentaVista.desUnidad = this.partidaPresupuestal.Unidad.nomUnidad;
            this.listaPartidaPresupuestalCuentaVista.precio = this.partidaPresupuestal.precio;
            //ObtenerDatosListado();

        }
        public void ObtenerDatosListado()
        {
            listaPartidaPresupuestalCuentaVista.listaDatosPrincipales = this.partidaPresupuestalServicio.TraerListaPartidaPresupuestalCuentaPoco(this.partidaPresupuestal.idParPre);
        }
        public PartidaPresupuestal BuscarPorID(int vid)
        {
            return this.partidaPresupuestalServicio.BuscarPorCodigo(vid);
        }
        public bool Anular()
        {
            bool respuesta = false;

            respuesta = this.partidaPresupuestalServicio.AnularPartidaPresupuestalCuenta(this.listaPartidaPresupuestalCuentaVista.partidaPresupuestalCuentaPoco.idParPreCue, this.listaPartidaPresupuestalCuentaVista.UsuarioOperacion.NomUsuario).esCorrecto;

            return respuesta;
        }
    }
}
