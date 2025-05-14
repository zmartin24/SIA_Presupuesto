using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Ayuda;
using Utilitario.Util;
using System;
using SIA_Presupuesto.Negocio.Servicios;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ActualizarPorRequerimientoBienServicioPresentador
    {
        private readonly IActualizarPorRequerimientoBienServicioVista actualizarPorRequerimientoBienServicioVista;

        private IGeneralServicio generalServicio;
        private IPeriodoServicio periodoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private int idProAnu;

        public ActualizarPorRequerimientoBienServicioPresentador(int idProAnu, IActualizarPorRequerimientoBienServicioVista actualizarPorRequerimientoBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.actualizarPorRequerimientoBienServicioVista = actualizarPorRequerimientoBienServicioVista;
            this.idProAnu = idProAnu;
        }
        public void Inicializar()
        {
            this.actualizarPorRequerimientoBienServicioVista.listaAnio = UtilitarioComun.ListarAnios(this.periodoServicio.ObtenerActivo().anio, 2018);
            this.actualizarPorRequerimientoBienServicioVista.anio = DateTime.Now.Year;
        }
        public bool Guardar()
        {
            bool resultado = true;
           
            this.programacionAnualServicio.GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(this.idProAnu, this.actualizarPorRequerimientoBienServicioVista.idsReqBienSer, this.actualizarPorRequerimientoBienServicioVista.UsuarioOperacion.NomUsuario);

            return resultado;
        }
    }
}
