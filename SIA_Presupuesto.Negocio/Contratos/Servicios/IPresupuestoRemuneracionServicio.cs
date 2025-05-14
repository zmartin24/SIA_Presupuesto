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
    public interface IPresupuestoRemuneracionServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(PresupuestoRemuneracion PresupuestoRemuneracion);

        Resultado Modificar(PresupuestoRemuneracion PresupuestoRemuneracion);

        Resultado Anular(PresupuestoRemuneracion PresupuestoRemuneracion);

        Resultado AnularPuestos(List<PuestoPresupuesto> PuestoPresupuesto, string usuario);

        Resultado Nuevo(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idProAnu, string usuario, int mesDesde, int mesHasta);

        Resultado Modificar(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idProAnu, string usuario, int mesDesde, int mesHasta);

        List<ResultadoCalculoPoco> CalcularPresupuestoRemuneraciones(int idProAnu, int idEstPreRem, int mesDesde, int mesHasta);

        #endregion

        #region Busquedas y listados

        PresupuestoRemuneracion BuscarPorCodigo(int idPresupuestoRemuneracion);

        List<PresupuestoRemuneracion> listarTodos();
        List<PresupuestoRemuneracion> TraerTodosActivos();

        List<DatosPuestoCalculo> TraerDatosPuestoCalculo(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idProAnu);

        List<DatoCalculoPresupuestoRemuneracion> TraerDatosCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem);

        List<CalculoPresupuestoRemuneracion> TraerResultadoCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem);

        bool NuevoProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem);

        bool ModificarProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod);

        List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(int idProAnu);

        List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(string codigoGruPre, string codigosDir, int anio);

        #endregion
    }
}
