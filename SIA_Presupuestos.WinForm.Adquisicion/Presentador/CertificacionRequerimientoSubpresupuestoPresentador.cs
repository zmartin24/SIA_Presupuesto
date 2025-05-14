using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class CertificacionRequerimientoSubpresupuestoPresentador
    {
        private readonly ICertificacionRequerimientoSubpresupuestoVista certificacionRequerimientoSubpresupuestoVista;

        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private IProgramacionAnualServicio programacionAnualServicio;
        private ISubpresupuestoServicio subPresupuestoServicio;
        
        private CertificacionRequerimiento certificacionRequerimiento;
        private List<SubPresupuestoPoco> listaSubPresupuestoPoco;
        private CertificacionMasterPres certificacionMasterPres;

        public CertificacionRequerimientoSubpresupuestoPresentador(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, ICertificacionRequerimientoSubpresupuestoVista certificacionRequerimientoSubpresupuestoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.subPresupuestoServicio = _Contenedor.Resolver(typeof(ISubpresupuestoServicio)) as ISubpresupuestoServicio;
            
            this.certificacionRequerimientoSubpresupuestoVista = certificacionRequerimientoSubpresupuestoVista;
            this.certificacionRequerimiento = certificacionRequerimiento ?? new CertificacionRequerimiento();
            this.certificacionMasterPres = certificacionMasterPres ?? new CertificacionMasterPres();
            this.listaSubPresupuestoPoco = new List<SubPresupuestoPoco>();
        }
        public void IniciarDatos()
        {
            llenarGrid();

            this.certificacionRequerimientoSubpresupuestoVista.CertificacionMasterPres = this.certificacionMasterPres;
            this.certificacionRequerimientoSubpresupuestoVista.CertificacionRequerimiento = this.certificacionRequerimiento;

            this.certificacionRequerimientoSubpresupuestoVista.ListaGrupoPresupuesto = grupoPresupuestoServicio.ListaGrupo();
            ///Asignamos presupuesto
            this.certificacionRequerimientoSubpresupuestoVista.idGruPre = this.certificacionMasterPres.tipoReq == 1 ? (int)this.certificacionMasterPres.forebi.idGruPre : (int)this.certificacionMasterPres.forese.idGruPre;
            this.certificacionRequerimientoSubpresupuestoVista.idPresupuesto = this.certificacionMasterPres.tipoReq == 1 ? (int)this.certificacionMasterPres.forebi.idPresupuesto : (int)this.certificacionMasterPres.forese.idPresupuesto;

        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;
            
            certificacionRequerimiento.fechaCrea = DateTime.Now;
            certificacionRequerimiento.usuCrea = certificacionRequerimientoSubpresupuestoVista.UsuarioOperacion.NomUsuario;
            
            resultado = this.certificacionRequerimientoServicio.AsignacionSubpresupuesto(this.certificacionRequerimiento, this.certificacionRequerimientoSubpresupuestoVista.idSubPresupuesto);
            return resultado.esCorrecto;
        }
        public bool AnularAsignacionSubpresupuesto(List<int> listaIds)
        {
            Resultado resultado = null;

            certificacionRequerimiento.fechaEdita = DateTime.Now;
            certificacionRequerimiento.usuEdita = certificacionRequerimientoSubpresupuestoVista.UsuarioOperacion.NomUsuario;

            resultado = this.certificacionRequerimientoServicio.AnularAsignacionSubpresupuesto(this.certificacionRequerimiento, listaIds);
            return resultado.esCorrecto;
        }
        public void llenarGrid()
        {
            this.listaSubPresupuestoPoco = this.certificacionRequerimientoServicio.TraerListaSubPresupuestoPocoPorIdCerReq(this.certificacionRequerimiento.idCerReq);
            this.certificacionRequerimientoSubpresupuestoVista.listaSubPresupuestoPoco = listaSubPresupuestoPoco;
        }
        
        public List<CertificacionRequerimientoSubprespuesto> listaCertificacionRequerimientoSubprespuesto()
        {
            return this.certificacionRequerimientoServicio.listaCertificacionRequerimientoSubprespuesto(this.certificacionRequerimiento.idCerReq, this.certificacionRequerimientoSubpresupuestoVista.idSubPresupuesto);
        }
        public void LlenarComboPresupuesto(int idGrupo)
        {
            this.certificacionRequerimientoSubpresupuestoVista.ListaProgramacion = programacionAnualServicio.TraerListaxGrupo(idGrupo);
        }
        public void LlenarComboSubPresupuesto(int idProAnu)
        {
            this.certificacionRequerimientoSubpresupuestoVista.ListaSubpresupuesto = null;
            this.certificacionRequerimientoSubpresupuestoVista.idSubPresupuesto = 0;

            List<int> listaIds = new List<int>();
            if (this.listaSubPresupuestoPoco.Count > 0)
                listaIds = this.listaSubPresupuestoPoco.Select(x => x.idSubPresupuesto).ToList();

            var listaSubpresupuesto = this.subPresupuestoServicio.TraerListaSubPresupuestoPorPresupuesto(idProAnu).Where(x => !listaIds.Contains(x.idSubpresupuesto)).ToList();
            if (listaSubpresupuesto.Count>0)
            {
                this.certificacionRequerimientoSubpresupuestoVista.ListaSubpresupuesto = listaSubpresupuesto;
                this.certificacionRequerimientoSubpresupuestoVista.idSubPresupuesto = listaSubpresupuesto.OrderByDescending(x => x.mes).FirstOrDefault().idSubpresupuesto;
            }
        }
        
    }
}
