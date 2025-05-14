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
    public class PuestoMasivoPresentador
    {
        private readonly IPuestoMasivoVista puestoMasivoVista;
        private IPuestoPresupuestoServicio puestoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;
        private IPresupuestoRemuneracionServicio presRemServicio;

        private ProgramacionAnual programacionAnual;
        public PuestoMasivoPresentador(ProgramacionAnual programacionAnual, IPuestoMasivoVista puestoMasivoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnual = programacionAnual;
            this.puestoMasivoVista = puestoMasivoVista;
            this.puestoServicio = _Contenedor.Resolver(typeof(IPuestoPresupuestoServicio)) as IPuestoPresupuestoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.presRemServicio = _Contenedor.Resolver(typeof(IPresupuestoRemuneracionServicio)) as IPresupuestoRemuneracionServicio;
        }

        public void IniciarDatos()
        {
            var lista = new List<Direccion>();
            lista.Add(new Direccion { idDireccion = 0, desDireccion = "NINGUNO" });
            lista.AddRange(generalServicio.ListaDirecciones());
            puestoMasivoVista.listaDireccion = lista;

            var listaGruPre = new List<GrupoPresupuesto>();
            listaGruPre.Add(new GrupoPresupuesto { idGruPre = 0, descripcion = "NINGUNO" });
            listaGruPre.AddRange(grupoPresupuestoServicio.TraerListaGrupoPresupuesto());
            puestoMasivoVista.listaGrupoPresupuesto = listaGruPre;
            puestoMasivoVista.idGruPre = (Int32)programacionAnual.idGruPre;
        }

        public void CargarDatosGenerales()
        {
            puestoMasivoVista.listaPuestos = presRemServicio.TraerDatosPuestoCalculo(puestoMasivoVista.idGruPre, puestoMasivoVista.idProAnu, 
                puestoMasivoVista.idDireccion, puestoMasivoVista.idSubdireccion, puestoMasivoVista.soloActivos ? "AC" : "", programacionAnual.idProAnu);
        }

        public void CargarDatosSubdireccion()
        {
            var listaSubdireccion = new List<Subdireccion>();
            listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, idDireccion=0, desSubdireccion = "NINGUNO" });
            listaSubdireccion.AddRange(generalServicio.ListaSubDirecciones(puestoMasivoVista.idDireccion));
            puestoMasivoVista.listaSubdireccion = listaSubdireccion;
        }

        public void CargarDatosPresupuesto()
        {
            var listaProgramacion = new List<ProgramacionAnual>();
            listaProgramacion.Add(new ProgramacionAnual { idProAnu = 0, idGruPre = 0, descripcion = "NINGUNO" });
            listaProgramacion.AddRange(programacionAnualServicio.listarTodosPorGrupoPresupuesto(puestoMasivoVista.idGruPre));
            puestoMasivoVista.listaPresupuesto = listaProgramacion;
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            List<PuestoPresupuesto> lista = new List<PuestoPresupuesto>();
            DateTime vfechaInicio = new DateTime(this.programacionAnual.anio, 1, 1);
            DateTime vfechaTermino = new DateTime(this.programacionAnual.anio, 12, 31);
            var vlista = puestoMasivoVista.listaSeleccionada.GroupBy(x => x.idTrabajador).Select(y => y.First()).ToList();
            
            foreach (var det in vlista)
            {
                lista.Add(new PuestoPresupuesto
                {
                    idCargo = det.idCargo,
                    idSede = det.idSede,
                    esVacante = false,
                    idTrabajador = det.idTrabajador,
                    remuneracion = det.remuneracion,
                    cantVacante = 0,
                    esRemDiaria = (bool)det.esRemDiaria,
                    grado = det.grado,
                    idTipMon = det.idTipMon,
                    idRegLab = det.idRegLab,
                    idCatLab = det.idCatLab,
                    idConLab = det.idConLab,
                    conBonoAlimento = det.conBonoAlimento,
                    conBonoAlimentoAdi = det.conBonoAlimentoAdi,
                    conBonoMovilidad = det.conBonoMovilidad,
                    conBonoProductividad = det.conBonoProductividad,
                    estado = Estados.Activo,
                    idProAnu = programacionAnual.idProAnu,
                    fechaCrea = DateTime.Now,
                    fechaInicio = vfechaInicio,
                    fechaTermino = vfechaTermino,
                    usuCrea = puestoMasivoVista.UsuarioOperacion.NomUsuario,
                    idArea = det.idAreLab
                });
            }

            resultado = puestoServicio.Nuevo(lista);
            
            return resultado.esCorrecto;
        }


    }
}
