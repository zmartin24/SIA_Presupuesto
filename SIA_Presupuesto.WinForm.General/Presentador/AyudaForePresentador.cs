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
    public class AyudaForePresentador
    {
        private readonly IAyudaForeVista ayudaForeVista;

        private ICertificacionMasterServicio certificacionMasterServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IPresupuestoServicio presupuestoServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;
        
        private tipoAyudaFore tipo;
        private int id;
        private int idSubPresupuesto = 0;

        public AyudaForePresentador(tipoAyudaFore tipo, IAyudaForeVista ayudaForeVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IPresupuestoServicio)) as IPresupuestoServicio;
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;

            this.ayudaForeVista = ayudaForeVista;
            this.tipo = tipo;
        }

        public AyudaForePresentador(tipoAyudaFore tipo, IAyudaForeVista ayudaForeVista, int idSubPresupuesto)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IPresupuestoServicio)) as IPresupuestoServicio;
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.idSubPresupuesto = idSubPresupuesto;

            this.ayudaForeVista = ayudaForeVista;
            this.tipo = tipo;
        }
        

        public void CargarLista()
        {
            switch(this.tipo)
            {
                case tipoAyudaFore.bien:
                    ayudaForeVista.tituloColumnaCodigo = "Código";
                    ayudaForeVista.nombreColumnaCodigo = "idForebi";
                    ayudaForeVista.listaDatosPrincipales = idSubPresupuesto == 0 ? certificacionMasterServicio.TraerListaForebiTodos() : certificacionRequerimientoServicio.TraerListaForebiPorSubPresupuesto(this.idSubPresupuesto);
                    break;
                case tipoAyudaFore.servicio:
                    ayudaForeVista.tituloColumnaCodigo = "Código";
                    ayudaForeVista.nombreColumnaCodigo = "idForese";
                    ayudaForeVista.listaDatosPrincipales = idSubPresupuesto == 0 ? certificacionMasterServicio.TraerListaForeseTodos() : certificacionRequerimientoServicio.TraerListaForesePorSubPresupuesto(this.idSubPresupuesto);
                    break;
            }
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaForeVista.DatoActual;
        }
    }
}
