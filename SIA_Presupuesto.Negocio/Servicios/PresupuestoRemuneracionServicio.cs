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
    public class PresupuestoRemuneracionServicio : ServicioBase, IPresupuestoRemuneracionServicio
    {
        IPresupuestoRemuneracionRepositorio repositorio;
        IPresupuestoRemuneracionDetRepositorio repoDet;
        IPuestoPresupuestoRepositorio repoPuesto;
        IPropiedadPresupuestoRemuneracionRepositorio repoPropiedad;
        IParametroPresupuestoRemuneracionRepositorio repoParametro;
        IProgramacionAnualRepositorio programacionRepositorio;
        ITipoCambioPresupuestoRepositorio tipoCambioPresupuestoRepositorio;
        ITipoCambioAnualRepositorio tipoCambioAnualRepositorio;

        public PresupuestoRemuneracionServicio(IPresupuestoRemuneracionRepositorio repositorio, IPresupuestoRemuneracionDetRepositorio repoDet,
            IPuestoPresupuestoRepositorio repoPuesto, IPropiedadPresupuestoRemuneracionRepositorio repoPropiedad, IParametroPresupuestoRemuneracionRepositorio repoParametro,
            IProgramacionAnualRepositorio programacionRepositorio, ITipoCambioPresupuestoRepositorio tipoCambioPresupuestoRepositorio, ITipoCambioAnualRepositorio tipoCambioAnualRepositorio)
        {
            this.repositorio = repositorio;
            this.repoDet = repoDet;
            this.repoPuesto = repoPuesto;
            this.repoPropiedad = repoPropiedad;
            this.repoParametro = repoParametro;
            this.programacionRepositorio = programacionRepositorio;
            this.tipoCambioPresupuestoRepositorio = tipoCambioPresupuestoRepositorio;
            this.tipoCambioAnualRepositorio = tipoCambioAnualRepositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        private PresupuestoRemuneracion Clonar(PresupuestoRemuneracion ejeOperativoOld)
        {
            return new PresupuestoRemuneracion
            {
                idPreRem = ejeOperativoOld.idPreRem,
                idPuePre = ejeOperativoOld.idPuePre,
                usuCrea = ejeOperativoOld.usuCrea,
                fechaCrea = ejeOperativoOld.fechaCrea,
                usuEdita = ejeOperativoOld.usuEdita,
                fechaEdita = ejeOperativoOld.fechaEdita,
                estado = ejeOperativoOld.estado,
            };
        }

        #region Operaciones
        public Resultado Nuevo(PresupuestoRemuneracion PresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Agregar(PresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, PresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, PresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Nuevo(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idProAnu, string usuario, int mesDesde, int mesHasta)
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
                    PresupuestoRemuneracion PresupuestoRemuneracion = null;
                    //PresupuestoRemuneracionDet PresupuestoRemuneracionDet = null;
                    resultadosCalculo = resultadosCalculo.OrderBy(o => o.idPuePre).ToList();
                    //int idPuesto = 0;

                    ProgramacionAnual programacion = this.programacionRepositorio.TraerPorID(idProAnu);
                    if(programacion != null)
                    {
                        programacion.idEstPreRem = idEstPreRem;
                        programacion.mesDesdeRem = mesDesde;
                        programacion.mesHastaRem = mesHasta;
                        programacionRepositorio.Actualizar(programacion);
                        unidadTrabajo.GuardarCambios();
                    }

                    var listaCabecera = resultadosCalculo.Select(s => s.idPuePre).Distinct();
                    Dictionary<int, int> lista = new Dictionary<int, int>();

                    foreach(int id in listaCabecera)
                    {
                        PresupuestoRemuneracion = new PresupuestoRemuneracion
                        {
                            idPuePre = id,
                            usuCrea = usuario,
                            fechaCrea = DateTime.Now,
                            estado = Estados.Activo,
                        };
                        repositorio.Agregar(PresupuestoRemuneracion);
                        unidadTrabajo.GuardarCambios();

                        lista.Add(id, PresupuestoRemuneracion.idPreRem);
                    }
                    int i = 0;
                    foreach (var resultado in resultadosCalculo)
                    {

                        repositorio.NuevoProgramacionDetalle(lista[resultado.idPuePre], Estados.Activo, resultado.valor, resultado.mes, DateTime.Now, usuario, resultado.idProPreRem);
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

        public Resultado Modificar(List<ResultadoCalculoPoco> resultadosCalculo, int idEstPreRem, int idProAnu, string usuario, int mesDesde, int mesHasta)
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
                    List<PresupuestoRemuneracion> listaPresRem = repositorio.TraerVariosPorCondicion(t => IDsPuestos.Contains(t.idPuePre) && t.estado != Estados.Anulado);
                    IEnumerable<int> IDsDet = listaPresRem.Select(s => s.idPreRem);
                    List<PresupuestoRemuneracionDet> listaPresRemDet = repoDet.TraerVariosPorCondicion(t => IDsDet.Contains(t.idPreRem) && t.estado != Estados.Anulado);

                    PresupuestoRemuneracion PresupuestoRemuneracion = null;
                    PresupuestoRemuneracionDet PresupuestoRemuneracionDet = null;
                    resultadosCalculo = resultadosCalculo.OrderBy(o => o.idPuePre).ToList();
                    int idPuesto = 0;


                    ProgramacionAnual programacion = this.programacionRepositorio.TraerPorID(idProAnu);
                    if (programacion != null)
                    {
                        programacion.idEstPreRem = idEstPreRem;
                        programacion.mesDesdeRem = mesDesde;
                        programacion.mesHastaRem = mesHasta;
                        programacionRepositorio.Actualizar(programacion);
                        unidadTrabajo.GuardarCambios();
                    }

                    List<int> listaIds = new List<int>();
                    List<int> listaIdsDet = new List<int>();
                    foreach (var resultado in resultadosCalculo)
                    {

                        if (idPuesto != resultado.idPuePre)
                        {
                            PresupuestoRemuneracion = listaPresRem.FirstOrDefault(f => f.idPuePre == resultado.idPuePre);
                            if (PresupuestoRemuneracion == null)
                            {
                                PresupuestoRemuneracion = new PresupuestoRemuneracion
                                {
                                    idPuePre = resultado.idPuePre,
                                    usuCrea = usuario,
                                    fechaCrea = DateTime.Now,
                                    estado = Estados.Activo,
                                };
                                repositorio.Agregar(PresupuestoRemuneracion);
                                unidadTrabajo.GuardarCambios();
                            }

                            listaIds.Add(PresupuestoRemuneracion.idPreRem);
                        }

                        if (PresupuestoRemuneracion != null)
                        {
                            PresupuestoRemuneracionDet = listaPresRemDet.FirstOrDefault(f => f.idPreRem == PresupuestoRemuneracion.idPreRem && f.idProPreRem == resultado.idProPreRem && f.mes == resultado.mes);
                            if (PresupuestoRemuneracionDet == null)
                            {
                                repositorio.NuevoProgramacionDetalle(PresupuestoRemuneracion.idPreRem, Estados.Activo, resultado.valor, resultado.mes, DateTime.Now, usuario, resultado.idProPreRem);
                            }
                            else
                            {
                                repositorio.ModificarProgramacionDetalle(PresupuestoRemuneracionDet.idPreRemDet, resultado.valor, DateTime.Now, usuario);
                                listaIdsDet.Add(PresupuestoRemuneracionDet.idPreRemDet);
                            }
                        }

                        idPuesto = resultado.idPuePre;
                    }
                    unidadTrabajo.GuardarCambios();

                    //Anulacion
                    var listaAnulacion = listaPresRem.Where(w => !listaIds.Contains(w.idPreRem));

                    foreach (var pres in listaAnulacion)
                    {
                        //pres.usuEdita = usuario;
                        //pres.fechaEdita = DateTime.Now;
                        //pres.estado = Estados.Anulado;
                        //repositorio.Actualizar(pres);
                        //unidadTrabajo.GuardarCambios();
                        repositorio.AnularProgramacionRemuneracion(pres.idPreRem, usuario);
                    }

                    var listaAnulacionDet = listaPresRemDet.Where(w => !listaIdsDet.Contains(w.idPreRemDet));

                    foreach (var pres in listaAnulacionDet)
                    {
                        //pres.usuEdita = usuario;
                        //pres.fechaEdita = DateTime.Now;
                        //pres.estado = Estados.Anulado;
                        //repoDet.Actualizar(pres);
                        //unidadTrabajo.GuardarCambios();
                        repositorio.AnularProgramacionRemuneracion(pres.idPreRemDet, DateTime.Now, usuario);
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

        public Resultado Modificar(PresupuestoRemuneracion PresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(Clonar(PresupuestoRemuneracion));
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, PresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, PresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado Anular(PresupuestoRemuneracion PresupuestoRemuneracion)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                PresupuestoRemuneracion.estado = Estados.Anulado;
                PresupuestoRemuneracion.fechaEdita = DateTime.Now;

                repositorio.Actualizar(PresupuestoRemuneracion);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, PresupuestoRemuneracion);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, PresupuestoRemuneracion, ex);
            }

            return resultado;
        }

        public Resultado AnularPuestos(List<PuestoPresupuesto> PuestoPresupuesto, string usuario)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                string codigo = string.Join("~", PuestoPresupuesto.Select(s => s.idPuePre));
                repositorio.AnularPuesto(codigo, usuario);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, PuestoPresupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, PuestoPresupuesto, ex);
            }

            return resultado;
        }

        public List<ResultadoCalculoPoco> CalcularPresupuestoRemuneraciones(int idProAnu, int idEstPreRem, int mesDesde, int mesHasta)
        {
            
            List<PuestoPoco> listaPuestos = repoPuesto.ListaPuestos(idProAnu);
            List<PropiedadPoco> listaPropiedades = repoPropiedad.TraerPropiedadPresentacion(idEstPreRem);
            List<DatoCalculoPresupuestoRemuneracion> listaCalculo = repositorio.TraerDatosCalculoPresupuestoRemuneracion(idProAnu, idEstPreRem);
            List<ParametroPresupuestoRemuneracion> listaParametros = repoParametro.TraerVariosPorCondicion(t => t.estado != Estados.Anulado);

            ProgramacionAnual programacionAnual = programacionRepositorio.TraerPorCondicion(t => t.idProAnu == idProAnu);
            TipoCambioAnual tipoCambioAnual = this.tipoCambioAnualRepositorio.TraerPorCondicion(t => t.anio == programacionAnual.anio && t.estado != Estados.Anulado);

            CalculadoraPresupuestoRemeracion calculadora = new CalculadoraPresupuestoRemeracion(listaPuestos, listaPropiedades, listaCalculo, 
                listaParametros, mesDesde, mesHasta, null, tipoCambioAnual, programacionAnual.idMoneda, 0, programacionAnual.anio);

            return calculadora.Calcular();
        }

        public bool NuevoProgramacionDetalle(int idPreRem, int estado, decimal importe, int mes, DateTime fechaCrea, string usuCrea, int idProPreRem)
        {
            return repositorio.NuevoProgramacionDetalle(idPreRem, estado, importe, mes, fechaCrea, usuCrea, idProPreRem);
        }

        public bool ModificarProgramacionDetalle(int idPreRemDet, decimal importe, DateTime fechaMod, string usuMod)
        {
            return repositorio.ModificarProgramacionDetalle(idPreRemDet, importe, fechaMod, usuMod);
        }

        #endregion


        #region Busquedas y listados

        public PresupuestoRemuneracion BuscarPorCodigo(int idPresupuestoRemuneracion)
        {
            return repositorio.TraerPorID(idPresupuestoRemuneracion);
        }

        public List<PresupuestoRemuneracion> listarTodos()
        {
            return repositorio.TraerTodos();
        }
        public List<PresupuestoRemuneracion> TraerTodosActivos()
        {
            return repositorio.TraerVariosPorCondicion(x => x.estado != Estados.Anulado).ToList();
        }

        public List<DatosPuestoCalculo> TraerDatosPuestoCalculo(int idGruPre, int idPresupuesto, int idDireccion, int idSubdireccion, string condicion, int idProAnu)
        {
            return repositorio.TraerDatosPuestoCalculo(idGruPre, idPresupuesto, idDireccion, idSubdireccion, condicion, idProAnu);
        }

        public List<DatoCalculoPresupuestoRemuneracion> TraerDatosCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem)
        {
            return repositorio.TraerDatosCalculoPresupuestoRemuneracion(idProAnu, idEstPreRem);
        }

        public List<CalculoPresupuestoRemuneracion> TraerResultadoCalculoPresupuestoRemuneracion(int idProAnu, int idEstPreRem)
        {
            return repositorio.TraerResultadoCalculoPresupuestoRemuneracion(idProAnu, idEstPreRem);
        }

        public List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(int idProAnu)
        {
            return repositorio.PresupuestoRemuneracionExporta(idProAnu);
        }

        public List<PresupuestoRemuneracionExporta> PresupuestoRemuneracionExporta(string codigoGruPre, string codigosDir, int anio)
        {
            return repositorio.PresupuestoRemuneracionExporta(codigoGruPre, codigosDir, anio);
        }

        #endregion
    }
}
