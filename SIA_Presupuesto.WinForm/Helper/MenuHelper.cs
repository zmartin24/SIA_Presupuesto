using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using Seguridad.Modelo;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Helper
{
    public class MenuHelper
    {
        public static void CargarMenu(NavBarControl nbcMenuPrincipal, List<Menu> listaMenuUsuario)
        {

            //List<Menu> listaMenus = LlenarMenu(listaMenuUsuario); //ListaMenus();
            IEnumerable<Menu> grupos = listaMenuUsuario.Where(s => s.tipo.Equals("CA")).OrderBy(o => o.posicion);

            nbcMenuPrincipal.BeginUpdate();
            foreach (Menu menuGrupo in grupos)
            {

                NavBarGroup grupo = new NavBarGroup(menuGrupo.titulo);
                grupo.SmallImage = UtilitarioComun.byteA_Imagen(menuGrupo.iconoPequenio); //ImagenHelper.TraerImagen(menuGrupo.nomImagen, TamanioImagen.Pequenio16);
                grupo.GroupStyle = NavBarGroupStyle.SmallIconsText;
                grupo.GroupCaptionUseImage = NavBarImage.Small;
                var itemsGrupo = listaMenuUsuario.Where(w => w.idDependencia == menuGrupo.idMenu && w.tipo.Equals("DE")).OrderBy(o => o.posicion);

                foreach (Menu  menuItem in itemsGrupo)
                {
                    NavBarItem item = new NavBarItem(menuItem.titulo);
                    item.Tag = menuItem;
                    item.Name = menuItem.nomMenu;
                    item.LargeImage = menuItem.iconoGrande != null ? UtilitarioComun.byteA_Imagen(menuItem.iconoGrande) : UtilitarioComun.byteA_Imagen(menuGrupo.iconoGrande);
                    item.SmallImage = menuItem.iconoPequenio != null ? UtilitarioComun.byteA_Imagen(menuItem.iconoPequenio) : UtilitarioComun.byteA_Imagen(menuGrupo.iconoPequenio);

                    grupo.ItemLinks.Add(item);
                }
                nbcMenuPrincipal.Groups.Add(grupo);
            }
            nbcMenuPrincipal.EndUpdate();
        }

        public static frmDialogo NuevoMenuPopup(Menu menu, Principal padre)
        {
            MenuModulo menuModulo = new MenuModulo(menu, RegistroModuloHelper.BuscarModulo(menu.control));
            return menuModulo.TControlDialogo;
        }
        public static FormBase AbrirFormulario(Menu menu, Principal padre)
        {
            FormBase frm = null;

            frm = new FormBase(new MenuModulo(menu, RegistroModuloHelper.BuscarModulo(menu.control)), null, padre.PopupMenu);
            //frm.FrmPrincipal = padre;
            frm.Anio = padre.PrincipalPresentador.Anio;
            frm.Mes = padre.PrincipalPresentador.Mes;
            frm.IdMoneda = padre.PrincipalPresentador.IdMoneda;
            frm.IdTipCam = padre.PrincipalPresentador.IdTipCam;
            frm.Usuario = padre.PrincipalPresentador.UsuarioOperacion;
            //frm.EjercicioContable = padre.PrincipalPresentador.EjercicioContable;
            frm.MdiParent = padre;
            frm.InicilizarModulo();
            frm.Show();

            return frm;
        }
    }
}
