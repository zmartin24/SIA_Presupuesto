using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class CertificacionRequerimientoPresentador
    {
        private readonly ICertificacionRequerimientoVista certificacionRequerimientoVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private ICertificacionMasterServicio certificacionMasterServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ISubpresupuestoServicio subPresupuestoServicio;
        private IGeneralServicio generalServicio;
        private ITipoCambioPresupuestoServicio tipoCambioPresupuestoServicio;

        private CertificacionRequerimiento certificacionRequerimiento;
        private CertificacionMasterPres certificacionMasterPres;
        private CertificacionMaster certificacionMaster;

        private ProgramacionAnual programacionAnual;
        private Subpresupuesto subpresupuesto;

        private bool esModificacion;
        public CertificacionRequerimientoPresentador(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, ICertificacionRequerimientoVista certificacionRequerimientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.subPresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.tipoCambioPresupuestoServicio = _Contenedor.Resolver(typeof(ITipoCambioPresupuestoServicio)) as ITipoCambioPresupuestoServicio;

            this.certificacionRequerimientoVista = certificacionRequerimientoVista;
            this.esModificacion = certificacionRequerimiento != null;
            this.certificacionRequerimiento = certificacionRequerimiento ?? new CertificacionRequerimiento();
            this.certificacionMasterPres = certificacionMasterPres ?? new CertificacionMasterPres();
            this.certificacionMaster = this.certificacionMasterServicio.BuscarPorCodigo(this.certificacionMasterPres.idCerMas);
            
            this.programacionAnual = new ProgramacionAnual();
            this.subpresupuesto = new Subpresupuesto();
        }
        public void IniciarDatos()
        {
            certificacionRequerimientoVista.CertificacionMasterPres = this.certificacionMasterPres;
            certificacionRequerimientoVista.CertificacionRequerimiento = this.certificacionRequerimiento;
            if (this.certificacionMasterPres.tipoReq == 1)
                certificacionRequerimientoVista.CertificacionMasterPres.forebi.ListaForeDetallePoco = certificacionRequerimientoServicio.TraerListaFormatoRequerimientoDetalle(this.certificacionMasterPres.idForebise, this.certificacionMasterPres.tipoReq);
            else
                certificacionRequerimientoVista.CertificacionMasterPres.forese.ListaForeDetallePoco = certificacionRequerimientoServicio.TraerListaFormatoRequerimientoDetalle(this.certificacionMasterPres.idForebise, this.certificacionMasterPres.tipoReq);

            certificacionRequerimientoVista.esTotalDetallado = (bool)this.certificacionMasterPres.esTotalDetallado;
            var listaTipoRequerimiento = PredeterminadoHelper.ListarTipoRequerimiento();
            if (listaTipoRequerimiento != null)
            {
                certificacionRequerimientoVista.listaTipoRequerimiento = listaTipoRequerimiento;
                if (listaTipoRequerimiento.Count > 0)
                    certificacionRequerimientoVista.idTipoReq = this.certificacionMasterPres.tipoReq;
            }
            certificacionRequerimientoVista.ListaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();
            ///Asignamos presupuesto
            certificacionRequerimientoVista.idGruPre = this.certificacionMasterPres.tipoReq == 1 ? (int)this.certificacionMasterPres.forebi.idGruPre : (int)this.certificacionMasterPres.forese.idGruPre;
            certificacionRequerimientoVista.idPresupuesto = this.certificacionMasterPres.tipoReq == 1 ? (int)this.certificacionMasterPres.forebi.idPresupuesto : (int)this.certificacionMasterPres.forese.idPresupuesto;
            certificacionRequerimientoVista.idSubPresupuesto = this.certificacionMasterPres.tipoReq == 1 ? (bool)this.certificacionMasterPres.forebi.esAnual ? 0 : (int)this.certificacionMasterPres.forebi.idSubPresupuesto : (bool)this.certificacionMasterPres.forese.esAnual ? 0 : (int)this.certificacionMasterPres.forese.idSubPresupuesto;
            //certificacionRequerimientoVista.importeMinCer = this.certificacionRequerimientoServicio.TraerImporteMinCer();//Convert.ToDecimal(150);
            this.programacionAnual = this.programacionAnualServicio.BuscarPorCodigo(certificacionRequerimientoVista.idPresupuesto);
            this.subpresupuesto = this.subPresupuestoServicio.BuscarPorCodigo(certificacionRequerimientoVista.idSubPresupuesto);

            certificacionRequerimientoVista.fechaEmision = DateTime.Now.Date;

            if (this.esModificacion)
            {
                certificacionRequerimiento.idCerReq = certificacionRequerimiento == null ? 1 : certificacionRequerimiento.idCerReq;
                
                //Subpresupuesto objRegistroSubPresupuesto = subPresupuestoServicio.BuscarPorCodigo((int)certificacionRequerimiento.idSubpresupuesto.GetValueOrDefault());
                Subpresupuesto objRegistroSubPresupuesto = subPresupuestoServicio.BuscarPorCodigo(certificacionRequerimiento.nivelPresupuesto == 3 ? (int)certificacionRequerimiento.idPresupuesto.GetValueOrDefault() : 0);
                ProgramacionAnual objProgramacionAnual = programacionAnualServicio.BuscarPorCodigo(objRegistroSubPresupuesto == null ? 0 : (int)objRegistroSubPresupuesto.idProAnu);

                //certificacionRequerimientoVista.idGruPre = objProgramacionAnual == null ? 0 : objProgramacionAnual.idGruPre.GetValueOrDefault();
                //certificacionRequerimientoVista.idPresupuesto = objRegistroSubPresupuesto == null ? 0 : objRegistroSubPresupuesto.idProAnu;
                //certificacionRequerimientoVista.idSubPresupuesto = objRegistroSubPresupuesto == null ? 0 : (int)objRegistroSubPresupuesto.idSubpresupuesto;
                certificacionRequerimientoVista.fechaEmision = certificacionRequerimiento.fechaEmision;
                certificacionRequerimientoVista.tipoCambio = certificacionRequerimiento.tipoCambio == null ? 1 : (decimal)certificacionRequerimiento.tipoCambio;
                certificacionRequerimientoVista.total = certificacionRequerimiento.totalSoles == null ? 0 : (decimal)certificacionRequerimiento.totalSoles;
                certificacionRequerimientoVista.detalle = certificacionRequerimiento == null ? "" : certificacionRequerimiento.detalle;
                certificacionRequerimientoVista.observacion = certificacionRequerimiento == null ? "" : certificacionRequerimiento.observacion;

                certificacionRequerimientoVista.ListaDetalle = certificacionRequerimientoServicio.TraerListaCertificacionDetalle(certificacionRequerimiento.idCerMas, certificacionRequerimiento.idCerReq);
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            certificacionRequerimiento.detalle = certificacionRequerimientoVista.detalle.ToUpper();
            certificacionRequerimiento.observacion = certificacionRequerimientoVista.observacion.ToUpper();
            certificacionRequerimiento.idPresupuesto = certificacionRequerimientoVista.esAnual ? certificacionRequerimientoVista.idPresupuesto : certificacionRequerimientoVista.idSubPresupuesto;
            certificacionRequerimiento.nivelPresupuesto = certificacionRequerimientoVista.esAnual ? 2 : 3;

            
            certificacionRequerimiento.totalSoles = certificacionRequerimientoVista.total;
            certificacionRequerimiento.fechaEmision = certificacionRequerimientoVista.fechaEmision;
            if (this.esModificacion)
            {
                certificacionRequerimiento.fechaEdita = DateTime.Now;
                certificacionRequerimiento.usuEdita = certificacionRequerimientoVista.UsuarioOperacion.NomUsuario;
                resultado = certificacionRequerimientoServicio.Modificar(certificacionRequerimiento);
            }
            else
            {
                certificacionRequerimiento.tipoCambio = certificacionRequerimientoVista.tipoCambio;
                certificacionRequerimiento.fechaCrea = DateTime.Now;
                certificacionRequerimiento.usuCrea = certificacionRequerimientoVista.UsuarioOperacion.NomUsuario;
                certificacionRequerimiento.estado = Estados.Activo;
                certificacionRequerimiento.idCerMas = this.certificacionRequerimientoVista.CertificacionMasterPres.idCerMas;
                resultado = certificacionRequerimientoServicio.Nuevo(certificacionRequerimiento, this.certificacionRequerimientoVista.CertificacionMasterPres, this.certificacionRequerimientoVista.ListaDetallesSeleccionados, this.certificacionRequerimientoVista.idSubPresupuesto);
                this.certificacionRequerimientoVista.vmensaje = resultado.mensajeMostrar;
            }

            return resultado.esCorrecto;
        }
        public bool ProcesarRequerimientoCajaChica()
        {
            bool respuesta = false;
            if (certificacionRequerimiento != null)
                respuesta = this.certificacionMasterServicio.Anular(2, this.certificacionMaster, this.certificacionRequerimientoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        public void LlenarComboPresupuesto(int idGrupo)
        {
            certificacionRequerimientoVista.ListaProgramacion = programacionAnualServicio.TraerListaxGrupo(idGrupo);
        }
        public void LlenarComboSubPresupuesto(int idProAnu)
        {
            certificacionRequerimientoVista.ListaSubpresupuesto = subPresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(idProAnu);
        }
        public void TraerTipoCambio()
        {
            //certificacionRequerimientoVista.SubPresupuestoImporteCertificacion = certificacionRequerimientoServicio.TraerSubPresupuestoImporteCertificacion(idSubpresupuesto);
            int mes = this.subpresupuesto != null ? (int)this.subpresupuesto.mes : 0;
            this.certificacionRequerimientoVista.tipoCambio = this.generalServicio.TraerTipoCambio(this.programacionAnual.anio, mes);
        }
        
        public List<UsuarioCorreoPres> TraerListaUsuarioCorreo()
        {
            return certificacionRequerimientoServicio.TraerListaUsuarioCorreo();
        }
        public Resultado ValidaFechaCertificacion(DateTime fechaEmision, int numero, string opcion, int? idCerReq)
        {
            return certificacionRequerimientoServicio.ValidaFechaCertificacion(fechaEmision, numero, opcion, idCerReq);
        }
    }
}
