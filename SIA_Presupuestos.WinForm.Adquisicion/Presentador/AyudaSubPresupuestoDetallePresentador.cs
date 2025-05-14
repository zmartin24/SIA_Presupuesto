using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class AyudaSubPresupuestoDetallePresentador
    {
        private readonly IAyudaSubPresupuestoDetalleVista ayudaSubPresupuestoDetalleVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private ISubpresupuestoServicio subpresupuestoServicio;

        private int idSubPresupuesto;
        List<SubPresupuestoDetallePres> listaSubPresupuestoDetalle;
        SubPresupuestoPoco subPresupuestoPoco;

        public AyudaSubPresupuestoDetallePresentador(int idSubPresupuesto, List<SubPresupuestoDetallePres> listaSubPresupuestoDetalle, IAyudaSubPresupuestoDetalleVista ayudaSubPresupuestoDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;

            this.ayudaSubPresupuestoDetalleVista = ayudaSubPresupuestoDetalleVista;
            this.idSubPresupuesto = idSubPresupuesto;
            this.listaSubPresupuestoDetalle = listaSubPresupuestoDetalle;
        }

        public void CargarLista()
        {
            subPresupuestoPoco = this.subpresupuestoServicio.BuscarSubPresupuestoPoco(this.idSubPresupuesto);
            if (subPresupuestoPoco != null)
            {
                ayudaSubPresupuestoDetalleVista.desGrupoPresupuesto = subPresupuestoPoco.desGrupoPresupuesto;
                ayudaSubPresupuestoDetalleVista.desPresupuesto = subPresupuestoPoco.desPresupuesto;
                ayudaSubPresupuestoDetalleVista.desSubPresupuesto = subPresupuestoPoco.desSubPresupuesto;
                ayudaSubPresupuestoDetalleVista.desDireccion = subPresupuestoPoco.desDireccion;
                ayudaSubPresupuestoDetalleVista.tipCambio = subPresupuestoPoco.tipoCambio;

            }
            ayudaSubPresupuestoDetalleVista.listaDatosPrincipales = this.listaSubPresupuestoDetalle;
        }

        public void AsignarDatosActual(Form frm)
        {
            frm.Tag = ayudaSubPresupuestoDetalleVista.DatoActual;
        }
        public void PintarLista(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                decimal vdiferencia = Convert.ToDecimal(View.GetRowCellDisplayText(e.RowHandle, View.Columns["saldoSoles"]));
                if (vdiferencia <= 0)
                    e.Appearance.ForeColor = Color.Red;
            }
        }
        
    }
}
