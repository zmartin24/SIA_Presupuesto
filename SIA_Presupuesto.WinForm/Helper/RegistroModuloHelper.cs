using SIA_Presupuesto.WinForm.Adquisicion;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Mantenimiento;
using SIA_Presupuesto.WinForm.Programacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Helper
{
    public class RegistroModuloHelper
    {
        private static ColeccionRegistroHelper coleccionRegistro;

        public static void CargarModulos()
        {
            coleccionRegistro = new ColeccionRegistroHelper();

            //Controles de Usuario
            coleccionRegistro.Agregar(typeof(ListaProgramacionAnual));
            coleccionRegistro.Agregar(typeof(ListaEvaluacionMensualPresupuesto));
            coleccionRegistro.Agregar(typeof(ListaRequerimientoBienServicio));
            coleccionRegistro.Agregar(typeof(ListaPlanAnualAdquisicion));
            coleccionRegistro.Agregar(typeof(ConsultaProgramacionAnual));
            coleccionRegistro.Agregar(typeof(ListaGastoRecurrente));
            coleccionRegistro.Agregar(typeof(frmGeneralReporte));
            coleccionRegistro.Agregar(typeof(ListaReajusteMensualPresupuesto));
            coleccionRegistro.Agregar(typeof(ListaGrupoPresupuesto));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoMensual));
            coleccionRegistro.Agregar(typeof(frmReporteEvaluacionBienServicio));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoRecepcionado));
            coleccionRegistro.Agregar(typeof(ListaCatGastosRecurrentes));
            coleccionRegistro.Agregar(typeof(ListaCuentaGastosRecurrentes));
            coleccionRegistro.Agregar(typeof(ListaCertificacionRequerimiento));
            coleccionRegistro.Agregar(typeof(ListaFuenteFinanciamiento));
            coleccionRegistro.Agregar(typeof(ListaTipoCambioPresupuesto));
            coleccionRegistro.Agregar(typeof(ListaEjeOperativo));
            coleccionRegistro.Agregar(typeof(ListaModalidad));
            coleccionRegistro.Agregar(typeof(ListaEvaluacionPresupuestoCuenta));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoEjecutadoFondos));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoEjecutadoFondosPorCuenta));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoAproCom));

            coleccionRegistro.Agregar(typeof(ListaConceptoPresRem));
            coleccionRegistro.Agregar(typeof(ListaParametroPresRem));
            coleccionRegistro.Agregar(typeof(ListaEstructuraPresRem));
            coleccionRegistro.Agregar(typeof(ListaTipoCambioAnual));
            coleccionRegistro.Agregar(typeof(ListaCertificacionMaster));
            coleccionRegistro.Agregar(typeof(ListaPrecioBienServicio));
            coleccionRegistro.Agregar(typeof(ListaRequerimientoRecursoHumano));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoFases));
            coleccionRegistro.Agregar(typeof(ListaPartidaPresupuestal));
            coleccionRegistro.Agregar(typeof(ListaRequerimientoMensualBienServicio));
            coleccionRegistro.Agregar(typeof(ListaRequerimientoMensualAsignacion));
            coleccionRegistro.Agregar(typeof(ListaPresupuestoEjecutado));



            //ListaNivelSaldo
        }

        public static Type BuscarModulo(string nombre)
        {
            return coleccionRegistro.Buscar(nombre);
        }
    }
}
