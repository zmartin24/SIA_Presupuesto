using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class PresupuestoRemuneracionPresentador
    {
        private readonly IPresupuestoRemuneracionVista presupuestoRemuneracionVista;
        private IPresupuestoRemuneracionServicio presupuestoRemuneracionServicio;
        private IPuestoPresupuestoServicio puestoPresupuestoServicio;
        private IEstructuraPresupuestoRemuneracionServicio estructuraServicio;
        private ProgramacionAnual programacionAnual;
        private bool esModificacion;
        public PresupuestoRemuneracionPresentador(ProgramacionAnual programacionAnual, IPresupuestoRemuneracionVista presupuestoRemuneracionVista)
        {
            this.programacionAnual = programacionAnual;
            IContenedor _Contenedor = new cContenedor();
            this.presupuestoRemuneracionVista = presupuestoRemuneracionVista;
            this.presupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IPresupuestoRemuneracionServicio)) as IPresupuestoRemuneracionServicio;
            this.puestoPresupuestoServicio = _Contenedor.Resolver(typeof(IPuestoPresupuestoServicio)) as IPuestoPresupuestoServicio;
            this.estructuraServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
            this.esModificacion = programacionAnual.idEstPreRem != null;
        }

        public void IniciarDatos()
        {
            var listaEst = estructuraServicio.TraerTodosActivos();
            presupuestoRemuneracionVista.listaEstructura = listaEst;
            if(listaEst!=null)
            {
                if (listaEst.Count > 0)
                    presupuestoRemuneracionVista.idEstPreRem = listaEst.First().idEstPreRem;
            }

            presupuestoRemuneracionVista.listaMesDesde = UtilitarioComun.ListarMeses();
            presupuestoRemuneracionVista.listaMesHasta = UtilitarioComun.ListarMeses();
            presupuestoRemuneracionVista.mesDesde = 1;
            presupuestoRemuneracionVista.mesHasta = 12;

            if(this.esModificacion)
            {
                presupuestoRemuneracionVista.idEstPreRem = (Int32)programacionAnual.idEstPreRem;
                presupuestoRemuneracionVista.mesDesde = (Int32)programacionAnual.mesDesdeRem;
                presupuestoRemuneracionVista.mesHasta = (Int32)programacionAnual.mesHastaRem;
            }
        }

        public void ObtenerDatosListado()
        {
            presupuestoRemuneracionVista.listaDatosPrincipales = 
                presupuestoRemuneracionServicio.TraerResultadoCalculoPresupuestoRemuneracion(this.programacionAnual.idProAnu, presupuestoRemuneracionVista.idEstPreRem);
        }
        public PuestoPresupuesto Buscar(int vid)
        {
            return puestoPresupuestoServicio.BuscarPorCodigo(vid);
        }

        public List<PuestoPresupuesto> Buscar(List<int> vids)
        {
            return puestoPresupuestoServicio.BuscarPorCodigo(vids);
        }

        public bool Calcular()
        {
            Resultado resultado = null;
            List<ResultadoCalculoPoco> listaResultado = presupuestoRemuneracionServicio.CalcularPresupuestoRemuneraciones(this.programacionAnual.idProAnu, presupuestoRemuneracionVista.idEstPreRem, presupuestoRemuneracionVista.mesDesde, presupuestoRemuneracionVista.mesHasta);

            if (listaResultado != null)
                if (!this.esModificacion)
                {
                    resultado = presupuestoRemuneracionServicio.Nuevo(listaResultado, presupuestoRemuneracionVista.idEstPreRem, this.programacionAnual.idProAnu, presupuestoRemuneracionVista.UsuarioOperacion.NomUsuario, presupuestoRemuneracionVista.mesDesde, presupuestoRemuneracionVista.mesHasta);
                    this.esModificacion = true;
                }
                else
                    resultado = presupuestoRemuneracionServicio.Modificar(listaResultado, presupuestoRemuneracionVista.idEstPreRem, this.programacionAnual.idProAnu, presupuestoRemuneracionVista.UsuarioOperacion.NomUsuario, presupuestoRemuneracionVista.mesDesde, presupuestoRemuneracionVista.mesHasta);
            else
                resultado = new Resultado();

            return resultado.esCorrecto;
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (presupuestoRemuneracionVista.puestoPresupuestos != null)
            {
                respuesta = this.presupuestoRemuneracionServicio.AnularPuestos(presupuestoRemuneracionVista.puestoPresupuestos, presupuestoRemuneracionVista.UsuarioOperacion.NomUsuario).esCorrecto;
            }
            return respuesta;
        }


    }
}
