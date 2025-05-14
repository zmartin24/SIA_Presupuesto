using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IPuestoRequerimientoServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(PuestoRequerimiento puestoRequerimiento);
        Resultado Modificar(PuestoRequerimiento puestoRequerimiento);
        Resultado ModificarSinClonar(PuestoRequerimiento puestoRequerimiento);
        Resultado Anular(PuestoRequerimiento puestoRequerimiento, string usuario);
        Resultado AnularSinClonar(PuestoRequerimiento puestoRequerimiento, string usuario);
        bool GuardarPuestoRequerimientoEnProgramacionAnual(string codigos, int idProAnu, string usuario);

        #endregion

        #region Busquedas y listados
        PuestoRequerimiento BuscarPorCodigo(int idPueReq);
        PuestoRequerimiento BuscarPorTrabajador(int idReqRecHum, int idTrabajador);
        List<TrabajadorPres> ListaTrabajadoresRequerimiento(int anio);
        List<PuestoRequerimientoAnualPres> TraerListaPuestoRequerimientoAnual(int anio);
        #endregion

        #region Reportes

        #endregion
    }
}
