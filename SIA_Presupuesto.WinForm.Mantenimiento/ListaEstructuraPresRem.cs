using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaEstructuraPresRem : ControlBase, IListaEstructuraPresRemVista
    {
        public ListaEstructuraPresRem()
        {
            InitializeComponent();
            this.listaEstructuraPresRemPresentador = new ListaEstructuraPresRemPresentador(this);
        }

        private ListaEstructuraPresRemPresentador listaEstructuraPresRemPresentador;

        public List<EstructuraPresupuestoRemuneracion> listaDatosPrincipales
        {
            set
            {
                grcEstructura.DataSource = value;
            }
        }
        public EstructuraPresupuestoRemuneracion estructuraPresupuestoRemuneracion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as EstructuraPresupuestoRemuneracion;
                return pro != null ? listaEstructuraPresRemPresentador.Buscar(pro.idEstPreRem) : null;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcEstructura.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcEstructura; } }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();

        }

        protected override void LlenarGrid()
        {
            listaEstructuraPresRemPresentador.ObtenerDatosListado();
        }
        protected override void Nuevo()
        {
            using (frmEstructura frm = new frmEstructura(null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        protected override void Modificar()
        {
            using (frmEstructura frm = new frmEstructura(estructuraPresupuestoRemuneracion, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }
        public override bool Anular()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (listaEstructuraPresRemPresentador.Anular())
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
                }
            }
            return true;
        }

        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch(nomOperacion)
            {
                case "Propiedades":
                    Propiedades();
                    break;
            }
        }

        private void Propiedades()
        {
            if (estructuraPresupuestoRemuneracion!=null)
            {
                frmEstructuraPropiedad frm = new frmEstructuraPropiedad(estructuraPresupuestoRemuneracion);
                MostrarDialogoModulo(frm);
            }
            else EmitirMensajeResultado(true, "Debe seleccionar una estructura");
        }
    }
}
