
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using SIA_Presupuesto.WinForm.General.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class VentanaHelper
    {

        public static void CerrarPersonalizacionFormulario(ControlBase control)
        {
            if (control == null) return;
            CloseElements(control);
            foreach (ControlDetalleBase dBase in control.DetalleModulosColeccion)
                CloseElements(dBase);
        }

        public static string ReplaceFilterText(object filter, string sourceString, string retString)
        {
            string displayFilterText = string.Format("{0}", filter);
            if (displayFilterText.Contains(sourceString))
                return displayFilterText.Replace(sourceString, retString);
            return null;
        }

        static BaseView GetBaseViewByControl(Control control)
        {
            if (control == null) return null;
            foreach (Control cntl in control.Controls)
                if (cntl is GridControl)
                    return ((GridControl)cntl).MainView;
            return null;
        }

        static LayoutControl GetLayoutControlByControl(Control control)
        {
            if (control == null) return null;
            foreach (Control cntl in control.Controls)
                if (cntl is LayoutControl)
                    return cntl as LayoutControl;
            return null;
        }

        static void CloseElements(Control control)
        {
            foreach (Control ctrl in control.Controls)
                CloseElements(ctrl);
            BaseView view = GetBaseViewByControl(control);
            if (view != null)
            {
                foreach (BaseView bView in view.GridControl.Views)
                    if (bView is GridView)
                        ((GridView)bView).DestroyCustomization();
            }
            LayoutControl layout = GetLayoutControlByControl(control);
            if (layout != null)
                layout.HideCustomizationForm();

        }
    }
}
