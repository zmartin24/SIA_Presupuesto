using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class RubroBienServicioCuentaServicio : ServicioBase, IRubroBienServicioCuentaServicio
    {
        IRubroBienServicioCuentaRepositorio repositorio;

        public RubroBienServicioCuentaServicio(IRubroBienServicioCuentaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<CuentaContablePoco> TraerListaCtaxNivelPlan(int idPlan, int? nivel, int dependencia)
        {
            return this.repositorio.TraerListaCtaxNivelPlan(idPlan, nivel, dependencia);
        }

        public Resultado Anular(int id)
        {
            RubroBienServicioCuenta objRubroBienServicio = repositorio.TraerPorID(id);

            try
            {
                objRubroBienServicio.idRubBieSerCue = id;
                objRubroBienServicio.estado = Estados.Anulado;
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objRubroBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, objRubroBienServicio);
                resultado.id = id;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, objRubroBienServicio, ex);
            }

            return resultado;
        }

        public Resultado Modificar(Entidades.RubroBienServicioCuenta rubroBienServicio)
        {
            try
            {
                RubroBienServicioCuenta objRubroBienServicio = repositorio.TraerPorID(rubroBienServicio.idRubBieSerCue);
                objRubroBienServicio.idRubBieSer = rubroBienServicio.idRubBieSer;
                objRubroBienServicio.idCueCon = rubroBienServicio.idCueCon;
                objRubroBienServicio.usuEdita = rubroBienServicio.usuEdita;
                objRubroBienServicio.fechaEdita = rubroBienServicio.fechaEdita;

                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objRubroBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, rubroBienServicio);
                resultado.id = rubroBienServicio.idRubBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, rubroBienServicio, ex);
            }

            return resultado;
        }

        public Resultado Nuevo(Entidades.RubroBienServicioCuenta rubroBienServicio)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(rubroBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, rubroBienServicio);
                resultado.id = rubroBienServicio.idRubBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, rubroBienServicio, ex);
            }

            return resultado;
        }

        public List<RubroBienServicioCuentaPoco> ObtenerLista(int idPlanCuenta)
        {
            return repositorio.TraerLista(idPlanCuenta);
        }

        public List<ItemPoco> TraerListaPlanCuenta()
        {
            return repositorio.TraerListaPlanCuenta();
        }

        public CuentaContablePoco ValidarExisteCta(int idCuenta)
        {
            return repositorio.ValidarExisteCta(idCuenta);
        }

        public CuentaContablePoco ObtenerCuenta(int idCuenta)
        {
            return repositorio.ObtenerCuenta(idCuenta);
        }
    }
}
