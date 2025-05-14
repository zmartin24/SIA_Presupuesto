using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class RequerimientoBienServicioPresentador
    {
        private readonly IRequerimientoBienServicioGeneralVista programacionAnualGeneralVista;

        private IRequerimientoBienServicioServicio programacionAnualServicio;
        private IGeneralServicio generalServicio;

        private RequerimientoBienServicio RequerimientoBienServicio;
        private bool esModificacion;
        public RequerimientoBienServicioPresentador(RequerimientoBienServicio RequerimientoBienServicio, IRequerimientoBienServicioGeneralVista programacionAnualGeneralVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IRequerimientoBienServicioServicio)) as IRequerimientoBienServicioServicio;

            this.programacionAnualGeneralVista = programacionAnualGeneralVista;
            this.esModificacion = RequerimientoBienServicio != null;
            this.RequerimientoBienServicio = RequerimientoBienServicio ?? new RequerimientoBienServicio();
        }

        public void IniciarDatos()
        {
            programacionAnualGeneralVista.anio = DateTime.Now.Year;
            programacionAnualGeneralVista.fechaEmision = DateTime.Now.Date;
            programacionAnualGeneralVista.idMoneda = 64;

            LlenarCombos();
            if(this.esModificacion)
            {
                programacionAnualGeneralVista.idMoneda = RequerimientoBienServicio.idMoneda;
                programacionAnualGeneralVista.descripcion = RequerimientoBienServicio.descripcion;
                programacionAnualGeneralVista.anio = RequerimientoBienServicio.anio;
                programacionAnualGeneralVista.fechaEmision = RequerimientoBienServicio.fechaEmision;
                var area = generalServicio.BuscarArea(RequerimientoBienServicio.idArea);
                if(area != null)
                {
                    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                    if (subdireccion != null)
                    {
                        programacionAnualGeneralVista.idDireccion = subdireccion.idDireccion;
                        programacionAnualGeneralVista.idSubdireccion = subdireccion.idSubdireccion;
                        programacionAnualGeneralVista.idArea = RequerimientoBienServicio.idArea;
                    }
                }
            }
        }

        private void LlenarCombos()
        {
            programacionAnualGeneralVista.listaMonedas = generalServicio.ListaMonedas();

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            programacionAnualGeneralVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                programacionAnualGeneralVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                programacionAnualGeneralVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                programacionAnualGeneralVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                programacionAnualGeneralVista.listaAreas = listaAreas;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            RequerimientoBienServicio.idMoneda = programacionAnualGeneralVista.idMoneda;
            RequerimientoBienServicio.descripcion = programacionAnualGeneralVista.descripcion;
            RequerimientoBienServicio.anio = programacionAnualGeneralVista.anio;
            RequerimientoBienServicio.fechaEmision = programacionAnualGeneralVista.fechaEmision;
            RequerimientoBienServicio.idArea = programacionAnualGeneralVista.idArea;
            if (this.esModificacion)
            {
                RequerimientoBienServicio.fechaEdita = DateTime.Now;
                RequerimientoBienServicio.usuEdita = programacionAnualGeneralVista.UsuarioOperacion.NomUsuario;
                resultado = programacionAnualServicio.Modificar(RequerimientoBienServicio);
            }
            else
            {
                RequerimientoBienServicio.fechaCrea = DateTime.Now;
                RequerimientoBienServicio.usuCrea = programacionAnualGeneralVista.UsuarioOperacion.NomUsuario;
                RequerimientoBienServicio.estado = Estados.Activo;
                resultado = programacionAnualServicio.Nuevo(RequerimientoBienServicio);
            }

            return resultado.esCorrecto;
        }
    }
}
