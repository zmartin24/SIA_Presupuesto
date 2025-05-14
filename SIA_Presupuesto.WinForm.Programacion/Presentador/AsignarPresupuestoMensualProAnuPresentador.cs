using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class AsignarPresupuestoMensualProAnuPresentador
    {
        private readonly IAsignarPresupuestoMensualProAnuVista asignarPresupuestoMensualProAnuVista;

        private ProgramacionAnual programacionAnual;
        private ISubpresupuestoServicio subPresupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private UsuarioOperacion usuarioOperacion;

        public AsignarPresupuestoMensualProAnuPresentador(ProgramacionAnual programacionAnual, UsuarioOperacion usuarioOperacion, IAsignarPresupuestoMensualProAnuVista asignarPresupuestoMensualProAnuVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.subPresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.usuarioOperacion = usuarioOperacion;
            this.asignarPresupuestoMensualProAnuVista = asignarPresupuestoMensualProAnuVista;
            this.programacionAnual = programacionAnual ?? new ProgramacionAnual();
        }

        public void IniciarDatos()
        {
            this.asignarPresupuestoMensualProAnuVista.desPresupuesto = programacionAnual.descripcion;
            LlenarComboMes();
        }

        private void LlenarComboMes()
        {
            List<ItemPoco> listaMeses = new List<ItemPoco>();

            listaMeses.Add(new ItemPoco() { id = 1, nombre = "Enero" });
            listaMeses.Add(new ItemPoco() { id = 2, nombre = "Febrero" });
            listaMeses.Add(new ItemPoco() { id = 3, nombre = "Marzo" });
            listaMeses.Add(new ItemPoco() { id = 4, nombre = "Abril" });
            listaMeses.Add(new ItemPoco() { id = 5, nombre = "Mayo" });
            listaMeses.Add(new ItemPoco() { id = 6, nombre = "Junio" });
            listaMeses.Add(new ItemPoco() { id = 7, nombre = "Julio" });
            listaMeses.Add(new ItemPoco() { id = 8, nombre = "Agosto" });
            listaMeses.Add(new ItemPoco() { id = 9, nombre = "Septiembre" });
            listaMeses.Add(new ItemPoco() { id = 10, nombre = "Octubre" });
            listaMeses.Add(new ItemPoco() { id = 11, nombre = "Noviembre" });
            listaMeses.Add(new ItemPoco() { id = 12, nombre = "Diciembre" });

            asignarPresupuestoMensualProAnuVista.listaMes = listaMeses.OrderBy(t => t.id).ToList();
            asignarPresupuestoMensualProAnuVista.mes = listaMeses.OrderBy(t => t.id).FirstOrDefault().id;
        }

        public void Llenar_ComboSubpresupuesto()
        {
            this.asignarPresupuestoMensualProAnuVista.opcion = 1;//Inicio de actualizaicon de grillas
            this.asignarPresupuestoMensualProAnuVista.idSubpresupuesto = -1;
            var listaSubpresupuesto = subPresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(programacionAnual.idProAnu).Where(x => x.mes == asignarPresupuestoMensualProAnuVista.mes).ToList();

            if(listaSubpresupuesto.Count>0)
            {
                this.asignarPresupuestoMensualProAnuVista.listaSubpresupuesto = listaSubpresupuesto;
                this.asignarPresupuestoMensualProAnuVista.idSubpresupuesto = listaSubpresupuesto.OrderBy(x=>x.idSubpresupuesto).FirstOrDefault().idSubpresupuesto;
            }
        }

        public void ActualizarGrillas()
        {
            this.asignarPresupuestoMensualProAnuVista.listaDetalleProAnu = this.programacionAnualServicio.TraerListaProgramacionAnualDetallePorMes(programacionAnual.idProAnu, this.asignarPresupuestoMensualProAnuVista.mes, null);
            this.asignarPresupuestoMensualProAnuVista.listaDetalleSubPre = this.programacionAnualServicio.TraerListaProgramacionAnualDetallePorMes(programacionAnual.idProAnu, this.asignarPresupuestoMensualProAnuVista.mes, this.asignarPresupuestoMensualProAnuVista.idSubpresupuesto);
        }
        
        public void ActualizarGriDetalleSubPresupuesto()
        {
            this.asignarPresupuestoMensualProAnuVista.listaDetalleSubPre = this.programacionAnualServicio.TraerListaProgramacionAnualDetallePorMes(programacionAnual.idProAnu, this.asignarPresupuestoMensualProAnuVista.mes, this.asignarPresupuestoMensualProAnuVista.idSubpresupuesto);
        }

        public ProgramacionAnualDetalleMes BuscarProgramacionAnualDetalleMes(int idProAnuDetMes)
        {
            return this.programacionAnualServicio.BuscarPorCodigoDetalleMes(idProAnuDetMes);
        }
        
        public bool AsignaSubpresupuesto(List<ProgramacionAnualDetallePorMesPres> lista, int? idSubpresupuesto)
        {
            Resultado resultado = null;
            this.asignarPresupuestoMensualProAnuVista.opcion = 1;
            resultado = programacionAnualServicio.AsginarSubpresupuesto(lista, idSubpresupuesto, this.usuarioOperacion.NomUsuario);

            return resultado.esCorrecto;
        }
    }
}
