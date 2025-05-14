using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class RequerimientoRecursoHumanoPresentador
    {
        private readonly IRequerimientoRecursoHumanoVista requerimientoRecursoHumanoVista;

        private IRequerimientoRecursoHumanoServicio requerimientoRecursoHumanoServicio;
        private IPuestoRequerimientoServicio puestoRequerimientoServicio;
        private IGeneralServicio generalServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IPeriodoServicio periodoServicio;
        private Periodo periodo = new Periodo();
        private RequerimientoRecursoHumanoPres requerimientoRecursoHumano;

        public RequerimientoRecursoHumanoPresentador(IRequerimientoRecursoHumanoVista requerimientoRecursoHumanoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoRecursoHumanoServicio = _Contenedor.Resolver(typeof(IRequerimientoRecursoHumanoServicio)) as IRequerimientoRecursoHumanoServicio;
            this.puestoRequerimientoServicio = _Contenedor.Resolver(typeof(IPuestoRequerimientoServicio)) as IPuestoRequerimientoServicio;
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();

            this.requerimientoRecursoHumanoVista = requerimientoRecursoHumanoVista;
            periodo = this.periodoServicio.ObtenerActivo();
            this.requerimientoRecursoHumano = new RequerimientoRecursoHumanoPres();
        }

        public void CargarServicios()
        {
            this.requerimientoRecursoHumanoServicio = IoCHelper.ResolverIoC<IRequerimientoRecursoHumanoServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.certificacionRequerimientoServicio = IoCHelper.ResolverIoC<ICertificacionRequerimientoServicio>();
            this.periodoServicio = IoCHelper.ResolverIoC<IPeriodoServicio>();
        }

        public void ObtenerDatosListado()
        {
            this.requerimientoRecursoHumano = requerimientoRecursoHumanoServicio.BuscarRequerimientoRecursoHumano(requerimientoRecursoHumanoVista.idReqRecHum);
            requerimientoRecursoHumanoVista.descripcion = this.requerimientoRecursoHumano.desArea + " / " + this.requerimientoRecursoHumano.desSubdireccion + " / " + this.requerimientoRecursoHumano.desDireccion;
            requerimientoRecursoHumanoVista.listaDatosPrincipales = requerimientoRecursoHumanoServicio.TraerListaRequerimientoRecursoHumanoDetalle(requerimientoRecursoHumanoVista.idReqRecHum);
        }

        public PuestoRequerimiento BuscarDetalle(int id)
        {
            return this.puestoRequerimientoServicio.BuscarPorCodigo(id);
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        public void IniciarDatos(int id)
        {
            LlenarCombos();
            PuestoRequerimiento puestoRequerimiento = puestoRequerimientoServicio.BuscarPorCodigo(id);
            if (puestoRequerimiento == null)
                return;

            requerimientoRecursoHumanoVista.idReqRecHum = puestoRequerimiento.idReqRecHum;
            requerimientoRecursoHumanoVista.idTrabajador = (int)puestoRequerimiento.idTrabajador;
            if (requerimientoRecursoHumanoVista.idTrabajador > 0)
                requerimientoRecursoHumanoVista.desPersonal = generalServicio.BuscarTrabajador((int)puestoRequerimiento.idTrabajador).trabajador;
            else
                requerimientoRecursoHumanoVista.desPersonal = "[VANCANTE]";

            requerimientoRecursoHumanoVista.esVacante = puestoRequerimiento.esVacante;
            requerimientoRecursoHumanoVista.cantVacante = (int)puestoRequerimiento.cantVacante;

            requerimientoRecursoHumanoVista.idRegLab = (int)puestoRequerimiento.idRegLab;
            requerimientoRecursoHumanoVista.idConLab = (int)puestoRequerimiento.idConLab;
            requerimientoRecursoHumanoVista.idCatLab = (int)puestoRequerimiento.idCatLab;
            requerimientoRecursoHumanoVista.idSede = (int)puestoRequerimiento.idSede;

            requerimientoRecursoHumanoVista.idCargo = (int)puestoRequerimiento.idCargo;
            if (requerimientoRecursoHumanoVista.idCargo > 0)
                requerimientoRecursoHumanoVista.desCargo = generalServicio.BuscarCargo((int)puestoRequerimiento.idCargo).desCargo;
            else
                requerimientoRecursoHumanoVista.desPersonal = "";

            requerimientoRecursoHumanoVista.grado = (int)puestoRequerimiento.grado;
            requerimientoRecursoHumanoVista.remuneracion = puestoRequerimiento.remuneracion;
            requerimientoRecursoHumanoVista.idMoneda = (int)puestoRequerimiento.idTipMon;
            requerimientoRecursoHumanoVista.esRemDiaria = (bool)puestoRequerimiento.esRemDiaria;

            if (puestoRequerimiento.idCargoPropuesto > 0)
                requerimientoRecursoHumanoVista.idCargoPropuesto = (int)puestoRequerimiento.idCargoPropuesto;

            requerimientoRecursoHumanoVista.gradoPropuesto = (int)puestoRequerimiento.gradoPropuesto;
            requerimientoRecursoHumanoVista.remPropuesta = (decimal)puestoRequerimiento.remPropuesta;

            requerimientoRecursoHumanoVista.justificacion = puestoRequerimiento.justificacion;
            requerimientoRecursoHumanoVista.idFueFin = (int)puestoRequerimiento.idFueFin;
            requerimientoRecursoHumanoVista.observacion = puestoRequerimiento.observacion;

            requerimientoRecursoHumanoVista.fechaInicio = (DateTime)puestoRequerimiento.fechaInicio;
            requerimientoRecursoHumanoVista.fechaTermino = (DateTime)puestoRequerimiento.fechaTermino;

        }

        private void LlenarCombos()
        {
            requerimientoRecursoHumanoVista.listaCargosPro = generalServicio.ListaCargos();

            requerimientoRecursoHumanoVista.listaRegimelLaboral = generalServicio.TraerDatosRegimenLaboral();
            requerimientoRecursoHumanoVista.listaCategoriaLaboral = generalServicio.TraerDatosCategoriaLaboral();
            requerimientoRecursoHumanoVista.listaCondicionLaboral = generalServicio.TraerDatosCondicionLaboral();

            requerimientoRecursoHumanoVista.listaSedes = generalServicio.ListaSedeLaboral();
            

            requerimientoRecursoHumanoVista.listaMonedas = generalServicio.ListaMonedas();
            requerimientoRecursoHumanoVista.listaFuenteFinanciamiento = generalServicio.ListaFuenteFinanciamiento();

        }
        public void ListaTrabajadores(int idReqRecHum)
        {
            RequerimientoRecursoHumano reqReHum = this.requerimientoRecursoHumanoServicio.BuscarPorCodigo(idReqRecHum);
            requerimientoRecursoHumanoVista.listaTrabajador = this.puestoRequerimientoServicio.ListaTrabajadoresRequerimiento(reqReHum != null ? reqReHum.anio : periodo.anio);
        }
        public void ListaCargos()
        {
            requerimientoRecursoHumanoVista.listaCargos = generalServicio.ListaCargos();
        }
        public string BuscarSimboloMoneda(int idReq)
        {
            string moneda = string.Empty;
            var requerimiento = requerimientoRecursoHumanoServicio.BuscarPorCodigo(idReq);
            if(requerimiento != null)
            {
                var objmoneda = generalServicio.BuscarMoneda(requerimiento.idMoneda);
                if (objmoneda != null)
                    moneda = objmoneda.abreviatura;
            }
            return moneda;
        }

        private bool esModificacion;
        public Resultado GuardarDatos(string args)
        {
            Resultado resultado = null;
            var callbackArgs = Util.DeserializeCallbackArgs(args);

            PuestoRequerimiento puestoRequerimiento = null;

            if (callbackArgs[0] == "Nuevo")
            {
                puestoRequerimiento = new PuestoRequerimiento();
            }
            else if (callbackArgs[0] == "Editar")
            {
                int id = int.Parse(callbackArgs[1]);
                puestoRequerimiento = puestoRequerimientoServicio.BuscarPorCodigo(id);
                esModificacion = true;
            }

            if (puestoRequerimiento == null)
                return null;

            puestoRequerimiento.idReqRecHum = Convert.ToInt32(callbackArgs[2]);

            int idTrabajador = 0;
            if (int.TryParse(callbackArgs[3], out idTrabajador))
                puestoRequerimiento.idTrabajador = idTrabajador;
            else
                puestoRequerimiento.idTrabajador = 0;

            if (Convert.ToBoolean(callbackArgs[4]))//es vacante
                puestoRequerimiento.idTrabajador = 0;
            else
                puestoRequerimiento.idTrabajador = idTrabajador;

            puestoRequerimiento.esVacante = Convert.ToBoolean(callbackArgs[4]);
            puestoRequerimiento.cantVacante = puestoRequerimiento.esVacante ? Convert.ToInt32(callbackArgs[5]) : 0;

            puestoRequerimiento.idSede = Convert.ToInt32(callbackArgs[6]);
            puestoRequerimiento.idRegLab = Convert.ToInt32(callbackArgs[7]);
            puestoRequerimiento.idCatLab = Convert.ToInt32(callbackArgs[8]);
            puestoRequerimiento.idConLab = Convert.ToInt32(callbackArgs[9]);

            puestoRequerimiento.idCargo = Convert.ToInt32(callbackArgs[10]);
            puestoRequerimiento.grado = Convert.ToInt32(callbackArgs[11]);
            puestoRequerimiento.remuneracion = Convert.ToDecimal(callbackArgs[12]);
            puestoRequerimiento.idTipMon = Convert.ToInt32(callbackArgs[13]);

            puestoRequerimiento.idCargoPropuesto = Convert.ToInt32(callbackArgs[14]);
            puestoRequerimiento.gradoPropuesto = Convert.ToInt32(callbackArgs[15]);
            puestoRequerimiento.remPropuesta = Convert.ToDecimal(callbackArgs[16]);
            puestoRequerimiento.esRemDiaria = Convert.ToBoolean(callbackArgs[17]);

            puestoRequerimiento.conBonoAlimento = puestoRequerimiento.esRemDiaria ? false : true;
            puestoRequerimiento.conBonoAlimentoAdi = false;
            puestoRequerimiento.conBonoMovilidad = puestoRequerimiento.esRemDiaria ? false : true;
            puestoRequerimiento.conBonoProductividad = false;
            
            puestoRequerimiento.justificacion = Convert.ToString(callbackArgs[18]).TrimStart().TrimEnd().ToUpper();
            puestoRequerimiento.idFueFin = Convert.ToInt32(callbackArgs[19]);

            puestoRequerimiento.observacion = Convert.ToString(callbackArgs[20]).TrimStart().TrimEnd().ToUpper();

            puestoRequerimiento.fechaInicio = Convert.ToDateTime(callbackArgs[21]);
            puestoRequerimiento.fechaTermino = Convert.ToDateTime(callbackArgs[22]);

            //if (puestoRequerimiento.esVacante)
            //{
            //    puestoRequerimiento.fechaInicio = Convert.ToDateTime(callbackArgs[21]);
            //    puestoRequerimiento.fechaTermino = Convert.ToDateTime(callbackArgs[22]);
            //}
            //else
            //{
            //    RequerimientoRecursoHumano reqReHum = this.requerimientoRecursoHumanoServicio.BuscarPorCodigo(puestoRequerimiento.idReqRecHum);
            //    int anio = reqReHum != null ? reqReHum.anio : periodo != null ? periodo.anio : DateTime.Now.Year;
            //    puestoRequerimiento.fechaInicio = new DateTime(anio, 1, 1);
            //    puestoRequerimiento.fechaTermino = puestoRequerimiento.fechaInicio = new DateTime(anio, 12, 31);
            //}
            
            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                puestoRequerimiento.fechaEdita = DateTime.Now;
                puestoRequerimiento.usuEdita = requerimientoRecursoHumanoVista.nomUsuario;
                resultado = puestoRequerimientoServicio.ModificarSinClonar(puestoRequerimiento);
            }
            else
            {
               
                puestoRequerimiento.fechaCrea = DateTime.Now;
                puestoRequerimiento.usuCrea = requerimientoRecursoHumanoVista.nomUsuario;
                puestoRequerimiento.estado = Estados.Activo;
                resultado = puestoRequerimientoServicio.Nuevo(puestoRequerimiento);
            }

            return resultado;
        }
        public bool Anular(int id)
        {
            bool respuesta = false;
            PuestoRequerimiento puestoRequerimiento = puestoRequerimientoServicio.BuscarPorCodigo(id);
            respuesta = this.puestoRequerimientoServicio.AnularSinClonar(puestoRequerimiento, requerimientoRecursoHumanoVista.nomUsuario).esCorrecto;
            return respuesta;
        }

    }
}
