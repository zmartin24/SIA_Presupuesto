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
    public class PuestoPresentador
    {
        private readonly IPuestoVista puestoVista;
        private IGeneralServicio generalServicio;
        private IPuestoPresupuestoServicio puestoServicio;
        private bool esModificacion;
        private PuestoPresupuesto puesto;
        private ProgramacionAnual programacionAnual;
        public PuestoPresentador(ProgramacionAnual programacionAnual, PuestoPresupuesto puesto, IPuestoVista puestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.puestoVista = puestoVista;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.puestoServicio = _Contenedor.Resolver(typeof(IPuestoPresupuestoServicio)) as IPuestoPresupuestoServicio;
            this.programacionAnual = programacionAnual;

            this.esModificacion = puesto != null;
            this.puesto = puesto ?? new PuestoPresupuesto();
        }

        public void IniciarDatos()
        {
            puestoVista.listaCargos = generalServicio.ListaCargos();
            puestoVista.listaSedes = generalServicio.ListaSedeLaboral();
            puestoVista.listaTrabajador = generalServicio.ListaTrabajadores();
            puestoVista.listaMonedas = generalServicio.ListaMonedas();
            puestoVista.listaCategoriaLaboral = generalServicio.TraerDatosCategoriaLaboral();
            puestoVista.listaCondicionLaboral = generalServicio.TraerDatosCondicionLaboral();
            puestoVista.listaRegimelLaboral = generalServicio.TraerDatosRegimenLaboral();
            puestoVista.listaDirecciones = generalServicio.ListaDirecciones();

            puestoVista.fechaMin = new DateTime(this.programacionAnual.anio, 1, 1);
            puestoVista.fechaMax = new DateTime(this.programacionAnual.anio, 12, 31);

            puestoVista.fechaInicio = new DateTime(this.programacionAnual.anio, 1, 1);
            puestoVista.fechaTermino = new DateTime(this.programacionAnual.anio, 12, 31);

            if (this.esModificacion)
            {
                puestoVista.idCargo = puesto.idCargo;
                puestoVista.idSede = (Int32)puesto.idSede;
                puestoVista.idMoneda = (Int32)puesto.idTipMon;
                puestoVista.idRegLab = (Int32)puesto.idRegLab;
                puestoVista.idConLab = (Int32)puesto.idConLab;
                puestoVista.idCatLab = (Int32)puesto.idCatLab;
                puestoVista.fechaInicio = (DateTime)puesto.fechaInicio;
                puestoVista.fechaTermino = (DateTime)puesto.fechaTermino;

                var area = generalServicio.BuscarArea((Int32)puesto.idArea);
                if(area!= null)
                {
                    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                    if(subdireccion != null)
                    {
                        puestoVista.idDireccion = (Int32)subdireccion.idDireccion;
                        puestoVista.idSubdireccion = (Int32)subdireccion.idSubdireccion;
                        puestoVista.idArea = (Int32)puesto.idArea;
                    }
                }

                if (puesto.idTrabajador != null)
                    puestoVista.idTrabajador = (Int32)puesto.idTrabajador;


                puestoVista.remuneracion = puesto.remuneracion;
                
                puestoVista.grado = puesto.grado;
                puestoVista.esVacante = puesto.esVacante;
                puestoVista.esRemDiaria = puesto.esRemDiaria;
                puestoVista.conBonoAlimento = (bool)puesto.conBonoAlimento;
                puestoVista.conBonoAlimentoEsp = (bool)puesto.conBonoAlimentoAdi;
                puestoVista.conBonoMovilidad = (bool)puesto.conBonoMovilidad;
                puestoVista.conBonoProductividad = (bool)puesto.conBonoProductividad;
                puestoVista.conSctrSalud = (bool)puesto.conSctrSalud;
                puestoVista.conSctrPension = (bool)puesto.conSctrPension;
                puestoVista.situacionEspecial = (Int32)puesto.situacionEspecial;
                puestoVista.cantVacante = (Int32)puesto.cantVacante;
            }
        }

        public void CargarSubdirecciones()
        {
            puestoVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(puestoVista.idDireccion);
        }

        public void CargarAreas()
        {
            puestoVista.listaAreas = generalServicio.ListaAreas(puestoVista.idSubdireccion);
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            puesto.idCargo = puestoVista.idCargo;
            puesto.idSede = puestoVista.idSede;
            if (!puestoVista.esVacante)
                puesto.idTrabajador = puestoVista.idTrabajador;
            else
                puesto.idTrabajador = null;

            puesto.remuneracion = puestoVista.remuneracion;
            puesto.cantVacante = puestoVista.esVacante ? puestoVista.cantVacante : 0;
            puesto.grado = puestoVista.grado;
            puesto.esVacante = puestoVista.esVacante;
            puesto.esRemDiaria = puestoVista.esRemDiaria;
            puesto.idRegLab = puestoVista.idRegLab;
            puesto.idCatLab = puestoVista.idCatLab;
            puesto.idConLab = puestoVista.idConLab;
            puesto.conBonoAlimento = puestoVista.conBonoAlimento;
            puesto.conBonoAlimentoAdi = puestoVista.conBonoAlimentoEsp;
            puesto.conBonoMovilidad = puestoVista.conBonoMovilidad;
            puesto.conBonoProductividad = puestoVista.conBonoProductividad;
            puesto.conSctrSalud = puestoVista.conSctrSalud;
            puesto.conSctrPension = puestoVista.conSctrPension;
            puesto.situacionEspecial = puestoVista.situacionEspecial;
            puesto.idTipMon = puestoVista.idMoneda;
            puesto.idArea = puestoVista.idArea;
            puesto.fechaInicio = puestoVista.fechaInicio;
            puesto.fechaTermino = puestoVista.fechaTermino;

            if (this.esModificacion)
            {
                puesto.fechaEdita = DateTime.Now;
                puesto.usuEdita = puestoVista.UsuarioOperacion.NomUsuario;
                resultado = puestoServicio.Modificar(puesto);
            }
            else
            {
                puesto.idProAnu = programacionAnual.idProAnu;
                puesto.fechaCrea = DateTime.Now;
                puesto.usuCrea = puestoVista.UsuarioOperacion.NomUsuario;
                puesto.estado = Estados.Activo;
                resultado = puestoServicio.Nuevo(puesto);
            }

            return resultado.esCorrecto;
        }
    }
}
