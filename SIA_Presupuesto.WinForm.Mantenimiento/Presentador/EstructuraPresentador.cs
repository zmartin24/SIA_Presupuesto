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
    public class EstructuraPresentador
    {
        private readonly IEjeOperativoVista ejeOperativoVista;

        private IEstructuraPresupuestoRemuneracionServicio estructuraPresupuestoRemuneracionServicio;
        private IGeneralServicio generalServicio;

        private EstructuraPresupuestoRemuneracion estructuraPresupuestoRemuneracion;
        private bool esModificacion;
        public EstructuraPresentador(EstructuraPresupuestoRemuneracion estructuraPresupuestoRemuneracion, IEjeOperativoVista ejeOperativoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.estructuraPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.ejeOperativoVista = ejeOperativoVista;
            this.esModificacion = estructuraPresupuestoRemuneracion != null;
            this.estructuraPresupuestoRemuneracion = estructuraPresupuestoRemuneracion ?? new EstructuraPresupuestoRemuneracion();
        }
        public void IniciarDatos()
        {
            if (this.esModificacion)
            {
                ejeOperativoVista.descripcion = estructuraPresupuestoRemuneracion.descripcion;
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            estructuraPresupuestoRemuneracion.descripcion = ejeOperativoVista.descripcion.ToUpper();
            
            if (this.esModificacion)
            {
                estructuraPresupuestoRemuneracion.fechaEdita = DateTime.Now;
                estructuraPresupuestoRemuneracion.usuEdita = ejeOperativoVista.UsuarioOperacion.NomUsuario;
                resultado = estructuraPresupuestoRemuneracionServicio.Modificar(estructuraPresupuestoRemuneracion);
            }
            else
            {
                estructuraPresupuestoRemuneracion.fechaCrea = DateTime.Now;
                estructuraPresupuestoRemuneracion.usuCrea = ejeOperativoVista.UsuarioOperacion.NomUsuario;
                estructuraPresupuestoRemuneracion.estado = Estados.Activo;
                resultado = estructuraPresupuestoRemuneracionServicio.Nuevo(estructuraPresupuestoRemuneracion);
            }

            return resultado.esCorrecto;
        }
    }
}
