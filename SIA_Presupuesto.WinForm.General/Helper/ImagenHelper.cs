using DevExpress.Utils;
using DevExpress.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public enum TamanioImagen { Pequenio16, Grande32 }

    public class ImagenHelper
    {
        static ImagenHelper actual;
        static Icon appIcon = null;

        public static ImagenHelper Actual
        {
            get
            {
                if (actual == null)
                    actual = new ImagenHelper();
                return actual;
            }
        }

        public static Image TraerImagen(string nombre, TamanioImagen tamanio)
        {
            if (string.IsNullOrEmpty(nombre)) return null;
            return ResourceImageHelper.CreateImageFromResources(
                string.Format("SIA_Presupuesto.WinForm.General.Imagenes.{0}_{1}.png", nombre, TraerNombreTamanioImagen(tamanio)),
                typeof(Imagenes).Assembly);
        }

        public static Image TraerImagenGif(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return null;
            return ResourceImageHelper.CreateImageFromResources(
                string.Format("SIA_Presupuesto.WinForm.General.Imagenes.{0}.gif", nombre),
                typeof(Imagenes).Assembly);
        }

        static string TraerNombreTamanioImagen(TamanioImagen tamanio)
        {
            if (tamanio == TamanioImagen.Pequenio16) return "16x16";
            return "32x32";
        }

        public static ImageCollection TraerColeccionImagenesPng(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return null;
            return ImageHelper
                .CreateImageCollectionFromResources(string.Format("SIA_Presupuesto.WinForm.General.Imagenes.{0}.png", nombre),
                typeof(ImagenHelper).Assembly, new Size(16, 16));
        }

        public static Icon AppIcon
        {
            get
            {
                if (ImagenHelper.appIcon == null)
                    ImagenHelper.appIcon = ResourceImageHelper.CreateIconFromResources("SIA_Presupuesto.WinForm.General.Imagenes.IconoCorah.ico", typeof(ImagenHelper).Assembly);
                return ImagenHelper.appIcon;
            }
        }
    }

    public class Imagenes
    {
        static Imagenes actual;
        public static Imagenes Actual
        {
            get
            {
                if (actual == null)
                    actual = new Imagenes();
                return actual;
            }
        }
    }
}
