using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class GastoRecurrenteRequerimientoCabeceraPresentador
    {
        private readonly IGastoRecurrenteRequerimientoCabeceraVista gastoRecurrenteRequerimientoCabeceraVista;

        private IGastoRecurrenteServicio gastoRecurrenteServicio;
        private IGeneralServicio generalServicio;

        private GastoRecurrente gastoRecurrente;
        private GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento;
        private bool esModificacion;
        public GastoRecurrenteRequerimientoCabeceraPresentador(GastoRecurrente gastoRecurrente, GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento, IGastoRecurrenteRequerimientoCabeceraVista gastoRecurrenteRequerimientoCabeceraVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.gastoRecurrenteServicio = _Contenedor.Resolver(typeof(IGastoRecurrenteServicio)) as IGastoRecurrenteServicio;

            this.gastoRecurrenteRequerimientoCabeceraVista = gastoRecurrenteRequerimientoCabeceraVista;
            this.esModificacion = gastoRecurrenteRequerimiento != null;
            this.gastoRecurrente = gastoRecurrente ?? new GastoRecurrente();
            this.gastoRecurrenteRequerimiento = gastoRecurrenteRequerimiento ?? new GastoRecurrenteRequerimiento();
        }

        public void IniciarDatos()
        {
            gastoRecurrenteRequerimientoCabeceraVista.anio = (Int32)gastoRecurrente.anio;
            gastoRecurrenteRequerimientoCabeceraVista.idMoneda = 64;

            LlenarCombos();
            if(this.esModificacion)
            {
                gastoRecurrenteRequerimientoCabeceraVista.idMoneda = gastoRecurrenteRequerimiento.idMoneda;
                gastoRecurrenteRequerimientoCabeceraVista.descripcion = gastoRecurrenteRequerimiento.descripcion;
                gastoRecurrenteRequerimientoCabeceraVista.anio = gastoRecurrenteRequerimiento.anio;
                
                var area = generalServicio.BuscarArea(gastoRecurrenteRequerimiento.idArea);
                if(area != null)
                {
                    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                    if (subdireccion != null)
                    {
                        gastoRecurrenteRequerimientoCabeceraVista.idDireccion = subdireccion.idDireccion;
                        gastoRecurrenteRequerimientoCabeceraVista.idSubdireccion = subdireccion.idSubdireccion;
                        gastoRecurrenteRequerimientoCabeceraVista.idArea = gastoRecurrenteRequerimiento.idArea;
                    }
                }
            }
        }

        private void LlenarCombos()
        {
            gastoRecurrenteRequerimientoCabeceraVista.listaMonedas = generalServicio.ListaMonedas().Where(x=>x.idMoneda != 5926).ToList();//5926 es inti

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            gastoRecurrenteRequerimientoCabeceraVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                gastoRecurrenteRequerimientoCabeceraVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                gastoRecurrenteRequerimientoCabeceraVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                gastoRecurrenteRequerimientoCabeceraVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                gastoRecurrenteRequerimientoCabeceraVista.listaAreas = listaAreas;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            gastoRecurrenteRequerimiento.idGasRec = gastoRecurrente.idGasRec;
            gastoRecurrenteRequerimiento.idMoneda = gastoRecurrenteRequerimientoCabeceraVista.idMoneda;
            gastoRecurrenteRequerimiento.descripcion = gastoRecurrenteRequerimientoCabeceraVista.descripcion;
            gastoRecurrenteRequerimiento.anio = gastoRecurrenteRequerimientoCabeceraVista.anio;
            gastoRecurrenteRequerimiento.idArea = gastoRecurrenteRequerimientoCabeceraVista.idArea;
            if (this.esModificacion)
            {
                gastoRecurrenteRequerimiento.fechaEdita = DateTime.Now;
                gastoRecurrenteRequerimiento.usuEdita = gastoRecurrenteRequerimientoCabeceraVista.UsuarioOperacion.NomUsuario;
                resultado = gastoRecurrenteServicio.ModificarGasRecReq(gastoRecurrenteRequerimiento);
            }
            else
            {
                gastoRecurrenteRequerimiento.fechaCrea = DateTime.Now;
                gastoRecurrenteRequerimiento.usuCrea = gastoRecurrenteRequerimientoCabeceraVista.UsuarioOperacion.NomUsuario;
                gastoRecurrenteRequerimiento.estado = Estados.Activo;
                resultado = gastoRecurrenteServicio.NuevoGasRecReq(gastoRecurrenteRequerimiento);
            }

            return resultado.esCorrecto;
        }
    }
}
