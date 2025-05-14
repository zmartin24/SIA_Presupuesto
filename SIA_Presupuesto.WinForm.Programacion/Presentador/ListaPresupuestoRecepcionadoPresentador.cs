using DevExpress.XtraReports.UI;
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
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaPresupuestoRecepcionadoPresentador
    {
        private readonly IListaPresupuestoRecepcionadoVista listaPresupuestoRecepcionadoVista;
        private IPresupuestoRecepcionadoServicio presupuestoRecepcionadoServicio;

        public ListaPresupuestoRecepcionadoPresentador(IListaPresupuestoRecepcionadoVista IListaPresupuestoRecepcionadoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.presupuestoRecepcionadoServicio = _Contenedor.Resolver(typeof(IPresupuestoRecepcionadoServicio)) as IPresupuestoRecepcionadoServicio;
            this.listaPresupuestoRecepcionadoVista = IListaPresupuestoRecepcionadoVista;
        }

        public void Iniciar()
        {
            int ultimoAnio = DateTime.Now.Year;

            int ultimoMes = DateTime.Now.Month;

            List<ItemPoco> listaAnios = new List<ItemPoco>();

            for (int i = 2004; i <= ultimoAnio; i++)
            {
                listaAnios.Add(new ItemPoco() { id = i, nombre = i.ToString() });
            }

            List<ItemPoco> listaMeses = new List<ItemPoco>();

            listaMeses.Add(new ItemPoco() { id = 0, nombre = "Seleccione" });
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

            listaPresupuestoRecepcionadoVista.listaAnios = listaAnios.OrderByDescending(t => t.id).ToList();
            listaPresupuestoRecepcionadoVista.anio = ultimoAnio;
            listaPresupuestoRecepcionadoVista.listaMesesInicio = listaMeses;
            listaPresupuestoRecepcionadoVista.listaMesesFin = listaMeses;
            listaPresupuestoRecepcionadoVista.mesInicio = 1;
            listaPresupuestoRecepcionadoVista.mesFin = ultimoMes;
           
        }

        public void ObtenerDatosListado()
        {
            //if(listaPresupuestoRecepcionadoVista.mes != null)
            //{
                List<PresupuestoRecepcionadoPoco> oLista = presupuestoRecepcionadoServicio.listarTodos(listaPresupuestoRecepcionadoVista.anio, listaPresupuestoRecepcionadoVista.mesInicio,listaPresupuestoRecepcionadoVista.mesFin);
                listaPresupuestoRecepcionadoVista.listaDatosPrincipales = oLista;
            //}
        }

        public void listarDetalleRecepcionados(int idGrupo)
        {
            List<PresupuestoRecepcionadoPoco> oLista = presupuestoRecepcionadoServicio.listarDetalleRecepcionados(idGrupo);

            listaPresupuestoRecepcionadoVista.listaDatosPrincipales = oLista;

        }
        public bool AnularRegistro()
        {
            bool respuesta = false;
            if (listaPresupuestoRecepcionadoVista.PresupuestoRecepcionado != null)
                respuesta = this.presupuestoRecepcionadoServicio.Eliminar(listaPresupuestoRecepcionadoVista.PresupuestoRecepcionado.idGruPre, listaPresupuestoRecepcionadoVista.PresupuestoRecepcionado.anio).esCorrecto;
            return respuesta;
        }
        public PresupuestoRecepcionado Buscar(int id)
        {
            return new PresupuestoRecepcionado();
          
        }
    }
}
