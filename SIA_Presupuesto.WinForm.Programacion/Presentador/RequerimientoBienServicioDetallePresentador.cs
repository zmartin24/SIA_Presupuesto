using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class RequerimientoBienServicioDetallePresentador
    {
        private readonly IRequerimientoBienServicioDetalleVista requerimientoBienServicioDetalleVista;

        private RequerimientoBienServicio RequerimientoBienServicio;
        private IRequerimientoBienServicioServicio programacionAnualServicio;

        public RequerimientoBienServicioDetallePresentador(RequerimientoBienServicio RequerimientoBienServicio, IRequerimientoBienServicioDetalleVista requerimientoBienServicioDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;

            this.requerimientoBienServicioDetalleVista = requerimientoBienServicioDetalleVista;
            this.RequerimientoBienServicio = RequerimientoBienServicio;
        }

        public void ObtenerDatosListado()
        {
            requerimientoBienServicioDetalleVista.listaDatosPrincipales = programacionAnualServicio.TraerListaRequerimientoBienServicioDetalle(RequerimientoBienServicio.idReqBieSer);
        }

        public RequerimientoBienServicioDetalle BuscarDetalle(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigoDetalle(id);
        }

        public void IniciarDatos()
        {

        }

        public bool AnularArea()
        {
            bool respuesta = false;
            if (requerimientoBienServicioDetalleVista.RequerimientoBienServicioDetalle != null)
                respuesta = this.programacionAnualServicio.AnularArea(requerimientoBienServicioDetalleVista.RequerimientoBienServicioDetalle, requerimientoBienServicioDetalleVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, decimal cantidad)
        {
            bool respuesta = false;
            if (requerimientoBienServicioDetalleVista.RequerimientoBienServicioDetalle != null)
            {
                var paa = requerimientoBienServicioDetalleVista.RequerimientoBienServicioDetalle;

                var nuevaArea = programacionAnualServicio.BuscarPorCodigoDetalleMes(paa.idReqBieSerDet, mes);
                if(nuevaArea == null)
                {
                    nuevaArea = new RequerimientoBienServicioDetalleMes();
                    nuevaArea.idReqBieSerDet = paa.idReqBieSerDet;
                    nuevaArea.cantidad = cantidad;
                    nuevaArea.mes = mes;
                    nuevaArea.usuCrea = requerimientoBienServicioDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoDetalle(nuevaArea, true).esCorrecto;
                }
                else
                {
                    nuevaArea.idReqBieSerDet = paa.idReqBieSerDet;
                    nuevaArea.cantidad = cantidad;
                    nuevaArea.mes = mes;
                    nuevaArea.estado = Estados.Activo;
                    nuevaArea.usuEdita = requerimientoBienServicioDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    respuesta = programacionAnualServicio.ModificarDetalles(nuevaArea, true).esCorrecto;
                }
            }
            ObtenerDatosListado();
            return respuesta;
        }


        public bool GuardarDatos()
        {
            bool respuesta = false;
            return respuesta;
        }

    }
}
