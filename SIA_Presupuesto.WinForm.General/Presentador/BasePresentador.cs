using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Presentador
{
    public class FormBasePresentador
    {
        private readonly IFormBaseVista formBaseVista;

        private UsuarioOperacion usuarioOperacion;
        public UsuarioOperacion UsuarioOperacion
        {
            get { return usuarioOperacion; }
            set { usuarioOperacion = value; }
        }

        private int anio;
        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        private int mes;
        public int Mes
        {
            get { return mes; }
            set { mes = value; }
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

        private string parametro;
        public string Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }
        public FormBasePresentador(IFormBaseVista formBaseVista)
        {
            this.formBaseVista = formBaseVista;
        }
    }
}
