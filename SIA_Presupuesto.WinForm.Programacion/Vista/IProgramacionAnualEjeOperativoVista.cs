using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IProgramacionAnualEjeOperativoVista
    {
        List<ProgramacionEjeOperativoPoco> listaDatosPrincipales { set; }

        List<EjeOperativo> listaEjeOperativos { set; }

        ProgramacionEjeOperativoPoco ProgramacionAnualEjeOperativo { get; }

        int idEjeOpe { set; get; }

        string ejeOperativo { set; get; }
    }
}
