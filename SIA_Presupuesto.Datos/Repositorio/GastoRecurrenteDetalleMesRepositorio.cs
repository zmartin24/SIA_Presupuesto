using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class GastoRecurrenteDetalleMesRepositorio : Repositorio<GastoRecurrenteDetalleMes>, IGastoRecurrenteDetalleMesRepositorio
    {
        private IContexto contexto;
        public GastoRecurrenteDetalleMesRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        #region Operaciones
        #endregion

        #region Listas
        #endregion
    }
}
