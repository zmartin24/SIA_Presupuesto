using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class PresupuestoMensualPresentador
    {
        private readonly IPresupuestoMensualVista subPresupuestoVista;
        private SubPresupuestoPoco subPresupuesto;
        private bool esModificacion;
        private ISubpresupuestoServicio subPresupuestoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;

        public PresupuestoMensualPresentador(SubPresupuestoPoco subPresupuesto, IPresupuestoMensualVista presupuestoMensualVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.subPresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.esModificacion = subPresupuesto != null;
            this.subPresupuestoVista = presupuestoMensualVista;
            this.subPresupuesto = subPresupuesto ?? new SubPresupuestoPoco();
        }

        public void IniciarDatos()
        {
            LlenarCombos();

            if (this.esModificacion)
            {
                Subpresupuesto objRegistroSubPresupuesto = subPresupuestoServicio.BuscarPorCodigo(subPresupuesto.idSubPresupuesto);

                ProgramacionAnual objProgramacionAnual = programacionAnualServicio.BuscarPorCodigo(objRegistroSubPresupuesto.idProAnu);
                subPresupuestoVista.idGruPre = objProgramacionAnual.idGruPre.GetValueOrDefault();
                subPresupuestoVista.idSubPresupuesto = objRegistroSubPresupuesto.idSubpresupuesto;
                subPresupuestoVista.idProAnual = objRegistroSubPresupuesto.idProAnu;
                subPresupuestoVista.descripcion = objRegistroSubPresupuesto.descripcion;
                subPresupuestoVista.abreviatura = objRegistroSubPresupuesto.abreviatura;
                subPresupuestoVista.nroProyecto = objRegistroSubPresupuesto.nroProyecto;
                subPresupuestoVista.esObra = objRegistroSubPresupuesto.esObra.GetValueOrDefault();
                subPresupuestoVista.esEncargo = objRegistroSubPresupuesto.esEncargo.GetValueOrDefault();
                subPresupuestoVista.esErradicacion = objRegistroSubPresupuesto.esErradicacion.GetValueOrDefault();
                subPresupuestoVista.esActividadCampo = objRegistroSubPresupuesto.esActividadCampo.GetValueOrDefault();
                subPresupuestoVista.anio = objRegistroSubPresupuesto.anio.GetValueOrDefault();
                subPresupuestoVista.mes = objRegistroSubPresupuesto.mes.GetValueOrDefault();
                subPresupuestoVista.estado = objRegistroSubPresupuesto.estado;
                subPresupuestoVista.importe = objRegistroSubPresupuesto.importe == null ? 0 : (decimal)objRegistroSubPresupuesto.importe;
            }
        }
        public bool ValidarRegistroExistente()
        {
            Subpresupuesto reg = null;
            if (!this.esModificacion || (this.esModificacion && (!this.subPresupuesto.idPresupuesto.Equals(subPresupuestoVista.idProAnual) || !this.subPresupuesto.desSubPresupuesto.Equals(subPresupuestoVista.descripcion))))
                reg = subPresupuestoServicio.BuscarPorDescripcion(subPresupuestoVista.idProAnual, subPresupuestoVista.descripcion);

            return reg == null;
        }

        public void LlenarComboPresupuesto(int idGrupo)
        {
            GrupoPresupuesto grupoPresupuesto = grupoPresupuestoServicio.BuscarPorCodigo(idGrupo);
            this.subPresupuestoVista.esEncargo = grupoPresupuesto.esEncargo;
            subPresupuestoVista.ListaProgramacion = programacionAnualServicio.TraerListaxGrupo(idGrupo);
        }

        public void SeleccionarAnio(int idProAnu)
        {
            ProgramacionAnual programacionAnual = programacionAnualServicio.BuscarPorCodigo(idProAnu);
            this.subPresupuestoVista.anio = programacionAnual.anio;
        }

        private void LlenarCombos()
        {
            subPresupuestoVista.ListaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();

            int ultimoAnio = DateTime.Now.Month == 12 ? DateTime.Now.Year + 1 : DateTime.Now.Year;

            List<ItemPoco> listaAnios = new List<ItemPoco>();

            for (int i = 2004; i <= ultimoAnio; i++)
            {
                listaAnios.Add(new ItemPoco() { id = i, nombre = i.ToString()});
            }

            List<ItemPoco> listaMeses = new List<ItemPoco>();

            listaMeses.Add(new ItemPoco() { id = 0, nombre = "Seleccione" });
            listaMeses.Add(new ItemPoco() { id = 1, nombre = "Enero"});
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

            subPresupuestoVista.ListaAnios = listaAnios.OrderByDescending(t => t.id).ToList();
            subPresupuestoVista.ListaMes = listaMeses;

            List<ItemPoco> listaEstados = new List<ItemPoco>();
            listaEstados.Add(new ItemPoco() { id= 2, nombre = "Pendiente"});
            listaEstados.Add(new ItemPoco() { id = 10, nombre = "Aprobado" });
            listaEstados.Add(new ItemPoco() { id = 60, nombre = "Liquidado" });

            subPresupuestoVista.ListaEstados = listaEstados;
            
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            Subpresupuesto oSubPrespuesto = new Subpresupuesto();

            oSubPrespuesto.idSubpresupuesto = subPresupuestoVista.idSubPresupuesto;
            oSubPrespuesto.idProAnu = subPresupuestoVista.idProAnual;
            oSubPrespuesto.descripcion = subPresupuestoVista.descripcion.Trim().ToUpper();
            oSubPrespuesto.abreviatura = subPresupuestoVista.abreviatura.Trim().ToUpper();
            oSubPrespuesto.nroProyecto = subPresupuestoVista.nroProyecto.Trim();
            oSubPrespuesto.esObra = subPresupuestoVista.esObra;
            oSubPrespuesto.esEncargo = subPresupuestoVista.esEncargo;
            oSubPrespuesto.esActividadCampo = subPresupuestoVista.esActividadCampo;
            oSubPrespuesto.esErradicacion = subPresupuestoVista.esErradicacion;
            oSubPrespuesto.anio = subPresupuestoVista.anio;
            oSubPrespuesto.mes = subPresupuestoVista.mes;
            oSubPrespuesto.importe = subPresupuestoVista.importe;


            List<Subpresupuesto> oList = new List<Subpresupuesto>();

            string testing = "";

            foreach (Subpresupuesto item in oList)
            {
                testing += "Id : " + item.idProAnu + ", Nombre :" + item.nroProyecto;
            }

            if (this.esModificacion)
            {
                oSubPrespuesto.fechaEdita = DateTime.Now;
                oSubPrespuesto.usuEdita = subPresupuestoVista.UsuarioOperacion.NomUsuario;
                resultado = subPresupuestoServicio.Modificar(oSubPrespuesto);
            }
            else
            {
                oSubPrespuesto.esLiquidado = false;
                oSubPrespuesto.estado = Estados.Activo;
                oSubPrespuesto.fechaCrea = DateTime.Now;
                oSubPrespuesto.usuCrea = subPresupuestoVista.UsuarioOperacion.NomUsuario;
                resultado = subPresupuestoServicio.Nuevo(oSubPrespuesto);
            }

            return resultado.esCorrecto;
        }
    }
}
