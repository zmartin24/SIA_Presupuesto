using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Presentador
{
    public class AyudaMonedaPresentador
    {
        private readonly IAyudaMonedaVista ayudaMonedaVista;

        private IGeneralServicio generalServicio;
        
        private int id;
        private int idSubPresupuesto = 0;

        public AyudaMonedaPresentador(IAyudaMonedaVista ayudaMonedaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.ayudaMonedaVista = ayudaMonedaVista;
        }

        public void InicializarDatos()
        {
            var lista = generalServicio.ListaMonedas();
            
            if (lista.Count > 0)
            {
                this.ayudaMonedaVista.listaMoneda = generalServicio.ListaMonedas();
            }
            this.ayudaMonedaVista.idMoneda = 63;

        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaMonedaVista.idMoneda;
        }
    }
}
