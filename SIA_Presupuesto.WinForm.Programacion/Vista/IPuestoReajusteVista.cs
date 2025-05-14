using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IPuestoReajusteVista : IDialogoBaseVista
    {

        List<TrabajadorPres> listaTrabajador { set; }

        List<CargoPres> listaCargos { set; }

        List<SedeLaboral> listaSedes { set; }

        List<Moneda> listaMonedas { set; }

        List<DatoRegimenLaboral> listaRegimelLaboral { set; }

        List<DatoCategoriaLaboral> listaCategoriaLaboral { set; }

        List<DatoCondicionLaboral> listaCondicionLaboral { set; }

        List<Direccion> listaDirecciones { set; }

        List<Subdireccion> listaSubdirecciones { set; }

        List<Area> listaAreas { set; }

        int idDireccion { get; set; }

        int idSubdireccion { get; set; }

        int idArea { get; set; }

        int idRegLab { get; set; }

        int idConLab { get; set; }

        int idCatLab { get; set; }

        int idTrabajador { get; set; }
        int idCargo { get; set; }
        int idSede { get; set; }
        int idMoneda { get; set; }
        int cantVacante { get; set; }

        decimal remuneracion { get; set; }

        int grado { get; set; }

        bool esVacante { get; set; }

        bool esRemDiaria { get; set; }

        bool conBonoAlimento { get; set; }

        bool conBonoAlimentoEsp { get; set; }

        bool conBonoMovilidad { get; set; }

        bool conBonoProductividad { get; set; }

        DateTime fechaInicio { get; set; }

        DateTime fechaTermino { get; set; }

        DateTime fechaMin { set; }

        DateTime fechaMax { set; }
    }
}
