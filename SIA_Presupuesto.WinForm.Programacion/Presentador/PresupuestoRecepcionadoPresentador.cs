using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class PresupuestoRecepcionadoPresentador
    {
        private readonly IPresupuestoRecepcionadoVista resupuestoRecepcionadoVista;
        private PresupuestoRecepcionadoPoco presupuestoRecepcionado;
        private bool esModificacion;
        private IPresupuestoRecepcionadoServicio presupuestoRecepcionadoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
       
        public PresupuestoRecepcionadoPresentador(PresupuestoRecepcionadoPoco presupuestoRecepcionado, IPresupuestoRecepcionadoVista presupuestorecepcionadoVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.presupuestoRecepcionadoServicio = _Contenedor.Resolver(typeof(IPresupuestoRecepcionadoServicio)) as IPresupuestoRecepcionadoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.esModificacion = presupuestoRecepcionado != null;
            this.resupuestoRecepcionadoVista = presupuestorecepcionadoVista;
            this.presupuestoRecepcionado = presupuestoRecepcionado ?? new PresupuestoRecepcionadoPoco();
        }

        public void IniciarDatos()
        {
            LlenarCombos();

            if (this.esModificacion)
            {
                //Subpresupuesto objRegistroSubPresupuesto = subPresupuestoServicio.BuscarPorCodigo(subPresupuesto.idSubPresupuesto);

                //ProgramacionAnual objProgramacionAnual = programacionAnualServicio.BuscarPorCodigo(objRegistroSubPresupuesto.idProAnu);
                //subPresupuestoVista.idGruPre = objProgramacionAnual.idGruPre.GetValueOrDefault();
                //subPresupuestoVista.idSubPresupuesto = objRegistroSubPresupuesto.idSubpresupuesto;
                //subPresupuestoVista.idProAnual = objRegistroSubPresupuesto.idProAnu;
                //subPresupuestoVista.descripcion = objRegistroSubPresupuesto.descripcion;
                //subPresupuestoVista.abreviatura = objRegistroSubPresupuesto.abreviatura;
                //subPresupuestoVista.nroProyecto = objRegistroSubPresupuesto.nroProyecto;
                //subPresupuestoVista.esObra = objRegistroSubPresupuesto.esObra.GetValueOrDefault();
                //subPresupuestoVista.esEncargo = objRegistroSubPresupuesto.esEncargo.GetValueOrDefault();
                //subPresupuestoVista.esErradicacion = objRegistroSubPresupuesto.esErradicacion.GetValueOrDefault();
                //subPresupuestoVista.esActividadCampo = objRegistroSubPresupuesto.esActividadCampo.GetValueOrDefault();
                //subPresupuestoVista.mes = objRegistroSubPresupuesto.mes.GetValueOrDefault();
                //subPresupuestoVista.estado = objRegistroSubPresupuesto.estado;

                resupuestoRecepcionadoVista.nombreMes = presupuestoRecepcionado.nombreMes;
                resupuestoRecepcionadoVista.importe = presupuestoRecepcionado.importe;
                resupuestoRecepcionadoVista.anio = presupuestoRecepcionado.anio;
                resupuestoRecepcionadoVista.idPreRec = presupuestoRecepcionado.idPreRec;
                
            }
        }

        public void AsignarFuenteFinanciamiento()
        {
            resupuestoRecepcionadoVista.fuenteFinanciamiento = grupoPresupuestoServicio.ObtenerxId(resupuestoRecepcionadoVista.idGrupoPresupuesto).nombreFuente;
        }

        private void LlenarCombos()
        {
            resupuestoRecepcionadoVista.listaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();

            int ultimoAnio = DateTime.Now.Year;

            //List<ItemPoco> listaMeses = new List<ItemPoco>();

            //listaMeses.Add(new ItemPoco() { id = 0, nombre = "Seleccione" });
            //listaMeses.Add(new ItemPoco() { id = 1, nombre = "Enero" });
            //listaMeses.Add(new ItemPoco() { id = 2, nombre = "Febrero" });
            //listaMeses.Add(new ItemPoco() { id = 3, nombre = "Marzo" });
            //listaMeses.Add(new ItemPoco() { id = 4, nombre = "Abril" });
            //listaMeses.Add(new ItemPoco() { id = 5, nombre = "Mayo" });
            //listaMeses.Add(new ItemPoco() { id = 6, nombre = "Junio" });
            //listaMeses.Add(new ItemPoco() { id = 7, nombre = "Julio" });
            //listaMeses.Add(new ItemPoco() { id = 8, nombre = "Agosto" });
            //listaMeses.Add(new ItemPoco() { id = 9, nombre = "Septiembre" });
            //listaMeses.Add(new ItemPoco() { id = 10, nombre = "Octubre" });
            //listaMeses.Add(new ItemPoco() { id = 11, nombre = "Noviembre" });
            //listaMeses.Add(new ItemPoco() { id = 12, nombre = "Diciembre" });

            //resupuestoRecepcionadoVista.listaMeses = listaMeses;
        }

        public PresupuestoRecepcionadoPoco ObtenerGrupoxRegistro(int idGruPre, int anio)
        {
            return presupuestoRecepcionadoServicio.ObtenerRegistroxGrupo(idGruPre, anio);
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            PresupuestoRecepcionado oSubPrespuesto = new PresupuestoRecepcionado();
            oSubPrespuesto.idPreRec = resupuestoRecepcionadoVista.idPreRec;
            oSubPrespuesto.idGruPre = resupuestoRecepcionadoVista.idGrupoPresupuesto;
            oSubPrespuesto.anio = resupuestoRecepcionadoVista.anio;
            oSubPrespuesto.mes = 0;
            oSubPrespuesto.importe = resupuestoRecepcionadoVista.importe;
            oSubPrespuesto.tipo = "RE";
            oSubPrespuesto.estado = Estados.Activo;

            //oSubPrespuesto.idSubpresupuesto = subPresupuestoVista.idSubPresupuesto;
            //oSubPrespuesto.idProAnu = subPresupuestoVista.idProAnual;
            //oSubPrespuesto.descripcion = subPresupuestoVista.descripcion;
            //oSubPrespuesto.abreviatura = subPresupuestoVista.abreviatura;
            //oSubPrespuesto.nroProyecto = subPresupuestoVista.nroProyecto;
            //oSubPrespuesto.esObra = subPresupuestoVista.esObra;
            //oSubPrespuesto.esEncargo = subPresupuestoVista.esEncargo;
            //oSubPrespuesto.esActividadCampo = subPresupuestoVista.esActividadCampo;
            //oSubPrespuesto.esErradicacion = subPresupuestoVista.esErradicacion;
            //oSubPrespuesto.mes = subPresupuestoVista.mes;
            //oSubPrespuesto.estado = subPresupuestoVista.estado;

            List<Subpresupuesto> oList = new List<Subpresupuesto>();

            //string testing = "";

            //foreach (Subpresupuesto item in oList)
            //{
            //    testing += "Id : " + item.idProAnu + ", Nombre :" + item.nroProyecto;
            //}

            if (this.esModificacion)
            {
                oSubPrespuesto.fechaMod = DateTime.Now;
                oSubPrespuesto.usuMod = resupuestoRecepcionadoVista.UsuarioOperacion.NomUsuario;
                resultado = presupuestoRecepcionadoServicio.Modificar(oSubPrespuesto);
            }
            else
            {
                oSubPrespuesto.fechaCrea = DateTime.Now;
                oSubPrespuesto.usuCrea = resupuestoRecepcionadoVista.UsuarioOperacion.NomUsuario;
                resultado = presupuestoRecepcionadoServicio.Nuevo(oSubPrespuesto);
            }

            return resultado.esCorrecto;
        }
    }
}
