using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class BarraProgresoBarHelper
    {
        private int progresoCalculo;
        private int cantidad;
        private string mensaje;

        public int ProgresoCalculo
        {
            set { progresoCalculo = value; }
            get { return progresoCalculo; }
        }

        public int Cantidad
        {
            set { cantidad = value; }
            get { return  cantidad; }
        }

        public string Mensaje
        {
            set { mensaje = value; }
            get { return mensaje; }
        }
    }
}
