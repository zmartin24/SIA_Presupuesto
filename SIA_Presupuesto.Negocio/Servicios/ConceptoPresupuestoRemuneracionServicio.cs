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
using Utilitario.Util;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class ConceptoPresupuestoRemuneracionServicio : ServicioBase, IConceptoPresupuestoRemuneracionServicio
    {
        IConceptoPresupuestoRemuneracionRepositorio repositorio;

        public ConceptoPresupuestoRemuneracionServicio(IConceptoPresupuestoRemuneracionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private ConceptoPresupuestoRemuneracion Clonar(ConceptoPresupuestoRemuneracion ejeOperativoOld)
        {
            return new ConceptoPresupuestoRemuneracion
            {
                idConPreRem = ejeOperativoOld.idConPreRem,
                codigo = ejeOperativoOld.codigo,
                tipo = ejeOperativoOld.tipo,
                descripcion = ejeOperativoOld.descripcion,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
                idOriCon = ejeOperativoOld.idOriCon,
                abreviatura = ejeOperativoOld.abreviatura,
            };
        }

        #region Operaciones
        public Resultado Nuevo(ConceptoPresupuestoRemuneracion ConceptoPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ConceptoPresupuestoRemuneracion.codigo = ConceptoPresupuestoRemuneracion.tipo + UtilitarioComun.CompletarCeros(repositorio.TraerUltimoNumero(ConceptoPresupuestoRemuneracion.tipo), 3);
                repositorio.Agregar(ConceptoPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ConceptoPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ConceptoPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Modificar(ConceptoPresupuestoRemuneracion ConceptoPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(ConceptoPresupuestoRemuneracion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ConceptoPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ConceptoPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Anular(ConceptoPresupuestoRemuneracion ConceptoPresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ConceptoPresupuestoRemuneracion.estado = Estados.Anulado;
                ConceptoPresupuestoRemuneracion.fechaEdita = DateTime.Now;

                repositorio.Actualizar(ConceptoPresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ConceptoPresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ConceptoPresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public ConceptoPresupuestoRemuneracion BuscarPorCodigo(int idConceptoPresupuestoRemuneracion)
        {
            return repositorio.TraerPorID(idConceptoPresupuestoRemuneracion);
        }

        public List<ConceptoPresupuestoRemuneracion> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<ConceptoPresupuestoRemuneracion> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        public List<ConceptoPresupuestoRemuneracion> TraerTodosActivos(string origen)
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado && x.OrigenConcepto.codigo.Equals(origen)).ToList();
        }

        public List<ConceptoPresupuestoRemuneracion> TraerConceptosEstructura(int idEstPreRem, int idConcepto)
        {
            return repositorio.TraerConceptosEstructura(idEstPreRem, idConcepto);
        }

        public List<ConceptoPresupuestoRemuneracion> TraerConceptosMenosdeEstructura(int idEstPreRem)
        {
            return repositorio.TraerConceptosMenosdeEstructura(idEstPreRem);
        }

        #endregion
    }
}
