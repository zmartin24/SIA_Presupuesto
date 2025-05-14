using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Adicional
{
    public partial class Splash : Form
    {
        private Thread _subProceso;
        public Splash(Thread t, string mensaje)
        {
            InitializeComponent();
            imagen.Image = ImagenHelper.TraerImagenGif("carga");
            lblMensaje.Text = mensaje;
            tiempo.Interval = 1;
            _subProceso = t;

            if (!tiempo.Enabled)
                tiempo.Enabled = true;
        }

        private void tiempo_Tick(object sender, EventArgs e)
        {
            tiempo.Stop();

            if (_subProceso.IsAlive)
            {
                if (tiempo.Interval != 1)
                    tiempo.Interval = 1;

                tiempo.Start();
            }
            else
                this.Close();
        }
    }
}
