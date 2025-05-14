using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPropiedadPresupuestoRemuneracionRepositorio : IRepositorio<PropiedadPresupuestoRemuneracion>
    {
        List<PropiedadPoco> TraerPropiedadPresentacion();
        List<PropiedadPoco> TraerPropiedadPresentacion(int idEstPreRem);

    }
}
