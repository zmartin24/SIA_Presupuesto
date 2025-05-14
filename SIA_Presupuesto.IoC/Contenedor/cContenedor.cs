using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.Unity;
using Seguridad.Servicio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Servicios;
using SIA_Presupuesto.Datos;
using Seguridad.Modelo;
using Seguridad.Datos.Infraestructura;
using SIA_Presupuesto.Datos.Repositorio;
using Unity;
using Unity.Lifetime;
using Unity.Injection;

namespace SIA_Presupuesto.IoC.Contenedor
{

    public class cContenedor : IContenedor
    {
        #region Miembros

        IDictionary<string, IUnityContainer> _DiccionarioContenedores;

        #endregion

        #region Constructor

        public cContenedor(IUnityContainer ContenedorRaiz)
        {
            _DiccionarioContenedores = new Dictionary<string, IUnityContainer>();

            //Crear contenedor raiz
            //IUnityContainer ContenedorRaiz = ContenedorRaiz;// new UnityContainer();
            _DiccionarioContenedores.Add("ContextoRaiz", ContenedorRaiz);

            //Crear contenedor para contexto real, hijo de contenedor raiz
            //IUnityContainer realContenedor = ContenedorRaiz.CreateChildContainer();
            //_DiccionarioContenedores.Add("RealContenedor", realContenedor);

            ////Crear contenedor para testeo, hijo de contenedor raiz
            //IUnityContainer FalsoContenedor = ContenedorRaiz.CreateChildContainer();
            //_DiccionarioContenedores.Add("FalsoContenedor", FalsoContenedor);


            ConfiguracionContenedorRaiz(ContenedorRaiz);
            ConfiguracionContedorServidor(ContenedorRaiz);
            ConfiguracionContenedorCliente(ContenedorRaiz);
        }

        public cContenedor()
        {
            _DiccionarioContenedores = new Dictionary<string, IUnityContainer>();

            //Crear contenedor raiz
            IUnityContainer ContenedorRaiz = new UnityContainer();
            _DiccionarioContenedores.Add("ContextoRaiz", ContenedorRaiz);

            IUnityContainer ContenedorServidor = ContenedorRaiz.CreateChildContainer();
            _DiccionarioContenedores.Add("ContenedorServidor", ContenedorServidor);

            IUnityContainer ContenedorCliente = ContenedorRaiz.CreateChildContainer();
            _DiccionarioContenedores.Add("ContenedorCliente", ContenedorCliente);

            ConfiguracionContenedorRaiz(ContenedorRaiz);
            ConfiguracionContedorServidor(ContenedorServidor);
            ConfiguracionContenedorCliente(ContenedorCliente);
        }

        #endregion

        private void ConfiguracionContenedorRaiz(IUnityContainer contenedor)
        {
            //Registro de mapa para los repositorios
            contenedor.RegisterType<IGrupoPresupuestoRepositorio, GrupoPresupuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoRepositorio, PresupuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ISubpresupuestoRepositorio, SubpresupuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualRepositorio, ProgramacionAnualRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGeneralRepositorio, GeneralRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualAreaRepositorio, ProgramacionAnualAreaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualDetalleRepositorio, ProgramacionAnualDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualAreaRepositorio, EvaluacionMensualAreaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualDetalleRepositorio, EvaluacionMensualDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualProgramacionRepositorio, EvaluacionMensualProgramacionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoCambioPresupuestoRepositorio, TipoCambioPresupuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoBienServicioDetalleRepositorio, RequerimientoBienServicioDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoBienServicioRepositorio, RequerimientoBienServicioRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoBienServicioDetalleMesRepositorio, RequerimientoBienServicioDetalleMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualDetalleMesRepositorio, ProgramacionAnualDetalleMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualAreaMesRepositorio, ProgramacionAnualAreaMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualAreaMesRepositorio, EvaluacionMensualAreaMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualDetalleMesRepositorio, EvaluacionMensualDetalleMesRepositorio>(new TransientLifetimeManager());

            contenedor.RegisterType<IPlanAnualAdquisicionRepositorio, PlanAnualAdquisicionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPlanAnualAdquisicionRequerimientoRepositorio, PlanAnualAdquisicionRequerimientoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPlanAnualAdquisicionDetalleRepositorio, PlanAnualAdquisicionDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPlanAnualAdquisicionDetalleMesRepositorio, PlanAnualAdquisicionDetalleMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IConfiguracionPAARepositorio, ConfiguracionPAARepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IFuenteFinanciamientoRepositorio, FuenteFinanciamientoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IUbigeoRepositorio, UbigeoRepositorio>(new TransientLifetimeManager());

            contenedor.RegisterType<IRubroBienServicioCuentaRepositorio, RubroBienServicioCuentaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRubroBienServicioRepositorio, RubroBienServicioRepositorio>(new TransientLifetimeManager());

            contenedor.RegisterType<IGastoRecurrenteRepositorio, GastoRecurrenteRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGastoRecurrenteRequerimientoRepositorio, GastoRecurrenteRequerimientoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGastoRecurrenteDetalleRepositorio, GastoRecurrenteDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGastoRecurrenteDetalleMesRepositorio, GastoRecurrenteDetalleMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualProgramacionPresRepositorio, EvaluacionMensualProgramacionPresRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGeneralReporteRepositorio, GeneralReporteRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoReporteRepositorio, TipoReporteRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRubroBienServicioCuentaRepositorio, RubroBienServicioCuentaRepositorio>(new TransientLifetimeManager());

            contenedor.RegisterType<IReajusteMensualDetalleMesRepositorio, ReajusteMensualDetalleMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajusteMensualDetalleRepositorio, ReajusteMensualDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajusteMensualAreaMesRepositorio, ReajusteMensualAreaMesRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajusteMensualProgramacionAreaRepositorio, ReajusteMensualProgramacionAreaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajusteMensualAreaRepositorio, ReajusteMensualAreaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajusteMensualProgramacionRepositorio, ReajusteMensualProgramacionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoRecepcionadoRepositorio, PresupuestoRecepcionadoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ICertificacionRequerimientoRepositorio, CertificacionRequerimientoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ICertificacionDetalleRepositorio, CertificacionDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IModalidadRepositorio, ModalidadRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEjeOperativoRepositorio, EjeOperativoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualSedeRepositorio, ProgramacionAnualSedeRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualEjeOperativoRepositorio, ProgramacionAnualEjeOperativoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IFuenteFinanciamientoRepositorio, FuenteFinanciamientoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionPresupuestoCuentaRepositorio, EvaluacionPresupuestoCuentaRepositorio>(new TransientLifetimeManager());

            contenedor.RegisterType<IPeriodoRepositorio,PeriodoRepositorio> (new TransientLifetimeManager());

            contenedor.RegisterType<IConceptoPresupuestoRemuneracionRepositorio, ConceptoPresupuestoRemuneracionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEstructuraPresupuestoRemuneracionRepositorio, EstructuraPresupuestoRemuneracionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IParametroPresupuestoRemuneracionRepositorio, ParametroPresupuestoRemuneracionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoRemuneracionDetRepositorio, PresupuestoRemuneracionDetRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoRemuneracionRepositorio, PresupuestoRemuneracionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPropiedadPresupuestoRemuneracionRepositorio, PropiedadPresupuestoRemuneracionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPuestoPresupuestoRepositorio, PuestoPresupuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajustePresupuestoRemuneracionDetRepositorio, ReajustePresupuestoRemuneracionDetRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajustePresupuestoRemuneracionRepositorio, ReajustePresupuestoRemuneracionRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IOrigenConceptoRepositorio, OrigenConceptoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IConceptoCuentaContableRepositorio, ConceptoCuentaContableRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPuestoReajustePresupuestoRepositorio, PuestoReajustePresupuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoCambioAnualRepositorio, TipoCambioAnualRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ICertificacionMasterRepositorio, CertificacionMasterRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoRecursoHumanoRepositorio, RequerimientoRecursoHumanoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPuestoRequerimientoRepositorio, PuestoRequerimientoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPartidaPresupuestalRepositorio, PartidaPresupuestalRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPartidaPresupuestalCuentaRepositorio, PartidaPresupuestalCuentaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoMensualBienServicioRepositorio, RequerimientoMensualBienServicioRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoMensualDetalleRepositorio, RequerimientoMensualDetalleRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ICertificacionRequerimientoSubprespuestoRepositorio, CertificacionRequerimientoSubprespuestoRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPoaRepositorio, PoaRepositorio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoActividadRepositorio, TipoActividadRepositorio>(new TransientLifetimeManager());


            //Servicios de la aplicacion
            contenedor.RegisterType<IGrupoPresupuestoServicio, GrupoPresupuestoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoServicio, PresupuestoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<ISubpresupuestoServicio, SubpresupuestoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IProgramacionAnualServicio, ProgramacionAnualServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGeneralServicio, GeneralServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionMensualProgramacionServicio, EvaluacionMensualProgramacionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoCambioPresupuestoServicio, TipoCambioPresupuestoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoBienServicioServicio, RequerimientoBienServicioServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<IPlanAnualAdquisicionServicio, PlanAnualAdquisicionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IConfiguracionPAAServicio, ConfiguracionPAAServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IFuenteFinanciamientoServicio, FuenteFinanciamientoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IUbigeoServicio, UbigeoServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<IGastoRecurrenteServicio, GastoRecurrenteServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoRecepcionadoServicio, PresupuestoRecepcionadoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IGeneralReporteServicio, GeneralReporteServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<ITipoReporteServicio, TipoReporteServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajusteMensualProgramacionServicio, ReajusteMensualProgramacionServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<IRubroBienServicio, RubroBienServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRubroBienServicioCuentaServicio, RubroBienServicioCuentaServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<ICertificacionRequerimientoServicio, CertificacionRequerimientoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IModalidadServicio, ModalidadServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEjeOperativoServicio, EjeOperativoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IFuenteFinanciamientoServicio, FuenteFinanciamientoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEvaluacionPresupuestoCuentaServicio, EvaluacionPresupuestoCuentaServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<IConceptoPresupuestoRemuneracionServicio, ConceptoPresupuestoRemuneracionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IEstructuraPresupuestoRemuneracionServicio, EstructuraPresupuestoRemuneracionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IParametroPresupuestoRemuneracionServicio, ParametroPresupuestoRemuneracionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPresupuestoRemuneracionServicio, PresupuestoRemuneracionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPuestoPresupuestoServicio, PuestoPresupuestoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IReajustePresupuestoRemuneracionServicio, ReajustePresupuestoRemuneracionServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IOrigenConceptoServicio, OrigenConceptoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IConceptoCuentaContableServicio, ConceptoCuentaContableServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPuestoReajustePresupuestoServicio, PuestoReajustePresupuestoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoCambioAnualServicio, TipoCambioAnualServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<ICertificacionMasterServicio, CertificacionMasterServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoRecursoHumanoServicio, RequerimientoRecursoHumanoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPuestoRequerimientoServicio, PuestoRequerimientoServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPartidaPresupuestalServicio, PartidaPresupuestalServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IRequerimientoMensualBienServicioServicio, RequerimientoMensualBienServicioServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<IPoaServicio, PoaServicio>(new TransientLifetimeManager());
            contenedor.RegisterType<ITipoActividadServicio, TipoActividadServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<IPeriodoServicio, PeriodoServicio>(new TransientLifetimeManager());
            //Administrador
            contenedor.RegisterType<UsuarioServicio, UsuarioServicio>(new TransientLifetimeManager());

            //Registro de la capa transversal
            contenedor.RegisterType<Seguridad.Log.IOcurrencia, LogSistemaServicio>(new TransientLifetimeManager());

            contenedor.RegisterType<IContexto, SIACORAHEntities>(new AdministracionTiempoVidaPorEjecucionContexto(), new InjectionConstructor());
            contenedor.RegisterType<FabricaBaseDatos, FabricaBaseDatos>(new AdministracionTiempoVidaPorEjecucionContexto(), new InjectionConstructor());
        }

        private void ConfiguracionContedorServidor(IUnityContainer contenedor)
        {
            //contenedor.RegisterType<IContextoBase, ContextoBase>(new TransientLifetimeManager());
            //contenedor.RegisterType<IContexto, SIACORAHEntities>(new AdministracionTiempoVidaPorEjecucionContexto(), new InjectionConstructor());
            //contenedor.RegisterType<IContexto, SIACORAHEntities>(new TransientLifetimeManager());
            //contenedor.RegisterType<IFabricaBaseDatos, FabricaBaseDatos>(new AdministracionTiempoVidaPorEjecucionContexto(), new InjectionConstructor());
        }

        private void ConfiguracionContenedorCliente(IUnityContainer contenedor)
        {
            //contenedor.RegisterType<IContexto, SIACORAHLOCALEntities>(new AdministracionTiempoVidaPorEjecucionContexto(), new InjectionConstructor());
            //contenedor.RegisterType<IFabricaBaseDatos, FabricaBaseDatos>(new AdministracionTiempoVidaPorEjecucionContexto(), new InjectionConstructor());
        }

        #region Miembros IFabricaServicios

        public TServicio Resolver<TServicio>()
        {
            //Nosotros usamos el contenedor predeterminado especificado en el AppSettings
            string NombreContenedor = ConfigurationManager.AppSettings["PredeterminadoContenedorIoC"];

            if (String.IsNullOrEmpty(NombreContenedor) || String.IsNullOrWhiteSpace(NombreContenedor))
            {
                throw new ArgumentNullException();
            }

            if (!_DiccionarioContenedores.ContainsKey(NombreContenedor))
                throw new InvalidOperationException();

            IUnityContainer contenedor = _DiccionarioContenedores[NombreContenedor];

            return contenedor.Resolve<TServicio>();
        }

        public object Resolver(Type tipo)
        {
            //Nosotros usamos el contenedor predeterminado especificado en el AppSettings
            string NombreContenedor = ConfigurationManager.AppSettings["PredeterminadoContenedorIoC"];

            if (String.IsNullOrEmpty(NombreContenedor) || String.IsNullOrWhiteSpace(NombreContenedor))
            {
                throw new ArgumentNullException();
            }

            if (!_DiccionarioContenedores.ContainsKey(NombreContenedor))
                throw new InvalidOperationException();

            IUnityContainer contenedor = _DiccionarioContenedores[NombreContenedor];

            return contenedor.Resolve(tipo, null);
        }

        public void RegistrarTipo(Type tipo)
        {
            IUnityContainer contenedor = this._DiccionarioContenedores["ContextoRaiz"];

            if (contenedor != null)
                contenedor.RegisterType(tipo, new TransientLifetimeManager());
        }

        public IUnityContainer EntregarContenedor()
        {
            IUnityContainer contenedor = this._DiccionarioContenedores["ContextoRaiz"];
            return contenedor;
        }

        #endregion

    }
}
