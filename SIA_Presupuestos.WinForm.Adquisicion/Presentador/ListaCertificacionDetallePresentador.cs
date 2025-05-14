using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaCertificacionDetallePresentador
    {
        private readonly IListaCertificacionDetalleVista listaCertificacionDetalleVista;
        private ICertificacionMasterServicio certificacionMasterServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        CertificacionRequerimiento certificacionRequerimiento;
        public ListaCertificacionDetallePresentador(CertificacionRequerimiento certificacionRequerimiento, IListaCertificacionDetalleVista listaCertificacionDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.certificacionRequerimiento = certificacionRequerimiento;
            this.listaCertificacionDetalleVista = listaCertificacionDetalleVista;
        }

        public void ObtenerDatosListado()
        {
            listaCertificacionDetalleVista.listaDatosPrincipales = certificacionRequerimientoServicio.TraerListaCertificacionDetalle(0, certificacionRequerimiento.idCerReq);
        }

        public Forebi BuscarForebi(int vidForebi)
        {
            return certificacionMasterServicio.BuscarForebi(vidForebi);
        }
        public VerificaCertificacionDetallePres VerificaCertificacionDetalle(int? idCerReq, int? idCerDet)
        {
            return certificacionRequerimientoServicio.VerificaCertificacionDetalle(idCerReq, idCerDet);
        }
        public bool Anular()
        {
            bool respuesta = false;
            this.certificacionRequerimiento.usuEdita = listaCertificacionDetalleVista.UsuarioOperacion.NomUsuario;
            if (listaCertificacionDetalleVista.certificacionDetallePres != null)
                respuesta = this.certificacionRequerimientoServicio.AnularDetalle(this.certificacionRequerimiento, listaCertificacionDetalleVista.certificacionDetallePres).esCorrecto;
            return respuesta;
        }
        
    }
}
