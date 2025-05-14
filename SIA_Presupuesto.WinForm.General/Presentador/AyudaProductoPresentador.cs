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
    public class AyudaProductoPresentador
    {
        private readonly IAyudaProductoVista ayudaPersonaVista;
        private IGeneralServicio generalServicio;
        private string numCuenta;
        public AyudaProductoPresentador(string numCuenta, IAyudaProductoVista ayudaPersonaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.numCuenta = numCuenta;
            this.ayudaPersonaVista = ayudaPersonaVista;
            
        }

        public void ObtenerDatosCuentas()
        {
            if (string.IsNullOrEmpty(numCuenta))
                ayudaPersonaVista.listaDatosPrincipales = generalServicio.ListaProducto();
            else
                ayudaPersonaVista.listaDatosPrincipales = generalServicio.ListaProducto(numCuenta);
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaPersonaVista.DatoActual;
        }
    }
}
