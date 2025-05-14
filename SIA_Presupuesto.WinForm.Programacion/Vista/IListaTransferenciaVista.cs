using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaTransferenciaVista : IDialogoBaseVista
    {
        List<GrupoPresupuestoTransferidoPoco> listaGrupoPresupuestoTransferido {set; }

        List<GrupoPresupuestoPoco> listaGrupoPresupuesto { set; }

        int idPreRec { get; set; }

        int idGrupoPresupuesto { set; get; }

        List<ItemPoco> listaAnios { set; }

        int anio { get;}

        int mes { get; }

        List<ItemPoco> listaMeses { set; }

        decimal importe { get; set; }
        decimal importetransferido { get; set; }

        decimal importerestante { get; set; }

    }
}
