using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaGrupoPresupuestoPresentador
    {
        private readonly IListaGrupoPresupuestoVista listaGrupoPresupuestoVista;
        private IGrupoPresupuestoServicio grupopresupuestoServicio;
        
        public ListaGrupoPresupuestoPresentador(IListaGrupoPresupuestoVista IListaGrupoPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.grupopresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.listaGrupoPresupuestoVista = IListaGrupoPresupuestoVista;
        }

        public void Iniciar()
        {

        }

        public void ObtenerDatosListado()
        {
            listaGrupoPresupuestoVista.listaDatosPrincipales = grupopresupuestoServicio.ListaGrupo();
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaGrupoPresupuestoVista.grupoPresupuesto != null)
                respuesta = this.grupopresupuestoServicio.Anular(listaGrupoPresupuestoVista.grupoPresupuesto).esCorrecto;
            return respuesta;
        }
    }
}
