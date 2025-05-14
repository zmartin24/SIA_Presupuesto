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
    public class ParametroPresentador
    {
        private readonly IParametroVista ejeOperativoVista;

        private IParametroPresupuestoRemuneracionServicio parametroPresupuestoRemuneracionServicio;
        private IConceptoPresupuestoRemuneracionServicio conceptoPresupuestoRemuneracionServicio;
        private IGeneralServicio generalServicio;

        private ParametroPresupuestoRemuneracion parametroPresupuestoRemuneracion;
        private bool esModificacion;
        public ParametroPresentador(ParametroPresupuestoRemuneracion parametroPresupuestoRemuneracion, IParametroVista ejeOperativoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.parametroPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IParametroPresupuestoRemuneracionServicio)) as IParametroPresupuestoRemuneracionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.conceptoPresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IConceptoPresupuestoRemuneracionServicio)) as IConceptoPresupuestoRemuneracionServicio;

            this.ejeOperativoVista = ejeOperativoVista;
            this.esModificacion = parametroPresupuestoRemuneracion != null;
            this.parametroPresupuestoRemuneracion = parametroPresupuestoRemuneracion ?? new ParametroPresupuestoRemuneracion();
        }
        public void IniciarDatos()
        {
            ejeOperativoVista.listaConceptos = conceptoPresupuestoRemuneracionServicio.TraerTodosActivos("PAR");
            ejeOperativoVista.listaMonedas = generalServicio.ListaMonedas();

            if (this.esModificacion)
            {
                ejeOperativoVista.idConPreRem = parametroPresupuestoRemuneracion.idConPreRem;
                ejeOperativoVista.importe = parametroPresupuestoRemuneracion.importe;
                ejeOperativoVista.idMoneda = (Int32)parametroPresupuestoRemuneracion.idTipMon;
                //ejeOperativoVista. = parametroPresupuestoRemuneracion.;
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            parametroPresupuestoRemuneracion.idTipMon = ejeOperativoVista.idMoneda;
            parametroPresupuestoRemuneracion.idConPreRem = ejeOperativoVista.idConPreRem;
            parametroPresupuestoRemuneracion.importe = ejeOperativoVista.importe;

            if (this.esModificacion)
            {
                parametroPresupuestoRemuneracion.fechaEdita = DateTime.Now;
                parametroPresupuestoRemuneracion.usuEdita = ejeOperativoVista.UsuarioOperacion.NomUsuario;
                resultado = parametroPresupuestoRemuneracionServicio.Modificar(parametroPresupuestoRemuneracion);
            }
            else
            {
                parametroPresupuestoRemuneracion.fechaCrea = DateTime.Now;
                parametroPresupuestoRemuneracion.usuCrea = ejeOperativoVista.UsuarioOperacion.NomUsuario;
                parametroPresupuestoRemuneracion.estado = Estados.Activo;
                resultado = parametroPresupuestoRemuneracionServicio.Nuevo(parametroPresupuestoRemuneracion);
            }

            return resultado.esCorrecto;
        }
    }
}
