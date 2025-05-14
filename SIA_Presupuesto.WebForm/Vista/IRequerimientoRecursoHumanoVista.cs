using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IRequerimientoRecursoHumanoVista : IFormularioBase
    {
        List<RequerimientoRecursoHumanoDetallePres> listaDatosPrincipales { set; }
        List<TrabajadorPres> listaTrabajador { set; }

        string descripcion { set; }

        List<CargoPres> listaCargos { set; }

        List<CargoPres> listaCargosPro { set; }

        List<DatoRegimenLaboral> listaRegimelLaboral { set; }

        List<DatoCategoriaLaboral> listaCategoriaLaboral { set; }

        List<DatoCondicionLaboral> listaCondicionLaboral { set; }

        List<SedeLaboral> listaSedes { set; }

        //List<Direccion> listaDirecciones { set; }

        //List<Subdireccion> listaSubdirecciones { set; }

        //List<Area> listaAreas { set; }

        List<Moneda> listaMonedas { set; }
        List<FuenteFinanciamiento> listaFuenteFinanciamiento { set; }

        int idReqRecHum { get; set; }

        int idTrabajador { get; set; }

        string desPersonal { get; set; }
        int idCargo { get; set; }
        string desCargo { get; set; }

        int idRegLab { get; set; }

        int idConLab { get; set; }

        int idCatLab { get; set; }

        int idSede { get; set; }

        //int idDireccion { get; set; }

        //int idSubdireccion { get; set; }

        //int idArea { get; set; }

        int grado { get; set; }

        int idMoneda { get; set; }

        decimal remuneracion { get; set; }

        int idCargoPropuesto { get; set; }
        int gradoPropuesto { get; set; }
        decimal remPropuesta { get; set; }

        bool esVacante { get; set; }
        int cantVacante { get; set; }

        bool esRemDiaria { get; set; }

        //bool conBonoAlimento { get; set; }

        //bool conBonoProductividad { get; set; }

        //bool conBonoMovilidad { get; set; }

        //bool conBonoAlimentoEsp { get; set; }

        int idFueFin { get; set; }

        string justificacion { get; set; }

        string observacion { get; set; }
        DateTime fechaInicio { get; set; }

        DateTime fechaTermino { get; set; }

        //DateTime fechaMin { set; }

        //DateTime fechaMax { set; }
    }
}
