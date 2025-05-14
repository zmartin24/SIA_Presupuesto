using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ProgramacionAnual
    {
        [DataMember]
        public List<ProgramacionSedeLaboralPoco> listaSedes { get; set; }

        [DataMember]
        public List<ProgramacionEjeOperativoPoco> listaEjeOperativos { get; set; }
    }
}
