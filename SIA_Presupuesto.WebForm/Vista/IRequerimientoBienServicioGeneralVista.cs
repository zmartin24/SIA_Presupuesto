using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IRequerimientoBienServicioGeneralVista : IFormularioBase
    {
        List<Moneda> listaMonedas { set; }

        List<Direccion> listaDirecciones { set; }

        List<Subdireccion> listaSubdirecciones { set; }

        List<Area> listaAreas { set; }

        int idMoneda { set; get; }

        int anio { set; get; }

        string descripcion { set; get; }

        DateTime fechaEmision { set; get; }

        int idDireccion { set; get; }

        int idSubdireccion { set; get; }

        int idArea { set; get; }
    }
}
