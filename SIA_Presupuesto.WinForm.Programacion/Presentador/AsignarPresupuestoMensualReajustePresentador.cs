using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class AsignarPresupuestoMensualReajustePresentador
    {
        private readonly IAsignarPresupuestoMensualReajusteVista asignarPresupuestoMensualReajusteVista;

        private ReajusteMensualProgramacion reajusteMensualProgramacion;
        private ISubpresupuestoServicio subPresupuestoServicio;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private UsuarioOperacion usuarioOperacion;

        public AsignarPresupuestoMensualReajustePresentador(ReajusteMensualProgramacion reajusteMensualProgramacion, UsuarioOperacion usuarioOperacion, IAsignarPresupuestoMensualReajusteVista asignarPresupuestoMensualReajusteVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.subPresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;

            this.usuarioOperacion = usuarioOperacion;
            this.asignarPresupuestoMensualReajusteVista = asignarPresupuestoMensualReajusteVista;
            this.reajusteMensualProgramacion = reajusteMensualProgramacion ?? new ReajusteMensualProgramacion();
        }

        public void IniciarDatos()
        {
            this.asignarPresupuestoMensualReajusteVista.desPresupuesto = reajusteMensualProgramacion.descripcion;
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

            asignarPresupuestoMensualReajusteVista.listaMes = listaMeses.OrderBy(t => t.id).Where(x => x.id >= reajusteMensualProgramacion.mesReajuste).ToList();
            asignarPresupuestoMensualReajusteVista.mes = reajusteMensualProgramacion.mesReajuste;//listaMeses.OrderBy(t => t.id).FirstOrDefault().id;
        }

        public void Llenar_ComboSubpresupuesto()
        {
            this.asignarPresupuestoMensualReajusteVista.opcion = 1;//Inicio de actualizaicon de grillas
            this.asignarPresupuestoMensualReajusteVista.listaSubpresupuesto = null;
            this.asignarPresupuestoMensualReajusteVista.idSubpresupuesto = -1;
            
            var listaSubpresupuesto = subPresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(reajusteMensualProgramacion.idProAnu).Where(x => x.mes == asignarPresupuestoMensualReajusteVista.mes).ToList();
            
            if (listaSubpresupuesto.Count > 0)
            {
                this.asignarPresupuestoMensualReajusteVista.listaSubpresupuesto = listaSubpresupuesto;
                this.asignarPresupuestoMensualReajusteVista.idSubpresupuesto = listaSubpresupuesto.OrderBy(x => x.idSubpresupuesto).FirstOrDefault().idSubpresupuesto;
            }
        }

        public void ActualizarGrillas()
        {
            this.asignarPresupuestoMensualReajusteVista.listaDetalleReajusteMensual = this.reajusteMensualProgramacionServicio.TraerListaReajusteMensualDetallePorMes(reajusteMensualProgramacion.idReaMenPro, this.asignarPresupuestoMensualReajusteVista.mes, null);
            this.asignarPresupuestoMensualReajusteVista.listaDetalleSubPre = this.reajusteMensualProgramacionServicio.TraerListaReajusteMensualDetallePorMes(reajusteMensualProgramacion.idReaMenPro, this.asignarPresupuestoMensualReajusteVista.mes, this.asignarPresupuestoMensualReajusteVista.idSubpresupuesto);
        }
        
        public void ActualizarGriDetalleSubPresupuesto()
        {
            this.asignarPresupuestoMensualReajusteVista.listaDetalleSubPre = this.reajusteMensualProgramacionServicio.TraerListaReajusteMensualDetallePorMes(reajusteMensualProgramacion.idReaMenPro, this.asignarPresupuestoMensualReajusteVista.mes, this.asignarPresupuestoMensualReajusteVista.idSubpresupuesto);
        }

        public ReajusteMensualDetalleMes BuscarProgramacionAnualDetalleMes(int idReaMenDetMes)
        {
            return this.reajusteMensualProgramacionServicio.BuscarPorCodigoDetalleMes(idReaMenDetMes);
        }
        
        public bool AsignaSubpresupuesto(List<ReajusteMensualDetallePorMesPres> lista, int? idSubpresupuesto)
        {
            Resultado resultado = null;
            this.asignarPresupuestoMensualReajusteVista.opcion = 1;
            resultado = reajusteMensualProgramacionServicio.AsginarSubpresupuesto(lista, idSubpresupuesto, this.usuarioOperacion.NomUsuario);

            return resultado.esCorrecto;
        }
    }
}
