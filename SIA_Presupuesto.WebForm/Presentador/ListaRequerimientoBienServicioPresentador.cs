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
    public class ListaRequerimientoBienServicioPresentador
    {
        private readonly IListaRequerimientoBienServicioVista listaRequerimientoBienServicioVista;
        private IRequerimientoBienServicioServicio requerimientoBienServicioServicio;
        private IGeneralServicio generalServicio;
        private IPeriodoServicio periodoServicio;
        Periodo periodo = new Periodo();

        public ListaRequerimientoBienServicioPresentador(IListaRequerimientoBienServicioVista listaRequerimientoBienServicioVista)
        {
            this.listaRequerimientoBienServicioVista = listaRequerimientoBienServicioVista;
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
            periodo = this.periodoServicio.ObtenerActivo();
        }

        public void Iniciar()
        {
            //ObtenerDatosListado();
            listaRequerimientoBienServicioVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);

            
            listaRequerimientoBienServicioVista.anioPresentacion = this.periodoServicio.ObtenerActivo().anio; // DateTime.Now.AddYears(1).Year;
        }

        public void ObtenerDatosListado()
        {
            this.requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            listaRequerimientoBienServicioVista.listaDatosPrincipales = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicio(listaRequerimientoBienServicioVista.anioPresentacion, listaRequerimientoBienServicioVista.idUsuario);
        }

        public Periodo ObtenerxAnio()
        {
            return this.periodoServicio.ObtenerxAnio(listaRequerimientoBienServicioVista.anioPresentacion);
        }

        public RequerimientoBienServicio Buscar(int id)
        {
            return requerimientoBienServicioServicio.BuscarPorCodigo(id);
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
            RequerimientoBienServicio RequerimientoBienServicio = Buscar(id);
            return requerimientoBienServicioServicio.Anular(RequerimientoBienServicio, listaRequerimientoBienServicioVista.nomUsuario).esCorrecto;
        }

        public void ImprimirRequerimiento(int id)
        {
            RequerimientoBienServicio RequerimientoBienServicio = Buscar(id);
            if (RequerimientoBienServicio != null)
            {
                List<RequerimientoBienServicioDetallePres> comp = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioDetalle(id);
                rptRequerimientoBienServicio reporte = new rptRequerimientoBienServicio();

                ReporteWinForDev frm = new ReporteWinForDev();
                List<ParametrosReporte> p = new List<ParametrosReporte>();
                frm.report = reporte;
                frm.datosReporte = comp;
                frm.listaParametros = p;
                frm.AbrirDocumento(true, false);
            }
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
        }

        //Requerimiento
        public void IniciarDatosRequerimiento(int id)
        {
            listaRequerimientoBienServicioVista.anio = periodo != null ? periodo.anio : DateTime.Now.Year;
            listaRequerimientoBienServicioVista.fechaEmision = DateTime.Now.Date;
            listaRequerimientoBienServicioVista.idMoneda = 63;

            LlenarCombosRequerimiento();
            RequerimientoBienServicio RequerimientoBienServicio = Buscar(id);
            if (RequerimientoBienServicio == null)
                return;

            listaRequerimientoBienServicioVista.idMoneda = RequerimientoBienServicio.idMoneda;
            listaRequerimientoBienServicioVista.descripcion = RequerimientoBienServicio.descripcion.ToUpper().Trim();
            listaRequerimientoBienServicioVista.anio = RequerimientoBienServicio.anio;
            listaRequerimientoBienServicioVista.fechaEmision = RequerimientoBienServicio.fechaEmision;
            var area = generalServicio.BuscarArea(RequerimientoBienServicio.idArea);
            if (area != null)
            {
                var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                if (subdireccion != null)
                {
                    listaRequerimientoBienServicioVista.idDireccion = subdireccion.idDireccion;
                    LlenarCombosSubdireccion(subdireccion.idDireccion);
                    listaRequerimientoBienServicioVista.idSubdireccion = subdireccion.idSubdireccion;
                    LlenarCombosAreas(subdireccion.idSubdireccion);
                    listaRequerimientoBienServicioVista.idArea = RequerimientoBienServicio.idArea;
                }
            }
        }
        public void IniciarDatosRequerimientoClonar(int idReqBieSerOrigen)
        {
            listaRequerimientoBienServicioVista.anio = periodo != null ? periodo.anio : DateTime.Now.Year;
            listaRequerimientoBienServicioVista.fechaEmision = DateTime.Now.Date;
            listaRequerimientoBienServicioVista.idMoneda = 63;

            LlenarCombosRequerimiento();
        }

        public void IniciarReporte(int id)
        {
            listaRequerimientoBienServicioVista.listaDireccionesReporte = generalServicio.ListaDirecciones();
            listaRequerimientoBienServicioVista.listaMonedasReporte = generalServicio.ListaMonedas();
            
            listaRequerimientoBienServicioVista.tipo = "TOD";
            listaRequerimientoBienServicioVista.listaAnioReporte = periodoServicio.ListaPeriodo();
            listaRequerimientoBienServicioVista.anioReporte = periodo != null ? periodo.anio : DateTime.Now.Year;
            listaRequerimientoBienServicioVista.idMonedaReporte = 63;
        }

        private void LlenarCombosRequerimiento()
        {
            List<Moneda> oListaMonedas = new List<Moneda>();
            oListaMonedas = generalServicio.ListaMonedas();
            listaRequerimientoBienServicioVista.listaMonedas = oListaMonedas;

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            listaRequerimientoBienServicioVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                listaRequerimientoBienServicioVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                listaRequerimientoBienServicioVista.listaSubdirecciones = listaSubdireccion;
            }
        }
        public void LlenarCombosSubdireccionReporte(int idDireccion)
        {
            if (idDireccion > 0)
                listaRequerimientoBienServicioVista.listaSubDireccionesReporte = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                listaRequerimientoBienServicioVista.listaSubDireccionesReporte = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                listaRequerimientoBienServicioVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                listaRequerimientoBienServicioVista.listaAreas = listaAreas;
            }
        }

        private bool esModificacion;
        public Resultado GuardarDatosRequerimiento(string args)
        {
            //this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            //this.requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>()
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            RequerimientoBienServicio RequerimientoBienServicio = null;
            if (callbackArgs[0] == "Nuevo")
            {
                RequerimientoBienServicio = new RequerimientoBienServicio();
            }
            else if (callbackArgs[0] == "Editar")
            {
                int id = int.Parse(callbackArgs[1]);
                RequerimientoBienServicio = Buscar(id);
                esModificacion = true;
            }

            if (RequerimientoBienServicio == null)
                return null;

            RequerimientoBienServicio.idArea = Convert.ToInt32(callbackArgs[2]);
            RequerimientoBienServicio.idMoneda = Convert.ToInt32(callbackArgs[3]);
            RequerimientoBienServicio.descripcion = Convert.ToString(callbackArgs[4]).ToUpper().Trim();
            RequerimientoBienServicio.anio = Convert.ToInt32(callbackArgs[5]);
            //RequerimientoBienServicio.fechaEmision = Convert.ToDateTime(callbackArgs[6]);
            
            if (this.esModificacion)
            {
                
                RequerimientoBienServicio.fechaEdita = DateTime.Now;
                RequerimientoBienServicio.usuEdita = listaRequerimientoBienServicioVista.nomUsuario;
                resultado = requerimientoBienServicioServicio.ModificarSinClonar(RequerimientoBienServicio);
            }
            else
            {
                RequerimientoBienServicio.fechaEmision = DateTime.Now;
                RequerimientoBienServicio.fechaCrea = DateTime.Now;
                RequerimientoBienServicio.usuCrea = listaRequerimientoBienServicioVista.nomUsuario;
                RequerimientoBienServicio.estado = Estados.Activo;
                resultado = requerimientoBienServicioServicio.Nuevo(RequerimientoBienServicio);
            }

            return resultado;
        }
        public Resultado ClonarDatosRequerimiento(string args)
        {
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            RequerimientoBienServicio requerimientoBienServicio = new RequerimientoBienServicio();
            

            if (requerimientoBienServicio == null)
                return null;

            requerimientoBienServicio.estado = int.Parse(callbackArgs[1]);//idReqBieSer Origen para clonar
            requerimientoBienServicio.idArea = Convert.ToInt32(callbackArgs[2]);
            requerimientoBienServicio.idMoneda = Convert.ToInt32(callbackArgs[3]);
            requerimientoBienServicio.descripcion = Convert.ToString(callbackArgs[4]).ToUpper().Trim();
            requerimientoBienServicio.anio = Convert.ToInt32(callbackArgs[5]);

            requerimientoBienServicio.fechaEmision = DateTime.Now;
            requerimientoBienServicio.fechaCrea = DateTime.Now;
            requerimientoBienServicio.usuCrea = listaRequerimientoBienServicioVista.nomUsuario;
            
            resultado = requerimientoBienServicioServicio.GuardarDetalleRequerimientoAnualBienesServiciosToClonar(requerimientoBienServicio);
            

            return resultado;
        }

    }
}
