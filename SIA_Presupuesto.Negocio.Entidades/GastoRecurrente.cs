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
    using System.Collections.Generic;
    
    using System.Runtime.Serialization;
    
    [DataContract(IsReference = true)]
    public partial class GastoRecurrente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GastoRecurrente()
        {
            this.GastoRecurrenteRequerimiento = new HashSet<GastoRecurrenteRequerimiento>();
        }
    
    	[DataMember]
        public int idGasRec { get; set; }
    	[DataMember]
        public string descripcion { get; set; }
    	[DataMember]
        public Nullable<int> idEntidad { get; set; }
    	[DataMember]
        public Nullable<int> anio { get; set; }
    	[DataMember]
        public Nullable<int> idMoneda { get; set; }
    	[DataMember]
        public Nullable<decimal> tipCam { get; set; }
    	[DataMember]
        public string usuCrea { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaCrea { get; set; }
    	[DataMember]
        public string usuEdita { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaEdita { get; set; }
    	[DataMember]
        public Nullable<int> estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<GastoRecurrenteRequerimiento> GastoRecurrenteRequerimiento { get; set; }
    }
}
