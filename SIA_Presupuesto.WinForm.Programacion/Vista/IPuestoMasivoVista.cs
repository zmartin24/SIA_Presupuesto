using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IPuestoMasivoVista : IDialogoBaseVista
    {
        List<DatosPuestoCalculo> listaSeleccionada { get; }

        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }

        List<ProgramacionAnual> listaPresupuesto { set; }

        List<Direccion> listaDireccion { set; }

        List<Subdireccion> listaSubdireccion { set; }

        int idGruPre { get; set; }

        int idProAnu { get; set; }

        int idDireccion { get; set; }

        int idSubdireccion { get; set; }

        bool soloActivos { get; set; }

        List<DatosPuestoCalculo> listaPuestos { set; }

    }
}
