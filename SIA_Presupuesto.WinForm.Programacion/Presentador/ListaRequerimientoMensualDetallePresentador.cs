using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaRequerimientoMensualDetallePresentador
    {
        private readonly IListaRequerimientoMensualDetalleVista listaRequerimientoMensualDetalleVista;
        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        
        private RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres;
        
        public ListaRequerimientoMensualDetallePresentador(RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres, IListaRequerimientoMensualDetalleVista listaRequerimientoMensualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;

            this.listaRequerimientoMensualDetalleVista = listaRequerimientoMensualDetalleVista;
            this.requerimientoMensualBienServicioPres = requerimientoMensualBienServicioPres;
        }
        public void Iniciar()
        {
            this.listaRequerimientoMensualDetalleVista.descripcion = "(" + this.requerimientoMensualBienServicioPres.idReqMenBieSer.ToString() + ") " + this.requerimientoMensualBienServicioPres.descripcion;
            this.listaRequerimientoMensualDetalleVista.desArea = this.requerimientoMensualBienServicioPres.desDireccion + "/" + this.requerimientoMensualBienServicioPres.desSubdireccion + "/" + this.requerimientoMensualBienServicioPres.desArea;
            this.listaRequerimientoMensualDetalleVista.desTipo = this.requerimientoMensualBienServicioPres.desTipo;
            this.listaRequerimientoMensualDetalleVista.desMoneda = this.requerimientoMensualBienServicioPres.desMoneda;
        }
        public void ObtenerDatosListado()
        {
            listaRequerimientoMensualDetalleVista.listaDatosPrincipales = this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualDetalle((Int32)this.requerimientoMensualBienServicioPres.idReqMenBieSer);
        }
        
        public RequerimientoMensualDetalle BuscarDetalle(int idReqMenDet)
        {
            return this.requerimientoMensualBienServicioServicio.BuscarDetallePorCodigo(idReqMenDet);
        }
        
        public bool Anular()
        {
            bool respuesta = false;
            if (this.listaRequerimientoMensualDetalleVista.requerimientoMensualDetalle != null)
                respuesta = this.requerimientoMensualBienServicioServicio.AnularDetalle(this.listaRequerimientoMensualDetalleVista.requerimientoMensualDetalle, this.listaRequerimientoMensualDetalleVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        
    }
}
