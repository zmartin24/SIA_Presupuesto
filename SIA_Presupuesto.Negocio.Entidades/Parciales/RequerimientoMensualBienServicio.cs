using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class RequerimientoMensualBienServicio
    {
        [DataMember]
        public string desTipo { get; set; }
        [DataMember] 
        public string desArea { get; set; }
        [DataMember]
        public string desSubdireccion { get; set; }
        [DataMember]
        public string desDireccion { get; set; }
    }
}
