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
    public class FuenteFinanciamientoServicio : ServicioBase, IFuenteFinanciamientoServicio
    {
        private IFuenteFinanciamientoRepositorio repositorio;

        public FuenteFinanciamientoServicio(IFuenteFinanciamientoRepositorio vrepositorio)
        {
            this.repositorio = vrepositorio;
        }

        private FuenteFinanciamiento Clonar(FuenteFinanciamiento fuenteFinanciamientoOld)
        {
            return new FuenteFinanciamiento
            {
                idFueFin = fuenteFinanciamientoOld.idFueFin,
                anio = fuenteFinanciamientoOld.anio,
                fuente = fuenteFinanciamientoOld.fuente,
                codigo = fuenteFinanciamientoOld.codigo,
                rubro = fuenteFinanciamientoOld.rubro,
                desRubro = fuenteFinanciamientoOld.desRubro,
                usuCrea = fuenteFinanciamientoOld.usuCrea,
                fechaCrea = fuenteFinanciamientoOld.fechaCrea,
                usuMod = fuenteFinanciamientoOld.usuMod,
                fechaMod = fuenteFinanciamientoOld.fechaMod,
                estado = fuenteFinanciamientoOld.estado
            };
        }
        
        #region Procesos
        public Resultado Nuevo(FuenteFinanciamiento fuenteFinanciamiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(fuenteFinanciamiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, fuenteFinanciamiento);
                resultado.id = fuenteFinanciamiento.idFueFin;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, fuenteFinanciamiento, ex);
            }

            return resultado;
        }
        public Resultado Modificar(FuenteFinanciamiento fuenteFinanciamiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(fuenteFinanciamiento));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, fuenteFinanciamiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, fuenteFinanciamiento, ex);
            }

            return resultado;
        }
        public Resultado Anular(FuenteFinanciamiento fuenteFinanciamiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                fuenteFinanciamiento.estado = Estados.Anulado;
                fuenteFinanciamiento.fechaMod = DateTime.Now;

                repositorio.Actualizar(fuenteFinanciamiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, fuenteFinanciamiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, fuenteFinanciamiento, ex);
            }

            return resultado;
        }

        #endregion

        #region Busqueda y Listas
        public FuenteFinanciamiento BuscarPorId(int idFueFin)
        {
            return repositorio.TraerPorID(idFueFin);
        }
        public List<FuenteFinanciamiento> TraerListaFuenteFinanciamiento(int vAnio)
        {
            return repositorio.TraerVariosPorCondicion(x => x.anio == vAnio && x.estado != Estados.Anulado).ToList();
        }
        public List<FuenteFinanciamiento> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }
        #endregion
    }
}
