using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class RequerimientoBienServicioDetalleOrginalPresentador
    {
        private readonly IRequerimientoBienServicioDetalleOriginalVista requerimientoBienServicioDetalleVista;

        private IRequerimientoBienServicioServicio requerimientoBienServicio;
        private IGeneralServicio generalServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IPeriodoServicio periodoServicio;

        public RequerimientoBienServicioDetalleOrginalPresentador(IRequerimientoBienServicioDetalleOriginalVista requerimientoBienServicioDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoBienServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;

            this.requerimientoBienServicioDetalleVista = requerimientoBienServicioDetalleVista;
        }

        public void CargarServicios()
        {
            this.requerimientoBienServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.certificacionRequerimientoServicio = IoCHelper.ResolverIoC<ICertificacionRequerimientoServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
        }

        public void ObtenerDatosListado()
        {
            requerimientoBienServicioDetalleVista.listaGridData = requerimientoBienServicio.TraerListaRequerimientoBienServicioDetalle(requerimientoBienServicioDetalleVista.idReqBieSer);
        }
        public void TraerRequerimientoBienServicio()
        {
            RequerimientoBienServicio objReq = this.requerimientoBienServicio.TraerRequerimientoBienServicio(this.requerimientoBienServicioDetalleVista.idReqBieSer);

            this.requerimientoBienServicioDetalleVista.desArea = objReq.desArea + " / " + objReq.desSubdireccion + " / " + objReq.desDireccion;
        }

        public RequerimientoBienServicioDetalle BuscarDetalle(int id)
        {
            return this.requerimientoBienServicio.BuscarPorCodigoDetalle(id);
        }

        public bool AnularArea(int id)
        {
            bool respuesta = false;
            RequerimientoBienServicioDetalle requerimientoBienServicioDetalle = requerimientoBienServicio.BuscarPorCodigoDetalle(id);
            respuesta = this.requerimientoBienServicio.AnularArea(requerimientoBienServicioDetalle, requerimientoBienServicioDetalleVista.nomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int id, int mes, decimal cantidad)
        {
            bool respuesta = false;
            RequerimientoBienServicioDetalle requerimientoBienServicioDetalle = requerimientoBienServicio.BuscarPorCodigoDetalle(id);
            if (requerimientoBienServicioDetalle != null)
            {
                var paa = requerimientoBienServicioDetalle;

                var nuevaArea = requerimientoBienServicio.BuscarPorCodigoDetalleMes(paa.idReqBieSerDet, mes);
                if(nuevaArea == null)
                {
                    nuevaArea = new RequerimientoBienServicioDetalleMes();
                    nuevaArea.idReqBieSerDet = paa.idReqBieSerDet;
                    nuevaArea.cantidad = cantidad;
                    nuevaArea.mes = mes;
                    nuevaArea.usuCrea =  requerimientoBienServicioDetalleVista.nomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    respuesta = requerimientoBienServicio.NuevoDetalle(nuevaArea, true).esCorrecto;
                }
                else
                {
                    nuevaArea.idReqBieSerDet = paa.idReqBieSerDet;
                    nuevaArea.cantidad = cantidad;
                    nuevaArea.mes = mes;
                    nuevaArea.estado = Estados.Activo;
                    nuevaArea.usuEdita = requerimientoBienServicioDetalleVista.nomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    respuesta = requerimientoBienServicio.ModificarDetalles(nuevaArea, true).esCorrecto;
                }
            }
            //ObtenerDatosListado();//Lachi Modifico
            return respuesta;
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        public void IniciarDatos(int id)
        {
            LlenarCombos();
            RequerimientoBienServicioDetalle requerimientoBienServicioDetalle = requerimientoBienServicio.BuscarPorCodigoDetalle(id);
            if (requerimientoBienServicioDetalle == null)
                return;

            //requerimientoBienServicioDetalleVista.tipo = requerimientoBienServicioDetalle.;
            requerimientoBienServicioDetalleVista.idUnidad = requerimientoBienServicioDetalle.idUnidad;
            requerimientoBienServicioDetalleVista.descripcion = requerimientoBienServicioDetalle.descripcion;
            requerimientoBienServicioDetalleVista.justificacion = requerimientoBienServicioDetalle.justificacion;
            requerimientoBienServicioDetalleVista.precio = requerimientoBienServicioDetalle.precio;
            requerimientoBienServicioDetalleVista.idCueCon = requerimientoBienServicioDetalle.idCueCon;
            requerimientoBienServicioDetalleVista.idProducto = requerimientoBienServicioDetalle.idProducto;
            
        }
        public void IniciarPopAyudaPrecio()
        {
            requerimientoBienServicioDetalleVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            requerimientoBienServicioDetalleVista.anioPresentacion = this.periodoServicio.ObtenerActivo().anio;
        }
        private void LlenarCombos()
        {
            requerimientoBienServicioDetalleVista.listaUnidades = generalServicio.ListaUnidad();
            requerimientoBienServicioDetalleVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual
        }

        public string BuscarSimboloMoneda(int idReq)
        {
            string moneda = string.Empty;
            var requerimiento = requerimientoBienServicio.BuscarPorCodigo(idReq);
            if(requerimiento != null)
            {
                var objmoneda = generalServicio.BuscarMoneda(requerimiento.idMoneda);
                if (objmoneda != null)
                    moneda = objmoneda.abreviatura;
            }
            return moneda;
        }

        private bool esModificacion;
        public Resultado GuardarDatos(string args)
        {
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            RequerimientoBienServicioDetalle requerimientoBienServicioDetalle = null;
            if (callbackArgs[0] == "Nuevo")
            {
                requerimientoBienServicioDetalle = new RequerimientoBienServicioDetalle();
            }
            else if (callbackArgs[0] == "Editar")
            {
                int id = int.Parse(callbackArgs[1]);
                requerimientoBienServicioDetalle = requerimientoBienServicio.BuscarPorCodigoDetalle(id);
                esModificacion = true;
            }

            if (requerimientoBienServicioDetalle == null)
                return null;

            //requerimientoBienServicioDetalle.idUnidad = requerimientoBienServicioDetalleVista.idUnidad;
            //requerimientoBienServicioDetalle.idCueCon = requerimientoBienServicioDetalleVista.idCueCon;
            //requerimientoBienServicioDetalle.descripcion = requerimientoBienServicioDetalleVista.descripcion;
            //requerimientoBienServicioDetalle.justificacion = requerimientoBienServicioDetalleVista.justificacion;
            //requerimientoBienServicioDetalle.precio = requerimientoBienServicioDetalleVista.precio;
            //requerimientoBienServicioDetalle.idProducto = requerimientoBienServicioDetalleVista.idProducto;

            requerimientoBienServicioDetalle.idCueCon = Convert.ToInt32(callbackArgs[2]);
            requerimientoBienServicioDetalle.descripcion = Convert.ToString(callbackArgs[3]);
            requerimientoBienServicioDetalle.idUnidad = Convert.ToInt32(callbackArgs[4]);
            requerimientoBienServicioDetalle.precio = Convert.ToDecimal(callbackArgs[5]);
            requerimientoBienServicioDetalle.justificacion = Convert.ToString(callbackArgs[6]);

            int idProducto = 0;
            if (int.TryParse(callbackArgs[7], out idProducto))
                requerimientoBienServicioDetalle.idProducto = idProducto;
            else
                requerimientoBienServicioDetalle.idProducto = 0;

            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                requerimientoBienServicioDetalle.fechaEdita = DateTime.Now;
                requerimientoBienServicioDetalle.usuEdita = requerimientoBienServicioDetalleVista.nomUsuario;
                resultado = requerimientoBienServicio.ModificarDetallesSinClonar(requerimientoBienServicioDetalle);
            }
            else
            {
                requerimientoBienServicioDetalle.idReqBieSer = requerimientoBienServicioDetalleVista.idReqBieSer;
                requerimientoBienServicioDetalle.fechaCrea = DateTime.Now;
                requerimientoBienServicioDetalle.usuCrea = requerimientoBienServicioDetalleVista.nomUsuario;
                requerimientoBienServicioDetalle.estado = Estados.Activo;
                resultado = requerimientoBienServicio.NuevoDetalle(requerimientoBienServicioDetalle);
            }


            return resultado;
        }

        public void AsignarProducto(Producto producto)
        {
            //if (producto != null)
            //{
            //    this.producto = producto;
            //    requerimientoBienServicio.descripcion = producto.Descripcion;
            //}
        }
        public void ObtenerDatosProductos()
        {
            //int idCuenta = requerimientoBienServicioDetalleVista.idCueCon;
            //var Cuenta = generalServicio.BuscarCuentaContable(idCuenta);
            //if (Cuenta != null)
            //    requerimientoBienServicioDetalleVista.listaDatosProductos = generalServicio.ListaProducto(Cuenta.numCuenta);

            requerimientoBienServicioDetalleVista.listaDatosProductos = generalServicio.ListaProducto();
        }
        public void ObtenerDatosPrecios(int anio, int idCuenta)
        {
            requerimientoBienServicioDetalleVista.listaPrecio = certificacionRequerimientoServicio.TraerListaPrecioBienServicioRequerimiento(anio, requerimientoBienServicioDetalleVista.idProducto, idCuenta, requerimientoBienServicioDetalleVista.idReqBieSer, requerimientoBienServicioDetalleVista.idProducto > 0 ? 1 : 2);
        }
        public int BuscarIDUnidadProducto(int id)
        {
            int idUnidad = 0;
            var producto = generalServicio.BuscarProducto(id);
            if (producto != null)
            {
                idUnidad = producto.idUnidad;
            }
            return idUnidad;
        }
    }
}
