using System.Collections.Generic;
using System.Linq;

using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ProgramacionAnualEjeOperativoPresentador
    {
        private readonly IProgramacionAnualEjeOperativoVista programacionAnualSedeVista;
        private List<ProgramacionEjeOperativoPoco> lista;
        private int idProAnu;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IEjeOperativoServicio ejeOperativoServicio;
        public ProgramacionAnualEjeOperativoPresentador(int idProAnu, List<ProgramacionEjeOperativoPoco> lista, IProgramacionAnualEjeOperativoVista programacionAnualSedeVista)
        {
            this.lista = lista;
            this.idProAnu = idProAnu;
            this.programacionAnualSedeVista = programacionAnualSedeVista;

            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.ejeOperativoServicio = _Contenedor.Resolver(typeof(IEjeOperativoServicio)) as IEjeOperativoServicio;
        }

        public void IniciarDatos()
        {
            LlenarDatos();
        }

        public void LlenarDatos()
        {
            var listaEjeOperativos = ejeOperativoServicio.listarTodos().OrderBy(x => x.descripcion).ToList();
            if(listaEjeOperativos.Count>0)
            {
                programacionAnualSedeVista.listaEjeOperativos = listaEjeOperativos;
                programacionAnualSedeVista.idEjeOpe = listaEjeOperativos.OrderBy(x=>x.descripcion).FirstOrDefault().idEjeOpe;
            }
            
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
            // Inicializar lista si es null (patrón null-coalescing)
            lista = lista ?? new List<ProgramacionEjeOperativoPoco>();

            // Verificar si el elemento ya existe
            bool existeElemento = lista.Exists(e => e.idEjeOpe == programacionAnualSedeVista.idEjeOpe);

            if (!existeElemento)
            {
                lista.Add(new ProgramacionEjeOperativoPoco { idEjeOpe = programacionAnualSedeVista.idEjeOpe, ejeOperativo = programacionAnualSedeVista.ejeOperativo, idProAnu = idProAnu, operacion = "N", observacion = "" });
                CargarGrid();
            }

            return respuesta;
        }

        public bool Quitar()
        {
            bool respuesta = false;
            if (programacionAnualSedeVista.ProgramacionAnualEjeOperativo != null)
                if (programacionAnualSedeVista.ProgramacionAnualEjeOperativo.operacion.Equals("N"))
                    lista.Remove(programacionAnualSedeVista.ProgramacionAnualEjeOperativo);
                else
                    programacionAnualSedeVista.ProgramacionAnualEjeOperativo.operacion = "E";
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
