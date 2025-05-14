using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using SIA_Presupuesto.WebForm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaPacVista : IListaBase
    {
        List<PlanAnualAdquisicion> listaDatosPrincipales { set; }
        
        //RequerimientoBienServicio RequerimientoBienServicio { get; }

        //Requerimientos Generales
        //List<Anio> listaAnios { set; }

        //List<Moneda> listaMonedas { set; }

        //List<Direccion> listaDirecciones { set; }

        List<Predeterminado> listaReporte { set; }
        List<Direccion> listaDireccionesReporte { set; }
        List<FuenteFinanciamiento> listaFuenteFinanciamientoReporte { set; }

        //List<Subdireccion> listaSubdirecciones { set; }

        //List<Area> listaAreas { set; }

        //int idMoneda { set; get; }

        //int anio { set; get; }

        //int anioPresentacion { set; get; }

        //string descripcion { set; get; }

        //DateTime fechaEmision { set; get; }

        string codReporte { set; get; }
        int idDireccion { set; get; }
        int idFueFin { set; get; }

        //int idSubdireccion { set; get; }

        //int idArea { set; get; }
    }
}
