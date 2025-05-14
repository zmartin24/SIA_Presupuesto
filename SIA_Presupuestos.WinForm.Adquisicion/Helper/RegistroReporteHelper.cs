using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;

namespace SIA_Presupuesto.WinForm.Adquisicion.Helper
{
    public class RegistroReporteHelper
    {
        private static ColeccionRegistroHelper coleccionRegistro;

        public static void CargarModulos()
        {
            coleccionRegistro = new ColeccionRegistroHelper();

            coleccionRegistro.Agregar(typeof(rptCertificacionPresupuestal));
            coleccionRegistro.Agregar(typeof(rptGastoRecurrenteDireccion));
            
        }

        public static Type BuscarModulo(string nombre)
        {
            return coleccionRegistro.Buscar(nombre);
        }
    }
}
