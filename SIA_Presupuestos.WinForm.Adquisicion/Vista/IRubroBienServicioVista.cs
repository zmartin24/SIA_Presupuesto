using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IRubroBienServicioVista : IDialogoBaseVista
    {
        int idRubBieSer { get; set; }

        string descripcion { get; set; }
    }
}
