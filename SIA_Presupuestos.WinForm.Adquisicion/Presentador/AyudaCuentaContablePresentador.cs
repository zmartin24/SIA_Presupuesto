using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class AyudaCuentaContablePresentador
    {
        private readonly IAyudaCuentaContableVista ayudaCuentaContableVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IGeneralServicio generalServicio;

        public AyudaCuentaContablePresentador(IAyudaCuentaContableVista ayudaCuentaContableVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.ayudaCuentaContableVista = ayudaCuentaContableVista;
        }
        public void IniciarDatos()
        {
            var listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual
            ayudaCuentaContableVista.listaCuentaContable = listaCuentaContable;
        }
        
        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaCuentaContableVista.DatoActual;
        }
    }
}
