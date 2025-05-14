using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class TransferenciaPresentador
    {
        private readonly IListaTransferenciaVista transferenciaVista;
        private readonly ITransferenciaVista transferenciaRegistroVista;
        private PresupuestoRecepcionadoPoco presupuestoRecepcionado;
        private bool esModificacion;
        private List<GrupoPresupuestoTransferidoPoco> Lista;
        private List<GrupoPresupuestoTransferidoPoco> listaPresupuestoRecepcionado;
        private IPresupuestoRecepcionadoServicio presupuestoRecepcionadoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        IContenedor _Contenedor = new cContenedor();

        public TransferenciaPresentador(PresupuestoRecepcionadoPoco presupuestoRecepcionado, IListaTransferenciaVista transferenciaVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.presupuestoRecepcionadoServicio = _Contenedor.Resolver(typeof(IPresupuestoRecepcionadoServicio)) as IPresupuestoRecepcionadoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.esModificacion = presupuestoRecepcionado != null;
            this.transferenciaVista = transferenciaVista;
            listaPresupuestoRecepcionado = new List<GrupoPresupuestoTransferidoPoco>();
            this.presupuestoRecepcionado = presupuestoRecepcionado ?? new PresupuestoRecepcionadoPoco();
        }

        public TransferenciaPresentador(PresupuestoRecepcionadoPoco presupuestoRecepcionado, ITransferenciaVista transferenciaRegistroVista, List<GrupoPresupuestoTransferidoPoco> Lista)
        {
            this.presupuestoRecepcionadoServicio = _Contenedor.Resolver(typeof(IPresupuestoRecepcionadoServicio)) as IPresupuestoRecepcionadoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.esModificacion = presupuestoRecepcionado != null;
            this.transferenciaRegistroVista = transferenciaRegistroVista;
            this.Lista = Lista;
            listaPresupuestoRecepcionado = new List<GrupoPresupuestoTransferidoPoco>();
            this.presupuestoRecepcionado = presupuestoRecepcionado ?? new PresupuestoRecepcionadoPoco();
        }

        public void IniciarDatos()
        {
            LlenarCombos();

            if (this.esModificacion)
            {
                //resupuestoRecepcionadoVista.nombreMes = presupuestoRecepcionado.nombreMes;
                //resupuestoRecepcionadoVista.importe = presupuestoRecepcionado.importe;
                //resupuestoRecepcionadoVista.anio = presupuestoRecepcionado.anio;
                //resupuestoRecepcionadoVista.idPreRec = presupuestoRecepcionado.idPreRec;
            }
        }

        public void IniciarDatosRegistro()
        {
            LlenarCombosRegistro();

            if (this.esModificacion)
            {
                //resupuestoRecepcionadoVista.nombreMes = presupuestoRecepcionado.nombreMes;
                //resupuestoRecepcionadoVista.importe = presupuestoRecepcionado.importe;
                //resupuestoRecepcionadoVista.anio = presupuestoRecepcionado.anio;
                //resupuestoRecepcionadoVista.idPreRec = presupuestoRecepcionado.idPreRec;
            }
        }

        private void LlenarCombosRegistro()
        {

            transferenciaRegistroVista.listaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();

            transferenciaRegistroVista.idGrupoPresupuesto = this.presupuestoRecepcionado.idGruPre;

            int ultimoAnio = DateTime.Now.Year;
            List<ItemPoco> listaAnios = new List<ItemPoco>();

            for (int i = 2004; i <= ultimoAnio; i++)
            {
                listaAnios.Add(new ItemPoco() { id = i, nombre = i.ToString() });
            }

            List<ItemPoco> listaMeses = new List<ItemPoco>();

            listaMeses.Add(new ItemPoco() { id = 0, nombre = "Seleccione" });
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

            transferenciaRegistroVista.listaAnios = listaAnios.OrderByDescending(t => t.id).ToList();
            transferenciaRegistroVista.listaMeses = listaMeses;

        }
        public List<GrupoPresupuestoTransferidoPoco> ListaPresupuestoRecepcionado
        {
            get { return listaPresupuestoRecepcionado; }
        }

        private void LlenarCombos()
        {
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            transferenciaVista.listaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();

            transferenciaVista.idGrupoPresupuesto = this.presupuestoRecepcionado.idGruPre;

            int ultimoAnio = DateTime.Now.Year;
            List<ItemPoco> listaAnios = new List<ItemPoco>();

            for (int i = 2004; i <= ultimoAnio; i++)
            {
                listaAnios.Add(new ItemPoco() { id = i, nombre = i.ToString() });
            }

            List<ItemPoco> listaMeses = new List<ItemPoco>();

            listaMeses.Add(new ItemPoco() { id = 0, nombre = "Seleccione" });
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

            transferenciaVista.listaAnios = listaAnios.OrderByDescending(t => t.id).ToList();
            transferenciaVista.listaMeses = listaMeses;

        }

        public void CargarDatosGruposPresupuestoRecepcionado()
        {
            if (listaPresupuestoRecepcionado != null)
            {
                var listaTemp = listaPresupuestoRecepcionado.FindAll(f => !f.operacion.Equals("E"));
                transferenciaVista.listaGrupoPresupuestoTransferido = listaTemp;

                decimal importetransferido = 0;
                foreach (var item in listaTemp)
                {
                    importetransferido += item.importe;
                }
                transferenciaVista.importetransferido = importetransferido;
                transferenciaVista.importerestante = transferenciaVista.importe - transferenciaVista.importetransferido;
            }
        }

        public void LimpiarGrilla()
        {
            var listaTemp = listaPresupuestoRecepcionado.FindAll(f => !f.operacion.Equals("E"));

            foreach (var item in listaTemp)
            {
                item.operacion = "E";
            }

            listaTemp = listaPresupuestoRecepcionado.FindAll(f => !f.operacion.Equals("E"));
            transferenciaVista.listaGrupoPresupuestoTransferido = listaTemp;
            transferenciaVista.importetransferido = 0;
            transferenciaVista.importerestante = transferenciaVista.importe;
        }

        public bool TieneListaGrupo()
        {
            if (listaPresupuestoRecepcionado != null)
            {
                var listaTemp = listaPresupuestoRecepcionado.FindAll(f => !f.operacion.Equals("E"));
                return (listaTemp.Count > 0) ? true : false ;
            }
            else
            {
                return false;
            }
        }

        public void AsignarImporteRecepcionado(int idgrupre, int anio, int mes)
        {
            PresupuestoRecepcionadoPoco oRegistro = presupuestoRecepcionadoServicio.ObtenerRegistroxFiltro(idgrupre, anio, mes);
            if(oRegistro != null)
            {
                this.transferenciaVista.importe = oRegistro.importe;
                this.transferenciaVista.importetransferido = 0;
                this.transferenciaVista.importerestante = oRegistro.importe;
            }
            else
            {
                this.transferenciaVista.importe = 0;
                this.transferenciaVista.importerestante = 0;
                this.transferenciaVista.importetransferido = 0;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            this.Lista.Add(new GrupoPresupuestoTransferidoPoco() {
                 importe = this.transferenciaRegistroVista.importe,
                 idGruPre = this.transferenciaRegistroVista.idGrupoPresupuesto,
                 nombreGruPre =  this.transferenciaRegistroVista.nombreGrupo,
                 mes = this.transferenciaRegistroVista.mes,
                 nombreMes = this.transferenciaRegistroVista.nombreMes,
                 anio = this.transferenciaRegistroVista.anio,
                 operacion = "N"
            });

            return true;
        }

        public bool GuardarDatosTransferencia()
        {
            Resultado resultado = null;

            List<GrupoPresupuestoTransferidoPoco> listaTemp = listaPresupuestoRecepcionado.FindAll(f => !f.operacion.Equals("E"));

            int idGrupo = transferenciaVista.idGrupoPresupuesto;
            int anio = transferenciaVista.anio;
            int mes = transferenciaVista.mes;
            decimal importe = -1*transferenciaVista.importetransferido;
            string tipo = "TR";
            string usuarioRegistra = transferenciaVista.UsuarioOperacion.NomUsuario;
            DateTime fechaCrea = DateTime.Now;
          
            listaTemp.Add(new GrupoPresupuestoTransferidoPoco() {
                idPreRec = 0,
                idGruPre = idGrupo,
                anio = anio,
                mes = mes,
                importe = importe,
                tipo = tipo
            });

            resultado = presupuestoRecepcionadoServicio.Transferir(idGrupo,anio,mes, usuarioRegistra,fechaCrea,listaTemp);
           
            return resultado.esCorrecto;
        }
    }
}
