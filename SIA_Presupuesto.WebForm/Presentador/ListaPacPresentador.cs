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
    public class ListaPacPresentador
    {
        private readonly IListaPacVista listaPacVista;
        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGeneralServicio generalServicio;

        public ListaPacPresentador(IListaPacVista listaPacVista)
        {
            this.listaPacVista = listaPacVista;
        }

        public void Iniciar()
        {
            //listaPacVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            //listaPacVista.anioPresentacion = DateTime.Now.AddYears(1).Year;
        }

        public void ObtenerDatosListado()
        {
            this.planAnualAdquisicionServicio = IoCHelper.ResolverIoC<IPlanAnualAdquisicionServicio>();
            listaPacVista.listaDatosPrincipales = planAnualAdquisicionServicio.listarTodosActivos();// listaRequerimientoBienServicioVista.anioPresentacion, listaRequerimientoBienServicioVista.idUsuario);
        }

        public PlanAnualAdquisicion Buscar(int id)
        {
            return planAnualAdquisicionServicio.Buscar(id);
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
            PlanAnualAdquisicion planAnualAdquisicion = Buscar(id);
            return planAnualAdquisicionServicio.Anular(planAnualAdquisicion, listaPacVista.nomUsuario).esCorrecto;
        }

        public void ImprimirRequerimiento(int id)
        {
            PlanAnualAdquisicion planAnualAdquisicion = Buscar(id);
            if (planAnualAdquisicion != null)
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
            this.planAnualAdquisicionServicio = IoCHelper.ResolverIoC<IPlanAnualAdquisicionServicio>();
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
            listaPacVista.listaDireccionesReporte = generalServicio.ListaDirecciones();

            var listaReporte = PredeterminadoHelper.ListarTipoReportePac();
            if (listaReporte != null)
            {
                listaPacVista.listaReporte = listaReporte;
                listaPacVista.codReporte = listaReporte.FirstOrDefault().codigo;
            }

            var listaDirecciones = generalServicio.ListaDirecciones();
            if (listaDirecciones != null)
            {
                listaDirecciones.Add(new Direccion { idDireccion = 0, desDireccion = "[TODOS]" });
                listaPacVista.listaDireccionesReporte = listaDirecciones.OrderBy(x => x.idDireccion).ToList();
                listaPacVista.idDireccion = listaDirecciones.OrderBy(x => x.idDireccion).FirstOrDefault().idDireccion;
            }

            var listaFueFin = generalServicio.ListaFuenteFinanciamiento();
            if (listaFueFin != null)
            {
                listaFueFin.Add(new FuenteFinanciamiento { idFueFin = 0, fuente = "[TODOS]" });
                listaPacVista.listaFuenteFinanciamientoReporte = listaFueFin.OrderBy(x => x.idFueFin).ToList();
                listaPacVista.idFueFin = listaFueFin.OrderBy(x => x.idFueFin).FirstOrDefault().idFueFin;
            }
        }

        private void LlenarCombosRequerimiento()
        {
            //listaPacVista.listaMonedas = generalServicio.ListaMonedas();

            //List<Direccion> listaDireccion = new List<Direccion>();
            //listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            //listaDireccion.AddRange(generalServicio.ListaDirecciones());

            //listaPacVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            //if (idDireccion > 0)
            //    listaPacVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            //else
            //{
            //    List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
            //    listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
            //    listaPacVista.listaSubdirecciones = listaSubdireccion;
            //}
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            //if (idSubDireccion > 0)
            //    listaPacVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            //else
            //{
            //    List<Area> listaAreas = new List<Area>();
            //    listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
            //    listaPacVista.listaAreas = listaAreas;
            //}
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

        public string ExportarPac(int id)
        {
            string ruta = string.Empty;
            PlanAnualAdquisicion pac = planAnualAdquisicionServicio.Buscar(id);
            List<ReportePlanAnualAdquisicionExportaPres> lista = planAnualAdquisicionServicio.TraerReportePlanAnualAdquisicionExporta(id, 0, 0);
            if (lista.Count > 0)
                ruta = ExportarPac(pac, lista);
            return ruta;
        }
        private string ExportarPac(PlanAnualAdquisicion pac, List<ReportePlanAnualAdquisicionExportaPres> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "PlanAnualContraciones_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarPAC(ruta, lista);

            }

            return ruta;
        }
    }
}
