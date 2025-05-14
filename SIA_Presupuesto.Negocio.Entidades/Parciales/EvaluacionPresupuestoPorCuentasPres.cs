using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class EvaluacionPresupuestoPorCuentasPres
    {
        [DataMember]
        public List<EvaluacionPresupuestoPorCuentasPres> ListaDivisionarias{ get; set; }
        [DataMember]
        public List<EvaluacionPresupuestoPorCuentasPres> ListaCuentasEspecificas { get; set; }
        [DataMember]
        public List<EvaluacionPresupuestoDetalleMovimientosPres> ListaDeVouchers { get; set; }

        //[DataMember]
        //public List<EvaluacionPresupuestoPorCuentasDiv> ListaDivisionarias { get; set; }
    }
    //public partial class EvaluacionPresupuestoPorCuentasDiv
    //{
    //    [DataMember]
    //    public List<EvaluacionPresupuestoPorCuentasPres> EvaluacionPresupuestoPorCuentasEsp { get; set; }
    //    //[DataMember]
    //    //public List<EvaluacionPresupuestoDetalleMovimientosPres> EvaluacionPresupuestoDetalleMovimientosPres { get; set; }
    //}
    //public partial class EvaluacionPresupuestoPorCuentasDiv
    //{
    //    public string numCuenta { get; set; }
    //    public string desCuenta { get; set; }
    //    public decimal importePre { get; set; }
    //    public decimal importeEje { get; set; }
    //    public decimal saldo { get; set; }

    //    public List<EvaluacionPresupuestoPorCuentasEsp> ListaCuentas { get; set; }
    //}
    //public partial class EvaluacionPresupuestoPorCuentasEsp
    //{
    //    public string numCuenta { get; set; }
    //    public string desCuenta { get; set; }
    //    public decimal importePre { get; set; }
    //    public decimal importeEje { get; set; }
    //    public decimal saldo { get; set; }

    //    public List<EvaluacionPresupuestoDetalleMovimientosPres> EvaluacionPresupuestoDetalleMovimientosPres { get; set; }
    //}
}
