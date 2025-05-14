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
using System.Transactions;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class ReajustePresupuestoRemuneracionServicio : ServicioBase, IReajustePresupuestoRemuneracionServicio
    {
        IReajustePresupuestoRemuneracionRepositorio repositorio;
        IReajustePresupuestoRemuneracionDetRepositorio repoDet;
        IPuestoReajustePresupuestoRepositorio repoPuesto;
        IPropiedadPresupuestoRemuneracionRepositorio repoPropiedad;
        IParametroPresupuestoRemuneracionRepositorio repoParametro;
        IProgramacionAnualRepositorio programacionRepositorio;
        IReajusteMensualProgramacionRepositorio reajusteMensualProgramacionRepositorio;
        ITipoCambioPresupuestoRepositorio tipoCambioPresupuestoRepositorio;
        ITipoCambioAnualRepositorio tipoCambioAnualRepositorio;

        public ReajustePresupuestoRemuneracionServicio(IReajustePresupuestoRemuneracionRepositorio repositorio, IReajustePresupuestoRemuneracionDetRepositorio repoDet,
            IPuestoReajustePresupuestoRepositorio repoPuesto, IPropiedadPresupuestoRemuneracionRepositorio repoPropiedad, IParametroPresupuestoRemuneracionRepositorio repoParametro,
            IProgramacionAnualRepositorio programacionRepositorio, IReajusteMensualProgramacionRepositorio reajusteMensualProgramacionRepositorio, 
            ITipoCambioPresupuestoRepositorio tipoCambioPresupuestoRepositorio, ITipoCambioAnualRepositorio tipoCambioAnualRepositorio)
        {
            this.repositorio = repositorio;
            this.repoDet = repoDet;
            this.repoPuesto = repoPuesto;
            this.repoPropiedad = repoPropiedad;
            this.repoParametro = repoParametro;
            this.programacionRepositorio = programacionRepositorio;
            this.reajusteMensualProgramacionRepositorio = reajusteMensualProgramacionRepositorio;
            this.tipoCambioPresupuestoRepositorio = tipoCambioPresupuestoRepositorio;
            this.tipoCambioAnualRepositorio = tipoCambioAnualRepositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private ReajustePresupuestoRemuneracion Clonar(ReajustePresupuestoRemuneracion ejeOperativoOld)
        {
            return new ReajustePresupuestoRemuneracion
            {
                idReaPreRem = ejeOperativoOld.idReaPreRem,
                idReaPuePre = ejeOperativoOld.idReaPuePre,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
            };
        }

        #region Operaciones
        public Resultado Nuevo(ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(ReajustePresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, ReajustePresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, ReajustePresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Nuevo(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idReaMenPro, string usuario, int mesDesde, int mesHasta)
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
                    ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion = null;
                    //ReajustePresupuestoRemuneracionDet ReajustePresupuestoRemuneracionDet = null;
                    resultadosCalculo = resultadosCalculo.OrderBy(o => o.idPuePre).ToList();
                    //int idPuesto = 0;

                    ReajusteMensualProgramacion programacion = this.reajusteMensualProgramacionRepositorio.TraerPorID(idReaMenPro);
                    if (programacion != null)
                    {
                        programacion.idEstPreRem = idEstPreRem;
                        programacion.mesDesdeRem = mesDesde;
                        programacion.mesHastaRem = mesHasta;
                        reajusteMensualProgramacionRepositorio.Actualizar(programacion);
                        unidadTrabajo.GuardarCambios();
                    }

                    var listaCabecera = resultadosCalculo.Select(s => s.idPuePre).Distinct();
                    Dictionary<int, int> lista = new Dictionary<int, int>();

                    foreach (int id in listaCabecera)
                    {
                        ReajustePresupuestoRemuneracion = new ReajustePresupuestoRemuneracion
                        {
                            idReaPuePre = id,
                            usuCrea = usuario,
                            fechaCrea = DateTime.Now,
                            estado = Estados.Activo,
                        };
                        repositorio.Agregar(ReajustePresupuestoRemuneracion);
                        unidadTrabajo.GuardarCambios();

                        lista.Add(id, ReajustePresupuestoRemuneracion.idReaPreRem);
                    }
                    int i = 0;
                    foreach (var resultado in resultadosCalculo)
                    {

                        repositorio.NuevoReajusteProgramacionDetalle(lista[resultado.idPuePre], Estados.Activo, resultado.valor, resultado.mes, DateTime.Now, usuario, resultado.idProPreRem);
                        i++;
                    }

                    unidadTrabajo.GuardarCambios();


                    resultado = MensajeSatisfactorio(TipoMensaje.Creacion, resultadosCalculo);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Creacion, resultadosCalculo, ex);
                }
            }

            return resultado;
        }

        public Resultado Modificar(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idReaMenPro, string usuario, int mesDesde, int mesHasta)
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
                    //List<PuestoPresupuesto> puestos = repoPuesto.TraerVariosPorCondicion(t => t.idProAnu == idProAnu);
                    IEnumerable<int> IDsPuestos = resultadosCalculo.Select(s => s.idPuePre).Distinct(); //puestos.Select(s => s.idPuePre);
                    List<ReajustePresupuestoRemuneracion> listaPresRem = repositorio.TraerVariosPorCondicion(t => IDsPuestos.Contains(t.idReaPuePre) && t.estado != Estados.Anulado);
                    IEnumerable<int> IDsDet = listaPresRem.Select(s => s.idReaPreRem);
                    List<ReajustePresupuestoRemuneracionDet> listaPresRemDet = repoDet.TraerVariosPorCondicion(t => IDsDet.Contains(t.idReaPreRem) && t.estado != Estados.Anulado);

                    ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion = null;
                    ReajustePresupuestoRemuneracionDet ReajustePresupuestoRemuneracionDet = null;
                    resultadosCalculo = resultadosCalculo.OrderBy(o => o.idPuePre).ToList();
                    int idPuesto = 0;


                    ReajusteMensualProgramacion programacion = this.reajusteMensualProgramacionRepositorio.TraerPorID(idReaMenPro);
                    if (programacion != null)
                    {
                        programacion.idEstPreRem = idEstPreRem;
                        programacion.mesDesdeRem = mesDesde;
                        programacion.mesHastaRem = mesHasta;
                        reajusteMensualProgramacionRepositorio.Actualizar(programacion);
                        unidadTrabajo.GuardarCambios();
                    }

                    List<int> listaIds = new List<int>();
                    List<int> listaIdsDet = new List<int>();
                    foreach (var resultado in resultadosCalculo)
                    {

                        if (idPuesto != resultado.idPuePre)
                        {
                            ReajustePresupuestoRemuneracion = listaPresRem.FirstOrDefault(f => f.idReaPuePre == resultado.idPuePre);
                            if (ReajustePresupuestoRemuneracion == null)
                            {
                                ReajustePresupuestoRemuneracion = new ReajustePresupuestoRemuneracion
                                {
                                    idReaPuePre = resultado.idPuePre,
                                    usuCrea = usuario,
                                    fechaCrea = DateTime.Now,
                                    estado = Estados.Activo,
                                };
                                repositorio.Agregar(ReajustePresupuestoRemuneracion);
                                unidadTrabajo.GuardarCambios();
                                //repositorio.Agregar(new ReajustePresupuestoRemuneracion { idReaPuePre =  })
                            }

                            listaIds.Add(ReajustePresupuestoRemuneracion.idReaPreRem);
                        }

                        if (ReajustePresupuestoRemuneracion != null)
                        {
                            ReajustePresupuestoRemuneracionDet = listaPresRemDet.FirstOrDefault(f => f.idReaPreRem == ReajustePresupuestoRemuneracion.idReaPreRem && f.idProPreRem == resultado.idProPreRem && f.mes == resultado.mes);
                            if (ReajustePresupuestoRemuneracionDet == null)
                            {
                                repositorio.NuevoReajusteProgramacionDetalle(ReajustePresupuestoRemuneracion.idReaPreRem, Estados.Activo, resultado.valor, resultado.mes, DateTime.Now, usuario, resultado.idProPreRem);
                            }
                            else
                            {
                                repositorio.ModificarReajusteProgramacionDetalle(ReajustePresupuestoRemuneracionDet.idReaPreRemDet, resultado.valor, DateTime.Now, usuario);
                                listaIdsDet.Add(ReajustePresupuestoRemuneracionDet.idReaPreRemDet);
                            }
                        }

                        idPuesto = resultado.idPuePre;
                    }
                    //unidadTrabajo.GuardarCambios();

                    //Anulacion
                    var listaAnulacion = listaPresRem.Where(w => !listaIds.Contains(w.idReaPreRem));

                    foreach (var pres in listaAnulacion)
                    {
                        //pres.usuEdita = usuario;
                        //pres.fechaEdita = DateTime.Now;
                        //pres.estado = Estados.Anulado;
                        //repositorio.Actualizar(pres);
                        //unidadTrabajo.GuardarCambios();
                        repositorio.AnularReajusteProgramacionRemuneracion(pres.idReaPreRem, usuario);
                    }

                    var listaAnulacionDet = listaPresRemDet.Where(w => !listaIdsDet.Contains(w.idReaPreRemDet));

                    foreach (var pres in listaAnulacionDet)
                    {
                        //pres.usuEdita = usuario;
                        //pres.fechaEdita = DateTime.Now;
                        //pres.estado = Estados.Anulado;
                        //repoDet.Actualizar(pres);
                        //unidadTrabajo.GuardarCambios();
                        repositorio.AnularReajusteProgramacionDetalle(pres.idReaPreRemDet, DateTime.Now, usuario);
                    }

                    resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, resultadosCalculo);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    resultado = MensajeError(repositorio, TipoMensaje.Modificacion, resultadosCalculo, ex);
                }
            }

            return resultado;
        }

        public Resultado Modificar(ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(ReajustePresupuestoRemuneracion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, ReajustePresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, ReajustePresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Anular(ReajustePresupuestoRemuneracion ReajustePresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                ReajustePresupuestoRemuneracion.estado = Estados.Anulado;
                ReajustePresupuestoRemuneracion.fechaEdita = DateTime.Now;

                repositorio.Actualizar(ReajustePresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, ReajustePresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, ReajustePresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado AnularPuestos(List<PuestoReajustePresupuesto> PuestoPresupuesto, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                string codigo = string.Join("~", PuestoPresupuesto.Select(s => s.idReaPuePre));
                repositorio.AnularPuestoReajusteRemuneracion(codigo, usuario);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, PuestoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, PuestoPresupuesto, ex);
            }

            return resultado;
        }

        public List<ResultadoCalculoPoco> CalcularReajustePresupuestoRemuneraciones(int idReaMenPro, int idEstPreRem, int mesDesde, int mesHasta)
        {
            List<PuestoPoco> listaPuestos = repoPuesto.ListaPuestos(idReaMenPro);
            List<PropiedadPoco> listaPropiedades = repoPropiedad.TraerPropiedadPresentacion(idEstPreRem);
            List<DatoCalculoPresupuestoRemuneracion> listaCalculo = new List<DatoCalculoPresupuestoRemuneracion>(); //repositorio.TraerDatosCalculoReajustePresupuestoRemuneracion(idProAnu, idEstPreRem);
            List<ParametroPresupuestoRemuneracion> listaParametros = repoParametro.TraerVariosPorCondicion(t => t.estado != Estados.Anulado);

            ReajusteMensualProgramacion reajuste = reajusteMensualProgramacionRepositorio.TraerPorCondicion(t=>t.idReaMenPro == idReaMenPro);
            ProgramacionAnual programacionAnual = programacionRepositorio.TraerPorCondicion(t => t.idProAnu == reajuste.idProAnu);
            TipoCambioAnual tipoCambioAnual = this.tipoCambioAnualRepositorio.TraerPorCondicion(t => t.anio == programacionAnual.anio && t.estado != Estados.Anulado);
            TipoCambioPresupuesto tipoCambioMensual = this.tipoCambioPresupuestoRepositorio.TraerPorCondicion(t => t.anio == programacionAnual.anio && t.mes == reajuste.mesReajuste && t.estado != Estados.Anulado);

            CalculadoraPresupuestoRemeracion calculadora = new CalculadoraPresupuestoRemeracion(listaPuestos, listaPropiedades, listaCalculo, listaParametros, 
                mesDesde, mesHasta, tipoCambioMensual, tipoCambioAnual, programacionAnual.idMoneda, reajuste.mesReajuste, programacionAnual.anio);

            return calculadora.Calcular();
        }

        public bool NuevoProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem)
        {
            return repositorio.NuevoReajusteProgramacionDetalle(idPreRem, estado, importe, mes, fechaCrea, usuCrea, idProPreRem);
        }

        public bool ModificarProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod)
        {
            return repositorio.ModificarReajusteProgramacionDetalle(idPreRemDet, importe, fechaMod, usuMod);
        }

        public bool VerificarDatosIniciales(int idReaMenPro)
        {
            return repositorio.VerificarDatosIniciales(idReaMenPro);
        }

        public bool MigrarDatosProgramacionReajuste(int idReaMenPro, string usuario)
        {
            return repositorio.MigrarDatosProgramacionReajuste(idReaMenPro, usuario);
        }

        #endregion


        #region Busquedas y listados

        public ReajustePresupuestoRemuneracion BuscarPorCodigo(int idReajustePresupuestoRemuneracion)
        {
            return repositorio.TraerPorID(idReajustePresupuestoRemuneracion);
        }

        public List<ReajustePresupuestoRemuneracion> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<ReajustePresupuestoRemuneracion> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        public List<DatosPuestoCalculo> TraerDatosPuestoCalculoReajuste(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idReaMenPro)
        {
            return repositorio.TraerDatosPuestoCalculoReajuste(idGruPre, idPresupuesto, idDireccion, idSubdireccion, condicion, idReaMenPro);
        }

        public List<CalculoReajustePresupuestoRemuneracion> TraerResultadoCalculoReajustePresupuestoRemuneracion(int idReaMenPro, int idEstPreRem)
        {
            return repositorio.TraerResultadoCalculoReajustePresupuestoRemuneracion(idReaMenPro, idEstPreRem);
        }

        public List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExporta(int idProAnu)
        {
            return repositorio.ReajustePresupuestoRemuneracionExporta(idProAnu);
        }

        public List<PresupuestoRemuneracionExporta> ReajustePresupuestoRemuneracionExportaPorGrupo(string codigoGruPre, string codigosDir, int anio, int mesReajuste)
        {
            return repositorio.ReajustePresupuestoRemuneracionExportaPorGrupo(codigoGruPre, codigosDir, anio, mesReajuste);
        }

        #endregion
    }
}
