using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IEvaluacionMensualPresupuestoVista : IControlDetalleBaseVista
    {
        List<EvaluacionMensualAreaPres> listaDatosPrincipales { set; }

        EvaluacionMensualArea EvaluacionMensualArea { get; }

        EvaluacionMensualDetalle EvaluacionMensualDetalle { get; }
    }
}
