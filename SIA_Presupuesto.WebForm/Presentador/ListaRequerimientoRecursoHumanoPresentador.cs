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
    public class ListaRequerimientoRecursoHumanoPresentador
    {
        private readonly IListaRequerimientoRecursoHumanoVista listaRequerimientoRecursoHumanoVista;
        private IRequerimientoRecursoHumanoServicio requerimientoRecursoHumanoServicio;
        private IGeneralServicio generalServicio;
        private IPeriodoServicio periodoServicio;
        Periodo periodo = new Periodo();

        public ListaRequerimientoRecursoHumanoPresentador(IListaRequerimientoRecursoHumanoVista listaRequerimientoRecursoHumanoVista)
        {
            this.listaRequerimientoRecursoHumanoVista = listaRequerimientoRecursoHumanoVista;
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
            periodo = this.periodoServicio.ObtenerActivo();
        }

        public void Iniciar()
        {
            listaRequerimientoRecursoHumanoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaRequerimientoRecursoHumanoVista.anioPresentacion = this.periodoServicio.ObtenerActivo().anio;
        }

        public void ObtenerDatosListado()
        {
            this.requerimientoRecursoHumanoServicio = IoCHelper.ResolverIoC<IRequerimientoRecursoHumanoServicio>();
            listaRequerimientoRecursoHumanoVista.listaDatosPrincipales = requerimientoRecursoHumanoServicio.TraerListaRequerimientoRecursoHumano(listaRequerimientoRecursoHumanoVista.anioPresentacion, listaRequerimientoRecursoHumanoVista.idUsuario);
        }

        public Periodo ObtenerxAnio()
        {
            return this.periodoServicio.ObtenerxAnio(listaRequerimientoRecursoHumanoVista.anioPresentacion);
        }

        public RequerimientoRecursoHumano Buscar(int id)
        {
            return requerimientoRecursoHumanoServicio.BuscarPorCodigo(id);
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
            RequerimientoRecursoHumano requerimientoRecursoHumano = Buscar(id);
            return requerimientoRecursoHumanoServicio.Anular(requerimientoRecursoHumano, listaRequerimientoRecursoHumanoVista.nomUsuario).esCorrecto;
        }

        public void ImprimirRequerimiento(int id)
        {
            //RequerimientoBienServicio RequerimientoBienServicio = Buscar(id);
            //if (RequerimientoBienServicio != null)
            //{
            //    List<RequerimientoBienServicioDetallePres> comp = requerimientoRecursoHumanoServicio.TraerListaRequerimientoBienServicioDetalle(id);
            //    rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();

            //    ReporteWinForDev frm = new ReporteWinForDev();
            //    List<ParametrosReporte> p = new List<ParametrosReporte>();
            //    frm.report = reporte;
            //    frm.datosReporte = comp;
            //    frm.listaParametros = p;
            //    frm.AbrirDocumento(true, false);
            //}
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.requerimientoRecursoHumanoServicio = IoCHelper.ResolverIoC<IRequerimientoRecursoHumanoServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
        }

        //Requerimiento
        public void IniciarDatosRequerimiento(int id)
        {
            //
            listaRequerimientoRecursoHumanoVista.anio = periodo != null ? periodo.anio : DateTime.Now.Year;
            listaRequerimientoRecursoHumanoVista.fechaEmision = DateTime.Now.Date;
            listaRequerimientoRecursoHumanoVista.idMoneda = 64;

            LlenarCombosRequerimiento();
            RequerimientoRecursoHumano requerimientoRecursoHumano = Buscar(id);
            if (requerimientoRecursoHumano == null)
                return;

            listaRequerimientoRecursoHumanoVista.idMoneda = requerimientoRecursoHumano.idMoneda;
            listaRequerimientoRecursoHumanoVista.descripcion = requerimientoRecursoHumano.descripcion.ToUpper().Trim();
            listaRequerimientoRecursoHumanoVista.anio = requerimientoRecursoHumano.anio;
            listaRequerimientoRecursoHumanoVista.fechaEmision = requerimientoRecursoHumano.fechaEmision;
            var area = generalServicio.BuscarArea(requerimientoRecursoHumano.idArea);
            if (area != null)
            {
                var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                if (subdireccion != null)
                {
                    listaRequerimientoRecursoHumanoVista.idDireccion = subdireccion.idDireccion;
                    LlenarCombosSubdireccion(subdireccion.idDireccion, false);
                    listaRequerimientoRecursoHumanoVista.idSubdireccion = subdireccion.idSubdireccion;
                    LlenarCombosAreas(subdireccion.idSubdireccion);
                    listaRequerimientoRecursoHumanoVista.idArea = requerimientoRecursoHumano.idArea;
                }
            }
        }
        public void IniciarReporte(int id)
        {
            listaRequerimientoRecursoHumanoVista.listaAnioReporte = periodoServicio.ListaPeriodo();
            listaRequerimientoRecursoHumanoVista.listaDireccionesReporte = generalServicio.ListaDirecciones();
        }
        public void IniciarReporteImporte()
        {
            this.listaRequerimientoRecursoHumanoVista.listaAnioReporteImp = this.periodoServicio.ListaPeriodo();
            this.listaRequerimientoRecursoHumanoVista.listaMonedasReporteImp = this.generalServicio.ListaMonedas();
            this.listaRequerimientoRecursoHumanoVista.listaDireccionesReporteImp = this.generalServicio.ListaDirecciones();
            
            this.listaRequerimientoRecursoHumanoVista.anioReporteImp = periodo != null ? periodo.anio : DateTime.Now.Year;
            this.listaRequerimientoRecursoHumanoVista.idMonedaReporteImp = 63;
        }

        private void LlenarCombosRequerimiento()
        {
            List<Moneda> oListaMonedas = new List<Moneda>();
            oListaMonedas = generalServicio.ListaMonedas();
            listaRequerimientoRecursoHumanoVista.listaMonedas = oListaMonedas;

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            listaRequerimientoRecursoHumanoVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion, bool esReporte)
        {
            var listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            if (idDireccion > 0)
            {
                listaRequerimientoRecursoHumanoVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
                if (esReporte)
                    listaRequerimientoRecursoHumanoVista.listaSubdireccionesReporte = listaSubdirecciones;
                else
                    listaRequerimientoRecursoHumanoVista.listaSubdirecciones = listaSubdirecciones;
            }
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                if (esReporte)
                    listaRequerimientoRecursoHumanoVista.listaSubdireccionesReporte = listaSubdireccion;
                else
                    listaRequerimientoRecursoHumanoVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosSubdireccionReporteImp(int idDireccion)
        {
            var listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            if (idDireccion > 0)
            {
                this.listaRequerimientoRecursoHumanoVista.listaSubdireccionesReporteImp = listaSubdirecciones;
                //this.listaRequerimientoRecursoHumanoVista.idSubdireccionReporteImp = listaSubdirecciones.OrderByDescending(x=>x.desSubdireccion).FirstOrDefault().idSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                listaRequerimientoRecursoHumanoVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                listaRequerimientoRecursoHumanoVista.listaAreas = listaAreas;
            }
        }

        private bool esModificacion;
        public Resultado GuardarDatosRequerimiento(string args)
        {
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            RequerimientoRecursoHumano requerimientoRecursoHumano = null;
            if (callbackArgs[0] == "Nuevo")
            {
                requerimientoRecursoHumano = new RequerimientoRecursoHumano();
            }
            else if (callbackArgs[0] == "Editar")
            {
                int id = int.Parse(callbackArgs[1]);
                requerimientoRecursoHumano = Buscar(id);
                esModificacion = true;
            }

            if (requerimientoRecursoHumano == null)
                return null;

            requerimientoRecursoHumano.idArea = Convert.ToInt32(callbackArgs[2]);
            requerimientoRecursoHumano.idMoneda = Convert.ToInt32(callbackArgs[3]);
            requerimientoRecursoHumano.descripcion = Convert.ToString(callbackArgs[4]).ToUpper().Trim();
            requerimientoRecursoHumano.anio = Convert.ToInt32(callbackArgs[5]);
            
            if (this.esModificacion)
            {
                
                requerimientoRecursoHumano.fechaEdita = DateTime.Now;
                requerimientoRecursoHumano.usuEdita = listaRequerimientoRecursoHumanoVista.nomUsuario;
                resultado = requerimientoRecursoHumanoServicio.ModificarSinClonar(requerimientoRecursoHumano);
            }
            else
            {
                requerimientoRecursoHumano.fechaEmision = DateTime.Now;
                requerimientoRecursoHumano.fechaCrea = DateTime.Now;
                requerimientoRecursoHumano.usuCrea = listaRequerimientoRecursoHumanoVista.nomUsuario;
                requerimientoRecursoHumano.estado = Estados.Activo;
                resultado = requerimientoRecursoHumanoServicio.Nuevo(requerimientoRecursoHumano);
            }
            return resultado;
        }

    }
}
