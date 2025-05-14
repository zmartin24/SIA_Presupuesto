using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ControlUsuarioHelper
    {
        public static void MostrarModulo(FormBase padre, PanelControl grupo)
        {
            MenuModulo menu = padre.MenuModulo;

            Cursor cursorActual = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                ControlBase controlPrincipal = menu.TControl as ControlBase;
                controlPrincipal.Bounds = grupo.DisplayRectangle;
                controlPrincipal.Visible = false;
                grupo.Controls.Add(controlPrincipal);
                controlPrincipal.Dock = DockStyle.Fill;

                controlPrincipal.EstablecerFormulario(padre);

                controlPrincipal.Visible = true;
                controlPrincipal.BringToFront();
            }
            catch (Exception ex)
            {
                string men = ex.Message;
            }
            finally
            {
                Cursor.Current = cursorActual;
            }
        }
    }
}
