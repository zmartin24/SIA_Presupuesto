using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaPacDetallePresentador
    {
        private readonly IListaPacDetalleVista listaPacDetalleVista;

        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGeneralServicio generalServicio;
        
        public ListaPacDetallePresentador(IListaPacDetalleVista listaPacDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.listaPacDetalleVista = listaPacDetalleVista;
        }
        private bool esNuevaArea;

        public void CargarServicios()
        {
            this.planAnualAdquisicionServicio = IoCHelper.ResolverIoC<IPlanAnualAdquisicionServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
        }

        public void ObtenerDatosListado()
        {
            listaPacDetalleVista.listaDatosPrincipales = planAnualAdquisicionServicio.TraerListaPlanAnualAdquisicionRequerimiento(listaPacDetalleVista.idPac); 
        }

        public void Iniciar()
        {
            ObtenerDatosListado();
        }

        //Detalle
        public void IniciarDatos(int id)
        {
            LlenarCombos();
            PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento = this.planAnualAdquisicionServicio.BuscarReqPorCodigo(id);
            if (planAnualAdquisicionRequerimiento == null)
                return;
        }

        private void LlenarCombos()
        {
        }

        public string BuscarSimboloMoneda(int idPac)
        {
            string moneda = string.Empty;
            var pac = this.planAnualAdquisicionServicio.Buscar(idPac);
            if(pac != null)
            {
                var objmoneda = generalServicio.BuscarMoneda((Int32)pac.idMoneda);
                if (objmoneda != null)
                    moneda = objmoneda.abreviatura;
            }
            return moneda;
        }

        private bool esModificacion;
        public Resultado GuardarDatos(string args)
        {
            Resultado resultado = null;
            
            return resultado;
        }

        public void AsignarProducto(Producto producto)
        {
        }

        public void ObtenerDatosProductos()
        {
        }

        public int BuscarIDUnidadProducto(int id)
        {
            int idUnidad = 0;
            var producto = generalServicio.BuscarProducto(id);
            if (producto != null)
            {
                idUnidad = producto.idUnidad;
            }
            return idUnidad;
        }

        public PlanAnualAdquisicionRequerimiento BuscarPacReq(int id)
        {
            return this.planAnualAdquisicionServicio.BuscarReqPorCodigo(id);
        }

        public PlanAnualAdquisicionDetalle BuscarDetalle(int id)
        {
            return this.planAnualAdquisicionServicio.BuscarDetallePorCodigo(id);
        }
    }
}

