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
    public class ListaTipoCambioAnualPresentador
    {
        private readonly IListaTipoCambioAnualVista listaTipoCambioAnualVista;
        private ITipoCambioAnualServicio tipoCambioAnualServicio;
        public ListaTipoCambioAnualPresentador(IListaTipoCambioAnualVista listaTipoCambioAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.tipoCambioAnualServicio = _Contenedor.Resolver(typeof(ITipoCambioAnualServicio)) as ITipoCambioAnualServicio;

            this.listaTipoCambioAnualVista = listaTipoCambioAnualVista;
        }
        public void Iniciar()
        {
        }
        public void ObtenerDatosListado()
        {
            listaTipoCambioAnualVista.listaDatosPrincipales = tipoCambioAnualServicio.listarTodos().OrderByDescending(x => Tuple.Create(x.anio)).ToList();
        }
        public TipoCambioAnual Buscar(int vid)
        {
            return tipoCambioAnualServicio.BuscarPorCodigo(vid);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaTipoCambioAnualVista.tipoCambioAnual != null)
            {
                listaTipoCambioAnualVista.tipoCambioAnual.usuEdita = listaTipoCambioAnualVista.UsuarioOperacion.NomUsuario;
                respuesta = this.tipoCambioAnualServicio.Eliminar(listaTipoCambioAnualVista.tipoCambioAnual).esCorrecto;
            }
            return respuesta;
        }
        
    }
}
