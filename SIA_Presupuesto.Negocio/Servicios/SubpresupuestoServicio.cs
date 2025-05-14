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
    public class SubpresupuestoServicio : ServicioBase, ISubpresupuestoServicio
    {
        ISubpresupuestoRepositorio repositorio;

        public SubpresupuestoServicio(ISubpresupuestoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        public Resultado Nuevo(Subpresupuesto Subpresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(Subpresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, Subpresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, Subpresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(Subpresupuesto Subpresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                Subpresupuesto objSubPresupuesto = repositorio.TraerPorID(Subpresupuesto.idSubpresupuesto);

                objSubPresupuesto.idSubpresupuesto = Subpresupuesto.idSubpresupuesto;
                objSubPresupuesto.idProAnu = Subpresupuesto.idProAnu;
                objSubPresupuesto.descripcion = Subpresupuesto.descripcion;
                objSubPresupuesto.abreviatura = Subpresupuesto.abreviatura;
                objSubPresupuesto.nroProyecto = Subpresupuesto.nroProyecto;
                objSubPresupuesto.esObra = Subpresupuesto.esObra;
                objSubPresupuesto.esEncargo = Subpresupuesto.esEncargo;
                objSubPresupuesto.esActividadCampo = Subpresupuesto.esActividadCampo;
                objSubPresupuesto.esErradicacion = Subpresupuesto.esErradicacion;
                objSubPresupuesto.anio = Subpresupuesto.anio;
                objSubPresupuesto.mes = Subpresupuesto.mes;
                objSubPresupuesto.usuEdita = Subpresupuesto.usuEdita;
                objSubPresupuesto.fechaEdita = Subpresupuesto.fechaEdita;
                objSubPresupuesto.importe = Subpresupuesto.importe;

                repositorio.Actualizar(objSubPresupuesto);

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, Subpresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, Subpresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Anular(SubPresupuestoPoco SubPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                Subpresupuesto objSubPresupuesto = repositorio.TraerPorID(SubPresupuesto.idSubPresupuesto);
                objSubPresupuesto.usuEdita = SubPresupuesto.usuEdita;
                objSubPresupuesto.fechaEdita = DateTime.Now;
                objSubPresupuesto.estado = Estados.Anulado;

                repositorio.Actualizar(objSubPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, SubPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, SubPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Aprobar(SubPresupuestoPoco SubPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                Subpresupuesto objSubPresupuesto = repositorio.TraerPorID(SubPresupuesto.idSubPresupuesto);
                objSubPresupuesto.usuEdita = SubPresupuesto.usuEdita;
                objSubPresupuesto.fechaEdita = DateTime.Now;
                objSubPresupuesto.estado = Entidades.Enumeradores.Estados.Aprobado;

                repositorio.Actualizar(objSubPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, SubPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, SubPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Liquidar(SubPresupuestoPoco SubPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                Subpresupuesto objSubPresupuesto = repositorio.TraerPorID(SubPresupuesto.idSubPresupuesto);
                objSubPresupuesto.usuEdita = SubPresupuesto.usuEdita;
                objSubPresupuesto.fechaEdita = DateTime.Now;
                objSubPresupuesto.estado = Entidades.Enumeradores.Estados.Liquidado;

                repositorio.Actualizar(objSubPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, SubPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, SubPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(Subpresupuesto Subpresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Eliminar(Subpresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, Subpresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, Subpresupuesto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public Subpresupuesto BuscarPorCodigo(int idSubpresupuesto)
        {
            return repositorio.TraerPorID(idSubpresupuesto);
        }
        public Subpresupuesto BuscarPorDescripcion(int idProAnu, string descripcion)
        {
            return repositorio.TraerPorCondicion(x=> x.idProAnu == idProAnu && x.descripcion.Trim().ToUpper() == descripcion.Trim().ToUpper() && x.estado != Estados.Anulado);
        }
        public SubPresupuestoPoco BuscarSubPresupuestoPoco(int idSubPresupuesto)
        {
            return repositorio.BuscarSubPresupuestoPoco(idSubPresupuesto);
        }

        public List<Subpresupuesto> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<Subpresupuesto> TraerListaSubPresupuestoPorPresupuesto(int idPresupuesto)
        {
            return repositorio.TraerListaSubPresupuestoPorPresupuesto(idPresupuesto);
        }

        public List<SubPresupuestoPoco> TraerListaSubPresupuesto(int vanio)
        {
            return repositorio.TraerListaSubPresupuesto(vanio).OrderByDescending(t => t.idSubPresupuesto).ToList();
        }
        public List<SubPresupuestoAreaPres> TraerListaSubPresupuestoAreaPres(int idSubPresupuesto)
        {
            return repositorio.TraerListaSubPresupuestoAreaPres(idSubPresupuesto);
        }
        public List<ReporteSubpresupuestoExportaPres> TraerReporteSubpresupuestoExporta(int idSubPresupuesto, int idMoneda)
        {
            return repositorio.TraerReporteSubpresupuestoExporta(idSubPresupuesto, idMoneda);
        }
        public Resultado VerificarSubpresupuesto(int idPresupuesto)
        {
            return repositorio.VerificarSubpresupuesto(idPresupuesto);
        }

        #endregion
    }
}
