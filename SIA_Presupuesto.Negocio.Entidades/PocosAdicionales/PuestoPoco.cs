using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class PuestoPoco
    {
        [DataMember]
        public int idPuesto { get; set; }
        [DataMember]
        public int idTipMon { get; set; }
        [DataMember]
        public decimal remuneracion { get; set; }
        [DataMember]
        public bool esRemDiaria { get; set; }
        [DataMember]
        public bool esVacante { get; set; }
        [DataMember]
        public int cantVacante { get; set; }
        [DataMember]
        public int situacionEspecial { get; set; }
        [DataMember]
        public int grado { get; set; }
        [DataMember]
        public bool conBonoAlimentacion { get; set; }
        [DataMember]
        public bool conBonoAlimentacionAdi { get; set; }
        [DataMember]
        public bool conBonoMovilidad { get; set; }
        [DataMember]
        public bool conBonoProductividad { get; set; }
        [DataMember]
        public bool conSctrSalud { get; set; }
        [DataMember]
        public bool conSctrPension { get; set; }
        [DataMember]
        public DateTime fechaInicio { get; set; }
        [DataMember]
        public DateTime fechaTermino { get; set; }
        [DataMember]
        public int idCatLab { get; set; }
        [DataMember]
        public int idConLab { get; set; }
    }
}
