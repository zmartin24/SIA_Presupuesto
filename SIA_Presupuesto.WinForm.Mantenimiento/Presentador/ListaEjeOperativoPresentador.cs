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
    public class ListaEjeOperativoPresentador
    {
        private readonly IListaEjeOperativoVista listaEjeOperativoVista;
        private IEjeOperativoServicio ejeOperativoServicio;
        public ListaEjeOperativoPresentador(IListaEjeOperativoVista listaEjeOperativoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.ejeOperativoServicio = _Contenedor.Resolver(typeof(IEjeOperativoServicio)) as IEjeOperativoServicio;

            this.listaEjeOperativoVista = listaEjeOperativoVista;
        }
        public void ObtenerDatosListado()
        {
            listaEjeOperativoVista.listaDatosPrincipales = ejeOperativoServicio.TraerTodosActivos();
        }
        public EjeOperativo Buscar(int vid)
        {
            return ejeOperativoServicio.BuscarPorCodigo(vid);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaEjeOperativoVista.ejeOperativo != null)
            {
                listaEjeOperativoVista.ejeOperativo.usuEdita = listaEjeOperativoVista.UsuarioOperacion.NomUsuario;
                respuesta = this.ejeOperativoServicio.Eliminar(listaEjeOperativoVista.ejeOperativo).esCorrecto;
            }
            return respuesta;
        }
        
    }
}
