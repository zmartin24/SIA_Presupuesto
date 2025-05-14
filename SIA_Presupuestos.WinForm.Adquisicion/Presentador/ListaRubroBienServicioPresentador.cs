using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaRubroBienServicioPresentador
    {
        private readonly IListaRubroBienServicioVista listaRubroBienServicioVista;
        private IRubroBienServicio gastoRecurrenteServicio;
        
        public ListaRubroBienServicioPresentador(IListaRubroBienServicioVista listaGastoRecurrenteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IRubroBienServicio)) as IRubroBienServicio;

            this.listaRubroBienServicioVista = listaGastoRecurrenteVista;
        }

        public void InicializarDatos()
        {

        }

        public void ObtenerDatosListado()
        {
            listaRubroBienServicioVista.listaDatosPrincipales = gastoRecurrenteServicio.ObtenerLista();
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaRubroBienServicioVista.rubroBienServicio != null)
                respuesta = this.gastoRecurrenteServicio.Anular(listaRubroBienServicioVista.rubroBienServicio.idRubBieSer).esCorrecto;
            return respuesta;
        }
    }
}
