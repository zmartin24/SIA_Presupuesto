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
    public class FormulaPresentador
    {
        private readonly IFormulaVista formulaVista;
        private IConceptoPresupuestoRemuneracionServicio conceptoPresupuestoRemuneracionServicio;
        private PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion;
        public FormulaPresentador(PropiedadPresupuestoRemuneracion PropiedadPresupuestoRemuneracion,  IFormulaVista formulaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.PropiedadPresupuestoRemuneracion = PropiedadPresupuestoRemuneracion;
            this.conceptoPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IConceptoPresupuestoRemuneracionServicio)) as IConceptoPresupuestoRemuneracionServicio;
            this.formulaVista = formulaVista;
        }

        public void IniciarDatos()
        {
            if (PropiedadPresupuestoRemuneracion != null)
                formulaVista.valor = PropiedadPresupuestoRemuneracion.valor;
            formulaVista.listaDatosPrincipales = conceptoPresupuestoRemuneracionServicio.TraerConceptosEstructura(PropiedadPresupuestoRemuneracion.idEstPreRem, PropiedadPresupuestoRemuneracion.idConPreRem);
        }

        public bool GuardarDatos()
        {
            PropiedadPresupuestoRemuneracion.valor = formulaVista.valor;
            return true;
        }
    }
}
