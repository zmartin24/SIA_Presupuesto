using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class BuscarRequerimientoPresentador
    {
        private readonly IBuscarRequerimientoVista buscarRequerimientoVista;

        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;

        private IConfiguracionPAAServicio configuracionPAAServicio;
        private IFuenteFinanciamientoServicio fuenteFinanciamientoServicio;
        private IUbigeoServicio ubigeoServicio;

        private PlanAnualAdquisicion planAnualAdquisicion;
        private GastoRecurrente gastoRecurrente;

        private PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle;

        private UbigeoPoco ubigeoPoco;
        private PlanAnualAdquisicionDetallePoco planAnualAdquisicionDetallePoco;

        private int vtipoRubro = 0;
        private int vanio = 0;// DateTime.Now.Year;
        public BuscarRequerimientoPresentador(PlanAnualAdquisicion planAnualAdquisicion, IBuscarRequerimientoVista buscarRequerimientoVista, int vtipoRubro)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.configuracionPAAServicio = _Contenedor.Resolver(typeof(IConfiguracionPAAServicio)) as IConfiguracionPAAServicio;
            this.fuenteFinanciamientoServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.ubigeoServicio = _Contenedor.Resolver(typeof(IUbigeoServicio)) as IUbigeoServicio;

            this.buscarRequerimientoVista = buscarRequerimientoVista;
            this.planAnualAdquisicion = planAnualAdquisicion ?? new PlanAnualAdquisicion();
            this.planAnualAdquisicionDetalle = planAnualAdquisicionDetalle ?? new PlanAnualAdquisicionDetalle();
            this.vtipoRubro = vtipoRubro;
            vanio = this.planAnualAdquisicion != null ? this.planAnualAdquisicion.anio : (int)this.generalServicio.ListaPlanCuenta().OrderByDescending(x => x.anioEjercicio).FirstOrDefault().anioEjercicio;
        }
        public BuscarRequerimientoPresentador(GastoRecurrente gastoRecurrente, IBuscarRequerimientoVista buscarRequerimientoVista, int vtipoRubro)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;

            this.buscarRequerimientoVista = buscarRequerimientoVista;
            this.gastoRecurrente = gastoRecurrente ?? new GastoRecurrente();
            this.vtipoRubro = vtipoRubro;
            vanio = this.gastoRecurrente != null ? (int)this.gastoRecurrente.anio : (int)this.generalServicio.ListaPlanCuenta().OrderByDescending(x => x.anioEjercicio).FirstOrDefault().anioEjercicio;
        }

        public void IniciarDatos()
        {
            //vanio = this.generalServicio.ListaPlanCuenta() != null ? (int)this.generalServicio.ListaPlanCuenta().OrderByDescending(x => x.anioEjercicio).FirstOrDefault().anioEjercicio : vanio;
            LlenarCombos();
            if (this.planAnualAdquisicion != null) LlenarCombosPaa();
        }

        private void LlenarCombos()
        {
            var listaCuentaN1 = generalServicio.ListaCuentaContableN1(vanio, vtipoRubro);
            if (listaCuentaN1 != null)
            {
                buscarRequerimientoVista.listaCuentaN1 = listaCuentaN1;
                if (listaCuentaN1.Count > 0)
                    buscarRequerimientoVista.idCueConN1 = listaCuentaN1.First().idCueCon;
            }
        }
        private void LlenarCombosPaa()
        {
            planAnualAdquisicionDetalle.tipComSel = planAnualAdquisicionDetalle.tipComSel == null ? 0 : planAnualAdquisicionDetalle.tipComSel;
            planAnualAdquisicionDetalle.TipPro = planAnualAdquisicionDetalle.TipPro == null ? 0 : planAnualAdquisicionDetalle.TipPro;
            planAnualAdquisicionDetalle.objCon = planAnualAdquisicionDetalle.objCon == null ? 0 : planAnualAdquisicionDetalle.objCon;
            planAnualAdquisicionDetalle.idFueFin = planAnualAdquisicionDetalle.idFueFin == null ? 0 : planAnualAdquisicionDetalle.idFueFin;
            planAnualAdquisicionDetalle.organoEncargado = planAnualAdquisicionDetalle.organoEncargado == null ? 0 : planAnualAdquisicionDetalle.organoEncargado;
            planAnualAdquisicionDetalle.idTipMon = planAnualAdquisicionDetalle.idTipMon == null ? 0 : planAnualAdquisicionDetalle.idTipMon;
            planAnualAdquisicionDetalle.idUbigeo = planAnualAdquisicionDetalle.idUbigeo == null ? 0 : planAnualAdquisicionDetalle.idUbigeo;
            
            planAnualAdquisicionDetalle.fechaPre = planAnualAdquisicionDetalle.fechaPre == null ? 0 : planAnualAdquisicionDetalle.fechaPre;

            if (planAnualAdquisicionDetalle.idUbigeo > 0)
            {
                ubigeoPoco = ubigeoServicio.TraerUbigeoPocoIdDistrito(Convert.ToInt32(planAnualAdquisicionDetalle.idUbigeo));
            }

            // combo tipo compra
            var listaTipCompra = configuracionPAAServicio.TraerListaConfiguracionPAA(1);
            if (listaTipCompra != null)
            {
                buscarRequerimientoVista.listaTipoCompra = listaTipCompra;
                if (listaTipCompra.Count > 0)
                    buscarRequerimientoVista.tipComSel = planAnualAdquisicionDetalle.tipComSel == 0 ? (Int32)listaTipCompra.First().codigo : (Int32)planAnualAdquisicionDetalle.tipComSel;
            }

            // combo tipo proceso
            var listaTipProceso = configuracionPAAServicio.TraerListaConfiguracionPAA(2);
            if (listaTipProceso != null)
            {
                buscarRequerimientoVista.listaTipoProceso = listaTipProceso;
                if (listaTipProceso.Count > 0)
                    buscarRequerimientoVista.TipPro = planAnualAdquisicionDetalle.TipPro == 0 ? (Int32)listaTipProceso.First().codigo : (Int32)planAnualAdquisicionDetalle.TipPro;
            }

            // combo objeto proceso
            var listaObjetoProceso = configuracionPAAServicio.TraerListaConfiguracionPAA(3);
            if (listaObjetoProceso != null)
            {
                buscarRequerimientoVista.listaObjetoProceso = listaObjetoProceso;
                if (listaObjetoProceso.Count > 0)
                    buscarRequerimientoVista.objCon = planAnualAdquisicionDetalle.objCon == 0 ? (Int32)listaObjetoProceso.First().codigo : (Int32)planAnualAdquisicionDetalle.objCon;
            }
            // combo Encargado
            var listaEncargado = configuracionPAAServicio.TraerListaConfiguracionPAA(4);
            if (listaEncargado != null)
            {
                buscarRequerimientoVista.listaEncargado = listaEncargado;
                if (listaEncargado.Count > 0)
                    buscarRequerimientoVista.organoEncargado = planAnualAdquisicionDetalle.organoEncargado == 0 ? (Int32)listaEncargado.First().codigo : (Int32)planAnualAdquisicionDetalle.organoEncargado;
            }

            // combo fuente financiamiento
            var listaFuenteFina = fuenteFinanciamientoServicio.TraerTodosActivos();
            if (listaFuenteFina != null)
            {
                buscarRequerimientoVista.listaFuenteFinanciamiento = listaFuenteFina;
                if (listaFuenteFina.Count > 0)
                    buscarRequerimientoVista.idFueFin = planAnualAdquisicionDetalle.idFueFin == 0 ? listaFuenteFina.First().idFueFin : (Int32)planAnualAdquisicionDetalle.idFueFin;
            }


            // combo región
            var listaRegion = ubigeoServicio.TraerListaRegion();
            if (listaRegion != null)
            {
                buscarRequerimientoVista.listaRegion = listaRegion;
                if (listaRegion.Count > 0)
                    buscarRequerimientoVista.idRegion = planAnualAdquisicionDetalle.idUbigeo == 0 ? listaRegion.Where(x => x.codSunat == "25").FirstOrDefault().idUbigeo : ubigeoPoco.idRegion;  //listaRegion.First().idUbigeo;
            }

            
            // combo fecha prevista
            var listaMesPrevisto = configuracionPAAServicio.TraerListaConfiguracionPAA(5);
            if (listaMesPrevisto != null)
            {
                buscarRequerimientoVista.listaMesPrevisto = listaMesPrevisto;
                if (listaMesPrevisto.Count > 0)
                    buscarRequerimientoVista.fechaPrevista = planAnualAdquisicionDetalle.fechaPre == 0 ? (Int32)listaMesPrevisto.First().codigo : (Int32)planAnualAdquisicionDetalle.fechaPre;
            }
        }

        public void LlenarCombosCuentasN2(int anio,int idCuenta)
        {
            var listaCuentaN2 = generalServicio.ListaCuentaContableN2(vanio, idCuenta, vtipoRubro);
            if (listaCuentaN2 != null)
            {
                buscarRequerimientoVista.listaCuentaN2 = listaCuentaN2;
                if (listaCuentaN2.Count > 0)
                    buscarRequerimientoVista.idCueConN2 = listaCuentaN2.First().idCueCon;
            }
        }

        public void LlenarCombosCuentasN3(int anio, int idCuenta)
        {
            var listaCuentaN3 = generalServicio.ListaCuentaContableN3(anio, idCuenta, vtipoRubro);
            if (listaCuentaN3 != null)
            {
                buscarRequerimientoVista.listaCuentaN3 = listaCuentaN3;
                if (listaCuentaN3.Count > 0)
                    buscarRequerimientoVista.idCueConN3 = listaCuentaN3.First().idCueCon;
            }
        }
        public void LlenarGrid(int anio, int idCuenta)
        {
            if (idCuenta > 0 && planAnualAdquisicion != null)
                buscarRequerimientoVista.listaDatosPrincipales = planAnualAdquisicionServicio.TraerListaRequerimientoBienServicioPendientePorCuenta(idCuenta, anio, 2);
            else if (idCuenta > 0 && gastoRecurrente != null)
                buscarRequerimientoVista.listaDatosPrincipales = gastoRecurrenteServicio.TraerListaRequerimientoBienServicioPendientePorCuenta(idCuenta, anio, 1);
        }
        public bool RegistrarDetalles()
        {
            Resultado respuesta = null;
            planAnualAdquisicion.usuCrea = buscarRequerimientoVista.UsuarioOperacion.NomUsuario;
            planAnualAdquisicionDetallePoco = new PlanAnualAdquisicionDetallePoco
            {
                tipComSel = buscarRequerimientoVista.tipComSel,
                TipPro = buscarRequerimientoVista.TipPro,
                objCon = buscarRequerimientoVista.objCon,
                organoEncargado = buscarRequerimientoVista.organoEncargado,
                idFueFin = buscarRequerimientoVista.idFueFin,
                fechaPre = buscarRequerimientoVista.fechaPrevista,
                idUbigeo = buscarRequerimientoVista.idUbigeo
                
            };
            respuesta = planAnualAdquisicionServicio.NuevoDetalleMasivoPorCuentas(planAnualAdquisicion, buscarRequerimientoVista.listaSeleccionada, planAnualAdquisicionDetallePoco);

            return respuesta.esCorrecto;
        }
        public bool RegistrarDetallesGastoRecurrente()
        {
            Resultado respuesta = null;
            gastoRecurrente.usuCrea = buscarRequerimientoVista.UsuarioOperacion.NomUsuario;
            respuesta = gastoRecurrenteServicio.NuevoDetalleMasivoPorCuentas(gastoRecurrente, buscarRequerimientoVista.listaSeleccionada);

            return respuesta.esCorrecto;
        }

        public void llenarComboProvincia(int idRegion)
        {
            var listaProvincia = ubigeoServicio.TraerListaProvincia(idRegion);
            if (listaProvincia != null)
            {
                buscarRequerimientoVista.listaProvincia = listaProvincia;
                if (listaProvincia.Count > 0)
                    buscarRequerimientoVista.idProvincia = planAnualAdquisicionDetalle.idUbigeo == 0 ? listaProvincia.First().idUbigeo : ubigeoPoco.idProvincia; //listaProvincia.First().idUbigeo;
            }
        }
        public void llenarComboDistrito(int idProvincia)
        {
            var listaDistrito = ubigeoServicio.TraerListaDistrito(idProvincia);
            if (listaDistrito != null)
            {
                buscarRequerimientoVista.listaDistrito = listaDistrito;
                if (listaDistrito.Count > 0)
                    buscarRequerimientoVista.idUbigeo = planAnualAdquisicionDetalle.idUbigeo == 0 ? listaDistrito.First().idUbigeo : ubigeoPoco.idDistrito; //listaDistrito.First().idUbigeo;
            }
        }
    }
}
