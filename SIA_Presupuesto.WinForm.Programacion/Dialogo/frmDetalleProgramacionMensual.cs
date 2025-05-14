using System;
using System.Collections.Generic;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmDetalleProgramacionMensual : frmDialogoBase, IDetalleProgramacionMensualVista
    {
        private DetalleProgramacionMensualPresentador detalleProgramacionMensualPresentador;

        public frmDetalleProgramacionMensual(SubPresupuestoPoco subPresupuestoPoco, int mes)
        {
            InitializeComponent();

            string textomes = "";
            switch (mes)
            {
                case 1: textomes = "Enero"; break;
                case 2: textomes = "Febrero"; break;
                case 3: textomes = "Marzo"; break;
                case 4: textomes = "Abril"; break;
                case 5: textomes = "Mayo"; break;
                case 6: textomes = "Junio"; break;
                case 7: textomes = "Julio"; break;
                case 8: textomes = "Agosto"; break;
                case 9: textomes = "Septiembre"; break;
                case 10: textomes = "Octubre"; break;
                case 11: textomes = "Noviembre"; break;
                case 12: textomes = "Diciembre"; break;
                default: break;
            }

            this.Text = "Detalle Cuentas Programación Mensual - " + textomes;
            this.detalleProgramacionMensualPresentador = new DetalleProgramacionMensualPresentador(subPresupuestoPoco, this);
        }

        public List<SubPresupuestoAreaPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        public SubPresupuestoAreaPres SubPresupuestoArea
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SubPresupuestoAreaDetallePres SubPresupuestoAreaDetalle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override void InicializarDatos()
        {
            
            this.detalleProgramacionMensualPresentador.ObtenerDatosListado();
            
        }
    }
}
