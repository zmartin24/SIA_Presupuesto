using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PuestoRequerimientoServicio : ServicioBase, IPuestoRequerimientoServicio
    {
        IPuestoRequerimientoRepositorio repositorio;

        public PuestoRequerimientoServicio(IPuestoRequerimientoRepositorio repositorio)
        {
            this.repositorio = repositorio;
            resultado = new Resultado();
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones

        private PuestoRequerimiento Clonar(PuestoRequerimiento puestoRequerimiento)
        {
            return new PuestoRequerimiento
            {
                idPueReq = puestoRequerimiento.idPueReq,
                idReqRecHum = puestoRequerimiento.idReqRecHum,
                idTrabajador = puestoRequerimiento.idTrabajador,
                idCargo = puestoRequerimiento.idCargo,
                idSede = puestoRequerimiento.idSede,
                idTipMon = puestoRequerimiento.idTipMon,
                idRegLab = puestoRequerimiento.idRegLab,
                idConLab = puestoRequerimiento.idConLab,
                idCatLab = puestoRequerimiento.idCatLab,
                grado = puestoRequerimiento.grado,
                remuneracion = puestoRequerimiento.remuneracion,
                idCargoPropuesto = puestoRequerimiento.idCargoPropuesto,
                gradoPropuesto = puestoRequerimiento.gradoPropuesto,
                remPropuesta = puestoRequerimiento.remPropuesta,
                idFueFin = puestoRequerimiento.idFueFin,
                justificacion = puestoRequerimiento.justificacion,
                esRemDiaria = puestoRequerimiento.esRemDiaria,
                esVacante = puestoRequerimiento.esVacante,
                conBonoAlimento = puestoRequerimiento.conBonoAlimento,
                conBonoProductividad = puestoRequerimiento.conBonoProductividad,
                conBonoMovilidad = puestoRequerimiento.conBonoMovilidad,
                conBonoAlimentoAdi = puestoRequerimiento.conBonoAlimentoAdi,
                fechaInicio = puestoRequerimiento.fechaInicio,
                fechaTermino = puestoRequerimiento.fechaTermino,
                usuCrea = puestoRequerimiento.usuCrea,
                fechaCrea = puestoRequerimiento.fechaCrea,
                usuEdita = puestoRequerimiento.usuEdita,
                fechaEdita = puestoRequerimiento.fechaEdita,
                estado = puestoRequerimiento.estado
            };
        }

        public Resultado Nuevo(PuestoRequerimiento puestoRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(puestoRequerimiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, puestoRequerimiento);
                resultado.id = puestoRequerimiento.idPueReq;
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, puestoRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado Modificar(PuestoRequerimiento puestoRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(Clonar(puestoRequerimiento));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, puestoRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, puestoRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado ModificarSinClonar(PuestoRequerimiento puestoRequerimiento)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                repositorio.Actualizar(puestoRequerimiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, puestoRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, puestoRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado Anular(PuestoRequerimiento puestoRequerimiento, string usuario)
        {
            PuestoRequerimiento objPuestoRequerimiento;
            try
            {
                objPuestoRequerimiento = Clonar(puestoRequerimiento);
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                objPuestoRequerimiento.estado = Estados.Anulado;
                objPuestoRequerimiento.usuCrea = usuario;
                objPuestoRequerimiento.fechaEdita = DateTime.Now;

                repositorio.Actualizar(objPuestoRequerimiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, puestoRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, puestoRequerimiento, ex);
            }

            return resultado;
        }
        public Resultado AnularSinClonar(PuestoRequerimiento puestoRequerimiento, string usuario)
        {
            PuestoRequerimiento objPuestoRequerimiento;
            try
            {
                objPuestoRequerimiento = puestoRequerimiento;
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                objPuestoRequerimiento.estado = Estados.Anulado;
                objPuestoRequerimiento.usuCrea = usuario;
                objPuestoRequerimiento.fechaEdita = DateTime.Now;

                repositorio.Actualizar(objPuestoRequerimiento);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, puestoRequerimiento);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, puestoRequerimiento, ex);
            }

            return resultado;
        }
        public bool GuardarPuestoRequerimientoEnProgramacionAnual(string codigos, int idProAnu, string usuario)
        {
            return repositorio.GuardarPuestoRequerimientoEnProgramacionAnual(codigos, idProAnu, usuario);
        }

        #endregion

        #region Busquedas y listados
        public PuestoRequerimiento BuscarPorCodigo(int idPueReq)
        {
            return repositorio.TraerPorID(idPueReq);
        }
        public PuestoRequerimiento BuscarPorTrabajador(int idReqRecHum, int idTrabajador)
        {
            return repositorio.TraerPorCondicion(x => x.idReqRecHum == idReqRecHum && x.idTrabajador == idTrabajador && x.estado != Estados.Anulado);
        }
        public List<TrabajadorPres> ListaTrabajadoresRequerimiento(int anio)
        {
            return repositorio.ListaTrabajadoresRequerimiento(anio);
        }
        public List<PuestoRequerimientoAnualPres> TraerListaPuestoRequerimientoAnual(int anio)
        {
            return repositorio.TraerListaPuestoRequerimientoAnual(anio);
        }
        #endregion

        #region Reportes


        #endregion
    }
}
