using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class RubroBienServicioPresentador
    {
        private readonly IRubroBienServicioVista rubroBienServicioVista;
        private IRubroBienServicio _rubroBienServicio;

        private RubroBienServicioPoco objRubroServicio;

        private bool esModificacion;
        public RubroBienServicioPresentador(RubroBienServicioPoco rubroBienServicio, IRubroBienServicioVista rubroBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this._rubroBienServicio = _Contenedor.Resolver(typeof(IRubroBienServicio)) as IRubroBienServicio;
           
            this.rubroBienServicioVista = rubroBienServicioVista;
            this.esModificacion = rubroBienServicio != null;
            this.objRubroServicio = rubroBienServicio ?? new RubroBienServicioPoco();
        }
        public void IniciarDatos()
        {
            //rubroBienServicioVista.anio = DateTime.Now.Year;
            //gastoRecurrente.idMoneda = gastoRecurrente.idMoneda == null ? 63 : gastoRecurrente.idMoneda;

            //// combo moneda
            //var listaMoneda = generalServicio.ListaMonedas();
            //if (listaMoneda != null)
            //{
            //    gastoRecurrenteVista.listaMoneda = listaMoneda.Where(x => x.descripcion != "INTI").ToList();
            //    if (listaMoneda.Count > 0)
            //        gastoRecurrenteVista.idTipMon = 63;
            //}

            if (this.esModificacion)
            {
                rubroBienServicioVista.descripcion = objRubroServicio.descripcion;
                rubroBienServicioVista.idRubBieSer = objRubroServicio.idRubBieSer;


            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            objRubroServicio.descripcion = rubroBienServicioVista.descripcion.ToUpper();
          
            if (this.esModificacion)
            {
                RubroBienServicio objRBS = new RubroBienServicio();
                objRBS.idRubBieSer = objRubroServicio.idRubBieSer;
                objRBS.descripcion = objRubroServicio.descripcion;
                objRBS.fechaEdita = DateTime.Now;
                objRBS.usuEdita = rubroBienServicioVista.UsuarioOperacion.NomUsuario;
                resultado = _rubroBienServicio.Modificar(objRBS);
            }
            else
            {
                RubroBienServicio objRBS = new RubroBienServicio();
                objRBS.idRubBieSer = 0;
                objRBS.descripcion = rubroBienServicioVista.descripcion.ToUpper();
                objRBS.tipoRubro = 1;
                objRBS.usuCrea = rubroBienServicioVista.UsuarioOperacion.NomUsuario;
                objRBS.fechaCrea = DateTime.Now;
                objRBS.estado = Estados.Activo;
                resultado = _rubroBienServicio.Nuevo(objRBS);
            }

            return resultado.esCorrecto;
        }
    }
}
