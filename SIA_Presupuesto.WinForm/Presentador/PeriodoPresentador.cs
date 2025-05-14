using SIA_Presupuesto.Negocio.Entidades;
//using SIA_Presupuesto.WinForm.AgenteServicio.Modelo;
using SIA_Presupuesto.WinForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Presentador
{
    public class PeriodoPresentador
    {
        private IPeriodoVista periodoVista;
        private PrincipalPresentador principalPresentador;
        //private EjercicioContableModelo ejercicioModelo;
        //private TipoCambioModelo tipoCambioModelo;

        //private List<EjercicioContable> lista;
        //private EjercicioContable ejercicioContableActual;
        public PeriodoPresentador(IPeriodoVista periodoVista, PrincipalPresentador principalPresentador)
        {
            this.periodoVista = periodoVista;
            this.principalPresentador = principalPresentador;
            //ejercicioModelo = new EjercicioContableModelo();
            //tipoCambioModelo = new TipoCambioModelo();
        }

        public void InicializarDatos()
        {
            CargarLista();

            //if (lista.Count > 0)
            //{
            //    periodoVista.listaAnios = UtilitarioComun.ListarAnios(lista.Max(s => s.anioEjercicio), lista.Min(s => s.anioEjercicio));
            //    var activo = lista.FirstOrDefault(f => !f.cerrado);
            //    if (activo != null)
            //    {
            //        periodoVista.Anio = activo.anioEjercicio;
            //        periodoVista.Mes = activo.mesEjercicio;
            //        ejercicioContableActual = activo;
            //    }
            //    else
            //    {
            //        var primero = lista.FirstOrDefault(f => !f.cerrado);
            //        if (primero!=null)
            //        {
            //            periodoVista.Anio = primero.anioEjercicio;
            //            periodoVista.Mes = primero.mesEjercicio;
            //            ejercicioContableActual = primero;
            //        }
            //    }
            //}
            //else
            //{
            //    periodoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2005);
            //    periodoVista.Anio = DateTime.Now.Year;
            //    periodoVista.Mes = DateTime.Now.Month;
            //}

            periodoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2005);
            periodoVista.Anio = DateTime.Now.Year;
            periodoVista.Mes = DateTime.Now.Month;

            //Primera opcion
            //periodoVista.Anio = DateTime.Now.Year;
            //periodoVista.Mes = DateTime.Now.Month;

            //Segunda opcion
            if (this.principalPresentador.Anio > 0)
                periodoVista.Anio = this.principalPresentador.Anio;
            if (this.principalPresentador.Mes > 0)
                periodoVista.Mes = this.principalPresentador.Mes;
        }

        public void CargarLista()
        {
            //lista = ejercicioModelo.Listado<EjercicioContable>();
        }

        public void LlenarDatosMeses()
        {
            periodoVista.listaMeses = UtilitarioComun.ListarMeses();
        }

        public bool Asignar()
        {
            bool respuesta = true;

            //ejercicioContableActual = lista.FirstOrDefault(f => f.anioEjercicio == periodoVista.Anio && f.mesEjercicio == periodoVista.Mes);
            //if (ejercicioContableActual != null)
            //{
            //    this.principalPresentador.EjercicioContable = ejercicioContableActual;
            //    this.principalPresentador.Anio = periodoVista.Anio;
            //    this.principalPresentador.Mes = periodoVista.Mes;
            //    var tipoCamp = tipoCambioModelo.BuscarTipoCambioAnioMes(periodoVista.Anio, periodoVista.Mes);
            //    if(tipoCamp!=null)
            //    {
            //        this.principalPresentador.IdTipCam = tipoCamp.idTipCamCon;
            //        this.principalPresentador.IdMoneda = 63;
            //    }
            //    var ejerAct = lista.FirstOrDefault(f => !f.cerrado);
            //    if(ejerAct!=null)
            //    {
            //        this.principalPresentador.AnioActivo = ejerAct.anioEjercicio;
            //        this.principalPresentador.MesActivo = ejerAct.mesEjercicio;
            //    }
            //    respuesta = true;
            //}

            this.principalPresentador.Anio = periodoVista.Anio;
            this.principalPresentador.Mes = periodoVista.Mes;

            return respuesta;
        }
    }
}
