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
    public partial class RequerimientoBienServicioPres
    {
    	[DataMember]
        public int idReqBieSer { get; set; }
    	[DataMember]
        public string descripcion { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaEmision { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaAprobacion { get; set; }
    	[DataMember]
        public string moneda { get; set; }
    	[DataMember]
        public Nullable<int> anio { get; set; }
    	[DataMember]
        public string desArea { get; set; }
    	[DataMember]
        public string desSubdireccion { get; set; }
    	[DataMember]
        public string desDireccion { get; set; }
    	[DataMember]
        public Nullable<decimal> total { get; set; }
    	[DataMember]
        public int mesInicio { get; set; }
    	[DataMember]
        public string nomMes { get; set; }
    	[DataMember]
        public string usuCrea { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaCrea { get; set; }
    	[DataMember]
        public string usuEdita { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaEdita { get; set; }
    	[DataMember]
        public Nullable<bool> esSeleccionado { get; set; }
    }
}
