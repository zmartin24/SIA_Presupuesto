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
    public class TipoCambioAnualServicio : ServicioBase, ITipoCambioAnualServicio
    {
        ITipoCambioAnualRepositorio repositorio;

        public TipoCambioAnualServicio(ITipoCambioAnualRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private TipoCambioAnual Clonar(TipoCambioAnual tipoCambioAnualOld)
        {
            return new TipoCambioAnual
            {
                idTipCamAnu = tipoCambioAnualOld.idTipCamAnu,
                idMoneda = tipoCambioAnualOld.idMoneda,
                anio = tipoCambioAnualOld.anio,
                valor = tipoCambioAnualOld.valor,
                usuCrea = tipoCambioAnualOld.usuCrea,
                fechaCrea = tipoCambioAnualOld.fechaCrea,
                usuEdita = tipoCambioAnualOld.usuEdita,
                fechaEdita = tipoCambioAnualOld.fechaEdita,
                estado = tipoCambioAnualOld.estado
            };
        }

        #region Operaciones
        public Resultado Nuevo(TipoCambioAnual TipoCambioAnual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(TipoCambioAnual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, TipoCambioAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, TipoCambioAnual, ex);
            }

            return resultado;
        }

        public Resultado Modificar(TipoCambioAnual TipoCambioAnual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                TipoCambioAnual obj = repositorio.TraerPorID(TipoCambioAnual.idTipCamAnu);
                obj.idMoneda = TipoCambioAnual.idMoneda;
                obj.anio = TipoCambioAnual.anio;
                obj.valor = TipoCambioAnual.valor;
                obj.usuEdita = TipoCambioAnual.usuEdita;
                obj.fechaEdita = DateTime.Now;

                repositorio.Actualizar(obj);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, TipoCambioAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, TipoCambioAnual, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(TipoCambioAnual TipoCambioAnual)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                TipoCambioAnual.estado = Estados.Anulado;
                TipoCambioAnual.fechaEdita = DateTime.Now;
                repositorio.Actualizar(TipoCambioAnual);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, TipoCambioAnual);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, TipoCambioAnual, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public TipoCambioAnual BuscarPorCodigo(int idTipoCambioAnual)
        {
            return repositorio.TraerPorID(idTipoCambioAnual);
        }
        public TipoCambioAnual BuscarPorAnio(int anio)
        {
            return repositorio.TraerPorCondicion(x => x.anio == anio && x.estado != Estados.Anulado);
        }

        public List<TipoCambioAnual> listarTodos()
        {
            return repositorio.TraerVariosPorCondicion(x=>x.estado != Estados.Anulado);
        }
        public List<TipoCambioAnual> listarTodos(int anio)
        {
            return repositorio.TraerVariosPorCondicion(x => x.anio==anio && x.estado != Estados.Anulado);
        } 

        #endregion

    }
}
