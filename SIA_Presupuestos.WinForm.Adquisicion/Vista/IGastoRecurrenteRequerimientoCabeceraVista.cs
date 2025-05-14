using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IGastoRecurrenteRequerimientoCabeceraVista : IDialogoBaseVista
    {
        List<Moneda> listaMonedas { set; }

        List<Direccion> listaDirecciones { set; }

        List<Subdireccion> listaSubdirecciones { set; }

        List<Area> listaAreas { set; }

        int idMoneda { set; get; }

        int anio { set; get; }

        string descripcion { set; get; }

        //DateTime fechaEmision { set; get; }

        int idDireccion { set; get; }

        int idSubdireccion { set; get; }

        int idArea { set; get; }
    }
}
