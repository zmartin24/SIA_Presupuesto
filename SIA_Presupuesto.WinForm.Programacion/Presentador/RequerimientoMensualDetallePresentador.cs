using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class RequerimientoMensualDetallePresentador
    {
        private readonly IRequerimientoMensualDetalleVista requerimientoMensualDetalleVista;
        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        private IGeneralServicio generalServicio;
        private RequerimientoMensualDetalle requerimientoMensualDetalle;
        private bool esModificacion;
        
        private RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres;
        private string tipoProceso;
        public RequerimientoMensualDetallePresentador(RequerimientoMensualDetalle requerimientoMensualDetalle, RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres, string tipoProceso, IRequerimientoMensualDetalleVista requerimientoMensualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.requerimientoMensualDetalleVista = requerimientoMensualDetalleVista;
            this.requerimientoMensualBienServicioPres = requerimientoMensualBienServicioPres;
            this.esModificacion = requerimientoMensualDetalle != null;
            this.requerimientoMensualDetalle = requerimientoMensualDetalle ?? new RequerimientoMensualDetalle();
            this.tipoProceso = tipoProceso;
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            if (this.esModificacion)
            {
                requerimientoMensualDetalleVista.idParPre = this.requerimientoMensualDetalle.idParPre;
                requerimientoMensualDetalleVista.idProducto = this.requerimientoMensualDetalle.idProducto;
                requerimientoMensualDetalleVista.idCueCon = this.requerimientoMensualDetalle.idCueCon;
                requerimientoMensualDetalleVista.desCuenta = this.requerimientoMensualDetalle.CuentaContable != null ? this.requerimientoMensualDetalle.CuentaContable.numCuenta + " - " + this.requerimientoMensualDetalle.CuentaContable.descripcion : String.Empty;

                requerimientoMensualDetalleVista.descripcion = this.requerimientoMensualDetalle.descripcion;
                requerimientoMensualDetalleVista.justificacion = this.requerimientoMensualDetalle.justificacion;
                requerimientoMensualDetalleVista.idUnidad = this.requerimientoMensualDetalle.idUnidad;
                requerimientoMensualDetalleVista.cantidad = this.tipoProceso.Equals("EDITA") ? this.requerimientoMensualDetalle.cantidad : this.requerimientoMensualDetalle.cantPresupuestada;
                requerimientoMensualDetalleVista.precio = this.requerimientoMensualDetalle.precio;
                requerimientoMensualDetalleVista.importe = this.requerimientoMensualDetalle.importe;
                
                this.requerimientoMensualDetalleVista.desParPre = this.requerimientoMensualDetalle.PartidaPresupuestal != null ? this.requerimientoMensualDetalle.PartidaPresupuestal.descripcion : String.Empty;
                this.requerimientoMensualDetalleVista.desProducto = this.requerimientoMensualDetalle.Producto != null ? this.requerimientoMensualDetalle.Producto.Descripcion : String.Empty;
            }
        }

        private void LlenarCombos()
        {
            this.requerimientoMensualDetalleVista.listaUnidades = generalServicio.ListaUnidad();
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            this.requerimientoMensualDetalle.idUnidad = this.requerimientoMensualDetalleVista.idUnidad;
            this.requerimientoMensualDetalle.idCueCon = this.requerimientoMensualDetalleVista.idCueCon;
            this.requerimientoMensualDetalle.descripcion = this.requerimientoMensualDetalleVista.descripcion.Trim().ToUpper();
            this.requerimientoMensualDetalle.justificacion = this.requerimientoMensualDetalleVista.justificacion.Trim().ToUpper();
            
            this.requerimientoMensualDetalle.precio = this.requerimientoMensualDetalleVista.precio;
            

            this.requerimientoMensualDetalle.idParPre = this.requerimientoMensualDetalleVista.idParPre;
            this.requerimientoMensualDetalle.idProducto = this.requerimientoMensualDetalleVista.idProducto;

            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                this.requerimientoMensualDetalle.cantidad = this.tipoProceso.Equals("EDITA") ? this.requerimientoMensualDetalleVista.cantidad : this.requerimientoMensualDetalle.cantidad;
                this.requerimientoMensualDetalle.cantPresupuestada = this.requerimientoMensualDetalleVista.cantidad;
                this.requerimientoMensualDetalle.importe = Math.Round(this.requerimientoMensualDetalle.precio * this.requerimientoMensualDetalle.cantPresupuestada, 2, MidpointRounding.AwayFromZero);

                this.requerimientoMensualDetalle.fechaEdita = DateTime.Now;
                this.requerimientoMensualDetalle.usuEdita = requerimientoMensualDetalleVista.UsuarioOperacion.NomUsuario;
                
                resultado = this.requerimientoMensualBienServicioServicio.ModificarDetalles(requerimientoMensualDetalle);
            }
            else
            {
                this.requerimientoMensualDetalle.idReqMenBieSer = (Int32)this.requerimientoMensualBienServicioPres.idReqMenBieSer;
                this.requerimientoMensualDetalle.cantidad = this.requerimientoMensualDetalleVista.cantidad;
                this.requerimientoMensualDetalle.cantPresupuestada = this.requerimientoMensualDetalleVista.cantidad;
                this.requerimientoMensualDetalle.importe = Math.Round(this.requerimientoMensualDetalle.precio * this.requerimientoMensualDetalle.cantPresupuestada, 2, MidpointRounding.AwayFromZero);

                this.requerimientoMensualDetalle.fechaCrea = DateTime.Now;
                this.requerimientoMensualDetalle.usuCrea = requerimientoMensualDetalleVista.UsuarioOperacion.NomUsuario;
                this.requerimientoMensualDetalle.estado = Estados.Activo;
                
                resultado = this.requerimientoMensualBienServicioServicio.NuevoDetalle(requerimientoMensualDetalle);
            }
            return resultado != null ? resultado.esCorrecto : false;
        }

        public void AsignarPartidaPresupuestal(PartidaPresupuestalPrecioPres partidaPresupuestalPrecioPres)
        {
            if (partidaPresupuestalPrecioPres != null)
            {
                this.requerimientoMensualDetalleVista.idParPre = partidaPresupuestalPrecioPres.idParPre;
                this.requerimientoMensualDetalleVista.idProducto = null;
                this.requerimientoMensualDetalleVista.desParPre = partidaPresupuestalPrecioPres.descripcion;
                this.requerimientoMensualDetalleVista.descripcion = partidaPresupuestalPrecioPres.descripcion;
                this.requerimientoMensualDetalleVista.idUnidad = partidaPresupuestalPrecioPres.idUnidad;
                this.requerimientoMensualDetalleVista.precio = (decimal)partidaPresupuestalPrecioPres.precio;
                this.requerimientoMensualDetalleVista.idCueCon = partidaPresupuestalPrecioPres.idCueCon;
                this.requerimientoMensualDetalleVista.desCuenta = partidaPresupuestalPrecioPres.numCuenta;
            }
        }
        public void AsignarProducto(ProductoPrecioPres producto)
        {
            if (producto != null)
            {
                //this.productoPrecioPres = producto;
                this.requerimientoMensualDetalleVista.idParPre = null;
                this.requerimientoMensualDetalleVista.idProducto = producto.idProducto;
                this.requerimientoMensualDetalleVista.desProducto = producto.descripcion;
                this.requerimientoMensualDetalleVista.descripcion = producto.descripcion;
                this.requerimientoMensualDetalleVista.idUnidad = (Int32)producto.idUnidad;
                this.requerimientoMensualDetalleVista.precio = (decimal)producto.precio;
                this.requerimientoMensualDetalleVista.idCueCon = (Int32)producto.idCueCon;
                this.requerimientoMensualDetalleVista.desCuenta = producto.numCuenta;
            }
        }
    }
}
