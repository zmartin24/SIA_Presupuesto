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
    public class PuestoReajusteMasivoPresentador
    {
        private readonly IPuestoReajusteMasivoVista puestoMasivoVista;
        private IPuestoReajustePresupuestoServicio puestoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IProgramacionAnualServicio reajusteMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IPresupuestoRemuneracionServicio presRemServicio;
        private IReajustePresupuestoRemuneracionServicio reaPresRemServicio;

        private ReajusteMensualProgramacion reajusteMensualProgramacion;
        public PuestoReajusteMasivoPresentador(ReajusteMensualProgramacion reajusteMensualProgramacion, IPuestoReajusteMasivoVista puestoMasivoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.reajusteMensualProgramacion = reajusteMensualProgramacion;
            this.puestoMasivoVista = puestoMasivoVista;
            this.puestoServicio = _Contenedor.Resolver(typeof(IPuestoReajustePresupuestoServicio)) as IPuestoReajustePresupuestoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.presRemServicio = _Contenedor.Resolver(typeof(IPresupuestoRemuneracionServicio)) as IPresupuestoRemuneracionServicio;
            this.reaPresRemServicio = _Contenedor.Resolver(typeof(IReajustePresupuestoRemuneracionServicio)) as IReajustePresupuestoRemuneracionServicio;
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
            //puestoMasivoVista.idGruPre = (Int32)reajusteMensualProgramacion.idGruPre;
        }

        public void CargarDatosGenerales()
        {
            puestoMasivoVista.listaPuestos = reaPresRemServicio.TraerDatosPuestoCalculoReajuste(puestoMasivoVista.idGruPre, puestoMasivoVista.idProAnu, 
                puestoMasivoVista.idDireccion, puestoMasivoVista.idSubdireccion, puestoMasivoVista.soloActivos ? "AC" : "", reajusteMensualProgramacion.idReaMenPro);
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
            listaProgramacion.AddRange(reajusteMensualProgramacionServicio.listarTodosPorGrupoPresupuesto(puestoMasivoVista.idGruPre));
            puestoMasivoVista.listaPresupuesto = listaProgramacion;
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            List<PuestoReajustePresupuesto> lista = new List<PuestoReajustePresupuesto>();
            DateTime vfechaInicio = new DateTime(this.reajusteMensualProgramacion.ProgramacionAnual.anio, reajusteMensualProgramacion.mesReajuste, 1);
            DateTime vfechaTermino = new DateTime(this.reajusteMensualProgramacion.ProgramacionAnual.anio, 12, 31);
            var vlista = puestoMasivoVista.listaSeleccionada.GroupBy(x => x.idTrabajador).Select(y => y.First()).ToList();
            foreach (var det in vlista)
            {
                lista.Add(new PuestoReajustePresupuesto
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
                    idReaMenPro = reajusteMensualProgramacion.idReaMenPro,
                    fechaInicio = vfechaInicio,
                    fechaTermino = vfechaTermino,
                    fechaCrea = DateTime.Now,
                    usuCrea = puestoMasivoVista.UsuarioOperacion.NomUsuario,
                    idArea = det.idAreLab
                });
            }

            resultado = puestoServicio.Nuevo(lista);
            
            return resultado.esCorrecto;
        }


    }
}
