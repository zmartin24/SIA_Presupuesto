using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ProgramacionAnualPresentador
    {
        private readonly IProgramacionAnualVista programacionAnualVista;
        private int mes;
        private ProgramacionAnual ProgramacionAnual;
        private IProgramacionAnualServicio programacionAnualServicio;

        public ProgramacionAnualPresentador(ProgramacionAnual ProgramacionAnual, IProgramacionAnualVista programacionAnualVista, int Mes)
        {
            IContenedor _Contenedor = new cContenedor();
            mes = Mes;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.programacionAnualVista = programacionAnualVista;
            this.ProgramacionAnual = ProgramacionAnual;

            
        }

        public void ObtenerDatosListado()
        {
            List<ProgramacionAnualAreaPres> oLista = new List<ProgramacionAnualAreaPres>();
            oLista = programacionAnualServicio.TraerListaProgramacionAnualArea(ProgramacionAnual.idProAnu);

            programacionAnualVista.listaDatosPrincipales = oLista;

            foreach (ProgramacionAnualAreaPres item in oLista)
            {
                switch (mes)
                {
                    case 1:item.enero = item.enero;break;
                    case 2:item.enero = item.febrero;break;
                    case 3: item.enero = item.marzo; break;
                    case 4: item.enero = item.abril; break;
                    case 5: item.enero = item.mayo; break;
                    case 6: item.enero = item.junio; break;
                    case 7: item.enero = item.julio; break;
                    case 8: item.enero = item.agosto; break;
                    case 9: item.enero = item.setiembre; break;
                    case 10: item.enero = item.octubre; break;
                    case 11: item.enero = item.noviembre; break;
                    case 12: item.enero = item.diciembre; break;
                    default:break;
                }
            }   
            //
        }

        public ProgramacionAnualArea BuscarArea(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigoArea(id);
        }

        public ProgramacionAnualDetalle BuscarDetalle(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigoDetalle(id);
        }

        public void IniciarDatos()
        {

        }

        public bool AnularArea()
        {
            bool respuesta = false;
            if (programacionAnualVista.ProgramacionAnualArea != null)
                //respuesta = this.programacionAnualServicio.AnularArea(programacionAnualVista.ProgramacionAnualArea, programacionAnualVista.UsuarioOperacion.NomUsuario).esCorrecto;
                respuesta = this.programacionAnualServicio.AnularProgramacionAnualAreaPorCuenta(programacionAnualVista.ProgramacionAnualArea, programacionAnualVista.UsuarioOperacion.NomUsuario);
            return respuesta;
        }

        public bool AnularDetalle()
        {
            bool respuesta = false;
            if (programacionAnualVista.ProgramacionAnualDetalle != null)
                respuesta = this.programacionAnualServicio.AnularDetalle(programacionAnualVista.ProgramacionAnualDetalle, programacionAnualVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }

        public bool IngresarMontoArea(int mes, decimal importe)
        {
            bool respuesta = false;
            if (programacionAnualVista.ProgramacionAnualArea != null)
            {
                var paa = programacionAnualVista.ProgramacionAnualArea;
                ProgramacionAnualAreaMes nuevaArea = null;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idProAnuArea, mes);
                if(nuevaArea == null)
                {
                    nuevaArea = new ProgramacionAnualAreaMes();
                    nuevaArea.idProAnuArea = paa.idProAnuArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = importe;
                    nuevaArea.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoAreaMes(nuevaArea).esCorrecto;
                }
                else
                {
                    nuevaArea.importe = importe;
                    nuevaArea.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    respuesta = programacionAnualServicio.ModificarAreasMes(nuevaArea).esCorrecto;
                }
            }
            ObtenerDatosListado();
            return respuesta;
        }
        private bool esNuevaArea;
        private ProgramacionAnualAreaMes IngresarMontoAreaOtro(int mes, decimal importe)
        {
            ProgramacionAnualAreaMes nuevaArea = null;
            if (programacionAnualVista.ProgramacionAnualArea != null)
            {
                var paa = programacionAnualVista.ProgramacionAnualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idProAnuArea, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new ProgramacionAnualAreaMes();
                    nuevaArea.idProAnuArea = paa.idProAnuArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = importe;
                    nuevaArea.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    nuevaArea.importe = importe;
                    nuevaArea.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    programacionAnualServicio.ModificarAreasMes(nuevaArea);
                }
            }
            return nuevaArea;
        }

        private ProgramacionAnualAreaMes IngresarCantidadAreaOtro(int mes, int dias, decimal precio, decimal cantidad)
        {
            ProgramacionAnualAreaMes nuevaArea = null;
            if (programacionAnualVista.ProgramacionAnualArea != null)
            {
                var paa = programacionAnualVista.ProgramacionAnualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(paa.idProAnuArea, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new ProgramacionAnualAreaMes();
                    nuevaArea.idProAnuArea = paa.idProAnuArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    ProgramacionAnualDetalle programacionAnualDetalle_ = programacionAnualVista.ProgramacionAnualDetalle;
                    suma = programacionAnualServicio.BuscarImportePorArea(nuevaArea.idProAnuAreaMes, programacionAnualDetalle_.descripcion, programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);
                    //nuevaArea.mes = mes;
                    nuevaArea.importe = suma + Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaEdita = DateTime.Now;

                    programacionAnualServicio.ModificarAreasMes(nuevaArea);
                }
            }
            return nuevaArea;
        }

        private ProgramacionAnualAreaMes IngresarCantidadAreaOtro(int idProAnuArea, int mes, int dias, decimal precio, decimal cantidad)
        {
            ProgramacionAnualAreaMes nuevaArea = null;
            if (programacionAnualVista.ProgramacionAnualArea != null)
            {
                //var paa = programacionAnualVista.ProgramacionAnualArea;
                nuevaArea = programacionAnualServicio.BuscarPorCodigoAreaMes(idProAnuArea, mes);
                if (nuevaArea == null)
                {
                    nuevaArea = new ProgramacionAnualAreaMes();
                    nuevaArea.idProAnuArea = idProAnuArea;
                    nuevaArea.mes = mes;
                    nuevaArea.importe = Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    programacionAnualServicio.NuevoAreaMes(nuevaArea);

                    esNuevaArea = true;
                }
                else
                {
                    decimal suma = 0;

                    ProgramacionAnualDetalle programacionAnualDetalle_ = programacionAnualVista.ProgramacionAnualDetalle;
                    suma = programacionAnualServicio.BuscarImportePorArea(nuevaArea.idProAnuAreaMes, programacionAnualDetalle_.descripcion, programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);
                    //nuevaArea.mes = mes;
                    nuevaArea.importe = suma + Math.Round(dias * precio * cantidad, 2, MidpointRounding.AwayFromZero);
                    nuevaArea.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
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

            ProgramacionAnualAreaMes ProgramacionAnualArea_ = IngresarMontoAreaOtro(mes, importe);

            if (ProgramacionAnualArea_ != null)
            {
                ProgramacionAnualDetalle programacionAnualDetalle_ = programacionAnualVista.ProgramacionAnualDetalle;
                ProgramacionAnualDetalleMes programacionAnualDetalle = programacionAnualServicio.BuscarPorCodigoDetalleMes(ProgramacionAnualArea_.idProAnuAreaMes, programacionAnualDetalle_.descripcion,
                                                                                                                         programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);

                if (programacionAnualDetalle != null)
                {
                    programacionAnualDetalle.cantidad = Math.Round(importe / programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.importe = importe;
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    respuesta = programacionAnualServicio.ModificarDetallesMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                else
                {
                    programacionAnualDetalle = new ProgramacionAnualDetalleMes();
                    programacionAnualDetalle.idProAnuDet = programacionAnualDetalle_.idProAnuDet;
                    programacionAnualDetalle.idProAnuAreaMes = ProgramacionAnualArea_.idProAnuAreaMes;
                    programacionAnualDetalle.cantidad = Math.Round(importe / programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.importe = importe;
                    programacionAnualDetalle.fechaCrea = DateTime.Now;
                    programacionAnualDetalle.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
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

            ProgramacionAnualAreaMes ProgramacionAnualArea_ = IngresarCantidadAreaOtro(mes, dias, precio, cantidad);

            if (ProgramacionAnualArea_ != null)
            {
                ProgramacionAnualDetalle programacionAnualDetalle_ = programacionAnualVista.ProgramacionAnualDetalle;
                ProgramacionAnualDetalleMes programacionAnualDetalle = programacionAnualServicio.BuscarPorCodigoDetalleMes(ProgramacionAnualArea_.idProAnuAreaMes, programacionAnualDetalle_.descripcion,
                                                                                                                         programacionAnualDetalle_.idUnidad, programacionAnualDetalle_.precio);
                //nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

                if (programacionAnualDetalle != null)
                {
                    //programacionAnualDetalle.idProAnuArea = ProgramacionAnualArea_.idProAnuArea;
                    programacionAnualDetalle.dias = dias;
                    programacionAnualDetalle.cantidad = cantidad;
                    programacionAnualDetalle.importe = Math.Round(dias * cantidad * programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.fechaEdita = DateTime.Now;
                    programacionAnualDetalle.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    respuesta = programacionAnualServicio.ModificarDetallesMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
                else
                {
                    programacionAnualDetalle = new ProgramacionAnualDetalleMes();
                    programacionAnualDetalle.cantidad = cantidad;
                    programacionAnualDetalle.dias = dias;
                    programacionAnualDetalle.importe = Math.Round(dias * cantidad * programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalle.idProAnuDet = programacionAnualDetalle_.idProAnuDet;
                    programacionAnualDetalle.idProAnuAreaMes = ProgramacionAnualArea_.idProAnuAreaMes;
                    programacionAnualDetalle.fechaCrea = DateTime.Now;
                    programacionAnualDetalle.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    programacionAnualDetalle.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoDetalleMes(programacionAnualDetalle, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }

        public bool IngresarCantidadDetalle(int idProAnuDet, int idProAnuArea, int mes, int dias, decimal precio, decimal cantidad)
        {
            bool respuesta = false;

            ProgramacionAnualAreaMes ProgramacionAnualArea_ = IngresarCantidadAreaOtro(idProAnuArea, mes, dias, precio, cantidad);

            if (ProgramacionAnualArea_ != null)
            {
                ProgramacionAnualDetalle programacionAnualDetalle_ = programacionAnualVista.ProgramacionAnualDetalle;
                ProgramacionAnualDetalleMes programacionAnualDetalleMes = programacionAnualServicio.BuscarPorCodigoDetalleMes(idProAnuDet, ProgramacionAnualArea_.idProAnuAreaMes);
                //nuevaArea = programacionAnualServicio.BuscarPorCodigoArea(paa.idProAnu, paa.idArea, paa.idCueCon, mes);

                if (programacionAnualDetalleMes != null)
                {
                    //programacionAnualDetalle.idProAnuArea = ProgramacionAnualArea_.idProAnuArea;
                    programacionAnualDetalleMes.dias = dias;
                    programacionAnualDetalleMes.cantidad = cantidad;
                    programacionAnualDetalleMes.importe = Math.Round(dias * cantidad * programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalleMes.fechaEdita = DateTime.Now;
                    programacionAnualDetalleMes.usuEdita = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    respuesta = programacionAnualServicio.ModificarDetallesMes(programacionAnualDetalleMes, !esNuevaArea).esCorrecto;
                }
                else
                {
                    programacionAnualDetalleMes = new ProgramacionAnualDetalleMes();
                    programacionAnualDetalleMes.cantidad = cantidad;
                    programacionAnualDetalleMes.dias = dias;
                    programacionAnualDetalleMes.importe = Math.Round(dias * cantidad * programacionAnualDetalle_.precio, 2, MidpointRounding.AwayFromZero);
                    programacionAnualDetalleMes.idProAnuDet = programacionAnualDetalle_.idProAnuDet;
                    programacionAnualDetalleMes.idProAnuAreaMes = ProgramacionAnualArea_.idProAnuAreaMes;
                    programacionAnualDetalleMes.fechaCrea = DateTime.Now;
                    programacionAnualDetalleMes.usuCrea = programacionAnualVista.UsuarioOperacion.NomUsuario;
                    programacionAnualDetalleMes.estado = Estados.Activo;
                    respuesta = programacionAnualServicio.NuevoDetalleMes(programacionAnualDetalleMes, !esNuevaArea).esCorrecto;
                }
            }

            ObtenerDatosListado();
            return respuesta;
        }
    }
}
