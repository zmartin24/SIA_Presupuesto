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
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class ListaPartidaPresupuestalPresentador
    {
        private readonly IListaPartidaPresupuestalVista listaPartidaPresupuestalVista;
        private IPartidaPresupuestalServicio partidaPresupuestalServicio;
        public ListaPartidaPresupuestalPresentador(IListaPartidaPresupuestalVista listaPartidaPresupuestalVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.partidaPresupuestalServicio = _Contenedor.Resolver(typeof(IPartidaPresupuestalServicio)) as IPartidaPresupuestalServicio;

            this.listaPartidaPresupuestalVista = listaPartidaPresupuestalVista;
        }
        public void Iniciar()
        {
        }
        public void ObtenerDatosListado()
        {
            listaPartidaPresupuestalVista.listaDatosPrincipales = this.partidaPresupuestalServicio.TraerListaPartidaPresupuestal().ToList();
        }
        public PartidaPresupuestal BuscarPorID(int vid)
        {
            return this.partidaPresupuestalServicio.BuscarPorCodigo(vid);
        }
        //public bool Anular()
        //{
        //    bool respuesta = false;
            
        //    respuesta = this.partidaPresupuestalServicio.AnularPartidaPresupuestalCuenta(this.listaPartidaPresupuestalVista.).esCorrecto;
            
        //    return respuesta;
        //}
    }
}
