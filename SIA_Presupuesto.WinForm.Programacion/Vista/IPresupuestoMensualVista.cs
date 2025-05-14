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
    public interface IPresupuestoMensualVista : IDialogoBaseVista
    {
        List<GrupoPresupuestoPoco> ListaGrupoPresupuesto { set; }
        int idGruPre { get; set; }

        int idProAnual { get; set; }

        List<ProgramacionAnual> ListaProgramacion { set; }

        List<ItemPoco> ListaAnios{ set; }

        List<ItemPoco> ListaMes{ set; }

        List<ItemPoco> ListaEstados{ set; }

        string descripcion { get; set; }

        string abreviatura { get; set; }
        string nroProyecto { get; set; }

        string nombreCortoPpto { get; set; }

        int anio { get; set; }

        int mes { get; set; }

        int idSubPresupuesto { get; set; }

        bool esEncargo { get; set; }

        bool esActividadCampo { get; set; }

        bool esObra { get; set; }

        bool esErradicacion { get; set; }

        int estado { get; set; }
        decimal importe { get; set; }

    }
}
