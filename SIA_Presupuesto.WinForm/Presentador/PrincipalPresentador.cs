using Seguridad.Modelo;
using Seguridad.Servicio;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Presentador
{
    public class PrincipalPresentador 
    {
        private readonly IPrincipalVista principalVista;
        private UsuarioServicio usuarioServ;

        private UsuarioOperacion usuarioOperacion;
        public  UsuarioOperacion UsuarioOperacion
        {
            get { return usuarioOperacion; }
            set { usuarioOperacion = value; }
        }

        private int mes;
        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        private int anio;
        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        private int mesActivo;
        public int MesActivo
        {
            get { return mesActivo; }
            set { mesActivo = value; }
        }

        private int anioActivo;
        public int AnioActivo
        {
            get { return anioActivo; }
            set { anioActivo = value; }
        }

        private int idMoneda;
        public int IdMoneda
        {
            get { return idMoneda; }
            set { idMoneda = value; }
        }

        private int idTipCam;
        public int IdTipCam
        {
            get { return idTipCam; }
            set { idTipCam = value; }
        }

        public PrincipalPresentador(IPrincipalVista principalVista)
        {
            this.principalVista = principalVista;

            IContenedor _Contenedor = new cContenedor();
            usuarioServ = _Contenedor.Resolver(typeof(UsuarioServicio)) as UsuarioServicio;
        }

        public void AsignarUsuario()
        {
            this.principalVista.nomUsuario = string.Format("USUARIO: {0} ", this.usuarioOperacion.NomUsuario);
        }

        public void AsignarPeriodo()
        {
            this.principalVista.Periodo = string.Format("PERIODO: {1} DEL {0} ", this.anio , UtilitarioComun.NombreMes(this.mes));
        }

        public List<Menu> TraerMenuUsuario()
        {
           return usuarioServ.ListaMenuOpcionesAutorizadosDos(this.usuarioOperacion.IDUsuario, 11).ToList();
        }
    }
}
