using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class CertificacionMasterPresentador
    {
        private readonly ICertificacionMasterVista certificacionMasterVista;

        private ICertificacionMasterServicio certificacionMasterServicio;
        private IGeneralServicio generalServicio;

        private CertificacionMaster certificacionMaster;
        private bool esModificacion;
        public CertificacionMasterPresentador(CertificacionMaster certificacionMaster, ICertificacionMasterVista certificacionMasterVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
           
            this.certificacionMasterVista = certificacionMasterVista;
            this.esModificacion = certificacionMaster != null;
            this.certificacionMaster = certificacionMaster ?? new CertificacionMaster();
        }
        public void IniciarDatos()
        {
            
            var listaTipoRequerimiento = PredeterminadoHelper.ListarTipoRequerimiento();
            if (listaTipoRequerimiento != null)
            {
                certificacionMasterVista.listaTipoRequerimiento = listaTipoRequerimiento;
                if (listaTipoRequerimiento.Count > 0)
                    certificacionMasterVista.idTipoReq = Convert.ToInt32(listaTipoRequerimiento.FirstOrDefault().codigo);
            }

            if (this.esModificacion)
            {
                certificacionMasterVista.idTipoReq = certificacionMaster.tipoReq;
                certificacionMaster.idCerMas = certificacionMaster.idCerMas;
                certificacionMasterVista.idForebise = (int)certificacionMaster.idForebise;
                if (certificacionMasterVista.idForebise > 0)
                {
                    if(certificacionMaster.tipoReq.Equals(1))
                        certificacionMasterVista.Forebi = certificacionMasterServicio.BuscarForebi(certificacionMasterVista.idForebise);
                    else if (certificacionMaster.tipoReq.Equals(2))
                        certificacionMasterVista.Forese = certificacionMasterServicio.BuscarForese(certificacionMasterVista.idForebise);
                }
                certificacionMasterVista.esTotalDetallado = certificacionMaster == null ? true : (bool)certificacionMaster.esTotalDetallado;
                certificacionMasterVista.observacion = certificacionMaster == null ? "" : certificacionMaster.observacion;

                certificacionMasterVista.ListaCertificacionRequerimiento = certificacionMasterServicio.TraerListaCertificacionRequerimiento(certificacionMaster.idCerMas);
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            certificacionMaster.esTotalDetallado = certificacionMasterVista.esTotalDetallado;
            certificacionMaster.observacion = certificacionMasterVista.observacion;
            if (this.esModificacion)
            {
                certificacionMaster.fechaEdita = DateTime.Now;
                certificacionMaster.usuEdita = certificacionMasterVista.UsuarioOperacion.NomUsuario;
                resultado = certificacionMasterServicio.Modificar(certificacionMaster);
            }
            else
            {
                certificacionMaster.tipoReq = certificacionMasterVista.idTipoReq;
                certificacionMaster.idForebise = certificacionMasterVista.idForebise;
                certificacionMaster.fechaCrea = DateTime.Now;
                certificacionMaster.usuCrea = certificacionMasterVista.UsuarioOperacion.NomUsuario;
                certificacionMaster.estado = Estados.Activo;
                resultado = certificacionMasterServicio.Nuevo(certificacionMaster);
            }

            return resultado.esCorrecto;
        }
    }
}
