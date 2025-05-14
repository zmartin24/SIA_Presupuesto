using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ReajustePresupuestoRemuneracionRepositorio : Repositorio<ReajustePresupuestoRemuneracion>, IReajustePresupuestoRemuneracionRepositorio
    {
        public ReajustePresupuestoRemuneracionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<DatosPuestoCalculo> TraerDatosPuestoCalculoReajuste(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idReaMenPro)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<DatosPuestoCalculo> lista = new List<DatosPuestoCalculo>();

            lista = contexto.TraerDatosPuestoCalculoReajuste(idGruPre, idPresupuesto, idDireccion, idSubdireccion, condicion, idReaMenPro).ToList();

            return lista;
        }

        public List<CalculoReajustePresupuestoRemuneracion> TraerResultadoCalculoReajustePresupuestoRemuneracion(int idReaMenPro, int idEstPreRem)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<CalculoReajustePresupuestoRemuneracion> lista = new List<CalculoReajustePresupuestoRemuneracion>();

            lista = contexto.TraerResultadoCalculoReajustePresupuestoRemuneracion(idReaMenPro, idEstPreRem).ToList();

            return lista;
        }

        public bool MigrarDatosProgramacionReajuste(int idReaMenPro, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.MigrarDatosProgramacionReajuste(idReaMenPro, usuario);

            return true;
        }


        public bool AnularPuestoReajusteRemuneracion(string codigo, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.AnularPuestoReajusteRemuneracion(codigo, usuario);

            return true;
        }

        public bool NuevoReajusteProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.CrearReajusteProgramacionDetalle(idPreRem, estado, importe, mes, fechaCrea, usuCrea, idProPreRem);

            return true;
        }

        public bool NuevoReajusteProgramacionDetalle(int idPuePre, int estado, DateTime fechaCrea, string usuCrea)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.CrearProgramacionRemuneracion(idPuePre, estado, fechaCrea, usuCrea);

            return true;
        }

        public bool ModificarReajusteProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.ModificarReajusteProgramacionDetalle(idPreRemDet, importe, fechaMod, usuMod);

            return true;
        }

        public bool AnularReajusteProgramacionDetalle(int idReaPreRemDet, DateTime fechaMod, string usuMod)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.AnularReajusteProgramacionDetalle(idReaPreRemDet, fechaMod, usuMod);

            return true;
        }

        public bool AnularReajusteProgramacionRemuneracion(int idReaPreRem, string usuMod)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.AnularReajusteProgramacionRemuneracion(idReaPreRem, usuMod);

            return true;
        }

        public bool VerificarDatosIniciales(int idReaMenPro)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.PuestoReajustePresupuesto.Any(a => a.estado != 1 && a.idReaMenPro == idReaMenPro);
        }

        public List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExporta(int idProAnu)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<PresupuestoRemuneracionExporta> lista = new List<PresupuestoRemuneracionExporta>();

            lista = contexto.ReajustePresupuestoRemuneracionExporta(idProAnu).ToList();

            return lista;
        }

        public List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExportaPorGrupo(string codigoGruPre, string codigosDir, int anio, int mesReajuste)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<PresupuestoRemuneracionExporta> lista = new List<PresupuestoRemuneracionExporta>();

            lista = contexto.ReajustePresupuestoRemuneracionExportaPorGrupo(codigoGruPre, codigosDir, anio, mesReajuste).ToList();

            return lista;
        }

    }
}
