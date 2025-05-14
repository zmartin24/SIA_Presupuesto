using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IListaParametroPresRemVista : IControlBaseVista
    {
        List<ParametroPoco> listaDatosPrincipales { set; }
        ParametroPresupuestoRemuneracion parametroPresupuestoRemuneracion { get; }
    }
}
