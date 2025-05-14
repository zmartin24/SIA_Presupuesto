using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IProgramacionAnualVista : IControlDetalleBaseVista
    {
        List<ProgramacionAnualAreaPres> listaDatosPrincipales { set; }

        ProgramacionAnualArea ProgramacionAnualArea { get; }

        ProgramacionAnualDetalle ProgramacionAnualDetalle { get; }
    }
}
