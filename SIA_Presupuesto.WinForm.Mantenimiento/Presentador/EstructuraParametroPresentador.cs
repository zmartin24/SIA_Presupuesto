using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class EstructuraParametroPresentador
    {
        private readonly IEstructuraPropiedadVista estructuraPropiedadVista;
        private IEstructuraPresupuestoRemuneracionServicio estructuraPresupuestoRemuneracionServicio;
        private EstructuraPresupuestoRemuneracion estructura;
        public EstructuraParametroPresentador(EstructuraPresupuestoRemuneracion estructura, IEstructuraPropiedadVista estructuraPropiedadVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.estructura = estructura;
            this.estructuraPropiedadVista = estructuraPropiedadVista;
            this.estructuraPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
        }

        public void ObtenerDatosListado()
        {
            estructuraPropiedadVista.listaDatosPrincipales = estructuraPresupuestoRemuneracionServicio.TraerPropiedadPresentacion(this.estructura.idEstPreRem);
        }
        public PropiedadPresupuestoRemuneracion Buscar(int vid)
        {
            return estructuraPresupuestoRemuneracionServicio.BuscarPorCodigoPropiedad(vid);
        }

        public EstructuraPresupuestoRemuneracion TraerEstructura()
        {
            return estructura;
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (estructuraPropiedadVista.propiedadPresupuestoRemuneracion != null)
            {
                estructuraPropiedadVista.propiedadPresupuestoRemuneracion.usuEdita = estructuraPropiedadVista.UsuarioOperacion.NomUsuario;
                respuesta = this.estructuraPresupuestoRemuneracionServicio.AnularPropiedad(estructuraPropiedadVista.propiedadPresupuestoRemuneracion).esCorrecto;
            }
            return respuesta;
        }

    }
}
