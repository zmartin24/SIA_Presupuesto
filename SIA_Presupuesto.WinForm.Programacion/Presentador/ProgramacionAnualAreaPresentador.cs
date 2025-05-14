using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ProgramacionAnualAreaPresentador
    {
        private readonly IProgramacionAnualAreaVista programacionAnualAreaVista;

        private ProgramacionAnualArea programacionAnualArea;
        private ProgramacionAnual programacionAnual;
        private bool esModificacion;
        private IGeneralServicio generalServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        
        public ProgramacionAnualAreaPresentador(ProgramacionAnual ProgramacionAnual, ProgramacionAnualArea programacionAnualArea, IProgramacionAnualAreaVista programacionAnualAreaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.programacionAnual = ProgramacionAnual;
            this.programacionAnualAreaVista = programacionAnualAreaVista;
            this.esModificacion = programacionAnualArea != null;
            this.programacionAnualArea = programacionAnualArea ?? new ProgramacionAnualArea();
        }

        public void IniciarDatos()
        {
            LlenarCombos();

            if (!esModificacion) return;

            var cuenta = generalServicio.BuscarCuentaContable(programacionAnualArea.idCueCon);
            if (cuenta != null)
            {
                var cuenta2 = generalServicio.BuscarCuentaContable(cuenta.numCuenta, DateTime.Now.Year);
                if(cuenta2 != null)
                {
                    programacionAnualAreaVista.idCueCon = cuenta2.idCueCon;
                }
                else
                    programacionAnualAreaVista.idCueCon = programacionAnualArea.idCueCon;
            }


            var area = generalServicio.BuscarArea(programacionAnualArea.idArea);
            var sd = generalServicio.BuscarSubDireccion(area.idSubDireccion);

            programacionAnualAreaVista.idDireccion = sd.idDireccion;
            LlenarCombosSubdireccion(sd.idDireccion);

            programacionAnualAreaVista.idSubdireccion = sd.idSubdireccion;
            LlenarCombosAreas(sd.idSubdireccion);

            programacionAnualAreaVista.idArea = programacionAnualArea.idArea;
            programacionAnualAreaVista.idUnidad = (Int32)programacionAnualArea.idUnidad;
        }

        private void LlenarCombos()
        {
            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            programacionAnualAreaVista.listaDirecciones = listaDireccion;
            programacionAnualAreaVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(DateTime.Now.Year); //año actual

            List<Unidad> listaUnidad = new List<Unidad>();
            listaUnidad.Add(new Unidad { idUnidad = 0, nomUnidad = "[NINGUNO]" });
            listaUnidad.AddRange(generalServicio.ListaUnidad());

            programacionAnualAreaVista.listaUnidades = listaUnidad;
        }

        public bool ValidarRegistroExistente()
        {
            ProgramacionAnualArea reg = null;
            if (!this.esModificacion || (this.esModificacion && (!programacionAnual.idProAnu.Equals(programacionAnual.idProAnu) || !programacionAnualArea.idArea.Equals(programacionAnualAreaVista.idArea) || !programacionAnualArea.idCueCon.Equals(programacionAnualAreaVista.idCueCon))))
                reg = programacionAnualServicio.BuscarPorCodigoArea(programacionAnual.idProAnu, programacionAnualAreaVista.idArea, programacionAnualAreaVista.idCueCon);

            return reg == null;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if(idDireccion>0)
                programacionAnualAreaVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                programacionAnualAreaVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if(idSubDireccion>0)
                programacionAnualAreaVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                programacionAnualAreaVista.listaAreas = listaAreas;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            programacionAnualArea.idProAnu = programacionAnual.idProAnu;
            programacionAnualArea.idCueCon = programacionAnualAreaVista.idCueCon;
            programacionAnualArea.idArea = programacionAnualAreaVista.idArea;
            programacionAnualArea.idUnidad = programacionAnualAreaVista.idUnidad;

            if (this.esModificacion)
            {
                programacionAnualArea.fechaEdita = DateTime.Now;
                programacionAnualArea.usuEdita = programacionAnualAreaVista.UsuarioOperacion.NomUsuario;
                resultado = programacionAnualServicio.ModificarAreas(programacionAnualArea);
            }
            else
            {
                programacionAnualArea.fechaCrea = DateTime.Now;
                programacionAnualArea.usuCrea = programacionAnualAreaVista.UsuarioOperacion.NomUsuario;
                programacionAnualArea.estado = Estados.Activo;
                resultado = programacionAnualServicio.NuevoArea(programacionAnualArea);
            }   

            return resultado.esCorrecto;
        }
    }
}
