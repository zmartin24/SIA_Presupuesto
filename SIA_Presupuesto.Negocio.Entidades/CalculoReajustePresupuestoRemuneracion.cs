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
    public partial class CalculoReajustePresupuestoRemuneracion
    {
    	[DataMember]
        public int idReaPuePre { get; set; }
    	[DataMember]
        public Nullable<int> idTrabajador { get; set; }
    	[DataMember]
        public string trabajador { get; set; }
    	[DataMember]
        public decimal remuneracion { get; set; }
    	[DataMember]
        public int grado { get; set; }
    	[DataMember]
        public string cargo { get; set; }
    	[DataMember]
        public string esRemDiaria { get; set; }
    	[DataMember]
        public Nullable<int> cantVacante { get; set; }
    	[DataMember]
        public string concepto { get; set; }
    	[DataMember]
        public string abrConcepto { get; set; }
    	[DataMember]
        public int mes { get; set; }
    	[DataMember]
        public string nomMes { get; set; }
    	[DataMember]
        public decimal importe { get; set; }
    }
}
