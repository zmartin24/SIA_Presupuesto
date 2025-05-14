using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Programacion.Vista;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaPuestoRequerimientoAnualPresentador
    {
        private readonly IListaPuestoRequerimientoAnualVista listaPuestoRequerimientoAnualVista;

        private IGeneralServicio generalServicio;
        private IPuestoRequerimientoServicio puestoRequerimientoServicio;
        private IProgramacionAnualServicio programacionServicio;

        public ListaPuestoRequerimientoAnualPresentador(IListaPuestoRequerimientoAnualVista listaPuestoRequerimientoAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.puestoRequerimientoServicio = _Contenedor.Resolver(typeof(IPuestoRequerimientoServicio)) as IPuestoRequerimientoServicio;
            this.programacionServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.listaPuestoRequerimientoAnualVista = listaPuestoRequerimientoAnualVista;
        } 

        public void Inicializar()
        {
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            listaPuestoRequerimientoAnualVista.listaPuestoRequerimientoAnual = this.puestoRequerimientoServicio.TraerListaPuestoRequerimientoAnual(listaPuestoRequerimientoAnualVista.programacionAnual.anio);
        }

        public bool GuardarPuestoRequerimientoEnProgramacionAnual(string codigos)
        {
            return this.puestoRequerimientoServicio.GuardarPuestoRequerimientoEnProgramacionAnual(
                                                                                    codigos, 
                                                                                    listaPuestoRequerimientoAnualVista.programacionAnual.idProAnu, 
                                                                                    this.listaPuestoRequerimientoAnualVista.UsuarioOperacion.NomUsuario
                                                                                    );   
        }
    }
}
