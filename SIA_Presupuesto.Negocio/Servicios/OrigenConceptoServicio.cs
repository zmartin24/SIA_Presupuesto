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
    public class OrigenConceptoServicio : ServicioBase, IOrigenConceptoServicio
    {
        IOrigenConceptoRepositorio repositorio;

        public OrigenConceptoServicio(IOrigenConceptoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private OrigenConcepto Clonar(OrigenConcepto ejeOperativoOld)
        {
            return new OrigenConcepto
            {
                codigo = ejeOperativoOld.codigo,
                descripcion = ejeOperativoOld.descripcion,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
                idOriCon = ejeOperativoOld.idOriCon,
            };
        }

        #region Operaciones
        public Resultado Nuevo(OrigenConcepto OrigenConcepto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(OrigenConcepto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, OrigenConcepto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, OrigenConcepto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(OrigenConcepto OrigenConcepto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(OrigenConcepto));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, OrigenConcepto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, OrigenConcepto, ex);
            }

            return resultado;
        }

        public Resultado Anular(OrigenConcepto OrigenConcepto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                OrigenConcepto.estado = Estados.Anulado;
                OrigenConcepto.fechaEdita = DateTime.Now;

                repositorio.Actualizar(OrigenConcepto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, OrigenConcepto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, OrigenConcepto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public OrigenConcepto BuscarPorCodigo(int idOrigenConcepto)
        {
            return repositorio.TraerPorID(idOrigenConcepto);
        }

        public List<OrigenConcepto> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<OrigenConcepto> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        #endregion
    }
}
