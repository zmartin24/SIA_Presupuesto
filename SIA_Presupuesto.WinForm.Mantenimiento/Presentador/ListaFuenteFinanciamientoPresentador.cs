using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class ListaFuenteFinanciamientoPresentador
    {
        private readonly IListaFuenteFinanciamientoVista listaFuenteFinanciamientoVista;
        private IFuenteFinanciamientoServicio fuenteFinanciamientoServicio;
        public ListaFuenteFinanciamientoPresentador(IListaFuenteFinanciamientoVista listaFuenteFinanciamientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.fuenteFinanciamientoServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;

            this.listaFuenteFinanciamientoVista = listaFuenteFinanciamientoVista;
        }
        public void ObtenerDatosListado()
        {
            listaFuenteFinanciamientoVista.listaDatosPrincipales = fuenteFinanciamientoServicio.TraerTodosActivos();
        }
        public FuenteFinanciamiento Buscar(int vidPlaa)
        {
            return fuenteFinanciamientoServicio.BuscarPorId(vidPlaa);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaFuenteFinanciamientoVista.fuenteFinanciamiento != null)
            {
                listaFuenteFinanciamientoVista.fuenteFinanciamiento.usuMod = listaFuenteFinanciamientoVista.UsuarioOperacion.NomUsuario;
                respuesta = this.fuenteFinanciamientoServicio.Anular(listaFuenteFinanciamientoVista.fuenteFinanciamiento).esCorrecto;
            }
            return respuesta;
        }
        
    }
}
