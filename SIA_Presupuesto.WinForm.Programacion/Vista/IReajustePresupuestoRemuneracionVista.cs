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
    public interface IReajustePresupuestoRemuneracionVista : IControlDetalleBaseVista
    {
        List<CalculoReajustePresupuestoRemuneracion> listaDatosPrincipales { set; }
        List<PuestoReajustePresupuesto> puestoPresupuestos { get; }
        List<EstructuraPresupuestoRemuneracion> listaEstructura { set; }
        int idEstPreRem { set; get; }

        List<Mes> listaMesDesde { set; }

        List<Mes> listaMesHasta { set; }

        int mesDesde { set; get; }

        int mesHasta { set; get; }
    }
}
