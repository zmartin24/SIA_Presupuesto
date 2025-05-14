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
    public interface IReajusteMensualDetalleVista : IDialogoBaseVista
    {
        List<Unidad> listaUnidades { set; }

        int idUnidad { get; set; }

        string descripcion { get; set; }

        decimal precio { get; set; }
        string justificacion { get; set; }
    }
}
