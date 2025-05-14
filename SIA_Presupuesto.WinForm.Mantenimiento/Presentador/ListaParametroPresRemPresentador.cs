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
    public class ListaParametroPresRemPresentador
    {
        private readonly IListaParametroPresRemVista listaParametroPresRemVista;
        private IParametroPresupuestoRemuneracionServicio parametroPresupuestoRemuneracionServicio;
        public ListaParametroPresRemPresentador(IListaParametroPresRemVista listaParametroPresRemVista)
        {
            this.listaParametroPresRemVista = listaParametroPresRemVista;
            IContenedor _Contenedor = new cContenedor();
            this.parametroPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IParametroPresupuestoRemuneracionServicio)) as IParametroPresupuestoRemuneracionServicio;
        }

        public void ObtenerDatosListado()
        {
            listaParametroPresRemVista.listaDatosPrincipales = parametroPresupuestoRemuneracionServicio.TraerParametrosPresentacion();
        }
        public ParametroPresupuestoRemuneracion Buscar(int vid)
        {
            return parametroPresupuestoRemuneracionServicio.BuscarPorCodigo(vid);
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (listaParametroPresRemVista.parametroPresupuestoRemuneracion != null)
            {
                listaParametroPresRemVista.parametroPresupuestoRemuneracion.usuEdita = listaParametroPresRemVista.UsuarioOperacion.NomUsuario;
                respuesta = this.parametroPresupuestoRemuneracionServicio.Anular(listaParametroPresRemVista.parametroPresupuestoRemuneracion).esCorrecto;
            }
            return respuesta;
        }
    }
}
