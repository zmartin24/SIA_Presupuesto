using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class RequerimientoRecursoHumanoPresentador
    {
        private readonly IRequerimientoRecursoHumanoVista requerimientoRecursoHumanoVista;

        private IRequerimientoRecursoHumanoServicio requerimientoRecursoHumanoServicio;
        private IGeneralServicio generalServicio;

        private RequerimientoRecursoHumano requerimientoRecursoHumano;
        private bool esModificacion;
        public RequerimientoRecursoHumanoPresentador(RequerimientoRecursoHumano requerimientoRecursoHumano, IRequerimientoRecursoHumanoVista requerimientoRecursoHumanoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.requerimientoRecursoHumanoServicio = _Contenedor.Resolver(typeof(IRequerimientoRecursoHumanoServicio)) as IRequerimientoRecursoHumanoServicio;

            this.requerimientoRecursoHumanoVista = requerimientoRecursoHumanoVista;
            this.esModificacion = requerimientoRecursoHumano != null;
            this.requerimientoRecursoHumano = requerimientoRecursoHumano ?? new RequerimientoRecursoHumano();
        }

        public void IniciarDatos()
        {
            requerimientoRecursoHumanoVista.anio = DateTime.Now.Year;
            requerimientoRecursoHumanoVista.fechaEmision = DateTime.Now.Date;
            requerimientoRecursoHumanoVista.idMoneda = 64;

            LlenarCombos();
            if(this.esModificacion)
            {
                requerimientoRecursoHumanoVista.idMoneda = requerimientoRecursoHumano.idMoneda;
                requerimientoRecursoHumanoVista.descripcion = requerimientoRecursoHumano.descripcion;
                requerimientoRecursoHumanoVista.anio = requerimientoRecursoHumano.anio;
                requerimientoRecursoHumanoVista.fechaEmision = requerimientoRecursoHumano.fechaEmision;
                var area = generalServicio.BuscarArea(requerimientoRecursoHumano.idArea);
                if(area != null)
                {
                    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                    if (subdireccion != null)
                    {
                        requerimientoRecursoHumanoVista.idDireccion = subdireccion.idDireccion;
                        requerimientoRecursoHumanoVista.idSubdireccion = subdireccion.idSubdireccion;
                        requerimientoRecursoHumanoVista.idArea = requerimientoRecursoHumano.idArea;
                    }
                }
            }
        }

        private void LlenarCombos()
        {
            requerimientoRecursoHumanoVista.listaMonedas = generalServicio.ListaMonedas();

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            requerimientoRecursoHumanoVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                requerimientoRecursoHumanoVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                requerimientoRecursoHumanoVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                requerimientoRecursoHumanoVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                requerimientoRecursoHumanoVista.listaAreas = listaAreas;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            requerimientoRecursoHumano.idMoneda = requerimientoRecursoHumanoVista.idMoneda;
            requerimientoRecursoHumano.descripcion = requerimientoRecursoHumanoVista.descripcion;
            requerimientoRecursoHumano.anio = requerimientoRecursoHumanoVista.anio;
            requerimientoRecursoHumano.fechaEmision = requerimientoRecursoHumanoVista.fechaEmision;
            requerimientoRecursoHumano.idArea = requerimientoRecursoHumanoVista.idArea;
            if (this.esModificacion)
            {
                requerimientoRecursoHumano.fechaEdita = DateTime.Now;
                requerimientoRecursoHumano.usuEdita = requerimientoRecursoHumanoVista.UsuarioOperacion.NomUsuario;
                resultado = requerimientoRecursoHumanoServicio.Modificar(requerimientoRecursoHumano);
            }
            else
            {
                requerimientoRecursoHumano.fechaCrea = DateTime.Now;
                requerimientoRecursoHumano.usuCrea = requerimientoRecursoHumanoVista.UsuarioOperacion.NomUsuario;
                requerimientoRecursoHumano.estado = Estados.Activo;
                resultado = requerimientoRecursoHumanoServicio.Nuevo(requerimientoRecursoHumano);
            }

            return resultado.esCorrecto;
        }
    }
}
