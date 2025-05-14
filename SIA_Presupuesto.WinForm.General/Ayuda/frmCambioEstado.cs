using DevExpress.Utils.Menu;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Presentador;
using SIA_Presupuesto.WinForm.General.Recursos;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class frmCambioEstado : frmDialogoBase, IAyudaCambioEstadoVista
    {
        private AyudaCambioEstadoPresentador ayudaCambioEstadoPresentador;

        public List<Predeterminado> listaEstado
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueEstado.Properties, "codigo", "descripcion", "Estado", value);
            }
        }

        public int idEstado
        {
            set { lueEstado.EditValue = value; }
            get { return lueEstado.EditValue != null ? Convert.ToInt32(lueEstado.EditValue) : 0; }
        }
        public string opcion
        {
            set; get;
        }

        public frmCambioEstado(CertificacionRequerimiento certificacionRequerimiento, List<Predeterminado> listaEstado, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.opcion = opcion;
            this.listaEstado = listaEstado;
            this.ayudaCambioEstadoPresentador = new AyudaCambioEstadoPresentador(certificacionRequerimiento, this);
            
            if(listaEstado.Count>0)
                this.idEstado = Convert.ToInt32(listaEstado.OrderByDescending(x=>x.descripcion).FirstOrDefault().codigo);
            Text = "Actualizar Estado";
        }
        protected override void InicializarDatos()
        {
            this.ayudaCambioEstadoPresentador.InicializarDatos();
        }
        protected override void GuardarDatos()
        {
            if (this.ayudaCambioEstadoPresentador.ActualizarEstado())
            {
                EmitirMensajeResultado(true, "Se actualizó correctamente");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                EmitirMensajeResultado(false, "Error, al actualizar el estado");
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
