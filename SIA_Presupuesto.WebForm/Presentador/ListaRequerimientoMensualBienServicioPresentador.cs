using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Servicios;
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
    public class ListaRequerimientoMensualBienServicioPresentador
    {
        private readonly IListaRequerimientoMensualBienServicioVista olistaRequerimientoMensualBienServicioVista;

        private IRequerimientoMensualBienServicioServicio oNeg_RequerimientoMensualBienServicioServicio;
        private IRequerimientoBienServicioServicio requerimientoBienServicioServicio;
        private IGeneralServicio generalServicio;
        private IPeriodoServicio periodoServicio;
        Periodo periodo = new Periodo();

        public ListaRequerimientoMensualBienServicioPresentador(IListaRequerimientoMensualBienServicioVista _olistaRequerimientoBienServicioVista)
        {
            this.olistaRequerimientoMensualBienServicioVista = _olistaRequerimientoBienServicioVista;
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
            periodo = this.periodoServicio.ObtenerActivo();
        }

        public void Iniciar()
        {
            olistaRequerimientoMensualBienServicioVista.listaAniosListado = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            olistaRequerimientoMensualBienServicioVista.anioListado = DateTime.Now.Year; //this.periodoServicio.ObtenerActivo().anio;
            olistaRequerimientoMensualBienServicioVista.listaMesListado = UtilitarioComun.ListarMeses();
            olistaRequerimientoMensualBienServicioVista.mesListado = DateTime.Now.Month;

            olistaRequerimientoMensualBienServicioVista.mes = DateTime.Now.Month;
            olistaRequerimientoMensualBienServicioVista.listaMes = UtilitarioComun.ListarMeses();
            var listaTipoRequerimiento = PredeterminadoHelper.ListarTipoRequerimiento();
            var Result = from s in listaTipoRequerimiento
                         where s.codigo != "0"
                         select s;
            olistaRequerimientoMensualBienServicioVista.listaTipoRequerimiento = Result.ToList();                       
        }

        public void ObtenerDatosListado()
        {
            this.oNeg_RequerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
            olistaRequerimientoMensualBienServicioVista.listaDatosPrincipales = oNeg_RequerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(olistaRequerimientoMensualBienServicioVista.anioListado, olistaRequerimientoMensualBienServicioVista.mesListado, olistaRequerimientoMensualBienServicioVista.idUsuario, null, true);
        }

        public Periodo ObtenerxAnio()
        {
            return this.periodoServicio.ObtenerxAnio(olistaRequerimientoMensualBienServicioVista.anioListado);
        }

        public RequerimientoMensualBienServicio Buscar(int id)
        {
            return oNeg_RequerimientoMensualBienServicioServicio.BuscarPorCodigo(id);
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
            RequerimientoMensualBienServicio oRequerimientoMensualBienServicio = Buscar(id);
            return oNeg_RequerimientoMensualBienServicioServicio.Anular(oRequerimientoMensualBienServicio, olistaRequerimientoMensualBienServicioVista.nomUsuario).esCorrecto;
        }

        public void ImprimirRequerimiento(int id)
        {
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.oNeg_RequerimientoMensualBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoMensualBienServicioServicio>();
            this.requerimientoBienServicioServicio = IoCHelper.ResolverIoC<IRequerimientoBienServicioServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
        }

        public void IniciarDatosRequerimiento(int id)
        {
            olistaRequerimientoMensualBienServicioVista.anio = DateTime.Now.Year; //periodo != null ? periodo.anio : DateTime.Now.Year;
            olistaRequerimientoMensualBienServicioVista.fechaEmision = DateTime.Now.Date;
            olistaRequerimientoMensualBienServicioVista.idMoneda = 63;
            olistaRequerimientoMensualBienServicioVista.idTipoRequerimiento = 1;

            LlenarCombosRequerimiento();
            RequerimientoMensualBienServicio oRequerimientoMensualBienServicio = Buscar(id);
            
            
            if (oRequerimientoMensualBienServicio == null)
                return;

            olistaRequerimientoMensualBienServicioVista.idMoneda = oRequerimientoMensualBienServicio.idMoneda;
            olistaRequerimientoMensualBienServicioVista.descripcion = oRequerimientoMensualBienServicio.descripcion.ToUpper().Trim();
            olistaRequerimientoMensualBienServicioVista.anio = oRequerimientoMensualBienServicio.anio;
            olistaRequerimientoMensualBienServicioVista.fechaEmision = oRequerimientoMensualBienServicio.fechaEmision;
            olistaRequerimientoMensualBienServicioVista.idTipoRequerimiento = oRequerimientoMensualBienServicio.tipo;
            olistaRequerimientoMensualBienServicioVista.mes = oRequerimientoMensualBienServicio.mes;
            olistaRequerimientoMensualBienServicioVista.estado = oRequerimientoMensualBienServicio.estado;
            olistaRequerimientoMensualBienServicioVista.tieneDetalles = TraerListarDetallesTodos(id).Count > 0 ? true : false;

            var area = generalServicio.BuscarArea(oRequerimientoMensualBienServicio.idArea);
            if (area != null)
            {
                var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                if (subdireccion != null)
                {
                    olistaRequerimientoMensualBienServicioVista.idDireccion = subdireccion.idDireccion;
                    LlenarCombosSubdireccion(subdireccion.idDireccion);
                    olistaRequerimientoMensualBienServicioVista.idSubdireccion = subdireccion.idSubdireccion;
                    LlenarCombosAreas(subdireccion.idSubdireccion);
                    olistaRequerimientoMensualBienServicioVista.idArea = oRequerimientoMensualBienServicio.idArea;
                }
            }
        }
        public void IniciarDatosRequerimientoClonar(int idReqBieSerOrigen)
        {
            RequerimientoMensualBienServicio oRequerimientoMensualBienServicio = Buscar(idReqBieSerOrigen);
            olistaRequerimientoMensualBienServicioVista.idTipoRequerimiento = oRequerimientoMensualBienServicio.tipo;
            olistaRequerimientoMensualBienServicioVista.anio = DateTime.Now.Year; //periodo != null ? periodo.anio : DateTime.Now.Year; //periodo != null ? oRequerimientoMensualBienServicio.anio : DateTime.Now.Year;
            olistaRequerimientoMensualBienServicioVista.fechaEmision = DateTime.Now.Date;
            olistaRequerimientoMensualBienServicioVista.idMoneda = 63;

            LlenarCombosRequerimiento();
        }

        public void IniciarReporte(int id)
        {
            olistaRequerimientoMensualBienServicioVista.listaDireccionesReporte = generalServicio.ListaDirecciones();
            olistaRequerimientoMensualBienServicioVista.tipoReporte = "TOD";
            olistaRequerimientoMensualBienServicioVista.listaTipoRequerimientoReporte = PredeterminadoHelper.ListarTipoRequerimiento();
            olistaRequerimientoMensualBienServicioVista.idTipoRequerimientoReporte = 0;
            olistaRequerimientoMensualBienServicioVista.listaAniosReporte = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            olistaRequerimientoMensualBienServicioVista.anioReporte = olistaRequerimientoMensualBienServicioVista.anioListado;
            olistaRequerimientoMensualBienServicioVista.listaMesReporte = UtilitarioComun.ListarMeses();
            olistaRequerimientoMensualBienServicioVista.mesReporte = olistaRequerimientoMensualBienServicioVista.mesListado;
        }

        private void LlenarCombosRequerimiento()
        {
            List<Moneda> oListaMonedas = new List<Moneda>();
            oListaMonedas = generalServicio.ListaMonedas();
            olistaRequerimientoMensualBienServicioVista.listaMonedas = oListaMonedas;

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            olistaRequerimientoMensualBienServicioVista.listaDirecciones = listaDireccion;
            olistaRequerimientoMensualBienServicioVista.listaDireccionesReporte = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                olistaRequerimientoMensualBienServicioVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                olistaRequerimientoMensualBienServicioVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosSubdireccionReporte(int idDireccion)
        {
            if (idDireccion > 0)
                olistaRequerimientoMensualBienServicioVista.listaSubdireccionesReporte = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                olistaRequerimientoMensualBienServicioVista.listaSubdireccionesReporte = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                olistaRequerimientoMensualBienServicioVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                olistaRequerimientoMensualBienServicioVista.listaAreas = listaAreas;
            }
        }

        private bool esModificacion;
        public Resultado GuardarDatosRequerimiento(string args)
        {
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            RequerimientoMensualBienServicio oRequerimientoMensualBienServicio = null;
            if (callbackArgs[0] == "Nuevo")
            {
                oRequerimientoMensualBienServicio = new RequerimientoMensualBienServicio();
            }
            else if (callbackArgs[0] == "Editar")
            {
                int id = int.Parse(callbackArgs[1]);
                oRequerimientoMensualBienServicio = Buscar(id);
                esModificacion = true;
            }

            if (oRequerimientoMensualBienServicio == null)
                return null;

            oRequerimientoMensualBienServicio.idArea = Convert.ToInt32(callbackArgs[2]);
            oRequerimientoMensualBienServicio.tipo = Convert.ToInt32(callbackArgs[3]);
            oRequerimientoMensualBienServicio.idMoneda = Convert.ToInt32(callbackArgs[4]);
            oRequerimientoMensualBienServicio.anio = Convert.ToInt32(callbackArgs[5]);
            oRequerimientoMensualBienServicio.mes = Convert.ToInt32(callbackArgs[6]);
            oRequerimientoMensualBienServicio.descripcion = Convert.ToString(callbackArgs[7]).ToUpper().Trim();

            if (this.esModificacion)
            {
                oRequerimientoMensualBienServicio.fechaEdita = DateTime.Now;
                oRequerimientoMensualBienServicio.usuEdita = olistaRequerimientoMensualBienServicioVista.nomUsuario;
                resultado = oNeg_RequerimientoMensualBienServicioServicio.ModificarSinClonar(oRequerimientoMensualBienServicio);
            }
            else
            {
                oRequerimientoMensualBienServicio.fechaEmision = DateTime.Now;
                oRequerimientoMensualBienServicio.fechaCrea = DateTime.Now;
                oRequerimientoMensualBienServicio.usuCrea = olistaRequerimientoMensualBienServicioVista.nomUsuario;
                oRequerimientoMensualBienServicio.estado = Estados.Activo;
                if (this.olistaRequerimientoMensualBienServicioVista.idsReqBieSer.Length > 0)
                    resultado = oNeg_RequerimientoMensualBienServicioServicio.Nuevo(oRequerimientoMensualBienServicio, this.olistaRequerimientoMensualBienServicioVista.idsReqBieSer);
                else
                    resultado = oNeg_RequerimientoMensualBienServicioServicio.Nuevo(oRequerimientoMensualBienServicio);
            }
            return resultado;
        }

        public List<OpcionMenuSistemaUsuarioPres> TraerOpcionPorMenuSistemaUsuario()
        {
            return this.generalServicio.TraerOpcionPorMenuSistemaUsuario(this.olistaRequerimientoMensualBienServicioVista.idUsuario, 11, 5452);
        }
        public List<RequerimientoMensualDetalle> TraerListarDetallesTodos(int idReqMenBieSer)
        {
            return this.oNeg_RequerimientoMensualBienServicioServicio.TraerListarDetallesTodos(idReqMenBieSer);
        }
        public bool AsignarEstadoRequerimiento(int idReqMenBieSer, int estado)
        {
            Resultado resultado = null;
            RequerimientoMensualBienServicio req = Buscar(idReqMenBieSer);
            switch (estado)
            {
                case Estados.Aprobado:
                    req.fechaAprobacion = DateTime.Now;
                    req.estado = Estados.Aprobado;
                    break;
                case Estados.Activo:
                    req.fechaAprobacion = null;
                    req.estado = Estados.Activo;
                    break;
            }

            resultado = this.oNeg_RequerimientoMensualBienServicioServicio.ModificarSinClonar(req);

            return resultado.esCorrecto;
        }
        public Resultado ClonarDatosRequerimiento(string args)
        {
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            RequerimientoMensualBienServicio requerimientoMensualBienServicio = new RequerimientoMensualBienServicio();


            if (requerimientoMensualBienServicio == null)
                return null;

            requerimientoMensualBienServicio.estado = int.Parse(callbackArgs[1]);//idReqBieSer Origen para clonar
            requerimientoMensualBienServicio.idArea = Convert.ToInt32(callbackArgs[2]);
            requerimientoMensualBienServicio.tipo = Convert.ToInt32(callbackArgs[3]);
            requerimientoMensualBienServicio.idMoneda = Convert.ToInt32(callbackArgs[4]);
            requerimientoMensualBienServicio.anio = Convert.ToInt32(callbackArgs[5]);
            requerimientoMensualBienServicio.mes = Convert.ToInt32(callbackArgs[6]);
            requerimientoMensualBienServicio.descripcion = Convert.ToString(callbackArgs[7]).ToUpper().Trim();

            requerimientoMensualBienServicio.fechaEmision = DateTime.Now;
            requerimientoMensualBienServicio.fechaCrea = DateTime.Now;
            requerimientoMensualBienServicio.usuCrea = olistaRequerimientoMensualBienServicioVista.nomUsuario;

            resultado = this.oNeg_RequerimientoMensualBienServicioServicio.GuardarDetalleRequerimientoMensualBienesServiciosToClonar(requerimientoMensualBienServicio);


            return resultado;
        }
        public List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPorArea(int tipo, int anio, int mes, int idArea)
        {
            return this.requerimientoBienServicioServicio.TraerListaRequerimientoBienServicioPorArea(tipo, anio, mes, idArea).ToList();
        }
        public void CargarRequerimientosAnualesBienesServicios()
        {
            this.olistaRequerimientoMensualBienServicioVista.listaRequerimientoBienServicio = null;
            if (this.olistaRequerimientoMensualBienServicioVista.idReqMenBieSer == 0)
                this.olistaRequerimientoMensualBienServicioVista.listaRequerimientoBienServicio = TraerListaRequerimientoBienServicioPorArea(this.olistaRequerimientoMensualBienServicioVista.idTipoRequerimiento, this.olistaRequerimientoMensualBienServicioVista.anio, this.olistaRequerimientoMensualBienServicioVista.mes, this.olistaRequerimientoMensualBienServicioVista.idArea);
            else
                this.olistaRequerimientoMensualBienServicioVista.listaRequerimientoBienServicio = null;
        }

    }
}