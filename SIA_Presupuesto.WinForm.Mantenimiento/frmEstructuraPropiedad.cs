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
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class frmEstructuraPropiedad : ControlDetalleBase, IEstructuraPropiedadVista
    {
        private EstructuraParametroPresentador estructuraParametroPresentador;

        public frmEstructuraPropiedad(EstructuraPresupuestoRemuneracion estructura)
        {
            InitializeComponent();
            Text = "Propiedades de Estructura - " + estructura.descripcion;
            this.estructuraParametroPresentador = new EstructuraParametroPresentador(estructura, this);
        }

        public List<PropiedadPoco> listaDatosPrincipales
        {
            set
            {
                grcPropiedad.DataSource = value;
            }
        }

        public PropiedadPresupuestoRemuneracion propiedadPresupuestoRemuneracion
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PropiedadPoco;
                return pro != null ? estructuraParametroPresentador.Buscar(pro.idProPreRem) : null;
            }
        }

        protected override ColumnView ColumnaActual { get { return grcPropiedad.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcPropiedad; } }

        protected override void InicializarDatos()
        {
            
        }

        protected override void LlenarGrid()
        {
            estructuraParametroPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmPropiedad frm = new frmPropiedad(null, estructuraParametroPresentador.TraerEstructura(),  this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmPropiedad frm = new frmPropiedad(propiedadPresupuestoRemuneracion, estructuraParametroPresentador.TraerEstructura(), this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Anular()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (estructuraParametroPresentador.Anular())
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                    LlenarGrid();
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorAnulacion);
                }
            }
        }

        

        protected override void GuardarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
        }
    }
}
