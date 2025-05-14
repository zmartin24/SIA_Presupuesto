using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class PartidaPresupuestalPresentador
    {
        private readonly IPartidaPresupuestalVista partidaPresupuestalVista;

        private IPartidaPresupuestalServicio partidaPresupuestalServicio;
        private IGeneralServicio generalServicio;
        private IOrigenConceptoServicio origenServicio;

        private PartidaPresupuestal partidaPresupuestal;
        private bool esModificacion;
        public PartidaPresupuestalPresentador(PartidaPresupuestal partidaPresupuestal, IPartidaPresupuestalVista partidaPresupuestalVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.partidaPresupuestalServicio = _Contenedor.Resolver(typeof(IPartidaPresupuestalServicio)) as IPartidaPresupuestalServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.origenServicio = _Contenedor.Resolver(typeof(IOrigenConceptoServicio)) as IOrigenConceptoServicio;

            this.partidaPresupuestalVista = partidaPresupuestalVista;
            this.esModificacion = partidaPresupuestal != null;
            this.partidaPresupuestal = partidaPresupuestal ?? new PartidaPresupuestal();
        }

        public void IniciarDatos()
        {
            partidaPresupuestalVista.listaTipo = PredeterminadoHelper.ListarTipoRequerimiento();
            partidaPresupuestalVista.listaUnidad = this.generalServicio.ListaUnidad();
            partidaPresupuestalVista.tipo = 1; //Unidad por defecto
            partidaPresupuestalVista.idUnidad = 4; //Unidad por defecto
            llenarComboCuentas();
            if (this.esModificacion)
            {
                partidaPresupuestalVista.tipo = partidaPresupuestal.tipo;
                partidaPresupuestalVista.descripcion = partidaPresupuestal.descripcion;
                partidaPresupuestalVista.idUnidad = (Int32)partidaPresupuestal.idUnidad;
                partidaPresupuestalVista.precio = partidaPresupuestal.precio;
            }
        }
        public bool ValidarRegistroExistente()
        {
            PartidaPresupuestal reg = null;
            if (!this.esModificacion || (this.esModificacion && (!this.partidaPresupuestal.descripcion.Equals(this.partidaPresupuestalVista.descripcion.Trim().ToUpper()) || !this.partidaPresupuestal.idUnidad.Equals(this.partidaPresupuestalVista.idUnidad) || !this.partidaPresupuestal.precio.Equals(this.partidaPresupuestalVista.precio))))
                reg = this.partidaPresupuestalServicio.BuscarPorCondicion(this.partidaPresupuestalVista.descripcion.Trim().ToUpper(), this.partidaPresupuestalVista.idUnidad, this.partidaPresupuestalVista.precio);

            return reg == null;
        }
        public void llenarComboCuentas()
        {
            int anio = (Int32)this.generalServicio.ListaPlanCuenta().OrderByDescending(x => x.anioEjercicio).FirstOrDefault().anioEjercicio;
            this.partidaPresupuestalVista.listaCuentaContable = this.generalServicio.ListaCuentaContableDesdeNivel2_BienesServicios(anio).ToList();
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;
            this.partidaPresupuestal.tipo = this.partidaPresupuestalVista.tipo;
            this.partidaPresupuestal.descripcion = this.partidaPresupuestalVista.descripcion.ToUpper().Trim();
            this.partidaPresupuestal.idUnidad = this.partidaPresupuestalVista.idUnidad;
            this.partidaPresupuestal.precio = this.partidaPresupuestalVista.precio;
            this.partidaPresupuestal.cuentaContable = this.partidaPresupuestalVista.cuentaContable;
            if (this.esModificacion)
            {
                this.partidaPresupuestal.fechaEdita = DateTime.Now;
                this.partidaPresupuestal.usuEdita = this.partidaPresupuestalVista.UsuarioOperacion.NomUsuario;
                resultado = partidaPresupuestalServicio.Modificar(this.partidaPresupuestal);
            }
            else
            {
                this.partidaPresupuestal.fechaCrea = DateTime.Now;
                this.partidaPresupuestal.usuCrea = this.partidaPresupuestalVista.UsuarioOperacion.NomUsuario;
                this.partidaPresupuestal.estado = Estados.Activo;
                resultado = partidaPresupuestalServicio.Nuevo(this.partidaPresupuestal);
            }

            return resultado.esCorrecto;
        }
    }
}
