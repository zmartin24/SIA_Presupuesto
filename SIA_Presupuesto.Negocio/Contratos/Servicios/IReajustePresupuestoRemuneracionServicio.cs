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
    public interface IReajustePresupuestoRemuneracionServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion);

        Resultado Nuevo(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idReaMenPro, string usuario, int mesDesde, int mesHasta);

        Resultado Modificar(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idReaMenPro, string usuario, int mesDesde, int mesHasta);

        Resultado Modificar(ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion);

        Resultado Anular(ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion);

        Resultado AnularPuestos(List<PuestoReajustePresupuesto> PuestoPresupuesto, string usuario);

        List<ResultadoCalculoPoco> CalcularReajustePresupuestoRemuneraciones(int idReaMenPro, int idEstPreRem, int mesDesde, int mesHasta);

        bool NuevoProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem);

        bool ModificarProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod);

        bool VerificarDatosIniciales(int idReaMenPro);

        bool MigrarDatosProgramacionReajuste(int idReaMenPro, string usuario);

        #endregion

        #region Busquedas y listados

        ReajustePresupuestoRemuneracion BuscarPorCodigo(int idReajustePresupuestoRemuneracion);

        List<ReajustePresupuestoRemuneracion> listarTodos();

        List<ReajustePresupuestoRemuneracion> TraerTodosActivos();

        List<DatosPuestoCalculo> TraerDatosPuestoCalculoReajuste(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idReaMenPro);

        List<CalculoReajustePresupuestoRemuneracion> TraerResultadoCalculoReajustePresupuestoRemuneracion(int idReaMenPro, int idEstPreRem);

        List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExporta(int idProAnu);

        List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExportaPorGrupo(string codigoGruPre, string codigosDir, int anio, int mesReajuste);

        #endregion
    }
}
