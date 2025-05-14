using DevExpress.XtraEditors.DXErrorProvider;
using SIA_Presupuesto.WinForm.General.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ValidacionHelper
    {
        static ConditionValidationRule reglaNoDebeSerVacio = null;
        static ConditionValidationRule reglaMayorIgualCero = null;
        static ConditionValidationRule reglaMayorCero = null;
        static ConditionValidationRule reglaEsFecha = null;
        static ConditionValidationRule reglaVacio = null;

        public static ConditionValidationRule ReglaNoDebeSerVacio
        {
            get
            {
                if (reglaNoDebeSerVacio == null)
                {
                    reglaNoDebeSerVacio = new ConditionValidationRule();
                    reglaNoDebeSerVacio.ConditionOperator = ConditionOperator.IsNotBlank;
                    reglaNoDebeSerVacio.ErrorText = Mensajes.AdvertenciaValidacionEsNoVacio;
                    reglaNoDebeSerVacio.ErrorType = ErrorType.Critical;
                }
                return reglaNoDebeSerVacio;
            }
        }

        public static ConditionValidationRule ReglaVacio
        {
            get
            {
                if (reglaVacio == null)
                {
                    reglaVacio = new ConditionValidationRule();
                    reglaVacio.ConditionOperator = ConditionOperator.IsBlank;
                    reglaVacio.ErrorText = "";
                    reglaVacio.ErrorType = ErrorType.Critical;
                }
                return reglaVacio;
            }
        }

        public static ConditionValidationRule ReglaMayorIgualCero
        {
            get
            {
                if (reglaMayorIgualCero == null)
                {
                    reglaMayorIgualCero = new ConditionValidationRule();
                    reglaMayorIgualCero.ConditionOperator = ConditionOperator.GreaterOrEqual;
                    reglaMayorIgualCero.Value1 = 0;
                    reglaMayorIgualCero.ErrorText = Mensajes.AdvertenciaValidacionMayorIgualCero;
                    reglaMayorIgualCero.ErrorType = ErrorType.Critical;
                }
                return reglaMayorIgualCero;
            }
        }

        public static ConditionValidationRule ReglaMayorCero
        {
            get
            {
                if (reglaMayorIgualCero == null)
                {
                    reglaMayorCero = new ConditionValidationRule();
                    reglaMayorCero.ConditionOperator = ConditionOperator.Greater;
                    reglaMayorCero.Value1 = 0;
                    reglaMayorCero.ErrorText = Mensajes.AdvertenciaValidacionMayorCero;
                    reglaMayorCero.ErrorType = ErrorType.Critical;
                }
                return reglaMayorCero;
            }
        }

        public static ConditionValidationRule ReglaEsFecha
        {
            get
            {
                if (reglaEsFecha == null)
                {
                    reglaEsFecha = new ConditionValidationRule();

                    reglaEsFecha.ConditionOperator = ConditionOperator.Between;

                    reglaEsFecha.Value1 = new DateTime(1900, 1, 1);
                    reglaEsFecha.Value2 = new DateTime(2050, 12, 31);

                    reglaEsFecha.ErrorText = Mensajes.AdvertenciaValidacionEsFecha;
                    reglaEsFecha.ErrorType = ErrorType.Critical;
                }
                return reglaEsFecha;
            }
        }

        public static ConditionValidationRule ReglaMayorIgual(int valor)
        {
            ConditionValidationRule ret = new ConditionValidationRule();
            ret.ConditionOperator = ConditionOperator.GreaterOrEqual;
            ret.Value1 = valor;
            ret.ErrorText = Mensajes.AdvertenciaValidacionMayorIgualCero;
            ret.ErrorType = ErrorType.Critical;
            return ret;
        }
    }
}
