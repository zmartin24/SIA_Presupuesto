using DevExpress.Office.Utils;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaRequerimientoMensualAsignacionPresentador
    {
        private readonly IListaRequerimientoMensualAsignacionVista listaRequerimientoMensualAsignacionVista;
        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        private IPeriodoServicio periodoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;

        private bool listarTodos = false;

        public ListaRequerimientoMensualAsignacionPresentador(IListaRequerimientoMensualAsignacionVista listaRequerimientoMensualAsignacionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.listaRequerimientoMensualAsignacionVista = listaRequerimientoMensualAsignacionVista;
        }

        public void Iniciar()
        {
            this.listaRequerimientoMensualAsignacionVista.listaAnio = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            this.listaRequerimientoMensualAsignacionVista.listaMes = UtilitarioComun.ListarMeses();



            this.listaRequerimientoMensualAsignacionVista.anio = DateTime.Now.Year; //this.periodoServicio.ObtenerActivo().anio;
            this.listaRequerimientoMensualAsignacionVista.mes = DateTime.Now.Date.Month;

            //this.listaRequerimientoMensualAsignacionVista.listaProgramacionAnual = this.programacionAnualServicio.TraerListaProgramacionAnual(this.listaRequerimientoMensualAsignacionVista.anio);
            LlenarListaProgramacionAnual();
        }

        public void ObtenerDatosListado()
        {
            this.listaRequerimientoMensualAsignacionVista.listaRequerimientoMensual = this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualAsignacionVista.anio, this.listaRequerimientoMensualAsignacionVista.mes, this.listaRequerimientoMensualAsignacionVista.UsuarioOperacion.IDUsuario, null, listarTodos);
            this.listaRequerimientoMensualAsignacionVista.listaRequerimientoMensualAsignado = this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualAsignacionVista.anio, this.listaRequerimientoMensualAsignacionVista.mes, this.listaRequerimientoMensualAsignacionVista.UsuarioOperacion.IDUsuario, this.listaRequerimientoMensualAsignacionVista.idProAnu, listarTodos);
        }

        public void LlenarListaProgramacionAnual()
        {
            this.listaRequerimientoMensualAsignacionVista.listaProgramacionAnual = this.programacionAnualServicio.TraerListaProgramacionAnual(this.listaRequerimientoMensualAsignacionVista.anio);
        }
        //public void ActualizarGrillas()
        //{
        //    this.listaRequerimientoMensualAsignacionVista.listaSplash = this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualAsignacionVista.anio, this.listaRequerimientoMensualAsignacionVista.mes, this.listaRequerimientoMensualAsignacionVista.UsuarioOperacion.IDUsuario, null);
        //    this.listaRequerimientoMensualAsignacionVista.listaRequerimientoMensualAsignado = this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualAsignacionVista.anio, this.listaRequerimientoMensualAsignacionVista.mes, this.listaRequerimientoMensualAsignacionVista.UsuarioOperacion.IDUsuario, this.listaRequerimientoMensualAsignacionVista.idProAnu);
        //}
        //public List<RequerimientoMensualBienServicioPres> listaRequerimientoMensualBienServicioPres()
        //{
        //    return this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualAsignacionVista.anio, 5, this.listaRequerimientoMensualAsignacionVista.UsuarioOperacion.IDUsuario, null);
        //}
        //public List<RequerimientoMensualBienServicioPres> listaAsignacionRequerimientoMensualBienServicioPres()
        //{
        //    return this.requerimientoMensualBienServicioServicio.TraerListaRequerimientoMensualBienServicio(this.listaRequerimientoMensualAsignacionVista.anio, 5, this.listaRequerimientoMensualAsignacionVista.UsuarioOperacion.IDUsuario, 623);
        //}

        public RequerimientoMensualBienServicio Buscar(int id)
        {
            return this.requerimientoMensualBienServicioServicio.BuscarPorCodigo(id);
        }

        public bool AsignarRequerimiento(RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres, int? idProAnu)
        {
            Resultado resultado = null;
            RequerimientoMensualBienServicio req = Buscar((Int32)requerimientoMensualBienServicioPres.idReqMenBieSer);
            req.idProAnu = idProAnu;
            if (idProAnu != null)
            {
                req.fechaAsigPre = DateTime.Now;
                req.estado = Estados.Asignado;
            }
            else
            {
                req.fechaAsigPre = null;
                req.estado = Estados.Aprobado;
            }
            resultado = requerimientoMensualBienServicioServicio.ModificarSinClonar(req);

            return resultado.esCorrecto;
        }

    }
}
