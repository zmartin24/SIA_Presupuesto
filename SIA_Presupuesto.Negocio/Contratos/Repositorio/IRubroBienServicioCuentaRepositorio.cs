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
    public interface IRubroBienServicioCuentaRepositorio : IRepositorio<RubroBienServicioCuenta>
    {
        List<RubroBienServicioCuentaPoco> TraerLista(int idPlanCuenta);

        List<ItemPoco> TraerListaPlanCuenta();

        List<CuentaContablePoco> TraerListaCtaxNivelPlan(int idPlan, int? nivel,int dependencia);

        CuentaContablePoco ValidarExisteCta(int idCuenta);

        CuentaContablePoco ObtenerCuenta(int idCuenta);
    }
}
