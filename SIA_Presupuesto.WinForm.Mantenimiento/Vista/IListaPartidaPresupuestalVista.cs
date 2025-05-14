using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IListaPartidaPresupuestalVista : IControlBaseVista
    {
        List<PartidaPresupuestalPres> listaDatosPrincipales { set; }
        PartidaPresupuestalPres partidaPresupuestalPres { get; }
    }
}
