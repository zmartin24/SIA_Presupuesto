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
    public class ReajusteMensualGeneralPresentador
    {
        private readonly IReajusteMensualGeneralVista evaluacionMensualGeneralVista;

        private IReajusteMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private IPresupuestoServicio presupuestoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;

        private ReajusteMensualProgramacion ReajusteMensualProgramacion;
        private bool esModificacion;
        public ReajusteMensualGeneralPresentador(ReajusteMensualProgramacion ReajusteMensualProgramacion, IReajusteMensualGeneralVista evaluacionMensualGeneralVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.presupuestoServicio = _Contenedor.Resolver(typeof(IPresupuestoServicio)) as IPresupuestoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.evaluacionMensualGeneralVista = evaluacionMensualGeneralVista;
            this.esModificacion = ReajusteMensualProgramacion != null;
            this.ReajusteMensualProgramacion = ReajusteMensualProgramacion ?? new ReajusteMensualProgramacion();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            if(this.esModificacion)
            {
                var pres = programacionAnualServicio.BuscarPorCodigo(ReajusteMensualProgramacion.idProAnu);
                evaluacionMensualGeneralVista.anioPres = pres.anio;
                LlenarComboPresupuesto();

                evaluacionMensualGeneralVista.idPresAnu = ReajusteMensualProgramacion.idProAnu;
                evaluacionMensualGeneralVista.descripcion = ReajusteMensualProgramacion.descripcion;
                evaluacionMensualGeneralVista.mesReajuste = ReajusteMensualProgramacion.mesReajuste;
                evaluacionMensualGeneralVista.fechaEmision = ReajusteMensualProgramacion.fechaEmision;
                evaluacionMensualGeneralVista.tipoCambio = (decimal)ReajusteMensualProgramacion.tipoCambio;
            }
        }

        private void LlenarCombos()
        {
            evaluacionMensualGeneralVista.listaMesesReajustes = UtilitarioComun.ListarMeses();
            evaluacionMensualGeneralVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2017);

        }
        public void LlenarComboPresupuesto()
        {
            evaluacionMensualGeneralVista.listaProgramacionAnual = programacionAnualServicio.listarTodos(this.evaluacionMensualGeneralVista.anioPres);
        }


        public List<PresupuestoPres> listaPresupuesto()
        {
            return presupuestoServicio.TraerListaPresupuestoPres();
        }

        public List<GrupoPresupuestoPres> listaGrupoPresupuesto()
        {
            return grupoPresupuestoServicio.TraerListaGrupoPresupuestoPres();
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            ReajusteMensualProgramacion.idProAnu = evaluacionMensualGeneralVista.idPresAnu;
            ReajusteMensualProgramacion.descripcion = evaluacionMensualGeneralVista.descripcion;
            ReajusteMensualProgramacion.mesReajuste = evaluacionMensualGeneralVista.mesReajuste;
            ReajusteMensualProgramacion.fechaEmision = evaluacionMensualGeneralVista.fechaEmision;
            ReajusteMensualProgramacion.tipoCambio = evaluacionMensualGeneralVista.tipoCambio; /// cambiar

            if (this.esModificacion)
            {
                ReajusteMensualProgramacion.fechaEdita = DateTime.Now;
                ReajusteMensualProgramacion.usuEdita = evaluacionMensualGeneralVista.UsuarioOperacion.NomUsuario;
                resultado = evaluacionMensualProgramacionServicio.Modificar(ReajusteMensualProgramacion);
            }
            else
            {
                ReajusteMensualProgramacion.fechaCrea = DateTime.Now;
                ReajusteMensualProgramacion.usuCrea = evaluacionMensualGeneralVista.UsuarioOperacion.NomUsuario;
                ReajusteMensualProgramacion.estado = Estados.Activo;
                resultado = evaluacionMensualProgramacionServicio.Nuevo(ReajusteMensualProgramacion);
            }

            return resultado.esCorrecto;
        }
    }
}
