using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Reporte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ExportarPresupuestoRemuneracionMasivoPresentador
    {
        private readonly IExportarPresupuestoRemuneracionMasivoVista exportarReajusteEvaluacionVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IPresupuestoRemuneracionServicio presupuestoRemuneracionServicio;

        public ExportarPresupuestoRemuneracionMasivoPresentador(IExportarPresupuestoRemuneracionMasivoVista exportarReajusteEvaluacionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;
            this.presupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IPresupuestoRemuneracionServicio)) as IPresupuestoRemuneracionServicio;

            this.exportarReajusteEvaluacionVista = exportarReajusteEvaluacionVista;
        } 

        public void Inicializar()
        {
            exportarReajusteEvaluacionVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            exportarReajusteEvaluacionVista.anioReporte = DateTime.Now.Year;

            exportarReajusteEvaluacionVista.listaDirecciones = generalServicio.ListaDirecciones();
        }

        public void AsignarMesReajuste()
        {
            //exportarReajusteEvaluacionVista.mesReporteRea = exportarReajusteEvaluacionVista.mesReporte == 12 ? exportarReajusteEvaluacionVista.mesReporte :
            //    exportarReajusteEvaluacionVista.mesReporte + 1;
        }

        public void Exportar()
        {
            ExportarEvaluacionReajuste();
        }

        public void ExportarEvaluacionReajuste()
        {
            List<PresupuestoRemuneracionExporta> lista = presupuestoRemuneracionServicio
                .PresupuestoRemuneracionExporta("", exportarReajusteEvaluacionVista.idsDireccion, exportarReajusteEvaluacionVista.anioReporte);
            ExportarEvaluacionReajuste(lista);
        }

        private void ExportarEvaluacionReajuste(List<PresupuestoRemuneracionExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "ExportacionRemuneracionPres_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarPresupuestoRemuneracion(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
