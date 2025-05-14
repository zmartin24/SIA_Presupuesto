using DevExpress.Web.Internal;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class RequerimientoBienServicioDetallePresentador
    {
        private readonly IRequerimientoBienServicioDetalleVista requerimientoBienServicioDetalleVista;

        private IRequerimientoBienServicioServicio requerimientoBienServicio;
        private IGeneralServicio generalServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IPeriodoServicio periodoServicio;
        private IPartidaPresupuestalServicio partidaPresupuestalServicio;

        public RequerimientoBienServicioDetallePresentador(IRequerimientoBienServicioDetalleVista requerimientoBienServicioDetalleVista)
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
            this.partidaPresupuestalServicio = IoCHelper.ResolverIoC<IPartidaPresupuestalServicio>();
        }

        public void ObtenerDatosListado()
        {
            requerimientoBienServicioDetalleVista.listaGridData = requerimientoBienServicio.TraerListaRequerimientoBienServicioDetalle(requerimientoBienServicioDetalleVista.idReqBieSer);
        }
        public void TraerRequerimientoBienServicio()
        {
            RequerimientoBienServicio objReq = this.requerimientoBienServicio.TraerRequerimientoBienServicio(this.requerimientoBienServicioDetalleVista.idReqBieSer);

            this.requerimientoBienServicioDetalleVista.desArea = objReq.desArea + " / " + objReq.desSubdireccion + " / " + objReq.desDireccion;
            this.requerimientoBienServicioDetalleVista.idMoneda = objReq.idMoneda;
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
            if (id == 0)
            {
                this.requerimientoBienServicioDetalleVista.tipo = 1;
                this.requerimientoBienServicioDetalleVista.conPartida = false;
            }
            RequerimientoBienServicioDetalle requerimientoBienServicioDetalle = requerimientoBienServicio.BuscarPorCodigoDetalle(id);
            if (requerimientoBienServicioDetalle == null)
                return;

            this.requerimientoBienServicioDetalleVista.tipo = (Int32)requerimientoBienServicioDetalle.tipo;
            this.requerimientoBienServicioDetalleVista.conPartida = (Int32)requerimientoBienServicioDetalle.tipo == 2 ? true : requerimientoBienServicioDetalle.idProducto == 0 ? true : false;
            this.requerimientoBienServicioDetalleVista.idCueCon = requerimientoBienServicioDetalle.idCueCon;
            CuentaContable objCuenta = this.generalServicio.BuscarCuentaContable(requerimientoBienServicioDetalle.idCueCon);
            this.requerimientoBienServicioDetalleVista.desCuenta = objCuenta.numCuenta;

            this.requerimientoBienServicioDetalleVista.idParPre = requerimientoBienServicioDetalle.idParPre;
            this.requerimientoBienServicioDetalleVista.datoDescripcionPartida = requerimientoBienServicioDetalle.idParPre != null ? requerimientoBienServicioDetalle.PartidaPresupuestal.descripcion : string.Empty;
            this.requerimientoBienServicioDetalleVista.idProducto = requerimientoBienServicioDetalle.idProducto;
            this.requerimientoBienServicioDetalleVista.datoDescripcion = requerimientoBienServicioDetalle.idProducto > 0 ? this.generalServicio.BuscarProducto(requerimientoBienServicioDetalle.idProducto).Descripcion : string.Empty;

            this.requerimientoBienServicioDetalleVista.idUnidad = requerimientoBienServicioDetalle.idUnidad;
            

            NumberFormatInfo current3 = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture);
            this.requerimientoBienServicioDetalleVista.precio = requerimientoBienServicioDetalle.precio; // requerimientoBienServicioDetalle.precio.ToString("c2", CultureInfo.CreateSpecificCulture("es-ES"));
            this.requerimientoBienServicioDetalleVista.descripcion = requerimientoBienServicioDetalle.descripcion;
            this.requerimientoBienServicioDetalleVista.justificacion = requerimientoBienServicioDetalle.justificacion;
        }
        private void LlenarCombos()
        {
            this.requerimientoBienServicioDetalleVista.listaTipo = PredeterminadoHelper.ListarTipoRequerimiento().Where(x => x.codigo != "0").ToList();
            this.requerimientoBienServicioDetalleVista.listaUnidades = generalServicio.ListaUnidad();
            //requerimientoBienServicioDetalleVista.listaPartidaPresupuestal = this.partidaPresupuestalServicio.TraerPartidaPresupuestalPrecio("");
            //this.requerimientoBienServicioDetalleVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual
            //requerimientoBienServicioDetalleVista.listaGridDataDetMes = TraerListaRequerimientoDetalleMes();
            //this.requerimientoBienServicioDetalleVista.listaRequerimientoDetalleMes = this.requerimientoBienServicioDetalleVista.listaGridDataDetMes;
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
        public Resultado GuardarDatos(string args, List<RequerimientoBienServicioDetalleMes> listaMeses)
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

            requerimientoBienServicioDetalle.tipo = Convert.ToInt32(callbackArgs[2]);
            
            //requerimientoBienServicioDetalle.idParPre = callbackArgs[3].Equals("") ? null : Convert.ToInt32(callbackArgs[3]);
            int idParPre = 0;
            if (int.TryParse(callbackArgs[3], out idParPre))
                requerimientoBienServicioDetalle.idParPre = idParPre;
            else
                requerimientoBienServicioDetalle.idParPre = null;

            requerimientoBienServicioDetalle.idCueCon = Convert.ToInt32(callbackArgs[4]);
            requerimientoBienServicioDetalle.descripcion = Convert.ToString(callbackArgs[5]).Trim().ToUpper();
            requerimientoBienServicioDetalle.idUnidad = Convert.ToInt32(callbackArgs[6]);
            requerimientoBienServicioDetalle.precio = Convert.ToDecimal(callbackArgs[7]);
            requerimientoBienServicioDetalle.justificacion = Convert.ToString(callbackArgs[8]).Trim().ToUpper();



            int idProducto = 0;
            if (int.TryParse(callbackArgs[9], out idProducto))
                requerimientoBienServicioDetalle.idProducto = idProducto;
            else
                requerimientoBienServicioDetalle.idProducto = 0;

            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                requerimientoBienServicioDetalle.fechaEdita = DateTime.Now;
                requerimientoBienServicioDetalle.usuEdita = requerimientoBienServicioDetalleVista.nomUsuario;
                resultado = requerimientoBienServicio.ModificarDetallesSinClonarConMeses(requerimientoBienServicioDetalle, listaMeses);
            }
            else
            {
                requerimientoBienServicioDetalle.idReqBieSer = requerimientoBienServicioDetalleVista.idReqBieSer;
                requerimientoBienServicioDetalle.fechaCrea = DateTime.Now;
                requerimientoBienServicioDetalle.usuCrea = requerimientoBienServicioDetalleVista.nomUsuario;
                requerimientoBienServicioDetalle.estado = Estados.Activo;
                resultado = requerimientoBienServicio.NuevoDetalleConMeses(requerimientoBienServicioDetalle, listaMeses);
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
        
        public void TraerPartidaPrecio(int tipo, string descripcion, int idMoneda)
        {
            this.requerimientoBienServicioDetalleVista.listaPartidaPresupuestal = this.partidaPresupuestalServicio.TraerPartidaPresupuestalPrecio(tipo, descripcion, idMoneda);
        }
        public void TraerProductoPrecio(string descripcion, int idMoneda)
        {
            this.requerimientoBienServicioDetalleVista.listaProductoPrecio = this.generalServicio.TraerProductoPrecio(descripcion, idMoneda);
        }
        public List<RequerimientoBienServicioDetalleMes> TraerListaRequerimientoDetalleMes(int id)
        {
            List<RequerimientoBienServicioDetalleMes> lista = new List<RequerimientoBienServicioDetalleMes>();

            if (id > 0)
            {
                lista = this.requerimientoBienServicio.TraerRequerimientoBienServicioDetalleMeses(id);
                return lista;
            }

            RequerimientoBienServicioDetalleMes obj = new RequerimientoBienServicioDetalleMes();
            obj = new RequerimientoBienServicioDetalleMes
            {
                idReqBieSerDetMes = 0,
                idReqBieSerDet = 0,
                mes = 0,
                cantEne = 0,
                cantFeb = 0,
                cantMar = 0,
                cantAbr = 0,
                cantMay = 0,
                cantJun = 0,
                cantJul = 0,
                cantAgo = 0,
                cantSet = 0,
                cantOct = 0,
                cantNov = 0,
                cantDic = 0,
                cantidad = 0,
                usuCrea = "SISTEMA",
                fechaCrea = DateTime.Now,
                estado = 2
            };
            lista.Add(obj);
            return lista;
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
        public DataTable ListaEstructuraCargaRequerimientoAnual(int idReqMenBieSer, DataTable estructuraCarga)
        {
            return this.requerimientoBienServicio.ListaEstructuraCargaRequerimientoAnual(idReqMenBieSer, estructuraCarga);
        }
        public bool GuardarDatosDesdeExcel(int idReqBieSer, DataTable estructuraCarga)
        {
            return this.requerimientoBienServicio.
                GuardarDetalleRequerimientoAnualBienesServiciosToExcel(idReqBieSer, this.requerimientoBienServicioDetalleVista.nomUsuario, estructuraCarga);
        }

    }
}
