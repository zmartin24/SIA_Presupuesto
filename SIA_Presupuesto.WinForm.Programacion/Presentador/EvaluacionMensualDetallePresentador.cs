using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class EvaluacionMensualDetallePresentador
    {
        private readonly IEvaluacionMensualDetalleVista evaluacionMensualDetalleVista;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private EvaluacionMensualDetalle evaluacionMensualDetalle;
        private bool esModificacion;
        private EvaluacionMensualArea EvaluacionMensualArea;
        private bool esNuevaArea;
        public EvaluacionMensualDetallePresentador(EvaluacionMensualArea EvaluacionMensualArea, EvaluacionMensualDetalle evaluacionMensualDetalle, IEvaluacionMensualDetalleVista evaluacionMensualDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.EvaluacionMensualArea = EvaluacionMensualArea;
            this.evaluacionMensualDetalleVista = evaluacionMensualDetalleVista;
            this.esModificacion = evaluacionMensualDetalle != null;
            this.evaluacionMensualDetalle = evaluacionMensualDetalle ?? new EvaluacionMensualDetalle();
        }

        public void IniciarDatos()
        {
            LlenarCombos();
            if (this.esModificacion)
            {
                evaluacionMensualDetalleVista.idUnidad = evaluacionMensualDetalle.idUnidad;
                evaluacionMensualDetalleVista.descripcion = evaluacionMensualDetalle.descripcion;
                evaluacionMensualDetalleVista.precio = evaluacionMensualDetalle.precio;
            }
        }
        public bool ValidarRegistroExistente()
        {
            EvaluacionMensualDetalle reg = null;
            if (!this.esModificacion || (this.esModificacion && (!evaluacionMensualDetalle.descripcion.Trim().ToUpper().Equals(this.evaluacionMensualDetalleVista.descripcion.Trim().ToUpper()) || !evaluacionMensualDetalle.idUnidad.Equals(this.evaluacionMensualDetalleVista.idUnidad) || !evaluacionMensualDetalle.precio.Equals(this.evaluacionMensualDetalleVista.precio))))
                reg = evaluacionMensualProgramacionServicio.BuscarPorCodigoDetalle(this.EvaluacionMensualArea.idEvaMenArea, this.evaluacionMensualDetalleVista.descripcion, this.evaluacionMensualDetalleVista.idUnidad, this.evaluacionMensualDetalleVista.precio);

            return reg == null;
        }

        private void LlenarCombos()
        {
            evaluacionMensualDetalleVista.listaUnidades = generalServicio.ListaUnidad();
        }

        private EvaluacionMensualArea IngresarMontoArea()
        {
            EvaluacionMensualArea nuevaArea = null;
            if (this.EvaluacionMensualArea != null)
            {
                var paa = this.EvaluacionMensualArea;
                nuevaArea = evaluacionMensualProgramacionServicio.BuscarPorCodigoArea(paa.idEvaMenPro, paa.idArea, paa.idCueCon);
                if (nuevaArea == null)
                {
                    nuevaArea = new EvaluacionMensualArea();
                    nuevaArea.idArea = paa.idArea;
                    nuevaArea.idCueCon = paa.idCueCon;
                    nuevaArea.idEvaMenPro = paa.idEvaMenPro;
                    nuevaArea.usuCrea = evaluacionMensualDetalleVista.UsuarioOperacion.NomUsuario;
                    nuevaArea.fechaCrea = DateTime.Now;
                    nuevaArea.estado = Estados.Activo;
                    evaluacionMensualProgramacionServicio.NuevoArea(nuevaArea);
                    esNuevaArea = true;
                }
            }
            return nuevaArea;
        }
        public EvaluacionMensualDetalle BuscarEvaluacionMensualDetalle()
        {
            return evaluacionMensualProgramacionServicio.BuscarPorCodigoDetalle(this.EvaluacionMensualArea.idEvaMenArea, this.evaluacionMensualDetalleVista.descripcion, this.evaluacionMensualDetalleVista.idUnidad, this.evaluacionMensualDetalleVista.precio);
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            EvaluacionMensualArea EvaluacionMensualArea_ = IngresarMontoArea();

            if (EvaluacionMensualArea_ != null)
            {
                evaluacionMensualDetalle.idUnidad = evaluacionMensualDetalleVista.idUnidad;
                evaluacionMensualDetalle.descripcion = evaluacionMensualDetalleVista.descripcion.ToUpper().Trim();
                evaluacionMensualDetalle.precio = evaluacionMensualDetalleVista.precio;
                
                if (this.esModificacion)
                {
                    evaluacionMensualDetalle.fechaEdita = DateTime.Now;
                    evaluacionMensualDetalle.usuEdita = evaluacionMensualDetalleVista.UsuarioOperacion.NomUsuario;
                    resultado = evaluacionMensualProgramacionServicio.ModificarDetalles(evaluacionMensualDetalle);
                }
                else
                {
                    evaluacionMensualDetalle.idEvaMenProArea = EvaluacionMensualArea_.idEvaMenArea;
                    evaluacionMensualDetalle.fechaCrea = DateTime.Now;
                    evaluacionMensualDetalle.usuCrea = evaluacionMensualDetalleVista.UsuarioOperacion.NomUsuario;
                    evaluacionMensualDetalle.estado = Estados.Activo;
                    resultado = evaluacionMensualProgramacionServicio.NuevoDetalle(evaluacionMensualDetalle, !esNuevaArea);
                }
            }

            return resultado != null ? resultado.esCorrecto : false;
        }
    }
}
