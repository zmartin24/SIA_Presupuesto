using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class RequerimientoBienServicioDetPresentador
    {
        private readonly IRequerimientoBienServicioDetVista requerimientoBienServicioDetVista;
        private IRequerimientoBienServicioServicio requerimientoBienServicioServicio;
        private IGeneralServicio generalServicio;
        private RequerimientoBienServicioDetalle requerimientoBienServicioDetalle;
        private bool esModificacion;
        //private bool esNuevaArea;
        private Producto producto;
        private RequerimientoBienServicio RequerimientoBienServicio;
        public RequerimientoBienServicioDetPresentador(RequerimientoBienServicioDetalle requerimientoBienServicioDetalle, RequerimientoBienServicio RequerimientoBienServicio, IRequerimientoBienServicioDetVista requerimientoBienServicioDetVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.requerimientoBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.requerimientoBienServicioDetVista = requerimientoBienServicioDetVista;
            this.RequerimientoBienServicio = RequerimientoBienServicio;
            this.esModificacion = requerimientoBienServicioDetalle != null;
            this.requerimientoBienServicioDetalle = requerimientoBienServicioDetalle ?? new RequerimientoBienServicioDetalle();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            if (this.esModificacion)
            {
                requerimientoBienServicioDetVista.idUnidad = requerimientoBienServicioDetalle.idUnidad;
                requerimientoBienServicioDetVista.descripcion = requerimientoBienServicioDetalle.descripcion;
                requerimientoBienServicioDetVista.justificacion = requerimientoBienServicioDetalle.justificacion;
                requerimientoBienServicioDetVista.precio = requerimientoBienServicioDetalle.precio;
                requerimientoBienServicioDetVista.idCueCon = requerimientoBienServicioDetalle.idCueCon;
                if (requerimientoBienServicioDetalle.idProducto > 0)
                    this.producto = generalServicio.BuscarProducto(requerimientoBienServicioDetalle.idProducto);
                
                //requerimientoBienServicioDetVista.mes = requerimientoBienServicioDetalle.mes;
            }
        }

        private void LlenarCombos()
        {
            requerimientoBienServicioDetVista.listaUnidades = generalServicio.ListaUnidad();
            requerimientoBienServicioDetVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            requerimientoBienServicioDetalle.idUnidad = requerimientoBienServicioDetVista.idUnidad;
            requerimientoBienServicioDetalle.idCueCon = requerimientoBienServicioDetVista.idCueCon;
            requerimientoBienServicioDetalle.descripcion = requerimientoBienServicioDetVista.descripcion;
            requerimientoBienServicioDetalle.justificacion = requerimientoBienServicioDetVista.justificacion;
            requerimientoBienServicioDetalle.precio = requerimientoBienServicioDetVista.precio;
            requerimientoBienServicioDetalle.idProducto = producto != null ? producto.idProducto : 0;

            //Modificamos todos los detalles
            if (this.esModificacion)
            {
                requerimientoBienServicioDetalle.fechaEdita = DateTime.Now;
                requerimientoBienServicioDetalle.usuEdita = requerimientoBienServicioDetVista.nomUsuario;
                resultado = requerimientoBienServicioServicio.ModificarDetalles(requerimientoBienServicioDetalle);
            }
            else
            {
                requerimientoBienServicioDetalle.idReqBieSer = RequerimientoBienServicio.idReqBieSer;
                requerimientoBienServicioDetalle.fechaCrea = DateTime.Now;
                requerimientoBienServicioDetalle.usuCrea = requerimientoBienServicioDetVista.nomUsuario;
                requerimientoBienServicioDetalle.estado = Estados.Activo;
                resultado = requerimientoBienServicioServicio.NuevoDetalle(requerimientoBienServicioDetalle);
            }


            return resultado != null ? resultado.esCorrecto : false;
        }

        public void AsignarProducto(Producto producto)
        {
            if (producto != null)
            {
                this.producto = producto;
                requerimientoBienServicioDetVista.descripcion = producto.Descripcion;
            }
        }

    }
}
