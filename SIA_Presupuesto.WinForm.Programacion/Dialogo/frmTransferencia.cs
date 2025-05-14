using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmTransferencia :frmDialogoBase, IListaTransferenciaVista
    {
        private TransferenciaPresentador transferenciaRecepcionadoPresentador;
        PresupuestoRecepcionadoPoco oPresupuestoPoco;
        public frmTransferencia(PresupuestoRecepcionadoPoco SubPresupuesto, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = SubPresupuesto != null;
            oPresupuestoPoco = SubPresupuesto;
            transferenciaRecepcionadoPresentador = new TransferenciaPresentador(SubPresupuesto, this);
            Text = (SubPresupuesto == null) ? "Nuevo Presupuesto Recepcionado" : "Editar Presupuesto Recepcionado";
        }

        protected override void InicializarDatos()
        {
            transferenciaRecepcionadoPresentador.IniciarDatos();
        }

        public List<GrupoPresupuestoPoco> listaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboGrupoPresupuesto.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }

        public List<ItemPoco> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboAnio.Properties, "id", "nombre", "Año", value);
            }
        }

        public List<ItemPoco> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboMes.Properties, "id", "nombre", "Mes", value);
            }
        }

        public decimal importe
        {
            set { txtImporte.EditValue = value; }
            get { return (decimal)txtImporte.EditValue; }
        }

        public decimal importetransferido
        {
            set { txtTransferido.EditValue = value; }
            get { return (decimal)txtTransferido.EditValue; }
        }

        public decimal importerestante
        {
            set { txtRestante.EditValue = value; }
            get { return (decimal)txtRestante.EditValue; }
        }

        public List<GrupoPresupuestoTransferidoPoco> listaGrupoPresupuestoTransferido
        {
            set
            {
                grcTransferencia.DataSource = value;
            }
        }

        public int idGrupoPresupuesto
        {
            set { cboGrupoPresupuesto.EditValue = value; }
            get { return (Int32)cboGrupoPresupuesto.EditValue; }
        }

        public int idPreRec
        {
            get;set;
        }

        public int anio
        {
            get { return (Int32)cboAnio.EditValue; }
        }

        public int mes
        {
          
            get { return (Int32)cboMes.EditValue; }
        }

        private void opcionesBarraGrid1_NuevoDetalleRegistro(object sender, EventArgs e)
        {
         
        }

        private void opcionesBarraGrid1_QuitarRegistro(object sender, EventArgs e)
        {

        }

        private void opcionesBarraGrid1_ModificarRegistro(object sender, EventArgs e)
        {

        }
        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(cboAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboMes, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        public bool ValidarImporteTransferir()
        {
            if(importerestante <= 0)
            {
                return false;
            }

            return true;
        }

        private void opcionesBarraGrid1_AgregarRegistro(object sender, EventArgs e)
        {
            if (ValidarImporteTransferir())
            {
                using (frmAgregarTransferencia frm = new frmAgregarTransferencia(new PresupuestoRecepcionadoPoco(), 
                    this.FindForm(), 
                    this.transferenciaRecepcionadoPresentador.ListaPresupuestoRecepcionado,
                    this.importe,
                    this.importetransferido
                    ))
                {
                    
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //LlenarGrid();
                        transferenciaRecepcionadoPresentador.CargarDatosGruposPresupuestoRecepcionado();
                    }
                }
            }
            else
            {
                EmitirMensajeResultado(false, "No hay saldo para transferir");
            }
           
        }

        private void cboAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (transferenciaRecepcionadoPresentador.TieneListaGrupo())
            {
                if (EmitirMensajePregunta("Las transferencias a los grupos presupuestales se borrarán. Desea continuar?"))
                {
                    if (cboMes.EditValue != null)
                    {
                        transferenciaRecepcionadoPresentador.AsignarImporteRecepcionado(idGrupoPresupuesto, anio, mes);
                        transferenciaRecepcionadoPresentador.LimpiarGrilla();
                    }
                }
            }
            else
            {
                if (cboMes.EditValue != null)
                {
                    transferenciaRecepcionadoPresentador.AsignarImporteRecepcionado(idGrupoPresupuesto, anio, mes);
                }
            }
        }

        private void cboMes_EditValueChanged(object sender, EventArgs e)
        {
            if (transferenciaRecepcionadoPresentador.TieneListaGrupo())
            {
                if (EmitirMensajePregunta("Las transferencias a los grupos presupuestales se borrarán. Desea continuar?"))
                {
                    transferenciaRecepcionadoPresentador.AsignarImporteRecepcionado(idGrupoPresupuesto, anio, mes);
                    transferenciaRecepcionadoPresentador.LimpiarGrilla();
                }
               
            }
            else
            {
                if (cboMes.EditValue != null)
                {
                    transferenciaRecepcionadoPresentador.AsignarImporteRecepcionado(idGrupoPresupuesto, anio, mes);
                }
            }
        }

        protected override void GuardarDatos()
        {
            if (transferenciaRecepcionadoPresentador.GuardarDatosTransferencia())
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
    }
}
