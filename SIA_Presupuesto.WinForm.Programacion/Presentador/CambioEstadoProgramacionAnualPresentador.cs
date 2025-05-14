using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
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
    public class CambioEstadoProgramacionAnualPresentador
    {
        private readonly ICambioEstadoProgramacionAnualVista cambioEstadoProgramacionAnualVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ProgramacionAnual programacionAnual;
        public CambioEstadoProgramacionAnualPresentador(ProgramacionAnual programacionAnual, ICambioEstadoProgramacionAnualVista cambioEstadoProgramacionAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.cambioEstadoProgramacionAnualVista = cambioEstadoProgramacionAnualVista;
            this.programacionAnual = programacionAnual;
        }

        public void Inicializar()
        {
            cambioEstadoProgramacionAnualVista.listaReporte = PredeterminadoHelper.ListarEstadosProgramacionAnual();
        }

        public bool Guardar()
        {
            bool resultado = false;
            this.programacionAnual.estado = cambioEstadoProgramacionAnualVista.codEstado;
            this.programacionAnual.usuEdita = cambioEstadoProgramacionAnualVista.UsuarioOperacion.NomUsuario;
            this.programacionAnual.fechaEdita = DateTime.Now;
            if(this.programacionAnual.estado == 10) this.programacionAnual.fechaAprobacion = DateTime.Now;
            resultado = programacionAnualServicio.Modificar(this.programacionAnual).esCorrecto;

            return resultado;
        }
    }
}
