using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IPresupuestoRecepcionadoVista : IDialogoBaseVista
    {
        List<GrupoPresupuestoPoco> listaGrupoPresupuesto { set; }
        int idGrupoPresupuesto { get; set; }
        string fuenteFinanciamiento { set; }
        int anio { get; set; }

        string nombreMes { get; set; }

        int idPreRec { get; set; }

        decimal importe { get; set; }

    }
}
