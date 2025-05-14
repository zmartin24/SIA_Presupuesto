using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ReajusteMensualPresupuestoPresentador
    {
        private readonly IReajusteMensualPresupuestoVista reajusteMensualPresupuestoVista;

        private ReajusteMensualProgramacion ReajusteMensualProgramacion;
        private IReajusteMensualProgramacionServicio reajusteMensualPresupuestoServicio;

        public ReajusteMensualPresupuestoPresentador(ReajusteMensualProgramacion ReajusteMensualProgramacion, IReajusteMensualPresupuestoVista reajusteMensualPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.reajusteMensualPresupuestoServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;

            this.reajusteMensualPresupuestoVista = reajusteMensualPresupuestoVista;
            this.ReajusteMensualProgramacion = ReajusteMensualProgramacion;
        }

        public void ObtenerDatosListado()
        {
            reajusteMensualPresupuestoVista.listaDatosPrincipales = reajusteMensualPresupuestoServicio.TraerListaReajusteMensualArea(ReajusteMensualProgramacion.idReaMenPro);
        }

        public ReajusteMensualArea BuscarArea(int id)
        {
            return this.reajusteMensualPresupuestoServicio.BuscarPorCodigoArea(id);
        }

        public ReajusteMensualDetalle BuscarDetalle(int id)
        {
            return this.reajusteMensualPresupuestoServicio.BuscarPorCodigoDetalle(id);
        }

        public void IniciarDatos()
        {

        }

        public bool AnularArea()
        {
            bool respuesta = false;
            if (reajusteMensualPresupuestoVista.ReajusteMensualArea != null)
                respuesta = this.reajusteMensualPresupuestoServicio.AnularArea(reajusteMensualPresupuestoVista.ReajusteMensualArea, reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool AnularDetalle()
        {
            bool respuesta = false;
            if (reajusteMensualPresupuestoVista.ReajusteMensualDetalle != null)
                respuesta = this.reajusteMensualPresupuestoServicio.AnularDetalle(reajusteMensualPresupuestoVista.ReajusteMensualDetalle, reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarMontoArea(int mes, decimal importe)
        {
            bool respuesta = false;
            if (reajusteMensualPresupuestoVista.ReajusteMensualArea != null)
            {
                var paa = reajusteMensualPresupuestoVista.ReajusteMensualArea;
                ReajusteMensualAreaMes nuevaArea = null;
                nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoAreaMes((Int32)paa.idReaMenPro, mes);
                if(nuevaArea == null)
                {
                    nuevaArea = new ReajusteMensualAreaMes();
                    nuevaArea.idReaMenArea = paa.idReaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = importe;
                    nuevaArea.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    
                    respuesta = reajusteMensualPresupuestoServicio.NuevoAreaMes(nuevaArea).esCorrecto;
                }
                else
                {
                    nuevaArea.importe = importe;
                    nuevaArea.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    respuesta = reajusteMensualPresupuestoServicio.ModificarAreasMes(nuevaArea).esCorrecto;
                }
            }
            ObtenerDatosListado();
            return respuesta;
        }
        private bool esNuevaArea;
        private ReajusteMensualAreaMes IngresarMontoAreaOtro(int mes, decimal importe)
        {
            ReajusteMensualAreaMes nuevaArea = null;
            if (reajusteMensualPresupuestoVista.ReajusteMensualArea != null)
            {
                var paa = reajusteMensualPresupuestoVista.ReajusteMensualArea;
                nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoAreaMes((Int32)paa.idReaMenPro, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new ReajusteMensualAreaMes();
                    nuevaArea.idReaMenArea = paa.idReaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = importe;
                    nuevaArea.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    reajusteMensualPresupuestoServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    nuevaArea.importe = importe;
                    nuevaArea.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    reajusteMensualPresupuestoServicio.ModificarAreasMes(nuevaArea);
                }
            }
            return nuevaArea;
        }

        private ReajusteMensualAreaMes IngresarCantidadAreaOtro(int mes, decimal precio, decimal cantidad)
        {
            ReajusteMensualAreaMes nuevaArea = null;
            if (reajusteMensualPresupuestoVista.ReajusteMensualArea != null)
            {
                var paa = reajusteMensualPresupuestoVista.ReajusteMensualArea;
                nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoAreaMes((Int32)paa.idReaMenPro, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new ReajusteMensualAreaMes();
                    nuevaArea.idReaMenArea = paa.idReaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    reajusteMensualPresupuestoServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    ReajusteMensualDetalle programacionAnualDetalle_ = reajusteMensualPresupuestoVista.ReajusteMensualDetalle;
                    suma = reajusteMensualPresupuestoServicio.BuscarImportePorArea(paa.idReaMenArea, programacionAnualDetalle_.descripcion, programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);

                    nuevaArea.importe = suma + Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    reajusteMensualPresupuestoServicio.ModificarAreasMes(nuevaArea);
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

            ReajusteMensualAreaMes ReajusteMensualProgramacionArea_ = IngresarMontoAreaOtro(mes, importe);

            if (ReajusteMensualProgramacionArea_ != null)
            {
                ReajusteMensualDetalle programacionAnualDetalle_ = reajusteMensualPresupuestoVista.ReajusteMensualDetalle;
                ReajusteMensualDetalleMes programacionAnualDetalle = reajusteMensualPresupuestoServicio.BuscarPorCodigoDetalleMes(ReajusteMensualProgramacionArea_.idReaMenAreaMes, programacionAnualDetalle_.idReaMenDet, programacionAnualDetalle_.descripcion,
                                                                                                                         programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);
                //nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

                if (programacionAnualDetalle != null)
                {
                    programacionAnualDetalle.cantidad = Math.Round(importe / programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.importe = importe;
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    respuesta = reajusteMensualPresupuestoServicio.ModificarDetallesMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                else
                {
                    programacionAnualDetalle = new ReajusteMensualDetalleMes();
                    programacionAnualDetalle.idReaMenDet = programacionAnualDetalle_.idReaMenDet;
                    programacionAnualDetalle.idReaMenDetMes = ReajusteMensualProgramacionArea_.idReaMenAreaMes;
                    programacionAnualDetalle.cantidad = Math.Round(importe / programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.importe = importe;
                    programacionAnualDetalle.fechaCrea = DateTime.Now;
                    programacionAnualDetalle.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    programacionAnualDetalle.estado = Estados.Activo;
                    respuesta = reajusteMensualPresupuestoServicio.NuevoDetalleMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                
            }

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            ReajusteMensualAreaMes ReajusteMensualArea_ = IngresarCantidadAreaOtro(mes, precio, cantidad);

            if (ReajusteMensualArea_ != null)
            {
                ReajusteMensualDetalle reajusteMensualDetalle = reajusteMensualPresupuestoVista.ReajusteMensualDetalle;
                ReajusteMensualDetalleMes reajusteMensualDetalleMes = reajusteMensualPresupuestoServicio.BuscarPorCodigoDetalleMes(ReajusteMensualArea_.idReaMenAreaMes, reajusteMensualDetalle.idReaMenDet, reajusteMensualDetalle.descripcion,
                                                                                                                         reajusteMensualDetalle.idUnidad, reajusteMensualDetalle.precio);
                //nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

                if (reajusteMensualDetalleMes != null)
                {
                    //programacionAnualDetalle.idReaMenProArea = ReajusteMensualArea_.idReaMenArea;
                    reajusteMensualDetalleMes.cantidad = cantidad;
                    reajusteMensualDetalleMes.importe = Math.Round(cantidad * reajusteMensualDetalle.precio, 2);
                    reajusteMensualDetalleMes.fechaEdita = DateTime.Now;
                    reajusteMensualDetalleMes.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    respuesta = reajusteMensualPresupuestoServicio.ModificarDetallesMes(reajusteMensualDetalleMes, !esNuevaArea).esCorrecto;
                }
                else
                {
                    reajusteMensualDetalleMes = new ReajusteMensualDetalleMes();
                    reajusteMensualDetalleMes.idReaMenDet = reajusteMensualDetalle.idReaMenDet;
                    //programacionAnualDetalle.idReaMenDetMes = ReajusteMensualArea_.idReaMenAreaMes;
                    reajusteMensualDetalleMes.cantidad = cantidad;
                    reajusteMensualDetalleMes.importe = Math.Round(cantidad * reajusteMensualDetalle.precio, 2);
                    reajusteMensualDetalleMes.idReaMenAreaMes = ReajusteMensualArea_.idReaMenAreaMes;
                    reajusteMensualDetalleMes.fechaCrea = DateTime.Now;
                    reajusteMensualDetalleMes.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    reajusteMensualDetalleMes.estado = Estados.Activo;
                    respuesta = reajusteMensualPresupuestoServicio.NuevoDetalleMes(reajusteMensualDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, int dias, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            ReajusteMensualAreaMes reajusteMensualAreaMes = IngresarCantidadAreaOtro(mes, dias, precio, cantidad);

            if (reajusteMensualAreaMes != null)
            {
                ReajusteMensualDetalle reajusteMensualDetalle_ = reajusteMensualPresupuestoVista.ReajusteMensualDetalle;
                ReajusteMensualDetalleMes reajusteMensualDetalleMes = reajusteMensualPresupuestoServicio.BuscarPorCodigoDetalleMes(reajusteMensualAreaMes.idReaMenAreaMes, reajusteMensualDetalle_.idReaMenDet, reajusteMensualDetalle_.descripcion,
                                                                                                                         reajusteMensualDetalle_.idUnidad, reajusteMensualDetalle_.precio);
                //nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes)
                if (reajusteMensualDetalleMes != null)
                {
                    reajusteMensualDetalleMes.dias = dias;
                    reajusteMensualDetalleMes.cantidad = cantidad;
                    reajusteMensualDetalleMes.importe = Math.Round(dias * cantidad * reajusteMensualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    reajusteMensualDetalleMes.fechaEdita = DateTime.Now;
                    reajusteMensualDetalleMes.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    respuesta = reajusteMensualPresupuestoServicio.ModificarDetallesMes(reajusteMensualDetalleMes, !esNuevaArea).esCorrecto;
                }
                else
                {
                    reajusteMensualDetalleMes = new ReajusteMensualDetalleMes();
                    reajusteMensualDetalleMes.cantidad = cantidad;
                    reajusteMensualDetalleMes.dias = dias;
                    reajusteMensualDetalleMes.importe = Math.Round(dias * cantidad * reajusteMensualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    reajusteMensualDetalleMes.idReaMenAreaMes = reajusteMensualAreaMes.idReaMenAreaMes;
                    reajusteMensualDetalleMes.idReaMenDet = reajusteMensualDetalle_.idReaMenDet;
                    reajusteMensualDetalleMes.fechaCrea = DateTime.Now;
                    reajusteMensualDetalleMes.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    reajusteMensualDetalleMes.estado = Estados.Activo;
                    respuesta = reajusteMensualPresupuestoServicio.NuevoDetalleMes(reajusteMensualDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }

        private ReajusteMensualAreaMes IngresarCantidadAreaOtro(int mes, int dias, decimal precio, decimal cantidad)
        {
            ReajusteMensualAreaMes nuevaArea = null;
            if (reajusteMensualPresupuestoVista.ReajusteMensualArea != null)
            {
                var paa = reajusteMensualPresupuestoVista.ReajusteMensualArea;
                nuevaArea = reajusteMensualPresupuestoServicio.BuscarPorCodigoAreaMes((int)paa.idReaMenArea, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new ReajusteMensualAreaMes();
                    nuevaArea.idReaMenArea = paa.idReaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuCrea = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    reajusteMensualPresupuestoServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    ReajusteMensualDetalle reajusteMensualDetalle = reajusteMensualPresupuestoVista.ReajusteMensualDetalle;
                    suma = reajusteMensualPresupuestoServicio.BuscarImportePorArea(nuevaArea.idReaMenAreaMes, reajusteMensualDetalle.idReaMenDet);

                    nuevaArea.importe = suma + Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuEdita = reajusteMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    reajusteMensualPresupuestoServicio.ModificarAreasMes(nuevaArea);
                }
            }
            return nuevaArea;
        }

    }
}
