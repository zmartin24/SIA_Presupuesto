using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaEvaluacionPresupuestoCuentaPresentador
    {
        private readonly IListaEvaluacionPresupuestoCuentaVista listaEvaluacionPresupuestoCuentaVista;
        private IEvaluacionPresupuestoCuentaServicio evaluacionPresupuestoCuentaServicio;
        private IGeneralServicio generalServicio;

        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IPresupuestoServicio presupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;

        public ListaEvaluacionPresupuestoCuentaPresentador(IListaEvaluacionPresupuestoCuentaVista listaEvaluacionPresupuestoCuentaVista)
        {
            this.listaEvaluacionPresupuestoCuentaVista = listaEvaluacionPresupuestoCuentaVista;
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.evaluacionPresupuestoCuentaServicio = IoCHelper.ResolverIoC<IEvaluacionPresupuestoCuentaServicio>();
            this.grupoPresupuestoServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();
            this.presupuestoServicio = IoCHelper.ResolverIoC<IPresupuestoServicio>();
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();
        }

        public void Iniciar()
        {
            listaEvaluacionPresupuestoCuentaVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaEvaluacionPresupuestoCuentaVista.anioPresentacion = DateTime.Now.Year;

            var listaMonedas = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMonedas != null)
            {
                listaEvaluacionPresupuestoCuentaVista.listaMonedas = listaMonedas;
                listaEvaluacionPresupuestoCuentaVista.idMoneda = (Int32)listaMonedas.FirstOrDefault().idMoneda;
            }

            listaEvaluacionPresupuestoCuentaVista.listaGrupoPresupuesto = grupoPresupuestoServicio.TraerListaGrupoPresupuesto();
        }
        public void LlenarComboPresupuesto(int vidGruPre)
        {
            listaEvaluacionPresupuestoCuentaVista.GrupoPresupuesto = grupoPresupuestoServicio.BuscarPorCodigo(vidGruPre);
            listaEvaluacionPresupuestoCuentaVista.listaPresupuesto = presupuestoServicio.TraerListaPresupuestoPorGrupoPresupuesto(listaEvaluacionPresupuestoCuentaVista.GrupoPresupuesto.idGruPre);
            listaEvaluacionPresupuestoCuentaVista.listaSubPresupuesto = null;
        }
        public void LlenarComboSubPresupuesto(int vidPresupuesto)
        {
            if (vidPresupuesto > 0)
            {
                var objProgramacion = programacionAnualServicio.BuscarPorCodigo(vidPresupuesto);
                listaEvaluacionPresupuestoCuentaVista.Presupuesto = new Presupuesto
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
                listaEvaluacionPresupuestoCuentaVista.listaSubPresupuesto = subpresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(listaEvaluacionPresupuestoCuentaVista.Presupuesto.idPresupuesto);
            }
            else
                listaEvaluacionPresupuestoCuentaVista.listaSubPresupuesto = null;


        }

        public List<EvaluacionPresupuestoPorCuentasPres> TraerListaEvaluacionPresupuestoPorCuentasTodo()
        {
            this.evaluacionPresupuestoCuentaServicio = IoCHelper.ResolverIoC<IEvaluacionPresupuestoCuentaServicio>();
            if (this.listaEvaluacionPresupuestoCuentaVista.idSubPresupuesto > 0)
                return evaluacionPresupuestoCuentaServicio.TraerListaEvaluacionPresupuestoPorCuentasTodo(this.listaEvaluacionPresupuestoCuentaVista.idSubPresupuesto, "", 1, listaEvaluacionPresupuestoCuentaVista.idMoneda);
            else
                return null;
        }

        public Subpresupuesto traerSubPresupuesto(int vidSubPresupuesto)
        {
            return subpresupuestoServicio.BuscarPorCodigo(vidSubPresupuesto);
        }
    }
}
