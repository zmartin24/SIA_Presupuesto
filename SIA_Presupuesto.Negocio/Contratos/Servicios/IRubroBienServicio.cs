using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IRubroBienServicio : IServicio
    {
        List<RubroBienServicioPoco> ObtenerLista();

        Resultado Nuevo(RubroBienServicio rubroBienServicio);

        Resultado Modificar(RubroBienServicio rubroBienServicio);

        Resultado Anular(int id);
    }
}
