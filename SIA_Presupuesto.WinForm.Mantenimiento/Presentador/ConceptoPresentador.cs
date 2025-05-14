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
    public class ConceptoPresentador
    {
        private readonly IConceptoVista conceptoVista;

        private IConceptoPresupuestoRemuneracionServicio conceptoPresupuestoRemuneracionServicio;
        private IGeneralServicio generalServicio;
        private IOrigenConceptoServicio origenServicio;

        private ConceptoPresupuestoRemuneracion conceptoPresupuestoRemuneracion;
        private bool esModificacion;
        public ConceptoPresentador(ConceptoPresupuestoRemuneracion conceptoPresupuestoRemuneracion, IConceptoVista conceptoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.conceptoPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IConceptoPresupuestoRemuneracionServicio)) as IConceptoPresupuestoRemuneracionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.origenServicio = _Contenedor.Resolver(typeof(IOrigenConceptoServicio)) as IOrigenConceptoServicio;

            this.conceptoVista = conceptoVista;
            this.esModificacion = conceptoPresupuestoRemuneracion != null;
            this.conceptoPresupuestoRemuneracion = conceptoPresupuestoRemuneracion ?? new ConceptoPresupuestoRemuneracion();
        }

        public void IniciarDatos()
        {
            conceptoVista.listaOrigenes = origenServicio.TraerTodosActivos();
            conceptoVista.listaTipo = PredeterminadoHelper.ListarTipoConcepto();
            if (this.esModificacion)
            {
                conceptoVista.descripcion = conceptoPresupuestoRemuneracion.descripcion;
                conceptoVista.idOriCon = (Int32)conceptoPresupuestoRemuneracion.idOriCon;
                conceptoVista.tipo = conceptoPresupuestoRemuneracion.tipo;
                conceptoVista.abreviatura = conceptoPresupuestoRemuneracion.abreviatura;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            conceptoPresupuestoRemuneracion.descripcion = conceptoVista.descripcion.ToUpper();
            conceptoPresupuestoRemuneracion.tipo = conceptoVista.tipo;
            conceptoPresupuestoRemuneracion.idOriCon = conceptoVista.idOriCon;
            conceptoPresupuestoRemuneracion.abreviatura = conceptoVista.abreviatura;
            if (this.esModificacion)
            {
                conceptoPresupuestoRemuneracion.fechaEdita = DateTime.Now;
                conceptoPresupuestoRemuneracion.usuEdita = conceptoVista.UsuarioOperacion.NomUsuario;
                resultado = conceptoPresupuestoRemuneracionServicio.Modificar(conceptoPresupuestoRemuneracion);
            }
            else
            {
                conceptoPresupuestoRemuneracion.fechaCrea = DateTime.Now;
                conceptoPresupuestoRemuneracion.usuCrea = conceptoVista.UsuarioOperacion.NomUsuario;
                conceptoPresupuestoRemuneracion.estado = Estados.Activo;
                resultado = conceptoPresupuestoRemuneracionServicio.Nuevo(conceptoPresupuestoRemuneracion);
            }

            return resultado.esCorrecto;
        }
    }
}
