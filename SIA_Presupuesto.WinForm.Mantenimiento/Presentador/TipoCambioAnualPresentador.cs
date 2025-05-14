using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class TipoCambioAnualPresentador
    {
        private readonly ITipoCambioAnualVista tipoCambioAnualVista;

        private ITipoCambioAnualServicio tipoCambioAnualServicio;
        private IGeneralServicio generalServicio;

        private TipoCambioAnual tipoCambioAnual;
        private bool esModificacion;
        public TipoCambioAnualPresentador(TipoCambioAnual tipoCambioAnual, ITipoCambioAnualVista tipoCambioAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.tipoCambioAnualServicio = _Contenedor.Resolver(typeof(ITipoCambioAnualServicio)) as ITipoCambioAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.tipoCambioAnualVista = tipoCambioAnualVista;
            this.esModificacion = tipoCambioAnual != null;
            this.tipoCambioAnual = tipoCambioAnual ?? new TipoCambioAnual();
        }
        public void IniciarDatos()
        {
            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926 && x.idMoneda != 63).ToList();
            if (listaMoneda != null)
            {
                tipoCambioAnualVista.listaMoneda = listaMoneda;
                tipoCambioAnualVista.idMoneda = tipoCambioAnual.idTipCamAnu == 0 ? 64 : tipoCambioAnual.idMoneda;
            }

            tipoCambioAnualVista.anio = tipoCambioAnual.idTipCamAnu == 0 ? DateTime.Now.Year : tipoCambioAnual.anio;

            if (this.esModificacion)
            {
                tipoCambioAnualVista.valor = tipoCambioAnual.valor;
            }
        }

        public TipoCambioAnual BuscarPorAnioMes()
        {
            return tipoCambioAnualServicio.BuscarPorAnio(tipoCambioAnualVista.anio);
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            tipoCambioAnual.idMoneda = tipoCambioAnualVista.idMoneda;
            tipoCambioAnual.anio = tipoCambioAnualVista.anio;
            tipoCambioAnual.valor = tipoCambioAnualVista.valor;

            if (this.esModificacion)
            {
                tipoCambioAnual.fechaEdita = DateTime.Now;
                tipoCambioAnual.usuEdita = tipoCambioAnualVista.UsuarioOperacion.NomUsuario;
                resultado = tipoCambioAnualServicio.Modificar(tipoCambioAnual);
            }
            else
            {
                tipoCambioAnual.fechaCrea = DateTime.Now;
                tipoCambioAnual.usuCrea = tipoCambioAnualVista.UsuarioOperacion.NomUsuario;
                tipoCambioAnual.estado = Estados.Activo;
                resultado = tipoCambioAnualServicio.Nuevo(tipoCambioAnual);
            }

            return resultado.esCorrecto;
        }
    }
}
