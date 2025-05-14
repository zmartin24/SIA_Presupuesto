//using DevExpress.DataAccess.Native.Data;
using DevExpress.Office.Utils;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class RequerimientoMensualBienServicioDetallePresentador
    {
        private readonly IRequerimientoMensualBienServicioDetalleVista requerimientoMensualBienServicioDetalleVista;

        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        private IGeneralServicio generalServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IPeriodoServicio periodoServicio;
        private IPartidaPresupuestalServicio partidaPresupuestalServicio;

        public RequerimientoMensualBienServicioDetallePresentador(IRequerimientoMensualBienServicioDetalleVista requerimientoMensualBienServicioDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;

            this.requerimientoMensualBienServicioDetalleVista = requerimientoMensualBienServicioDetalleVista;
        }

        public void CargarServicios()
        {
            this.requerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.certificacionRequerimientoServicio = IoCHelper.ResolverIoC<ICertificacionRequerimientoServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
            this.partidaPresupuestalServicio = IoCHelper.ResolverIoC<IPartidaPresupuestalServicio>();
        }

        public void LlenarGrid()
        {
            requerimientoMensualBienServicioDetalleVista.listaGridData = requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalle(requerimientoMensualBienServicioDetalleVista.idReqMenBieSer);
        }
        public void TraerRequerimientoBienServicio()
        {
            RequerimientoMensualBienServicio objReq = this.requerimientoMensualBienServicioServicio.BuscarRequerimientoMensualBienServicio(this.requerimientoMensualBienServicioDetalleVista.idReqMenBieSer);

            this.requerimientoMensualBienServicioDetalleVista.desArea = objReq.desArea + " / " + objReq.desSubdireccion + " / " + objReq.desDireccion;
            this.requerimientoMensualBienServicioDetalleVista.desTipoCambio = this.generalServicio.TraerTipoCambioPresupuesto(objReq.anio, objReq.mes).valor.ToString();
            this.requerimientoMensualBienServicioDetalleVista.idMoneda = objReq.idMoneda;
            this.requerimientoMensualBienServicioDetalleVista.tipo = objReq.tipo;
            this.requerimientoMensualBienServicioDetalleVista.estadoReqMen = objReq.estado.ToString();
        }

        public RequerimientoMensualDetalle BuscarDetalle(int id)
        {
            return this.requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(id);
        }

        public bool AnularDetalle(int id)
        {
            bool respuesta = false;
            RequerimientoMensualDetalle requerimientoMensualDetalle = requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(id);
            respuesta = this.requerimientoMensualBienServicioServicio.AnularDetalle(requerimientoMensualDetalle, requerimientoMensualBienServicioDetalleVista.nomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int id, decimal cantidad)
        {
            bool respuesta = false;
            RequerimientoMensualDetalle requerimientoMensualDetalle = this.requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(id);
            if (requerimientoMensualDetalle != null)
            {
                requerimientoMensualDetalle.cantidad = cantidad;
                requerimientoMensualDetalle.cantPresupuestada = cantidad;
                requerimientoMensualDetalle.importe = Math.Round(requerimientoMensualDetalle.precio * requerimientoMensualDetalle.cantPresupuestada, 2, MidpointRounding.AwayFromZero);

                requerimientoMensualDetalle.fechaEdita = DateTime.Now;
                requerimientoMensualDetalle.usuEdita = this.requerimientoMensualBienServicioDetalleVista.nomUsuario;

                respuesta = this.requerimientoMensualBienServicioServicio.ModificarDetallesSinClonar(requerimientoMensualDetalle).esCorrecto;
            }
            return respuesta;
        }

        public void Iniciar()
        {
            LlenarGrid();
        }

        //Detalle
        public void IniciarDatos(int idReqMenBieSer, int id)
        {
            RequerimientoMensualBienServicio objRequerimientoMensualBienServicio = this.requerimientoMensualBienServicioServicio.BuscarRequerimientoMensualBienServicio(idReqMenBieSer);
            requerimientoMensualBienServicioDetalleVista.desTipo = "(" + objRequerimientoMensualBienServicio.tipo.ToString() + ") " + objRequerimientoMensualBienServicio.desTipo;
            
            LlenarCombos();
            
            RequerimientoMensualDetalle requerimientoMensualDetalle = this.requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(id);
            if (requerimientoMensualDetalle == null)
                return;

            this.requerimientoMensualBienServicioDetalleVista.idCueCon = requerimientoMensualDetalle.idCueCon;
            this.requerimientoMensualBienServicioDetalleVista.desCuenta = requerimientoMensualDetalle.CuentaContable.numCuenta+" - "+ requerimientoMensualDetalle.CuentaContable.descripcion;
            
            this.requerimientoMensualBienServicioDetalleVista.idParPre = requerimientoMensualDetalle.idParPre;
            this.requerimientoMensualBienServicioDetalleVista.desPartidaPre = requerimientoMensualDetalle.idParPre != null ? requerimientoMensualDetalle.PartidaPresupuestal.descripcion : string.Empty;
            this.requerimientoMensualBienServicioDetalleVista.idProducto = requerimientoMensualDetalle.idProducto;
            this.requerimientoMensualBienServicioDetalleVista.desProducto = requerimientoMensualDetalle.idProducto!=null? requerimientoMensualDetalle.Producto.Descripcion: string.Empty;
            this.requerimientoMensualBienServicioDetalleVista.idUnidad = requerimientoMensualDetalle.idUnidad;
            
            this.requerimientoMensualBienServicioDetalleVista.precio = requerimientoMensualDetalle.precio;
            this.requerimientoMensualBienServicioDetalleVista.cantidad = requerimientoMensualDetalle.cantidad;
            this.requerimientoMensualBienServicioDetalleVista.importe = requerimientoMensualDetalle.importe;
            this.requerimientoMensualBienServicioDetalleVista.descripcion = requerimientoMensualDetalle.descripcion;
            this.requerimientoMensualBienServicioDetalleVista.justificacion = requerimientoMensualDetalle.justificacion;
        }
        private void LlenarCombos()
        {
            //requerimientoMensualBienServicioDetalleVista.listaTipo = PredeterminadoHelper.ListarTipoRequerimiento();
            requerimientoMensualBienServicioDetalleVista.listaUnidades = generalServicio.ListaUnidad();
            //requerimientoBienServicioDetalleVista.listaPartidaPresupuestal = this.partidaPresupuestalServicio.TraerPartidaPresupuestalPrecio("");
            //requerimientoMensualBienServicioDetalleVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual
            //requerimientoBienServicioDetalleVista.listaGridDataDetMes = TraerListaRequerimientoDetalleMes();
            //this.requerimientoBienServicioDetalleVista.listaRequerimientoDetalleMes = this.requerimientoBienServicioDetalleVista.listaGridDataDetMes;
        }

        public string BuscarSimboloMoneda(int idReq)
        {
            string moneda = string.Empty;
            var requerimiento = requerimientoMensualBienServicioServicio.BuscarPorCodigo(idReq);
            if (requerimiento != null)
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

            RequerimientoMensualDetalle RequerimientoMensualDetalle = null;
            if (callbackArgs[0] == "Nuevo")
            {
                RequerimientoMensualDetalle = new RequerimientoMensualDetalle();
            }
            else if (callbackArgs[0] == "Editar")
            {
                int id = int.Parse(callbackArgs[1]);
                RequerimientoMensualDetalle = requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(id);
                esModificacion = true;
            }

            if (RequerimientoMensualDetalle == null)
                return null;

            //requerimientoBienServicioDetalle.idParPre = callbackArgs[3].Equals("") ? null : Convert.ToInt32(callbackArgs[3]);
            int idParPre = 0;
            if (int.TryParse(callbackArgs[2], out idParPre))
                RequerimientoMensualDetalle.idParPre = idParPre;
            else
                RequerimientoMensualDetalle.idParPre = null;

            int idProducto = 0;
            if (int.TryParse(callbackArgs[3], out idProducto))
                RequerimientoMensualDetalle.idProducto = idProducto;
            else
                RequerimientoMensualDetalle.idProducto = null;

            RequerimientoMensualDetalle.idCueCon = Convert.ToInt32(callbackArgs[4]);
            RequerimientoMensualDetalle.descripcion = Convert.ToString(callbackArgs[5]).Trim().ToUpper();
            RequerimientoMensualDetalle.idUnidad = Convert.ToInt32(callbackArgs[6]);
            RequerimientoMensualDetalle.precio = Convert.ToDecimal(callbackArgs[7]);
            RequerimientoMensualDetalle.cantidad = Convert.ToDecimal(callbackArgs[8]);
            RequerimientoMensualDetalle.justificacion = Convert.ToString(callbackArgs[9]).Trim().ToUpper();

            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                RequerimientoMensualDetalle.cantPresupuestada = RequerimientoMensualDetalle.cantidad;
                RequerimientoMensualDetalle.importe = Math.Round(Math.Round(RequerimientoMensualDetalle.precio, 2, MidpointRounding.AwayFromZero) * Math.Round(RequerimientoMensualDetalle.cantPresupuestada, 2, MidpointRounding.AwayFromZero), 2, MidpointRounding.AwayFromZero);

                RequerimientoMensualDetalle.fechaEdita = DateTime.Now;
                RequerimientoMensualDetalle.usuEdita = requerimientoMensualBienServicioDetalleVista.nomUsuario;
                resultado = requerimientoMensualBienServicioServicio.ModificarDetallesSinClonar(RequerimientoMensualDetalle);
            }
            else
            {
                RequerimientoMensualDetalle.idReqMenBieSer = requerimientoMensualBienServicioDetalleVista.idReqMenBieSer;

                RequerimientoMensualDetalle.cantPresupuestada = RequerimientoMensualDetalle.cantidad;
                RequerimientoMensualDetalle.importe = Math.Round(Math.Round(RequerimientoMensualDetalle.precio, 2, MidpointRounding.AwayFromZero) * Math.Round(RequerimientoMensualDetalle.cantPresupuestada, 2, MidpointRounding.AwayFromZero), 2, MidpointRounding.AwayFromZero);

                RequerimientoMensualDetalle.fechaCrea = DateTime.Now;
                RequerimientoMensualDetalle.usuCrea = requerimientoMensualBienServicioDetalleVista.nomUsuario;
                RequerimientoMensualDetalle.estado = Estados.Activo;
                resultado = requerimientoMensualBienServicioServicio.NuevoDetalle(RequerimientoMensualDetalle);
            }

            return resultado;
        }

        public void TraerPartidaPrecio(int tipo, string descripcion, int idMoneda)
        {
            this.requerimientoMensualBienServicioDetalleVista.listaPartidaPresupuestal = this.partidaPresupuestalServicio.TraerPartidaPresupuestalPrecio(tipo, descripcion, idMoneda);
        }
        public void TraerProductoPrecio(string descripcion, int idMoneda)
        {
            this.requerimientoMensualBienServicioDetalleVista.listaProductoPrecio = this.generalServicio.TraerProductoPrecio(descripcion, idMoneda);
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
        public ProductoPartidaPres BuscarProductoPartida(int tipo, int idProPar)
        {
            return this.generalServicio.BuscarProductoPartida(tipo, idProPar);
        }
        public Unidad BuscarUnidadMedida(int idUnidad)
        {
            return this.generalServicio.BuscarUnidadMedida(idUnidad);
        }
        public DataTable ListaEstructuraCargaRequerimientoMensual(int idReqMenBieSer, DataTable estructuraCarga)
        {
            return this.requerimientoMensualBienServicioServicio.ListaEstructuraCargaRequerimientoMensual(idReqMenBieSer, estructuraCarga);
        }
        public bool GuardarDatosDesdeExcel(int idReqMenBieSer, DataTable estructuraCarga)
        {
            return this.requerimientoMensualBienServicioServicio.
                GuardarDetalleRequerimientoMensualBienesServiciosToExcel(idReqMenBieSer, this.requerimientoMensualBienServicioDetalleVista.nomUsuario, estructuraCarga);
        }
    }
}