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
    public class ListaTipoCambioPresupuestoPresentador
    {
        private readonly IListaTipoCambioPresupuestoVista listaTipoCambioPresupuestoVista;
        private ITipoCambioPresupuestoServicio tipoCambioPresupuestoServicio;
        public ListaTipoCambioPresupuestoPresentador(IListaTipoCambioPresupuestoVista listaTipoCambioPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.tipoCambioPresupuestoServicio = _Contenedor.Resolver(typeof(ITipoCambioPresupuestoServicio)) as ITipoCambioPresupuestoServicio;

            this.listaTipoCambioPresupuestoVista = listaTipoCambioPresupuestoVista;
        }
        public void Iniciar()
        {
            listaTipoCambioPresupuestoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2005);
            listaTipoCambioPresupuestoVista.anioPresentacion = DateTime.Now.Date.Year;
        }
        public void ObtenerDatosListado()
        {
            listaTipoCambioPresupuestoVista.listaDatosPrincipales = tipoCambioPresupuestoServicio.listarTodos(listaTipoCambioPresupuestoVista.anioPresentacion).OrderByDescending(x => Tuple.Create(x.anio, x.mes)).ToList();
        }
        public TipoCambioPresupuesto Buscar(int vid)
        {
            return tipoCambioPresupuestoServicio.BuscarPorCodigo(vid);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaTipoCambioPresupuestoVista.tipoCambioPresupuesto != null)
            {
                listaTipoCambioPresupuestoVista.tipoCambioPresupuesto.usuEdita = listaTipoCambioPresupuestoVista.UsuarioOperacion.NomUsuario;
                respuesta = this.tipoCambioPresupuestoServicio.Eliminar(listaTipoCambioPresupuestoVista.tipoCambioPresupuesto).esCorrecto;
            }
            return respuesta;
        }
        
    }
}
