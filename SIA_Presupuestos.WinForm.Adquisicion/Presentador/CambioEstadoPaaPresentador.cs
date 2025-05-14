using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class CambioEstadoPaaPresentador
    {
        private readonly ICambioEstadoPaaVista cambioEstadoPaaVista;
        private IPlanAnualAdquisicionServicio programacionAnualServicio;
        private PlanAnualAdquisicion planAnualAdquisicion;
        public CambioEstadoPaaPresentador(PlanAnualAdquisicion planAnualAdquisicion, ICambioEstadoPaaVista cambioEstadoPaaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.cambioEstadoPaaVista = cambioEstadoPaaVista;
            this.planAnualAdquisicion = planAnualAdquisicion;
        }

        public void Inicializar()
        {
            cambioEstadoPaaVista.listaReporte = PredeterminadoHelper.ListarEstadosProgramacionAnual();
            if (planAnualAdquisicion.estado==10 || planAnualAdquisicion.estado == 11) cambioEstadoPaaVista.codEstado = planAnualAdquisicion.estado;
        }

        public bool Guardar()
        {
            bool resultado = false;
            this.planAnualAdquisicion.estado = cambioEstadoPaaVista.codEstado;
            this.planAnualAdquisicion.usuMod = cambioEstadoPaaVista.UsuarioOperacion.NomUsuario;
            this.planAnualAdquisicion.fechaMod = DateTime.Now;
            this.planAnualAdquisicion.fechaAprobacion = DateTime.Now;
            resultado = programacionAnualServicio.Modificar(this.planAnualAdquisicion).esCorrecto;

            return resultado;
        }
    }
}
