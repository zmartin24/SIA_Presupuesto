using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class PropiedadPoco
    {
        [DataMember]
        public int idProPreRem { get; set; }
        [DataMember]
        public int idConPreRem { get; set; }
        [DataMember]
        public int idEstPreRem { get; set; }
        [DataMember]
        public string concepto { get; set; }
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string tipo { get; set; }
        [DataMember]
        public string codOrigen { get; set; }
        [DataMember]
        public string origen { get; set; }
        [DataMember]
        public string tipoValor { get; set; }
        [DataMember]
        public string codTipoValor { get; set; }
        [DataMember]
        public string valor { get; set; }
        [DataMember]
        public int orden { get; set; }
        [DataMember]
        public string visualiza { get; set; }
        [DataMember]
        public bool seVisualiza { get; set; }
        [DataMember]
        public bool esAcumulativo { set; get; }
        [DataMember]
        public int numero { set; get; }
        [DataMember]
        public int numeroImp { set; get; }
        //[DataMember]
        //public CalcEngine.CalcEngine calculadora { get; set; }

    }
}
