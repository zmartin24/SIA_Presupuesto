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
    public class ProgramacionAnualSedePresentador
    {
        private readonly IProgramacionAnualSedeVista programacionAnualSedeVista;
        private List<ProgramacionSedeLaboralPoco> lista;
        private int idProAnu;
        private IGeneralServicio generalServicio;
        public ProgramacionAnualSedePresentador(int idProAnu, List<ProgramacionSedeLaboralPoco> lista, IProgramacionAnualSedeVista programacionAnualSedeVista)
        {
            this.lista = lista;
            this.idProAnu = idProAnu;
            this.programacionAnualSedeVista = programacionAnualSedeVista;

            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
        }

        public void IniciarDatos()
        {
            LlenarDatos();
        }

        public void LlenarDatos()
        {
            programacionAnualSedeVista.listaSedesLaborales = generalServicio.ListaSedeLaboral();
            CargarGrid();
        }

        private void CargarGrid()
        {
            if (this.lista != null)
                programacionAnualSedeVista.listaDatosPrincipales = this.lista.Where(W => !W.operacion.Equals("E")).ToList();
        }

        public bool Agregar()
        {
            bool respuesta = false;
            if (lista == null)
                lista = new List<ProgramacionSedeLaboralPoco>();
            if (!lista.Exists(e => e.idSede == programacionAnualSedeVista.idSede))
            {
                lista.Add(new ProgramacionSedeLaboralPoco { idSede = programacionAnualSedeVista.idSede, desSede = programacionAnualSedeVista.desSede, idProAnu = idProAnu, operacion = "N", observacion = "" });
                CargarGrid();
            }

            return respuesta;
        }

        public bool Quitar()
        {
            bool respuesta = false;
            if (programacionAnualSedeVista.ProgramacionAnualSede != null)
                if (programacionAnualSedeVista.ProgramacionAnualSede.operacion.Equals("N"))
                    lista.Remove(programacionAnualSedeVista.ProgramacionAnualSede);
                else
                    programacionAnualSedeVista.ProgramacionAnualSede.operacion = "E";
            CargarGrid();
            return respuesta;
        }

        public bool GuardarDatos()
        {
            bool respuesta = false;

            return respuesta;
        }

    }
}
