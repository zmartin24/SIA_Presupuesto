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
    public class PresupuestoRemuneracionRepositorio : Repositorio<PresupuestoRemuneracion>, IPresupuestoRemuneracionRepositorio
    {
        public PresupuestoRemuneracionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<DatosPuestoCalculo> TraerDatosPuestoCalculo(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idProAnu)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<DatosPuestoCalculo> lista = new List<DatosPuestoCalculo>();

            lista = contexto.TraerDatosPuestoCalculo(idGruPre, idPresupuesto, idDireccion, idSubdireccion, condicion, idProAnu).ToList();

            return lista;
        }

        public List<DatoCalculoPresupuestoRemuneracion> TraerDatosCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<DatoCalculoPresupuestoRemuneracion> lista = new List<DatoCalculoPresupuestoRemuneracion>();

            lista = contexto.TraerDatosCalculoPresupuestoRemuneracion(idProAnu, idEstPreRem).ToList();

            return lista;
        }

        public List<CalculoPresupuestoRemuneracion> TraerResultadoCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<CalculoPresupuestoRemuneracion> lista = new List<CalculoPresupuestoRemuneracion>();

            lista = contexto.TraerResultadoCalculoPresupuestoRemuneracion(idProAnu, idEstPreRem).ToList();

            return lista;
        }

        public bool AnularPuesto(string codigo, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.AnularPuestoRemuneracion(codigo, usuario);

            return true;
        }

        public bool NuevoProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.CrearProgramacionDetalle(idPreRem, estado, importe, mes, fechaCrea, usuCrea, idProPreRem);

            return true;
        }

        public bool NuevoProgramacionRemuneracion(int idPuePre, int estado, DateTime fechaCrea, string usuCrea)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.CrearProgramacionRemuneracion(idPuePre, estado, fechaCrea, usuCrea);

            return true;
        }

        public bool ModificarProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.ModificarProgramacionDetalle(idPreRemDet, importe, fechaMod, usuMod);

            return true;
        }


        public bool AnularProgramacionRemuneracion(int idPreRem, string usuMod)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.AnularProgramacionRemuneracion(idPreRem, usuMod);

            return true;
        }

        public bool AnularProgramacionRemuneracion(int idPreRemDet, DateTime fechaMod, string usuMod)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            contexto.AnularProgramacionDetalle(idPreRemDet, fechaMod, usuMod);

            return true;
        }

        public List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(int idProAnu)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<PresupuestoRemuneracionExporta> lista = new List<PresupuestoRemuneracionExporta>();

            lista = contexto.PresupuestoRemuneracionExporta(idProAnu).ToList();

            return lista;
        }

        public List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(string codigoGruPre, string codigosDir, int anio)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            List<PresupuestoRemuneracionExporta> lista = new List<PresupuestoRemuneracionExporta>();

            lista = contexto.PresupuestoRemuneracionExportaPorGrupo(codigoGruPre, codigosDir, anio).ToList();

            return lista;
        }

    }
}
