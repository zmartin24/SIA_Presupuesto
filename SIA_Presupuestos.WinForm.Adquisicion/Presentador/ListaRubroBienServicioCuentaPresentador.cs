using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaRubroBienServicioCuentaPresentador
    {
        private readonly IListaRubroBienServicioCuentaVista listaRubroBienServicioCuentaVista;
        private IRubroBienServicioCuentaServicio rubroBienServicioCuentaServicio;
        public ListaRubroBienServicioCuentaPresentador(IListaRubroBienServicioCuentaVista listaGastoRecurrenteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.rubroBienServicioCuentaServicio = _Contenedor.Resolver(typeof(IRubroBienServicioCuentaServicio)) as IRubroBienServicioCuentaServicio;
            this.listaRubroBienServicioCuentaVista = listaGastoRecurrenteVista;
        }

        public void InicializarDatos()
        {
            List<ItemPoco> oLista = rubroBienServicioCuentaServicio.TraerListaPlanCuenta();

            this.listaRubroBienServicioCuentaVista.listaPlanCuenta = oLista;
            this.listaRubroBienServicioCuentaVista.idPlanCuenta = oLista[1].id;
            // listaRubroBienServicioCuentaVista.listaDatosPrincipales = rubroBienServicioCuentaServicio.ObtenerLista(listaRubroBienServicioCuentaVista.idPlanCuenta);
        }

        public void ObtenerDatosListado()
        {
            listaRubroBienServicioCuentaVista.listaDatosPrincipales = rubroBienServicioCuentaServicio.ObtenerLista(listaRubroBienServicioCuentaVista.idPlanCuenta);
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaRubroBienServicioCuentaVista.rubroBienCuentaServicio != null)
                respuesta = this.rubroBienServicioCuentaServicio.Anular(listaRubroBienServicioCuentaVista.rubroBienCuentaServicio.idRubBieSerCue).esCorrecto;

            return respuesta;
        }
    }
}
