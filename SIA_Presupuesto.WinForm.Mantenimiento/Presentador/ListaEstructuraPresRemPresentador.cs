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
    public class ListaEstructuraPresRemPresentador
    {
        private readonly IListaEstructuraPresRemVista listaEstructuraPresRemVista;
        private IEstructuraPresupuestoRemuneracionServicio estructuraPresupuestoRemuneracionServicio;
        public ListaEstructuraPresRemPresentador(IListaEstructuraPresRemVista listaEstructuraPresRemVista)
        {
            this.listaEstructuraPresRemVista = listaEstructuraPresRemVista;
            IContenedor _Contenedor = new cContenedor();
            this.estructuraPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
        }

        public void ObtenerDatosListado()
        {
            listaEstructuraPresRemVista.listaDatosPrincipales = estructuraPresupuestoRemuneracionServicio.TraerTodosActivos();
        }
        public EstructuraPresupuestoRemuneracion Buscar(int vid)
        {
            return estructuraPresupuestoRemuneracionServicio.BuscarPorCodigo(vid);
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaEstructuraPresRemVista.estructuraPresupuestoRemuneracion != null)
            {
                listaEstructuraPresRemVista.estructuraPresupuestoRemuneracion.usuEdita = listaEstructuraPresRemVista.UsuarioOperacion.NomUsuario;
                respuesta = this.estructuraPresupuestoRemuneracionServicio.Anular(listaEstructuraPresRemVista.estructuraPresupuestoRemuneracion).esCorrecto;
            }
            return respuesta;
        }
    }
}
