using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class EvaluacionMensualProgramacionPresentador
    {
        private readonly IEvaluacionMensualPresupuestoVista evaluacionMensualPresupuestoVista;

        private EvaluacionMensualProgramacion EvaluacionMensualProgramacion;
        private IEvaluacionMensualProgramacionServicio programacionAnualServicio;

        public EvaluacionMensualProgramacionPresentador(EvaluacionMensualProgramacion EvaluacionMensualProgramacion, IEvaluacionMensualPresupuestoVista evaluacionMensualPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;

            this.evaluacionMensualPresupuestoVista = evaluacionMensualPresupuestoVista;
            this.EvaluacionMensualProgramacion = EvaluacionMensualProgramacion;
        }

        public void ObtenerDatosListado()
        {
            evaluacionMensualPresupuestoVista.listaDatosPrincipales = programacionAnualServicio.TraerListaEvaluacionMensualArea(EvaluacionMensualProgramacion.idEvaMenPro);
        }

        public EvaluacionMensualArea BuscarArea(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigoArea(id);
        }

        public EvaluacionMensualDetalle BuscarDetalle(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigoDetalle(id);
        }

        public void IniciarDatos()
        {

        }

        public bool AnularArea()
        {
            bool respuesta = false;
            if (evaluacionMensualPresupuestoVista.EvaluacionMensualArea != null)
                respuesta = this.programacionAnualServicio.AnularArea(evaluacionMensualPresupuestoVista.EvaluacionMensualArea, evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool AnularDetalle()
        {
            bool respuesta = false;
            if (evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle != null)
                respuesta = this.programacionAnualServicio.AnularDetalle(evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle, evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarMontoArea(int mes, decimal importe)
        {
            bool respuesta = false;
            if (evaluacionMensualPresupuestoVista.EvaluacionMensualArea != null)
            {
                var paa = evaluacionMensualPresupuestoVista.EvaluacionMensualArea;
                EvaluacionMensualAreaMes nuevaArea = null;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idEvaMenPro, mes);
                if(nuevaArea == null)
                {
                    nuevaArea = new EvaluacionMensualAreaMes();
                    nuevaArea.idEvaMenArea = paa.idEvaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = importe;
                    nuevaArea.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    
                    respuesta = programacionAnualServicio.NuevoAreaMes(nuevaArea).esCorrecto;
                }
                else
                {
                    nuevaArea.importe = importe;
                    nuevaArea.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    respuesta = programacionAnualServicio.ModificarAreasMes(nuevaArea).esCorrecto;
                }
            }
            ObtenerDatosListado();
            return respuesta;
        }
        private bool esNuevaArea;
        private EvaluacionMensualAreaMes IngresarMontoAreaOtro(int mes, decimal importe)
        {
            EvaluacionMensualAreaMes nuevaArea = null;
            if (evaluacionMensualPresupuestoVista.EvaluacionMensualArea != null)
            {
                var paa = evaluacionMensualPresupuestoVista.EvaluacionMensualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idEvaMenPro, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new EvaluacionMensualAreaMes();
                    nuevaArea.idEvaMenArea = paa.idEvaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = importe;
                    nuevaArea.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    nuevaArea.importe = importe;
                    nuevaArea.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    programacionAnualServicio.ModificarAreasMes(nuevaArea);
                }
            }
            return nuevaArea;
        }

        private EvaluacionMensualAreaMes IngresarCantidadAreaOtro(int mes, decimal precio, decimal cantidad)
        {
            EvaluacionMensualAreaMes nuevaArea = null;
            if (evaluacionMensualPresupuestoVista.EvaluacionMensualArea != null)
            {
                var paa = evaluacionMensualPresupuestoVista.EvaluacionMensualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idEvaMenPro, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new EvaluacionMensualAreaMes();
                    nuevaArea.idEvaMenArea = paa.idEvaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    EvaluacionMensualDetalle programacionAnualDetalle_ = evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle;
                    suma = programacionAnualServicio.BuscarImportePorArea(nuevaArea.idEvaMenAreaMes, programacionAnualDetalle_.descripcion, programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);

                    nuevaArea.importe = suma + Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    programacionAnualServicio.ModificarAreasMes(nuevaArea);
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

            EvaluacionMensualAreaMes EvaluacionMensualProgramacionArea_ = IngresarMontoAreaOtro(mes, importe);

            if (EvaluacionMensualProgramacionArea_ != null)
            {
                EvaluacionMensualDetalle programacionAnualDetalle_ = evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle;
                EvaluacionMensualDetalleMes programacionAnualDetalle = programacionAnualServicio.BuscarPorCodigoDetalleMes(EvaluacionMensualProgramacionArea_.idEvaMenAreaMes, programacionAnualDetalle_.descripcion,
                                                                                                                         programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);
                //nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

                if (programacionAnualDetalle != null)
                {
                    //programacionAnualDetalle.idEvaMenProArea = EvaluacionMensualProgramacionArea_.idEvaMenArea;
                    programacionAnualDetalle.cantidad = Math.Round(importe / programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.importe = importe;
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    respuesta = programacionAnualServicio.ModificarDetallesMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                else
                {
                    programacionAnualDetalle = new EvaluacionMensualDetalleMes();
                    programacionAnualDetalle.idEvaMenProDet = programacionAnualDetalle_.idEvaMenProDet;
                    programacionAnualDetalle.idEvaMenProDetMes = EvaluacionMensualProgramacionArea_.idEvaMenAreaMes;
                    programacionAnualDetalle.cantidad = Math.Round(importe / programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.importe = importe;
                    programacionAnualDetalle.fechaCrea = DateTime.Now;
                    programacionAnualDetalle.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    programacionAnualDetalle.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoDetalleMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                
            }

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            EvaluacionMensualAreaMes EvaluacionMensualArea_ = IngresarCantidadAreaOtro(mes, precio, cantidad);

            if (EvaluacionMensualArea_ != null)
            {
                EvaluacionMensualDetalle programacionAnualDetalle_ = evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle;
                EvaluacionMensualDetalleMes programacionAnualDetalle = programacionAnualServicio.BuscarPorCodigoDetalleMes(EvaluacionMensualArea_.idEvaMenAreaMes, programacionAnualDetalle_.descripcion,
                                                                                                                         programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);
                //nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

                if (programacionAnualDetalle != null)
                {
                    //programacionAnualDetalle.idEvaMenProArea = EvaluacionMensualArea_.idEvaMenArea;
                    programacionAnualDetalle.cantidad = cantidad;
                    programacionAnualDetalle.importe = Math.Round(cantidad * programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    respuesta = programacionAnualServicio.ModificarDetallesMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                else
                {
                    programacionAnualDetalle = new EvaluacionMensualDetalleMes();
                    programacionAnualDetalle.idEvaMenProDet = programacionAnualDetalle_.idEvaMenProDet;
                    //programacionAnualDetalle.idEvaMenProDetMes = EvaluacionMensualArea_.idEvaMenAreaMes;
                    programacionAnualDetalle.cantidad = cantidad;
                    programacionAnualDetalle.importe = Math.Round(cantidad * programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.idEvaMenAreaMes = EvaluacionMensualArea_.idEvaMenAreaMes;
                    programacionAnualDetalle.fechaCrea = DateTime.Now;
                    programacionAnualDetalle.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    programacionAnualDetalle.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoDetalleMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int mes, int dias, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            EvaluacionMensualAreaMes evaluacionMensualAreaMes = IngresarCantidadAreaOtro(mes, dias, precio, cantidad);

            if (evaluacionMensualAreaMes != null)
            {
                EvaluacionMensualDetalle evaluacionMensualDetalle = evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle;
                EvaluacionMensualDetalleMes evaluacionMensualDetalleMes = programacionAnualServicio.BuscarPorCodigoDetalleMes(evaluacionMensualAreaMes.idEvaMenAreaMes, evaluacionMensualDetalle.idEvaMenProDet);

                if (evaluacionMensualDetalleMes != null)
                {
                    evaluacionMensualDetalleMes.dias = dias;
                    evaluacionMensualDetalleMes.cantidad = cantidad;
                    evaluacionMensualDetalleMes.importe = Math.Round(dias * cantidad * evaluacionMensualDetalle.precio, 2, MidpointRounding.AwayFromZero);
                    evaluacionMensualDetalleMes.fechaEdita = DateTime.Now;
                    evaluacionMensualDetalleMes.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    respuesta = programacionAnualServicio.ModificarDetallesMes(evaluacionMensualDetalleMes, !esNuevaArea).esCorrecto;
                }
                else
                {
                    evaluacionMensualDetalleMes = new EvaluacionMensualDetalleMes();
                    evaluacionMensualDetalleMes.cantidad = cantidad;
                    evaluacionMensualDetalleMes.dias = dias;
                    evaluacionMensualDetalleMes.importe = Math.Round(dias * cantidad * evaluacionMensualDetalle.precio, 2, MidpointRounding.AwayFromZero);
                    evaluacionMensualDetalleMes.idEvaMenAreaMes = evaluacionMensualAreaMes.idEvaMenAreaMes;
                    evaluacionMensualDetalleMes.idEvaMenProDet = evaluacionMensualDetalle.idEvaMenProDet;
                    evaluacionMensualDetalleMes.fechaCrea = DateTime.Now;
                    evaluacionMensualDetalleMes.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    evaluacionMensualDetalleMes.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoDetalleMes(evaluacionMensualDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }

        private EvaluacionMensualAreaMes IngresarCantidadAreaOtro(int mes, int dias, decimal precio, decimal cantidad)
        {
            EvaluacionMensualAreaMes nuevaArea = null;
            if (evaluacionMensualPresupuestoVista.EvaluacionMensualArea != null)
            {
                var paa = evaluacionMensualPresupuestoVista.EvaluacionMensualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idEvaMenArea, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new EvaluacionMensualAreaMes();
                    nuevaArea.idEvaMenArea = paa.idEvaMenArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuCrea = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    EvaluacionMensualDetalle programacionAnualDetalle_ = evaluacionMensualPresupuestoVista.EvaluacionMensualDetalle;
                    suma = programacionAnualServicio.BuscarImportePorArea(nuevaArea.idEvaMenAreaMes, programacionAnualDetalle_.idEvaMenProDet);

                    nuevaArea.importe = suma + Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuEdita = evaluacionMensualPresupuestoVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    programacionAnualServicio.ModificarAreasMes(nuevaArea);
                }
            }
            return nuevaArea;
        }
    }
}
