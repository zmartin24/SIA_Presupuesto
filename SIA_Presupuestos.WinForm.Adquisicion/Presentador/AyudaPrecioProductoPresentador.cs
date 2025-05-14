using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Adquisicion.Ayuda;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Ayuda;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class AyudaPrecioProductoPresentador
    {
        private readonly IAyudaPrecioProductoVista ayudaPrecioProductoVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        
        private ForeDetallePoco foreDetallePoco;
        private tipoAyudaFore tipo;
        public AyudaPrecioProductoPresentador(ForeDetallePoco foreDetallePoco, tipoAyudaFore tipo, IAyudaPrecioProductoVista ayudaPrecioProductoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            
            this.ayudaPrecioProductoVista = ayudaPrecioProductoVista;
            this.foreDetallePoco = foreDetallePoco;
            this.tipo = tipo;
        }
        public void Iniciar()
        {
            this.ayudaPrecioProductoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2005);
            this.ayudaPrecioProductoVista.anioPresentacion = DateTime.Now.Date.Year;
        }

        public void CargarLista()
        {
            ayudaPrecioProductoVista.listaDatosPrincipales = certificacionRequerimientoServicio.TraerListaPrecioBienServicio(this.ayudaPrecioProductoVista.anioPresentacion,foreDetallePoco.idDetalle, Convert.ToInt32(tipo));
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaPrecioProductoVista.DatoActual;
        }
    }
}
