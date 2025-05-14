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
    public class ListaPresupuestoMensualPresentador
    {
        private readonly IListaPresupuestoMensualVista listaPresupuestoMensualVista;
        private ISubpresupuestoServicio subpresupuestoServicio;
        private IGeneralServicio generalServicio;

        private SubPresupuestoPoco subPresupuestoPoco;
        

        public ListaPresupuestoMensualPresentador(IListaPresupuestoMensualVista listaPresupuestoMensualVista)
        {
            this.listaPresupuestoMensualVista = listaPresupuestoMensualVista;
            this.subPresupuestoPoco = new SubPresupuestoPoco();
        }

        public void Iniciar()
        {
            listaPresupuestoMensualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2005);
            listaPresupuestoMensualVista.anioPresentacion = DateTime.Now.Date.Year;
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();
        }
        public void ObtenerDatosListado()
        {
            this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();
            listaPresupuestoMensualVista.listaDatosPrincipales = subpresupuestoServicio.TraerListaSubPresupuesto(listaPresupuestoMensualVista.anioPresentacion);
        }

        public List<ReporteSubpresupuestoExportaPres> TraerReporteSubpresupuestoExporta()
        {
            return subpresupuestoServicio.TraerReporteSubpresupuestoExporta(this.listaPresupuestoMensualVista.idSubpresupuesto, this.listaPresupuestoMensualVista.idMoneda);
        }

        public void IniciarExportaPresupuestoMensual(int id)
        {
            this.subPresupuestoPoco = this.subpresupuestoServicio.BuscarSubPresupuestoPoco(id);

            this.listaPresupuestoMensualVista.desSubpresupuesto = this.subPresupuestoPoco.desSubPresupuesto;
            this.listaPresupuestoMensualVista.desPresupuesto = this.subPresupuestoPoco.desPresupuesto;
            this.listaPresupuestoMensualVista.listaMoneda = generalServicio.ListaMonedas();

            this.listaPresupuestoMensualVista.idMoneda = 63;
        }
    }
}
