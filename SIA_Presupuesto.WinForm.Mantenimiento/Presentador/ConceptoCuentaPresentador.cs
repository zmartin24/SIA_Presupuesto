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
    public class ConceptoCuentaPresentador
    {
        private readonly IConceptoCuentaVista conceptoCuentaVista;
        private IGeneralServicio generalServicio;
        private IConceptoCuentaContableServicio conceptoCuentaServicio;
        private IConceptoPresupuestoRemuneracionServicio conceptoServicio;
        private ConceptoCuentaContable conceptoCuenta;
        private bool esModificacion;
        private ConceptoPresupuestoRemuneracion concepto;
        private UsuarioOperacion UsuarioOperacion;
        public ConceptoCuentaPresentador(ConceptoPresupuestoRemuneracion concepto, ConceptoCuentaContable conceptoCuenta, UsuarioOperacion UsuarioOperacion, IConceptoCuentaVista conceptoCuentaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.UsuarioOperacion = UsuarioOperacion;
            this.concepto = concepto;
            this.conceptoCuentaVista = conceptoCuentaVista;
            this.conceptoCuenta = conceptoCuenta;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.conceptoCuentaServicio = _Contenedor.Resolver(typeof(IConceptoCuentaContableServicio)) as IConceptoCuentaContableServicio;
            this.conceptoServicio = _Contenedor.Resolver(typeof(IConceptoPresupuestoRemuneracionServicio)) as IConceptoPresupuestoRemuneracionServicio;


            this.esModificacion = conceptoCuenta != null;
            this.conceptoCuenta = conceptoCuenta ?? new ConceptoCuentaContable();
        }

        public void IniciarDatos()
        {
            conceptoCuentaVista.listaCategoria = generalServicio.TraerDatosCategoriaLaboral();
            conceptoCuentaVista.listaCondicion = generalServicio.TraerDatosCondicionLaboral();
            conceptoCuentaVista.listaRegimen = generalServicio.TraerDatosRegimenLaboral();
            conceptoCuentaVista.listaCuentaContable = generalServicio.ListaCuentaContable(DateTime.Now.Year);

            conceptoCuentaVista.listaConceptos = conceptoServicio.TraerTodosActivos();
            conceptoCuentaVista.idConPreRem = concepto.idConPreRem;

            if (this.esModificacion)
            {
                conceptoCuentaVista.idConPreRem = conceptoCuenta.idConPreRem;
                conceptoCuentaVista.idCatLab = (Int32)conceptoCuenta.idCatLab;
                conceptoCuentaVista.idConLab = (Int32)conceptoCuenta.idConLab;
                conceptoCuentaVista.idRegLab = (Int32)conceptoCuenta.idRegLab;

                var cuenta = generalServicio.BuscarCuentaContable(conceptoCuenta.numCuenta, DateTime.Now.Year);
                if (cuenta != null)
                    conceptoCuentaVista.idCueCon = cuenta.idCueCon;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            conceptoCuenta.idConPreRem = conceptoCuentaVista.idConPreRem;
            conceptoCuenta.idCatLab = conceptoCuentaVista.idCatLab;
            conceptoCuenta.idConLab = conceptoCuentaVista.idConLab;
            conceptoCuenta.idRegLab = conceptoCuentaVista.idRegLab;
            conceptoCuenta.numCuenta = conceptoCuentaVista.numCuenta;

            if (this.esModificacion)
            {
                conceptoCuenta.fechaEdita = DateTime.Now;
                conceptoCuenta.usuEdita = UsuarioOperacion.NomUsuario;
                resultado = conceptoCuentaServicio.Modificar(conceptoCuenta);
            }
            else
            {
                conceptoCuenta.fechaCrea = DateTime.Now;
                conceptoCuenta.usuCrea = UsuarioOperacion.NomUsuario;
                conceptoCuenta.estado = Estados.Activo;
                resultado = conceptoCuentaServicio.Nuevo(conceptoCuenta);
            }

            return resultado.esCorrecto;
        }
    }
}
