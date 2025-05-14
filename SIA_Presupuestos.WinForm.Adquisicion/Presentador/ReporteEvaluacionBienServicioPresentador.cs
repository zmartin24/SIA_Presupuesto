using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ReporteEvaluacionBienServicioPresentador
    {
        private readonly IReporteEvaluacionBienServicioVista reporteEvaluacionBienServicioVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private List<ReporteEvaluacionDetalladaBienSerExportaPres> listaReporteExporta;
        public ReporteEvaluacionBienServicioPresentador(IReporteEvaluacionBienServicioVista reporteEvaluacionBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.reporteEvaluacionBienServicioVista = reporteEvaluacionBienServicioVista;
            this.listaReporteExporta = new List<ReporteEvaluacionDetalladaBienSerExportaPres>();
        }
        public void IniciarDatos()
        {
            var listaAnio = PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                this.reporteEvaluacionBienServicioVista.listaAnio = listaAnio;
                this.reporteEvaluacionBienServicioVista.vanio = DateTime.Now.Year;
            }

            var listaGruPre = grupoPresupuestoServicio.TraerListaGrupoPresupuesto(); ;
            if (listaGruPre != null)
            {
                listaGruPre.Add(
                        new GrupoPresupuesto { idGruPre = 0, codigo = "00", descripcion = "[Todos]" }
                    );
                this.reporteEvaluacionBienServicioVista.listaGruPre = listaGruPre.OrderBy(x=>x.codigo).ToList();
                this.reporteEvaluacionBienServicioVista.vidGruPre = listaGruPre.OrderBy(x => Convert.ToInt32(x.codigo)).FirstOrDefault().idGruPre;
            }

            var listaDirecciones = generalServicio.ListaDirecciones();
            if (listaDirecciones != null)
            {
                listaDirecciones.Add(
                        new Direccion { idDireccion = 0, desDireccion = "[Todos]" }
                    );
                this.reporteEvaluacionBienServicioVista.listaDirecciones = listaDirecciones.OrderBy(x => x.desDireccion).ToList();
                this.reporteEvaluacionBienServicioVista.vidDireccion = listaDirecciones.OrderBy(x=>x.idDireccion).FirstOrDefault().idDireccion;
            }
        }
        public void llenarComboSubDireccion()
        {
            var listaSubdirecciones = generalServicio.ListaSubDirecciones(this.reporteEvaluacionBienServicioVista.vidDireccion);
            if (listaSubdirecciones != null)
            {
                listaSubdirecciones.Add(
                        new Subdireccion { idSubdireccion = 0, desSubdireccion = "[Todos]" }
                    );
                this.reporteEvaluacionBienServicioVista.listaSubdireccion = listaSubdirecciones.OrderBy(x => x.desSubdireccion).ToList();
                this.reporteEvaluacionBienServicioVista.vidSubDireccion = listaSubdirecciones.OrderBy(x => x.idSubdireccion).FirstOrDefault().idSubdireccion;
            }
        }
        public void llenarGridPivot()
        {
            
            this.reporteEvaluacionBienServicioVista.listaSplash = generalReporteServicio.TraerReporteEvaluacionDetalladaBienSer(this.reporteEvaluacionBienServicioVista.vanio,
                                                                                                                                          this.reporteEvaluacionBienServicioVista.vidGruPre, this.reporteEvaluacionBienServicioVista.vidDireccion,
                                                                                                                                          this.reporteEvaluacionBienServicioVista.vidSubDireccion);
        }

        public void ExportarEvaluacionDetalladaBienServicio()
        {
            this.listaReporteExporta = generalReporteServicio.TraerReporteEvaluacionDetalladaBienSerExporta(this.reporteEvaluacionBienServicioVista.vanio,
                                                                                                                                          this.reporteEvaluacionBienServicioVista.vidGruPre, this.reporteEvaluacionBienServicioVista.vidDireccion,
                                                                                                                                          this.reporteEvaluacionBienServicioVista.vidSubDireccion);
            ExportarEvaluacionDetalladaBienServicio(this.listaReporteExporta);
        }

        private void ExportarEvaluacionDetalladaBienServicio(List<ReporteEvaluacionDetalladaBienSerExportaPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "EvaluacionDetalladaBienServicio_" + Path.GetRandomFileName() + ".xlsx";

                ExportarHelperAdquisicion.ExportarEvaluacionDetalladaBienServicio(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }


    }
}
