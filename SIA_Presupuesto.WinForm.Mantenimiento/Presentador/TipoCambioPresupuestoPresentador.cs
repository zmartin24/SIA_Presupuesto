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
    public class TipoCambioPresupuestoPresentador
    {
        private readonly ITipoCambioPresupuestoVista tipoCambioPresupuestoVista;

        private ITipoCambioPresupuestoServicio tipoCambioPresupuestoServicio;
        private IGeneralServicio generalServicio;

        private TipoCambioPresupuesto tipoCambioPresupuesto;
        private bool esModificacion;
        public TipoCambioPresupuestoPresentador(TipoCambioPresupuesto tipoCambioPresupuesto, ITipoCambioPresupuestoVista tipoCambioPresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.tipoCambioPresupuestoServicio = _Contenedor.Resolver(typeof(ITipoCambioPresupuestoServicio)) as ITipoCambioPresupuestoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.tipoCambioPresupuestoVista = tipoCambioPresupuestoVista;
            this.esModificacion = tipoCambioPresupuesto != null;
            this.tipoCambioPresupuesto = tipoCambioPresupuesto ?? new TipoCambioPresupuesto();
        }
        public void IniciarDatos()
        {
            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926 && x.idMoneda != 63).ToList();
            if (listaMoneda != null)
            {
                tipoCambioPresupuestoVista.listaMoneda = listaMoneda;
                tipoCambioPresupuestoVista.idMoneda = tipoCambioPresupuesto.idTipCamPres == 0 ? 64 : tipoCambioPresupuesto.idMoneda;
            }

            tipoCambioPresupuestoVista.anio = tipoCambioPresupuesto.idTipCamPres == 0 ? DateTime.Now.Year : tipoCambioPresupuesto.anio;

            llenarComboMeses();

            if (this.esModificacion)
            {
                tipoCambioPresupuestoVista.mes = tipoCambioPresupuesto.mes;
                tipoCambioPresupuestoVista.valor = tipoCambioPresupuesto.valor;
            }
        }
        public void llenarComboMeses()
        {
            var listaMesesAnio = tipoCambioPresupuesto.idTipCamPres == 0 ? tipoCambioPresupuestoServicio.listarMesesAnio(tipoCambioPresupuestoVista.anio) :
                                 tipoCambioPresupuestoServicio.listarMesesAnio(tipoCambioPresupuestoVista.anio).Where(x => x.id != tipoCambioPresupuesto.mes);

            var listaMes = (
                            from l1 in UtilitarioComun.ListarMeses()
                                join l2 in listaMesesAnio on l1.indice equals l2.id into gj from subMes in gj.DefaultIfEmpty()
                            select new { l1.indice, l1.nombre, mesActual = subMes?.id ?? 0 }
                           ).Where(x => x.mesActual == 0).Select(s => new Mes { indice = s.indice, nombre = s.nombre }).ToList();
            if (listaMes != null && listaMes.Count > 0)
            {
                tipoCambioPresupuestoVista.listaMes = listaMes;
                tipoCambioPresupuestoVista.mes = tipoCambioPresupuesto.idTipCamPres == 0 ? (int)listaMes.OrderBy(x => x.indice).Take(1).SingleOrDefault().indice : tipoCambioPresupuesto.mes;
            }
            else
            {
                tipoCambioPresupuestoVista.listaMes = null;
            }

        }
        public TipoCambioPresupuesto BuscarPorAnioMes()
        {
            return tipoCambioPresupuestoServicio.BuscarPorAnioMes(tipoCambioPresupuestoVista.anio, tipoCambioPresupuestoVista.mes);
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            tipoCambioPresupuesto.idMoneda = tipoCambioPresupuestoVista.idMoneda;
            tipoCambioPresupuesto.anio = tipoCambioPresupuestoVista.anio;
            tipoCambioPresupuesto.mes = tipoCambioPresupuestoVista.mes;
            tipoCambioPresupuesto.valor = tipoCambioPresupuestoVista.valor;

            if (this.esModificacion)
            {
                tipoCambioPresupuesto.fechaEdita = DateTime.Now;
                tipoCambioPresupuesto.usuEdita = tipoCambioPresupuestoVista.UsuarioOperacion.NomUsuario;
                resultado = tipoCambioPresupuestoServicio.Modificar(tipoCambioPresupuesto);
            }
            else
            {
                tipoCambioPresupuesto.fechaCrea = DateTime.Now;
                tipoCambioPresupuesto.usuCrea = tipoCambioPresupuestoVista.UsuarioOperacion.NomUsuario;
                tipoCambioPresupuesto.estado = Estados.Activo;
                resultado = tipoCambioPresupuestoServicio.Nuevo(tipoCambioPresupuesto);
            }

            return resultado.esCorrecto;
        }
    }
}
