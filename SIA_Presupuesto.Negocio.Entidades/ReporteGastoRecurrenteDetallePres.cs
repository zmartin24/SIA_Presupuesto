//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIA_Presupuesto.Negocio.Entidades
{
    using System;
    
    using System.Runtime.Serialization;
    
    [DataContract(IsReference = true)]
    public partial class ReporteGastoRecurrenteDetallePres
    {
    	[DataMember]
        public Nullable<int> idgasrecDet { get; set; }
    	[DataMember]
        public string titulo { get; set; }
    	[DataMember]
        public string numCuentaNivel1 { get; set; }
    	[DataMember]
        public string descripcionNivel1 { get; set; }
    	[DataMember]
        public string numCuentaNivel2 { get; set; }
    	[DataMember]
        public string descripcionNivel2 { get; set; }
    	[DataMember]
        public string numCuenta { get; set; }
    	[DataMember]
        public string descripcionCuenta { get; set; }
    	[DataMember]
        public string endtidad { get; set; }
    	[DataMember]
        public string ruc { get; set; }
    	[DataMember]
        public Nullable<int> anio { get; set; }
    	[DataMember]
        public string desDetalle { get; set; }
    	[DataMember]
        public string Abreviado { get; set; }
    	[DataMember]
        public decimal cant { get; set; }
    	[DataMember]
        public Nullable<decimal> precio { get; set; }
    	[DataMember]
        public string abreviatura { get; set; }
    	[DataMember]
        public decimal tipoCambio { get; set; }
    }
}
