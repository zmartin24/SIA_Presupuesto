using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class GastoRecurrenteRequerimientoPresentador
    {
        private readonly IListaGastoRecurrenteRequerimientoVista listaGastoRecurrenteRequerimientoVista;

        private GastoRecurrente gastoRecurrente;
        private IGastoRecurrenteServicio gastoRecurrenteServicio;

        public GastoRecurrenteRequerimientoPresentador(GastoRecurrente gastoRecurrente, IListaGastoRecurrenteRequerimientoVista listaGastoRecurrenteRequerimientoVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;

            this.listaGastoRecurrenteRequerimientoVista = listaGastoRecurrenteRequerimientoVista;
            this.gastoRecurrente = gastoRecurrente;
        }

        public void ObtenerDatosListado()
        {
            if (gastoRecurrente != null)
                listaGastoRecurrenteRequerimientoVista.listaDatosPrincipales = gastoRecurrenteServicio.TraerListaGastoRecurrenteRequerimiento(gastoRecurrente.idGasRec);
        }

        public GastoRecurrenteRequerimiento BuscarArea(int id)
        {
            return this.gastoRecurrenteServicio.BuscarReqPorCodigo(id);
        }

        public GastoRecurrenteDetalle BuscarDetalle(int id)
        {
            return this.gastoRecurrenteServicio.BuscarDetallePorCodigo(id);
        }

        public void IniciarDatos()
        {

        }

        public bool AnularGastoRecurrenteCab()
        {
           bool respuesta = false;
            
            if (listaGastoRecurrenteRequerimientoVista.gastoRecurrenteRequerimientoPres != null)
                respuesta = this.gastoRecurrenteServicio.AnularGasRecReqPres(listaGastoRecurrenteRequerimientoVista.gastoRecurrenteRequerimientoPres, listaGastoRecurrenteRequerimientoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool AnularDetalle()
        {
            bool respuesta = false;
            if (listaGastoRecurrenteRequerimientoVista.gastoRecurrenteDetalle != null)
                respuesta = this.gastoRecurrenteServicio.AnularDetalle(listaGastoRecurrenteRequerimientoVista.gastoRecurrenteDetalle, listaGastoRecurrenteRequerimientoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarMontoArea(int mes, decimal importe)
        {
            bool respuesta = false;
            ObtenerDatosListado();
            return respuesta;
        }
        private bool esNuevaArea;
        private ProgramacionAnualArea IngresarMontoAreaOtro(int mes, decimal importe)
        {
            ProgramacionAnualArea nuevaArea = null;
            return nuevaArea;
        }

        private GastoRecurrenteDetalle IngresarCantidadDetOtro(int mes, int dias, decimal precio, decimal cantidad)
        {
            GastoRecurrenteDetalle nuevaArea = null;
            if (listaGastoRecurrenteRequerimientoVista.gastoRecurrenteDetalle != null)
            {
                var paa = listaGastoRecurrenteRequerimientoVista.gastoRecurrenteDetalle;
                nuevaArea = gastoRecurrenteServicio.BuscarDetallePorCodigo(paa.idGasRecDet);
                if (nuevaArea == null)
                {
                    nuevaArea = new GastoRecurrenteDetalle();
                    nuevaArea.idGasRecReq = paa.idGasRecReq;
                    nuevaArea.subTotal = Math.Round(precio * cantidad, 2);
                    nuevaArea.usuCrea = listaGastoRecurrenteRequerimientoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    gastoRecurrenteServicio.NuevoDetalle(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;
                    suma = gastoRecurrenteServicio.BuscarImporteDetalle((Int32)paa.idGasRecReq, (decimal)paa.precio);
                    
                    nuevaArea.subTotal = suma;// + Math.Round(dias * precio * cantidad, 2);
                    nuevaArea.usuEdita = listaGastoRecurrenteRequerimientoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    gastoRecurrenteServicio.ModificarDetalles(nuevaArea);
                }
            }
            return nuevaArea;
        }

        public bool GuardarDatos()
        {
            bool respuesta = false;
            return respuesta;
        }
        public bool IngresarMontoDetalle(int mes, decimal importe)
        {
            bool respuesta = false;

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, int dias, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            GastoRecurrenteDetalle gastoRecurrenteDetalle_ = IngresarCantidadDetOtro(mes, dias, precio, cantidad);

            if (gastoRecurrenteDetalle_ != null)
            {
                GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes = gastoRecurrenteServicio.BuscarPorCodigoPaaDetalleMes(gastoRecurrenteDetalle_.idGasRecDet, mes);

                if (gastoRecurrenteDetalleMes != null)
                {
                    gastoRecurrenteDetalleMes.cantidad = cantidad;
                    gastoRecurrenteDetalleMes.fechaEdita = DateTime.Now;
                    gastoRecurrenteDetalleMes.usuEdita = listaGastoRecurrenteRequerimientoVista.UsuarioOperacion.NomUsuario;

                    respuesta = gastoRecurrenteServicio.ModificarGasRecDetMes(gastoRecurrenteDetalleMes, !esNuevaArea).esCorrecto;
                }
                else
                {
                    gastoRecurrenteDetalleMes = new GastoRecurrenteDetalleMes();

                    gastoRecurrenteDetalleMes.mes = mes;
                    gastoRecurrenteDetalleMes.cantidad = cantidad;
                    gastoRecurrenteDetalleMes.idGasRecDet = gastoRecurrenteDetalle_.idGasRecDet;
                    gastoRecurrenteDetalleMes.idReqBieSerDetMes = 0;
                    gastoRecurrenteDetalleMes.fechaCrea = DateTime.Now;
                    gastoRecurrenteDetalleMes.usuCrea = listaGastoRecurrenteRequerimientoVista.UsuarioOperacion.NomUsuario;
                    gastoRecurrenteDetalleMes.estado = Estados.Activo;
                    
                    respuesta = gastoRecurrenteServicio.NuevoGasRecDetMes(gastoRecurrenteDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }
        
    }
}
