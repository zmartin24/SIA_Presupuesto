using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class EvaluacionMensualGeneralPresentador
    {
        private readonly IEvaluacionMensualGeneralVista evaluacionMensualGeneralVista;

        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private IPresupuestoServicio presupuestoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;

        private EvaluacionMensualProgramacion EvaluacionMensualProgramacion;
        private bool esModificacion;
        public EvaluacionMensualGeneralPresentador(EvaluacionMensualProgramacion EvaluacionMensualProgramacion, IEvaluacionMensualGeneralVista evaluacionMensualGeneralVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IPresupuestoServicio)) as IPresupuestoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.evaluacionMensualGeneralVista = evaluacionMensualGeneralVista;
            this.esModificacion = EvaluacionMensualProgramacion != null;
            this.EvaluacionMensualProgramacion = EvaluacionMensualProgramacion ?? new EvaluacionMensualProgramacion();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            evaluacionMensualGeneralVista.mesDesde = 1;
            evaluacionMensualGeneralVista.fechaEmision = DateTime.Now.Date;

            if (this.esModificacion)
            {
                var pres = programacionAnualServicio.BuscarPorCodigo(EvaluacionMensualProgramacion.idProAnu);
                evaluacionMensualGeneralVista.anioPres = pres.anio;
                LlenarComboPresupuesto();
                evaluacionMensualGeneralVista.idPresAnu = EvaluacionMensualProgramacion.idProAnu;
                evaluacionMensualGeneralVista.descripcion = EvaluacionMensualProgramacion.descripcion;
                evaluacionMensualGeneralVista.mesDesde = EvaluacionMensualProgramacion.mesDesde;
                evaluacionMensualGeneralVista.mesHasta = EvaluacionMensualProgramacion.mesHasta;
                evaluacionMensualGeneralVista.fechaEmision = EvaluacionMensualProgramacion.fechaEmision;
                evaluacionMensualGeneralVista.tipoCambio = (decimal)EvaluacionMensualProgramacion.tipoCambio;
            }
        }

        private void LlenarCombos()
        {
            evaluacionMensualGeneralVista.listaMesesDesde = UtilitarioComun.ListarMeses();
            evaluacionMensualGeneralVista.listaMesesHasta = UtilitarioComun.ListarMeses();
            evaluacionMensualGeneralVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2017);
        }

        public void LlenarComboPresupuesto()
        {
            evaluacionMensualGeneralVista.listaProgramacionAnual = programacionAnualServicio.listarTodos(evaluacionMensualGeneralVista.Anio);
        }

        public List<PresupuestoPres> listaPresupuesto()
        {
            return presupuestoServicio.TraerListaPresupuestoPres();
        }

        public List<GrupoPresupuestoPres> listaGrupoPresupuesto()
        {
            return grupoPresupuestoServicio.TraerListaGrupoPresupuestoPres();
        }

        public bool GuardarDatos(List<EvaluacionPresupuestoPoco> lista)
        {
            Resultado resultado = null;

            EvaluacionMensualProgramacion.idProAnu = evaluacionMensualGeneralVista.idPresAnu;
            EvaluacionMensualProgramacion.descripcion = evaluacionMensualGeneralVista.descripcion;
            EvaluacionMensualProgramacion.mesDesde = evaluacionMensualGeneralVista.mesDesde;
            EvaluacionMensualProgramacion.mesHasta = evaluacionMensualGeneralVista.mesHasta;
            EvaluacionMensualProgramacion.fechaEmision = evaluacionMensualGeneralVista.fechaEmision;
            EvaluacionMensualProgramacion.tipoCambio = evaluacionMensualGeneralVista.tipoCambio; /// cambiar
            EvaluacionMensualProgramacion.listaPresupuestos = lista;

            if (this.esModificacion)
            {
                EvaluacionMensualProgramacion.fechaEdita = DateTime.Now;
                EvaluacionMensualProgramacion.usuEdita = evaluacionMensualGeneralVista.UsuarioOperacion.NomUsuario;
                resultado = evaluacionMensualProgramacionServicio.Modificar(EvaluacionMensualProgramacion);
            }
            else
            {
                EvaluacionMensualProgramacion.fechaCrea = DateTime.Now;
                EvaluacionMensualProgramacion.usuCrea = evaluacionMensualGeneralVista.UsuarioOperacion.NomUsuario;
                EvaluacionMensualProgramacion.estado = Estados.Activo;
                resultado = evaluacionMensualProgramacionServicio.Nuevo(EvaluacionMensualProgramacion);
            }

            return resultado.esCorrecto;
        }


        public bool GuardarDatos()
        {
            Resultado resultado = null;

            EvaluacionMensualProgramacion.idProAnu = evaluacionMensualGeneralVista.idPresAnu;
            EvaluacionMensualProgramacion.descripcion = evaluacionMensualGeneralVista.descripcion;
            EvaluacionMensualProgramacion.mesDesde = evaluacionMensualGeneralVista.mesDesde;
            EvaluacionMensualProgramacion.mesHasta = evaluacionMensualGeneralVista.mesHasta;
            EvaluacionMensualProgramacion.fechaEmision = evaluacionMensualGeneralVista.fechaEmision;
            EvaluacionMensualProgramacion.tipoCambio = evaluacionMensualGeneralVista.tipoCambio; /// cambiar
            //EvaluacionMensualProgramacion.listaPresupuestos = lista;

            if (this.esModificacion)
            {
                EvaluacionMensualProgramacion.fechaEdita = DateTime.Now;
                EvaluacionMensualProgramacion.usuEdita = evaluacionMensualGeneralVista.UsuarioOperacion.NomUsuario;
                resultado = evaluacionMensualProgramacionServicio.Modificar(EvaluacionMensualProgramacion);
            }
            else
            {
                EvaluacionMensualProgramacion.fechaCrea = DateTime.Now;
                EvaluacionMensualProgramacion.usuCrea = evaluacionMensualGeneralVista.UsuarioOperacion.NomUsuario;
                EvaluacionMensualProgramacion.estado = Estados.Activo;
                resultado = evaluacionMensualProgramacionServicio.Nuevo(EvaluacionMensualProgramacion);
            }

            return resultado.esCorrecto;
        }
    }
}
