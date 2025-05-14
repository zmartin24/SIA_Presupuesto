using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Reporte;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaGasRecPresentador
    {
        private readonly IListaGasRecVista listaGasRecVista;
        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;

        public ListaGasRecPresentador(IListaGasRecVista listaGasRecVista)
        {
            this.listaGasRecVista = listaGasRecVista;
        }

        public void Iniciar()
        {
            //listaPacVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            //listaPacVista.anioPresentacion = DateTime.Now.AddYears(1).Year;
        }

        public void ObtenerDatosListado()
        {
            this.gastoRecurrenteServicio = IoCHelper.ResolverIoC<IGastoRecurrenteServicio>();
            listaGasRecVista.listaDatosPrincipales = gastoRecurrenteServicio.listarTodosActivos();// listaRequerimientoBienServicioVista.anioPresentacion, listaRequerimientoBienServicioVista.idUsuario);
        }

        public GastoRecurrente Buscar(int id)
        {
            return gastoRecurrenteServicio.Buscar(id);
        }

        private void LlamarReporte(XtraReport report, object datosReporte, string titulo)
        {
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = report;
            frm.datosReporte = datosReporte;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }


        public bool AnularRegistro(int id)
        {
            GastoRecurrente gastoRecurrente = Buscar(id);
            return gastoRecurrenteServicio.Anular(gastoRecurrente, listaGasRecVista.nomUsuario).esCorrecto;
        }

        public void ImprimirRequerimiento(int id)
        {
            GastoRecurrente gastoRecurrente = Buscar(id);
            if (gastoRecurrente != null)
            {
                //List<RequerimientoBienServicioDetallePres> comp = planAnualAdquisicionServicio.TraerListaRequerimientoBienServicioDetalle(id);
                //rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();

                //ReporteWinForDev frm = new ReporteWinForDev();
                //List<ParametrosReporte> p = new List<ParametrosReporte>();
                //frm.report = reporte;
                //frm.datosReporte = comp;
                //frm.listaParametros = p;
                //frm.AbrirDocumento(true, false);
            }
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.gastoRecurrenteServicio = IoCHelper.ResolverIoC<IGastoRecurrenteServicio>();
        }

        //Requerimiento
        public void IniciarDatosRequerimiento(int id)
        {
            //
            //listaPacVista.anio = DateTime.Now.Year;
            //listaPacVista.fechaEmision = DateTime.Now.Date;
            //listaPacVista.idMoneda = 64;

            //LlenarCombosRequerimiento();
            //RequerimientoBienServicio RequerimientoBienServicio = Buscar(id);
            //if (RequerimientoBienServicio == null)
            //    return;

            //listaPacVista.idMoneda = RequerimientoBienServicio.idMoneda;
            //listaPacVista.descripcion = RequerimientoBienServicio.descripcion;
            //listaPacVista.anio = RequerimientoBienServicio.anio;
            //listaPacVista.fechaEmision = RequerimientoBienServicio.fechaEmision;
            //var area = generalServicio.BuscarArea(RequerimientoBienServicio.idArea);
            //if (area != null)
            //{
            //    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
            //    if (subdireccion != null)
            //    {
            //        listaPacVista.idDireccion = subdireccion.idDireccion;
            //        LlenarCombosSubdireccion(subdireccion.idDireccion);
            //        listaPacVista.idSubdireccion = subdireccion.idSubdireccion;
            //        LlenarCombosAreas(subdireccion.idSubdireccion);
            //        listaPacVista.idArea = RequerimientoBienServicio.idArea;
            //    }
            //}
        }
        public void IniciarReporte(int id)
        {
            listaGasRecVista.listaDireccionesReporte = generalServicio.ListaDirecciones();
        }

        private bool esModificacion;
        public Resultado GuardarDatosRequerimiento(string args)
        {
            Resultado resultado = null;
            //var callbackArgs = Util.DeserializeCallbackArgs(args);

            //RequerimientoBienServicio RequerimientoBienServicio = null;
            //if (callbackArgs[0] == "Nuevo")
            //{
            //    RequerimientoBienServicio = new RequerimientoBienServicio();
            //}
            //else if (callbackArgs[0] == "Editar")
            //{
            //    int id = int.Parse(callbackArgs[1]);
            //    RequerimientoBienServicio = Buscar(id);
            //    esModificacion = true;
            //}

            //if (RequerimientoBienServicio == null)
            //    return null;

            //RequerimientoBienServicio.idMoneda = listaPacVista.idMoneda;
            //RequerimientoBienServicio.descripcion = listaPacVista.descripcion;
            //RequerimientoBienServicio.anio = listaPacVista.anio;
            //RequerimientoBienServicio.fechaEmision = listaPacVista.fechaEmision;
            //RequerimientoBienServicio.idArea = listaPacVista.idArea;

            //if (this.esModificacion)
            //{
            //    RequerimientoBienServicio.fechaEdita = DateTime.Now;
            //    RequerimientoBienServicio.usuEdita = listaPacVista.nomUsuario;
            //    resultado = planAnualAdquisicionServicio.ModificarSinClonar(RequerimientoBienServicio);
            //}
            //else
            //{
            //    RequerimientoBienServicio.fechaCrea = DateTime.Now;
            //    RequerimientoBienServicio.usuCrea = listaPacVista.nomUsuario;
            //    RequerimientoBienServicio.estado = Estados.Activo;
            //    resultado = planAnualAdquisicionServicio.Nuevo(RequerimientoBienServicio);
            //}

            return resultado;
        }

    }
}
