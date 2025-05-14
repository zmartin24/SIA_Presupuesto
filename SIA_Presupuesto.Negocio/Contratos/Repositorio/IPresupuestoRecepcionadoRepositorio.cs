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
    public interface IPresupuestoRecepcionadoRepositorio : IRepositorio<PresupuestoRecepcionado>
    {
        List<PresupuestoRecepcionadoPoco> ListaGrupo(int anio, int mesInicio, int mesFin);

        List<PresupuestoRecepcionadoPoco> listarDetalleRecepcionados(int idGrupo);

        List<PresupuestoRecepcionadoPoco> BuscarxIdAnio(int idGru, int anio);

        PresupuestoRecepcionadoPoco ObtenerRegistroxFiltro(int idGruPre, int anio, int mes);

        PresupuestoRecepcionadoPoco ObtenerRegistroxGrupo(int idGruPre, int anio);
    }
}
