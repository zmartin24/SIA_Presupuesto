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
    public class PuestoReajustePresupuestoServicio : ServicioBase, IPuestoReajustePresupuestoServicio
    {
        IPuestoReajustePresupuestoRepositorio repositorio;

        public PuestoReajustePresupuestoServicio(IPuestoReajustePresupuestoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private PuestoReajustePresupuesto Clonar(PuestoReajustePresupuesto ejeOperativoOld)
        {
            return new PuestoReajustePresupuesto
            {
                idCargo = ejeOperativoOld.idCargo,
                idTrabajador = ejeOperativoOld.idTrabajador,
                idReaMenPro = ejeOperativoOld.idReaMenPro,
                idReaPuePre = ejeOperativoOld.idReaPuePre,
                idSede = ejeOperativoOld.idSede,
                cantVacante = ejeOperativoOld.cantVacante,
                esRemDiaria = ejeOperativoOld.esRemDiaria,
                esVacante = ejeOperativoOld.esVacante,
                grado = ejeOperativoOld.grado,
                remuneracion = ejeOperativoOld.remuneracion,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
                conBonoAlimento = ejeOperativoOld.conBonoAlimento,
                conBonoAlimentoAdi = ejeOperativoOld.conBonoAlimentoAdi,
                conBonoMovilidad = ejeOperativoOld.conBonoMovilidad,
                conBonoProductividad = ejeOperativoOld.conBonoProductividad,
                idCatLab = ejeOperativoOld.idCatLab,
                idConLab = ejeOperativoOld.idConLab,
                idRegLab = ejeOperativoOld.idRegLab,
                idTipMon = ejeOperativoOld.idTipMon,
                idArea = ejeOperativoOld.idArea,
                fechaInicio = ejeOperativoOld.fechaInicio,
                fechaTermino = ejeOperativoOld.fechaTermino,
                
            };
        }

        #region Operaciones

        public Resultado Nuevo(List<PuestoReajustePresupuesto> PuestoReajustePresupuestos)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                foreach (var PuestoReajustePresupuesto in PuestoReajustePresupuestos)
                {
                    repositorio.Agregar(PuestoReajustePresupuesto);
                    unidadTrabajo.GuardarCambios();
                }
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, PuestoReajustePresupuestos);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, PuestoReajustePresupuestos, ex);
            }

            return resultado;
        }

        public Resultado Nuevo(PuestoReajustePresupuesto PuestoReajustePresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(PuestoReajustePresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, PuestoReajustePresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, PuestoReajustePresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(PuestoReajustePresupuesto PuestoReajustePresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(PuestoReajustePresupuesto));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, PuestoReajustePresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, PuestoReajustePresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Anular(PuestoReajustePresupuesto PuestoReajustePresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                PuestoReajustePresupuesto.estado = Estados.Anulado;
                PuestoReajustePresupuesto.fechaEdita = DateTime.Now;

                repositorio.Actualizar(PuestoReajustePresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, PuestoReajustePresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, PuestoReajustePresupuesto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public PuestoReajustePresupuesto BuscarPorCodigo(int idPuestoReajustePresupuesto)
        {
            return repositorio.TraerPorID(idPuestoReajustePresupuesto);
        }

        public List<PuestoReajustePresupuesto> BuscarPorCodigo(List<int> ids)
        {
            return repositorio.TraerVariosPorCondicion(t=> ids.Contains(t.idReaPuePre));
        }


        public List<PuestoReajustePresupuesto> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<PuestoReajustePresupuesto> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        #endregion
    }
}
