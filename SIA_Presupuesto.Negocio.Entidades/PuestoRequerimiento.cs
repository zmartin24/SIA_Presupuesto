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
    public partial class PuestoRequerimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PuestoRequerimiento()
        {
            this.PuestoReqPre = new HashSet<PuestoReqPre>();
        }
    
    	[DataMember]
        public int idPueReq { get; set; }
    	[DataMember]
        public int idReqRecHum { get; set; }
    	[DataMember]
        public Nullable<int> idTrabajador { get; set; }
    	[DataMember]
        public int idCargo { get; set; }
    	[DataMember]
        public Nullable<int> idSede { get; set; }
    	[DataMember]
        public int idTipMon { get; set; }
    	[DataMember]
        public Nullable<int> idRegLab { get; set; }
    	[DataMember]
        public Nullable<int> idConLab { get; set; }
    	[DataMember]
        public Nullable<int> idCatLab { get; set; }
    	[DataMember]
        public int grado { get; set; }
    	[DataMember]
        public decimal remuneracion { get; set; }
    	[DataMember]
        public Nullable<int> idCargoPropuesto { get; set; }
    	[DataMember]
        public Nullable<int> gradoPropuesto { get; set; }
    	[DataMember]
        public Nullable<decimal> remPropuesta { get; set; }
    	[DataMember]
        public bool esRemDiaria { get; set; }
    	[DataMember]
        public bool esVacante { get; set; }
    	[DataMember]
        public Nullable<int> cantVacante { get; set; }
    	[DataMember]
        public Nullable<bool> conBonoAlimento { get; set; }
    	[DataMember]
        public Nullable<bool> conBonoProductividad { get; set; }
    	[DataMember]
        public Nullable<bool> conBonoMovilidad { get; set; }
    	[DataMember]
        public Nullable<bool> conBonoAlimentoAdi { get; set; }
    	[DataMember]
        public int idFueFin { get; set; }
    	[DataMember]
        public string observacion { get; set; }
    	[DataMember]
        public string justificacion { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaInicio { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaTermino { get; set; }
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
    
        public virtual FuenteFinanciamiento FuenteFinanciamiento { get; set; }
        public virtual RequerimientoRecursoHumano RequerimientoRecursoHumano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<PuestoReqPre> PuestoReqPre { get; set; }
    }
}
