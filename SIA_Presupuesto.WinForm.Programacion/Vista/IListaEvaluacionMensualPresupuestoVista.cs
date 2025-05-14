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
    public interface IListaEvaluacionMensualPresupuestoVista : IControlBaseVista
    {
        List<EvaluacionMensualPresupuestoPres> listaDatosPrincipales { set; }

        EvaluacionMensualProgramacion EvaluacionMensualProgramacion { get; }

        List<Anio> listaAnios { set; }

        List<Mes> listaMeses { set; }

        int anioPresentacion { set; get; }

        int mesPresentacion { set; get; }
        int idMoneda { set; get; }
    }
}
