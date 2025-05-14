using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPuestoRequerimientoRepositorio : IRepositorio<PuestoRequerimiento>
    {
        bool GuardarPuestoRequerimientoEnProgramacionAnual(string codigos, int idProAnu, string usuario);
        List<PuestoPoco> ListaPuestos(int idProAnu);
        List<TrabajadorPres> ListaTrabajadoresRequerimiento(int anio);
        List<PuestoRequerimientoAnualPres> TraerListaPuestoRequerimientoAnual(int anio);
    }
}
