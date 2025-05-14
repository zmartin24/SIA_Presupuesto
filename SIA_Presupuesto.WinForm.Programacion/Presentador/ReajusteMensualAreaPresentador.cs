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
    public class ReajusteMensualAreaPresentador
    {
        private readonly IReajusteMensualAreaVista reajusteMensualAreaVista;

        private ReajusteMensualArea reajusteMensualArea;
        private ReajusteMensualProgramacion ReajusteMensualProgramacion;
        private bool esModificacion;
        private IGeneralServicio generalServicio;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        public ReajusteMensualAreaPresentador(ReajusteMensualProgramacion ReajusteMensualProgramacion, ReajusteMensualArea reajusteMensualArea, IReajusteMensualAreaVista reajusteMensualAreaVista)
        {
            IContenedor _Contenedor = new cContenedor();
            generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;

            this.ReajusteMensualProgramacion = ReajusteMensualProgramacion;
            this.reajusteMensualAreaVista = reajusteMensualAreaVista;
            this.esModificacion = reajusteMensualArea != null;
            this.reajusteMensualArea = reajusteMensualArea ?? new ReajusteMensualArea();
            
        }

        public void IniciarDatos()
        {
            LlenarCombos();

            if (!esModificacion) return;

            
            reajusteMensualAreaVista.idCueCon = reajusteMensualArea.idCueCon;
            
            var area = generalServicio.BuscarArea(reajusteMensualArea.idArea);
            var sd = generalServicio.BuscarSubDireccion(area.idSubDireccion);

            reajusteMensualAreaVista.idDireccion = sd.idDireccion;
            LlenarCombosSubdireccion(sd.idDireccion);

            reajusteMensualAreaVista.idSubdireccion = sd.idSubdireccion;
            LlenarCombosAreas(sd.idSubdireccion);

            reajusteMensualAreaVista.idArea = reajusteMensualArea.idArea;
            reajusteMensualAreaVista.idUnidad = (Int32)reajusteMensualArea.idUnidad;
        }

        private void LlenarCombos()
        {
            List<Direccion> listaDireccion = new List<Direccion>();
            listaDireccion.Add(new Direccion { idDireccion = 0, desDireccion = "[NINGUNO]" });
            listaDireccion.AddRange(generalServicio.ListaDirecciones());

            reajusteMensualAreaVista.listaDirecciones = listaDireccion;

            reajusteMensualAreaVista.listaCuentaContable = generalServicio.ListaCuentaContableDesdeNivel2(ReajusteMensualProgramacion.ProgramacionAnual.anio); //año actual

            List<Unidad> listaUnidad = new List<Unidad>();
            listaUnidad.Add(new Unidad { idUnidad = 0, nomUnidad = "[NINGUNO]" });
            listaUnidad.AddRange(generalServicio.ListaUnidad());

            reajusteMensualAreaVista.listaUnidades = listaUnidad;
        }

        public bool ValidarRegistroExistente()
        {
            ReajusteMensualArea reg = null;
            if (!this.esModificacion || (this.esModificacion && (!reajusteMensualArea.idReaMenPro.Equals(ReajusteMensualProgramacion.idReaMenPro) || !reajusteMensualArea.idArea.Equals(reajusteMensualAreaVista.idUnidad) || !reajusteMensualArea.idCueCon.Equals(reajusteMensualAreaVista.idCueCon))))
                reg = reajusteMensualProgramacionServicio.BuscarPorCodigoArea(ReajusteMensualProgramacion.idReaMenPro, reajusteMensualAreaVista.idArea, reajusteMensualAreaVista.idCueCon);

            return reg == null;
        }

        public void LlenarCombosSubdireccion(int idDireccion)
        {
            reajusteMensualAreaVista.listaSubdirecciones = generalServicio.ListaSubDirecciones(idDireccion);
        }

        public void LlenarCombosAreas(int idSubDireccion)
        {
            reajusteMensualAreaVista.listaAreas = generalServicio.ListaAreas(idSubDireccion);
        }

        public bool GuardarDatos()
        {
            Resultado resultado = null;

            reajusteMensualArea.idReaMenPro = ReajusteMensualProgramacion.idReaMenPro;
            reajusteMensualArea.idCueCon = reajusteMensualAreaVista.idCueCon;
            reajusteMensualArea.idArea = reajusteMensualAreaVista.idArea;
            reajusteMensualArea.idUnidad = 4;

            if (this.esModificacion)
            {
                reajusteMensualArea.fechaEdita = DateTime.Now;
                reajusteMensualArea.usuEdita = reajusteMensualAreaVista.UsuarioOperacion.NomUsuario;
                resultado = reajusteMensualProgramacionServicio.ModificarAreas(reajusteMensualArea);
            }
            else
            {
                reajusteMensualArea.fechaCrea = DateTime.Now;
                reajusteMensualArea.usuCrea = reajusteMensualAreaVista.UsuarioOperacion.NomUsuario;
                reajusteMensualArea.estado = Estados.Activo;
                resultado = reajusteMensualProgramacionServicio.NuevoArea(reajusteMensualArea);
            }   

            return resultado.esCorrecto;
        }
    }
}
