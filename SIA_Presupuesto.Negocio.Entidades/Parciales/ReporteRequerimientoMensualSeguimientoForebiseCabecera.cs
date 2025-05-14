using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteRequerimientoMensualSeguimientoForebiseCabecera
    {
        [DataMember]
        public Nullable<int> id { get; set; }
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string numero { get; set; }
        [DataMember]
        public Nullable<System.DateTime> fechaEmision { get; set; }
        [DataMember]
        public string desPresupuesto { get; set; }
        [DataMember]
        public string desSubpresupuesto { get; set; }
        [DataMember]
        public string desDireccion { get; set; }
        [DataMember]
        public string desSubDireccion { get; set; }
        [DataMember]
        public Nullable<int> estado { get; set; }
        [DataMember]
        public string desEstado { get; set; }
        [DataMember]
        public string nroCertificacion { get; set; }
        [DataMember]
        public string nroOrden { get; set; }
        [DataMember]
        public Nullable<decimal> importeCertificacion { get; set; }
        [DataMember]
        public Nullable<decimal> importeOrden { get; set; }

        [DataMember]
        public List<ReporteRequerimientoMensualSeguimientoForebisePres> ListaDetalles{ get; set; }
    }
    
}
