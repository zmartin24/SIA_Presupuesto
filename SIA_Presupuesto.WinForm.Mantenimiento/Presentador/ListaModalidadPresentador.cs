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
    public class ListaModalidadPresentador
    {
        private readonly IListaModalidadVista listaModalidadVista;
        private IModalidadServicio modalidadServicio;
        public ListaModalidadPresentador(IListaModalidadVista listaModalidadVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.modalidadServicio = _Contenedor.Resolver(typeof(IModalidadServicio)) as IModalidadServicio;

            this.listaModalidadVista = listaModalidadVista;
        }
        public void ObtenerDatosListado()
        {
            listaModalidadVista.listaDatosPrincipales = modalidadServicio.TraerTodosActivos();
        }
        public Modalidad Buscar(int vid)
        {
            return modalidadServicio.BuscarPorCodigo(vid);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaModalidadVista.modalidad != null)
            {
                listaModalidadVista.modalidad.usuEdita = listaModalidadVista.UsuarioOperacion.NomUsuario;
                respuesta = this.modalidadServicio.Eliminar(listaModalidadVista.modalidad).esCorrecto;
            }
            return respuesta;
        }
        
    }
}
