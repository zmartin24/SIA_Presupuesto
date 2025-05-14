using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class CertificacionRequerimientoAmpliacionPresentador
    {
        private readonly ICertificacionRequerimientoAmpliacionVista certificacionRequerimientoAmpliacionVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private ICertificacionMasterServicio certificacionMasterServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ISubpresupuestoServicio subPresupuestoServicio;
        private IGeneralServicio generalServicio;
        private ITipoCambioPresupuestoServicio tipoCambioPresupuestoServicio;

        private CertificacionRequerimiento certificacionRequerimiento;
        private List<ForeDetallePoco> listaCertificacionDetalleAmpliacion;
        private CertificacionMasterPres certificacionMasterPres;
        private bool esModificacion;

        public CertificacionRequerimientoAmpliacionPresentador(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, ICertificacionRequerimientoAmpliacionVista certificacionRequerimientoAmpliacionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.subPresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.tipoCambioPresupuestoServicio = _Contenedor.Resolver(typeof(ITipoCambioPresupuestoServicio)) as ITipoCambioPresupuestoServicio;

            this.certificacionRequerimientoAmpliacionVista = certificacionRequerimientoAmpliacionVista;
            this.certificacionRequerimiento = certificacionRequerimiento ?? new CertificacionRequerimiento();
            this.certificacionMasterPres = certificacionMasterPres ?? new CertificacionMasterPres();
        }
        public void IniciarDatos()
        {
            certificacionRequerimientoAmpliacionVista.CertificacionMasterPres = this.certificacionMasterPres;
            if (this.certificacionMasterPres.tipoReq == 1)
                certificacionRequerimientoAmpliacionVista.CertificacionMasterPres.forebi.ListaForeDetallePoco = certificacionRequerimientoServicio.TraerListaFormatoRequerimientoDetalle(this.certificacionMasterPres.idForebise, this.certificacionMasterPres.tipoReq);
            else
                certificacionRequerimientoAmpliacionVista.CertificacionMasterPres.forese.ListaForeDetallePoco = certificacionRequerimientoServicio.TraerListaFormatoRequerimientoDetalle(this.certificacionMasterPres.idForebise, this.certificacionMasterPres.tipoReq);

            
            var listaTipoRequerimiento = PredeterminadoHelper.ListarTipoRequerimiento();
            if (listaTipoRequerimiento != null)
            {
                certificacionRequerimientoAmpliacionVista.listaTipoRequerimiento = listaTipoRequerimiento;
                if (listaTipoRequerimiento.Count > 0)
                    certificacionRequerimientoAmpliacionVista.idTipoReq = this.certificacionMasterPres.tipoReq;
            }
            certificacionRequerimientoAmpliacionVista.ListaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();
            ///Asignamos presupuesto
            certificacionRequerimientoAmpliacionVista.idGruPre = this.certificacionMasterPres.tipoReq == 1 ? (int)this.certificacionMasterPres.forebi.idGruPre : (int)this.certificacionMasterPres.forese.idGruPre;
            certificacionRequerimientoAmpliacionVista.idPresupuesto = this.certificacionMasterPres.tipoReq == 1 ? (int)this.certificacionMasterPres.forebi.idPresupuesto : (int)this.certificacionMasterPres.forese.idPresupuesto;
            certificacionRequerimientoAmpliacionVista.idSubPresupuesto = this.certificacionMasterPres.tipoReq == 1 ? (bool)this.certificacionMasterPres.forebi.esAnual ? 0 : (int)this.certificacionMasterPres.forebi.idSubPresupuesto : (bool)this.certificacionMasterPres.forese.esAnual ? 0 : (int)this.certificacionMasterPres.forese.idSubPresupuesto;
            
            

            Subpresupuesto objRegistroSubPresupuesto = subPresupuestoServicio.BuscarPorCodigo(certificacionRequerimiento.nivelPresupuesto == 3 ? (int)certificacionRequerimiento.idPresupuesto.GetValueOrDefault() : 0);
            ProgramacionAnual objProgramacionAnual = programacionAnualServicio.BuscarPorCodigo(objRegistroSubPresupuesto == null ? 0 : (int)objRegistroSubPresupuesto.idProAnu);

            certificacionRequerimientoAmpliacionVista.sigla = this.certificacionRequerimiento.sigla;
            //certificacionRequerimientoAmpliacionVista.idGruPre = objProgramacionAnual == null ? 0 : objProgramacionAnual.idGruPre.GetValueOrDefault();
            //certificacionRequerimientoAmpliacionVista.idPresupuesto = objRegistroSubPresupuesto == null ? 0 : objRegistroSubPresupuesto.idProAnu;
            //certificacionRequerimientoAmpliacionVista.idSubPresupuesto = objRegistroSubPresupuesto == null ? 0 : (int)objRegistroSubPresupuesto.idSubpresupuesto;
            certificacionRequerimientoAmpliacionVista.tipoCambio = certificacionRequerimiento.tipoCambio == null ? 0 : (decimal)certificacionRequerimiento.tipoCambio;
            certificacionRequerimientoAmpliacionVista.total = certificacionRequerimiento.totalSoles == null ? 0 : (decimal)certificacionRequerimiento.totalSoles;
            certificacionRequerimientoAmpliacionVista.detalle = certificacionRequerimiento.totalSoles == null ? "" : certificacionRequerimiento.detalle;
            certificacionRequerimientoAmpliacionVista.justificacion = "";

            listaCertificacionDetalleAmpliacion = this.certificacionRequerimientoServicio.TraerListaCertificacionDetalleAmpiacion(this.certificacionRequerimiento.idCerReq);
            this.esModificacion = listaCertificacionDetalleAmpliacion != null && listaCertificacionDetalleAmpliacion.Count > 0 ? true : false;

            if (this.esModificacion)
            {
                //certificacionRequerimientoAmpliacionVista.detalle = certificacionRequerimiento.detalle;
                certificacionRequerimientoAmpliacionVista.justificacion = certificacionRequerimiento.justificacionAmp;
                certificacionRequerimientoAmpliacionVista.listaForeDetallePoco = listaCertificacionDetalleAmpliacion;
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            certificacionRequerimiento.detalle = certificacionRequerimientoAmpliacionVista.detalle;
            certificacionRequerimiento.justificacionAmp = certificacionRequerimientoAmpliacionVista.justificacion;
            certificacionRequerimiento.totalSoles = certificacionRequerimientoAmpliacionVista.total;
            if (this.esModificacion)
            {
                certificacionRequerimiento.fechaEditaAmp = DateTime.Now;
                certificacionRequerimiento.usuEditaAmp = certificacionRequerimientoAmpliacionVista.UsuarioOperacion.NomUsuario;
            }
            else
            {
                certificacionRequerimiento.fechaAmp = DateTime.Now;
                certificacionRequerimiento.usuAmp = certificacionRequerimientoAmpliacionVista.UsuarioOperacion.NomUsuario;
            }
            resultado = certificacionRequerimientoServicio.NuevoAmpliacion(certificacionRequerimiento, this.certificacionRequerimientoAmpliacionVista.CertificacionMasterPres, this.certificacionRequerimientoAmpliacionVista.ListaDetallesSeleccionados, this.esModificacion);
            return resultado.esCorrecto;
        }
        public void LlenarComboPresupuesto(int idGrupo)
        {
            certificacionRequerimientoAmpliacionVista.ListaProgramacion = programacionAnualServicio.TraerListaxGrupo(idGrupo);
        }
        public void LlenarComboSubPresupuesto(int idProAnu)
        {
            certificacionRequerimientoAmpliacionVista.ListaSubpresupuesto = subPresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(idProAnu);
        }
        public void TraerTipoCambio(int idSubpresupuesto)
        {
            certificacionRequerimientoAmpliacionVista.SubPresupuestoImporteCertificacion = certificacionRequerimientoServicio.TraerSubPresupuestoImporteCertificacion(idSubpresupuesto);
            certificacionRequerimientoAmpliacionVista.tipoCambio = certificacionRequerimientoAmpliacionVista.SubPresupuestoImporteCertificacion != null ? (decimal)certificacionRequerimientoAmpliacionVista.SubPresupuestoImporteCertificacion.tipoCambio : 0;
        }
        public List<SubPresupuestoDetallePres> TraerListaSubPresupuestoDetalle(int idSubPresupuesto)
        {
            return certificacionRequerimientoServicio.TraerListaSubPresupuestoDetalle(idSubPresupuesto);
        }
    }
}
