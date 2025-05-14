using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class PartidaPresupuestalAsignarCuentaPresentador
    {
        private readonly IPartidaPresupuestalAsignarCuentaVista partidaPresupuestalAsignarCuentaVista;

        private IPartidaPresupuestalServicio partidaPresupuestalServicio;
        private IGeneralServicio generalServicio;
        private IOrigenConceptoServicio origenServicio;

        private PartidaPresupuestal partidaPresupuestal;
        private bool esModificacion;
        public PartidaPresupuestalAsignarCuentaPresentador(PartidaPresupuestal partidaPresupuestal, IPartidaPresupuestalAsignarCuentaVista partidaPresupuestalAsignarCuentaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.partidaPresupuestalServicio = _Contenedor.Resolver(typeof(IPartidaPresupuestalServicio)) as IPartidaPresupuestalServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.origenServicio = _Contenedor.Resolver(typeof(IOrigenConceptoServicio)) as IOrigenConceptoServicio;

            this.partidaPresupuestalAsignarCuentaVista = partidaPresupuestalAsignarCuentaVista;
            this.esModificacion = partidaPresupuestal != null;
            this.partidaPresupuestal = partidaPresupuestal ?? new PartidaPresupuestal();
        }

        public void IniciarDatos()
        {
            this.partidaPresupuestalAsignarCuentaVista.tipo = this.partidaPresupuestal.tipo == 1 ? "BIEN" : "SERVICIO";
            this.partidaPresupuestalAsignarCuentaVista.descripcion = this.partidaPresupuestal.descripcion;
            this.partidaPresupuestalAsignarCuentaVista.desUnidad = this.partidaPresupuestal.Unidad.nomUnidad;
            this.partidaPresupuestalAsignarCuentaVista.precio = this.partidaPresupuestal.precio;
            llenarComboCuentas();
        }
        public bool ValidarRegistroExistente()
        {
            PartidaPresupuestal reg = null;
            
            return reg == null;
        }
        public void llenarComboCuentas()
        {
            int anio = (Int32)this.generalServicio.ListaPlanCuenta().OrderByDescending(x => x.anioEjercicio).FirstOrDefault().anioEjercicio;
            this.partidaPresupuestalAsignarCuentaVista.listaCuentaContable = this.generalServicio.ListaCuentaContableDesdeNivel2_BienesServicios(anio).ToList();
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;
            this.partidaPresupuestal.descripcion = this.partidaPresupuestalAsignarCuentaVista.descripcion.ToUpper().Trim();
            this.partidaPresupuestal.precio = this.partidaPresupuestalAsignarCuentaVista.precio;
            this.partidaPresupuestal.cuentaContable = this.partidaPresupuestalAsignarCuentaVista.cuentaContable;
            if (this.esModificacion)
            {
                this.partidaPresupuestal.fechaEdita = DateTime.Now;
                this.partidaPresupuestal.usuEdita = this.partidaPresupuestalAsignarCuentaVista.UsuarioOperacion.NomUsuario;
                resultado = partidaPresupuestalServicio.Modificar(this.partidaPresupuestal);
            }
            else
            {
                this.partidaPresupuestal.fechaCrea = DateTime.Now;
                this.partidaPresupuestal.usuCrea = this.partidaPresupuestalAsignarCuentaVista.UsuarioOperacion.NomUsuario;
                this.partidaPresupuestal.estado = Estados.Activo;
                resultado = partidaPresupuestalServicio.Nuevo(this.partidaPresupuestal);
            }

            return resultado.esCorrecto;
        }
    }
}
