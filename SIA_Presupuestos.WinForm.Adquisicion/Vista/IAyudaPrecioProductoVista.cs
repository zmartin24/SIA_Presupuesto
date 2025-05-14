using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IAyudaPrecioProductoVista
    {
        object listaDatosPrincipales { set; }
        object DatoActual { get; }
        List<Anio> listaAnios { set; }

        int anioPresentacion { get; set; }
    }
}
