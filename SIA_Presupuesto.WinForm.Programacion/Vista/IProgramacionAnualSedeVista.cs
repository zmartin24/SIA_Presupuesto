using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IProgramacionAnualSedeVista
    {
        List<ProgramacionSedeLaboralPoco> listaDatosPrincipales { set; }

        List<SedeLaboral> listaSedesLaborales { set; }

        ProgramacionSedeLaboralPoco ProgramacionAnualSede { get; }

        int idSede { set; get; }

        string desSede { set; get; }
    }
}
