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
    public class ListaPresupuestoAproComPresentador
    {
        private readonly IListaPresupuestoAproComVista listaPresupuestoAproComVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;

        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IPresupuestoServicio presupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;

        public ListaPresupuestoAproComPresentador(IListaPresupuestoAproComVista listaPresupuestoAproComVista)
        {
            this.listaPresupuestoAproComVista = listaPresupuestoAproComVista;
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.generalReporteServicio = IoCHelper.ResolverIoC<IGeneralReporteServicio>();
            this.grupoPresupuestoServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();
            this.presupuestoServicio = IoCHelper.ResolverIoC<IPresupuestoServicio>();
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();
        }

        public void Iniciar()
        {
            var listaMonedas = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMonedas != null)
            {
                listaPresupuestoAproComVista.listaMonedas = listaMonedas;
                listaPresupuestoAproComVista.idMoneda = (Int32)listaMonedas.FirstOrDefault().idMoneda;
            }

            listaPresupuestoAproComVista.listaGrupoPresupuesto = grupoPresupuestoServicio.TraerListaGrupoPresupuesto();
        }
        public void LlenarComboPresupuesto(int vidGruPre)
        {
            listaPresupuestoAproComVista.GrupoPresupuesto = grupoPresupuestoServicio.BuscarPorCodigo(vidGruPre);
            listaPresupuestoAproComVista.listaPresupuesto = presupuestoServicio.TraerListaPresupuestoPorGrupoPresupuesto(listaPresupuestoAproComVista.GrupoPresupuesto.idGruPre);
            listaPresupuestoAproComVista.listaSubPresupuesto = null;
        }
        public void LlenarComboSubPresupuesto(int vidPresupuesto)
        {
            if (vidPresupuesto > 0)
            {
                var objProgramacion = programacionAnualServicio.BuscarPorCodigo(vidPresupuesto);
                listaPresupuestoAproComVista.Presupuesto = new Presupuesto
                {
                    idPresupuesto = objProgramacion.idProAnu,
                    idGruPre = (Int32)objProgramacion.idGruPre,
                    codigo = string.Empty,
                    descripcion = objProgramacion.descripcion,
                    abreviatura = objProgramacion.denominacion,
                    anio = objProgramacion.anio,
                    usuCrea = objProgramacion.usuCrea,
                    fechaCrea = objProgramacion.fechaCrea,
                    usuEdita = objProgramacion.usuEdita,
                    fechaEdita = objProgramacion.fechaEdita,
                    estado = objProgramacion.estado,
                };
                listaPresupuestoAproComVista.listaSubPresupuesto = subpresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(listaPresupuestoAproComVista.Presupuesto.idPresupuesto);
            }
            else
                listaPresupuestoAproComVista.listaSubPresupuesto = null;


        }

        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> TraerReportePresupuestoAprobadoComprometidoEjecutado()
        {
            this.generalReporteServicio = IoCHelper.ResolverIoC<IGeneralReporteServicio>();
            if (this.listaPresupuestoAproComVista.idSubPresupuesto > 0)
                return generalReporteServicio.TraerReportePresupuestoAprobadoComprometidoEjecutado(this.listaPresupuestoAproComVista.idMoneda, this.listaPresupuestoAproComVista.idSubPresupuesto);
            else
                return null;
        }

        public Subpresupuesto traerSubPresupuesto(int vidSubPresupuesto)
        {
            return subpresupuestoServicio.BuscarPorCodigo(vidSubPresupuesto);
        }

        public string ExportarPresupuestoAprobadoComprometidoEjecutado(List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> lista, string vpresupuesto, string vsubPresupuesto)
        {
            string ruta = string.Empty;
            if (lista.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string format = "yyyy-MM-dd_hh.mm.ss.tt";
                    sfd.Filter = "Excel XLSX|*.xlsx";
                    sfd.Title = "Guardar el siguiente archivo";

                    ruta = Path.GetTempPath() + "PresupuestoAprobadoComprometidoEjecutado_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";

                    ExportarProHelper.ExportarPresupuestoAprobadoComprometidoEjecutado(ruta, lista.OrderBy(o => o.numCuenta).ToList(), listaPresupuestoAproComVista.idMoneda, vpresupuesto, vsubPresupuesto);
                }
            }

            return ruta;
        }



    }
}
