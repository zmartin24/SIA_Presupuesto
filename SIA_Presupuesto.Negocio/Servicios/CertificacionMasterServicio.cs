using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class CertificacionMasterServicio : ServicioBase, ICertificacionMasterServicio
    {
        ICertificacionMasterRepositorio repositorio;
        ICertificacionRequerimientoRepositorio repoReq;

        public CertificacionMasterServicio(ICertificacionMasterRepositorio repositorio, ICertificacionRequerimientoRepositorio repoReq)
        {
            this.repositorio = repositorio;
            this.repoReq = repoReq;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Clon
        private CertificacionMaster Clonar(CertificacionMaster certificacionMasterOld)
        {
            return new CertificacionMaster
            {
                idCerMas = certificacionMasterOld.idCerMas,
                tipoReq = certificacionMasterOld.tipoReq,
                idForebise = certificacionMasterOld.idForebise,
                esTotalDetallado = certificacionMasterOld.esTotalDetallado,
                observacion = certificacionMasterOld.observacion,
                usuCrea = certificacionMasterOld.usuCrea,
                fechaCrea = certificacionMasterOld.fechaCrea,
                usuEdita = certificacionMasterOld.usuEdita,
                fechaEdita = certificacionMasterOld.fechaEdita,
                estado = certificacionMasterOld.estado
            };
        }
        #endregion
        #region Operaciones
        
        public Resultado Nuevo(CertificacionMaster certificacionMaster)
        {
            TransactionOptions Tranconfiguracion = new TransactionOptions()
            {
                Timeout = TransactionManager.MaximumTimeout,
                IsolationLevel = IsolationLevel.Serializable
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, Tranconfiguracion))
            {
                try
                {
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                   
                    repositorio.Agregar(certificacionMaster);
                    
                    unidadTrabajo.GuardarCambios();
                    scope.Complete();
                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, certificacionMaster);
                    resultado.id = certificacionMaster.idCerMas;
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, certificacionMaster, ex);
                }
            }

            return resultado;
        }
        public Resultado Modificar(CertificacionMaster certificacionMaster)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                CertificacionMaster clon = Clonar(certificacionMaster);
                
                repositorio.Actualizar(clon);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, certificacionMaster);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, certificacionMaster, ex);
            }

            return resultado;
        }
        public Resultado Anular(int opcion, CertificacionMaster certificacionMaster, string usuario)
        {
            resultado = new Resultado();
            try
            {
                resultado.esCorrecto = repositorio.AnularCertificacionMaster(opcion, certificacionMaster.idCerMas, certificacionMaster.tipoReq, usuario);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, certificacionMaster, ex);
            }

            return resultado;
        }
        #endregion

        #region Busqueda y listas
        public CertificacionMaster BuscarPorCodigo(int idCerMas)
        {
            return repositorio.TraerPorCondicion(x => x.idCerMas == idCerMas && x.estado != 1);
        }
        public Forebi BuscarForebi(int idForebi)
        {

            return repositorio.BuscarForebi(idForebi);
        }
        public Forese BuscarForese(int idForese)
        {
            return repositorio.BuscarForese(idForese);
        }
        public ForeDetallePoco BuscarForebiDetallePoco(int idForeDet)
        {
            return repositorio.BuscarForebiDetallePoco(idForeDet);
        }
        public ForeDetallePoco BuscarForeseDetallePoco(int idForeDet)
        {
            return repositorio.BuscarForeseDetallePoco(idForeDet);
        }

        public List<CertificacionMasterPres> TraerListaCertificacionMaster(int anio)
        {
            return repositorio.TraerListaCertificacionMaster(anio);
        }
        public List<Forebi> TraerListaForebiTodos()
        {
            return repositorio.TraerListaForebiTodos();
        }
        public List<Forese> TraerListaForeseTodos()
        {
            return repositorio.TraerListaForeseTodos();
        }
        public List<CertificacionRequerimiento> TraerListaCertificacionRequerimiento(int idCerMas)
        {
            return repoReq.TraerVariosPorCondicion(x => x.idCerMas == idCerMas && x.estado != 1);
        }
        public ValidarForebisePres ValidarForebise(int idCerMas)
        {
            return repositorio.ValidarForebise(idCerMas);
        }

        #endregion

        #region Reporte
        #endregion
    }
}
