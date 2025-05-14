using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ProgramacionAnualDetallePresentador
    {
        private readonly IProgramacionAnualDetalleVista programacionAnualDetalleVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private ProgramacionAnualDetalle programacionAnualDetalle;
        private bool esModificacion;
        private ProgramacionAnualArea ProgramacionAnualArea;
        private bool esNuevaArea;
        private Producto producto;

        public ProgramacionAnualDetallePresentador(ProgramacionAnualArea ProgramacionAnualArea, ProgramacionAnualDetalle programacionAnualDetalle, IProgramacionAnualDetalleVista programacionAnualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.ProgramacionAnualArea = ProgramacionAnualArea;
            this.programacionAnualDetalleVista = programacionAnualDetalleVista;
            this.esModificacion = programacionAnualDetalle != null;
            this.programacionAnualDetalle = programacionAnualDetalle ?? new ProgramacionAnualDetalle();

        }

        public void IniciarDatos()
        {
            LlenarCombos();
            if (this.esModificacion)
            {
                programacionAnualDetalleVista.idUnidad = programacionAnualDetalle.idUnidad;
                programacionAnualDetalleVista.descripcion = programacionAnualDetalle.descripcion;
                programacionAnualDetalleVista.precio = programacionAnualDetalle.precio;
            }
        }
        public bool ValidarRegistroExistente()
        {
            ProgramacionAnualDetalle reg = null;
            if (!this.esModificacion || (this.esModificacion && (!programacionAnualDetalle.descripcion.Equals(this.programacionAnualDetalleVista.descripcion.Trim().ToUpper()) || !programacionAnualDetalle.idUnidad.Equals(this.programacionAnualDetalleVista.idUnidad) || !programacionAnualDetalle.precio.Equals(this.programacionAnualDetalleVista.precio))))
                reg = programacionAnualServicio.BuscarPorCodigoDetalle(this.ProgramacionAnualArea.idProAnuArea, this.programacionAnualDetalleVista.descripcion.Trim().ToUpper(), this.programacionAnualDetalleVista.idUnidad, this.programacionAnualDetalleVista.precio);

            return reg == null;
        }
        private void LlenarCombos()
        {
            programacionAnualDetalleVista.listaUnidades = generalServicio.ListaUnidad();
        }

        private ProgramacionAnualArea IngresarMontoArea()
        {
            ProgramacionAnualArea nuevaArea = null;
            if (this.ProgramacionAnualArea != null)
            {
                var paa = this.ProgramacionAnualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon);
                if (nuevaArea == null)
                {
                    nuevaArea = new ProgramacionAnualArea();
                    nuevaArea.idArea = paa.idArea;
                    nuevaArea.idCueCon = paa.idCueCon;
                    nuevaArea.idProAnu = paa.idProAnu;
                    //nuevaArea.mes = programacionAnualDetalleVista.mes;
                    //nuevaArea.importe = programacionAnualDetalleVista.total;
                    nuevaArea.usuCrea = programacionAnualDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoArea(nuevaArea);
                    esNuevaArea = true;
                }
            }
            return nuevaArea;
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            programacionAnualDetalle.idUnidad = programacionAnualDetalleVista.idUnidad;
            programacionAnualDetalle.descripcion = programacionAnualDetalleVista.descripcion.ToUpper().Trim();
            programacionAnualDetalle.precio = programacionAnualDetalleVista.precio;
           
            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                programacionAnualDetalle.fechaEdita = DateTime.Now;
                programacionAnualDetalle.usuEdita = programacionAnualDetalleVista.UsuarioOperacion.NomUsuario;
                resultado = programacionAnualServicio.ModificarDetalles(programacionAnualDetalle);
            }
            else
            {
                ProgramacionAnualArea ProgramacionAnualArea_ = IngresarMontoArea();
                if (ProgramacionAnualArea_ != null)
                {
                    programacionAnualDetalle.idProAnuArea = ProgramacionAnualArea_.idProAnuArea;
                    programacionAnualDetalle.fechaCrea = DateTime.Now;
                    programacionAnualDetalle.usuCrea = programacionAnualDetalleVista.UsuarioOperacion.NomUsuario;
                    programacionAnualDetalle.estado = Estados.Activo;
                    resultado = programacionAnualServicio.NuevoDetalle(programacionAnualDetalle, !esNuevaArea);
                }
            }


            return resultado != null ? resultado.esCorrecto : false;
        }

        public void ActualizarTotal()
        {
            //programacionAnualDetalleVista.total = programacionAnualDetalleVista.precio * programacionAnualDetalleVista.cantidad * programacionAnualDetalleVista.dias;
        }

        public void AsignarProducto(Producto producto)
        {
            if (producto != null)
            {
                this.producto = producto;
                programacionAnualDetalleVista.descripcion = producto.Descripcion;
            }
        }
    }
}
