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
    public class RubroBienServicioCuentaPresentador
    {
        private readonly IRubroBienServicioCuentaVista rubroBienServicioVista;
        private IRubroBienServicioCuentaServicio _rubroBienServicio;
        private IRubroBienServicio _rubroBienServicio1;
        private int _idPlanCuenta;

        private RubroBienServicioCuentaPoco objRubroServicio;

        private bool esModificacion;
        public RubroBienServicioCuentaPresentador(RubroBienServicioCuentaPoco rubroBienServicio,int _idPlanCuenta, IRubroBienServicioCuentaVista rubroBienServicioVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this._rubroBienServicio = _Contenedor.Resolver(typeof(IRubroBienServicioCuentaServicio)) as IRubroBienServicioCuentaServicio;
            this._rubroBienServicio1 = _Contenedor.Resolver(typeof(IRubroBienServicio)) as IRubroBienServicio;
            this._idPlanCuenta = _idPlanCuenta;
            this.rubroBienServicioVista = rubroBienServicioVista;
            this.esModificacion = rubroBienServicio != null;
            this.objRubroServicio = rubroBienServicio ?? new RubroBienServicioCuentaPoco();
        }

        public void IniciarDatos()
        {
            rubroBienServicioVista.listaTipoGastos = _rubroBienServicio1.ObtenerLista();

            int? nivel = 1;

            rubroBienServicioVista.listaCuentasNivel1 = _rubroBienServicio.TraerListaCtaxNivelPlan(this._idPlanCuenta, nivel.GetValueOrDefault(),0);

            if (this.esModificacion)
            {
                rubroBienServicioVista.idRubBieSer = objRubroServicio.idRubBieSer;

                int n1 = 0;
                int n2 = 0;
                int n3 = objRubroServicio.idCueCon;

                CuentaContablePoco objCuenta = _rubroBienServicio.ObtenerCuenta(objRubroServicio.idCueCon);
                CuentaContablePoco objCuenta2 = _rubroBienServicio.ObtenerCuenta(objCuenta.dependencia.GetValueOrDefault());
                n2 = objCuenta2.idCueCon;
                CuentaContablePoco objCuenta3 = _rubroBienServicio.ObtenerCuenta(objCuenta2.dependencia.GetValueOrDefault());
                n1 = objCuenta3.idCueCon;

                rubroBienServicioVista.idCuentaNivel1 = n1;
                rubroBienServicioVista.idCuentaNivel2 = n2;
                rubroBienServicioVista.idCuentaNivel3 = n3;
            }
        }

        public void ActualizarCombo(int nivel)
        {
            int? nivel1 = 1;

            switch (nivel)
            {
                case 1:
                    nivel1 = 1;
                    rubroBienServicioVista.listaCuentasNivel1 = _rubroBienServicio.TraerListaCtaxNivelPlan(this._idPlanCuenta, nivel1.GetValueOrDefault(), 0);
                    rubroBienServicioVista.listaCuentasNivel2 = null;
                    rubroBienServicioVista.listaCuentasNivel3 = null;
                    rubroBienServicioVista.idCuentaNivel2 = 0;
                    rubroBienServicioVista.idCuentaNivel3 = 0;
                    break;
                case 2:
                    nivel1 = 2;
                    rubroBienServicioVista.listaCuentasNivel2 = _rubroBienServicio.TraerListaCtaxNivelPlan(this._idPlanCuenta, nivel1.GetValueOrDefault(), rubroBienServicioVista.idCuentaNivel1);
                    rubroBienServicioVista.listaCuentasNivel3 = null;
                    rubroBienServicioVista.idCuentaNivel3 = 0;
                    break;
                case 3:
                    nivel1 = 3;
                    rubroBienServicioVista.listaCuentasNivel3 = _rubroBienServicio.TraerListaCtaxNivelPlan(this._idPlanCuenta, nivel1.GetValueOrDefault(), rubroBienServicioVista.idCuentaNivel2);
                    break;
                default:
                    break;
            }
        }

        public CuentaContablePoco ValidarExisteCta(int idCuenta)
        {
            return _rubroBienServicio.ValidarExisteCta(idCuenta);
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            if (this.esModificacion)
            {
                RubroBienServicioCuenta objRBS = new RubroBienServicioCuenta();
                objRBS.idRubBieSerCue = this.objRubroServicio.idRubBieSerCue;
                objRBS.idRubBieSer = rubroBienServicioVista.idRubBieSer;
                objRBS.idCueCon = rubroBienServicioVista.idCuentaNivel3;
                objRBS.usuCrea = rubroBienServicioVista.UsuarioOperacion.NomUsuario;
                objRBS.fechaCrea = DateTime.Now;
                objRBS.estado = Estados.Activo;
                resultado = _rubroBienServicio.Modificar(objRBS);
            }
            else
            {
                RubroBienServicioCuenta objRBS = new RubroBienServicioCuenta();
                objRBS.idRubBieSerCue = 0;
                objRBS.idRubBieSer = rubroBienServicioVista.idRubBieSer;
                objRBS.idCueCon = rubroBienServicioVista.idCuentaNivel3;
                objRBS.usuCrea = rubroBienServicioVista.UsuarioOperacion.NomUsuario;
                objRBS.fechaCrea = DateTime.Now;
                objRBS.estado = Estados.Activo;
                resultado = _rubroBienServicio.Nuevo(objRBS);
            }

            return resultado.esCorrecto;
        }
    }
}
