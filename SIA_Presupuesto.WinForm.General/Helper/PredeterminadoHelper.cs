using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class PredeterminadoHelper
    {
        public static List<Predeterminado> ListarTipoProgramacion()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "NN", descripcion = "NORMAL" });
            lista.Add(new Predeterminado { codigo = "ER", descripcion = "ERRADICACIÓN" });
            lista.Add(new Predeterminado { codigo = "AV", descripcion = "AVIACIÓN" });
            lista.Add(new Predeterminado { codigo = "DI", descripcion = "DIRECCIÓN" });
            lista.Add(new Predeterminado { codigo = "RE", descripcion = "REMUNERACIÓN" });

            return lista;
        }

        public static List<Predeterminado> ListarNroTrandferencia()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "1", descripcion = "1ra. TRANSFERENCIA" });
            lista.Add(new Predeterminado { codigo = "2", descripcion = "2ra. TRANSFERENCIA" });
            lista.Add(new Predeterminado { codigo = "3", descripcion = "3ra. TRANSFERENCIA" });
            lista.Add(new Predeterminado { codigo = "4", descripcion = "4ra. TRANSFERENCIA" });
            lista.Add(new Predeterminado { codigo = "5", descripcion = "5ra. TRANSFERENCIA" });

            return lista;
        }

        public static List<Predeterminado> ListarTipoReportePorDireccion()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "01", descripcion = "REPORTE REQUERIMIENTO POR DIRECCION" });
            lista.Add(new Predeterminado { codigo = "02", descripcion = "EXPORTAR REQUERIMIENTO POR DIRECCION" });
            lista.Add(new Predeterminado { codigo = "03", descripcion = "EXPORTAR REQUERIMIENTO POR DIRECCION - AREA" });
            lista.Add(new Predeterminado { codigo = "04", descripcion = "EXPORTAR REQUERIMIENTO - AREA FORMATO II" });

            return lista;
        }

        public static List<Predeterminado> ListarTipoReportePorDireccionPresupuestoAnual()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "RE", descripcion = "POR DIRECCION Y SUBDIRECCION" });

            return lista;
        }

        public static List<Predeterminado> ListarEstadosProgramacionAnual()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "10", descripcion = "APROBADO" });
            lista.Add(new Predeterminado { codigo = "11", descripcion = "RECHAZADO" });

            return lista;
        }

        public static List<Predeterminado> ListarAgrupamientoPresupuesto()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "CO", descripcion = "PRESUPUESTOS CORAH" });
            lista.Add(new Predeterminado { codigo = "SA", descripcion = "PRESUPUESTOS INL" });

            return lista;
        }

        public static List<Predeterminado> ListarTipoConcepto()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "IN", descripcion = "INGRESOS" });
            lista.Add(new Predeterminado { codigo = "DE", descripcion = "DESCUENTO" });
            lista.Add(new Predeterminado { codigo = "DA", descripcion = "DATOS" });

            return lista;
        }

        public static List<Predeterminado> ListarOrigenConcepto()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "NNN", descripcion = "NINGUNO" });
            lista.Add(new Predeterminado { codigo = "PAR", descripcion = "PARAMETROS" });
            lista.Add(new Predeterminado { codigo = "REM", descripcion = "REMUNERACION PUESTO" });
            lista.Add(new Predeterminado { codigo = "RDI", descripcion = "ES REMUNERACION DIARIA" });
            lista.Add(new Predeterminado { codigo = "ESV", descripcion = "ES PUESTO VACANTE" });
            lista.Add(new Predeterminado { codigo = "CVA", descripcion = "CANTIDAD DE VACANTES" });

            lista.Add(new Predeterminado { codigo = "MES", descripcion = "MES DE CALCULO" });
            lista.Add(new Predeterminado { codigo = "IBA", descripcion = "INDICA BONO ALIMENTACION" });
            lista.Add(new Predeterminado { codigo = "IBD", descripcion = "INDICA BONO ALIMENTACION ESPECIAL" });
            lista.Add(new Predeterminado { codigo = "IBM", descripcion = "INDICA BONO MOVILIDAD" });
            lista.Add(new Predeterminado { codigo = "IBP", descripcion = "INDICA BONO PRODUCTIVIDAD" });

            return lista;
        }

        public static List<Predeterminado> ListarTipoValor()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "FI", descripcion = "FIJO" });
            lista.Add(new Predeterminado { codigo = "FR", descripcion = "FORMULA" });

            return lista;
        }
        
        public static List<Predeterminado> ListarTipoReportePorDireccionGastoRecurrente()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "01", descripcion = "GASTO RECURRENTE GENERAL" });
            lista.Add(new Predeterminado { codigo = "02", descripcion = "GASTO RECURRENTE POR DIRECCION" });

            return lista;
        }
        public static List<Predeterminado> ListarTipoReportePac()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "01", descripcion = "PLAN ANUAL DE CONTRATACIONES AGRUPADO POR CUENTA" });
            lista.Add(new Predeterminado { codigo = "02", descripcion = "PLAN ANUAL DE CONTRATACIONES AGRUPADO POR DIRECCION" });

            return lista;
        }
        public static List<Predeterminado> ListarTipoReporteGeneral()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "03", descripcion = "ORDEN COMPRA & SERVICIO - GENERAL" });
            lista.Add(new Predeterminado { codigo = "04", descripcion = "ORDEN COMPRA & SERVICIO - COMPROMETIDAS" });
            lista.Add(new Predeterminado { codigo = "05", descripcion = "ORDEN COMPRA & SERVICIO - PROVISIONADAS" });
            lista.Add(new Predeterminado { codigo = "06", descripcion = "ORDEN COMPRA & SERVICIO - PAGADAS" });

            return lista;
        }

        public static List<Predeterminado> ListarTipoCertifiacionRequerimientoReporte()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "0", descripcion = "TODOS" });
            lista.Add(new Predeterminado { codigo = "1", descripcion = "BIEN" });
            lista.Add(new Predeterminado { codigo = "2", descripcion = "SERVICIO" });
            
            return lista;
        }
        
        public static List<Anio> ListaAnio()
        {
            //List<Predeterminado> lista = new List<Predeterminado>();
            //int vanioi = 2018;
            //int vaniof = DateTime.Now.Year;
            //for (int i = vanioi; i <= vaniof; i++)
            //{
            //    lista.Add(new Predeterminado { codigo = i.ToString(), descripcion = i.ToString() });
            //}
            //return lista;
            return UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2017);
        }

        public static List<Predeterminado> ListarTipoRequerimiento()
        {
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "1", descripcion = "BIENES" });
            lista.Add(new Predeterminado { codigo = "2", descripcion = "SERVICIOS" });

            return lista;
        }
    }

    public class Predeterminado
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
}
