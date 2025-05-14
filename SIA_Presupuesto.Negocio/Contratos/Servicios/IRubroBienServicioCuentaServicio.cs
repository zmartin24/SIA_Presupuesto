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
    public interface IRubroBienServicioCuentaServicio : IServicio
    {
        List<RubroBienServicioCuentaPoco> ObtenerLista(int idPlanCuenta);

        Resultado Nuevo(RubroBienServicioCuenta rubroBienServicio);

        Resultado Modificar(RubroBienServicioCuenta rubroBienServicio);

        Resultado Anular(int id);

        List<ItemPoco> TraerListaPlanCuenta();

        List<CuentaContablePoco> TraerListaCtaxNivelPlan(int idPlan, int? nivel,int dependencia);

        CuentaContablePoco ValidarExisteCta(int idCuenta);

        CuentaContablePoco ObtenerCuenta(int idCuenta);
    }
}
