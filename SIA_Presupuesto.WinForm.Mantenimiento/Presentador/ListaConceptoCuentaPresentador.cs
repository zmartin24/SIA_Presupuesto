using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class ListaConceptoCuentaPresentador
    {
        private readonly IListaConceptoCuentaVista listaConceptoCuentaVista;
        private IConceptoCuentaContableServicio conceptoCuentaServicio;
        private ConceptoPresupuestoRemuneracion concepto;

        public ListaConceptoCuentaPresentador(ConceptoPresupuestoRemuneracion concepto, IListaConceptoCuentaVista listaConceptoCuentaVista)
        {
            this.concepto = concepto;
            this.listaConceptoCuentaVista = listaConceptoCuentaVista;
            IContenedor _Contenedor = new cContenedor();
            this.conceptoCuentaServicio = _Contenedor.Resolver(typeof(IConceptoCuentaContableServicio)) as IConceptoCuentaContableServicio;
        }

        public void ObtenerDatosListado()
        {
            listaConceptoCuentaVista.listaDatosPrincipales = conceptoCuentaServicio.TraerDatosConceptoCuentaContable(this.concepto.idConPreRem);
        }

        public ConceptoCuentaContable Buscar(int vid)
        {
            return conceptoCuentaServicio.BuscarPorCodigo(vid);
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaConceptoCuentaVista.conceptoCuentaContable != null)
            {
                listaConceptoCuentaVista.conceptoCuentaContable.usuEdita = listaConceptoCuentaVista.UsuarioOperacion.NomUsuario;
                respuesta = this.conceptoCuentaServicio.Anular(listaConceptoCuentaVista.conceptoCuentaContable).esCorrecto;
            }
            return respuesta;
        }

    }
}
