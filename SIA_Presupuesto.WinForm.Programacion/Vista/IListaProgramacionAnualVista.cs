using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaProgramacionAnualVista : IControlBaseVista
    {
        List<ProgramacionAnualPres> listaDatosPrincipales { set; }

        ProgramacionAnual ProgramacionAnual { get; }

        List<Anio> listaAnios { set; }

        int anioPresentacion { get; set; }
        int idMoneda { get; set; }
    }
}
