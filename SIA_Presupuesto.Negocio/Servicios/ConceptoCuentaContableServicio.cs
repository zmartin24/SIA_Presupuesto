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
    public class ConceptoCuentaContableServicio  : ServicioBase, IConceptoCuentaContableServicio
    {
        IConceptoCuentaContableRepositorio repositorio;

        public ConceptoCuentaContableServicio(IConceptoCuentaContableRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private ConceptoCuentaContable Clonar(ConceptoCuentaContable ejeOperativoOld)
        {
            return new ConceptoCuentaContable
            {
                numCuenta = ejeOperativoOld.numCuenta,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
                idCatLab = ejeOperativoOld.idCatLab,
                idConLab = ejeOperativoOld.idConLab,
                idRegLab = ejeOperativoOld.idRegLab,
                idConPreRem = ejeOperativoOld.idConPreRem,
            };
        }

        #region Operaciones
        public Resultado Nuevo(ConceptoCuentaContable ConceptoCuentaContable)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(ConceptoCuentaContable);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ConceptoCuentaContable);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ConceptoCuentaContable, ex);
            }

            return resultado;
        }

        public Resultado Modificar(ConceptoCuentaContable ConceptoCuentaContable)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(ConceptoCuentaContable));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ConceptoCuentaContable);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ConceptoCuentaContable, ex);
            }

            return resultado;
        }

        public Resultado Anular(ConceptoCuentaContable ConceptoCuentaContable)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ConceptoCuentaContable.estado = Estados.Anulado;
                ConceptoCuentaContable.fechaEdita = DateTime.Now;

                repositorio.Actualizar(ConceptoCuentaContable);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ConceptoCuentaContable);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ConceptoCuentaContable, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public ConceptoCuentaContable BuscarPorCodigo(int idConceptoCuentaContable)
        {
            return repositorio.TraerPorID(idConceptoCuentaContable);
        }

        public List<ConceptoCuentaContable> listarTodos()
        {
            return repositorio.TraerTodos();
        }

        public List<ConceptoCuentaContable> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        public List<DatoConceptoCuentaContable> TraerDatosConceptoCuentaContable(int idConCueCon)
        {
            return repositorio.TraerDatosConceptoCuentaContable(idConCueCon);
        }

        #endregion
    }
}
