using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ReajustePresupuestoRemuneracionPresentador
    {
        private readonly IReajustePresupuestoRemuneracionVista reajustePresupuestoRemuneracionVista;
        private IReajustePresupuestoRemuneracionServicio reajustePresupuestoRemuneracionServicio;
        private IPuestoReajustePresupuestoServicio puestoPresupuestoServicio;
        private IEstructuraPresupuestoRemuneracionServicio estructuraServicio;
        private ReajusteMensualProgramacion reajusteMensualProgramacion;
        private bool esModificacion;
        public ReajustePresupuestoRemuneracionPresentador(ReajusteMensualProgramacion reajusteMensualProgramacion, IReajustePresupuestoRemuneracionVista reajustePresupuestoRemuneracionVista)
        {
            this.reajusteMensualProgramacion = reajusteMensualProgramacion;
            IContenedor _Contenedor = new cContenedor();
            this.reajustePresupuestoRemuneracionVista = reajustePresupuestoRemuneracionVista;
            this.reajustePresupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IReajustePresupuestoRemuneracionServicio)) as IReajustePresupuestoRemuneracionServicio;
            this.puestoPresupuestoServicio = _Contenedor.Resolver(typeof(IPuestoReajustePresupuestoServicio)) as IPuestoReajustePresupuestoServicio;
            this.estructuraServicio = _Contenedor.Resolver(typeof(IEstructuraPresupuestoRemuneracionServicio)) as IEstructuraPresupuestoRemuneracionServicio;
            this.esModificacion = reajusteMensualProgramacion.idEstPreRem != null;
        }

        public void IniciarDatos()
        {
            if (!reajustePresupuestoRemuneracionServicio.VerificarDatosIniciales(reajusteMensualProgramacion.idReaMenPro))
            {
                reajustePresupuestoRemuneracionServicio.MigrarDatosProgramacionReajuste(reajusteMensualProgramacion.idReaMenPro, reajustePresupuestoRemuneracionVista.UsuarioOperacion.NomUsuario);
            }

            var listaEst = estructuraServicio.TraerTodosActivos();
            reajustePresupuestoRemuneracionVista.listaEstructura = listaEst;
            if (listaEst != null)
            {
                if (listaEst.Count > 0)
                    reajustePresupuestoRemuneracionVista.idEstPreRem = listaEst.First().idEstPreRem;
            }

            reajustePresupuestoRemuneracionVista.listaMesDesde = UtilitarioComun.ListarMeses();
            reajustePresupuestoRemuneracionVista.listaMesHasta = UtilitarioComun.ListarMeses();
            reajustePresupuestoRemuneracionVista.mesDesde = reajusteMensualProgramacion.mesReajuste;
            reajustePresupuestoRemuneracionVista.mesHasta = 12;

            if (this.esModificacion)
            {
                reajustePresupuestoRemuneracionVista.idEstPreRem = (Int32)reajusteMensualProgramacion.idEstPreRem;
                reajustePresupuestoRemuneracionVista.mesDesde = (Int32)reajusteMensualProgramacion.mesDesdeRem;
                reajustePresupuestoRemuneracionVista.mesHasta = (Int32)reajusteMensualProgramacion.mesHastaRem;
            }
        }

        public void ObtenerDatosListado()
        {
            reajustePresupuestoRemuneracionVista.listaDatosPrincipales = 
                reajustePresupuestoRemuneracionServicio.TraerResultadoCalculoReajustePresupuestoRemuneracion(this.reajusteMensualProgramacion.idReaMenPro, reajustePresupuestoRemuneracionVista.idEstPreRem);
        }
        public PuestoReajustePresupuesto Buscar(int vid)
        {
            return puestoPresupuestoServicio.BuscarPorCodigo(vid);
        }

        public List<PuestoReajustePresupuesto> Buscar(List<int> vids)
        {
            return puestoPresupuestoServicio.BuscarPorCodigo(vids);
        }

        public bool Calcular()
        {
            Resultado resultado = null;
            List<ResultadoCalculoPoco> listaResultado = reajustePresupuestoRemuneracionServicio.CalcularReajustePresupuestoRemuneraciones(this.reajusteMensualProgramacion.idReaMenPro, reajustePresupuestoRemuneracionVista.idEstPreRem, reajustePresupuestoRemuneracionVista.mesDesde, reajustePresupuestoRemuneracionVista.mesHasta);

            if (listaResultado != null)
                if (!this.esModificacion)
                {
                    resultado = reajustePresupuestoRemuneracionServicio.Nuevo(listaResultado, reajustePresupuestoRemuneracionVista.idEstPreRem, this.reajusteMensualProgramacion.idReaMenPro, reajustePresupuestoRemuneracionVista.UsuarioOperacion.NomUsuario, reajustePresupuestoRemuneracionVista.mesDesde, reajustePresupuestoRemuneracionVista.mesHasta);
                    this.esModificacion = true;
                }
                else
                    resultado = reajustePresupuestoRemuneracionServicio.Modificar(listaResultado, reajustePresupuestoRemuneracionVista.idEstPreRem, this.reajusteMensualProgramacion.idReaMenPro, reajustePresupuestoRemuneracionVista.UsuarioOperacion.NomUsuario, reajustePresupuestoRemuneracionVista.mesDesde, reajustePresupuestoRemuneracionVista.mesHasta);
            else
                resultado = new Resultado();

            return resultado.esCorrecto;
        }

        public bool Anular()
        {
            bool respuesta = false;
            if (reajustePresupuestoRemuneracionVista.puestoPresupuestos != null)
            {
                respuesta = this.reajustePresupuestoRemuneracionServicio.AnularPuestos(reajustePresupuestoRemuneracionVista.puestoPresupuestos, reajustePresupuestoRemuneracionVista.UsuarioOperacion.NomUsuario).esCorrecto;
            }
            return respuesta;
        }


    }
}
