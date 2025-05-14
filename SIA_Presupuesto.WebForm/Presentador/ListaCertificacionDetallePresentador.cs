using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaCertificacionDetallePresentador
    {
        private readonly IListaCertificacionDetalleVista listaCertificacionDetalleVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IGeneralServicio generalServicio;
        
        public ListaCertificacionDetallePresentador(IListaCertificacionDetalleVista listaCertificacionDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;

            this.listaCertificacionDetalleVista = listaCertificacionDetalleVista;
        }

        public void CargarServicios()
        {
            this.certificacionRequerimientoServicio = IoCHelper.ResolverIoC<ICertificacionRequerimientoServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
        }

        public void ObtenerDatosListado()
        {
            listaCertificacionDetalleVista.listaDatosPrincipales = TraerListaCertificacionRequerimiento();
        }
        public List<CertificacionRequerimientoPres> TraerListaCertificacionRequerimiento()
        {
            return this.certificacionRequerimientoServicio.TraerListaCertificacionRequerimiento(listaCertificacionDetalleVista.idCerMas);
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        
    }
}

