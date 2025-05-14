using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Reporte;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
{
    public class ListaCertificacionPresupuestalPresentador
    {
        private readonly IListaCertificacionPresupuestalVista listaCertificacionPresupuestalVista;
        private ICertificacionMasterServicio certificacionMasterServicio;
        private IGeneralServicio generalServicio;

        public ListaCertificacionPresupuestalPresentador(IListaCertificacionPresupuestalVista listaCertificacionPresupuestalVista)
        {
            this.listaCertificacionPresupuestalVista = listaCertificacionPresupuestalVista;
        }

        public void Iniciar()
        {
            listaCertificacionPresupuestalVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaCertificacionPresupuestalVista.anioPresentacion = DateTime.Now.Year;
        }

        public void ObtenerDatosListado()
        {
            this.certificacionMasterServicio = IoCHelper.ResolverIoC<ICertificacionMasterServicio>();
            listaCertificacionPresupuestalVista.listaDatosPrincipales = certificacionMasterServicio.TraerListaCertificacionMaster(listaCertificacionPresupuestalVista.anioPresentacion);
        }

        public void CargarServicios()
        {
            this.certificacionMasterServicio = IoCHelper.ResolverIoC<ICertificacionMasterServicio>();
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
        }

        //Requerimiento
        public void IniciarDatosRequerimiento(int id)
        {
            //
            //listaPacVista.anio = DateTime.Now.Year;
            //listaPacVista.fechaEmision = DateTime.Now.Date;
            //listaPacVista.idMoneda = 64;

            //LlenarCombosRequerimiento();
            //RequerimientoBienServicio RequerimientoBienServicio = Buscar(id);
            //if (RequerimientoBienServicio == null)
            //    return;

            //listaPacVista.idMoneda = RequerimientoBienServicio.idMoneda;
            //listaPacVista.descripcion = RequerimientoBienServicio.descripcion;
            //listaPacVista.anio = RequerimientoBienServicio.anio;
            //listaPacVista.fechaEmision = RequerimientoBienServicio.fechaEmision;
            //var area = generalServicio.BuscarArea(RequerimientoBienServicio.idArea);
            //if (area != null)
            //{
            //    var subdireccion = generalServicio.BuscarSubDireccion(area.idSubDireccion);
            //    if (subdireccion != null)
            //    {
            //        listaPacVista.idDireccion = subdireccion.idDireccion;
            //        LlenarCombosSubdireccion(subdireccion.idDireccion);
            //        listaPacVista.idSubdireccion = subdireccion.idSubdireccion;
            //        LlenarCombosAreas(subdireccion.idSubdireccion);
            //        listaPacVista.idArea = RequerimientoBienServicio.idArea;
            //    }
            //}
        }
        
        public Resultado GuardarDatosRequerimiento(string args)
        {
            Resultado resultado = null;
            //var callbackArgs = Util.DeserializeCallbackArgs(args);

            //RequerimientoBienServicio RequerimientoBienServicio = null;
            //if (callbackArgs[0] == "Nuevo")
            //{
            //    RequerimientoBienServicio = new RequerimientoBienServicio();
            //}
            //else if (callbackArgs[0] == "Editar")
            //{
            //    int id = int.Parse(callbackArgs[1]);
            //    RequerimientoBienServicio = Buscar(id);
            //    esModificacion = true;
            //}

            //if (RequerimientoBienServicio == null)
            //    return null;

            //RequerimientoBienServicio.idMoneda = listaPacVista.idMoneda;
            //RequerimientoBienServicio.descripcion = listaPacVista.descripcion;
            //RequerimientoBienServicio.anio = listaPacVista.anio;
            //RequerimientoBienServicio.fechaEmision = listaPacVista.fechaEmision;
            //RequerimientoBienServicio.idArea = listaPacVista.idArea;

            //if (this.esModificacion)
            //{
            //    RequerimientoBienServicio.fechaEdita = DateTime.Now;
            //    RequerimientoBienServicio.usuEdita = listaPacVista.nomUsuario;
            //    resultado = planAnualAdquisicionServicio.ModificarSinClonar(RequerimientoBienServicio);
            //}
            //else
            //{
            //    RequerimientoBienServicio.fechaCrea = DateTime.Now;
            //    RequerimientoBienServicio.usuCrea = listaPacVista.nomUsuario;
            //    RequerimientoBienServicio.estado = Estados.Activo;
            //    resultado = planAnualAdquisicionServicio.Nuevo(RequerimientoBienServicio);
            //}

            return resultado;
        }

    }
}
