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
    public class PlanAnualAdquisicionPresentador
    {
        private readonly IPlanAnualAdquisicionVista planAnualAdquisicionVista;

        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGeneralServicio generalServicio;

        private PlanAnualAdquisicion planAnualAdquisicion;
        private bool esModificacion;
        public PlanAnualAdquisicionPresentador(PlanAnualAdquisicion planAnualAdquisicion, IPlanAnualAdquisicionVista planAnualAdquisicionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.planAnualAdquisicionVista = planAnualAdquisicionVista;
            this.esModificacion = planAnualAdquisicion != null;
            this.planAnualAdquisicion = planAnualAdquisicion ?? new PlanAnualAdquisicion();
        }
        public void IniciarDatos()
        {
            planAnualAdquisicionVista.anio = DateTime.Now.Year;
            planAnualAdquisicionVista.fechaEmision = DateTime.Now.Date;

            planAnualAdquisicion.idMoneda = planAnualAdquisicion.idMoneda == null ? 63 : planAnualAdquisicion.idMoneda;

            // combo moneda
            var listaMoneda = generalServicio.ListaMonedas();
            if (listaMoneda != null)
            {
                planAnualAdquisicionVista.listaMoneda = listaMoneda;
                if (listaMoneda.Count > 0)
                    planAnualAdquisicionVista.idTipMon = 63;
            }

            if (this.esModificacion)
            {
                planAnualAdquisicionVista.descripcion = planAnualAdquisicion.descripcion;
                planAnualAdquisicionVista.anio = planAnualAdquisicion.anio;
                planAnualAdquisicionVista.fechaEmision = (DateTime)planAnualAdquisicion.fechaEmision;
                planAnualAdquisicionVista.siglas = planAnualAdquisicion.siglas;
                planAnualAdquisicionVista.uniEje = planAnualAdquisicion.uniEje;
                planAnualAdquisicionVista.pliego = planAnualAdquisicion.pliego;
                planAnualAdquisicionVista.idTipMon = (int)planAnualAdquisicion.idMoneda;
                planAnualAdquisicionVista.tipCam = planAnualAdquisicion.tipoCambio == null ? 1 : (decimal)planAnualAdquisicion.tipoCambio;

            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            planAnualAdquisicion.descripcion = planAnualAdquisicionVista.descripcion.ToUpper();
            planAnualAdquisicion.idEntidad = 1;
            planAnualAdquisicion.anio = planAnualAdquisicionVista.anio;
            planAnualAdquisicion.fechaEmision = planAnualAdquisicionVista.fechaEmision;
            planAnualAdquisicion.siglas = planAnualAdquisicionVista.siglas.ToUpper();
            planAnualAdquisicion.uniEje = planAnualAdquisicionVista.uniEje.ToUpper();
            planAnualAdquisicion.pliego = planAnualAdquisicionVista.pliego.ToUpper();
            planAnualAdquisicion.idMoneda = planAnualAdquisicionVista.idTipMon;
            planAnualAdquisicion.tipoCambio = planAnualAdquisicionVista.tipCam;
            if (this.esModificacion)
            {
                planAnualAdquisicion.fechaMod = DateTime.Now;
                planAnualAdquisicion.usuMod = planAnualAdquisicionVista.UsuarioOperacion.NomUsuario;
                resultado = planAnualAdquisicionServicio.Modificar(planAnualAdquisicion);
            }
            else
            {
                planAnualAdquisicion.fechaCrea = DateTime.Now;
                planAnualAdquisicion.usuCrea = planAnualAdquisicionVista.UsuarioOperacion.NomUsuario;
                planAnualAdquisicion.estado = Estados.Activo;
                resultado = planAnualAdquisicionServicio.Nuevo(planAnualAdquisicion);
            }

            return resultado.esCorrecto;
        }
    }
}
