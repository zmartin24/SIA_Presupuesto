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
    public class ActualizacionPorRRHHPresentador
    {
        private readonly IActualizacionPorRRHHVista actualizacionPorRRHHVista;
        private IGeneralServicio generalServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private int idProAnu;
        public ActualizacionPorRRHHPresentador(int idProAnu, IActualizacionPorRRHHVista actualizacionPorRRHHVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.idProAnu = idProAnu;
            this.actualizacionPorRRHHVista = actualizacionPorRRHHVista;
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

            string codigos = actualizacionPorRRHHVista.IndicaSoloPresupuesto ? string.Empty : string.Join("~", this.actualizacionPorRRHHVista.listaAreasSeleccionadas.Select(s=>s.idArea));

            programacionAnualServicio.GuardarDetalleProgramacionAnualRRHH(this.idProAnu, codigos, actualizacionPorRRHHVista.UsuarioOperacion.NomUsuario, 
                actualizacionPorRRHHVista.IndicaElimina);

            return resultado;
        }
    }
}
