using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class CertificacionMasterPres
    {
        [DataMember]
        public Forebi forebi { get; set; }
        public Forese forese { get; set; }
        public ValidarForebisePres validarForebisePres { get; set; }

    }
}
