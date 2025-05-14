using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class RubroBienServicio : ServicioBase, IRubroBienServicio
    {
        IRubroBienServicioRepositorio repositorio;

        public RubroBienServicio(IRubroBienServicioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Resultado Anular(int idRubroBienServicio)
        {
            Entidades.RubroBienServicio objRubroBienServicio = repositorio.TraerPorID(idRubroBienServicio);
            try
            {
                objRubroBienServicio.estado = Estados.Anulado;
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(objRubroBienServicio);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, objRubroBienServicio);
                resultado.id = objRubroBienServicio.idRubBieSer;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, objRubroBienServicio, ex);
            }

            return resultado;
        }

        public Resultado Modificar(Entidades.RubroBienServicio rubroBienServicio)
        {
            try
            {
                Entidades.RubroBienServicio objRubroBienServicio = repositorio.TraerPorID(rubroBienServicio.idRubBieSer);

                objRubroBienServicio.descripcion = rubroBienServicio.descripcion;
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

        public Resultado Nuevo(Entidades.RubroBienServicio rubroBienServicio)
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

        public List<RubroBienServicioPoco> ObtenerLista()
        {
            return repositorio.TraerLista();
        }
    }
}
