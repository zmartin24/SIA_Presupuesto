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
    public class ListaPresupuestoMensualDetallesPresentador
    {
        private readonly IListaPresupuestoMensualDetalleVista listaPresupuestoMensualDetalleVista;

        private ISubpresupuestoServicio subpresupuestoServicio;

        private SubPresupuestoPoco objPresupuestoPoco;


        public ListaPresupuestoMensualDetallesPresentador(IListaPresupuestoMensualDetalleVista listaPresupuestoMensualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;

            this.listaPresupuestoMensualDetalleVista = listaPresupuestoMensualDetalleVista;
            this.objPresupuestoPoco = new SubPresupuestoPoco();
        }
        
        public void CargarServicios()
        {
            this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();
        }
        public void Iniciar()
        {
            ObtenerDatosListado();
        }
        public void ObtenerDatosListado()
        {
            listaPresupuestoMensualDetalleVista.listaDatosPrincipales = subpresupuestoServicio.TraerListaSubPresupuestoAreaPres(listaPresupuestoMensualDetalleVista.idSubPre);
            objPresupuestoPoco = subpresupuestoServicio.BuscarSubPresupuestoPoco(listaPresupuestoMensualDetalleVista.idSubPre);
            listaPresupuestoMensualDetalleVista.desPresupuesto = objPresupuestoPoco.desPresupuesto;
            listaPresupuestoMensualDetalleVista.desSubPresupuesto = objPresupuestoPoco.desSubPresupuesto;
            listaPresupuestoMensualDetalleVista.tipoCambio = objPresupuestoPoco.tipoCambio.ToString();
            listaPresupuestoMensualDetalleVista.proyecto = objPresupuestoPoco.proyecto;
            listaPresupuestoMensualDetalleVista.esObra = objPresupuestoPoco.esObra == true ? "Si" : "No";

        }
    }
}

