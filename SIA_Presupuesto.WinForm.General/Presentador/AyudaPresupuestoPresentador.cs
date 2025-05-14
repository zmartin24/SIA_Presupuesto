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
    public class AyudaPresupuestoPresentador
    {
        private readonly IAyudaPresupuestoVista ayudaPresupuestoVista;

        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IPresupuestoServicio presupuestoServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;
        
        private tipoAyudaPresupuesto tipo;
        private int id;

        public AyudaPresupuestoPresentador(int id, tipoAyudaPresupuesto tipo, IAyudaPresupuestoVista ayudaPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IPresupuestoServicio)) as IPresupuestoServicio;
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            

            this.ayudaPresupuestoVista = ayudaPresupuestoVista;
            this.tipo = tipo;
            this.id = id;
            

        }

        public void CargarLista()
        {
            switch(this.tipo)
            {
                case tipoAyudaPresupuesto.grupoPresupuesto:
                    ayudaPresupuestoVista.tituloColumna = "Grupo Presupuestos";
                    ayudaPresupuestoVista.nombreColumna = "descripcion";
                    ayudaPresupuestoVista.tituloColumnaCodigo = "Código";
                    ayudaPresupuestoVista.nombreColumnaCodigo = "codigo";
                    ayudaPresupuestoVista.listaDatosPrincipales = grupoPresupuestoServicio.TraerListaGrupoPresupuesto();
                    break;
                case tipoAyudaPresupuesto.presupuesto:
                    ayudaPresupuestoVista.tituloColumna = "Presupuestos";
                    ayudaPresupuestoVista.nombreColumna = "descripcion";
                    ayudaPresupuestoVista.tituloColumnaCodigo = "Código";
                    ayudaPresupuestoVista.nombreColumnaCodigo = "codigo";
                    ayudaPresupuestoVista.listaDatosPrincipales = presupuestoServicio.TraerListaPresupuestoPorGrupoPresupuesto(id);
                    break;
                case tipoAyudaPresupuesto.subpresupuesto:
                    ayudaPresupuestoVista.tituloColumna = "Presupuestos Mensual / Obra";
                    ayudaPresupuestoVista.nombreColumna = "descripcion";
                    ayudaPresupuestoVista.tituloColumnaCodigo = "Código";
                    ayudaPresupuestoVista.nombreColumnaCodigo = "nroProyecto";
                    ayudaPresupuestoVista.listaDatosPrincipales = subpresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(id);
                    break;
            }
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaPresupuestoVista.DatoActual;
        }
    }
}
