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
    public partial class ReajusteMensualProgramacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReajusteMensualProgramacion()
        {
            this.ReajusteMensualArea = new HashSet<ReajusteMensualArea>();
            this.PuestoReajustePresupuesto = new HashSet<PuestoReajustePresupuesto>();
        }
    
    	[DataMember]
        public int idReaMenPro { get; set; }
    	[DataMember]
        public int idProAnu { get; set; }
    	[DataMember]
        public decimal tipoCambio { get; set; }
    	[DataMember]
        public string descripcion { get; set; }
    	[DataMember]
        public System.DateTime fechaEmision { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaAprobacion { get; set; }
    	[DataMember]
        public int mesReajuste { get; set; }
    	[DataMember]
        public Nullable<int> mesDesdeRem { get; set; }
    	[DataMember]
        public Nullable<int> mesHastaRem { get; set; }
    	[DataMember]
        public Nullable<int> idEstPreRem { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<ReajusteMensualArea> ReajusteMensualArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<PuestoReajustePresupuesto> PuestoReajustePresupuesto { get; set; }
        public virtual ProgramacionAnual ProgramacionAnual { get; set; }
    }
}
