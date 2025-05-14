using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class GrupoPresupuestoPresentador
    {
        private readonly IGrupoPresupuestoVista  grupoPresupuestoVista;

        private GrupoPresupuestoPoco grupoPresupuesto;
        private bool esModificacion;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IFuenteFinanciamientoServicio fuenteFinanciamientoServicio;

        public GrupoPresupuestoPresentador(GrupoPresupuestoPoco grupoPresupuesto, IGrupoPresupuestoVista grupoPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.fuenteFinanciamientoServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.esModificacion = grupoPresupuesto != null;
            this.grupoPresupuestoVista = grupoPresupuestoVista;
            this.grupoPresupuesto = grupoPresupuesto ?? new GrupoPresupuestoPoco();
        }

        public void IniciarDatos()
        {
            grupoPresupuestoVista.listaFuente = fuenteFinanciamientoServicio.TraerTodosActivos();
            grupoPresupuestoVista.listaAgrupamiento = PredeterminadoHelper.ListarAgrupamientoPresupuesto();
            if (this.esModificacion)
            {
                grupoPresupuestoVista.idGruPre = grupoPresupuesto.idGrupoPresupuesto;
                grupoPresupuestoVista.codigo = grupoPresupuesto.codigo;
                grupoPresupuestoVista.descripcion = grupoPresupuesto.descripcion;
                grupoPresupuestoVista.abreviatura = grupoPresupuesto.abreviatura;
                grupoPresupuestoVista.observacion = grupoPresupuesto.observacion;
                grupoPresupuestoVista.esEncargo = (grupoPresupuesto.esEncargo == "Si") ? true : false;
                grupoPresupuestoVista.idFuenteFinanciamiento = grupoPresupuesto.idFuenteFinanciamiento.GetValueOrDefault();
                grupoPresupuestoVista.agrupamiento = grupoPresupuesto.grupo;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            GrupoPresupuesto ogrupo = new GrupoPresupuesto();
            ogrupo.idGruPre = grupoPresupuestoVista.idGruPre;
            ogrupo.codigo = grupoPresupuestoVista.codigo;
            ogrupo.descripcion = grupoPresupuestoVista.descripcion;
            ogrupo.abreviatura = grupoPresupuestoVista.abreviatura;
            ogrupo.observacion = grupoPresupuestoVista.observacion;
            ogrupo.esEncargo = grupoPresupuestoVista.esEncargo;
            ogrupo.idFueFin = grupoPresupuestoVista.idFuenteFinanciamiento;
            ogrupo.grupo = grupoPresupuestoVista.agrupamiento;
            if (this.esModificacion)
            {
                ogrupo.fechaEdita = DateTime.Now;
                ogrupo.usuEdita = grupoPresupuestoVista.UsuarioOperacion.NomUsuario;
                resultado = grupoPresupuestoServicio.Modificar(ogrupo);
            }
            else
            {
                ogrupo.fechaCrea = DateTime.Now;
                ogrupo.usuCrea = grupoPresupuestoVista.UsuarioOperacion.NomUsuario;
                ogrupo.estado = Estados.Activo;
                resultado = grupoPresupuestoServicio.Nuevo(ogrupo);
            }

            return resultado.esCorrecto;
        }
    }
}
