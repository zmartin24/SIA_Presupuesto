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
    public class PuestoPresupuestoServicio : ServicioBase, IPuestoPresupuestoServicio
    {
        IPuestoPresupuestoRepositorio repositorio;

        public PuestoPresupuestoServicio(IPuestoPresupuestoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private PuestoPresupuesto Clonar(PuestoPresupuesto ejeOperativoOld)
        {
            return new PuestoPresupuesto
            {
                idCargo = ejeOperativoOld.idCargo,
                idTrabajador = ejeOperativoOld.idTrabajador,
                idProAnu = ejeOperativoOld.idProAnu,
                idPuePre = ejeOperativoOld.idPuePre,
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
                conSctrSalud = ejeOperativoOld.conSctrSalud,
                conSctrPension = ejeOperativoOld.conSctrPension,
                situacionEspecial = ejeOperativoOld.situacionEspecial,
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

        public Resultado Nuevo(List<PuestoPresupuesto> PuestoPresupuestos)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                foreach (var PuestoPresupuesto in PuestoPresupuestos)
                {
                    repositorio.Agregar(PuestoPresupuesto);
                    unidadTrabajo.GuardarCambios();
                }
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, PuestoPresupuestos);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, PuestoPresupuestos, ex);
            }

            return resultado;
        }

        public Resultado Nuevo(PuestoPresupuesto PuestoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(PuestoPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, PuestoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, PuestoPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Modificar(PuestoPresupuesto PuestoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(PuestoPresupuesto));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, PuestoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, PuestoPresupuesto, ex);
            }

            return resultado;
        }

        public Resultado Anular(PuestoPresupuesto PuestoPresupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                PuestoPresupuesto.estado = Estados.Anulado;
                PuestoPresupuesto.fechaEdita = DateTime.Now;

                repositorio.Actualizar(PuestoPresupuesto);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, PuestoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, PuestoPresupuesto, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public PuestoPresupuesto BuscarPorCodigo(int idPuestoPresupuesto)
        {
            return repositorio.TraerPorID(idPuestoPresupuesto);
        }

        public List<PuestoPresupuesto> BuscarPorCodigo(List<int> ids)
        {
            return repositorio.TraerVariosPorCondicion(t=> ids.Contains(t.idPuePre));
        }


        public List<PuestoPresupuesto> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<PuestoPresupuesto> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        #endregion
    }
}
