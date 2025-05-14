using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IRequerimientoMensualDetalleRepositorio : IRepositorio<RequerimientoMensualDetalle>
    {
        List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalle(int idReqMenBieSer);
    }
}
