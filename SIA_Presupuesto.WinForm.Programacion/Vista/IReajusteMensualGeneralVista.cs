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
    public interface IReajusteMensualGeneralVista : IDialogoBaseVista
    {
        List<Anio> listaAnios { set; }
        List<Mes> listaMesesReajustes { set; }
        List<ProgramacionAnual> listaProgramacionAnual { set; }
        int mesReajuste { set; get; }
        int idPresAnu { set; get; }
        int anioPres { set; get; }
        string descripcion { set; get; }
        DateTime fechaEmision { set; get; }
        decimal tipoCambio { set; get; }
    }
}
