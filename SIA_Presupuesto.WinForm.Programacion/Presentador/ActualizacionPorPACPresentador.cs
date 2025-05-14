using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ActualizacionPorPACPresentador
    {
        private readonly IActualizacionPorPACVista actualizacionPorPACVista;
        private IGeneralServicio generalServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private int idProAnu;
        public ActualizacionPorPACPresentador(int idProAnu, IActualizacionPorPACVista actualizacionPorPACVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.idProAnu = idProAnu;
            this.actualizacionPorPACVista = actualizacionPorPACVista;
        }

        public void Inicializar()
        {
           
        }

        public List<int> listaIDsAreas()
        {
            return programacionAnualServicio.TraerListaProgramacionAnualAreas(this.idProAnu);
        }

        public List<Area> listaAreas()
        {
            return generalServicio.ListaAreas();
        }

        public List<Subdireccion> listaSubdirecciones()
        {
            return generalServicio.ListaSubDirecciones();
        }

        public List<Direccion> listaDirecciones()
        {
            return generalServicio.ListaDirecciones();
        }

        public bool Guardar()
        {
            bool resultado = true;
            //this.programacionAnual.estado = cambioEstadoProgramacionAnualVista.codEstado;
            //this.programacionAnual.usuEdita = cambioEstadoProgramacionAnualVista.UsuarioOperacion.NomUsuario;
            //this.programacionAnual.fechaEdita = DateTime.Now;

            string codigos = string.Join("~", this.actualizacionPorPACVista.listaAreasSeleccionadas.Select(s=>s.idArea));
            programacionAnualServicio.GuardarDetalleProgramacionAnual(this.idProAnu, codigos, actualizacionPorPACVista.UsuarioOperacion.NomUsuario, 
                actualizacionPorPACVista.IndicaElimina);

            return resultado;
        }
    }
}
