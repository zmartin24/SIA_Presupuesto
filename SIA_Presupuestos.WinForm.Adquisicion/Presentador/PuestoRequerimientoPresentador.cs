using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class PuestoRequerimientoPresentador
    {
        private readonly IPuestoRequerimientoVista puestoRequerimientoVista;
        private IGeneralServicio generalServicio;
        private IPuestoRequerimientoServicio puestoRequerimientoServicio;
        private bool esModificacion;
        private PuestoRequerimiento puestoRequerimiento;
        private RequerimientoRecursoHumano requerimientoRecursoHumano;
        public PuestoRequerimientoPresentador(RequerimientoRecursoHumano requerimientoRecursoHumano, PuestoRequerimiento puestoRequerimiento, IPuestoRequerimientoVista puestoRequerimientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.puestoRequerimientoVista = puestoRequerimientoVista;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.puestoRequerimientoServicio = _Contenedor.Resolver(typeof(IPuestoRequerimientoServicio)) as IPuestoRequerimientoServicio;
            this.requerimientoRecursoHumano = requerimientoRecursoHumano;

            this.esModificacion = puestoRequerimiento != null;
            this.puestoRequerimiento = puestoRequerimiento ?? new PuestoRequerimiento();
        }

        public void IniciarDatos()
        {
            puestoRequerimientoVista.listaCargos = generalServicio.ListaCargos();
            puestoRequerimientoVista.listaSedes = generalServicio.ListaSedeLaboral();
            puestoRequerimientoVista.listaTrabajador = generalServicio.ListaTrabajadores();
            puestoRequerimientoVista.listaMonedas = generalServicio.ListaMonedas();
            puestoRequerimientoVista.listaCategoriaLaboral = generalServicio.TraerDatosCategoriaLaboral();
            puestoRequerimientoVista.listaCondicionLaboral = generalServicio.TraerDatosCondicionLaboral();
            puestoRequerimientoVista.listaRegimelLaboral = generalServicio.TraerDatosRegimenLaboral();
            puestoRequerimientoVista.listaDirecciones = generalServicio.ListaDirecciones();

            puestoRequerimientoVista.fechaMin = new DateTime(this.requerimientoRecursoHumano.anio, 1, 1);
            puestoRequerimientoVista.fechaMax = new DateTime(this.requerimientoRecursoHumano.anio, 12, 31);

            puestoRequerimientoVista.fechaInicio = new DateTime(this.requerimientoRecursoHumano.anio, 1, 1);
            puestoRequerimientoVista.fechaTermino = new DateTime(this.requerimientoRecursoHumano.anio, 12, 31);

            var area = generalServicio.BuscarArea((Int32)requerimientoRecursoHumano.idArea);
            if (area != null)
            {
                var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                if (subdireccion != null)
                {
                    puestoRequerimientoVista.idDireccion = (Int32)subdireccion.idDireccion;
                    puestoRequerimientoVista.idSubdireccion = (Int32)subdireccion.idSubdireccion;
                    puestoRequerimientoVista.idArea = (Int32)requerimientoRecursoHumano.idArea;
                }
            }

            if (this.esModificacion)
            {
                puestoRequerimientoVista.idCargo = puestoRequerimiento.idCargo;
                puestoRequerimientoVista.idSede = (Int32)puestoRequerimiento.idSede;
                puestoRequerimientoVista.idMoneda = (Int32)puestoRequerimiento.idTipMon;
                puestoRequerimientoVista.idRegLab = (Int32)puestoRequerimiento.idRegLab;
                puestoRequerimientoVista.idConLab = (Int32)puestoRequerimiento.idConLab;
                puestoRequerimientoVista.idCatLab = (Int32)puestoRequerimiento.idCatLab;
                puestoRequerimientoVista.fechaInicio = (DateTime)puestoRequerimiento.fechaInicio;
                puestoRequerimientoVista.fechaTermino = (DateTime)puestoRequerimiento.fechaTermino;

                
                if (puestoRequerimiento.idTrabajador != null)
                    puestoRequerimientoVista.idTrabajador = (Int32)puestoRequerimiento.idTrabajador;


                puestoRequerimientoVista.remuneracion = puestoRequerimiento.remuneracion;
                
                puestoRequerimientoVista.grado = puestoRequerimiento.grado;
                puestoRequerimientoVista.esVacante = puestoRequerimiento.esVacante;
                puestoRequerimientoVista.esRemDiaria = puestoRequerimiento.esRemDiaria;
                puestoRequerimientoVista.conBonoAlimento = (bool)puestoRequerimiento.conBonoAlimento;
                puestoRequerimientoVista.conBonoAlimentoEsp = (bool)puestoRequerimiento.conBonoAlimentoAdi;
                puestoRequerimientoVista.conBonoMovilidad = (bool)puestoRequerimiento.conBonoMovilidad;
                puestoRequerimientoVista.conBonoProductividad = (bool)puestoRequerimiento.conBonoProductividad;
            }
        }

        public void CargarSubdirecciones()
        {
            puestoRequerimientoVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(puestoRequerimientoVista.idDireccion);
        }

        public void CargarAreas()
        {
            puestoRequerimientoVista.listaAreas = generalServicio.ListaAreas(puestoRequerimientoVista.idSubdireccion);
        }
        public PuestoRequerimiento BuscarPorTrabajador()
        {
            return puestoRequerimientoServicio.BuscarPorTrabajador(requerimientoRecursoHumano.idReqRecHum, puestoRequerimientoVista.idTrabajador);
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            puestoRequerimiento.idCargo = puestoRequerimientoVista.idCargo;
            puestoRequerimiento.idSede = puestoRequerimientoVista.idSede;
            if (!puestoRequerimientoVista.esVacante)
                puestoRequerimiento.idTrabajador = puestoRequerimientoVista.idTrabajador;
            else
                puestoRequerimiento.idTrabajador = null;

            puestoRequerimiento.remuneracion = puestoRequerimientoVista.remuneracion;
            puestoRequerimiento.grado = puestoRequerimientoVista.grado;
            puestoRequerimiento.esVacante = puestoRequerimientoVista.esVacante;
            puestoRequerimiento.esRemDiaria = puestoRequerimientoVista.esRemDiaria;
            puestoRequerimiento.idRegLab = puestoRequerimientoVista.idRegLab;
            puestoRequerimiento.idCatLab = puestoRequerimientoVista.idCatLab;
            puestoRequerimiento.idConLab = puestoRequerimientoVista.idConLab;
            puestoRequerimiento.conBonoAlimento = puestoRequerimientoVista.conBonoAlimento;
            puestoRequerimiento.conBonoAlimentoAdi = puestoRequerimientoVista.conBonoAlimentoEsp;
            puestoRequerimiento.conBonoMovilidad = puestoRequerimientoVista.conBonoMovilidad;
            puestoRequerimiento.conBonoProductividad = puestoRequerimientoVista.conBonoProductividad;
            puestoRequerimiento.idTipMon = puestoRequerimientoVista.idMoneda;
            puestoRequerimiento.fechaInicio = puestoRequerimientoVista.fechaInicio;
            puestoRequerimiento.fechaTermino = puestoRequerimientoVista.fechaTermino;

            if (this.esModificacion)
            {
                puestoRequerimiento.fechaEdita = DateTime.Now;
                puestoRequerimiento.usuEdita = puestoRequerimientoVista.UsuarioOperacion.NomUsuario;
                resultado = puestoRequerimientoServicio.Modificar(puestoRequerimiento);
            }
            else
            {
                puestoRequerimiento.idReqRecHum = requerimientoRecursoHumano.idReqRecHum;
                puestoRequerimiento.fechaCrea = DateTime.Now;
                puestoRequerimiento.usuCrea = puestoRequerimientoVista.UsuarioOperacion.NomUsuario;
                puestoRequerimiento.estado = Estados.Activo;
                resultado = puestoRequerimientoServicio.Nuevo(puestoRequerimiento);
            }

            return resultado.esCorrecto;
        }
    }
}
