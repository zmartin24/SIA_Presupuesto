using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class RequerimientoBienServicio
    {
        [DataMember] 
        public string desArea { get; set; }
        [DataMember]
        public string desSubdireccion { get; set; }
        [DataMember]
        public string desDireccion { get; set; }


    }
}
