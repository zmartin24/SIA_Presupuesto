using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class SeleccionRequerimientoDetallePresentador
    {
        private readonly ISeleccionRequerimientoDetalleVista seleccionRequerimientoDetalleVista;

        private ICertificacionMasterServicio certificacionMasterServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private IGeneralServicio generalServicio;

        private CertificacionMasterPres certificacionMasterPres;
        private CertificacionRequerimiento certificacionRequerimiento;
        private CertificacionDetallePres certificacionDetallePres;

        public SeleccionRequerimientoDetallePresentador(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres, ISeleccionRequerimientoDetalleVista seleccionRequerimientoDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;

            this.seleccionRequerimientoDetalleVista = seleccionRequerimientoDetalleVista;
            this.certificacionMasterPres = certificacionMasterPres ?? new CertificacionMasterPres();
            this.certificacionRequerimiento = certificacionRequerimiento ?? new CertificacionRequerimiento();
            this.certificacionDetallePres = certificacionDetallePres;

            if (this.certificacionMasterPres.tipoReq.Equals(1))
                this.seleccionRequerimientoDetalleVista.Forebi = this.certificacionMasterServicio.BuscarForebi((int)certificacionMasterPres.idForebise);
            else
                this.seleccionRequerimientoDetalleVista.Forese = this.certificacionMasterServicio.BuscarForese((int)certificacionMasterPres.idForebise);

        }
        public void LlenarGrid()
        {
            if (this.certificacionDetallePres != null)
            {
                ForeDetallePoco detPoco = certificacionDetallePres.idForeDet != null && certificacionDetallePres.idForeDet > 0 ? this.certificacionMasterPres.tipoReq.Equals(1) ?
                                         this.certificacionMasterServicio.BuscarForebiDetallePoco((int)certificacionDetallePres.idForeDet) :
                                        this.certificacionMasterServicio.BuscarForeseDetallePoco((int)certificacionDetallePres.idForeDet)
                                        : new ForeDetallePoco();
                detPoco.tipoDet = certificacionDetallePres.tipoDet;
                detPoco.idProAnuReaMen = certificacionDetallePres.idReaMenDet;
                detPoco.idCueCon = certificacionDetallePres.idCueCon;
                detPoco.numCuenta = certificacionDetallePres.numCuenta;
                detPoco.descripcion = certificacionDetallePres.descripcion;
                detPoco.unidad = certificacionDetallePres.unidad;
                detPoco.idCerDet = certificacionDetallePres.idCerDet;
                detPoco.cantidad = (decimal)certificacionDetallePres.cantidad;
                detPoco.precio = (decimal)certificacionDetallePres.precio;
                detPoco.subTotal = (decimal)certificacionDetallePres.subTotal == 0 ? Math.Round((decimal)certificacionDetallePres.cantidad * (decimal)certificacionDetallePres.precio, 2, MidpointRounding.AwayFromZero) : (decimal)certificacionDetallePres.subTotal;

                List<ForeDetallePoco> lista = new List<ForeDetallePoco>();
                lista.Add(detPoco);
                this.seleccionRequerimientoDetalleVista.listaForeDetallePoco = lista;
            }
            else
                seleccionRequerimientoDetalleVista.listaForeDetallePoco = certificacionRequerimientoServicio.TraerListaFormatoRequerimientoDetalle(this.certificacionMasterPres.idForebise, this.certificacionMasterPres.tipoReq);
        }
        public List<SubPresupuestoDetallePres> TraerListaSubPresupuestoDetalle(int idSubPresupuesto)
        {
            return certificacionRequerimientoServicio.TraerListaSubPresupuestoDetalle(idSubPresupuesto);
        }
        public void TraerSubPresupuestoImporteCertificacion(int idSubpresupuesto)
        {
            seleccionRequerimientoDetalleVista.SubPresupuestoImporteCertificacion = certificacionRequerimientoServicio.TraerSubPresupuestoImporteCertificacion(idSubpresupuesto);
        }
        public decimal TraerCantPendiente(int idForReqDet, int tipoReq)
        {
            return certificacionRequerimientoServicio.TraerCantPendiente(idForReqDet, tipoReq);
        }
    }
}
