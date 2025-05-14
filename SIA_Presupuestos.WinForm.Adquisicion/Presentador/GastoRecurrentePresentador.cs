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
    public class GastoRecurrentePresentador
    {
        private readonly IGastoRecurrenteVista gastoRecurrenteVista;

        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;

        private GastoRecurrente gastoRecurrente;
        private bool esModificacion;
        public GastoRecurrentePresentador(GastoRecurrente gastoRecurrente, IGastoRecurrenteVista gastoRecurrenteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.gastoRecurrenteVista = gastoRecurrenteVista;
            this.esModificacion = gastoRecurrente != null;
            this.gastoRecurrente = gastoRecurrente ?? new GastoRecurrente();
        }
        public void IniciarDatos()
        {
            gastoRecurrenteVista.anio = DateTime.Now.Year;
            gastoRecurrente.idMoneda = gastoRecurrente.idMoneda == null ? 63 : gastoRecurrente.idMoneda;

            // combo moneda
            var listaMoneda = generalServicio.ListaMonedas();
            if (listaMoneda != null)
            {
                gastoRecurrenteVista.listaMoneda = listaMoneda.Where(x=>x.descripcion!= "INTI").ToList();
                if (listaMoneda.Count > 0)
                    gastoRecurrenteVista.idTipMon = 63;
            }

            if (this.esModificacion)
            {
                gastoRecurrenteVista.descripcion = gastoRecurrente.descripcion;
                gastoRecurrenteVista.anio = (Int32)gastoRecurrente.anio;
                gastoRecurrenteVista.idTipMon = (Int32)gastoRecurrente.idMoneda;
                gastoRecurrenteVista.tipCam = gastoRecurrente.tipCam == null ? 1 : (decimal)gastoRecurrente.tipCam;

            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            gastoRecurrente.descripcion = gastoRecurrenteVista.descripcion.ToUpper();
            gastoRecurrente.idEntidad = 1;
            gastoRecurrente.anio = gastoRecurrenteVista.anio;
            gastoRecurrente.idMoneda = gastoRecurrenteVista.idTipMon;
            gastoRecurrente.tipCam = gastoRecurrenteVista.tipCam;
            if (this.esModificacion)
            {
                gastoRecurrente.fechaEdita = DateTime.Now;
                gastoRecurrente.usuEdita = gastoRecurrenteVista.UsuarioOperacion.NomUsuario;
                resultado = gastoRecurrenteServicio.Modificar(gastoRecurrente);
            }
            else
            {
                gastoRecurrente.fechaCrea = DateTime.Now;
                gastoRecurrente.usuCrea = gastoRecurrenteVista.UsuarioOperacion.NomUsuario;
                gastoRecurrente.estado = Estados.Activo;
                resultado = gastoRecurrenteServicio.Nuevo(gastoRecurrente);
            }

            return resultado.esCorrecto;
        }
    }
}
