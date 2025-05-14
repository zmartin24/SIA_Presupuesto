using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Presentador
{
    public class AyudaCambioEstadoPresentador
    {
        private readonly IAyudaCambioEstadoVista ayudaCambioEstadoVista;

        private IGeneralServicio generalServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;

        private CertificacionRequerimiento certificacionRequerimiento;

        public AyudaCambioEstadoPresentador(CertificacionRequerimiento certificacionRequerimiento, IAyudaCambioEstadoVista ayudaCambioEstadoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.ayudaCambioEstadoVista = ayudaCambioEstadoVista;
            this.certificacionRequerimiento = certificacionRequerimiento;
        }

        public void InicializarDatos()
        {
            
        }
        public bool ActualizarEstado()
        {
            bool res = true;
            switch(this.ayudaCambioEstadoVista.idEstado.ToString())
            {
                case "10":
                    res = this.certificacionRequerimientoServicio.ActualizarEstadoCertificacionPresupuestal(this.certificacionRequerimiento.idCerReq, "AP", this.ayudaCambioEstadoVista.UsuarioOperacion.NomUsuario);
                    break;
                case "2":
                    res = this.certificacionRequerimientoServicio.ActualizarEstadoCertificacionPresupuestal(this.certificacionRequerimiento.idCerReq, "PE", this.ayudaCambioEstadoVista.UsuarioOperacion.NomUsuario);
                    break;
            }
            
            return res;
        }
    }
}
