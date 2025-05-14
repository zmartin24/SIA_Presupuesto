using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Helper
{
    public class ReporteHelper
    {
        public static XtraReport TraerReporte(string nombreReporte)
        {
            var tipo = RegistroReporteHelper.BuscarModulo(nombreReporte);
            ConstructorInfo constructorInfoObj = tipo.GetConstructor(Type.EmptyTypes);
            if (constructorInfoObj == null)
                throw new ApplicationException(string.Format("", tipo.FullName));
            return constructorInfoObj.Invoke(null) as XtraReport;

        }


    }
}
