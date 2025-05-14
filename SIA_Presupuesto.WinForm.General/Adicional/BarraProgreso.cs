using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.General.Adicional
{
    public partial class BarraProgreso : Form
    {
        private Thread _subProceso;
        private BarraProgresoBarHelper BarraProgresoBarHelper;

        public void RefrescarBarra(decimal value)
        {
            if (this == null) return;
            Invoke(new Action(() => pbGeneral.Value = (int)value));
        }

        public void Parar()
        {
            //_subProceso.CancelAsync();
            if (_subProceso != null)
            {
                _subProceso.Abort();
                _subProceso = null;
                pbGeneral.Value = 0;
            }
        }

        public void Iniciar()
        {
            //_subProceso.RunWorkerAsync();
            if (_subProceso == null)
            {
                _subProceso.Start();
            }
        }

        public BarraProgreso(Thread t, BarraProgresoBarHelper BarraProgresoBarHelper)
        {
            InitializeComponent();
            this.BarraProgresoBarHelper = BarraProgresoBarHelper;
            //
            BarraProgresoBarHelper.ProgresoCalculo = 0;
            //
            lblMensaje.Text = BarraProgresoBarHelper.Mensaje;
            timer1.Interval = 1;
            _subProceso = t;
            if (!timer1.Enabled)
                timer1.Enabled = true;  
        }

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{

        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    pbGeneral.Value = e.ProgressPercentage; //actualizamos la barra de progreso
        //    DateTime time = Convert.ToDateTime(e.UserState); //obtenemos información adicional si procede
        //    //en este ejemplo, logamos a un textbox
        //    //lblMensaje.AppendText(time.ToLongTimeString());
        //    //txtOutput.AppendText(Environment.NewLine);
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        MessageBox.Show("El proceso ha sido cancelado");
        //    }
        //    else if (e.Error != null)
        //    {
        //        MessageBox.Show("Error. Detalles: " + (e.Error as Exception).ToString());
        //    }
        //    else
        //    {
        //        MessageBox.Show("El proceso ha sido completado con exito. Resultado: " + e.Result.ToString());
        //    }
        //}

        private void Splash_Load(object sender, EventArgs e)
        {

        }
        decimal percent = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (_subProceso != null)
            {
                if (_subProceso.IsAlive)
                {
                    //
                    BarraProgresoBarHelper.ProgresoCalculo++;
                    //
                    percent = BarraProgresoBarHelper.Cantidad == 0 ? 0 : (BarraProgresoBarHelper.ProgresoCalculo * 100 / BarraProgresoBarHelper.Cantidad);
                    if (percent > 0)
                    {
                        if (percent <= 100)
                        {
                            lblMensaje.Text = string.Format(BarraProgresoBarHelper.Mensaje + "{0}%", percent);
                            RefrescarBarra(percent);
                        }
                    }
                    else
                        lblMensaje.Text = BarraProgresoBarHelper.Mensaje;
                    

                    if (timer1.Interval != 1)
                        timer1.Interval = 1;
                    timer1.Start();
                }
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            Parar();
        }
    }
}
