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
    public partial class ReporteRequerimientoBienServicioDetalleMensualPres
    {
    	[DataMember]
        public Nullable<int> idReqBieSer { get; set; }
    	[DataMember]
        public string desRequerimiento { get; set; }
    	[DataMember]
        public string desArea { get; set; }
    	[DataMember]
        public string desMoneda { get; set; }
    	[DataMember]
        public Nullable<int> idReqBieSerDet { get; set; }
    	[DataMember]
        public Nullable<int> idCueCon { get; set; }
    	[DataMember]
        public string numCuenta { get; set; }
    	[DataMember]
        public string desCuenta { get; set; }
    	[DataMember]
        public string descripcion { get; set; }
    	[DataMember]
        public Nullable<decimal> precio { get; set; }
    	[DataMember]
        public Nullable<decimal> impEne { get; set; }
    	[DataMember]
        public Nullable<decimal> impFeb { get; set; }
    	[DataMember]
        public Nullable<decimal> impMar { get; set; }
    	[DataMember]
        public Nullable<decimal> impAbr { get; set; }
    	[DataMember]
        public Nullable<decimal> impMay { get; set; }
    	[DataMember]
        public Nullable<decimal> impJun { get; set; }
    	[DataMember]
        public Nullable<decimal> impJul { get; set; }
    	[DataMember]
        public Nullable<decimal> impAgo { get; set; }
    	[DataMember]
        public Nullable<decimal> impSet { get; set; }
    	[DataMember]
        public Nullable<decimal> impOct { get; set; }
    	[DataMember]
        public Nullable<decimal> impNov { get; set; }
    	[DataMember]
        public Nullable<decimal> impDic { get; set; }
    	[DataMember]
        public string unidad { get; set; }
    }
}
