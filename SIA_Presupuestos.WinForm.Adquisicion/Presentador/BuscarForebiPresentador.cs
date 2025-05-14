using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class BuscarForebiPresentador
    {
        private readonly IBuscarForebiVista buscarForebiVista;

        private ICertificacionMasterServicio certificacionMasterServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        
        private CertificacionRequerimiento certificacionRequerimiento;
        private CertificacionDetallePres certificacionDetallePres;

        private tipoAyudaFore tipo;
        private bool esModificacion;

        public BuscarForebiPresentador(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres, IBuscarForebiVista buscarRequerimientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;

            this.buscarForebiVista = buscarRequerimientoVista;
            this.certificacionRequerimiento = certificacionRequerimiento ?? new CertificacionRequerimiento();
            this.certificacionDetallePres = certificacionDetallePres;
            this.esModificacion = this.certificacionDetallePres != null;

            this.tipo = certificacionMasterPres.tipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio;

            if (tipo.Equals(tipoAyudaFore.bien))
                this.buscarForebiVista.Forebi = this.certificacionMasterServicio.BuscarForebi((int)certificacionMasterPres.idForebise);
            else
                this.buscarForebiVista.Forese = this.certificacionMasterServicio.BuscarForese((int)certificacionMasterPres.idForebise);

        }
        
        public bool RegistrarDetalles()
        {
            Resultado respuesta = null;
            certificacionRequerimiento.usuCrea = buscarForebiVista.UsuarioOperacion.NomUsuario;

            if(!esModificacion)
                respuesta = certificacionRequerimientoServicio.NuevoDetalleMasivoReque(certificacionRequerimiento, buscarForebiVista.ListaDetallesSeleccionados);
            else
                respuesta = certificacionRequerimientoServicio.ModificarDetalleMasivoReque(certificacionRequerimiento, buscarForebiVista.ListaDetallesSeleccionados);
            return respuesta.esCorrecto;
        }

        public void TraerSubPresupuestoImporteCertificacion(int idSubpresupuesto)
        {
            buscarForebiVista.SubPresupuestoImporteCertificacion = certificacionRequerimientoServicio.TraerSubPresupuestoImporteCertificacion(idSubpresupuesto);
        }
    }
}
