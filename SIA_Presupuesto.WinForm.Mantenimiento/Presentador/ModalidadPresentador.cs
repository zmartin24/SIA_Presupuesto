using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class ModalidadPresentador
    {
        private readonly IModalidadVista modalidadVista;

        private IModalidadServicio modalidadServicio;
        private IGeneralServicio generalServicio;

        private Modalidad modalidad;
        private bool esModificacion;
        public ModalidadPresentador(Modalidad modalidad, IModalidadVista modalidadVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.modalidadServicio = _Contenedor.Resolver(typeof(IModalidadServicio)) as IModalidadServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.modalidadVista = modalidadVista;
            this.esModificacion = modalidad != null;
            this.modalidad = modalidad ?? new Modalidad();
        }
        public void IniciarDatos()
        {
            if (this.esModificacion)
            {
                modalidadVista.descripcion = modalidad.descripcion;
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            modalidad.descripcion = modalidadVista.descripcion.ToUpper();
            
            if (this.esModificacion)
            {
                modalidad.fechaEdita = DateTime.Now;
                modalidad.usuEdita = modalidadVista.UsuarioOperacion.NomUsuario;
                resultado = modalidadServicio.Modificar(modalidad);
            }
            else
            {
                modalidad.fechaCrea = DateTime.Now;
                modalidad.usuCrea = modalidadVista.UsuarioOperacion.NomUsuario;
                modalidad.estado = Estados.Activo;
                resultado = modalidadServicio.Nuevo(modalidad);
            }

            return resultado.esCorrecto;
        }
    }
}
