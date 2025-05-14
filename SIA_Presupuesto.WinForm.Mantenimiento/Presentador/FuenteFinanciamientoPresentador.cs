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
    public class FuenteFinanciamientoPresentador
    {
        private readonly IFuenteFinanciamientoVista fuenteFinanciamientoVista;

        private IFuenteFinanciamientoServicio fuenteFinanciamientoServicio;
        private IGeneralServicio generalServicio;

        private FuenteFinanciamiento fuenteFinanciamiento;
        private bool esModificacion;
        public FuenteFinanciamientoPresentador(FuenteFinanciamiento fuenteFinanciamiento, IFuenteFinanciamientoVista fuenteFinanciamientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.fuenteFinanciamientoServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.fuenteFinanciamientoVista = fuenteFinanciamientoVista;
            this.esModificacion = fuenteFinanciamiento != null;
            this.fuenteFinanciamiento = fuenteFinanciamiento ?? new FuenteFinanciamiento();
        }
        public void IniciarDatos()
        {
            if (this.esModificacion)
            {
                fuenteFinanciamientoVista.fuente = fuenteFinanciamiento.fuente;
                fuenteFinanciamientoVista.codigo = fuenteFinanciamiento.codigo;
                fuenteFinanciamientoVista.rubro = fuenteFinanciamiento.rubro;
                fuenteFinanciamientoVista.desRubro = fuenteFinanciamiento.desRubro;
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            fuenteFinanciamiento.fuente = fuenteFinanciamientoVista.fuente.ToUpper();
            fuenteFinanciamiento.anio = 2019;
            fuenteFinanciamiento.codigo = fuenteFinanciamientoVista.codigo.ToUpper();
            fuenteFinanciamiento.rubro = fuenteFinanciamientoVista.rubro.ToUpper();
            fuenteFinanciamiento.desRubro = fuenteFinanciamientoVista.desRubro.ToUpper();
            if (this.esModificacion)
            {
                fuenteFinanciamiento.fechaMod = DateTime.Now;
                fuenteFinanciamiento.usuMod = fuenteFinanciamientoVista.UsuarioOperacion.NomUsuario;
                resultado = fuenteFinanciamientoServicio.Modificar(fuenteFinanciamiento);
            }
            else
            {
                fuenteFinanciamiento.fechaCrea = DateTime.Now;
                fuenteFinanciamiento.usuCrea = fuenteFinanciamientoVista.UsuarioOperacion.NomUsuario;
                fuenteFinanciamiento.estado = Estados.Activo;
                resultado = fuenteFinanciamientoServicio.Nuevo(fuenteFinanciamiento);
            }

            return resultado.esCorrecto;
        }
    }
}
