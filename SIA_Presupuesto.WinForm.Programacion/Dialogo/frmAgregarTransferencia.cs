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
    public partial class frmAgregarTransferencia : frmDialogoBase, ITransferenciaVista
    {
        private TransferenciaPresentador transferenciaRecepcionadoPresentador;
        PresupuestoRecepcionadoPoco oPresupuestoPoco;
        private decimal _importe;
        private decimal _importetransferido;

        public frmAgregarTransferencia(PresupuestoRecepcionadoPoco SubPresupuesto, 
            Form padre, 
            List<GrupoPresupuestoTransferidoPoco> Lista,
            decimal importe,
            decimal importetransferido
            ) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = SubPresupuesto != null;
            oPresupuestoPoco = SubPresupuesto;
            this._importe = importe;
            this._importetransferido = importetransferido;
            transferenciaRecepcionadoPresentador = new TransferenciaPresentador(SubPresupuesto, this,Lista);
            Text = (SubPresupuesto == null) ? "Agregar Item" : "Editar Item";
        }
        protected override void InicializarDatos()
        {
            transferenciaRecepcionadoPresentador.IniciarDatosRegistro();
        }

        public int idGrupoPresupuesto
        {
            set { cboGrupoPresupuesto.EditValue = value; }
            get { return (Int32)cboGrupoPresupuesto.EditValue; }
        }

        public List<GrupoPresupuestoPoco> listaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboGrupoPresupuesto.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }

        public List<ItemPoco> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboMes.Properties, "id", "nombre", "Mes", value);
            }
        }

        public int mes
        {
            set { cboMes.EditValue = value; }
            get { return (Int32)cboMes.EditValue; }
        }

        public List<ItemPoco> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboAnio.Properties, "id", "nombre", "Año", value);
            }
        }

        public decimal importe
        {
            set { txtImporte.EditValue = value; }
            get { return (decimal)txtImporte.EditValue; }
        }

        public string nombreGrupo
        {
            get
            {
                return cboGrupoPresupuesto.Properties.GetDisplayText(cboGrupoPresupuesto.EditValue);
            }
        }

        public string nombreMes
        {
            get
            {
                return cboMes.Properties.GetDisplayText(cboMes.EditValue);
            }
        }

        public int anio
        {
            get
            {
                return Convert.ToInt32(cboAnio.Properties.GetDisplayText(cboAnio.EditValue));
            }
        }

        protected override void GuardarDatos()
        {
            if((this._importe <(this._importetransferido + this.importe)))
            {
                EmitirMensajeResultado(false,"El importe total ha superado el importe límite a transferir.");
            }
            else
            {
                //if(this.anio > 0)
                //{
                    if (transferenciaRecepcionadoPresentador.GuardarDatos())
                    {
                        if (this.esModificacion)
                            EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                        else
                            EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                //}
                //else
                //{
                //    EmitirMensajeResultado(false, "El Año debe ser mayor a cero.");
                //}
                
            }
           
        }
    }
}
