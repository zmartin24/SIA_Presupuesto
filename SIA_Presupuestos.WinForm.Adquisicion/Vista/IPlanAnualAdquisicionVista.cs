using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IPlanAnualAdquisicionVista : IDialogoBaseVista
    {
        List<Moneda> listaMoneda { set; }

        string descripcion { set; get; }
        int anio { set; get; }
        DateTime fechaEmision { set; get; }
        string siglas { set; get; }
        string uniEje { set; get; }
        string pliego { set; get; }

        int idTipMon { set; get; }
        decimal tipCam { set; get; }
    }
}
