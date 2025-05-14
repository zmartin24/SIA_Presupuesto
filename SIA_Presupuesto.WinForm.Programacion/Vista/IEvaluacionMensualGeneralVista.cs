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
    public interface IEvaluacionMensualGeneralVista : IDialogoBaseVista
    {
        List<Mes> listaMesesDesde { set; }
        List<Mes> listaMesesHasta { set; }
        List<Anio> listaAnios { set; }
        List<ProgramacionAnual> listaProgramacionAnual { set; }
        int anioPres { set; get; }
        int mesDesde { set; get; }
        int mesHasta { set; get; }
        int idPresAnu { set; get; }
        string descripcion { set; get; }
        DateTime fechaEmision { set; get; }
        decimal tipoCambio { set; get; }
    }
}
