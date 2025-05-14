using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ProgramacionAnualDetalleMesRepositorio : Repositorio<ProgramacionAnualDetalleMes>, IProgramacionAnualDetalleMesRepositorio
    {
        public ProgramacionAnualDetalleMesRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

       
    }
}
