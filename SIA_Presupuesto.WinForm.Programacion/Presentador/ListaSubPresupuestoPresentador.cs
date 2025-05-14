using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ListaSubPresupuestoPresentador
    {
        private readonly IListaSubPresupuestoVista listaSubPresupuestoVista;
        private ISubpresupuestoServicio subpresupuestoServicio;
        public ListaSubPresupuestoPresentador(IListaSubPresupuestoVista IListaSubPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.subpresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.listaSubPresupuestoVista = IListaSubPresupuestoVista;
        }

        public void Iniciar()
        {
            listaSubPresupuestoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2005);
            listaSubPresupuestoVista.anioPresentacion = DateTime.Now.Date.Year;//.AddYears(1).Year;
        }

        public void ObtenerDatosListado()
        {
            listaSubPresupuestoVista.listaDatosPrincipales = subpresupuestoServicio.TraerListaSubPresupuesto(listaSubPresupuestoVista.anioPresentacion);
        }

        public bool Anular()
        {
            bool respuesta = false;
            listaSubPresupuestoVista.subPresupuesto.usuEdita = listaSubPresupuestoVista.UsuarioOperacion.NomUsuario;
            if (listaSubPresupuestoVista.subPresupuesto != null)
                respuesta = this.subpresupuestoServicio.Anular(listaSubPresupuestoVista.subPresupuesto).esCorrecto;
            return respuesta;
        }

        public bool Aprobar()
        {
            bool respuesta = false;
            listaSubPresupuestoVista.subPresupuesto.usuEdita = listaSubPresupuestoVista.UsuarioOperacion.NomUsuario;
            if (listaSubPresupuestoVista.subPresupuesto != null)
                respuesta = this.subpresupuestoServicio.Aprobar(listaSubPresupuestoVista.subPresupuesto).esCorrecto;
            return respuesta;
        }

        public bool Liquidar()
        {
            bool respuesta = false;
            listaSubPresupuestoVista.subPresupuesto.usuEdita = listaSubPresupuestoVista.UsuarioOperacion.NomUsuario;
            if (listaSubPresupuestoVista.subPresupuesto != null)
                respuesta = this.subpresupuestoServicio.Liquidar(listaSubPresupuestoVista.subPresupuesto).esCorrecto;
            return respuesta;
        }
        public List<ReporteSubpresupuestoExportaPres> TraerReporteSubpresupuestoExporta()
        {
            return subpresupuestoServicio.TraerReporteSubpresupuestoExporta(listaSubPresupuestoVista.subPresupuesto.idSubPresupuesto, listaSubPresupuestoVista.idMoneda);
        }

        public Resultado VerificarSubpresupuesto()
        {
            return subpresupuestoServicio.VerificarSubpresupuesto(listaSubPresupuestoVista.subPresupuesto.idSubPresupuesto);
        }

    }
}
