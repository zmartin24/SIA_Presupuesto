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
    public class TipoCambioPresupuestoServicio : ServicioBase, ITipoCambioPresupuestoServicio
    {
        ITipoCambioPresupuestoRepositorio repositorio;

        public TipoCambioPresupuestoServicio(ITipoCambioPresupuestoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private TipoCambioPresupuesto Clonar(TipoCambioPresupuesto tipoCambioPresupuestoOld)
        {
            return new TipoCambioPresupuesto
            {
                idTipCamPres = tipoCambioPresupuestoOld.idTipCamPres,
                idMoneda = tipoCambioPresupuestoOld.idMoneda,
                anio = tipoCambioPresupuestoOld.anio,
                mes = tipoCambioPresupuestoOld.mes,
                valor = tipoCambioPresupuestoOld.valor,
                usuCrea = tipoCambioPresupuestoOld.usuCrea,
                fechaCrea = tipoCambioPresupuestoOld.fechaCrea,
                usuEdita = tipoCambioPresupuestoOld.usuEdita,
                fechaEdita = tipoCambioPresupuestoOld.fechaEdita,
                estado = tipoCambioPresupuestoOld.estado
            };
        }

        #region Operaciones
        public Resultado Nuevo(TipoCambioPresupuesto TipoCambioPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(TipoCambioPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, TipoCambioPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, TipoCambioPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(TipoCambioPresupuesto TipoCambioPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                TipoCambioPresupuesto obj = repositorio.TraerPorID(TipoCambioPresupuesto.idTipCamPres);
                obj.idMoneda = TipoCambioPresupuesto.idMoneda;
                obj.anio = TipoCambioPresupuesto.anio;
                obj.mes = TipoCambioPresupuesto.mes;
                obj.valor = TipoCambioPresupuesto.valor;
                obj.usuEdita = TipoCambioPresupuesto.usuEdita;
                obj.fechaEdita = DateTime.Now;

                repositorio.Actualizar(obj);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, TipoCambioPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, TipoCambioPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(TipoCambioPresupuesto TipoCambioPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                TipoCambioPresupuesto.estado = Estados.Anulado;
                TipoCambioPresupuesto.fechaEdita = DateTime.Now;
                repositorio.Actualizar(TipoCambioPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, TipoCambioPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, TipoCambioPresupuesto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public TipoCambioPresupuesto BuscarPorCodigo(int idTipoCambioPresupuesto)
        {
            return repositorio.TraerPorID(idTipoCambioPresupuesto);
        }
        public TipoCambioPresupuesto BuscarPorAnioMes(int anio, int mes)
        {
            return repositorio.TraerPorCondicion(x => x.anio == anio && x.mes == mes && x.estado != Estados.Anulado);
        }

        public List<TipoCambioPresupuesto> listarTodos()
        {
            return repositorio.TraerVariosPorCondicion(x=>x.estado != Estados.Anulado);
        }
        public List<TipoCambioPresupuesto> listarTodos(int anio)
        {
            return repositorio.TraerVariosPorCondicion(x => x.anio==anio && x.estado != Estados.Anulado);
        }
        public List<ItemPoco> listarMesesAnio(int anio)
        {
            return repositorio.TraerVariosPorCondicion(x => x.anio == anio && x.estado != Estados.Anulado).Select(x => new ItemPoco { id = x.mes }).ToList();
        }
        

        #endregion

    }
}
