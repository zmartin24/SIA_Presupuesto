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
    public class EvaluacionMensualAreaPresentador
    {
        private readonly IEvaluacionMensualAreaVista evaluacionMensualAreaVista;

        private EvaluacionMensualArea evaluacionMensualArea;
        private EvaluacionMensualProgramacion EvaluacionMensualProgramacion;
        private bool esModificacion;
        private IGeneralServicio generalServicio;
        private IEvaluacionMensualProgramacionServicio programacionAnualServicio;
        public EvaluacionMensualAreaPresentador(EvaluacionMensualProgramacion EvaluacionMensualProgramacion, EvaluacionMensualArea evaluacionMensualArea, IEvaluacionMensualAreaVista evaluacionMensualAreaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            programacionAnualServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;

            this.EvaluacionMensualProgramacion = EvaluacionMensualProgramacion;
            this.evaluacionMensualAreaVista = evaluacionMensualAreaVista;
            this.esModificacion = evaluacionMensualArea != null;
            this.evaluacionMensualArea = evaluacionMensualArea ?? new EvaluacionMensualArea();
            
        }

        public void IniciarDatos()
        {
            LlenarCombos();

            if (!esModificacion) return;

            var cuenta = generalServicio.BuscarCuentaContable(evaluacionMensualArea.idCueCon);
            if (cuenta != null)
            {
                var cuenta2 = generalServicio.BuscarCuentaContable(cuenta.numCuenta, EvaluacionMensualProgramacion.ProgramacionAnual.anio);
                if (cuenta2 != null)
                {
                    evaluacionMensualAreaVista.idCueCon = cuenta2.idCueCon;
                }
                else
                    evaluacionMensualAreaVista.idCueCon = evaluacionMensualArea.idCueCon;
            }

            if (evaluacionMensualArea.idArea > 0)
            {
                var area = generalServicio.BuscarArea(evaluacionMensualArea.idArea);
                var sd = generalServicio.BuscarSubDireccion(area.idSubDireccion);

                evaluacionMensualAreaVista.idDireccion = sd.idDireccion;
                LlenarCombosSubdireccion(sd.idDireccion);

                evaluacionMensualAreaVista.idSubdireccion = sd.idSubdireccion;
                LlenarCombosAreas(sd.idSubdireccion);

                evaluacionMensualAreaVista.idArea = evaluacionMensualArea.idArea;
            }
            evaluacionMensualAreaVista.idUnidad = (Int32)evaluacionMensualArea.idUnidad;
        }

        private void LlenarCombos()
        {
            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            evaluacionMensualAreaVista.listaDirecciones = listaDireccion;

            //evaluacionMensualAreaVista.listaMeses = UtilitarioComun.ListarMeses();
            evaluacionMensualAreaVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(this.EvaluacionMensualProgramacion.ProgramacionAnual.anio); //año actual

            List<Unidad> listaUnidad = new List<Unidad>();
            listaUnidad.Add(new Unidad { idUnidad = 0, nomUnidad = "[NINGUNO]" });
            listaUnidad.AddRange(generalServicio.ListaUnidad());

            evaluacionMensualAreaVista.listaUnidades = listaUnidad;
        }

        public bool ValidarRegistroExistente()
        {
            EvaluacionMensualArea reg = null;
            if (!this.esModificacion || (this.esModificacion && !evaluacionMensualArea.idCueCon.Equals(evaluacionMensualAreaVista.idCueCon)))
                reg = programacionAnualServicio.BuscarPorCodigoArea(EvaluacionMensualProgramacion.idProAnu, evaluacionMensualAreaVista.idArea, evaluacionMensualAreaVista.idCueCon);

            return reg == null;
        }
        public void LlenarCombosSubdireccion(int idDireccion)
        {
            evaluacionMensualAreaVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
        }
        public void LlenarCombosAreas(int idSubDireccion)
        {
            evaluacionMensualAreaVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
        }
        public EvaluacionMensualArea BuscarEvaluacionMensualAreaPorCuenta()
        {
            return programacionAnualServicio.BuscarEvaluacionMensualAreaPorCuenta(EvaluacionMensualProgramacion.idEvaMenPro, evaluacionMensualAreaVista.idCueCon);
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            evaluacionMensualArea.idEvaMenPro = EvaluacionMensualProgramacion.idEvaMenPro;
            evaluacionMensualArea.idCueCon = evaluacionMensualAreaVista.idCueCon;
            evaluacionMensualArea.idArea = evaluacionMensualAreaVista.idArea;
            evaluacionMensualArea.idUnidad = 4;

            if (this.esModificacion)
            {
                evaluacionMensualArea.fechaEdita = DateTime.Now;
                evaluacionMensualArea.usuEdita = evaluacionMensualAreaVista.UsuarioOperacion.NomUsuario;
                resultado = programacionAnualServicio.ModificarAreas(evaluacionMensualArea);
            }
            else
            {
                evaluacionMensualArea.fechaCrea = DateTime.Now;
                evaluacionMensualArea.usuCrea = evaluacionMensualAreaVista.UsuarioOperacion.NomUsuario;
                evaluacionMensualArea.estado = Estados.Activo;
                resultado = programacionAnualServicio.NuevoArea(evaluacionMensualArea);
            }   

            return resultado.esCorrecto;
        }
    }
}
