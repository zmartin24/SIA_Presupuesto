using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Presentador
{
    public class AyudaProductoPrecioPresentador
    {
        private readonly IAyudaProductoPrecioVista ayudaProductoPrecioVista;
        private IGeneralServicio generalServicio;

        public AyudaProductoPrecioPresentador(int idMoneda, IAyudaProductoPrecioVista ayudaProductoPrecioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.ayudaProductoPrecioVista = ayudaProductoPrecioVista;
            this.ayudaProductoPrecioVista.idMoneda = idMoneda;
            
        }

        public void llenarGrid()
        {
            ayudaProductoPrecioVista.listaDatosPrincipales = generalServicio.TraerProductoPrecio(this.ayudaProductoPrecioVista.desBusqueda, this.ayudaProductoPrecioVista.idMoneda);
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaProductoPrecioVista.DatoActual;
        }
    }
}
