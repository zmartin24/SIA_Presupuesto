using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class PropiedadPresentador
    {
        private readonly IPropiedadVista propiedadVista;
        private IParametroPresupuestoRemuneracionServicio propiedadPresupuestoRemuneracionServicio;
        private IConceptoPresupuestoRemuneracionServicio conceptoPresupuestoRemuneracionServicio;
        private IEstructuraPresupuestoRemuneracionServicio estructuraPresupuestoRemuneracionServicio;
        private PropiedadPresupuestoRemuneracion propiedadPresupuestoRemuneracion;
        private EstructuraPresupuestoRemuneracion estructura;
        private bool esModificacion;
        public PropiedadPresentador(PropiedadPresupuestoRemuneracion propiedadPresupuestoRemuneracion, EstructuraPresupuestoRemuneracion estructura, IPropiedadVista propiedadVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.propiedadVista = propiedadVista;
            this.estructura = estructura;

            this.propiedadPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IParametroPresupuestoRemuneracionServicio)) as IParametroPresupuestoRemuneracionServicio;
            this.estructuraPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
            this.conceptoPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IConceptoPresupuestoRemuneracionServicio)) as IConceptoPresupuestoRemuneracionServicio;

            this.esModificacion = propiedadPresupuestoRemuneracion != null;
            this.propiedadPresupuestoRemuneracion = propiedadPresupuestoRemuneracion ?? new PropiedadPresupuestoRemuneracion();
        }

        public PropiedadPresupuestoRemuneracion TraerPropiedad()
        {
            this.propiedadPresupuestoRemuneracion.idConPreRem = propiedadPresupuestoRemuneracion.idConPreRem;
            this.propiedadPresupuestoRemuneracion.idEstPreRem = estructura.idEstPreRem;
            return this.propiedadPresupuestoRemuneracion;
        }

        public void IniciarDatos()
        {
            
            propiedadVista.listaTipoValor = PredeterminadoHelper.ListarTipoValor();
            
            if (this.esModificacion)
            {
                propiedadVista.listaConceptos = conceptoPresupuestoRemuneracionServicio.TraerTodosActivos();
                propiedadVista.idConPreRem = propiedadPresupuestoRemuneracion.idConPreRem;
                propiedadVista.tipoValor = propiedadPresupuestoRemuneracion.tipoValor;
                propiedadVista.valor = propiedadPresupuestoRemuneracion.valor;
                propiedadVista.orden = propiedadPresupuestoRemuneracion.orden;
                propiedadVista.visualiza = propiedadPresupuestoRemuneracion.visualiza ? "SI": "NO";
                //propiedadVista. = propiedadPresupuestoRemuneracion.;
            }
            else
                propiedadVista.listaConceptos = conceptoPresupuestoRemuneracionServicio.TraerConceptosMenosdeEstructura(estructura.idEstPreRem);
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            propiedadPresupuestoRemuneracion.idConPreRem = propiedadVista.idConPreRem;
            propiedadPresupuestoRemuneracion.tipoValor = propiedadVista.tipoValor;
            propiedadPresupuestoRemuneracion.valor = propiedadVista.valor;
            propiedadPresupuestoRemuneracion.orden = propiedadVista.orden;
            propiedadPresupuestoRemuneracion.visualiza = propiedadVista.visualiza.Equals("SI");
            propiedadPresupuestoRemuneracion.idEstPreRem = estructura.idEstPreRem;

            if (this.esModificacion)
            {
                propiedadPresupuestoRemuneracion.fechaEdita = DateTime.Now;
                propiedadPresupuestoRemuneracion.usuEdita = propiedadVista.UsuarioOperacion.NomUsuario;
                resultado = estructuraPresupuestoRemuneracionServicio.ModificarPropiedad(propiedadPresupuestoRemuneracion);
            }
            else
            {
                propiedadPresupuestoRemuneracion.fechaCrea = DateTime.Now;
                propiedadPresupuestoRemuneracion.usuCrea = propiedadVista.UsuarioOperacion.NomUsuario;
                propiedadPresupuestoRemuneracion.estado = Estados.Activo;
                resultado = estructuraPresupuestoRemuneracionServicio.NuevoPropiedad(propiedadPresupuestoRemuneracion);
            }

            return resultado.esCorrecto;
        }
    }
}
