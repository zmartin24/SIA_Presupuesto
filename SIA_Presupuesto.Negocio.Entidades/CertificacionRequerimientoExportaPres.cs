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
    public partial class CertificacionRequerimientoExportaPres
    {
    	[DataMember]
        public Nullable<int> idCerReq { get; set; }
    	[DataMember]
        public Nullable<int> idCerMas { get; set; }
    	[DataMember]
        public Nullable<int> numero { get; set; }
    	[DataMember]
        public string sigla { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaEmision { get; set; }
    	[DataMember]
        public string descripcion { get; set; }
    	[DataMember]
        public Nullable<int> tipoReq { get; set; }
    	[DataMember]
        public string descripcionTipoReq { get; set; }
    	[DataMember]
        public Nullable<int> idForebise { get; set; }
    	[DataMember]
        public string numeroReq { get; set; }
    	[DataMember]
        public string direccion { get; set; }
    	[DataMember]
        public string estadoReq { get; set; }
    	[DataMember]
        public Nullable<int> idPresupuesto { get; set; }
    	[DataMember]
        public string desPresupuesto { get; set; }
    	[DataMember]
        public Nullable<int> idSubpresupuesto { get; set; }
    	[DataMember]
        public string desSubpresupuesto { get; set; }
    	[DataMember]
        public string numCuenta { get; set; }
    	[DataMember]
        public string rubro { get; set; }
    	[DataMember]
        public Nullable<decimal> totalSoles { get; set; }
    	[DataMember]
        public Nullable<decimal> totalDolares { get; set; }
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
    	[DataMember]
        public string numOrden { get; set; }
    	[DataMember]
        public string usuAmp { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaAmp { get; set; }
    	[DataMember]
        public string usuEditaAmp { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> fechaEditaAmp { get; set; }
    	[DataMember]
        public Nullable<decimal> impPendiente { get; set; }
    	[DataMember]
        public string desProductoServicio { get; set; }
    	[DataMember]
        public Nullable<decimal> cantidad { get; set; }
    	[DataMember]
        public Nullable<decimal> precio { get; set; }
    	[DataMember]
        public Nullable<decimal> tipoCambio { get; set; }
    	[DataMember]
        public Nullable<decimal> precioDolares { get; set; }
    	[DataMember]
        public string unidad { get; set; }
    }
}
