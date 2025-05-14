using DevExpress.XtraEditors;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Vista;
using SIA_Presupuesto.WinForm.General.Vistas;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Presentador
{
    public class ListaSeleccionRequerimientoAnualPresentador
    {
        private readonly IListaSeleccionRequerimientoAnualVista listaSeleccionRequerimientoAnualVista;

        private IRequerimientoBienServicioServicio requerimientoBienServicioServicio;
        
        private int vAnio;
        private int vIdUsuario;

        public ListaSeleccionRequerimientoAnualPresentador(int vAnio, int vIdUsuario, IListaSeleccionRequerimientoAnualVista listaSeleccionRequerimientoAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            
            this.requerimientoBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;
            
            this.listaSeleccionRequerimientoAnualVista = listaSeleccionRequerimientoAnualVista;

            this.vAnio = vAnio;
            this.vIdUsuario = vIdUsuario;
        }
        public void LlenarGrid()
        {
            this.listaSeleccionRequerimientoAnualVista.listaDatosPrincipales = requerimientoBienServicioServicio.TraerListaRequerimientoBienServicio(vAnio, vIdUsuario);
        }
        public RequerimientoBienServicio Buscar(int id)
        {
            return this.requerimientoBienServicioServicio.BuscarPorCodigo(id);
        }
        public void AsignarIdsBienServicio(XtraUserControl frm)
        {
            frm.Tag = this.listaSeleccionRequerimientoAnualVista.idsReqBienSer;
        }
    }
}
