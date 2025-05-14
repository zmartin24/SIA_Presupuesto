using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IReajustePresupuestoRemuneracionRepositorio : IRepositorio<ReajustePresupuestoRemuneracion>
    {
        List<DatosPuestoCalculo> TraerDatosPuestoCalculoReajuste(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idReaMenPro);

        List<CalculoReajustePresupuestoRemuneracion> TraerResultadoCalculoReajustePresupuestoRemuneracion(int idReaMenPro, int idEstPreRem);

        bool MigrarDatosProgramacionReajuste(int idReaMenPro, string usuario);

        bool AnularPuestoReajusteRemuneracion(string codigo, string usuario);

        bool NuevoReajusteProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem);

        bool NuevoReajusteProgramacionDetalle(int idPuePre, int estado, DateTime fechaCrea, string usuCrea);

        bool ModificarReajusteProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod);

        bool VerificarDatosIniciales(int idReaMenPro);

        bool AnularReajusteProgramacionDetalle(int idReaPreRemDet, DateTime fechaMod, string usuMod);

        bool AnularReajusteProgramacionRemuneracion(int idReaPreRem, string usuMod);

        List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExporta(int idProAnu);

        List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExportaPorGrupo(string codigoGruPre, string codigosDir, int anio, int mesReajuste);

    }
}
