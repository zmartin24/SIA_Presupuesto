using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Presentador
{
    public class EjeOperativoPresentador
    {
        private readonly IEjeOperativoVista ejeOperativoVista;

        private IEjeOperativoServicio ejeOperativoServicio;
        private IGeneralServicio generalServicio;

        private EjeOperativo ejeOperativo;
        private bool esModificacion;
        public EjeOperativoPresentador(EjeOperativo ejeOperativo, IEjeOperativoVista ejeOperativoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.ejeOperativoServicio = _Contenedor.Resolver(typeof(IEjeOperativoServicio)) as IEjeOperativoServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.ejeOperativoVista = ejeOperativoVista;
            this.esModificacion = ejeOperativo != null;
            this.ejeOperativo = ejeOperativo ?? new EjeOperativo();
        }
        public void IniciarDatos()
        {
            if (this.esModificacion)
            {
                ejeOperativoVista.descripcion = ejeOperativo.descripcion;
            }
        }
        public bool GuardarDatos()
        {
            Resultado resultado = null;

            ejeOperativo.descripcion = ejeOperativoVista.descripcion.ToUpper();
            
            if (this.esModificacion)
            {
                ejeOperativo.fechaEdita = DateTime.Now;
                ejeOperativo.usuEdita = ejeOperativoVista.UsuarioOperacion.NomUsuario;
                resultado = ejeOperativoServicio.Modificar(ejeOperativo);
            }
            else
            {
                ejeOperativo.fechaCrea = DateTime.Now;
                ejeOperativo.usuCrea = ejeOperativoVista.UsuarioOperacion.NomUsuario;
                ejeOperativo.estado = Estados.Activo;
                resultado = ejeOperativoServicio.Nuevo(ejeOperativo);
            }

            return resultado.esCorrecto;
        }
    }
}
