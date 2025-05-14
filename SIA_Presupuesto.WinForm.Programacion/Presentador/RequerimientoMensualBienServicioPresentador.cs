using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class RequerimientoMensualBienServicioPresentador
    {
        private readonly IRequerimientoMensualBienServicioVista requerimientoMensualBienServicioVista;

        private IRequerimientoMensualBienServicioServicio requerimientoMensualBienServicioServicio;
        private IGeneralServicio generalServicio;
        private IPeriodoServicio periodoServicio;

        private RequerimientoMensualBienServicio requerimientoMensualBienServicio;
        private bool esModificacion;
        public RequerimientoMensualBienServicioPresentador(RequerimientoMensualBienServicio requerimientoMensualBienServicio, IRequerimientoMensualBienServicioVista requerimientoMensualBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;
            this.requerimientoMensualBienServicioServicio = _Contenedor.Resolver(typeof(IRequerimientoMensualBienServicioServicio)) as IRequerimientoMensualBienServicioServicio;

            this.requerimientoMensualBienServicioVista = requerimientoMensualBienServicioVista;
            this.esModificacion = requerimientoMensualBienServicio != null;
            this.requerimientoMensualBienServicio = requerimientoMensualBienServicio ?? new RequerimientoMensualBienServicio();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            this.requerimientoMensualBienServicioVista.anio = this.periodoServicio.ObtenerActivo().anio; //DateTime.Now.Date.AddYears(1).Year;
            this.requerimientoMensualBienServicioVista.mes = DateTime.Now.Date.Month;
            this.requerimientoMensualBienServicioVista.fechaEmision = DateTime.Now.Date;
            this.requerimientoMensualBienServicioVista.idMoneda = 63;
            this.requerimientoMensualBienServicioVista.tipo = 1; //Unidad por defecto


            if (this.esModificacion)
            {
                requerimientoMensualBienServicioVista.descripcion = requerimientoMensualBienServicio.descripcion;
                requerimientoMensualBienServicioVista.idMoneda = requerimientoMensualBienServicio.idMoneda;
                requerimientoMensualBienServicioVista.anio = requerimientoMensualBienServicio.anio;
                requerimientoMensualBienServicioVista.mes = requerimientoMensualBienServicio.mes;
                requerimientoMensualBienServicioVista.tipo = requerimientoMensualBienServicio.tipo;
                requerimientoMensualBienServicioVista.fechaEmision = requerimientoMensualBienServicio.fechaEmision;
                var area = generalServicio.BuscarArea(requerimientoMensualBienServicio.idArea);
                if(area != null)
                {
                    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                    if (subdireccion != null)
                    {
                        requerimientoMensualBienServicioVista.idDireccion = subdireccion.idDireccion;
                        requerimientoMensualBienServicioVista.idSubdireccion = subdireccion.idSubdireccion;
                        requerimientoMensualBienServicioVista.idArea = requerimientoMensualBienServicio.idArea;
                    }
                }
            }
        }

        private void LlenarCombos()
        {
            this.requerimientoMensualBienServicioVista.listaTipo = PredeterminadoHelper.ListarTipoRequerimiento();
            this.requerimientoMensualBienServicioVista.listaMonedas = generalServicio.ListaMonedas();
            this.requerimientoMensualBienServicioVista.listaAnio = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            this.requerimientoMensualBienServicioVista.listaMes = UtilitarioComun.ListarMeses();

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            this.requerimientoMensualBienServicioVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                requerimientoMensualBienServicioVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                requerimientoMensualBienServicioVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                requerimientoMensualBienServicioVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                requerimientoMensualBienServicioVista.listaAreas = listaAreas;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            requerimientoMensualBienServicio.tipo = requerimientoMensualBienServicioVista.tipo;
            requerimientoMensualBienServicio.idMoneda = requerimientoMensualBienServicioVista.idMoneda;
            requerimientoMensualBienServicio.descripcion = requerimientoMensualBienServicioVista.descripcion.Trim().ToUpper();
            requerimientoMensualBienServicio.anio = requerimientoMensualBienServicioVista.anio;
            requerimientoMensualBienServicio.mes = requerimientoMensualBienServicioVista.mes;
            requerimientoMensualBienServicio.fechaEmision = requerimientoMensualBienServicioVista.fechaEmision;
            requerimientoMensualBienServicio.idArea = requerimientoMensualBienServicioVista.idArea;
            if (this.esModificacion)
            {
                requerimientoMensualBienServicio.fechaEdita = DateTime.Now;
                requerimientoMensualBienServicio.usuEdita = requerimientoMensualBienServicioVista.UsuarioOperacion.NomUsuario;
                resultado = requerimientoMensualBienServicioServicio.Modificar(requerimientoMensualBienServicio);
            }
            else
            {
                requerimientoMensualBienServicio.fechaCrea = DateTime.Now;
                requerimientoMensualBienServicio.usuCrea = requerimientoMensualBienServicioVista.UsuarioOperacion.NomUsuario;
                requerimientoMensualBienServicio.estado = Estados.Activo;
                resultado = requerimientoMensualBienServicioServicio.Nuevo(requerimientoMensualBienServicio);
            }

            return resultado.esCorrecto;
        }

        public List<RequerimientoMensualDetalle> TraerListarDetallesTodos(int idReqMenBieSer)
        {
            return this.requerimientoMensualBienServicioServicio.TraerListarDetallesTodos(idReqMenBieSer);
        }
    }
}
