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
    public partial class ProgramacionAnualEjeOperativo
    {
    	[DataMember]
        public int idProAnuEjeOpe { get; set; }
    	[DataMember]
        public int idEjeOpe { get; set; }
    	[DataMember]
        public int idProAnu { get; set; }
    	[DataMember]
        public string observacion { get; set; }
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
    
        public virtual EjeOperativo EjeOperativo { get; set; }
        public virtual ProgramacionAnual ProgramacionAnual { get; set; }
    }
}
