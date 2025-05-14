using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ReajusteMensualDetallePresentador
    {
        private readonly IReajusteMensualDetalleVista reajusteMensualDetalleVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private ReajusteMensualDetalle reajusteMensualDetalle;
        private bool esModificacion;
        private ReajusteMensualArea ReajusteMensualArea;
        private bool esNuevaArea;
        public ReajusteMensualDetallePresentador(ReajusteMensualArea ReajusteMensualArea, ReajusteMensualDetalle reajusteMensualDetalle, IReajusteMensualDetalleVista reajusteMensualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.ReajusteMensualArea = ReajusteMensualArea;
            this.reajusteMensualDetalleVista = reajusteMensualDetalleVista;
            this.esModificacion = reajusteMensualDetalle != null;
            this.reajusteMensualDetalle = reajusteMensualDetalle ?? new ReajusteMensualDetalle();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            if (this.esModificacion)
            {
                reajusteMensualDetalleVista.idUnidad = reajusteMensualDetalle.idUnidad;
                reajusteMensualDetalleVista.descripcion = reajusteMensualDetalle.descripcion;
                reajusteMensualDetalleVista.precio = reajusteMensualDetalle.precio;
                reajusteMensualDetalleVista.justificacion = reajusteMensualDetalle.justificacion;
            }
        }
        private void LlenarCombos()
        {
            reajusteMensualDetalleVista.listaUnidades = generalServicio.ListaUnidad();
        }

        public bool ValidarRegistroExistente()
        {
            ReajusteMensualDetalle reg = null;
            if (!this.esModificacion || (this.esModificacion && (!reajusteMensualDetalle.descripcion.Equals(reajusteMensualDetalleVista.descripcion.Trim().ToUpper()) || !reajusteMensualDetalle.idUnidad.Equals(reajusteMensualDetalleVista.idUnidad) || !reajusteMensualDetalle.precio.Equals(reajusteMensualDetalleVista.precio))))
                reg = reajusteMensualProgramacionServicio.BuscarPorCodigoDetalle(ReajusteMensualArea.idReaMenArea, reajusteMensualDetalleVista.descripcion.Trim().ToUpper(), reajusteMensualDetalleVista.idUnidad, reajusteMensualDetalleVista.precio);

            return reg == null;
        }
        private ReajusteMensualArea IngresarMontoArea()
        {
            ReajusteMensualArea nuevaArea = null;
            if (this.ReajusteMensualArea != null)
            {
                var paa = this.ReajusteMensualArea;
                nuevaArea = reajusteMensualProgramacionServicio.BuscarPorCodigoArea(paa.idReaMenPro.Value, paa.idArea, paa.idCueCon);
                if (nuevaArea == null)
                {
                    nuevaArea = new ReajusteMensualArea();
                    nuevaArea.idArea = paa.idArea;
                    nuevaArea.idCueCon = paa.idCueCon;
                    nuevaArea.idReaMenPro = paa.idReaMenPro;
                    nuevaArea.usuCrea = reajusteMensualDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    reajusteMensualProgramacionServicio.NuevoArea(nuevaArea);
                    esNuevaArea = true;
                }
            }
            return nuevaArea;
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            ReajusteMensualArea ReajusteMensualArea_ = IngresarMontoArea();

            if (ReajusteMensualArea_ != null)
            {
                
                reajusteMensualDetalle.idUnidad = reajusteMensualDetalleVista.idUnidad;
                reajusteMensualDetalle.descripcion = reajusteMensualDetalleVista.descripcion.ToUpper().Trim();
                reajusteMensualDetalle.precio = reajusteMensualDetalleVista.precio;
                reajusteMensualDetalle.justificacion = reajusteMensualDetalleVista.justificacion.ToUpper().Trim();

                if (this.esModificacion)
                {
                    reajusteMensualDetalle.fechaEdita = DateTime.Now;
                    reajusteMensualDetalle.usuEdita = reajusteMensualDetalleVista.UsuarioOperacion.NomUsuario;
                    resultado = reajusteMensualProgramacionServicio.ModificarDetalles(reajusteMensualDetalle);
                }
                else
                {
                    reajusteMensualDetalle.idReaMenArea = ReajusteMensualArea_.idReaMenArea;
                    reajusteMensualDetalle.fechaCrea = DateTime.Now;
                    reajusteMensualDetalle.usuCrea = reajusteMensualDetalleVista.UsuarioOperacion.NomUsuario;
                    reajusteMensualDetalle.estado = Estados.Activo;
                    resultado = reajusteMensualProgramacionServicio.NuevoDetalle(reajusteMensualDetalle, !esNuevaArea);
                }
            }

            return resultado != null ? resultado.esCorrecto : false;
        }
        public void ActualizarTotal()
        {
            //evaluacionMensualDetalleVista.total = evaluacionMensualDetalleVista.precio * evaluacionMensualDetalleVista.cantidad;
        }
    }
}
