using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class DetalleProgramacionMensualPresentador
    {
        private readonly IDetalleProgramacionMensualVista detalleProgramacionMensualVista;
        private ISubpresupuestoServicio subpresupuestoServicio;
        private SubPresupuestoPoco subPresupuestoPoco;
        public DetalleProgramacionMensualPresentador(SubPresupuestoPoco subPresupuestoPoco, IDetalleProgramacionMensualVista detalleProgramacionMensualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.detalleProgramacionMensualVista = detalleProgramacionMensualVista;
            this.subPresupuestoPoco = subPresupuestoPoco;
        }

        public void Iniciar()
        {
        }

        public void ObtenerDatosListado()
        {
            detalleProgramacionMensualVista.listaDatosPrincipales = subpresupuestoServicio.TraerListaSubPresupuestoAreaPres(subPresupuestoPoco.idSubPresupuesto);
        }

        
    }
}
