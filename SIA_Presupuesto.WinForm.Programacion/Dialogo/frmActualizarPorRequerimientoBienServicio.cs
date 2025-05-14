using System.Collections.Generic;
using System.Windows.Forms;

using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.General.Ayuda;

using SIA_Presupuesto.WinForm.General.Helper;
using Utilitario.Util;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmActualizarPorRequerimientoBienServicio : frmDialogoBase, IActualizarPorRequerimientoBienServicioVista
    {
        private ActualizarPorRequerimientoBienServicioPresentador actualizarPorRequerimientoBienServicioPresentador;
       
        private ListaSeleccionRequerimientoAnual listaSeleccionRequerimientoAnual;

        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public int anio
        {
            set
            {
                lueAnio.EditValue = value;
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }
        public string idsReqBienSer
        {
            get; set;
        }

        public frmActualizarPorRequerimientoBienServicio(ProgramacionAnual programacionAnual, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.actualizarPorRequerimientoBienServicioPresentador = new ActualizarPorRequerimientoBienServicioPresentador(programacionAnual.idProAnu,this);
            this.Text = "Actualizar Programación Anual - "+programacionAnual.descripcion;
            mostrar_control_listaRequerimientoBienServivio();
        }

        protected override void InicializarDatos()
        {
            actualizarPorRequerimientoBienServicioPresentador.Inicializar();
        }
        protected override void GuardarDatos()
        {
            this.idsReqBienSer = listaSeleccionRequerimientoAnual.Tag as string;
            if (this.idsReqBienSer.Length > 0)
            {
                if (actualizarPorRequerimientoBienServicioPresentador.Guardar())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            }
            else
            {
                EmitirMensajeResultado(true, "Debes seleccionar al menos un requerimiento ");
                this.DialogResult = DialogResult.No;
            }
        }
        
        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && anio > 0)
                mostrar_control_listaRequerimientoBienServivio();
        }

        private void mostrar_control_listaRequerimientoBienServivio()
        {
            listaSeleccionRequerimientoAnual = new ListaSeleccionRequerimientoAnual(anio, UsuarioOperacion.IDUsuario);
            listaSeleccionRequerimientoAnual.Bounds = lciBaseReq.DisplayRectangle;
            listaSeleccionRequerimientoAnual.Visible = true;
            lciBaseReq.Controls.Add(listaSeleccionRequerimientoAnual);

            listaSeleccionRequerimientoAnual.Dock = DockStyle.Fill;
            listaSeleccionRequerimientoAnual.Visible = true;
            listaSeleccionRequerimientoAnual.BringToFront();

            
        }
    }
}