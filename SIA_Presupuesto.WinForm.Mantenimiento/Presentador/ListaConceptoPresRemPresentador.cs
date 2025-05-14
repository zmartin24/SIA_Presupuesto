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
    public class ListaConceptoPresRemPresentador
    {
        private readonly IListaConceptoPresRemVista listaConceptoPresRemVista;
        private IConceptoPresupuestoRemuneracionServicio conceptoPresupuestoRemuneracionServicio;
        public ListaConceptoPresRemPresentador(IListaConceptoPresRemVista listaConceptoPresRemVista)
        {
            this.listaConceptoPresRemVista = listaConceptoPresRemVista;
            IContenedor _Contenedor = new cContenedor();
            this.conceptoPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IConceptoPresupuestoRemuneracionServicio)) as IConceptoPresupuestoRemuneracionServicio;
        }
     

        public void ObtenerDatosListado()
        {
            listaConceptoPresRemVista.listaDatosPrincipales = conceptoPresupuestoRemuneracionServicio.TraerTodosActivos();
        }
        public ConceptoPresupuestoRemuneracion Buscar(int vid)
        {
            return conceptoPresupuestoRemuneracionServicio.BuscarPorCodigo(vid);
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaConceptoPresRemVista.conceptoPresupuestoRemuneracion != null)
            {
                listaConceptoPresRemVista.conceptoPresupuestoRemuneracion.usuEdita = listaConceptoPresRemVista.UsuarioOperacion.NomUsuario;
                respuesta = this.conceptoPresupuestoRemuneracionServicio.Anular(listaConceptoPresRemVista.conceptoPresupuestoRemuneracion).esCorrecto;
            }
            return respuesta;
        }
    }
}
