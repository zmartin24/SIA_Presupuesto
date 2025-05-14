using System;
using System.Collections.Generic;
using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PoaServicio : ServicioBase, IPoaServicio
    {
        IPoaRepositorio repositorio;

        public PoaServicio(IPoaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        #region Procesos
        public Resultado Nuevo(Poa poa)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(poa);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, poa);
                resultado.id = poa.idPoa;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, poa, ex);
            }

            return resultado;
        }
        public Resultado Modificar(Poa poa)
        {
            try
            {
                Poa objPoa = repositorio.TraerPorID(poa.idPoa);

                objPoa.codigoPoa = poa.codigoPoa;
                objPoa.nombre = poa.nombre;
                objPoa.objetivo = poa.objetivo;

                objPoa.usuEdita = poa.usuEdita;
                objPoa.fechaEdita = poa.fechaEdita;

                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objPoa);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, poa);
                resultado.id = poa.idPoa;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, poa, ex);
            }

            return resultado;
        }

        public Resultado Anular(int idPoa)
        {
            Poa objPoa = repositorio.TraerPorID(idPoa);
            try
            {
                objPoa.estado = Estados.Anulado;
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objPoa);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, objPoa);
                resultado.id = objPoa.idPoa;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, objPoa, ex);
            }

            return resultado;
        }
        #endregion

        #region Listas
        public List<PoaVersionPoco> ListaPoaVersiones(int anio)
        {
            return repositorio.ListaPoaVersiones(anio);
        }
        #endregion
    }
}
