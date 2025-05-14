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
    public class PresupuestoAnualDetallePresentador
    {
        private readonly IPresupuestoAnualDetalleVista presupuestoAnualDetalleVista;

        //private RequerimientoBienServicio RequerimientoBienServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;

        public PresupuestoAnualDetallePresentador(IPresupuestoAnualDetalleVista presupuestoAnualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.presupuestoAnualDetalleVista = presupuestoAnualDetalleVista;
            //this.RequerimientoBienServicio = RequerimientoBienServicio;
        }

        public void CargarServicios()
        {
            this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
        }

        public void ObtenerDatosListado()
        {
            presupuestoAnualDetalleVista.listaDatosPrincipales = programacionAnualServicio.TraerListaProgramacionAnualArea(presupuestoAnualDetalleVista.idPreAnu);
        }

        public ProgramacionAnualDetalle BuscarDetalle(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigoDetalle(id);
        }

        public ProgramacionAnual Buscar(int id)
        {
            return this.programacionAnualServicio.BuscarPorCodigo(id);
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        public string BuscarSimboloMoneda(int id)
        {
            string moneda = string.Empty;
            var requerimiento = programacionAnualServicio.BuscarPorCodigo(id);
            if (requerimiento != null)
            {
                var objmoneda = generalServicio.BuscarMoneda(requerimiento.idMoneda);
                if (objmoneda != null)
                    moneda = objmoneda.abreviatura;
            }
            return moneda;
        }
    }
}
