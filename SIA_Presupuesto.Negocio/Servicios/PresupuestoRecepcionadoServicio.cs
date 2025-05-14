using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PresupuestoRecepcionadoServicio : ServicioBase, IPresupuestoRecepcionadoServicio
    {
        IPresupuestoRecepcionadoRepositorio repositorio;

        public PresupuestoRecepcionadoServicio(IPresupuestoRecepcionadoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones
        public Resultado Nuevo(PresupuestoRecepcionado Presupuesto)
        {
            try
            {
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;

                List<ItemPoco> listaMeses = new List<ItemPoco>();

                listaMeses.Add(new ItemPoco() { id = 1, nombre = "Enero" });
                listaMeses.Add(new ItemPoco() { id = 2, nombre = "Febrero" });
                listaMeses.Add(new ItemPoco() { id = 3, nombre = "Marzo" });
                listaMeses.Add(new ItemPoco() { id = 4, nombre = "Abril" });
                listaMeses.Add(new ItemPoco() { id = 5, nombre = "Mayo" });
                listaMeses.Add(new ItemPoco() { id = 6, nombre = "Junio" });
                listaMeses.Add(new ItemPoco() { id = 7, nombre = "Julio" });
                listaMeses.Add(new ItemPoco() { id = 8, nombre = "Agosto" });
                listaMeses.Add(new ItemPoco() { id = 9, nombre = "Septiembre" });
                listaMeses.Add(new ItemPoco() { id = 10, nombre = "Octubre" });
                listaMeses.Add(new ItemPoco() { id = 11, nombre = "Noviembre" });
                listaMeses.Add(new ItemPoco() { id = 12, nombre = "Diciembre" });

                foreach (ItemPoco item in listaMeses)
                {
                    PresupuestoRecepcionado oRegistro = new PresupuestoRecepcionado();
                    oRegistro.idGruPre = Presupuesto.idGruPre;
                    oRegistro.anio = Presupuesto.anio;
                    oRegistro.mes = item.id;
                    oRegistro.importe = 0;
                    oRegistro.tipo = Presupuesto.tipo;
                    oRegistro.usuCrea = Presupuesto.usuCrea;
                    oRegistro.fechaCrea = Presupuesto.fechaCrea;
                    oRegistro.estado = Presupuesto.estado;
                    repositorio.Agregar(oRegistro);
                }
                
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Creacion, Presupuesto);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Creacion, Presupuesto, ex);
            }

            return resultado;
        }

        public Resultado Transferir(int idGruPre, int anio, int mes, string usuarioRegistra,DateTime fechaCrea, List<GrupoPresupuestoTransferidoPoco> listaTemp) {
            
            try
            {

                PresupuestoRecepcionadoPoco oRegistro = repositorio.ObtenerRegistroxFiltro(idGruPre, anio, mes);

                foreach (var item in listaTemp)
                {
                    IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                    repositorio.Agregar(new PresupuestoRecepcionado() {
                        idGruPre = item.idGruPre,
                        anio = item.anio,
                        mes = item.mes,
                        importe = item.importe,
                        tipo = "TR",
                        usuCrea = usuarioRegistra,
                        fechaCrea = fechaCrea,
                        estado = 2,
                        idPreRecOrigen = oRegistro.idPreRec
                    });
                    unidadTrabajo.GuardarCambios();
                }
                
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, new GrupoPresupuestoTransferidoPoco());
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, new GrupoPresupuestoTransferidoPoco(), ex);
            }

            return resultado;
        }

        public Resultado Modificar(PresupuestoRecepcionado Presupuesto)
        {
            PresupuestoRecepcionado oRegistro = BuscarPorCodigo(Presupuesto.idPreRec);
            try
            {
              
                oRegistro.importe = Presupuesto.importe;
                oRegistro.usuMod = Presupuesto.usuMod;
                oRegistro.fechaMod = Presupuesto.fechaMod;

                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                repositorio.Actualizar(oRegistro);
                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Modificacion, oRegistro);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Modificacion, oRegistro, ex);
            }

            return resultado;
        }

        public Resultado Eliminar(int id,int anio)
        {
            List<PresupuestoRecepcionadoPoco> oRegistro = repositorio.BuscarxIdAnio(id, anio);

            try
            {
              
                IUnidadTrabajo unidadTrabajo = repositorio.UnidadTrabajo as IUnidadTrabajo;
                foreach (PresupuestoRecepcionadoPoco item in oRegistro)
                {
                    PresupuestoRecepcionado oPresupuesto = BuscarPorCodigo(item.idPreRec);
                    oPresupuesto.estado = 1;
                    repositorio.Actualizar(oPresupuesto);
                }

                unidadTrabajo.GuardarCambios();
                resultado = MensajeSatisfactorio(TipoMensaje.Eliminacion, oRegistro);
            }
            catch (Exception ex)
            {
                resultado = MensajeError(repositorio, TipoMensaje.Eliminacion, oRegistro, ex);
            }

            return resultado;
        }

        #endregion

        #region Busquedas y listados

        public PresupuestoRecepcionado BuscarPorCodigo(int idPresupuesto)
        {
            return repositorio.TraerPorID(idPresupuesto);
        }

        public List<PresupuestoRecepcionadoPoco> listarTodos(int anio, int mesInicio, int mesFin)
        {
            return repositorio.ListaGrupo(anio, mesInicio,mesFin);
        }

        public List<PresupuestoRecepcionadoPoco> listarDetalleRecepcionados(int idGrupo)
        {
            return repositorio.listarDetalleRecepcionados(idGrupo);
        }

        public PresupuestoRecepcionado BuscarPorCodigo(PresupuestoRecepcionado Presupuesto)
        {
            throw new NotImplementedException();
        }

        public PresupuestoRecepcionadoPoco ObtenerRegistroxFiltro(int idGruPre, int anio, int mes)
        {
            return repositorio.ObtenerRegistroxFiltro(idGruPre, anio, mes);
        }

        public PresupuestoRecepcionadoPoco ObtenerRegistroxGrupo(int idGrupo, int anio)
        {
            return repositorio.ObtenerRegistroxGrupo(idGrupo, anio);
        }

        #endregion
    }
}
