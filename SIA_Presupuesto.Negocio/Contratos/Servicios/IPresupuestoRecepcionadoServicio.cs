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
    public interface IPresupuestoRecepcionadoServicio : IServicio
    {
        Resultado Nuevo(PresupuestoRecepcionado Presupuesto);

        Resultado Modificar(PresupuestoRecepcionado Presupuesto);

        Resultado Eliminar(int id, int anio);

        PresupuestoRecepcionado BuscarPorCodigo(PresupuestoRecepcionado Presupuesto);

        List<PresupuestoRecepcionadoPoco> listarTodos(int anio, int mesInicio, int mesFin);

        List<PresupuestoRecepcionadoPoco> listarDetalleRecepcionados(int idGrupo);

        PresupuestoRecepcionadoPoco ObtenerRegistroxFiltro(int idGruPre, int anio, int mes);

        Resultado Transferir(int idGruPre, int anio, int mes, string usuarioRegistra, DateTime fechaCrea, List<GrupoPresupuestoTransferidoPoco> listaTemp);

        PresupuestoRecepcionadoPoco ObtenerRegistroxGrupo(int idGrupo, int anio);
    }
}
