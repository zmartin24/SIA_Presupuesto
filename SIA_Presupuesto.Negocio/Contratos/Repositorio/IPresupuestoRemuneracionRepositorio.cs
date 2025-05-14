using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPresupuestoRemuneracionRepositorio : IRepositorio<PresupuestoRemuneracion>
    {
        List<DatosPuestoCalculo> TraerDatosPuestoCalculo(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idProAnu);

        List<DatoCalculoPresupuestoRemuneracion> TraerDatosCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem);

        List<CalculoPresupuestoRemuneracion> TraerResultadoCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem);

        bool AnularPuesto(string codigo, string usuario);

        bool NuevoProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem);

        bool NuevoProgramacionRemuneracion(int idPuePre, int estado, DateTime fechaCrea, string usuCrea);

        bool ModificarProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod);

        bool AnularProgramacionRemuneracion(int idPreRem, string usuMod);

        bool AnularProgramacionRemuneracion(int idPreRemDet, DateTime fechaMod, string usuMod);

        List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(int idProAnu);

        List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(string codigoGruPre, string codigosDir, int anio);

    }
}
