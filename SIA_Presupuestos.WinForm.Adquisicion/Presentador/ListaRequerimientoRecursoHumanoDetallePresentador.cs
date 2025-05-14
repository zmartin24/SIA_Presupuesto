using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaRequerimientoRecursoHumanoDetallePresentador
    {
        private readonly IListaRequerimientoRecursoHumanoDetalleVista listaRequerimientoRecursoHumanoDetalleVista;
        private IRequerimientoRecursoHumanoServicio requerimientoRecursoHumanoServicio;
        private IPuestoRequerimientoServicio puestoRequerimientoServicio;
        private IEstructuraPresupuestoRemuneracionServicio estructuraServicio;
        private RequerimientoRecursoHumano requerimientoRecursoHumano;
        
        public ListaRequerimientoRecursoHumanoDetallePresentador(RequerimientoRecursoHumano requerimientoRecursoHumano, IListaRequerimientoRecursoHumanoDetalleVista listaRequerimientoRecursoHumanoDetalleVista)
        {
            this.requerimientoRecursoHumano = requerimientoRecursoHumano;
            IContenedor _Contenedor = new cContenedor();
            this.listaRequerimientoRecursoHumanoDetalleVista = listaRequerimientoRecursoHumanoDetalleVista;
            this.requerimientoRecursoHumanoServicio = _Contenedor.Resolver(typeof(IRequerimientoRecursoHumanoServicio)) as IRequerimientoRecursoHumanoServicio;
            this.puestoRequerimientoServicio = _Contenedor.Resolver(typeof(IPuestoRequerimientoServicio)) as IPuestoRequerimientoServicio;
            this.estructuraServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
        }

        public void IniciarDatos()
        {
            listaRequerimientoRecursoHumanoDetalleVista.listaMesDesde = UtilitarioComun.ListarMeses();
            listaRequerimientoRecursoHumanoDetalleVista.listaMesHasta = UtilitarioComun.ListarMeses();
            listaRequerimientoRecursoHumanoDetalleVista.mesDesde = 1;
            listaRequerimientoRecursoHumanoDetalleVista.mesHasta = 12;
        }

        public void ObtenerDatosListado()
        {
            listaRequerimientoRecursoHumanoDetalleVista.listaDatosPrincipales = 
                requerimientoRecursoHumanoServicio.TraerListaRequerimientoRecursoHumanoDetalle(this.requerimientoRecursoHumano.idReqRecHum);
        }
        public PuestoRequerimiento Buscar(int vid)
        {
            return puestoRequerimientoServicio.BuscarPorCodigo(vid);
        }

        //public List<PuestoPresupuesto> Buscar(List<int> vids)
        //{
        //    return puestoRequerimientoServicio.BuscarPorCodigo(vids);
        //}
        
        public bool Anular()
        {
            bool respuesta = false;
            if (listaRequerimientoRecursoHumanoDetalleVista.puestoRequerimiento != null)
            {
                //respuesta = this.requerimientoRecursoHumanoServicio.Anular(listaRequerimientoRecursoHumanoDetalleVista.puestoRequerimiento).esCorrecto;
                respuesta = true;
            }
            return respuesta;
        }


    }
}
