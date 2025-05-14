using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IPeriodoServicio
    {
        #region Busquedas y listados

        Periodo ObtenerxAnio(int anio);

        Periodo ObtenerActivo();

        List<Periodo> ListaPeriodo();

        #endregion
    }
}
