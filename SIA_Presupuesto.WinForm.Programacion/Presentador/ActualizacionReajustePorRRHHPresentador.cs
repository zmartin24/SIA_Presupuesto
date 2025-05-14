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
    public class ActualizacionReajustePorRRHHPresentador
    {
        private readonly IActualizacionReajustePorRRHHVista actualizacionPorRRHHVista;
        private IGeneralServicio generalServicio;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private int idReaMenPro;
        private int idProAnu;
        public ActualizacionReajustePorRRHHPresentador(int idProAnu, int idReaMenPro, IActualizacionReajustePorRRHHVista actualizacionPorRRHHVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;

            this.idReaMenPro = idReaMenPro;
            this.idProAnu = idProAnu;
            this.actualizacionPorRRHHVista = actualizacionPorRRHHVista;
        }

        public void Inicializar()
        {
           
        }

        public List<int> listaIDsAreas()
        {
            return reajusteMensualProgramacionServicio.TraerListaReajusteMensualAreas(this.idReaMenPro);
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

            string codigos = this.actualizacionPorRRHHVista.IndicaSoloReajuste ? string.Empty : string.Join("~", this.actualizacionPorRRHHVista.listaAreasSeleccionadas.Select(s=>s.idArea));
            reajusteMensualProgramacionServicio.GuardarDetalleReajusteRRHH(this.idProAnu, this.idReaMenPro, codigos, actualizacionPorRRHHVista.UsuarioOperacion.NomUsuario, 
                actualizacionPorRRHHVista.IndicaElimina);

            return resultado;
        }
    }
}
