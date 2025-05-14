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
    public interface IProgramacionAnualAreaVista : IDialogoBaseVista
    {
        List<CuentaContable> listaCuentaContable { set; }

        List<Direccion> listaDirecciones { set; }

        List<Subdireccion> listaSubdirecciones { set; }

        List<Area> listaAreas { set; }

        List<Unidad> listaUnidades { set; }

        int idUnidad { get; set; }

        int idCueCon { set; get; }

        int idDireccion { set; get; }

        int idSubdireccion { set; get; }

        int idArea { set; get; }

    }
}
