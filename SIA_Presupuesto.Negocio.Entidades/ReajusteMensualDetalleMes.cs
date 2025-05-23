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
    public partial class ReajusteMensualDetalleMes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReajusteMensualDetalleMes()
        {
            this.ReajusteProgramacionMensualDetalleMes = new HashSet<ReajusteProgramacionMensualDetalleMes>();
        }
    
    	[DataMember]
        public int idReaMenDetMes { get; set; }
    	[DataMember]
        public int idReaMenDet { get; set; }
    	[DataMember]
        public int idReaMenAreaMes { get; set; }
    	[DataMember]
        public Nullable<int> idSubpresupuesto { get; set; }
    	[DataMember]
        public Nullable<int> dias { get; set; }
    	[DataMember]
        public decimal cantidad { get; set; }
    	[DataMember]
        public decimal importe { get; set; }
    	[DataMember]
        public string usuCrea { get; set; }
    	[DataMember]
        public System.DateTime fechaCrea { get; set; }
    	[DataMember]
        public string usuEdita { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaEdita { get; set; }
    	[DataMember]
        public int estado { get; set; }
    
        public virtual ReajusteMensualAreaMes ReajusteMensualAreaMes { get; set; }
        public virtual Subpresupuesto Subpresupuesto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<ReajusteProgramacionMensualDetalleMes> ReajusteProgramacionMensualDetalleMes { get; set; }
        public virtual ReajusteMensualDetalle ReajusteMensualDetalle { get; set; }
    }
}
