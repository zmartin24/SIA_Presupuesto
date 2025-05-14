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
    public interface IListaReajusteMensualPresupuestoVista : IControlBaseVista
    {
        List<ReajusteMensualPresupuestoPres> listaDatosPrincipales { set; }
        List<ReporteReajusteMensualExportaPres> listaReporteReajusteMensualExportaPres { set; get; }

        ReajusteMensualProgramacion ReajusteMensualProgramacion { get; }

        List<Anio> listaAnios { set; }

        List<Mes> listaMeses { set; }

        int anioPresentacion { set; get; }

        int mesPresentacion { set; get; }
        int idMoneda { set; get; }

    }
}
