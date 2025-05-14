using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class PlanAnualAdquisicionRequerimientoCabeceraPresentador
    {
        private readonly IPlanAnualAdquisicionRequerimientoCabeceraVista planAnualAdquisicionRequerimientoCabeceraVista;

        private IPlanAnualAdquisicionServicio planAnualAdquisicionServicio;
        private IGeneralServicio generalServicio;

        private PlanAnualAdquisicion planAnualAdquisicion;
        private PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento;
        private bool esModificacion;
        public PlanAnualAdquisicionRequerimientoCabeceraPresentador(PlanAnualAdquisicion planAnualAdquisicion,PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento, IPlanAnualAdquisicionRequerimientoCabeceraVista planAnualAdquisicionRequerimientoCabeceraVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.planAnualAdquisicionServicio = _Contenedor.Resolver(typeof(IPlanAnualAdquisicionServicio)) as IPlanAnualAdquisicionServicio;

            this.planAnualAdquisicionRequerimientoCabeceraVista = planAnualAdquisicionRequerimientoCabeceraVista;
            this.esModificacion = planAnualAdquisicionRequerimiento != null;
            this.planAnualAdquisicion = planAnualAdquisicion ?? new PlanAnualAdquisicion();
            this.planAnualAdquisicionRequerimiento = planAnualAdquisicionRequerimiento ?? new PlanAnualAdquisicionRequerimiento();

        }

        public void IniciarDatos()
        {
            
            planAnualAdquisicionRequerimientoCabeceraVista.anio = planAnualAdquisicion.anio;
            planAnualAdquisicionRequerimientoCabeceraVista.fechaEmision = DateTime.Now.Date;
            planAnualAdquisicionRequerimientoCabeceraVista.idMoneda = 64;

            LlenarCombos();
            if(this.esModificacion)
            {
                planAnualAdquisicionRequerimientoCabeceraVista.idMoneda = planAnualAdquisicionRequerimiento.idMoneda;
                planAnualAdquisicionRequerimientoCabeceraVista.descripcion = planAnualAdquisicionRequerimiento.descripcion;
                planAnualAdquisicionRequerimientoCabeceraVista.anio = planAnualAdquisicionRequerimiento.anio;
                planAnualAdquisicionRequerimientoCabeceraVista.fechaEmision = planAnualAdquisicionRequerimiento.fechaEmision;
                var area = generalServicio.BuscarArea(planAnualAdquisicionRequerimiento.idArea);
                if(area != null)
                {
                    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
                    if (subdireccion != null)
                    {
                        planAnualAdquisicionRequerimientoCabeceraVista.idDireccion = subdireccion.idDireccion;
                        planAnualAdquisicionRequerimientoCabeceraVista.idSubdireccion = subdireccion.idSubdireccion;
                        planAnualAdquisicionRequerimientoCabeceraVista.idArea = planAnualAdquisicionRequerimiento.idArea;
                    }
                }
            }
        }
        public bool ValidarRegistroExistente()
        {
            PlanAnualAdquisicionRequerimiento reg = null;
            if (!this.esModificacion || (this.esModificacion && (!planAnualAdquisicionRequerimiento.descripcion.Trim().ToUpper().Equals(planAnualAdquisicionRequerimientoCabeceraVista.descripcion.Trim().ToUpper()) || !planAnualAdquisicionRequerimiento.idArea.Equals(planAnualAdquisicionRequerimientoCabeceraVista.idArea))))
                reg = planAnualAdquisicionServicio.BuscarReqPorDescripcion_Area(this.planAnualAdquisicion.idPaa, planAnualAdquisicionRequerimientoCabeceraVista.descripcion.Trim().ToUpper(), planAnualAdquisicionRequerimientoCabeceraVista.idArea);

            return reg == null;
        }

        private void LlenarCombos()
        {
            planAnualAdquisicionRequerimientoCabeceraVista.listaMonedas = generalServicio.ListaMonedas();

            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            planAnualAdquisicionRequerimientoCabeceraVista.listaDirecciones = listaDireccion;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            if (idDireccion > 0)
                planAnualAdquisicionRequerimientoCabeceraVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
            else
            {
                List<Subdireccion> listaSubdireccion = new List<Subdireccion>();
                listaSubdireccion.Add(new Subdireccion { idSubdireccion = 0, desSubdireccion = "[NINGUNO]", idDireccion = 0 });
                planAnualAdquisicionRequerimientoCabeceraVista.listaSubdirecciones = listaSubdireccion;
            }
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            if (idSubDireccion > 0)
                planAnualAdquisicionRequerimientoCabeceraVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
            else
            {
                List<Area> listaAreas = new List<Area>();
                listaAreas.Add(new Area { idArea = 0, idSubDireccion = 0, desArea = "[NINGUNO]" });
                planAnualAdquisicionRequerimientoCabeceraVista.listaAreas = listaAreas;
            }
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            planAnualAdquisicionRequerimiento.idPaa = planAnualAdquisicion.idPaa;
            planAnualAdquisicionRequerimiento.idMoneda = planAnualAdquisicionRequerimientoCabeceraVista.idMoneda;
            planAnualAdquisicionRequerimiento.descripcion = planAnualAdquisicionRequerimientoCabeceraVista.descripcion;
            planAnualAdquisicionRequerimiento.anio = planAnualAdquisicionRequerimientoCabeceraVista.anio;
            planAnualAdquisicionRequerimiento.fechaEmision = planAnualAdquisicionRequerimientoCabeceraVista.fechaEmision;
            planAnualAdquisicionRequerimiento.idArea = planAnualAdquisicionRequerimientoCabeceraVista.idArea;
            if (this.esModificacion)
            {
                planAnualAdquisicionRequerimiento.fechaMod = DateTime.Now;
                planAnualAdquisicionRequerimiento.usuMod = planAnualAdquisicionRequerimientoCabeceraVista.UsuarioOperacion.NomUsuario;
                resultado = planAnualAdquisicionServicio.ModificarPaaReq(planAnualAdquisicionRequerimiento);
            }
            else
            {
                planAnualAdquisicionRequerimiento.fechaCrea = DateTime.Now;
                planAnualAdquisicionRequerimiento.usuCrea = planAnualAdquisicionRequerimientoCabeceraVista.UsuarioOperacion.NomUsuario;
                planAnualAdquisicionRequerimiento.estado = Estados.Activo;
                resultado = planAnualAdquisicionServicio.NuevoPaaReq(planAnualAdquisicionRequerimiento);
            }

            return resultado.esCorrecto;
        }
    }
}
