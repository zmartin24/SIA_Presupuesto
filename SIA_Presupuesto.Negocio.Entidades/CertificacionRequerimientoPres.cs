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
    public partial class CertificacionRequerimientoPres
    {
    	[DataMember]
        public int idCerReq { get; set; }
    	[DataMember]
        public int numero { get; set; }
    	[DataMember]
        public string numeroReq { get; set; }
    	[DataMember]
        public string sigla { get; set; }
    	[DataMember]
        public System.DateTime fechaEmision { get; set; }
    	[DataMember]
        public int tipoReq { get; set; }
    	[DataMember]
        public string descripcionTipoReq { get; set; }
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
    	[DataMember]
        public decimal totalSoles { get; set; }
    	[DataMember]
        public decimal totalDolares { get; set; }
    	[DataMember]
        public string desPresupuesto { get; set; }
    	[DataMember]
        public string desSubpresupuesto { get; set; }
    	[DataMember]
        public decimal tipoCambio { get; set; }
    	[DataMember]
        public int idForebise { get; set; }
    	[DataMember]
        public string desEstado { get; set; }
    }
}
