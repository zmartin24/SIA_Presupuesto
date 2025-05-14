using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Presentador
{
    public class AyudaPartidaPresupuestalPrecioPresentador
    {
        private readonly IAyudaPartidaPresupuestalPrecioVista ayudaPartidaPresupuestalPrecioVista;
        private IPartidaPresupuestalServicio partidaPresupuestalServicio;
        private RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres;

        public AyudaPartidaPresupuestalPrecioPresentador(RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres, IAyudaPartidaPresupuestalPrecioVista ayudaPartidaPresupuestalPrecioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.partidaPresupuestalServicio = _Contenedor.Resolver(typeof(IPartidaPresupuestalServicio)) as IPartidaPresupuestalServicio;
            this.ayudaPartidaPresupuestalPrecioVista = ayudaPartidaPresupuestalPrecioVista;
            this.requerimientoMensualBienServicioPres = requerimientoMensualBienServicioPres;
        }

        public void llenarGrid()
        {
            this.ayudaPartidaPresupuestalPrecioVista.listaDatosPrincipales = this.partidaPresupuestalServicio.TraerPartidaPresupuestalPrecio((Int32)this.requerimientoMensualBienServicioPres.tipo, this.ayudaPartidaPresupuestalPrecioVista.desBusqueda, (Int32)this.requerimientoMensualBienServicioPres.idMoneda);
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaPartidaPresupuestalPrecioVista.DatoActual;
        }
    }
}
