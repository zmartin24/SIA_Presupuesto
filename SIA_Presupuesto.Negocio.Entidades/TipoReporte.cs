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
    public partial class TipoReporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoReporte()
        {
            this.TipoReporteGrupoFinan = new HashSet<TipoReporteGrupoFinan>();
            this.ReportePresupuesto = new HashSet<ReportePresupuesto>();
            this.TipoReporteGrupoPresupuesto = new HashSet<TipoReporteGrupoPresupuesto>();
        }
    
    	[DataMember]
        public int idTipRep { get; set; }
    	[DataMember]
        public string descripcion { get; set; }
    	[DataMember]
        public string nomReporte { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<TipoReporteGrupoFinan> TipoReporteGrupoFinan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<ReportePresupuesto> ReportePresupuesto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	//[DataMember]
        public virtual ICollection<TipoReporteGrupoPresupuesto> TipoReporteGrupoPresupuesto { get; set; }
    }
}
