using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class EvaluacionMensualPresupuestoDetallePresentador
    {
        private readonly IEvaluacionMensualPresupuestoDetalleVista evaluacionMensualPresupuestoDetalleVista;

        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IGeneralServicio generalServicio;

        public EvaluacionMensualPresupuestoDetallePresentador(IEvaluacionMensualPresupuestoDetalleVista evaluacionMensualPresupuestoDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;

            this.evaluacionMensualPresupuestoDetalleVista = evaluacionMensualPresupuestoDetalleVista;
            //this.RequerimientoBienServicio = RequerimientoBienServicio;
        }

        public void CargarServicios()
        {
            this.evaluacionMensualProgramacionServicio = IoCHelper.ResolverIoC<IEvaluacionMensualProgramacionServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
        }

        public void ObtenerDatosListado()
        {
            evaluacionMensualPresupuestoDetalleVista.listaDatosPrincipales = evaluacionMensualProgramacionServicio.TraerListaEvaluacionMensualArea(evaluacionMensualPresupuestoDetalleVista.idEvaMenPro);
        }

        public EvaluacionMensualDetalle BuscarDetalle(int id)
        {
            return this.evaluacionMensualProgramacionServicio.BuscarPorCodigoDetalle(id);
        }

        public EvaluacionMensualProgramacion Buscar(int id)
        {
            return this.evaluacionMensualProgramacionServicio.BuscarPorCodigo(id);
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        public string BuscarSimboloMoneda(int id)
        {
            string moneda = string.Empty;

            //var requerimiento = evaluacionMensualProgramacionServicio.BuscarPorCodigo(id);
            //if (requerimiento != null)
            //{
            //    var objmoneda = generalServicio.BuscarMoneda(requerimiento.idMoneda);
            //    if (objmoneda != null)
            //        moneda = objmoneda.abreviatura;
            //}

            return moneda;
        }
    }
}
