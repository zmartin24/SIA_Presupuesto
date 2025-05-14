using System;
using System.Collections.Generic;
using System.Linq;

using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;


namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ProgramacionAnualGeneralPresentador
    {
        private readonly IProgramacionAnualGeneralVista programacionAnualGeneralVista;

        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;
        private IGrupoPresupuestoServicio grupoServicio;
        private IModalidadServicio modalidadServicio;
        private IEjeOperativoServicio ejeOperativoServicio;
        private IPoaServicio poaServicio;
        private ITipoActividadServicio tipoActividadServicio;
        private IPeriodoServicio periodoServicio;

        private ProgramacionAnual ProgramacionAnual;
        private bool esModificacion;
        public ProgramacionAnualGeneralPresentador(ProgramacionAnual ProgramacionAnual, 
            IProgramacionAnualGeneralVista programacionAnualGeneralVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.fuenteServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.modalidadServicio = _Contenedor.Resolver(typeof(IModalidadServicio)) as IModalidadServicio;
            this.ejeOperativoServicio = _Contenedor.Resolver(typeof(IEjeOperativoServicio)) as IEjeOperativoServicio;
            this.poaServicio = _Contenedor.Resolver(typeof(IPoaServicio)) as IPoaServicio;
            this.tipoActividadServicio = _Contenedor.Resolver(typeof(ITipoActividadServicio)) as ITipoActividadServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;

            this.programacionAnualGeneralVista = programacionAnualGeneralVista;
            this.esModificacion = ProgramacionAnual != null;
            this.ProgramacionAnual = ProgramacionAnual ?? new ProgramacionAnual();
        }

        public void IniciarDatos()
        {
            
            
            programacionAnualGeneralVista.fechaEmision = DateTime.Now.Date;
            programacionAnualGeneralVista.anio = DateTime.Now.Date.Year;//DateTime.Now.AddYears(1).Year;

            LlenarCombos();

            programacionAnualGeneralVista.listaSedes = new List<ProgramacionSedeLaboralPoco>();
            programacionAnualGeneralVista.listaEjeOperativos = new List<ProgramacionEjeOperativoPoco>();

            

            if (this.esModificacion)
            {
                programacionAnualGeneralVista.idMoneda = ProgramacionAnual.idMoneda;
                programacionAnualGeneralVista.descripcion = ProgramacionAnual.descripcion;
                programacionAnualGeneralVista.titulo = ProgramacionAnual.titulo;
                programacionAnualGeneralVista.anio = ProgramacionAnual.anio;
                programacionAnualGeneralVista.codTipo = ProgramacionAnual.tipo;
                programacionAnualGeneralVista.fechaEmision = ProgramacionAnual.fechaEmision;
                programacionAnualGeneralVista.idGruPre = (Int32)ProgramacionAnual.idGruPre;
                programacionAnualGeneralVista.idTipoActividad = ProgramacionAnual.idTipoActividad;
                programacionAnualGeneralVista.idNroTransferencia = ProgramacionAnual.nroTransferencia;
                programacionAnualGeneralVista.idPoaVersion = ProgramacionAnual.idPoaVersion;
                programacionAnualGeneralVista.idFueFin = (Int32)ProgramacionAnual.idFueFin;
                programacionAnualGeneralVista.esSaldo = ProgramacionAnual.esSaldo;
                
                programacionAnualGeneralVista.metaHa = ProgramacionAnual.metaHa;
                programacionAnualGeneralVista.costoHa = ProgramacionAnual.costoxHa;
                programacionAnualGeneralVista.denominacion = ProgramacionAnual.denominacion;
                programacionAnualGeneralVista.observacion = ProgramacionAnual.observacion;
                programacionAnualGeneralVista.listaSedes = programacionAnualServicio.ListaProgramacionSedeLaboralPoco(ProgramacionAnual.idProAnu);
                programacionAnualGeneralVista.listaEjeOperativos = programacionAnualServicio.ListaProgramacionEjeOperativoPoco(ProgramacionAnual.idProAnu);
            }
        }

        private void LlenarCombos()
        {
            programacionAnualGeneralVista.listaMonedas = generalServicio.ListaMonedas();
            programacionAnualGeneralVista.listaTipos = PredeterminadoHelper.ListarTipoProgramacion();
            programacionAnualGeneralVista.listaFuenteFinan = fuenteServicio.TraerListaFuenteFinanciamiento(2019);//2019 Año por defecto
            programacionAnualGeneralVista.listaGrupoPresupuesto = grupoServicio.TraerListaGrupoPresupuesto();
            programacionAnualGeneralVista.listaNroTransferencia = PredeterminadoHelper.ListarNroTrandferencia();
            
            llenarComboPoa();
            programacionAnualGeneralVista.listaTipoActividad = tipoActividadServicio.ListaTodos().OrderByDescending(x => x.nombre).ToList();

            programacionAnualGeneralVista.idMoneda = 63; //Soles por defecto
            programacionAnualGeneralVista.idGruPre = 291;

            programacionAnualGeneralVista.codTipo = "NN";

            programacionAnualGeneralVista.idTipoActividad = 1;

        }
        public void llenarComboPoa()
        {
            var listaPoaVersion = poaServicio.ListaPoaVersiones(this.programacionAnualGeneralVista.anio);
            programacionAnualGeneralVista.idPoaVersion = null;
            if (listaPoaVersion != null && listaPoaVersion.Count > 0)
            {
                programacionAnualGeneralVista.listaPoa = listaPoaVersion;
            }
        }
        public int anioPeridoAcitvo()
        {
            return periodoServicio.ObtenerActivo().anio;
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            ProgramacionAnual.idMoneda = programacionAnualGeneralVista.idMoneda;
            ProgramacionAnual.descripcion = programacionAnualGeneralVista.descripcion.Trim().ToUpper();
            ProgramacionAnual.anio = programacionAnualGeneralVista.anio;
            ProgramacionAnual.fechaEmision = programacionAnualGeneralVista.fechaEmision;
            ProgramacionAnual.tipo = programacionAnualGeneralVista.codTipo;
            ProgramacionAnual.titulo = programacionAnualGeneralVista.titulo.ToUpper();
            ProgramacionAnual.idFueFin = programacionAnualGeneralVista.idFueFin;
            ProgramacionAnual.esSaldo = programacionAnualGeneralVista.esSaldo;
            ProgramacionAnual.idGruPre = programacionAnualGeneralVista.idGruPre;

            if (programacionAnualGeneralVista.codTipo.Equals("ER"))
            {
                ProgramacionAnual.idTipoActividad = programacionAnualGeneralVista.idTipoActividad;
                ProgramacionAnual.nroTransferencia = programacionAnualGeneralVista.idNroTransferencia;
                ProgramacionAnual.idPoaVersion = programacionAnualGeneralVista.idPoaVersion;
                ProgramacionAnual.costoxHa = programacionAnualGeneralVista.costoHa;
                ProgramacionAnual.metaHa = programacionAnualGeneralVista.metaHa;
                ProgramacionAnual.denominacion = programacionAnualGeneralVista.denominacion;
                ProgramacionAnual.listaEjeOperativos = programacionAnualGeneralVista.listaEjeOperativos ?? new List<ProgramacionEjeOperativoPoco>();
                ProgramacionAnual.listaSedes = programacionAnualGeneralVista.listaSedes ?? new List<ProgramacionSedeLaboralPoco>();
            }
            else
            {
                ProgramacionAnual.idModalidad = null;
                ProgramacionAnual.idTipoActividad = null;
                ProgramacionAnual.nroTransferencia = null;
                ProgramacionAnual.idPoaVersion = null;
                ProgramacionAnual.costoxHa = null;
                ProgramacionAnual.metaHa = null;
                ProgramacionAnual.denominacion = string.Empty;

                ProgramacionAnual.listaEjeOperativos = programacionAnualGeneralVista.listaEjeOperativos ?? new List<ProgramacionEjeOperativoPoco>();
                ProgramacionAnual.listaSedes = programacionAnualGeneralVista.listaSedes ?? new List<ProgramacionSedeLaboralPoco>();

                ProgramacionAnual.listaEjeOperativos.ForEach(f => f.operacion = "E");
                ProgramacionAnual.listaSedes.ForEach(f => f.operacion = "E");
            }

            ProgramacionAnual.observacion = programacionAnualGeneralVista.observacion.ToUpper();
           

            if (this.esModificacion)
            {
                ProgramacionAnual.fechaEdita = DateTime.Now;
                ProgramacionAnual.usuEdita = programacionAnualGeneralVista.UsuarioOperacion.NomUsuario;
                resultado = programacionAnualServicio.Modificar(ProgramacionAnual);
            }
            else
            {
                ProgramacionAnual.fechaCrea = DateTime.Now;
                ProgramacionAnual.usuCrea = programacionAnualGeneralVista.UsuarioOperacion.NomUsuario;
                ProgramacionAnual.estado = Estados.Activo;
                resultado = programacionAnualServicio.Nuevo(ProgramacionAnual);
            }

            return resultado.esCorrecto;
        }
    }
}
